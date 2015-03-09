using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using IRCABrowserLocalService;
using IRCAKernel;

namespace TallySynchronizer
{
    public partial class Form1 : Form, StatusUpdater
    {
        private IRCARegistery _registery;
        private HttpRequestManager _RequestManager = null;

        private static readonly String DBString = "DBSTRING";
        private static readonly String TallyURL = "TALLYURL";
        private static readonly String Company = "COMPANY";

        public Form1()
        {
            InitializeComponent();

            rchStatus.Width = this.PreferredSize.Width - 20;
            rchStatus.Height = this.PreferredSize.Height - rchStatus.Location.Y - 20;

            TallyExceptionHandler.StatusUpdater = this;

            _registery = new IRCARegistery();

            txtDB.Text = _registery.Read(DBString);
            txtURL.Text = _registery.Read(TallyURL);
            txtCompany.Text = _registery.Read(Company);

            try
            {
                _RequestManager = new HttpRequestManager(this);

                _RequestManager.Start();
            }
            catch (Exception e)
            {
                TallyExceptionHandler.HandleException(e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormWindowState.Normal == WindowState)
            {
                Hide();
            }

            ((CancelEventArgs)e).Cancel = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        private void notifyServiceIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void mnuRestore_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(0);
        }

        #region StatusUpdater Members

        public void Clear()
        {
            Action action = () => rchStatus.Text = String.Empty;
            this.Invoke(action);
        }

        public void AddStatus(String StatusMessage)
        {
            Action action = () => rchStatus.Text = (DateTime.Now + " : " + StatusMessage + "\n") + rchStatus.Text;
            this.Invoke(action);
        }

        public void SetMessage(String Message)
        {
            Action action = () => lblStatus.Text = Message;
            this.Invoke(action);
        }

        #endregion

        private void btnSynchronize_Click(object sender, EventArgs e)
        {
            Clear();

            _registery.Write(DBString, txtDB.Text);
            _registery.Write(TallyURL, txtURL.Text);
            _registery.Write(Company, txtCompany.Text);

            Tally tally = new Tally(txtCompany.Text, txtURL.Text, txtDB.Text, this);

            tally.SynchronzieOffLineTransaction();
        }

        private void btnCheckDuplicate_Click(object sender, EventArgs e)
        {
            Clear();

            Tally tally = new Tally(txtCompany.Text, txtURL.Text, txtDB.Text, this);

            tally.CheckDuplicates(txtFrom.Text, txtTo.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        #region StatusUpdater Members

        public String HandleRequest(Dictionary<string, string> PostedInformation)
        {
            String Response = "Request Received by Tally Synchronizer";
            String ActionKey = String.Empty;

            foreach (KeyValuePair<String, String> KVP in PostedInformation)
            {
                if (KVP.Key == "Synchronize" || KVP.Key == "CheckDuplicate")
                {
                    ActionKey = KVP.Key;
                }
                else if (KVP.Key == "DateFrom")
                {
                    Action action = () => txtFrom.Text = KVP.Value;
                    this.Invoke(action);
                }
                else if (KVP.Key == "DateTo")
                {
                    Action action = () => txtTo.Text = KVP.Value;
                    this.Invoke(action);
                }
                else if (KVP.Key == "DBConnectionString")
                {
                    Action action = () => txtDB.Text = KVP.Value;
                    this.Invoke(action);
                }
                else if (KVP.Key == "TallyURL")
                {
                    Action action = () => txtURL.Text = KVP.Value;
                    this.Invoke(action);
                }
                else if (KVP.Key == "CompanyName")
                {
                    Action action = () => txtCompany.Text = KVP.Value;
                    this.Invoke(action);
                }
            }

            if (ActionKey == "Synchronize")
            {
                Action action = () => btnSynchronize_Click(null, null); 
                this.Invoke(action);
                
                Response = "Tally Synchronization has been requested.";
            }
            else if (ActionKey == "CheckDuplicate")
            {
                Action action = () => btnCheckDuplicate_Click(null, null);
                this.Invoke(action);

                Response = "Tally Duplicate Check has been requested.";
            }

            Thread.Sleep(3000);

            return Response + " Status:[" + lblStatus.Text + "]";
        }

        #endregion

        private void rchStatus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
