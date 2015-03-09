using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCAKernel;
using System.Reflection;
using System.IO;
using System.Web;
using IRCA.Communication;


namespace ApplicationManager
{
    /// <summary>
    /// All the request from the page will come to this class. 
    /// This will be responsible to send to different handlers
    /// The other handlers will convert the request data as the object and process.
    /// The handler will give the response as CommunicationObject and it will be converted as JSON String and sent to client
    /// </summary>
    public class AppRequestHandler
    {
        private static Dictionary<String, IRCARequestHandler> _MapHandler = new Dictionary<string, IRCARequestHandler>();

        static AppRequestHandler()
        {
            try
            {
                Assembly[] AllAssemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (Assembly assembly in AllAssemblies)
                {
                    try
                    {
                        foreach (var type in assembly.GetTypes())
                        {
                            if (type.IsClass && typeof(IRCARequestHandler).IsAssignableFrom(type) && (!type.IsAbstract))
                            {
                                IRCARequestHandler RequestHandler = (IRCARequestHandler)Activator.CreateInstance(type);

                                String[] Commands = RequestHandler.GetCommands();

                                for (int i = 0; i < Commands.Length; i++)
                                {
                                    if (!_MapHandler.ContainsKey(Commands[i]))
                                    {
                                        _MapHandler.Add(Commands[i], RequestHandler);
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
            }
        }

        public Object ProcessRequest(String RequestCommand, String RequestData)
        {
            if (_MapHandler.ContainsKey(RequestCommand))
            {
                return _MapHandler[RequestCommand].ProcessRequest(RequestCommand, RequestData);
            }
            else
            {
                return "";
            }
        }

    }
}
