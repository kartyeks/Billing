using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace IRCAKernel
{
    /// <summary>
    /// The exception handler will handle all the exceptions. When a exceptions is given to handler
    /// that will be store in a queue. Another thread will pick and log
    /// </summary>
    public class IRCAExceptionHandler
    {
        private static Dictionary<String, String> _LogCheckMap = new Dictionary<string, string>();
        private static Dictionary<String, StreamWriter> _FileMap = new Dictionary<string, StreamWriter>();

        private Queue<Object> _LogData;
        private Semaphore _Synchronize;
        private static IRCAExceptionHandler _ExceptionHandler;

        /// <summary>
        /// Static constructor, which will be run when class getting loaded
        /// </summary>
        static IRCAExceptionHandler()
        {
            _ExceptionHandler = new IRCAExceptionHandler();
        }

        /// <summary>
        /// Constructor which creates queue and synchronize object
        /// </summary>
        private IRCAExceptionHandler()
        {
            _LogData = new Queue<object>();
            _Synchronize = new Semaphore(0, 1000);

            new Thread(this.LogData).Start();
        }

        /// <summary>
        /// Sysnchronized call to get the data. This call will be waiting until some one post the data
        /// </summary>
        /// <returns></returns>
        private Object GetMessage()
        {
            _Synchronize.WaitOne();
            lock (_LogData)
            {
                return _LogData.Dequeue();
            }
        }

        /// <summary>
        /// Synchronized call to set the data.
        /// </summary>
        /// <param name="Message"></param>
        private void SetMessage(Object Message)
        {
            lock (_LogData)
            {
                _LogData.Enqueue(Message);
                _Synchronize.Release();
            }
        }

        /// <summary>
        /// The method which will be running in a thread. Once the data posted this will pick the data and process.
        /// Based on the exception type, the details will be logged
        /// </summary>
        private void LogData()
        {
            for (; ; )
            {
                Object Data = GetMessage();

                if (Data is Exception)
                {
                    Log(GetErrorLogFilePath(), ((Exception)Data).Message + "\n" + ((Exception)Data).StackTrace, String.Empty);
                }
                else if (Data is IRCAException)
                {
                    Log(GetErrorLogFilePath(), ((IRCAException)Data).Message + "\n" + ((IRCAException)Data).StackTrace , ((IRCAException)Data).Data);
                }
                else
                {
                    Log(GetMessageLogFilePath(), (String)Data, String.Empty);
                }
            }
        }

        /// <summary>
        /// Logs all the error message and error data
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Message"></param>
        /// <param name="Data"></param>
        private void Log(String FileName, String Message, String Data)
        {
            try
            {
                StreamWriter file;
                Uri uri = new Uri(FileName);

                if (_FileMap.ContainsKey(uri.LocalPath))
                {
                    file = _FileMap[uri.LocalPath];
                }
                else
                {
                    file = new StreamWriter(uri.LocalPath, true);
                    _FileMap.Add(uri.LocalPath, file);
                }

                file.WriteLine("\n" + DateTime.Now + "\n" + Message + Data);
                file.Flush();
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Function to get the error log file path
        /// </summary>
        /// <returns></returns>
        private static String GetErrorLogFilePath()
        {
            String path = GetLogDirectory() + "\\IRCAExceptions_" + DateTime.Today.ToString("dd-MM-yyyy") + ".log";

            return path;
        }

        /// <summary>
        /// Get the message log path
        /// </summary>
        /// <returns></returns>
        private static String GetMessageLogFilePath()
        {
            String path = GetLogDirectory() + "\\IRCAMessages_" + DateTime.Today.ToString("dd-MM-yyyy") + ".log";

            return path;
        }

        /// <summary>
        /// Get the log directory. If the directory is not available that will be created.
        /// Also cleares the log files which are 10 days older
        /// </summary>
        /// <returns></returns>
        private static String GetLogDirectory()
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

            path = path.Substring(0, path.LastIndexOf("\\")) + "\\_logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(new Uri(path).AbsolutePath);
            }
            else
            {
                if (!_LogCheckMap.ContainsKey(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    String[] LogFiles = System.IO.Directory.GetFiles(new Uri(path).AbsolutePath);

                    foreach (String LogFile in LogFiles)
                    {
                        if (File.GetLastAccessTime(LogFile) < DateTime.Now.AddDays(-10))
                        {
                            File.Delete(LogFile);
                        }
                    }

                    _LogCheckMap.Add(DateTime.Now.ToString("yyyy-MM-dd"), String.Empty);
                }
            }

            return path;
        }

        /// <summary>
        /// Ths static method which will be called by others for handle exception
        /// </summary>
        /// <param name="e"></param>
        public static void HandleException(Exception e)
        {
            _ExceptionHandler.SetMessage(e);
        }

        /// <summary>
        /// Ths static method which will be called by others for handle message
        /// </summary>
        /// <param name="Message"></param>
        public static void HandleMessage(String Message)
        {
            _ExceptionHandler.SetMessage(Message);
        }

    }

    /// <summary>
    /// The class which we can store the custom details
    /// </summary>
    public class IRCAException : Exception
    {
        private String _message;
        private String _data;
        private Exception exception;

        /// <summary>
        /// Provides the custom message
        /// </summary>
        public override String Message
        {
            get
            {
                if (exception == null)
                {
                    return _message;
                }
                else
                {
                    return exception.Message + "\n" + _message;
                }
            }
        }

        /// <summary>
        /// Provides the data
        /// </summary>
        public String Data
        {
            get
            {
                if (exception == null)
                {
                    return _data;
                }
                else
                {
                    return exception.Data + "\n" + Data;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message">The error message</param>
        /// <param name="Data">The Error data</param>
        public IRCAException(String Message, String Data)
        {
            _message = Message;
            _data = Data;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="e">Exception object</param>
        public IRCAException(Exception e)
        {
            exception = e;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="e">Exception Object</param>
        /// <param name="Message">Error Message</param>
        /// <param name="Data">Error Data</param>
        public IRCAException(Exception e, String Message, String Data)
        {
            _message = Message;
            _data = Data;
            exception = e;
        }
    }
}
