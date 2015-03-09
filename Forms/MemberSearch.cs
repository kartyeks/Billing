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
    public partial class  MemberSearch : Form
    {
        public MemberSearch()
        {
            InitializeComponent();
        }
        void MemberSearch_Load(object sender, System.EventArgs e)
        {
            //bindSource.DataSource = BillController._billController.DataStore.GetItemDetails();
            cmbMem.SelectedIndex = 0;
            txtName.Focus();
        
        }
         

        private void tblSelect_Click(object sender, EventArgs e)
        {
            
          
        }

        private void tblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void grdDep_DoubleClick(object sender, System.EventArgs e)
        {
             //tblSelect_Click(this.grdDep,new EventArgs());
            DataGridViewRow crow = grdDep.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row", "Billing");
                return;
            }
            picMem.Image = null;
            picDep.Image = null; 
            string depId = crow.Cells[4].Value.ToString();
            DependantMemberDetails dep = BillController._billController.GetDependantMember(depId);
            if (dep != null)
            {
                txtAddr.Text = dep._address;
                txtPhoneNo.Text = dep._phoneNo;
                txtMobileNo.Text = dep._mobileNo;
                txtEmail.Text = dep._email;
                if (dep._dPhoto.Length > 1)
                {
                    System.IO.Stream strm = new System.IO.MemoryStream(dep._dPhoto);
                    picDep.Image = Image.FromStream(strm);
                }
                if (dep._mPhoto != null)
                {
                    if (dep._mPhoto.Length > 1)
                    {
                        System.IO.Stream mstrm = new System.IO.MemoryStream(dep._mPhoto);
                        picMem.Image = Image.FromStream(mstrm);
                    }
                }
            }
        }
        void grdDep_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tblSelect_Click(this.grdDep, new EventArgs());
                e.Handled = true;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fld="AccountNumber";
            if(cmbMem.Text=="Member Name")
                fld="MemberName";
            BillingBasicStatusMessagae msg = BillController._billController.GetMemberList(txtName.Text, fld);
            if (!msg._isSuccess) return;
            DependantMemberDetails[] deps = BillController._billController.DataStore.GetDependantMemberDetail();
            grdDep.Rows.Clear();
            if (deps.Length > 0)
            {
                grdDep.Rows.Add(deps.Length);
                int k = 0;
                foreach (DependantMemberDetails dm in deps)
                {
                    DataGridViewRow dr = grdDep.Rows[k];
                    dr.Cells["MemberName"].Value = dm._memberName;
                    dr.Cells["AccountNumber"].Value = dm._accountNumber;
                    dr.Cells["Category"].Value = dm._category;
                    dr.Cells["dob"].Value = dm._dob;
                    dr.Cells["MemberID"].Value = dm._memberID;
                    k++;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataGridViewRow crow = grdDep.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row", "Billing");
                return;
            }
            ((ICMSBill)this.Owner).txtAccNo.Text =string.Concat( crow.Cells["AccountNumber"].Value);
            ((ICMSBill)this.Owner).txtAccNo.Focus();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((ICMSBill)this.Owner).txtAccNo.Text = "";
            ((ICMSBill)this.Owner).txtAccNo.Focus();
            this.Close();
        }

    

    }
}
