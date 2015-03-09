using System;
using System.Collections.Generic;
using System.Text;
using IRCAKernel;
using PDACommunications;
using System.Windows.Forms;


namespace BillingManager
{
    public class BillController
    {
        public static BillController _billController;
        private BillDataStore _dataStore;
        private IRCAServer _server;

        public BillDataStore DataStore
        {
            get
            {
                return _dataStore;
            }
        }

        public static BillController CreateController()
        {
            if (null == _billController)
            {
                _billController= new BillController();
            }

            return _billController;
        }

        private BillController()
        {
            if (null == _dataStore)
            {
                _dataStore = new BillDataStore();
            }
        }

        public bool IsServerURLSet()
        {
            IRCARegistery registery = new IRCARegistery();
            String url = registery.Read(BillDefs.URLRegKey);
            
            if (url == null)
            {
                return false;
            }

            return true;
        }

        public void StartController()
        {

            IRCARegistery registery = new IRCARegistery();
            String url = registery.Read(BillDefs.URLRegKey);
            int timeOut = Convert.ToInt32(registery.Read(BillDefs.TIMEOUT));

            if(_server == null)
            {
                _server = new IRCAServer(url, timeOut);
            }
            else
            {
                _server.URL = url;
                _server.TimeOut = timeOut;
            }
        }

        public BillingBasicStatusMessagae Initialize()
        {
            BillingBasicStatusMessagae status = GetMenu();
            status = GetStewards();
            status = GetGodowns();
            return status;

        }
        public BillingBasicStatusMessagae GetMenu()
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.MenuList;
            
            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            MenuList mList = (MenuList)response;

            _dataStore.ClearMenu();

            foreach (BillingMenu mn in mList._menu)
            {
                _dataStore.AddMenu(mn);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }

        public BillingBasicStatusMessagae GetGodowns()
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.GodownList;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            MenuList mList = (MenuList)response;

            _dataStore.ClearGodown();

            foreach (BillingMenu mn in mList._menu)
            {
                _dataStore.AddGodown(mn);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }
        public BillingLoginResponse Login(String LoginName, String Password)
        {
            BillingLoginResponse loginRes;

            BillingLoginRequest loginReq = new BillingLoginRequest();

            loginReq._loginName = LoginName;
            if(Password!=string.Empty)
                loginReq._password = IRCAUtils.Encrypt(Password);

            CommunicationObject response = _server.getResponse(loginReq);

            if (response is ErrorMessage)
            {
                loginRes = new BillingLoginResponse();
                loginRes._isSuccess = false;
                loginRes._message = ((ErrorMessage)response)._errorMessage;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                loginRes = new BillingLoginResponse();
                loginRes._isSuccess = false;
                loginRes._message = ((BillingBasicStatusMessagae)response)._message;
            }
            else
            {
                loginRes = (BillingLoginResponse)response;
            }

            return loginRes;
        }

        public  BillingBasicRequest GetBillNumber(String computerName)
        {
            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.BillNumber;
            request._computerName = computerName;

            CommunicationObject response = _server.getResponse(request);

            if (response is BillingBasicRequest)
            {
                return (BillingBasicRequest)response;
            }
            return null;
        }


        public BillingBasicStatusMessagae GetItemList(string storeId)
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.ItemListRequest;
            request._storeId = storeId;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            BillingItemList iList = (BillingItemList)response;

            _dataStore.ClearItemList();

            foreach (BillingItemDetails itmdet in iList._itemList)
            {
                _dataStore.AddItemDetails(itmdet);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }
        public BillToStatusMessagae GetBillTo(string Memberid)
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.BillTo;
            request._MemberId = Memberid;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillToStatusMessagae msg = new BillToStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillToStatusMessagae)
            {
                return (BillToStatusMessagae)response;
            }

            PartyList iList = (PartyList)response;

            _dataStore.ClearPartyList();

            foreach (Party itmdet in iList._partyList)
            {
                _dataStore.AddPartyDetails(itmdet);
            }

