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
using XCoolForm;
using XCoolFormTest;
using System.IO;
namespace BillingManager.Forms
{
    public partial class BillSummary :Form//: XCoolForm.XCoolForm
    {
        //private XmlThemeLoader xtl = new XmlThemeLoader();
        public String StoreId=string.Empty;
        public String BillType = string.Empty;
        private BillController bController=BillController._billController;
        public BillSummary() //:base()
        {
            InitializeComponent();
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
            LoadCardRelatedData();
            cmbStatus.SelectedIndex = 0;
            LoadTable();
        }
        public void LoadTable()
        {
            TableNumber[] tbls = bController.DataStore.GetTableNo();
            cmbTable.ValueMember = "_tableId";
            cmbTable.DisplayMember = "_tableNo";
            cmbTable.Sorted = false;
            cmbTable.DataSource = tbls;
            cmbTable.SelectedIndex = 0;
        }
        public void LoadCardRelatedData()
        {
            
            ComboHead cctype = bController.GetCreditCardType();
            ComboHead edcr = bController.GetEDCMaster();
            if (cctype._action == BillActionType.Success)
            {
                //cmbCardType.DataSource =cctype._combo
                cmbCardType.Items.Clear();
                //foreach (Combo dr in cctype._combo)
                //{
                //    cmbCardType.Items.Add(dr._Value.ToString());
                //}
                Combo[] list = new Combo[cctype._combo.Length];
                cctype._combo.CopyTo(list, 0);

                
                cmbCardType.ValueMember = "_ID";
                cmbCardType.DisplayMember = "_Value";
                cmbCardType.Sorted = false;
                cmbCardType.DataSource = list;

            }
            if (edcr._action == BillActionType.Success)
            {
                cmbAcquirer.Items.Clear();
                //foreach (Combo dr in edcr._combo)
                //{
                //    cmbAcquirer.Items.Add(dr._Value.ToString());
                //}
                Combo[] list = new Combo[edcr._combo.Length];
                edcr._combo.CopyTo(list, 0);

                cmbAcquirer.ValueMember = "_ID";
                cmbAcquirer.DisplayMember = "_Value";
                cmbAcquirer.Sorted = false;
                cmbAcquirer.DataSource = list;

            }
        }
        
        private void BillSummary_Load(object sender, EventArgs e)
        {
            //frmCoolFormList_Load(sender, e);
            if (!((ICMSBill)this.Owner).hasCancelPerm)
            {
                tblBCancel.Visible = false;
                btnDelete.Visible = false;
                grdBill.Columns["Chk"].Visible = false;
                if (((ICMSBill)this.Owner).loginPOSId != "" || ((ICMSBill)this.Owner).loginPOSId != "0")
                {
                    //txtPOSID.Text = ((ICMSBill)this.Owner).loginPOSId;
                    StoreId = ((ICMSBill)this.Owner).StoreId;
                    //if (StoreId != "0")
                    //{
                    //    txtPOSID.Text = ((ICMSBill)this.Owner).POS;
                    //    txtPOSID.Enabled = false;
                    //}
                    //else
                    //{
                    //    txtPOSID.Text = "";
                    //    txtPOSID.Enabled = true;
                    //}
                }
                //else
                //{
                //    txtPOSID.Enabled = true;
                //}
            }
            else
            {
                btnDelete.Visible = true;
                grdBill.Columns["Chk"].Visible = true;
                if (((ICMSBill)this.Owner).loginPOSId != "" || ((ICMSBill)this.Owner).loginPOSId != "0")
                {
                    //txtPOSID.Text = ((ICMSBill)this.Owner).loginPOSId;
                    StoreId = ((ICMSBill)this.Owner).StoreId;
                    if (StoreId != "0")
                    {
                        //txtPOSID.Text = ((ICMSBill)this.Owner).POS;
                        //txtPOSID.Enabled = false;
                    }
                    else
                    {
                        //txtPOSID.Text = "";
                        //txtPOSID.Enabled = true;
                    }
                }
                else
                {
                    //txtPOSID.Enabled = true;
                }

            }
        }
        private void LoadBillSummary(BillSummaryList bsLst)
        {
            grdBill.Rows.Clear();
            grdBill.Rows.Add(bsLst._billSumList.Length);
            int k = 0; double totAmt = 0;
            foreach (BillSummaryDetails bs in bsLst._billSumList)
            {
                DataGridViewRow dr = grdBill.Rows[k];
                dr.Cells["BillID"].Value = bs._billId;
                dr.Cells["BillNumber"].Value = bs._billNumber;
                dr.Cells["BillDate"].Value = bs._billDate;
                dr.Cells["Member"].Value = bs._memberName;
                dr.Cells["MemberID"].Value = bs._memberId;
                dr.Cells["BillAmount"].Value = bs._amount;
                dr.Cells["Counter"].Value = bs._storeName;
                dr.Cells["Status"].Value = bs._status;
                totAmt = totAmt + bs._amount;
                k++;
            }
            txtTotAmt.Text = totAmt.ToString();
        }
        private void tblSelect_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow crow = grdBill.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row","Billing");
                return;
            }
            
