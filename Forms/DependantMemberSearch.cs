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
    public partial class DependantMemberSearch : Form
    {
        public DependantMemberSearch()
        {
            InitializeComponent();
        }
        void DependantMemberSearch_Load(object sender, System.EventArgs e)
        {
            //bindSource.DataSource = BillController._billController.DataStore.GetItemDetails();
        
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
            string depId = crow.Cells[0].Value.ToString();
            DependantMemberDetails dep = BillController._billController.GetDependantMember(depId);
            if (dep != null)
            {
                txtAddr.Text = dep._address;
                txtPhoneNo.Text = dep._phoneNo;
                txtMobileNo.Text = dep._mobileNo;
                txtEmail.Text = dep._email;
                if (dep._dPhoto != null)
                {
                    if (dep._dPhoto.Length > 1)
                    {
                        System.IO.Stream strm = new System.IO.MemoryStream(dep._dPhoto);
                        picDep.Image = Image.FromStream(strm);
                    }
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
        void txtMemberID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void cmbRel_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMemberID.Text.Trim() == "" && txtName.Text.Trim() == "")
            {
                MessageBox.Show("Enter Member ID Or Dependant Name","Dependant Search",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (  txtName.Text.Trim() != "" && txtName.Text.Trim().Length <3)
            {
                MessageBox.Show("atleast Enter Three Letters for Dependant Name ", "Dependant Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BillingBasicStatusMessagae msg = BillController._billController.GetDependantMemberList( txtName.Text, cmbRel.Text,txtMemberID.Text);
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
                    dr.Cells["DependantID"].Value = dm._dependantID;
                    dr.Cells["DependantName"].Value = dm._dependantName;
                    dr.Cells["MemberName"].Value = dm._memberName;
                    dr.Cells["AccountNumber"].Value = dm._accountNumber;
                    dr.Cells["Category"].Value = dm._category;
                    dr.Cells["Relation"].Value = dm._realtion;
                    dr.Cells["dob"].Value = dm._dob;
                    dr.Cells["MemberID"].Value = dm._memberID;
                    k++;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMemberID.Text = "";
            txtName.Text = "";
            cmbRel.SelectedIndex = -1;
            grdDep.Rows.Clear();
        }

    

    }
}
