using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDACommunications;
using BillingManager;
using BillingManager.Forms;
using XCoolForm;
using XCoolFormTest;
using System.IO;

namespace BillinManager.Forms
{
    public partial class LoginForm :Form//: XCoolForm.XCoolForm
    {
        //private XmlThemeLoader xtl = new XmlThemeLoader();
        private BillController _billController;
        private bool _isClosing=false;
        BillingBasicStatusMessagae initResponse   = null;
        internal string posId = "0";
        internal string storedposId = "0";
        internal string storeId = "0";
        internal string ordtckt= "KOT";
        BillingMenu[] bloc = null;
        public LoginForm()
            //: base()
        {
            InitializeComponent();

            _billController = BillController.CreateController();

            if (!_billController.IsServerURLSet())
            {
                new URLEntryForm().ShowDialog(this);
            }

            _billController.StartController();
            initResponse = _billController.Initialize();
            StartPosition = FormStartPosition.CenterScreen;
            LoadPOS();
        }

        //private void frmCoolForm_Load(object sender, EventArgs e)
        //{
        //    this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(150, "Date : "+DateTime.Now.ToString("dd/MM/yyyy")));
        //    this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(250, "Powered by IRCA India Pvt. Ltd."));
        //    this.StatusBar.EllipticalGlow = false;
        //    xtl.ThemeForm = this;
        //    this.TitleBar.TitleBarCaption = "Clover Green Login Form";
        //    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Themes\BlueWinterTheme.xml"));
        //}

        private void LoadPOS()
        {
            bloc = _billController.DataStore.GetMenu();
            cmbSStore.Items.Add("ALL");
            foreach (BillingMenu loc in bloc)
            {
                cmbSStore.Items.Add(loc._storeName + "(" + loc._storeCode + ")");
            }
            cmbSStore.SelectedIndex = 0;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            posId = "0";
            storedposId = "0";
            storeId = "0";
            ordtckt= "KOT";
            if (txtLoginName.Text.Trim().Equals(""))
            {
                lblMessage.Text = BillDefs.NO_NAME;

                return;
            }
            txtLoginName.Enabled = false;
            txtPassword.Enabled = false;

            lblMessage.Text = "Connecting to Server ....";

            BillingLoginResponse respone = _billController.Login(txtLoginName.Text.Trim(), txtPassword.Text.Trim());

            if (respone._isSuccess)
            {
                lblMessage.Text = "Starting Application ....";

                if (initResponse._isSuccess)
                {
                    _billController.DataStore.LoggedInPersonId = respone._personID;
                    _billController.DataStore.LoggedInUserId = respone._userId;
                    _billController.DataStore.LoggedInUser = respone._userName;
                    _billController.DataStore.UserPermissions = respone._permission;
                    storedposId = respone._posId;
                    if (storedposId == string.Empty) storedposId = "0";
                    if (storedposId == "-1")
                    {
                        lblMessage.Text = "";
                        MessageBox.Show("User has No Permission", BillDefs.ERROR);

                        txtLoginName.Enabled = true;
                        txtPassword.Enabled = true;
                        txtLoginName.Text = "";
                        txtPassword.Text = "";
                        txtLoginName.Focus();
                        return;
                    }

                    if (storedposId != "0")
                    {
                        storeId = storedposId;
                    }
                    if (bloc != null)
                        {
                            int ind = -1;
                            if (storeId != "0")
                            {
                                ind = Array.FindIndex(bloc, (x) => (x._storeId== storeId));
                            }
                            else
                            {
                                ind = Array.FindIndex(bloc, (x) => (x._storeName + "(" + x._storeCode + ")" == cmbSStore.Text));
                            }
                            if (ind > -1)
                            {
                                if (cmbSStore.Text != "ALL")
                                {
                                    if (cmbSStore.Text != bloc[ind]._storeName + "(" + bloc[ind]._storeCode + ")")
                                    {
                                        lblMessage.Text = "";
                                        MessageBox.Show("User has No Permission for selected POS", BillDefs.ERROR);

                                        txtLoginName.Enabled = true;
                                        txtPassword.Enabled = true;
                                        txtLoginName.Text = "";
                                        txtPassword.Text = "";
                                        txtLoginName.Focus();

                                        return;
                                    }
                                    storeId = bloc[ind]._storeId;
                                    posId = bloc[ind]._storeCode;
                                    if (bloc[ind]._catId == "1")
                                        ordtckt = "BOT";
                                    else
                                        ordtckt = "KOT";

                                }
                                
                                
                            }
                        }
                    this.SetVisibleCore(false);
                    this.DialogResult = DialogResult.Yes;
                    _isClosing = true;
                    
                    //new code 
                    ICMSBill objBill = new ICMSBill(this);
                    //objBill.StartPosition = FormStartPosition.CenterParent;
                    //objBill.MdiParent = this.MdiParent;
                    objBill.loginPOSId = this.posId;
                    objBill.loginStoreId = this.storeId;
                    objBill.loginOT = this.ordtckt;
                    objBill.storedPOSId = this.storedposId;                    
                    objBill.Show();
                    lblMessage.Text = "";
                    txtLoginName.Enabled = true;
                    txtPassword.Enabled = true;
                    txtLoginName.Text = "";
                    txtPassword.Text = "";
                    txtLoginName.Focus();
                    //this.Hide();
                }
                else
                {
                    lblMessage.Text = initResponse._message;
                }
            }
            else
            {
                lblMessage.Text = "";
                MessageBox.Show(respone._message, BillDefs.ERROR);

                txtLoginName.Enabled = true;
                txtPassword.Enabled = true;
                txtLoginName.Text = "";
                txtPassword.Text = "";
                txtLoginName.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        void txtLoginName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isClosing = true;
            Application.Exit();
        }
        void LoginForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!_isClosing)
            {
                if (DialogResult.Yes == MessageBox.Show(BillDefs.EXIT_CONFIRM, BillDefs.EXIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _isClosing = true;

                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    _isClosing = false;
                }
            }
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            new URLEntryForm().ShowDialog(this);
            _billController.StartController();
        }

        private void txtLoginName_Enter(object sender, EventArgs e)
        {
            txtLoginName.Select(0, txtLoginName.Text.Length);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Select(0, txtPassword.Text.Length);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
