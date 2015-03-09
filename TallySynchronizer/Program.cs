using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace TallySynchronizer
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length > 1 && args[0] == "LOGALL")
            {
                TallyExceptionHandler.LOGALL = true;
            }

            StartSynchronizer();
        }

        public static void StartSynchronizer()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void StopSynchronizer()
        {
            Application.ExitThread();
        }
    }
}
