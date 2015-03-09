using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using IRCAKernel;

namespace IRCABrowserLocalService
{
    public interface StatusUpdater
    {
        void Clear();
        void AddStatus(String StatusMessage);
        void SetMessage(String Message);
        String HandleRequest(Dictionary<String, String> PostedInformation);
    }

    public class HttpRequestManager
    {
        private StatusUpdater _StatusUpdater = null;
        private int _Port = 8080;
        private bool _EndListen = false;
        private HttpListener _Listener = null;
        private bool _IsStarted = false;

        public int ListenerPort
        {
            get 
            { 
                return _Port; 
            }
            set 
            { 
                _Port = value; 
            }
        }
        
        public HttpRequestManager(StatusUpdater StatusUpdater)
        {
            _StatusUpdater = StatusUpdater;
        }

        protected void AddStatus(String StatusMessage)
        {
            if (null != _StatusUpdater)
            {
                _StatusUpdater.AddStatus(StatusMessage);
            }
        }

        protected void ClearStatus()
        {
            if (null != _StatusUpdater)
            {
                _StatusUpdater.Clear();
            }
        }

        public void Start()
        {
            // Create a new thread for the listener and start the service
            new Thread(this.StartService).Start();
            new Thread(this.CheckAndRestart).Start();
        }

        private void CheckAndRestart()
        {
            IRCAAppSettings Settings = IRCAAppSettings.getAppSettings(IRCAUtils.getAppSettingPathForExe(), IRCAUtils.getAppSettingsFileName());

            int interval;

            int.TryParse(Settings.getSettings("checkinterval"), out interval);
            
            for (; ; )
            {
                Thread.Sleep(60000 * interval);
                if ((!_IsStarted) || _EndListen)
                {
                    _EndListen = false;
                    StartService();
                }
            }
        }

        private void StartService()
        {
            if (!_IsStarted)
            {
                _IsStarted = true;

                int errorcount = 0;

                for (; errorcount < 3 && (!_EndListen); )
                {                    
                    try
                    {
                        _Listener = new HttpListener();

                        _Listener.Prefixes.Add("http://*:8080/");

                        _Listener.Start();

                        AddStatus("Listener Started @ port:" + ListenerPort);

                        _EndListen = false;
                        errorcount = 0;
                        while (!_EndListen)
                        {
                            HttpListenerContext Context = _Listener.GetContext();
                            new RequestProcessor(_StatusUpdater, Context).ProcessRequest();
                        }

                        ClearStatus();
                    }
                    catch (Exception e)
                    {
                        // Log exception if thread exit was not triggered by user action
                        Thread.Sleep(1000);
                        errorcount++;
                        if (!_EndListen)
                        {   
                            AddStatus(e.ToString());
                        }
                    }
                }

                _EndListen = true;
                _IsStarted = false;
            }
            else
            {
                AddStatus("Service Already Running...");
            }            
        }

        public void Stop()
        {
            if (_IsStarted)
            {
                _EndListen = true;
                _IsStarted = false;
                _Listener.Stop();
                
                AddStatus("Service Stopped");
            }
        }
    }

    class RequestProcessor
    {
        private HttpListenerContext _Context;
        private StatusUpdater _StatusUpdater;

        public RequestProcessor(StatusUpdater StatusUpdater, HttpListenerContext context)
        {
            this._Context = context;
            _StatusUpdater = StatusUpdater;
        }

        public void ProcessRequest()
        {
            _StatusUpdater.AddStatus("Request Received");

            StringBuilder sb = new StringBuilder();

            try
            {
                String PostedData = _Context.Request.Url.PathAndQuery;

                PostedData = PostedData.Remove(0, PostedData.IndexOf("?") + 1);

                _StatusUpdater.AddStatus("Processing Request:" + PostedData);
                // Process posted data

                String[] PostedDataTerms = PostedData.Split(new String[]{"&"}, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<String, String> PostedInformation = new Dictionary<string,string>();
                
                foreach (String PostedDataTerm in PostedDataTerms)
                {
                    String[] PostedTermParts = PostedDataTerm.Split(new String[] { "=" }, StringSplitOptions.None);

                    if (PostedTermParts.Length == 2)
                    {
                        PostedInformation.Add(PostedTermParts[0], PostedTermParts[1]);
                    }
                    else if (PostedTermParts.Length == 1)
                    {
                        PostedInformation.Add(PostedTermParts[0], String.Empty);
                    }
                }

                String Response = _StatusUpdater.HandleRequest(PostedInformation);

                _StatusUpdater.AddStatus("Request Processed");

                sb.Append(Response);
            }
            catch (Exception e)
            {
                _StatusUpdater.AddStatus("Error in processing request:" + e.ToString());
            }

            byte[] b = Encoding.UTF8.GetBytes(sb.ToString());
            
            _Context.Response.AppendHeader("content-type", "text/html");

            _Context.Response.ContentLength64 = b.Length;
            _Context.Response.OutputStream.Write(b, 0, b.Length);
            _Context.Response.OutputStream.Close();

            _StatusUpdater.AddStatus("Response Sent");
        }
    }
}
