using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using IRCABrowserLocalService;

namespace TallySynchronizer
{
    public class TallyExceptionHandler
    {
        public static StatusUpdater StatusUpdater;
        public static bool LOGALL = false;

        private static void Log(String FileName, String Message,String Data)
        {
            try
            {
                if (null != StatusUpdater)
                {
                    if (Message.Contains("\n"))
                    {
                        StatusUpdater.AddStatus(Message.Remove(Message.IndexOf("\n")));
                    }
                    else
                    {
                        StatusUpdater.AddStatus(Message);
                    }
                }

                StreamWriter file;
                Uri uri = new Uri(FileName);
                file = new StreamWriter(uri.LocalPath, true);
                String LogData = String.Format("\n\n{0}\n{1}\n\t\t{2}", DateTime.Now, Message, Data);
                file.WriteLine(LogData);
                file.Flush();
                file.Close();
            }
            catch (Exception ex) { }
        }

        public static void HandleException(TallyException e)
        {
            Log(GetLogFilePath(), "Error-->>" + e.ToString(), e.Data);
        }

        public static void HandleException(Exception e)
        {
            Log(GetLogFilePath(), "Error-->>" + e.ToString(), String.Empty);
        }

        public static void HandleMessage(String Message)
        {
            String Path = GetLogDirectory() + "\\TallyMessages_" + DateTime.Today.ToString("dd-MM-yyyy") + ".log";

            Log(Path, Message, String.Empty);
        }

        public static void HandleTrace(String Message)
        {
            if (LOGALL)
            {
                String Path = GetLogDirectory() + "\\TallyTrace_" + DateTime.Today.ToString("dd-MM-yyyy") + ".log";

                Log(Path, Message, String.Empty);
            }
        }

        public static String GetLogFilePath()
        {
            String path = GetLogDirectory() + "\\TallyExceptions_" + DateTime.Today.ToString("dd-MM-yyyy") + ".log";

            return path;
        }

        private static String GetLogDirectory()
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            path = path.Substring(0, path.LastIndexOf("\\")) + "\\_logs";

            Uri uri = new Uri(path);
            if (!Directory.Exists(uri.LocalPath))
            {
                Directory.CreateDirectory(uri.LocalPath);
            }

            return path;
        }
    }

    public class TallyException : Exception
    {
        private String _message;
        private String _data;

        public override String Message
        {
            get { return _message; }
        }

        public String Data
        {
            get { return _data; }
        }

        public TallyException(String Message, String Data)
        {
            _message = Message;
            _data = Data;
        }
    }
}
