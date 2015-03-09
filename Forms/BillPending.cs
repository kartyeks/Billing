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
    public partial class BillPending : Form
    {
        public String StoreId=string.Empty;
        public String BillType = string.Empty;
        private BillController bController=BillController._billController;
        public BillPending()
        {
            InitializeComponent();
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
        }
        void ItemPopup_Load(object sender, System.EventArgs e)
        {
            //bindSource.DataSource = BillController._billController.DataStore.GetItemDetails();

          // BillingItemDetails[] itms  = BillController._billController.DataStore.GetItemDetails();
            if (!((ICMSBill)this.Owner).hasCancelPerm)
                    tblDelete.Enabled = false;
          
        }

        private void LoadPendingBill(PendingBillList pbList)
        {
            grdBill.Rows.Clear();
            grdBill.Rows.Add(pbList._pedbillList.Length);
            int k = 0;
            foreach (PendingBillDetails pb in pbList._pedbillList)
            {
                DataGridViewRow dr = grdBill.Rows[k];
                dr.Cells["BillID"].Value = pb._billId;
                dr.Cells["BillNumber"].Value = pb._billNumber;
                dr.Cells["BillDate"].Value = pb._billDate;
                dr.Cells["Member"].Value = pb._memberName;
                dr.Cells["MemberID"].Value = pb._memberId;
                dr.Cells["OTNo"].Value = pb._otNo;
                dr.Cells["ItemID"].Value = pb._ItemId;
                dr.Cells["ItemCode"].Value = pb._ItemCode;
                dr.Cells["ItemName"].Value = pb._ItemName;
                dr.Cells["Unit"].Value = pb._unitCode;
                dr.Cells["Quantity"].Value = pb._quantity;
                dr.Cells["BearerCode"].Value = pb._personCode;
                k++;
            }
        }
 
        
        void grdBill_DoubleClick(object sender, System.EventArgs e)
        {
             
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            PendingBillList pbList = new PendingBillList();

            pbList._accountNumber = txtAccNo.Text;
            pbList._billNumber = txtBillNumber.Text;
            pbList._fromDate = dtFrom.Value;
            pbList._toDate = dtTo.Value.AddDays(1) ;
            pbList._storeId = StoreId;
            pbList._billType = BillType;
            pbList._action = BillActionType.View;
            pbList._personCode = txtBearerCode.Text;

            pbList = bController.GetPendingBillDetails(pbList);
            if (pbList._action == BillActionType.Success)
            {
                LoadPendingBill(pbList);
                btnFind.Enabled= true;

            }
            else if (pbList._action == BillActionType.Failure)
            {
                grdBill.Rows.Clear();
                MessageBox.Show("Data is not Available", "Billing");
            }
        }

        private void grdBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tblDelete_Click(object sender, EventArgs e)
        {
            //PendingBillList pbList = new PendingBillList();
            PendingBillDetails pb = new PendingBillDetails();
            DataGridViewRow dr = grdBill.CurrentRow;
            if (dr == null)
            {
                MessageBox.Show("Select row to Delete","CMS Billing");
                return;
            }
            if (MessageBox.Show("Do you wish to Delete selected row?", "CMS Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            if (dr != null)
            {
                pb._billId =string.Concat(dr.Cells["BillID"].Value);
                pb._memberId = string.Concat(dr.Cells["MemberID"].Value);
                pb._otNo = string.Concat(dr.Cells["OTNo"].Value);
                pb._ItemId=string.Concat(dr.Cells["ItemID"].Value) ;
                double qty = 0;
                double.TryParse(string.Concat(dr.Cells["Quantity"].Value),out qty);
                pb._quantity = qty;
                DateTime dat = new DateTime(1900, 1, 1);
                DateTime.TryParse(string.Concat(dr.Cells["BillDate"].Value),out dat);
                if (dat.Year < 1900) dat = new DateTime(1900, 1, 1);
                pb._billDate = dat;
                pb._action = BillActionType.Cancel;

                pb=  bController.DeletePendingBillDetails(pb);
                if (pb._action == BillActionType.Success)
                {
                    MessageBox.Show("Selected row Deleted successfully", "CMS Billing");
                    grdBill.Rows.Remove(dr);
                }
                else
                {
                    MessageBox.Show("Error while Deleting Selected row ", "CMS Billing");
                }
            }

        }
    }
}
