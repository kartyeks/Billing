using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PDACommunications;
using IRCAKernel;
using System.Net;
using BillinManager.Forms;
using XCoolForm;
using XCoolFormTest;
using System.IO;
namespace BillingManager.Forms
{
    public partial class ICMSBill : XCoolForm.XCoolForm
    {
        private XmlThemeLoader xtl = new XmlThemeLoader();
        bool blnNo = false;
        string CheckCreditLimit = string.Empty;
        double MemberCrediteLimit = 0;
        public string posId = string.Empty;
        string oldquantity = string.Empty;
       // string catId = "1";
        string catId = string.Empty;
        string mode = string.Empty;
        bool EnableAccFld = false;
        bool Isclosing = false;
        string cuurentUser = "0";
        internal string loginPOSId = "0";
        internal string storedPOSId = "0";
        internal string loginStoreId = "0";
        internal string loginOT = "KOT";
        //int ID = 0;
        internal int billId = 0;
        bool IsItemValid = true;
        bool IsQtyValid = true;
        public bool IsDecAllowed = true;
        internal bool IsHappyHourRate = false;
        internal bool blnPopup = false;
        BillingMemberDetails _member = null;
        BillingMemberDetails _bmember = null;
        BillController _bController;
        bool IsFinalize = false;
        bool IsForFinalize = false;
        string stewardId = string.Empty;
        public string StoreId = string.Empty;
        int iStoreId = 0;
        DeletedItemList delItm = null;
        BillDetails objBillDet = null;
        Bill objBill = null;
        BillDetails[] arrBillDet = null;
        BillingItemTax[] arrBillTax = null;
        Dictionary<String, BillingItemTax[]> _TaxMap;
        BillingItemDetails itemDet = null;
        public int itemSrNo = 0;
        double aQuantity = 0;
        string itmCategory = "inventory";
        bool isStockCheckRequired = false;
        int orderBy = 0;
        public bool hasAddPerm = true;
        public bool hasEditPerm = true;
        public bool hasCancelPerm = false;
        public bool hasViewPerm = true;
        bool IsCashCard = false;
        string cardPrefix = "0";
        string ItemCategory = "1";
        public string OldStoreId = "";
        string computerName = string.Empty;
        bool blnDefaultPOS = false;
        bool blnDeleteRow = false;
        String clubAccounts = string.Empty;
        bool blnClubAccount = false;
        string DBConn = string.Empty;
        bool IsSmartCard = false;
        bool IsRoomCard = false;
        int KOTID = 0;
        double KOTQty = 0;
        public string POS = string.Empty;
        bool viewMode = false;
        Form _Parent = null;
        public ICMSBill(Form Parent):base()
        {   
            InitializeComponent();
            //base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            _bController = BillController._billController;
            dtBillDate.Text = DateTime.Now.ToString();
            btnReadCard.Enabled = true;
            if (_bController.DataStore.LoggedInUserId == 1)
                dtBillDate.Enabled = true;
            //EnableAccFld = (IS91.Services.Common.GetAppSetting("EnableAccFld").ToLower() == "true");
            //if (EnableAccFld)
            txtAccNo.Enabled = true;
            txtAccNo.Focus();
            //cmbPaymentMode.SelectedIndex = 0;
            cmbBillMode.SelectedIndex = 0;
            pnlMemberDetails.Visible = false;
            btnReadCard.Visible = false;
            Parent.Hide();
            _Parent = Parent;
        }
        private void frmCoolForm_Load(object sender, EventArgs e)
        {
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(150, "Date : " + DateTime.Now.ToString("dd/MM/yyyy")));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(250, "Powered by IRCA India Pvt. Ltd."));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(250, "Loged in User : " + BillController._billController.DataStore.LoggedInUser));
            this.StatusBar.EllipticalGlow = false;
            xtl.ThemeForm = this;
            this.TitleBar.TitleBarCaption = "Clover Green Billing";
            xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Themes\BlueWinterTheme.xml"));
        }
        void ICMSBill_Load(object sender, System.EventArgs e)
        {
            frmCoolForm_Load(sender, e);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            SetPermissions("BOT");
            computerName = System.Environment.MachineName;
            GetBillNumber();
            grdBilling.RowsAdded += new DataGridViewRowsAddedEventHandler(grdBilling_RowsAdded);
            AssignSerailNumber();
            btnSave.Enabled = false;
            posId = loginPOSId;
            string localComputerName = Dns.GetHostName();
            txtCounterName.Text = localComputerName;
            GetStoreID();
            object status = _bController.GetTableList(posId);
            cmbTable.ValueMember = "_tableId";
            cmbTable.DisplayMember = "_tableNo";
            cmbTable.Sorted = false;
            cmbTable.DataSource = _bController.DataStore.GetTableNo();
            if (cmbTable.Items.Count > 0)
                cmbTable.SelectedIndex = 0;
            clubAccounts = "," + IS91.Services.Common.GetAppSetting("CLUBACCOUNTS") + ",";
            string defdis = IS91.Services.Common.GetAppSetting("DisableControls");
            if (defdis == "true")
            {
                btnReadCard.Enabled = false;
                //txtBMemberId.Enabled = false;
            }
            btnReadCard.Enabled = true;
            BillingItemDetails[] itms = null;
            BillingBasicStatusMessagae autostatus = BillController._billController.GetItemList(StoreId);
            itms = BillController._billController.DataStore.GetItemDetails();
            if (itms.Length > 0)
            {
                AutoCompleteLoad(itms);
            }
        }

        void txtStewCode_Leave(object sender, System.EventArgs e)
        {
            if (txtStewCode.Text != string.Empty)
            {
                Steward[] arrStews = _bController.DataStore.GetStewards();
                    int ind = Array.FindIndex(arrStews, (x) => (x._stewardCode.ToLower() == txtStewCode.Text.ToLower()));
                if (ind == -1)
                {
                    MessageBox.Show("Invalid Bearer ID", "CMS Billing Details");
                    txtStewCode.Text = string.Empty;
                    txtBearerName.Text = "";
                    txtStewCode.Focus();
                    return;
                }
                txtBearerName.Text = arrStews[ind]._stewardName;
                stewardId = arrStews[ind]._stewardId;

            }
        }



        private void tblReadcard_Click(object sender, EventArgs e)
        {
            try
            {
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
                    
                BillingBasicStatusMessagae bmsg = _bController.GetMember(ref _member);
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
                    IsSmartCard = true;
                    LoadMember(_member);
                    if (!_member._IsCashCard)
                    {
                        cmbBillTo.DataSource = null;
                        if (posId.ToLower() != "spa")
                        {
                            lblBillTo.Visible = true;
                            _bController.GetBillTo(_member._memberID);
                            cmbBillTo.Visible = true;
                            cmbBillTo.ValueMember = "_partyId";
                            cmbBillTo.DisplayMember = "_partyName";
                            cmbBillTo.Sorted = false;
                            cmbBillTo.DataSource = _bController.DataStore.GetParty();
                        }
                    }
                    else
                    {
                        lblBillTo.Visible = false;
                        cmbBillTo.DataSource = null;
                        cmbBillTo.Visible = false;
                        btnSave.Enabled = false;
                        btnKOTSave.Enabled = true;
                        btnKOTCancelSave.Enabled = true;
                        btnFinalize.Enabled = true;
                    }
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
            string mId = arrVal[1] + "_"+ arrVal[2];
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
        //    BillingBasicStatusMessagae bmsg = _bController.GetMember(ref _member);
        //    if (bmsg._isSuccess)
        //    {
        //        LoadMember(_member);
        //    }
        //    else if (!bmsg._isSuccess)
        //    {
        //        MessageBox.Show(bmsg._message, "CMS Billing Details");
        //    }
        //}
        private void LoadMember(BillingMemberDetails memb)
        {
            txtAccNo.Text = memb._accountNumber;
            txtBalance.Text = string.Concat(Math.Round(memb._balAmt, 2, MidpointRounding.AwayFromZero));
            txtMemberName.Text = memb._memberName;
            _member = memb;
            itemSrNo = memb._itemSrNo;
            if (_member._cardPrefix.Contains("DP"))
            {
                grpDep.Visible = true;
                txtDependantName.Text = _member._dependantName;
                txtRelation.Text = _member._relationship;
            }
            if (_bController.DataStore.LoggedInUserId == 1)
                dtBillDate.Enabled = true;
            else
                dtBillDate.Text = DateTime.Now.ToString();
            if (objBill == null)
                objBill = new Bill();
            objBill._memberId = Convert.ToInt32(memb._memberID);

            string caccno = "," + txtAccNo.Text + ",";
            if (clubAccounts.Contains(caccno))
            {
                blnClubAccount = true;
            }
            else
            {
                blnClubAccount = false;
            }
        }
        private void LoadBillToMember(BillingMemberDetails memb)
        {
            //txtBMemberName.Text = memb._memberName;
            //txtBMemberBalance.Text = string.Concat(Math.Round(memb._balAmt));
            _bmember = memb;
        }
        private void txtBMemberId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void tblClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearALL();
                btnKOTSave.Enabled = true;
                btnSave.Enabled = false;
                if (posId.ToLower() != "spa")
                {
                    btnKOTSave.Enabled = false;
                    btnKOTCancelSave.Enabled = false;
                    btnFinalize.Enabled = false;
                    btnSave.Enabled = true;
                }
                else {
                    btnKOTSave.Enabled = true;
                    btnKOTCancelSave.Enabled = true;
                    btnFinalize.Enabled = true;
                }
                viewMode = false;
                cmbBillTo.Enabled = true;
            }
            catch (Exception ex)
            {
                IS91.Services.Logger.LogThis(ex);

            }
        }
        private void ClearALL()
        {
            if (hasAddPerm || hasEditPerm)
                tblFinalize.Enabled = true;
            mode = "";
            btnSave.Enabled = true;
            UnLockControls();
            cmbBillTo.Enabled = true;
            billId = 0;
            if (grdBilling.EditingControl != null)
            {
                grdBilling.EndEdit();
            }
            grdBilling.Rows.Clear();
            if (grdBilling.Columns["chk"] != null)
            {
                grdBilling.Columns.RemoveAt(16);
            }
            _member = null;
            _bmember = null;
            //txtBMemberId.Text = "";
            //txtBMemberName.Text = "";
            //txtBMemberBalance.Text = "";
            txtBalance.Text = "";
            lblBAmt.Text = "0";
            txtBillAmount.Text = "";
            txtTax.Text = "";
            txtVat.Text = "";
            txtNetAmount.Text = "";
            txtBillNo.Text = "";
            stewardId = "0";
            IsSmartCard = false;

            _bController.DataStore.ClearDeletedItemDetails();
            itemSrNo = 0;
            objBill = null;
            objBillDet = null;
            _TaxMap = null;
            tblPost.Enabled = false;
            tblFinalize.Enabled = false;
            IsForFinalize = false;
            tblBillTo.Enabled = false;

            IsCashCard = false;
            IsRoomCard = false;
            cardPrefix = "0";
            //pnlAcChange.Visible = false;
            //txtReason.Text = "";
            grpDep.Visible = false;
            txtDependantName.Text = "";
            GetBillNumber();
            if (cmbBillTo.Items.Count > 0)
                cmbBillTo.SelectedIndex = 0;
            cmbBillTo.DataSource = null;
            btnKOTCancelSave.Enabled = true;
            AssignSerailNumber();
            if (blnDefaultPOS)
            {
                txtAccNo.Focus();
                if (posId.ToLower() != "spa")
                {
                    btnKOTSave.Enabled = false;
                    btnKOTCancelSave.Enabled = false;
                    btnFinalize.Enabled = false;
                    btnSave.Enabled = true;
                }
                else
                {
                    btnKOTCancelSave.Enabled = true;
                    btnFinalize.Enabled = true;
                }
            }
        }

        private void UnLockControls()
        {
            try
            {
                if (mode == "medit") return;
                if (EnableAccFld)
                    txtAccNo.Enabled = true;
                txtStewCode.Enabled = true;
                grdBilling.Enabled = true;
                if (_bController.DataStore.LoggedInUserId == 1)
                    dtBillDate.Enabled = true;
                ClearMemberDetails();
                txtStewCode.Text = string.Empty;
                txtBearerName.Text = string.Empty;
                lblBillNoDisplay.Text = string.Empty;
                //txtReason.Text = string.Empty;
                //pnlAcChange.Visible = false;
                pnlMain.Enabled = true;
                grdBilling.Rows.Clear();
                cmbTable.Enabled = true;
            }
            catch (Exception ex)
            {
                IS91.Services.Logger.LogThis(ex);
            }
        }
        private void ClearMemberDetails()
        {
            try
            {
                txtMemberName.Text = string.Empty;
                txtBalance.Text = string.Empty;
                //txtBMemberId.Text = string.Empty;
                //txtBMemberName.Text = string.Empty;
                //txtBMemberBalance.Text = string.Empty;
                txtAccNo.Text = string.Empty;
                
                cmbTable.SelectedIndex = -1;
                if (cmbTable.Items.Count > 0)
                    cmbTable.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                IS91.Services.Logger.LogThis(ex);

            }
        }
        
        void grdBilling_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            AssignSerailNumber();

        }
        void AssignSerailNumber()
        {
            for (int k = 0; k < grdBilling.Rows.Count; k++)
            {
                grdBilling.Rows[k].Cells[0].Value = k + 1;
            }
        }
        void GetBillNumber()
        {
            BillingBasicRequest br = BillController._billController.GetBillNumber(computerName);
            if (br == null) return;
            txtBillNo.Text = br._billNumber;
            btnSave.Enabled = false;
        }
        void SetPermissions(string strType)
        {
            tblFinalize.Enabled = true;
            tblPost.Enabled = true;
            tblViewm.Enabled = true;
            tblModify.Enabled = true;
            tblBillCancel.Enabled = true;
            tblPending.Enabled = true;
            int ind = Array.FindIndex(_bController.DataStore.UserPermissions, (x) => (x._type == strType));
            if (ind != -1)
            {
                BillingPermissions bp = _bController.DataStore.UserPermissions[ind];
                hasAddPerm = bp._add;
                hasEditPerm = bp._edit;
                hasCancelPerm = bp._delete;
                hasViewPerm = bp._view;

                if (!bp._add)
                {
                    tblFinalize.Enabled = false;
                    tblPost.Enabled = false;
                    tblViewm.Enabled = false;
                }
                if (!bp._view)
                {
                    tblModify.Enabled = false;
                    tblPending.Enabled = false;
                }
                if (!bp._delete)
                {
                    tblBillCancel.Enabled = false;
                }
                if (_bController.DataStore.LoggedInUserId == 1)
                    hasCancelPerm = true;
                else
                    hasCancelPerm = false;
            }
        }        
        void grdBilling_CellEnter(object sender, DataGridViewCellEventArgs e)
        {        
            try
            {
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    if (grdBilling.CurrentCell == grdBilling.Rows[e.RowIndex].Cells[e.ColumnIndex])
                    {
                        if (!grdBilling.CurrentCell.IsInEditMode)
                        {
                            grdBilling.BeginEdit(false);
                            lblAvialableQty.Text = "";
                        }
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    if (string.Concat(grdBilling.CurrentCell.Value) != "")
                    {
                       

                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        void grdBilling_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (AutoItemName == null) return;
            if (e.ColumnIndex == 3)
            {
                if (blnPopup)
                {
                    return;
                }
                if (grdBilling.IsCurrentCellInEditMode)
                {
                    int index = AutoItemName.IndexOf(grdBilling.EditingControl.Text.ToLower());
                    if (index == -1) return;
                    //grdBilling.CurrentRow.Cells[3].Value
                    string itmcode = AutoItemCode[index];

                    //string itmcode = string.Concat(grdBilling.EditingControl.Text);
                    if (itmcode == string.Empty)
                    {
                        return;
                    }
                    if (itmcode == "?")
                    {
                        IsItemValid = false;
                        grdBilling.EditingControl.Text = "";
                        e.Cancel = true;
                        return;

                    }
                    for (int k = 0; k < grdBilling.Rows.Count; k++)
                    {
                        if (k != e.RowIndex)
                        {
                            if (string.Concat(grdBilling.Rows[k].Cells[2].Value).ToUpper() == itmcode.ToUpper())
                            {
                                MessageBox.Show("Item already exists", "CMS Billing Details");
                                IsItemValid = false;
                                grdBilling.EditingControl.Text = "";
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    string vItemCodes = IS91.Services.Common.GetAppSetting("ItemCodes");
                    if (vItemCodes != string.Empty)
                    {
                        vItemCodes = "," + vItemCodes + ",";
                        if (!vItemCodes.Contains("," + itmcode + ","))
                        {
                            MessageBox.Show("Invalid Item", "CMS Billing Details");
                            IsItemValid = false;
                            grdBilling.EditingControl.Text = "";
                            e.Cancel = true;
                            return;
                        }
                    }
                    if (StoreId != "")
                    {
                        string[] xStoreId = StoreId.Split(',');
                        foreach (String s in xStoreId)
                        {
                            itemDet = BillController._billController.GetItem(itmcode, s == "" ? 0 : Convert.ToInt32(s), dtBillDate.Value,cmbBillMode.SelectedItem.ToString());
                            if (itemDet != null) break;
                        }
                    }
                    if (itemDet == null)
                    {
                        MessageBox.Show("Invalid Item", "CMS Billing Details");
                        IsItemValid = false;
                        grdBilling.EditingControl.Text = "";
                        e.Cancel = true;
                        return;
                    }
                    if (itemDet._itemId == 0)
                    {
                        MessageBox.Show("Invalid Item", "CMS Billing Details");
                        IsItemValid = false;
                        grdBilling.EditingControl.Text = "";
                        e.Cancel = true;
                        return;
                    }
                    isStockCheckRequired = itemDet._isStockCheckRequire;
                    string iCodes = "," + IS91.Services.Common.GetAppSetting("StockNotRequired") + ",";
                    if (isStockCheckRequired && !iCodes.Contains("," + itemDet._itemCode + ","))
                    {
                        aQuantity = itemDet._availableQuantity;
                        if (aQuantity <= 0)
                        {
                            MessageBox.Show("Stock Not Available For " + itemDet._itemName, "CMS Billing Details");
                            IsItemValid = false;
                            grdBilling.EditingControl.Text = "";
                            e.Cancel = true;
                            return;
                        }
                    }
                    itmCategory = string.Concat(itemDet._itemCategory).ToLower();
                    if (itmCategory == string.Empty) itmCategory = "inventory";
                    IsDecAllowed = itemDet._sAcc != "1";

                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (blnPopup)
                {
                    return;
                }                 
                if (grdBilling.IsCurrentCellInEditMode)
                {
                    string itmcode = string.Concat(grdBilling.EditingControl.Text);
                    if (itmcode == string.Empty)
                    {
                        return;
                    }
                    if (itmcode == "?")
                    {
                        IsItemValid = false;
                        grdBilling.EditingControl.Text = "";
                        e.Cancel = true;
                        return;

                    }
                    for (int k = 0; k < grdBilling.Rows.Count; k++)
                    {
                        if (k != e.RowIndex)
                        {
                            if (string.Concat(grdBilling.Rows[k].Cells[2].Value).ToUpper() == itmcode.ToUpper())
                            {
                                MessageBox.Show("Item already exists", "CMS Billing Details");
                                IsItemValid = false;
                                grdBilling.EditingControl.Text = "";
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    string vItemCodes = IS91.Services.Common.GetAppSetting("ItemCodes");
                    if (vItemCodes != string.Empty)
                    {
                        vItemCodes = "," + vItemCodes + ",";
                        if (!vItemCodes.Contains("," + itmcode + ","))
                        {
                            MessageBox.Show("Invalid Item", "CMS Billing Details");
                            IsItemValid = false;
                            grdBilling.EditingControl.Text = "";
                            e.Cancel = true;
                            return;
                        }
                    }
                    if (StoreId != "")
                    {
                        string[] xStoreId = StoreId.Split(',');
                        foreach (String s in xStoreId)
                        {
                            itemDet = BillController._billController.GetItem(itmcode, s == "" ? 0 : Convert.ToInt32(s), dtBillDate.Value, cmbBillMode.SelectedItem.ToString());
                            if (itemDet != null) break;
                        }
                    }
                    if (itemDet == null)
                    {
                        MessageBox.Show("Invalid Item", "CMS Billing Details");
                        IsItemValid = false;
                        grdBilling.EditingControl.Text = "";
                        e.Cancel = true;
                        return;
                    }
                    if (itemDet._itemId == 0)
                    {
                        MessageBox.Show("Invalid Item", "CMS Billing Details");
                        IsItemValid = false;
                        grdBilling.EditingControl.Text = "";
                        e.Cancel = true;
                        return;
                    }
                    isStockCheckRequired = itemDet._isStockCheckRequire;
                    string iCodes = "," + IS91.Services.Common.GetAppSetting("StockNotRequired") + ",";
                    if (isStockCheckRequired && !iCodes.Contains("," + itemDet._itemCode + ","))
                    {
                        aQuantity = itemDet._availableQuantity;
                        if (aQuantity <= 0)
                        {
                            MessageBox.Show("Stock Not Available For " + itemDet._itemName, "CMS Billing Details");
                            IsItemValid = false;
                            grdBilling.EditingControl.Text = "";
                            e.Cancel = true;
                            return;
                        }
                    }
                    itmCategory = string.Concat(itemDet._itemCategory).ToLower();
                    if (itmCategory == string.Empty) itmCategory = "inventory";
                    IsDecAllowed = itemDet._sAcc != "1";

                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (grdBilling.IsCurrentCellInEditMode)
                {
                    double qty = 0;
                    double.TryParse(string.Concat(grdBilling.EditingControl.Text), out qty);
                    if (viewMode)
                    {
                        if (qty > Convert.ToDouble(oldquantity))
                        {
                            MessageBox.Show("Can not increase quantity ", "CMS Billing Details");
                            grdBilling.EditingControl.Text = oldquantity;
                            e.Cancel = true;
                        }                       
                    }
                    string iCodes = "," + IS91.Services.Common.GetAppSetting("StockNotRequired") + ",";
                    if (isStockCheckRequired && !iCodes.Contains("," + string.Concat(grdBilling.CurrentRow.Cells[2].Value) + ","))
                    {
                        if (qty > aQuantity)
                        {
                            MessageBox.Show("Quantity should not exceed Available Quantity", "CMS Billing Details");
                            IsQtyValid = false;
                            grdBilling.EditingControl.Text = "";

                            if (aQuantity == 0)
                            {
                                e.Cancel = true;
                                return;
                            }
                            e.Cancel = true;
                            return;
                        }
                    }
                    if (itmCategory == "pos")
                    {
                        double maxqty = 0;
                        string mQty = IS91.Services.Common.GetAppSetting("MaxQuantity");
                        string[] itmsQty = mQty.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        string itmCode = string.Concat(grdBilling.CurrentRow.Cells[2].Value);
                        if (itmsQty.Length > 0)
                        {
                            foreach (string str in itmsQty)
                            {
                                string[] itms = str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                if (itms.Length > 0)
                                {
                                    if (itms[0] == "0")
                                    {
                                        double.TryParse(itms[1], out maxqty);
                                    }
                                    if (itms[0] == itmCode)
                                    {
                                        double.TryParse(itms[1], out maxqty);
                                        break;
                                    }
                                }
                            }
                        }
                        if (maxqty > 0)
                        {
                            if (qty > maxqty)
                            {
                                MessageBox.Show("Quantity should not exceed Max Quantity " + string.Concat(maxqty), "CMS Billing Details");
                                IsQtyValid = false;
                                grdBilling.EditingControl.Text = "";
                                if (aQuantity == 0)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        double maxbqty = 0;
                        string mbQty = IS91.Services.Common.GetAppSetting("MaxBarQuantity");
                        string[] itmsbQty = mbQty.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        string itmbCode = string.Concat(grdBilling.CurrentRow.Cells[2].Value);
                        if (itmsbQty.Length > 0)
                        {
                            foreach (string strb in itmsbQty)
                            {
                                string[] itmsb = strb.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                if (itmsb.Length > 0)
                                {
                                    if (itmsb[0] == "0")
                                    {
                                        double.TryParse(itmsb[1], out maxbqty);
                                    }
                                    if (itmsb[0] == itmbCode)
                                    {
                                        double.TryParse(itmsb[1], out maxbqty);
                                        break;
                                    }
                                }
                            }
                        }
                        if (maxbqty > 0)
                        {
                            if (qty > maxbqty)
                            {
                                MessageBox.Show("Quantity should not exceed Max Quantity " + string.Concat(maxbqty), "CMS Billing Details");
                                IsQtyValid = false;
                                grdBilling.EditingControl.Text = "";
                                if (aQuantity == 0)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    lblAvialableQty.Text = "";

                }
            }

        }


        void grdBilling_keyDownHook(object sender, KeyEventArgs e)
        {
            if (!grdBilling.CurrentRow.IsNewRow)
            {                
                if (e.KeyCode == Keys.Delete && e.Control)
                {
                    if (!viewMode)
                    {
                        blnDeleteRow = true;
                        grdBilling.Rows.Remove(grdBilling.CurrentRow);
                        blnDeleteRow = false;
                        OnDeleteRow();
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (grdBilling.EditingControl == null) return;
                if (grdBilling.EditingControl.Text == "?")
                {
                    blnPopup = true;
                    if (!viewMode)
                    {
                        grdBilling.CurrentRow.Cells[1].Value = String.Empty;
                        ItemPopup objItm = new ItemPopup();
                        objItm.Owner = this;
                        objItm.ShowDialog();
                        if (objItm.DialogResult == DialogResult.Yes)
                        {
                            grdBilling.EndEdit();
                            grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[5];
                            grdBilling.CurrentCell.Selected = true;
                            grdBilling.BeginEdit(false);
                            e.Handled = true;
                            e.SuppressKeyPress = true;

                            int iColumn = grdBilling.CurrentCell.ColumnIndex;
                            int iRow = grdBilling.CurrentCell.RowIndex;
                            grdBilling.CurrentCell = grdBilling[2, iRow];

                        }
                    }

                    blnPopup = false;
                }
            }


        }
        void grdBilling_keyPressHook(object sender, KeyPressEventArgs e)
        {
            if (grdBilling.CurrentCell.ColumnIndex == 5)
            {
                if (Strings.Asc(e.KeyChar) == 8) return;
                if (Strings.Asc(e.KeyChar) > 47 && Strings.Asc(e.KeyChar) < 58) return;
                e.Handled = true;
            }
        }
        void grdBilling_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (AutoItemName == null) return;
            if (blnDeleteRow) return;
            lblItem.Visible = false;
            if (e.ColumnIndex == 2)
            {
                if (blnPopup) return;
                string itmcode = string.Empty;
                if (string.Concat(grdBilling.CurrentRow.Cells[2].Value) != "?")
                {
                    itmcode = string.Concat(grdBilling.CurrentRow.Cells[2].Value);
                }
                else
                {
                    int index = AutoItemName.IndexOf(string.Concat(grdBilling.CurrentRow.Cells[3].Value).ToLower());
                    itmcode = AutoItemCode[index];
                }

                if (itmcode == string.Empty && string.Concat(grdBilling.CurrentRow.Cells[8].Value) != string.Empty)
                {
                    MessageBox.Show("Item Code can not be empty ", "CMS Billing Details");
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    IsItemValid = false;
                    return;
                }
                if (itmcode == string.Empty) return;
                string[] xStoreId = StoreId.Split(',');
                foreach (String s in xStoreId)
                {
                    itemDet = BillController._billController.GetItem(itmcode, s == "" ? 0 : Convert.ToInt32(s), dtBillDate.Value, cmbBillMode.SelectedItem.ToString());
                    if (itemDet != null) break;
                }
                if (itemDet == null)
                {
                    MessageBox.Show("Invalid Item", "CMS Billing Details");
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    IsItemValid = false;
                    return;

                }
                if (itemDet._itemId == 0)
                {
                    MessageBox.Show("Invalid Item", "CMS Billing Details");
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    IsItemValid = false;
                    return;

                }

                string vItemCodes = IS91.Services.Common.GetAppSetting("ItemCodes");
                if (vItemCodes != string.Empty)
                {
                    vItemCodes = "," + vItemCodes + ",";
                    if (!vItemCodes.Contains("," + itemDet._itemCode + ","))
                    {
                        MessageBox.Show("Invalid Item", "CMS Billing Details");
                        grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                        grdBilling.CurrentCell.Selected = true;
                        IsItemValid = false;
                        return;
                    }
                }
                grdBilling.EndEdit();

                if (objBillDet == null)
                    objBillDet = new BillDetails();
                grdBilling.CurrentRow.Cells[1].Value = String.Empty;
                grdBilling.CurrentRow.Cells[2].Value = itemDet._itemCode;
                grdBilling.CurrentRow.Cells[3].Value = itemDet._itemName;
                grdBilling.CurrentRow.Cells[4].Value = itemDet._baseUnit;
                
                if (IsHappyHourRate)
                    grdBilling.CurrentRow.Cells[6].Value = itemDet._happyhrRate;
                else
                    grdBilling.CurrentRow.Cells[6].Value = itemDet._rate;
                grdBilling.CurrentRow.Cells[8].Value = itemDet._itemId;
                grdBilling.CurrentRow.Cells[9].Value = itemDet._happyhrRate;
                grdBilling.CurrentRow.Cells[10].Value = itemDet._baseUnitId;
              
                grdBilling.CurrentRow.Cells[11].Value = 0;
                grdBilling.CurrentRow.Cells[12].Value = 0;
                if (string.Concat(grdBilling.CurrentRow.Cells[13].Value) == "" || string.Concat(grdBilling.CurrentRow.Cells[13].Value) == "0")
                {
                    grdBilling.CurrentRow.Cells[13].Value = itemSrNo + 1;
                    itemSrNo = itemSrNo + 1;
                }
                itmCategory = itemDet._itemCategory.ToLower();
                grdBilling.CurrentRow.Cells[14].Value = itmCategory;
                aQuantity = itemDet._availableQuantity;
                isStockCheckRequired = itemDet._isStockCheckRequire;
                grdBilling.CurrentRow.Cells[17].Value = itemDet._storeId;
                IsDecAllowed = itemDet._sAcc != "1";
                string iCodes = "," + IS91.Services.Common.GetAppSetting("StockNotRequired") + ",";
                if (isStockCheckRequired && !iCodes.Contains("," + itemDet._itemCode + ","))
                {
                    lblAvialableQty.Text = itemDet._itemName + " Quantity Available :" + string.Concat(aQuantity);
                }
                try
                {
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[5];
                    grdBilling.CurrentCell.Selected = true;
                    grdBilling.BeginEdit(false);
                }
                catch (Exception ex)
                {
                    IS91.Services.Logger.LogThis(ex);
                }
            }
            else if (e.ColumnIndex == 3)
            {
                int index = 0;
                if (string.Concat(grdBilling.CurrentRow.Cells[3].Value) == "?")
                {
                    index = AutoItemCode.IndexOf(string.Concat(grdBilling.CurrentRow.Cells[2].Value).ToLower());
                }
                else
                {
                    index = AutoItemName.IndexOf(string.Concat(grdBilling.CurrentRow.Cells[3].Value).ToLower());
                }
                if (index == -1) {
                    //MessageBox.Show("Please enter correct item name", "CMS Billing Details");
                    //grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    grdBilling.CurrentRow.Cells[3].Value = "";
                    IsItemValid = false;
                    return;
                }
                //grdBilling.CurrentRow.Cells[3].Value
                string itmcode = AutoItemCode[index];

                if (itmcode == string.Empty && string.Concat(grdBilling.CurrentRow.Cells[8].Value) != string.Empty)
                {
                    MessageBox.Show("Item Code can not be empty ", "CMS Billing Details");
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    IsItemValid = false;
                    return;
                }
                if (itmcode == string.Empty) return;
                string[] xStoreId = StoreId.Split(',');
                foreach (String s in xStoreId)
                {
                    itemDet = BillController._billController.GetItem(itmcode, s == "" ? 0 : Convert.ToInt32(s), dtBillDate.Value, cmbBillMode.SelectedItem.ToString());
                    if (itemDet != null) break;
                }
                if (itemDet == null)
                {
                    MessageBox.Show("Invalid Item", "CMS Billing Details");
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    IsItemValid = false;
                    return;

                }
                if (itemDet._itemId == 0)
                {
                    MessageBox.Show("Invalid Item", "CMS Billing Details");
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    IsItemValid = false;
                    return;

                }

                string vItemCodes = IS91.Services.Common.GetAppSetting("ItemCodes");
                if (vItemCodes != string.Empty)
                {
                    vItemCodes = "," + vItemCodes + ",";
                    if (!vItemCodes.Contains("," + itemDet._itemCode + ","))
                    {
                        MessageBox.Show("Invalid Item", "CMS Billing Details");
                        grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                        grdBilling.CurrentCell.Selected = true;
                        IsItemValid = false;
                        return;
                    }
                }
                grdBilling.EndEdit();

                if (objBillDet == null)
                    objBillDet = new BillDetails();
                grdBilling.CurrentRow.Cells[1].Value = String.Empty;
                grdBilling.CurrentRow.Cells[2].Value = itemDet._itemCode;
                grdBilling.CurrentRow.Cells[3].Value = itemDet._itemName;
                grdBilling.CurrentRow.Cells[4].Value = itemDet._baseUnit;

                if (IsHappyHourRate)
                    grdBilling.CurrentRow.Cells[6].Value = itemDet._happyhrRate;
                else
                    grdBilling.CurrentRow.Cells[6].Value = itemDet._rate;
                grdBilling.CurrentRow.Cells[8].Value = itemDet._itemId;
                grdBilling.CurrentRow.Cells[9].Value = itemDet._happyhrRate;
                grdBilling.CurrentRow.Cells[10].Value = itemDet._baseUnitId;

                grdBilling.CurrentRow.Cells[11].Value = 0;
                grdBilling.CurrentRow.Cells[12].Value = 0;
                if (string.Concat(grdBilling.CurrentRow.Cells[13].Value) == "" || string.Concat(grdBilling.CurrentRow.Cells[13].Value) == "0")
                {
                    grdBilling.CurrentRow.Cells[13].Value = itemSrNo + 1;
                    itemSrNo = itemSrNo + 1;
                }
                itmCategory = itemDet._itemCategory.ToLower();
                grdBilling.CurrentRow.Cells[14].Value = itmCategory;
                aQuantity = itemDet._availableQuantity;
                isStockCheckRequired = itemDet._isStockCheckRequire;
                grdBilling.CurrentRow.Cells[17].Value = itemDet._storeId;
                IsDecAllowed = itemDet._sAcc != "1";
                string iCodes = "," + IS91.Services.Common.GetAppSetting("StockNotRequired") + ",";
                if (isStockCheckRequired && !iCodes.Contains("," + itemDet._itemCode + ","))
                {
                    lblAvialableQty.Text = itemDet._itemName + " Quantity Available :" + string.Concat(aQuantity);
                }
                try
                {
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[5];
                    grdBilling.CurrentCell.Selected = true;
                    grdBilling.BeginEdit(false);
                }
                catch (Exception ex)
                {
                    IS91.Services.Logger.LogThis(ex);
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (string.Concat(grdBilling.CurrentRow.Cells[2].Value) == "")
                {
                    grdBilling.EndEdit();
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;
                    grdBilling.BeginEdit(false);
                    return;
                }
                if (viewMode)
                {
                   if (oldquantity != string.Concat(grdBilling.CurrentRow.Cells[5].Value))
                    {
                        btnSave.Enabled = false;

                    }

                }
                double rate = 0; double qty = 0; int kid = 0; int stoID = 0;
                double.TryParse(string.Concat(grdBilling.CurrentRow.Cells[6].Value), out rate);
                double.TryParse(string.Concat(grdBilling.CurrentRow.Cells[5].Value), out qty);
                int.TryParse(string.Concat(grdBilling.CurrentRow.Cells[16].Value), out kid);
                int.TryParse(string.Concat(grdBilling.CurrentRow.Cells[17].Value), out stoID);
                string iCodes = "," + IS91.Services.Common.GetAppSetting("StockNotRequired") + ",";
                if (isStockCheckRequired && !iCodes.Contains("," + string.Concat(grdBilling.CurrentRow.Cells[2].Value) + ","))
                {
                    if (qty > aQuantity)
                    {
                        MessageBox.Show("Quantity should not exceed Available Quantity", "CMS Billing Details");
                        if (aQuantity == 0)
                        {
                            ClearGridRow(grdBilling.CurrentRow.Index);
                            grdBilling.EndEdit();
                            grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                            grdBilling.CurrentCell.Selected = true;
                            grdBilling.BeginEdit(false);
                            IsQtyValid = false;
                            return;
                        }
                        grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[5];
                        grdBilling.CurrentCell.Selected = true;
                        IsQtyValid = false;
                        return;
                    }
                }

                double bamt = rate * qty;
                grdBilling.CurrentRow.Cells[7].Value = bamt;               
                CalculateBillAmount();
                KOTID = kid;
                KOTQty = qty;
                if (oldquantity != "")
                {
                    if (btnKOTSave.Enabled == false && qty != Convert.ToDouble(oldquantity))
                    {
                        GetCancelItem();
                    }
                }
                itemDet = null;
                if (hasAddPerm || hasEditPerm)
                    tblFinalize.Enabled = true;
                if (mode == "" && IsForFinalize == false)
                {
                    if (hasAddPerm || hasEditPerm)
                        tblPost.Enabled = true;
                }
            }            
        }
        void ClearGridRow(int rowId)
        {
            DataGridViewRow grw = grdBilling.Rows[rowId];
            if (grw != null)
            {
                grw.Cells[0].Value = "";
                grw.Cells[1].Value = "";
                grw.Cells[2].Value = "";
                grw.Cells[3].Value = "";
                grw.Cells[4].Value = "";
                grw.Cells[5].Value = "";
                grw.Cells[6].Value = "";
                grw.Cells[7].Value = "";
                grw.Cells[8].Value = "";
                grw.Cells[9].Value = "";
                grw.Cells[10].Value = 0;
                grw.Cells[11].Value = 0;
                grw.Cells[12].Value = 0;
                grw.Cells[13].Value = 0;
                grw.Cells[16].Value = 0;
                grw.Cells[17].Value = 0;
            }
        }

        void CalculateBillAmount()
        {
            if (_TaxMap == null) 
                _TaxMap = new Dictionary<string, BillingItemTax[]>();
            BillingItemDetails[] arrItms = null;
            double bamt = 0; double tax = 0; double tottax = 0; double totamt = 0; double totvat = 0; double vat = 0;
            BillingItemTax btx = null;
            BillingItemTax[] totITax = null; 
            foreach (DataGridViewRow dr in grdBilling.Rows)
            {
                int itmId = 0;
                int.TryParse(string.Concat(string.Concat(dr.Cells[8].Value)), out itmId);
                if (itmId == 0) continue;

                BillController._billController.DataStore.ClearItemList();
                BillingBasicStatusMessagae status = BillController._billController.GetItemListCat(StoreId, itmId);
                arrItms = BillController._billController.DataStore.GetItemDetails(StoreId, itmId);

                int ind = Array.FindIndex(arrItms, (x) => (x._itemId == itmId));
                if (ind == -1) continue;
                BillingItemDetails bitm = arrItms[ind];
                tax = 0; bamt = 0; vat = 0;
                double.TryParse(string.Concat(dr.Cells[7].Value), out bamt);
                if (bitm != null)
                {
                    int n = 0; double rtx = 0;
                    totITax = new BillingItemTax[bitm._itmTax.Length];
                    foreach (ItemTax itx in bitm._itmTax)
                    {
                        if (itx._taxType == "P")
                        {
                            rtx = ((itx._tax * bamt) / 100);
                            if (itx._taxFlag == "T")
                            {
                                tax = tax + ((itx._tax * bamt) / 100);
                            }
                            else if (itx._taxFlag == "V")
                            {
                                vat = vat + ((itx._tax * bamt) / 100);
                            }

                        }
                        else
                        {
                            rtx = itx._tax;
                            tax = tax + itx._tax;
                        }
                        btx = new BillingItemTax();
                        btx._itemId = itx._itemId;
                        btx._taxId = itx._taxId;
                        btx._amount = Math.Round(rtx, 2);
                        btx._tax = itx._tax;
                        btx._taxType = itx._taxType;
                        totITax[n] = btx;
                        n++;
                    }
                    if (string.Concat(dr.Cells[16].Value) != "" && string.Concat(dr.Cells[16].Value) != "0")
                    {
                        if (btx != null)
                        {
                            if (_TaxMap.ContainsKey(dr.Cells[16].Value + "_" + btx._itemId))
                            {
                                _TaxMap.Remove(dr.Cells[16].Value + "_" + btx._itemId);
                            }
                            _TaxMap.Add(string.Concat(dr.Cells[16].Value + "_" + btx._itemId), totITax);
                        }

                    }
                    else
                    {

                        if (_TaxMap.ContainsKey(string.Concat(dr.Cells[13].Value)))
                        {
                            _TaxMap.Remove(string.Concat(dr.Cells[13].Value));
                        }
                        _TaxMap.Add(string.Concat(dr.Cells[13].Value), totITax);
                    }
                }
                tottax = tottax + tax;
                totvat = totvat + vat;
                totamt += bamt;
            }
            txtBillAmount.Text = string.Concat(Math.Round(totamt, 2));
            txtTax.Text = string.Concat(Math.Round(tottax, 2));
            txtVat.Text = string.Concat(Math.Round(totvat, 2));
            txtNetAmount.Text = string.Concat(Math.Round(totamt + tottax + totvat, 2));
        }
        void grdBilling_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (string.Concat(grdBilling.CurrentRow.Cells[2].Value) == "" || !IsItemValid)
                {
                    if (string.Concat(grdBilling.CurrentRow.Cells[2].Value) == "")
                    {
                        IsItemValid = true;
                        e.Cancel = true;
                        return;
                    }
                    grdBilling.CurrentCell = grdBilling.CurrentRow.Cells[2];
                    grdBilling.CurrentCell.Selected = true;

                    IsItemValid = true;
                    e.Cancel = true;
                    return;
                }
                if (string.Concat(grdBilling.CurrentCell.Value) == "")
                    grdBilling.CurrentCell.Value = "1";

                if (viewMode)
                    oldquantity = string.Concat(grdBilling.CurrentRow.Cells[5].Value);
            }
            else if (e.ColumnIndex == 2)
            {                
                lblItem.Visible = true;
            }
        }

        void grdBilling_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl editControl = (DataGridViewTextBoxEditingControl)grdBilling.EditingControl;
            if (editControl != null)
            {
                editControl.SelectionStart = 0;
                editControl.SelectionLength = editControl.Text.Length;
            }
            //Added by yogesh 
            int column = grdBilling.CurrentCell.ColumnIndex;
            string headerText = grdBilling.Columns[column].HeaderText;
            TextBox tb = e.Control as TextBox;
            tb.AutoCompleteCustomSource = null;
            if (column == 3)
            {
                //if (headerText.Equals("Item Name"))
                //{
                    tb = e.Control as TextBox;

                    if (tb != null)
                    {
                        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        tb.AutoCompleteCustomSource = AutoItemName;
                        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                //}
            }
            //if (headerText.Equals("Item Code"))
            //{
            //    TextBox tb = e.Control as TextBox;

            //    if (tb != null)
            //    {
            //        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        tb.AutoCompleteCustomSource = AutoItemCode;
            //        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    }
            //}
        }
        AutoCompleteStringCollection AutoItemName;
        AutoCompleteStringCollection AutoItemCode;
        public void AutoCompleteLoad(BillingItemDetails[] itms)
        {
            AutoItemName = new AutoCompleteStringCollection();
            AutoItemCode = new AutoCompleteStringCollection();
            foreach (BillingItemDetails itm in itms)
            {
                AutoItemName.Add(itm._itemName.ToLower());
                AutoItemCode.Add(itm._itemCode);
            }
            //return AutoItmsstr;
        }
        private void tblPost_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Save Billing Details?", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (!ValidateData()) return;

            BillDetailList blist = _bController.SaveBilling(GetBillList());
            if (blist._billList.Length != 0)
            {
                ClearALL();
                return;
            }
            else if (blist._action == BillActionType.NOCRLIMIT)
            {
                MessageBox.Show("Member exceeded Credit Limit", "CMS Billing Details");
                return;
            }
            else
            {
                MessageBox.Show("Error occured while Saving....", "CMS Billing Details");
                return;
            }
            txtAccNo.Focus();
        }
        private void tblPostVisitor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Save Billing Details?", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (!ValidateData()) return;

            BillDetailList blist = _bController.SaveVisitorBilling(GetBillList());
            if (blist._billList.Length != 0)
            {
                ClearALL();
                return;
            }
            cmbTable.Focus();
        }
        private BillDetailList GetBillList()
        {
            BillDetails objBillDet = null;
            Bill objBill = new Bill();
            if (IsFinalize)
            {
                
                if (cmbBillMode.SelectedIndex >= 1)
                {
                    if (_bmember == null) _bmember = _member;
                    objBill._memberId = Convert.ToInt32(_bmember._memberID);
                    objBill._contractorsId = _member._dependantID;
                }
                else
                {
                    objBill._memberId = 0;
                    objBill._contractorsId = "0";
                }
                objBill._isFinalized = true;
            }
            else
            {
                if (cmbBillMode.SelectedIndex >= 1)
                {
                    objBill._memberId = Convert.ToInt32(_member._memberID);
                    objBill._contractorsId = _member._dependantID;
                }
                else
                {
                    objBill._memberId = 0;
                    objBill._contractorsId = "0";
                }
            }

            
            objBill._billId = billId;
            objBill._billNumber = txtBillNo.Text;
            objBill._otNo = String.Empty;
            objBill._billCalncelDate = new DateTime(1900, 1, 1);
            objBill._billDate = dtBillDate.Value;
            if (IsCashCard)
                objBill._billMode = "C";
            else if (IsRoomCard)
                objBill._billMode = "E";
            else
                objBill._billMode = "R";
            if (cmbBillTo.DataSource == null || ((Party)cmbBillTo.SelectedItem)._partyId == "0")
            {
                objBill._billType = "RR";
            }
            else
            {
                objBill._billType = "PR";
                objBill._referenceNumber = ((Party)cmbBillTo.SelectedItem)._partyId.ToString();// +"-" + ((Party)cmbBillTo.SelectedItem)._partyName;

            }
            if (stewardId == "") stewardId = "0";
            objBill._stewardId = Convert.ToInt32(stewardId);
            objBill._storeId = 0;
            double namt = 0;
            double.TryParse(txtNetAmount.Text, out namt);
            objBill._amount = namt;
            if (cmbTable.SelectedIndex > -1)
                objBill._tableId = ((TableNumber)cmbTable.SelectedValue)._tableId;
            else
                objBill._tableId = "0";
            objBill._createdBy = _bController.DataStore.LoggedInUserId;
            objBill._createdDate = DateTime.Now;
            objBill._modifiedBy = _bController.DataStore.LoggedInUserId;
            objBill._modifiedDate = DateTime.Now;
            objBill._userId = _bController.DataStore.LoggedInUserId;
            objBill._userName = _bController.DataStore.LoggedInUser;
            double tamt = 0;
            double.TryParse(txtNetAmount.Text, out tamt);
            objBill._amount = tamt;
            if (IsSmartCard)
                objBill._orderby = 1;
            else
                objBill._orderby = 0;

            double irate = 0;
            double qty = 0;
            double amt = 0;
            int k = 0; double stax = 0; double ctax = 0; double srtax = 0; double srtax1 = 0; double srtax2 = 0;
            double totamt = 0;
            double tottax = 0; int srno = 0; int kid = 0;
            BillController._billController.DataStore.ClearBillDetails();

            foreach (DataGridViewRow gr in grdBilling.Rows)
            {
                qty = 0;
                double.TryParse(string.Concat(gr.Cells[5].Value), out qty);
                if (string.Concat(gr.Cells[8].Value) != String.Empty && qty != 0.0)
                {
                    objBillDet = new BillDetails();
                    int itmId = 0;
                    int.TryParse(string.Concat(gr.Cells[8].Value), out itmId);
                    objBillDet._itemId = itmId;
                    int.TryParse(string.Concat(gr.Cells[16].Value), out kid);
                    objBillDet._ID = kid;
                    objBillDet._otNo = string.Concat(gr.Cells[1].Value);
                    irate = 0;
                    double.TryParse(string.Concat(gr.Cells[6].Value), out irate);
                    objBillDet._rate = irate;
                    if (IsHappyHourRate)
                        objBillDet._isHappyhr = true;
                    else
                        objBillDet._isHappyhr = false;
                    //qty = 0;
                    double.TryParse(string.Concat(gr.Cells[5].Value), out qty);
                    objBillDet._quantity = qty;
                    int IStoID = 0;
                    objBillDet._ItemStoreID = Convert.ToInt32(gr.Cells[17].Value);
                    amt = qty * irate;
                    objBillDet._amount = amt;
                    objBillDet._baseUnitId = string.Concat(gr.Cells[10].Value);
                    srno = 0;
                    int.TryParse(string.Concat(gr.Cells[0].Value), out srno);
                    objBillDet._itemSerialNo = srno;
                    k++;
                    totamt = totamt + amt;
                    tottax = tottax + stax + ctax + srtax + srtax1 + srtax2;
                    if (_TaxMap != null)
                    {
                        if (string.Concat(gr.Cells[16].Value) != "" && string.Concat(gr.Cells[16].Value) != "0")
                        {
                            if (_TaxMap.ContainsKey(kid + "_" + itmId))
                                objBillDet._bTax = _TaxMap[kid + "_" + itmId];
                        }
                        else
                        {
                            if (_TaxMap.ContainsKey(string.Concat(gr.Cells[13].Value)))
                                objBillDet._bTax = _TaxMap[string.Concat(gr.Cells[13].Value)];
                        }
                    }
                    _bController.DataStore.AddDetails(objBillDet);
                }
            }
            BillDetailList blist = new BillDetailList();
            blist._computerName = computerName;
            blist._bill = objBill;
            blist._billList = _bController.DataStore.GetBillDetails();
            blist._delItems = _bController.DataStore.GetDeletedItemDetails();
            if (cmbBillMode.SelectedIndex == 1)
            {
                if (_member._cardPrefix == "") _member._cardPrefix = "0";
            }
            blist._memb = _member;
            return blist;
        }
        void txtStewCode_KeyDown(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtStewCode.Text != string.Empty)
                {
                    Steward[] arrStews = _bController.DataStore.GetStewards();
                    int ind = Array.FindIndex(arrStews, (x) => (x._stewardCode.ToLower() == txtStewCode.Text.ToLower()));
                    if (ind == -1)
                    {
                        MessageBox.Show("Invalid Bearer ID", "CMS Billing Details");
                        txtStewCode.Text = string.Empty;
                        txtBearerName.Text = "";
                        txtStewCode.Focus();
                        return;
                    }
                    txtBearerName.Text = arrStews[ind]._stewardName;
                    stewardId = arrStews[ind]._stewardId;
                }
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        void txtAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            cardPrefix = "0";
            grpDep.Visible = false;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAccNo.Text == "?")
                {
                    MemberSearch fMem = new MemberSearch();
                    fMem.Owner = this;
                    fMem.ShowDialog();
                    return;
                }
                if (txtAccNo.Text == "") return;
                //System.Windows.Forms.SendKeys.Send("{TAB}");
                //System.Windows.Forms.SendKeys.Send("{TAB}");
                txtStewCode.Focus();
             }
        }
        void cmbTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
         
        void txtAccNo_Leave(object sender, System.EventArgs e)
        {
            if (txtAccNo.Text == "") return;
            BillingMemberDetails objMemb = new BillingMemberDetails();
            objMemb._accountNumber = txtAccNo.Text;
            objMemb._memberID = txtAccNo.Text;
            objMemb._curDateTime = DateTime.Now;
            objMemb._storeId = StoreId;
            objMemb._userId = _bController.DataStore.LoggedInUserId;
            objMemb._clubName = computerName;
            if (cardPrefix == "") cardPrefix = "0";
            objMemb._cardPrefix = cardPrefix;
                if (objMemb._cardPrefix != "0") return;
            objMemb._IsSmartCard = false;
            BillingBasicStatusMessagae bmsg = _bController.GetMember(ref objMemb);
            if (bmsg._isSuccess)
            {

                if (objMemb._memberID == "0")
                {
                    MessageBox.Show("Invalid Member", "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccNo.Text = "";
                    txtMemberName.Text = "";
                    txtBalance.Text = "";
                    txtAccNo.Focus();
                    return;
                }
                else if (objMemb._memberID == "-2")
                {
                    txtAccNo.Text = objMemb._accountNumber;
                    txtBalance.Text = string.Concat(Math.Round(objMemb._balAmt, 2, MidpointRounding.AwayFromZero));
                    txtMemberName.Text = objMemb._memberName;
                    MessageBox.Show(objMemb._reason, "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccNo.Text = "";
                    txtMemberName.Text = "";
                    txtBalance.Text = "";
                    txtAccNo.Focus();
                    return;
                }
                else if (objMemb._memberID == "-1")
                {
                    txtAccNo.Text = objMemb._accountNumber;
                    txtBalance.Text = string.Concat(Math.Round(objMemb._balAmt, 2, MidpointRounding.AwayFromZero));
                    txtMemberName.Text = objMemb._memberName;
                    MessageBox.Show("Member exceeds Credit Limit, cannot proceed \r\n Balance is " + string.Concat(objMemb._balAmt), "CMS Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccNo.Text = "";
                    txtMemberName.Text = "";
                    txtBalance.Text = "";
                    txtAccNo.Focus();
                    return;
                }
                else if (objMemb._clubID == "-3")
                {
                    if (MessageBox.Show("Member exceeds Credit Limit, cannot proceed \r\n Balance is : " + string.Concat(objMemb._balAmt) + "\n\r Do you want to proceed?", "CMS Billing Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                LoadMember(objMemb);
                MemberCrediteLimit = Math.Round(objMemb._balAmt, 2, MidpointRounding.AwayFromZero);
                txtStewCode.Focus();
                if (!objMemb._IsCashCard)
                {
                    cmbBillTo.DataSource = null;
                    if(posId.ToLower()!="spa")
                    {
                        lblBillTo.Visible = true;
                        _bController.GetBillTo(objMemb._memberID);
                        cmbBillTo.Visible = true;
                        cmbBillTo.ValueMember = "_partyId";
                        cmbBillTo.DisplayMember = "_partyName";
                        cmbBillTo.Sorted = false;
                        cmbBillTo.DataSource = _bController.DataStore.GetParty();
                    }
               }
                else
                {
                    lblBillTo.Visible = false;
                    cmbBillTo.DataSource = null;
                    cmbBillTo.Visible = false;
                }
                if (posId.ToLower() == "spa")
                {
                    btnKOTSave.Enabled = false;
                    btnKOTCancelSave.Enabled = false;
                    btnFinalize.Enabled = false;
                    btnSave.Enabled = true;
                }
                else
                {
                    btnKOTCancelSave.Enabled = true;
                    btnFinalize.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            else if (!bmsg._isSuccess)
            {
                MessageBox.Show(bmsg._message, "CMS Billing Details");
                txtAccNo.Text = "";
                txtAccNo.Focus();
            }
        }
        void tblBillTo_Click(object sender, System.EventArgs e)
        {
            try
            {
                string memId = GetCardDetails();
                if (memId == string.Empty) return;
                BillingMemberDetails _member = new BillingMemberDetails();
                _member._memberID = memId;
                _member._cardPrefix = cardPrefix;
                _member._curDateTime = DateTime.Now;
                _member._storeId = StoreId;
                _member._IsSmartCard = true;
                BillingBasicStatusMessagae bmsg = _bController.GetMember(ref _member);
                if (bmsg._isSuccess)
                {
                    LoadBillToMember(_member);
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

        private void tblViewm_Click(object sender, EventArgs e)
        {
            if (cmbBillMode.SelectedIndex != 0)
            {
                if (_member == null)
                {
                    MessageBox.Show("Select Member", "CMS Billing Details");
                    txtAccNo.Focus();
                    return;
                }
            }

            BillDetailList billList = new BillDetailList();

            billList._bill = new Bill();
            billList._bill._memberId = _member==null?0:Convert.ToInt32(_member._memberID);
            billList._bill._billCalncelDate = new DateTime(1900, 1, 1);
            billList._bill._billDate = new DateTime(1900, 1, 1);
            billList._bill._createdDate = new DateTime(1900, 1, 1);
            billList._bill._modifiedDate = new DateTime(1900, 1, 1);

            if (cmbBillMode.SelectedIndex != 0)
            {
                billList._memb = _member;
                if (_member._curDateTime.Year < 1900)
                    billList._memb._curDateTime = DateTime.Now;
                else
                    billList._memb._curDateTime = _member._curDateTime;
            }
            else
            {
                billList._bill._tableId = ((TableNumber)cmbTable.SelectedValue)._tableId;
            }
            if (cmbBillTo.DataSource == null || ((Party)cmbBillTo.SelectedItem)._partyId == "0")
            {
                billList._bill._billType = "RR";
            }
            else
            {
                billList._bill._billType = "PR";
                billList._bill._referenceNumber = ((Party)cmbBillTo.SelectedItem)._partyId.ToString();// +"-" + ((Party)cmbBillTo.SelectedItem)._partyName;
            }
            billList._action = BillActionType.View;

            BillDetailList blist = _bController.GetBilling(billList);
            if (blist._action == BillActionType.Success)
            {
                IsForFinalize = true;
                IsFinalize = true;
                LoadBill(blist);
                GetBillNumber();
                tblBillTo.Enabled = true;
                tblPost.Enabled = false;
                btnKOTSave.Enabled = false;
                viewMode = true;
                btnSave.Enabled = true;
                cmbBillTo.Enabled = false;
            }
            else if (blist._action == BillActionType.Failure)
            {
                ClearALL();
                MessageBox.Show("Data is not Available", "CMS Billing Details");
            }

        }

        private void cmbBillTo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (posId.ToLower() != "spa")
            {
                btnSave.Enabled = false;
                btnKOTSave.Enabled = true;
                btnKOTCancelSave.Enabled = true;
                btnFinalize.Enabled = true;
            }
            else
            {
                btnSave.Enabled = true;
                btnKOTSave.Enabled = false;
                btnKOTCancelSave.Enabled = false;
                btnFinalize.Enabled = false;
            }
            //cmbBillTo.Focus();      
        }
        void cmbBillTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStewCode.Focus();
            }
        }
        private void LoadBill(BillDetailList blist)
        {

            Bill obill = blist._bill;
            BillDetails[] bdetails = blist._billList;
            if (obill != null)
            {
                txtStewCode.Text = obill._stewardCode;
                txtBearerName.Text = obill._stewardName;
                stewardId = string.Concat(obill._stewardId);
                txtBillNo.Text = obill._billNumber;
                billId = obill._billId;
                TableNumber[] tbls = _bController.DataStore.GetTableNo();
                int ind = Array.FindIndex(tbls, (x) => (x._tableId == obill._tableId));
                cmbTable.ValueMember = "_tableId";
                cmbTable.DisplayMember = "_tableNo";
                cmbTable.Sorted = false;
                cmbTable.DataSource = tbls;
                cmbTable.SelectedIndex = ind;
            }
            BillingMemberDetails memb = blist._memb;
            if(memb != null){
                if (memb._memberName == "Walkin")
                {
                    pnlMemberDetails.Visible = false;
                    cmbBillMode.SelectedIndex = 0;
                    cmbTable.SelectedItem = memb._accountNumber;
                }
                else
                {                
                    pnlMemberDetails.Visible = true;
                    cmbBillMode.SelectedIndex = 1;
                }
            }
            if (memb != null && memb._memberName != "Walkin")
            {
                txtAccNo.Text = memb._accountNumber;
                LoadMember(memb);
            }
            grdBilling.Rows.Clear();
            grdBilling.EndEdit();
            if (bdetails.Length > 0)
            {
                grdBilling.Rows.Add(bdetails.Length);
                int k = 0; int m = 0;
                _TaxMap = new Dictionary<string, BillingItemTax[]>();
                foreach (BillDetails bl in bdetails)
                {
                    DataGridViewRow dr = grdBilling.Rows[k];
                    dr.Selected = true;
                    if (posId.ToLower() != "spa")
                    {
                        dr.Cells[1].Value = bl._otNo.Substring(4);
                    }
                    dr.Cells[2].Value = bl._itemCode;
                    grdBilling.Rows[k].Cells[2].ReadOnly = true;
                    dr.Cells[3].Value = bl._itemName;
                    dr.Cells[4].Value = bl._baseUnit;
                    dr.Cells[6].Value = bl._rate;
                    dr.Cells[5].Value = bl._quantity;
                    dr.Cells[7].Value = bl._amount;
                    dr.Cells[8].Value = bl._itemId;
                    dr.Cells[9].Value = bl._rate;
                    dr.Cells[10].Value = bl._baseUnitId;
                    dr.Cells[11].Value = 0;
                    dr.Cells[12].Value = "0";
                    dr.Cells[13].Value = bl._itemSerialNo;
                    dr.Cells[16].Value = bl._ID;
                    dr.Cells[17].Value = bl._ItemStoreID;
                    m = 0; double itmtx = 0;
                    foreach (BillingItemTax tx in bl._bTax)
                    {
                        itmtx = itmtx + (tx._amount) ;
                    }
                    dr.Cells[15].Value = itmtx;
                    if (_TaxMap.ContainsKey(string.Concat(bl._ID + "_" + bl._itemId)))
                        _TaxMap.Remove(string.Concat(bl._ID + "_" + bl._itemId));
                    _TaxMap.Add(string.Concat(bl._ID + "_" + bl._itemId), bl._bTax);

                    k++;
                }
            }
            CalculateBillAmount();
            if (hasAddPerm || hasEditPerm)
                tblFinalize.Enabled = true;
            if (mode == "" && IsForFinalize == false)
            {
                if (hasAddPerm || hasEditPerm)
                    tblPost.Enabled = true;
            }
        }
        private void tblFinalize_Click(object sender, EventArgs e)
        {            
            if (!ValidateData())
            {
                IsFinalize = false;
                return;
            }
            //if (!ValidateCardData())
            //{
            //    IsFinalize = false;
            //    return;
            //}
            if (MessageBox.Show("Do you want Post? ", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                blnNo = true;
                return;
            }
            BillDetailList blist = _bController.PostBilling(GetBillList());
            if (blist == null)
            {
                IsFinalize = false;
                return;
            }
            IsFinalize = false;
            if (blist._action == BillActionType.Success)
            {
                viewMode = false;
                cmbBillTo.Enabled = true;
                SmartCardReaderNew objSmart = new SmartCardReaderNew();
                if (blist._TxtPrintSnehaBar!= null)
                {
                    string prnname = IS91.Services.Common.GetAppSetting("PrinterName");
                    do
                    {
                        for (int i = 0; i < blist._TxtPrintSnehaBar.Length; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                objSmart.CustomPrintDocument(blist._TxtPrintSnehaBar[i].ToString(), prnname);
                            }  
                        }                     
                    } while (MessageBox.Show("Do you want to Re-Print?", "CMS Billing Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
                }
                ClearALL();
                btnKOTSave.Enabled = true;
                txtAccNo.Focus();
                return;
            }
            else if (blist._action == BillActionType.NOCRLIMIT)
            {
                MessageBox.Show("Member exceeded Credit Limit", "CMS Billing Details");
                return;
            }
            else if (blist._action == BillActionType.Finalize)
            {
                MessageBox.Show("Posted Successfully", "CMS Billing Details");
                viewMode = false;
                cmbBillTo.Enabled = true;
                ClearALL();
                return;
            }
            else
            {
                MessageBox.Show("Error occured while Posting....", "CMS Billing Details");
                return;
            }
            
        }
        private Boolean ValidateData()
        {
            if (_member == null && cmbBillMode.SelectedIndex==1)
            {
                MessageBox.Show("Select Member", "CMS Billing Details");
                txtAccNo.Focus();
                return false;
            }
            if (cmbTable.SelectedIndex == 0)
            {
                MessageBox.Show("Select Table", "CMS Billing Details");
                cmbTable.Focus();
                return false;
            }
            if (txtBearerName.Text == "")
            {
                MessageBox.Show("Enter steward", "CMS Billing Details");
                txtBearerName.Focus();
                return false;
            }
            if (grdBilling.RowCount == 1)
            {
                MessageBox.Show("Enter Item Details", "CMS Billing Details");
                return false;
            }
            return true;
        }
        //private Boolean ValidateCardData()
        //{
        //    if (cmbBillMode.SelectedIndex == 0)
        //    {
        //        if (cmbPaymentMode.SelectedItem.ToString() == "")
        //        {
        //            MessageBox.Show("Select Payment Mode", "CMS Billing Details");
        //            return false;
        //        }
        //        if (cmbPaymentMode.SelectedItem.ToString() == "Credit Card")
        //        {
        //            if (txtBankName.Text == "")
        //            {
        //                MessageBox.Show("Enter Bank Name", "CMS Billing Details");
        //                return false;
        //            }
        //            if (cmbCardType.SelectedItem.ToString() == "")
        //            {
        //                MessageBox.Show("Select Credit Card Type", "CMS Billing Details");
        //                return false;
        //            }
        //            if (txtCardNumber.Text == "" || txtCardNumber.Text.Length < 4)
        //            {
        //                MessageBox.Show("Enter last 4 digit of the credit card", "CMS Billing Details");
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove selected rows", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No) return;

            int cnt = 0;
            foreach (DataGridViewRow dr in grdBilling.Rows)
            {
                if (string.Concat(dr.Cells["chk"].Value).ToLower() == "true")
                {
                    cnt++;
                }
            }
            if (grdBilling.Rows.Count == cnt)
            {
                MessageBox.Show("All rows cant be deleted", "CMS Billing Details");
                return;
            }
            for (int k = grdBilling.Rows.Count - 1; k > -1; k--)
            {
                if (string.Concat(grdBilling.Rows[k].Cells["chk"].Value).ToLower() == "true")
                {
                    grdBilling.Rows.RemoveAt(k);
                }
            }
        }

        private void tblExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want Logoff?", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Isclosing = true;
            //LoginForm loginForm = new LoginForm();
            //loginForm.Width = 536;
            //loginForm.Height = 387;
            //loginForm.Show();
            _Parent.Show();
            this.Close();
        }
        void ICMSBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!IslistOpen)
            //{
                if (!Isclosing)
                {
                    if (MessageBox.Show("Do you want Logoff?", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Isclosing = true;
                }
            //}
        }
        //private void tblBillCancel_Click(object sender, EventArgs e)
        //{
        //    if (billId == 0)
        //    {
        //        MessageBox.Show("Select Bill to cancel", "CMS Billing Details");
        //        return;
        //    }
        //    //pnlAcChange.Visible = true;
        //}

        void grdBilling_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            OnDeleteRow();
        }
        void grdBilling_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }
        void OnDeleteRow()
        {
            AssignSerailNumber();

            CalculateBillAmount();
            if (string.Concat(grdBilling.CurrentRow.Cells[8].Value) != "")
            {
                if (mode != "medit") return;
                int k = 0;
                DeletedItemDetails ditm = new DeletedItemDetails();
                ditm._billId = billId;
                int itmId = 0;
                int.TryParse(string.Concat(grdBilling.CurrentRow.Cells[8].Value), out itmId);
                ditm._itemId = itmId;
                int.TryParse(string.Concat(grdBilling.CurrentRow.Cells[13].Value), out k);
                ditm._itemSerialNo = k;
                _bController.DataStore.AddDeletedItemDetails(ditm);
                if (_TaxMap != null)
                {
                    if (_TaxMap.ContainsKey(string.Concat(grdBilling.CurrentRow.Cells[13].Value)))
                        _TaxMap.Remove(string.Concat(grdBilling.CurrentRow.Cells[13].Value));
                }
            }
        }
        //bool IslistOpen = false;
        private void tblModify_Click(object sender, EventArgs e)
        {
            
            BillSummary bsum = new BillSummary();
            bsum.StoreId = StoreId;
            if (cmbBillTo.DataSource == null || ((Party)cmbBillTo.SelectedItem)._partyId == "0")
            {
                bsum.BillType = "RR";
            }
            else
            {
                bsum.BillType = "PR";
            }
            bsum.Owner = this;
            if (StoreId == "") StoreId = "0";
            //IslistOpen = true;

            DialogResult drl = bsum.ShowDialog();
            if (drl == DialogResult.Yes)
            {
                BillDetailList billList = new BillDetailList();

                billList._bill = new Bill();
                billList._bill._billId = billId;
                billList._bill._billCalncelDate = new DateTime(1900, 1, 1);
                billList._bill._billDate = new DateTime(1900, 1, 1);
                billList._bill._createdDate = new DateTime(1900, 1, 1);
                billList._bill._modifiedDate = new DateTime(1900, 1, 1);
                if (cmbBillTo.DataSource == null || ((Party)cmbBillTo.SelectedItem)._partyId == "0")
                {
                    billList._bill._billType = "RR";
                }
                else
                {
                    billList._bill._billType = "PR";
                }
                billList._action = BillActionType.Modify;
                billList._memb = new BillingMemberDetails();
                billList._memb._curDateTime = DateTime.Now;
                billList._memb._storeId = StoreId; ;
                BillDetailList blist = _bController.GetBilling(billList);
                if (blist._action == BillActionType.Success)
                {
                    LoadBill(blist);
                    tblPost.Enabled = false;
                    mode = "medit";
                    btnSave.Enabled = false;
                    SmartCardReaderNew objSmart = new SmartCardReaderNew();
                    if (blist._bill._printText != string.Empty)
                    {
                        string prnname = IS91.Services.Common.GetAppSetting("PrinterName");
                        if (MessageBox.Show("Do you want to Re-Print?", "CMS Billing Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            objSmart.CustomPrintDocument(blist._bill._printText, prnname);
                        }
                    }
                    ClearALL();
                }
                else if (blist._action == BillActionType.Failure)
                {
                    MessageBox.Show("Data is not Available", "CMS Billing Details");
                }
                //IslistOpen = false;
            }
        }
        void tblPending_Click(object sender, System.EventArgs e)
        {
            BillPending pendBill = new BillPending();
            pendBill.StoreId = StoreId;
            pendBill.Owner = this;
            pendBill.ShowDialog();
        }
        private void btnMemSearch_Click(object sender, EventArgs e)
        {
            DependantMemberSearch depMem = new DependantMemberSearch();
            depMem.Owner = this;
            depMem.ShowDialog();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            tblClear_Click(sender, e);
            GetStoreID();
            if (cmbTable.Items.Count > 0)
                cmbTable.SelectedIndex = 0;

            txtAccNo.Focus();
            btnSave.Enabled = false;
            btnKOTSave.Enabled = true;
            btnKOTCancelSave.Enabled = true;
            btnFinalize.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            blnNo = false;
            btnSave.Enabled = false;
            tblFinalize_Click(sender, e);
            if (posId.ToLower() != "spa")
            {
                btnSave.Enabled = true;
                btnKOTSave.Enabled = false;
            }
            if (cmbBillTo.DataSource == null || ((Party)cmbBillTo.SelectedItem)._partyId == "0")
            {
                btnSave.Enabled = false;
                btnKOTCancelSave.Enabled = true;
                btnFinalize.Enabled = true;
            }
            else
            {
                btnSave.Enabled = true;
                btnKOTSave.Enabled = false;
                btnKOTCancelSave.Enabled = false;
                btnFinalize.Enabled = false;
            }
            if (IsFinalize)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }
        private void btnKOTCancelSave_Click(object sender, EventArgs e)
        {
            tblKOTCancel_Click(sender, e);
            if (viewMode)
            {
                if(!btnSave.Enabled)
                  btnSave.Enabled = true;
            }
        }
        private void btnKOTSave_Click(object sender, EventArgs e)
        {
            if (cmbBillMode.SelectedIndex == 0)
            {
                tblPostVisitor_Click(sender, e);
            }
            else
            {
                tblPost_Click(sender, e);
            }
            btnKOTSave.Enabled = true;
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            tblModify_Click(sender, e);
        }
        private void btnPending_Click(object sender, EventArgs e)
        {
            tblPending_Click(sender, e);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            tblExit_Click(sender, e);
        }
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            tblReadcard_Click(sender, e);
            //cmbBillTo.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tblViewm_Click(sender, e);
        }
        void ICMSBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt) return;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;
                case Keys.F6:
                    tblReadcard_Click(sender, e);
                    break;
                case Keys.Escape:
                    tblExit_Click(sender, e);
                    break;
                case Keys.F11:
                    tblPending_Click(sender, e);
                    break;
                case Keys.F2:
                    if (btnModify.Enabled)
                    {
                        tblModify_Click(sender, e);
                    }
                    break;
                case Keys.F8:
                    tblViewm_Click(sender, e);
                    break;
                case Keys.F7:
                    if (btnKOTSave.Enabled)
                    {
                        if (cmbBillMode.SelectedIndex == 0)
                        {
                            tblPostVisitor_Click(sender, e);
                        }
                        else
                        {
                            tblPost_Click(sender, e);
                        }
                    }
                    break;
                case Keys.F5:
                    if (btnSave.Enabled)
                    {
                        tblFinalize_Click(sender, e);                        
                    }
                    break;
                case Keys.F3:
                    tblClear_Click(sender, e);
                    txtAccNo.Focus();
                    break;
                case Keys.F4:
                    btnMemSearch_Click(sender, e);
                    break;                
            }
        }        
        private void btnReport_Click(object sender, EventArgs e)
        {
            CMSReports cmsRpt = new CMSReports();
            cmsRpt.ShowDialog();
        }
        #region KOT BOT print Ravindra


        private void tblKOTCancel_Click(object sender, EventArgs e)
        {
            if (cmbBillMode.SelectedIndex >= 1)
            {
                if (_member == null)
                {
                    MessageBox.Show("Select Member", "CMS Billing Details");
                    txtAccNo.Focus();
                    return;
                }
            }
            if (KOTID != 0)
            {
                KOTBillPrint blist = _bController.KOTPrintUpdated(KOTPrintDetails());
            }
            else
            {
                MessageBox.Show("Please update item quantity ");
                return;
            }
        }
        private void GetCancelItem()
        {           
            KOTBillCancel blist = _bController.KOTBotCancel(KOTBotDetails());
            if (blist._action == BillActionType.NOCRLIMIT)
            {
                    btnKOTCancelSave.Enabled = false;
            }
            else
            {
                btnKOTCancelSave.Enabled = true;
            }           
        }
        private KOTBillCancel KOTBotDetails()
        {
            KOTBillCancel blist = new KOTBillCancel();
            blist._ID = KOTID;
            blist._Quantity = KOTQty;
           if(txtBalance.Text!="")
             blist._Balance = double.Parse(txtBalance.Text);
           if (txtNetAmount.Text != "")
                blist._NetAmt = double.Parse(txtNetAmount.Text);
            
            if (viewMode) blist._isView = true;
            else blist._isView = false;
            return blist;
        }
        private KOTBillPrint KOTPrintDetails()
        {
            KOTBillPrint blist = new KOTBillPrint();
            blist._ID = KOTID;
            blist._QTY = KOTQty;
            blist._MemberID = _member==null?0:Convert.ToInt32(_member._memberID);
            blist._TableID = ((TableNumber)cmbTable.SelectedValue)._tableId;
            return blist;
        }
        void cmbTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.AutoComplete((ComboBox)sender, e, true);
        }
        public void GetStoreID()
        {
        if (posId == "0")
            {
                Labe20.Text = "KITCHEN AND BAR";
                StoreId = IS91.Services.Common.GetAppSetting("KitchenAndBar");
            }
            else if (posId == "K")
            {
                Labe20.Text = "KITCHEN";
                StoreId = IS91.Services.Common.GetAppSetting("Kitchen");
            }
            else if (posId == "B")
            {
                Labe20.Text = "BAR";
                StoreId = IS91.Services.Common.GetAppSetting("Bar");
            }
        }
        public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e)
        {
            this.AutoComplete(cb, e, false);
        }

        public void AutoComplete(ComboBox cb,System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8) 
            {
                if (cb.SelectionStart <= 1) 
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else 
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else 
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }
        }
        #endregion

        //private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbPaymentMode.SelectedIndex == 0)
        //    {
        //        pnlCardDetails.Visible = false;
        //    }
        //    else if (cmbPaymentMode.SelectedIndex == 1)
        //    {
        //        pnlCardDetails.Visible = true;
        //    }
        //}

        private void cmbBillMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearALL();
            if (cmbBillMode.SelectedItem.ToString() == "Walkin") {
                pnlMemberDetails.Visible = false;
                btnReadCard.Visible = false;
                //pnlPaymentMode.Visible = true;
            }
            else {
                pnlMemberDetails.Visible = true;
                btnReadCard.Visible = true;
                //pnlPaymentMode.Visible = false;
            }
            btnKOTSave.Enabled = true;
        }
    }

}
