using System;
using System.Collections.Generic;
using System.Text;
using PDACommunications;

namespace BillingManager
{
    public class BillDataStore
    {

        private Dictionary<String, BillingMemberDetails> _memberMap;
        private Dictionary<int, Bill> _billMap;
        private Dictionary<String, BillDetails> _detailsMap;
        private Dictionary<int, BillingItemDetails> _itemMap;
        private Dictionary<int, BillingItemDetails> _itemListBar;
        private Dictionary<int, BillingItemDetails> _itemListKitchen;

        private Dictionary<string, DependantMemberDetails> _depMemberMap;
        private Dictionary<String, Steward> _stewMap;
        private Dictionary<String, TableNumber> _tblwMap;
        private Dictionary<String, BillingMenu> _menuMap;
        private Dictionary<String, BillingMenu> _godownMap;
        private Dictionary<String, BillSummaryDetails> _billSumMap;
        private Dictionary<String, DeletedItemDetails> _deletedItemsMap;
        private Dictionary<String, BilledItem> _billedItemsMap;
        private Dictionary<String, ItemGroup> _ItemGroupMap;
        private Dictionary<String, Party> _PartyListMap;
        private String _loggedInPersonId;
        private int _loggedInUserId;
        private String _loggedInUser;
        private BillingPermissions[] _bPermission;
        private BillController _billController;
        public String LoggedInPersonId
        {
            get
            {
                return _loggedInPersonId;
            }
            set
            {
                _loggedInPersonId = value;
            }
        }
        public int LoggedInUserId
        {
            get
            {
                return _loggedInUserId;
            }
            set
            {
                _loggedInUserId = value;
            }
        }
        public BillingPermissions[] UserPermissions
        {
            get
            {
                return _bPermission;
            }
            set
            {
                _bPermission = value;
            }
        }
        public String LoggedInUser
        {
            get
            {
                return _loggedInUser;
            }
            set
            {
                _loggedInUser = value;
            }
        }

        public BillDataStore()
        {
            _detailsMap = new Dictionary<string, BillDetails>();
            _billMap = new Dictionary<int, Bill>();
            _itemMap =new Dictionary<int,BillingItemDetails>();
            _itemListBar = new Dictionary<int, BillingItemDetails>();
            _itemListKitchen =new Dictionary<int,BillingItemDetails>();
            _stewMap = new Dictionary<string, Steward>();
            _tblwMap = new Dictionary<string, TableNumber>();
            _menuMap = new Dictionary<string, BillingMenu>();
            _godownMap = new Dictionary<string, BillingMenu>();
            _billSumMap = new Dictionary<string, BillSummaryDetails>();
            _deletedItemsMap = new Dictionary<string, DeletedItemDetails>();
            _depMemberMap= new Dictionary<string, DependantMemberDetails>();
            _billedItemsMap = new Dictionary<string, BilledItem>();
            _ItemGroupMap = new Dictionary<string, ItemGroup>();
            _PartyListMap = new Dictionary<string, Party>();
        }


        public void ClearMenu()
        {
            _menuMap.Clear();
        }
        public void AddMenu(BillingMenu mnu)
        {

            _menuMap.Add(mnu._storeId, mnu);

        }
        public BillingMenu[] GetMenu()
        {
            BillingMenu[] list = new BillingMenu[_menuMap.Values.Count];

            _menuMap.Values.CopyTo(list, 0);

            return list;
        }
         public void ClearGodown()
        {
            _godownMap.Clear();
        }
        public void AddGodown(BillingMenu mnu)
        {

            _godownMap.Add(mnu._storeId, mnu);

        }
        public BillingMenu[] GetGodown()
        {
            BillingMenu[] list = new BillingMenu[_godownMap.Values.Count];

            _godownMap.Values.CopyTo(list, 0);

            return list;
        }
        public void ClearStewards()
        {
            _stewMap.Clear();
        }
        public void AddStewards(Steward stew)
        {

            _stewMap.Add(stew._stewardId, stew);

        }
        public Steward[] GetStewards()
        {
            Steward[] list = new Steward[_stewMap.Values.Count];

            _stewMap.Values.CopyTo(list, 0);

            return list;
        }

        public void ClearTableNo()
        {
            _tblwMap.Clear();
        }
        public void AddTableNo(TableNumber tbl)
        {

            _tblwMap.Add(tbl._tableId, tbl);

        }
        public TableNumber[] GetTableNo()
        {
            TableNumber[] list = new TableNumber[_tblwMap.Values.Count];

            _tblwMap.Values.CopyTo(list, 0);

            return list;
        }
        public Party[] GetParty()
        {
            if (_PartyListMap.Values.Count == 0)
            {
                return null;
            }            
            else{
                 Party[] list = new Party[_PartyListMap.Values.Count];

                _PartyListMap.Values.CopyTo(list, 0);

                return list;
            }
        }
        public void ClearPartyList()
        {
            _PartyListMap.Clear();
        }
        public Party[] GetBillTo()
        {
            Party[] list = new Party[_PartyListMap.Values.Count];

            _PartyListMap.Values.CopyTo(list, 0);

            return list;
        }
        public void ClearBillDetails()
        {
            _detailsMap.Clear();
        }
        public void AddDetails(BillDetails bDetails)
        {
            _detailsMap.Add(string.Concat(bDetails._itemSerialNo), bDetails);
        }

