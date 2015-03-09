using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BillinManager.Forms;
using System.Diagnostics;
using BillingManager.Forms;
namespace BillingManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            String proc = Process.GetCurrentProcess().ProcessName;
            
            Process[] processes=Process.GetProcessesByName(proc);
            
            if (processes.Length > 1)
            {
                Process.GetCurrentProcess().Close();
                Process.GetCurrentProcess().Dispose();
                //MessageBox.Show("Application is already running");
                //return;
            }
            BillController._billController = BillController.CreateController();
            
            Application.Run(new LoginForm());
        }
    }
}
