using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using IRCAKernel;
using BillinManager.Forms;

namespace BillingManager.Forms
{
    public partial class Main : Form
    {
        private int childFormNumber = 0;
        private BillController _controller;
        private string POSId = "0";
        private string storedPOSId = "0";
        private string StoreId = "0";
        private string ordTckt= "KOT";
        public Main()
        {
            InitializeComponent();
            this.Text =  "Billing  " + Assembly.GetAssembly(this.GetType()).GetName().Version.ToString();

            _controller = BillController.CreateController();

            //int h = SystemInformation.PrimaryMonitorMaximizedWindowSize.Height;
            //int w = SystemInformation.PrimaryMonitorMaximizedWindowSize.Width;

            //int bannerLocation = 0;
            //int bannerHeight = h / 3;
            //int bgLocation = bannerLocation + bannerHeight - 1;
            //int bgHeight = h - bannerHeight;

            //picBanner.Size = new Size(w, bannerHeight);
            //picBanner.Location = new Point(0, bannerLocation);

            //picBG.Size = new Size(w, bgHeight);
            //picBG.Location = new Point(0, bgLocation);

            //picBG.Image = IRCAUtils.GetScalledImage(picBG.Image, picBG.Width, picBG.Height);
            //picBanner.Image = IRCAUtils.GetScalledImage(picBanner.Image, picBanner.Width, picBanner.Height);
            
        }
        void Main_Load(object sender, System.EventArgs e)
        {
            this.Show();
            ShowLogin();
        }
        void ShowLogin()
        {
            LoginForm login = new LoginForm();
            login.Owner = this;
            login.StartPosition = FormStartPosition.CenterParent;
            login.ShowDialog();
            if (login.DialogResult == DialogResult.Yes)
            {
                POSId = login.posId;
                StoreId = login.storeId;
                ordTckt = login.ordtckt;
                storedPOSId = login.storedposId;
                ShowBilling();
            }
        }
        void ShowBilling()
        {
            this.statusStrip.Items[0].Text = "Loged in User : " + BillController._billController.DataStore.LoggedInUser;
            ICMSBill objBill = new ICMSBill(this);
            objBill.StartPosition = FormStartPosition.CenterParent;
            objBill.MdiParent = this;
            pictureBox1.Height = 75;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            objBill.loginPOSId = POSId;
            objBill.loginStoreId = StoreId;
            objBill.loginOT=ordTckt;
            objBill.storedPOSId = storedPOSId;
            objBill.Show();
 
        }
        void Main_MdiChildActivate(object sender, System.EventArgs e)
        {
            if(this.ActiveMdiChild==null)
                ShowLogin();
        }

       
        void Main_Shown(object sender, System.EventArgs e)
        {
        }
        void Main_Click(object sender, System.EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Height = 50;
            ICMSBill objBill = new ICMSBill(this);
            objBill.StartPosition = FormStartPosition.CenterParent;
            objBill.MdiParent = this;
            objBill.Show();
        }
    }
}