            int bId = 0;
            int.TryParse(string.Concat(crow.Cells["BillID"].Value), out bId);
            ((ICMSBill)this.Owner).billId =bId ;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        
        void grdBill_DoubleClick(object sender, System.EventArgs e)
        {
             tblSelect_Click(this.grdBill,new EventArgs());
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
            BillSummaryList bsList = new BillSummaryList();

            bsList._billNumber = txtBillNumber.Text;
            bsList._fromDate = dtFrom.Value;
            bsList._toDate = dtTo.Value ;
            bsList._storeId = ((ICMSBill)this.Owner).posId;
            bsList._memberID = txtMemberID.Text;
            bsList._billType = BillType;
            bsList._KOTNumber = txtKOT.Text;
            bsList._TableId = Convert.ToInt32(((TableNumber)cmbTable.SelectedValue)._tableId);
            bsList._Status = cmbStatus.SelectedItem.ToString();

            bsList._action = BillActionType.Modify;

            BillSummaryList bslist = bController.GetBillSummary(bsList);
            if (bslist._action == BillActionType.Success)
            {
                LoadBillSummary(bslist);
               // btnFind.Enabled= false;
            }
            else if (bslist._action == BillActionType.Failure)
            {
                grdBill.Rows.Clear();
                txtTotAmt.Text = "";
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

        private void tblClear_Click(object sender, EventArgs e)
        {
            grdBill.Rows.Clear();
            txtBillNumber.Text = "";
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
            btnFind.Enabled = true;
            pnlAcChange.Visible = false;
            txtReason.Text = "";
            cmbStatus.SelectedIndex = 0;
            cmbTable.SelectedIndex = 0;
        }

        private void tblBCancel_Click(object sender, EventArgs e)
        {
            DataGridViewRow crow = grdBill.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row To Delete Bill", "CMS Billing");
                return;
            }
            lblBillNo.Text = string.Concat(grdBill.CurrentRow.Cells["BillNumber"].Value);
            pnlAcChange.Visible = true;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DataGridViewRow crow = grdBill.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row To Delete Bill", "CMS Billing");
                return;
            }

            int bId = 0;
            int.TryParse(string.Concat(grdBill.CurrentRow.Cells["BillID"].Value), out bId);
            if (MessageBox.Show("Do you want Delete the Bill? ", "Billing", MessageBoxButtons.YesNo) == DialogResult.No) return;
           
            BillCancel objBill = new BillCancel();
            objBill._billId = bId;
            objBill._reason = txtReason.Text;
            objBill._cancelledDate = DateTime.Now;
            BillController _bController = BillController._billController;
            objBill = _bController.CancelBilling(objBill);
            if (objBill == null) return;
            if (objBill._action == BillActionType.Success)
            {
                MessageBox.Show("Bill Cancelled Successfully");
                grdBill.Rows.Clear();
                txtBillNumber.Text = "";
                dtFrom.Value = DateTime.Today;
                dtTo.Value = DateTime.Today;
                pnlAcChange.Visible = false;
                txtReason.Text = "";
                return;
            }
            else
            {
                MessageBox.Show("Error occured while Cancelling....");
            }
        }

