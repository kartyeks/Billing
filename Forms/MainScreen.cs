using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IRCAKernel;
using System.Reflection;
using BillingManager;
using BillingManager.Forms;
using BillinManager.Forms;
using PDACommunications;

namespace BillingManager.Forms
{
    public partial class MainScreen : Form
    {
        private BillController _bcontroller;
        private bool _isClosing;
        public MainScreen()
        {
            InitializeComponent();

            //this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //this.MinimumSize = this.Size;
            //this.MaximumSize = this.MinimumSize;

            this.Text = this.Text + "  " + Assembly.GetAssembly(this.GetType()).GetName().Version.ToString();

            _bcontroller = BillController._billController;

            int h = SystemInformation.PrimaryMonitorMaximizedWindowSize.Height;
            int w = SystemInformation.PrimaryMonitorMaximizedWindowSize.Width;

            int bannerLocation =0;
            int bannerHeight = h / 3;
            int bgLocation = bannerLocation + bannerHeight -1;
            int bgHeight = h - bannerHeight;

             
        }
        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if(_isClosing)return;
            if (MessageBox.Show("Do you want Exit?", "Billing", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            _isClosing = true;
            this.Close();
            Application.Exit();

        }

        private void ViewCaddie_Click(object sender, EventArgs e)
        {
         //   new CaddieList().ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(BillDefs.EXIT_CONFIRM, BillDefs.EXIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                _isClosing = true;
                Application.Exit();                
            }
        }

        private void btnCaddieLogin_Click(object sender, EventArgs e)
        {
         //   new CaddieValidator(CaddieActionType.CaddieEntry).ShowDialog(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           // new CaddieValidator(CaddieActionType.CaddieLunch).ShowDialog(this);
        }

        private void btnMemberCaddieAssignment_Click(object sender, EventArgs e)
        {
         //   new MemberCaddieAssignment( ).ShowDialog(this);
        }

        private void btnCaddieExit_Click(object sender, EventArgs e)
        {
           // new CaddieValidator(CaddieActionType.CaddieExit).ShowDialog(this);
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
           BillingMenu[] arrMnu=  _bcontroller.DataStore.GetMenu();
           int k = 1;
           foreach (BillingMenu mn in arrMnu)
           {
               LinkLabel lLbl = new LinkLabel();
               lLbl.Left = lnkBill.Left;
               lLbl.Top = lnkBill.Top + (k*30);
               this.Controls.Add(lLbl); 
               lLbl.Text = mn._menuName;
               lLbl.Tag= mn._storeId;
               lLbl.Font = new Font("Arial", 12);
               lLbl.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBill_LinkClicked);
               k++;
           }
        }

        private void lnkBill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ICMSBill objBill = new ICMSBill(this);
            objBill.StoreId = string.Concat(((LinkLabel)sender).Tag);
            //objBill.txtposn.Text = string.Concat(((LinkLabel)sender).Text);
            objBill.StartPosition = FormStartPosition.CenterParent;
            objBill.MdiParent=this.Owner;
            ((Main)this.Owner).pictureBox1.Height = 50;
            ((Main)this.Owner).pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage ;
            objBill.Show();
            _isClosing = true;
            this.Close();
        }
    }
}