         public BillDetails[] GetBillDetails()
        {
            BillDetails[] list = new BillDetails[_detailsMap.Values.Count];

            _detailsMap.Values.CopyTo(list,0);

            return list;
        }

         public void ClearDeletedItemDetails()
         {
             _deletedItemsMap.Clear();
         }
         public void AddDeletedItemDetails(DeletedItemDetails iDetails)
         {
             if (!_deletedItemsMap.ContainsKey(string.Concat(iDetails._itemId)))
             {
                 _deletedItemsMap.Add(string.Concat(iDetails._itemId), iDetails);
             }
         }

         public DeletedItemDetails[] GetDeletedItemDetails()
         {
             DeletedItemDetails[] list = new DeletedItemDetails[_deletedItemsMap.Values.Count];

             _deletedItemsMap.Values.CopyTo(list, 0);

             return list;
         }

        public void ClearItemList()
        {
            _itemMap.Clear();
        }
        
        public void AddItemDetails(BillingItemDetails iDetails)
        {

            _itemMap.Add(iDetails._itemId, iDetails);

        }

        public BillingItemDetails[] GetItemDetails()
        {
            BillingItemDetails[] list = new BillingItemDetails[_itemMap.Values.Count];

            _itemMap.Values.CopyTo(list, 0);

            return list;
        }
        public void ClearItemList(string StoreId)
        {
            _itemListBar.Clear();
            //if (StoreId == 1)
            //    _itemListBar.Clear();
            //else
            //    _itemListKitchen.Clear();

        }

        public void AddItemDetails(BillingItemDetails iDetails, string StoreId)
        {
            _itemListBar.Add(iDetails._itemId, iDetails);
            //if (catId == 1)
            //    _itemListBar.Add(iDetails._itemId, iDetails);
            //else
            //    _itemListKitchen.Add(iDetails._itemId, iDetails);
        }

        public void AddPartyDetails(Party iDetails)
        {
            if (iDetails != null)
            {
                _PartyListMap.Add(iDetails._partyId, iDetails);
            }
        }

        public BillingItemDetails[] GetItemDetails(string StoreId, int itmId)
        {
            BillingItemDetails[] list = null;
            list = new BillingItemDetails[_itemListBar.Values.Count];
            _itemListBar.Values.CopyTo(list, 0);
              //if (catId == 1)   
              //{
              //     list= new BillingItemDetails[_itemListBar.Values.Count];
              //     _itemListBar.Values.CopyTo(list, 0);
              //}
              //else
              //{
              //    list= new BillingItemDetails[_itemListKitchen.Values.Count];
              //    _itemListKitchen.Values.CopyTo(list, 0);
              //}
            return list;
        }

        public void ClearDependantList()
        {
            _depMemberMap.Clear();
        }
        public void AddDepMemberDetails(DependantMemberDetails dDetails)
        {
            if(dDetails._isMember)
                _depMemberMap.Add(dDetails._memberID, dDetails);
            else
                _depMemberMap.Add(dDetails._dependantID, dDetails);
        }

        public DependantMemberDetails[] GetDependantMemberDetail()
        {
            DependantMemberDetails[] list = new DependantMemberDetails[_depMemberMap.Values.Count];

            _depMemberMap.Values.CopyTo(list, 0);

            return list;
        }
        public void ClearBillSumList()
        {
            _billSumMap.Clear();
        }
        public void AddBillSummary(BillSummaryDetails bSum)
        {

            _billSumMap.Add(bSum._billId, bSum);

        }

        public BillSummaryDetails[] GetBillSummary()
        {
            BillSummaryDetails[] list = new BillSummaryDetails[_billSumMap.Values.Count];

            _billSumMap.Values.CopyTo(list, 0);

            return list;
        }

        public void ClearBilledItem()
        {
            _billedItemsMap.Clear();
        }
        public void AddBilledItems(BilledItem iDetails)
        {

            _billedItemsMap.Add(iDetails._itemId, iDetails);

        }

        public BilledItem[] GetBilledItems()
        {
            BilledItem[] list = new BilledItem[_billedItemsMap.Values.Count];

            _billedItemsMap.Values.CopyTo(list, 0);

            return list;
        }

        public void ClearItemGroup()
        {
            _ItemGroupMap.Clear();
        }
        public void AddItemGroup(ItemGroup igroup)
        {

            _ItemGroupMap.Add(igroup._groupId, igroup);

        }

        public ItemGroup[] GetItemGroups()
        {
            ItemGroup[] list = new ItemGroup[_ItemGroupMap.Values.Count];

            _ItemGroupMap.Values.CopyTo(list, 0);

            return list;
        }
    }
}