        private void btnCCancel_Click(object sender, EventArgs e)
        {
            pnlAcChange.Visible = false;
            txtReason.Text = "";
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            grdBill.Rows.Clear();
            txtBillNumber.Text = "";
            if(((ICMSBill)this.Owner).StoreId=="0")
            //txtPOSID.Text = "";

            txtMemberID.Text = "";
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
            txtReason.Text = "";
            txtTotAmt.Text = "";
            txtKOT.Text = "";
            pnlPaymentMode.Visible = false;
            pnlCardDetails.Visible = false;
            btnPayBill.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string billIds = string.Empty;
            string billNos = string.Empty;
            foreach (DataGridViewRow dr in grdBill.Rows)
            {
                 if (string.Concat(dr.Cells["Chk"].Value).ToLower() == "true")
                {   
                    billIds=billIds +"," + string.Concat(dr.Cells["BillID"].Value);
                    billNos = billNos + "\n\r" + string.Concat(dr.Cells["BillNumber"].Value);
                }
                    
            }
            if (billIds.Length==0)
            {
                MessageBox.Show("Select Row To Delete Bill", "CMS Billing");
                return;
            }
            billIds = billIds.Substring(1);
            
            if (MessageBox.Show("Do you want Delete the Following Bills? " + billNos , "CMS Billing", MessageBoxButtons.YesNo) == DialogResult.No) return;
             BillCancel objBill = new BillCancel();
            objBill._billIds = billIds;
            objBill._reason = "";
            objBill._cancelledDate = DateTime.Now;
            BillController _bController = BillController._billController;
            objBill = _bController.CancelBilling(objBill);
            if (objBill == null) return;
            if (objBill._action == BillActionType.Success)
            {
                MessageBox.Show("Selected Bills Deleted Successfully");
                grdBill.Rows.Clear();
                txtBillNumber.Text = "";
                txtMemberID.Text = "";
                dtFrom.Value = DateTime.Today;
                dtTo.Value = DateTime.Today;
                txtReason.Text = "";
                txtTotAmt.Text = "";
                return;
            }
            else
            {
                MessageBox.Show("Error occured while Cancelling....");
            }
        }
        void txtMemberID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void txtBillNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void txtKOT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void txtPOSID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void dtFrom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void dtTo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataGridViewRow crow = grdBill.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row", "Billing");
                return;
            }

            int bId = 0;
            int.TryParse(string.Concat(crow.Cells["BillID"].Value), out bId);
            ((ICMSBill)this.Owner).billId = bId;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DataGridViewRow crow = grdBill.CurrentRow;
            if (crow == null)
            {
                MessageBox.Show("Select Row", "Billing");
                pnlPaymentMode.Visible = false;
                pnlCardDetails.Visible = false;
                btnPayBill.Visible = false;
                btnRead.Visible = false;
                pnlMemberDetails.Visible = false;
                return;
            }
            else
            {
                if (string.Concat(crow.Cells["Status"].Value) != "Pending")
                {
                    MessageBox.Show("Bill already paid", "Billing");
                    pnlPaymentMode.Visible = false;
                    pnlCardDetails.Visible = false;
                    btnPayBill.Visible = false;
                    btnRead.Visible = false;
                    pnlMemberDetails.Visible = false;
                    return;
                }
            }
            pnlPaymentMode.Visible = true;
            btnPayBill.Visible = true;
            //pnlCardDetails.Visible=true;
            cmbPaymentMode.SelectedIndex = 0;
    //        public class PayBillObject : CommunicationObject
    //{
    //    public int _billId;
    //    public String _paymentMode;
    //    public int _memberId;
    //    public String _bankName;
    //    public int _creditCardType;
    //    public int _edcr;
    //    public String _creditCardNumber;
    //    public BillActionType _action;
    //}
           
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMode.SelectedIndex == 1)
            {
                pnlCardDetails.Visible = true;
                btnRead.Visible = false;
                pnlMemberDetails.Visible = false;
            }
            else if (cmbPaymentMode.SelectedIndex == 2)
            {
                pnlCardDetails.Visible = false;
                btnRead.Visible = true;
                pnlMemberDetails.Visible = true;
            }
            else
            {
                pnlCardDetails.Visible = false;
                btnRead.Visible = false;
                pnlMemberDetails.Visible = false;
            }
        }
        String cardPrefix = String.Empty;
        bool IsCashCard = false;
        bool IsRoomCard = false;
        private string GetCardDetails()
        {
            SmartCardReaderNew objSmart = new SmartCardReaderNew();
            if (!objSmart.IsCardConnected())
            {
                return string.Empty;
            }
            string cdata = objSmart.ReadSmartCardDataStr();
            if (cdata == string.Empty || cdata == null)
            {
                MessageBox.Show("Invalid Card", "CMS Billing Details");
                return string.Empty;
            }
            string[] arrVal = cdata.Split("$".ToCharArray());

            if (arrVal.Length < 3)
            {
                MessageBox.Show("Invalid Card", "CMS Billing Details");
                return string.Empty;
            }
            cardPrefix = arrVal[0] + "$";

            if (cardPrefix == IS91.Services.Common.GetAppSetting("CashCardPrefix"))
            {
                IsCashCard = true;
            }
            if (cardPrefix == IS91.Services.Common.GetAppSetting("RoomCardPrefix"))
            {
                IsRoomCard = true;
            }
            string mId = arrVal[1] + "_" + arrVal[2];
            return mId;
        }
        //private void LoadCardDetails()
        //{
        //    SmartCardReaderNew objSmart = new SmartCardReaderNew();
        //    if (objSmart.IsCardConnected())
        //    {
        //        return;
        //    }
        //    string cdata = objSmart.ReadSmartCardDataStr();
        //    if (cdata == string.Empty || cdata == null)
        //    {
        //        MessageBox.Show("Invalid Card", "CMS Billing Details");
        //        return;
        //    }
        //    string[] arrVal = cdata.Split("$".ToCharArray());

        //    if (arrVal.Length < 3)
        //    {
        //        MessageBox.Show("Invalid Card", "CMS Billing Details");
        //        return;
        //    }
        //    BillingMemberDetails _member = new BillingMemberDetails();
        //    string mId = arrVal[1];
        //    _member._memberID = mId;
        //    _member._curDateTime = DateTime.Now;
        //    _member._storeId = StoreId;
        //    if (cardPrefix == "") cardPrefix = "0";
        //    _member._cardPrefix = cardPrefix;
        //    BillingBasicStatusMessagae bmsg = bController.GetMember(ref _member);
        //    if (bmsg._isSuccess)
        //    {
        //        LoadMember(_member);
        //    }
        //    else if (!bmsg._isSuccess)
        //    {
        //        MessageBox.Show(bmsg._message, "CMS Billing Details");
        //    }
        //}
        BillingMemberDetails _memberObj = null;
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                _memberObj = null;
                string memId = GetCardDetails();
                if (memId == string.Empty) return;
                //WHILE READING CARD WILL GET MEMBERID, CARD SERIAL NO FOR BILLING
                //ADDED BY ARCHANA DEC18 2014
                string[] arrVal = memId.Split("_".ToCharArray());
                BillingMemberDetails _member = new BillingMemberDetails();
                _member._memberID = arrVal[0];// memId;
                _member._cardSerialNo = arrVal[1];
                _member._curDateTime = DateTime.Now;
                if (cardPrefix == "") cardPrefix = "0";
                _member._cardPrefix = cardPrefix;
                _member._storeId = StoreId;
                _member._IsSmartCard = true;

                if (_member._cardPrefix.Contains("DP"))
                    _member._dependantID = memId;

                BillingBasicStatusMessagae bmsg = bController.GetMember(ref _member);
                if (bmsg._isSuccess)
                {
                    if (_member._memberID == "0")
                    {
                        MessageBox.Show("Invalid Member", "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_member._memberID == "-2")
                    {
                        MessageBox.Show("Member InActive \n\r" + _member._reason, "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (_member._memberID == "-1")
                    {
                        MessageBox.Show("Member exceeds Credit Limit, cannot proceed", "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (_member._clubID == "-3")
                    {
                        if (MessageBox.Show("Member exceeds Credit Limit, do you want to proceed?", "CMS Billing Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else if (_member._clubID == "-4")
                    {
                        MessageBox.Show("Room already Checkedout, cannot proceed", "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //CHECK WHILE READ CARD LATEST CARD SERIAL NUMBER FROM DB WITH SERIAL NUMBER FROM CARD,IF MATCH ALLOW ELSE THROW MESSAGE
                    if (arrVal[1] != string.Empty)
                    {
                        if (arrVal[1] != _member._cardSerialNo)
                        {
                            MessageBox.Show("Invalid Card,Please use the original card ", "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    //IsSmartCard = true;
                    _memberObj = _member;
                    LoadMember(_member);
                    
                }
                else if (!bmsg._isSuccess)
                {
                    MessageBox.Show(bmsg._message, "CMS Billing Details");
                }
            }
            catch (Exception ex)
            {
                IS91.Services.Logger.LogThis(ex);
            }
        }
        public BillingMemberDetails _member = null;
        private void LoadMember(BillingMemberDetails memb)
        {
            txtAccNo.Text = memb._accountNumber;
            txtBalance.Text = string.Concat(Math.Round(memb._balAmt, 2, MidpointRounding.AwayFromZero));
            txtMemberName.Text = memb._memberName;
            _member = memb;
            //itemSrNo = memb._itemSrNo;
            //if (_member._cardPrefix.Contains("DP"))
            //{
            //    grpDep.Visible = true;
            //    txtDependantName.Text = _member._dependantName;
            //    txtRelation.Text = _member._relationship;
            //}
            //if (_bController.DataStore.LoggedInUserId == 1)
            //    dtBillDate.Enabled = true;
            //else
            //    dtBillDate.Text = DateTime.Now.ToString();
            //if (objBill == null)
            //    objBill = new Bill();
            //objBill._memberId = Convert.ToInt32(memb._memberID);

            //string caccno = "," + txtAccNo.Text + ",";
            //if (clubAccounts.Contains(caccno))
            //{
            //    blnClubAccount = true;
            //}
            //else
            //{
            //    blnClubAccount = false;
            //}
        }

        private void btnPayBill_Click(object sender, EventArgs e)
        {
            DataGridViewRow crow = grdBill.CurrentRow;
            BillController _bController = BillController._billController;
            PayBillObject obj = new PayBillObject();
            int bId = 0;
            int.TryParse(string.Concat(crow.Cells["BillID"].Value), out bId);
            obj._billId = bId;
            obj._paymentMode = cmbPaymentMode.SelectedItem.ToString();
            obj._memberId = _memberObj != null ? Convert.ToInt32(_memberObj._memberID) : 0;
            obj._bankName = txtBankName.Text;
            obj._creditCardType = ((Combo)cmbCardType.SelectedValue)==null?0:((Combo)cmbCardType.SelectedValue)._ID;
            obj._edcr = ((Combo)cmbAcquirer.SelectedValue) == null ? 0 : ((Combo)cmbAcquirer.SelectedValue)._ID;
            obj._creditCardNumber = txtCardNumber.Text;
            obj._amount = Convert.ToDouble(string.Concat(crow.Cells["BillAmount"].Value));
            obj._userId = _bController.DataStore.LoggedInUserId;


            bool status = _bController.PayBill(obj);
            if (status)
            {               
                MessageBox.Show("Bill paid successfully");
                pnlPaymentMode.Visible = false;
                pnlCardDetails.Visible = false;
                btnPayBill.Visible = false;
                btnRead.Visible = false;
                pnlMemberDetails.Visible = false;
                btnFind_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Bill payment failed");
            }
        }

        private void txtMemberID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtKOT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPOSID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