            BillToStatusMessagae msgSuccess = new BillToStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }


        public BillingBasicStatusMessagae GetItemListCat(string StoreId, int itmId)
        {

            BillingBasicRequest request = new BillingBasicRequest();
           // CommunicationObject response = _server.getResponse(request);
            request._requestID = (short)BillRequestID.ItemListRequestCat;
            request._storeId = StoreId;
            request._itmId = itmId.ToString();

            if (request == null) return null;
            request._action = BillActionType.Itemlist;
            CommunicationObject response = _server.getResponse(request);
           // CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            BillingItemList iList = (BillingItemList)response;

            _dataStore.ClearItemList(StoreId);

            foreach (BillingItemDetails itmdet in iList._itemList)
            {
                _dataStore.AddItemDetails(itmdet, StoreId);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }

        public BillingItemDetails GetItem(string itemCode, int storeId, DateTime dtAsOn,String MemberType)
        {

            BillingItemDetails request = new BillingItemDetails();
            request._itemCode = itemCode;
            request._storeId = storeId;
            request._dtAsOn = dtAsOn;
            request._memberType = MemberType;
            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage || ((PDACommunications.BillingItemDetails)response)._storeId != storeId && storeId !=0)
            {
                return null;
            }
            else if (response is BillingItemDetails)
            {
                return (BillingItemDetails)response;
            }

              
            return null;
        }
        public BillingBasicStatusMessagae GetStewards()
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.StewardList;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            StewardList sList = (StewardList)response;

            _dataStore.ClearStewards();

            foreach (Steward st  in sList._stewards)
            {
                _dataStore.AddStewards(st);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }
        public BillingBasicStatusMessagae GetTableList(string storeId)
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.TableList;
            request._storeId = storeId;
            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            BillingTableList tList = (BillingTableList)response;

            _dataStore.ClearTableNo();

            foreach (TableNumber tbl in tList._tables)
            {
                _dataStore.AddTableNo(tbl);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }

        public BillingBasicStatusMessagae GetDependantMemberList(string nam,string rel )
        {

            DependantMemberDetails request = new DependantMemberDetails();
            request._dependantID = "";
            request._dependantName = nam;
            request._realtion= rel;
            request._isMember = false;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            DependantMemberList iList = (DependantMemberList)response;

            foreach (DependantMemberDetails depdet in iList._depList)
            {
                _dataStore.AddDepMemberDetails(depdet);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }

        public BillingBasicStatusMessagae GetDependantMemberList(string nam, string rel,string memId)
        {

            DependantMemberDetails request = new DependantMemberDetails();
            request._dependantID = "";
            request._dependantName = nam;
            request._realtion = rel;
            request._memberID = memId;
            request._isMember = false;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            DependantMemberList iList = (DependantMemberList)response;
            _dataStore.ClearDependantList();
            foreach (DependantMemberDetails depdet in iList._depList)
            {
                _dataStore.AddDepMemberDetails(depdet);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }

        public BillingBasicStatusMessagae GetMemberList(string nam, string rel)
        {

            DependantMemberDetails request = new DependantMemberDetails();
            request._dependantID = "";
            request._memberID = "";
            request._memberName = nam;
            request._realtion = rel;
            request._isMember = true;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            DependantMemberList iList = (DependantMemberList)response;
            _dataStore.ClearDependantList();
            foreach (DependantMemberDetails depdet in iList._depList)
            {
                _dataStore.AddDepMemberDetails(depdet);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }
        public DependantMemberDetails GetDependantMember(string depmemberId)
        {
            DependantMemberDetails request = new DependantMemberDetails();
            request._dependantID= depmemberId;

            CommunicationObject response = _server.getResponse(request);

            if (response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return null;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (DependantMemberDetails)response;
            }

            DependantMemberDetails dmemb = (DependantMemberDetails)response;
            return dmemb;
        }

        public BillingMemberDetails GetMember( string memberId)
        {
            BillingMemberDetails request = new BillingMemberDetails();
            request._memberID = memberId;

            CommunicationObject response = _server.getResponse(request);

            if (response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return null;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingMemberDetails)response;
            }

            BillingMemberDetails memb = (BillingMemberDetails)response;
            return memb;
        }
        public BillingBasicStatusMessagae GetMember(ref BillingMemberDetails memb)
        {

            CommunicationObject response = _server.getResponse(memb);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg= (BillingBasicStatusMessagae)response;
            }

            memb = (BillingMemberDetails)response;
            msg._isSuccess = true;
            return msg;
        }

        public BillDetailList GetBilling(BillDetailList billList)
        {
            
            CommunicationObject response = _server.getResponse(billList);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return billList;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }

            billList = (BillDetailList)response;
            msg._isSuccess = true;
            return billList;
        }

        public void GetReportTable(ref ReportTable rpt)
        {

            CommunicationObject response = _server.getResponse(rpt);
            rpt = (ReportTable)response;
              
        }

        public BillSummaryList GetBillSummary(BillSummaryList billSumList)
        {

            CommunicationObject response = _server.getResponse(billSumList);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return billSumList;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }

            billSumList = (BillSummaryList)response;
            msg._isSuccess = true;
            return billSumList;
        }

        public PendingBillList GetPendingBillDetails(PendingBillList pendbillList)
        {

            CommunicationObject response = _server.getResponse(pendbillList);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return pendbillList;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }

            pendbillList = (PendingBillList)response;
            msg._isSuccess = true;
            return pendbillList;
        }
        public PendingBillDetails DeletePendingBillDetails(PendingBillDetails pendbilldet)
        {

            CommunicationObject response = _server.getResponse(pendbilldet);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return pendbilldet;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }
            else if (response is PendingBillDetails)
            {
                pendbilldet = (PendingBillDetails)response;
            }
            
            return pendbilldet;
        }
        //public BillDetailList SaveBilling(BillDetailList blist)
        //{
        //    if (blist == null) return null;
        //    blist._action = BillActionType.Save;

        //    CommunicationObject response = _server.getResponse(blist);
        //    BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
        //    if (response is ErrorMessage)
        //    {
        //        msg._isSuccess = false;
        //        msg._message = ((ErrorMessage)response)._errorMessage;

        //        return blist;
        //    }
        //    else if (response is BillingBasicStatusMessagae)
        //    {
        //        msg = (BillingBasicStatusMessagae)response;
        //    }

        //    blist = (BillDetailList)response;
        //    msg._isSuccess = true;
        //    return blist;
        //}

     
        public BillDetailList SaveBilling(BillDetailList blist)
        {
            if (blist == null) return null;
            blist._action = BillActionType.Save;

            CommunicationObject response = _server.getResponse(blist);


            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return blist;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }
            KOTBillPrintTableList tList = (KOTBillPrintTableList)response;
            if (tList._PrintTables[0]._KOTNo == BillActionType.NOCRLIMIT.ToString())
            {
                MessageBox.Show("Member exceeded Credit Limit", "CMS Billing Details");
                return blist;
            }
            MessageBox.Show("Billing Data Successfully Saved", "CMS Billing Details");
            // if (MessageBox.Show("Do you want to Print?", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No) return;
            // KOTBillPrintTableList tList = (KOTBillPrintTableList)response;
            PrintKOT Print = new PrintKOT();
            Print.print(tList);
            PrintOTNonVeg PrintNonVeg = new PrintOTNonVeg();
            PrintNonVeg.print(tList);
            // blist = (BillDetailList)response;
            msg._isSuccess = true;
            return blist;
        }

        public BillDetailList SaveVisitorBilling(BillDetailList blist)
        {
            if (blist == null) return null;
            blist._action = BillActionType.SaveVisitor;

            CommunicationObject response = _server.getResponse(blist);


            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return blist;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }
            KOTBillPrintTableList tList = (KOTBillPrintTableList)response;
            MessageBox.Show("Billing Data Successfully Saved", "CMS Billing Details");
            // if (MessageBox.Show("Do you want to Print?", "CMS Billing Details", MessageBoxButtons.YesNo) == DialogResult.No) return;
            // KOTBillPrintTableList tList = (KOTBillPrintTableList)response;
            PrintKOT Print = new PrintKOT();
            Print.print(tList);
            PrintOTNonVeg PrintNonVeg = new PrintOTNonVeg();
            PrintNonVeg.print(tList);
            // blist = (BillDetailList)response;
            msg._isSuccess = true;
            return blist;
        }
        public BillDetailList PostBilling(BillDetailList blist)
        {
            if (blist == null) return null;
            blist._action = BillActionType.Finalize;

            CommunicationObject response = _server.getResponse(blist);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return blist;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }

            blist = (BillDetailList)response;
            msg._isSuccess = true;
            return blist;
        }

        public BillCancel CancelBilling(BillCancel blist)
        {
            if (blist == null) return null;
            blist._action = BillActionType.Cancel;

            CommunicationObject response = _server.getResponse(blist);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return blist;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }

            blist = (BillCancel)response;
            msg._isSuccess = true;
            return blist;
        }

        //For Reports
        /// <summary>
        /// Get Billed Items
        /// </summary>
        /// <returns></returns>
        public BillingBasicStatusMessagae GetBilledItemList()
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.BilledItem;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            BilledItemList iList = (BilledItemList)response;

            _dataStore.ClearBilledItem();

            foreach (BilledItem itmdet in iList._bItems)
            {
                _dataStore.AddBilledItems(itmdet);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }

        /// <summary>
        /// Get Item Groups
        /// </summary>
        /// <returns></returns>
        public BillingBasicStatusMessagae GetItemGroups()
        {

            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.ItemGroup;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return msg;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                return (BillingBasicStatusMessagae)response;
            }

            ItemGroupList gList = (ItemGroupList)response;

            _dataStore.ClearItemGroup();

            foreach (ItemGroup grp in gList._iGroups)
            {
                _dataStore.AddItemGroup(grp);
            }

            BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            msgSuccess._isSuccess = true;
            msgSuccess._message = "";

            return msgSuccess;
        }
        public KOTBillPrint KOTPrint(KOTBillPrint blist)
        {
            if (blist == null) return null;
            blist._action = BillActionType.Print;

            CommunicationObject response = _server.getResponse(blist);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return blist;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }
            KOTBillPrintTableList tList = (KOTBillPrintTableList)response;
            PrintKOT Print = new PrintKOT();
            Print.print(tList);

            MessageBox.Show("Kot Printed Successfully");

            return blist;
        }
        //public KOTBillPrint KOTPrintUpdated(KOTBillPrint blist)
        //{
        //    if (blist == null) return null;
        //    blist._action = BillActionType.Print;

        //    CommunicationObject response = _server.getResponse(blist);
        //    BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
        //    if (response is ErrorMessage)
        //    {
        //        msg._isSuccess = false;
        //        msg._message = ((ErrorMessage)response)._errorMessage;

        //        return blist;
        //    }
        //    else if (response is BillingBasicStatusMessagae)
        //    {
        //        msg = (BillingBasicStatusMessagae)response;
        //    }
        //    KOTBillPrintTableList tList = (KOTBillPrintTableList)response;
        //    PrintKOT Print = new PrintKOT();
        //    Print.printUpdated(tList);
        //    // MessageBox.Show("Kot Printed Successfully");

        //    return blist;
        //}

        public KOTBillPrint KOTPrintUpdated(KOTBillPrint blist)
        {
            if (blist == null) return null;
            blist._action = BillActionType.Print;

            CommunicationObject response = _server.getResponse(blist);
            BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();
            if (response is ErrorMessage)
            {
                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return blist;
            }
            else if (response is BillingBasicStatusMessagae)
            {
                msg = (BillingBasicStatusMessagae)response;
            }
            KOTBillPrintTableList tList = (KOTBillPrintTableList)response;
            PrintKOT Print = new PrintKOT();
            Print.printUpdated(tList);
            PrintOTNonVeg PrintNoveg = new PrintOTNonVeg();
            PrintNoveg.printUpdated(tList);
            // MessageBox.Show("Kot Printed Successfully");

            return blist;
        }
        public KOTBillCancel KOTBotCancel(KOTBillCancel blist)
        {
            if (blist == null) return null;         

            CommunicationObject response = _server.getResponse(blist);
            //if (((KOTBillCancel)response)._action == BillActionType.NOCRLIMIT)
            //{
            //    MessageBox.Show("Member exceeded Credit Limit", "CMS Billing Details");
            //    blist._action = BillActionType.NOCRLIMIT;
            //    return blist;
            //}
            return blist;
        }

        public bool PayBill(PayBillObject blist)
        {
            if (blist == null) return false;         

            CommunicationObject response = _server.getResponse(blist);
            //if (((KOTBillCancel)response)._action == BillActionType.NOCRLIMIT)
            //{
            //    MessageBox.Show("Member exceeded Credit Limit", "CMS Billing Details");
            //    blist._action = BillActionType.NOCRLIMIT;
            //    return blist;
            //}
            if (((PayBillObject)response)._action == BillActionType.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ComboHead GetCreditCardType()
        {
            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.CreditCardType;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return null;
            }
            //else if (response is BillingBasicStatusMessagae)
            //{
            //    return (BillingBasicStatusMessagae)response;
            //}

            ComboHead mList = (ComboHead)response;

            //_dataStore.ClearMenu();

            //foreach (BillingMenu mn in mList._combo)
            //{
            //    _dataStore.AddMenu(mn);
            //}

            //BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            //msgSuccess._isSuccess = true;
            //msgSuccess._message = "";

            return mList;
        }

        public ComboHead GetEDCMaster()
        {
            BillingBasicRequest request = new BillingBasicRequest();

            request._requestID = (short)BillRequestID.EdcrMaster;

            CommunicationObject response = _server.getResponse(request);

            if (response == null || response is ErrorMessage)
            {
                BillingBasicStatusMessagae msg = new BillingBasicStatusMessagae();

                msg._isSuccess = false;
                msg._message = ((ErrorMessage)response)._errorMessage;

                return null;
            }
            //else if (response is BillingBasicStatusMessagae)
            //{
            //    return (BillingBasicStatusMessagae)response;
            //}

            ComboHead mList = (ComboHead)response;

            //_dataStore.ClearMenu();

            //foreach (BillingMenu mn in mList._combo)
            //{
            //    _dataStore.AddMenu(mn);
            //}

            //BillingBasicStatusMessagae msgSuccess = new BillingBasicStatusMessagae();

            //msgSuccess._isSuccess = true;
            //msgSuccess._message = "";

            return mList;
        }
        
    }
}
