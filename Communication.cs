using System;
using System.Collections.Generic;
using System.Text;
using BillingManager;

namespace PDACommunications
{
    public class BillingBasicRequest : CommunicationObject
    {
        public short _requestID;
        public string _storeId;
        public string _billNumber;
        public string _computerName;
        public string _MemberId;
        public string _itmId;
        public BillActionType _action;
    }
    //public class BillToRequest : CommunicationObject
    //{
    //    public short _requestID;
    //    public string _MemberId;
    //}
    public class Configuration : CommunicationObject
    {
        public DateTime _currentDateTime;
        public short _storeId;
        
    }
    public class BillSummaryDetails : CommunicationObject
    {
        public string _billId;
        public string _billNumber;
        public string _billType;
        public DateTime _billDate;
        public string _memberId;
        public double _amount;
        public string _memberName;
        public string _storeCode;
        public string _storeName;
        public string _storeId;
        public string _status;
    }
    public class PendingBillDetails : CommunicationObject
    {
        public string _billId;
        public string _billNumber;
        public string _billType;
        public DateTime _billDate;
        public string _memberId;
        public string _memberName;
        public string _otNo;
        public string _ItemId;
        public string _ItemCode;
        public string _ItemName;
        public string _unitCode;
        public double _quantity;
        public string _personCode;
        public BillActionType _action;
    }
    public class BillingMenu : CommunicationObject
    {
        public string _menuName;
        public string _storeCode;
        public string _storeName;
        public string _storeId;
        public string _catId;
        public string _billPrefix;
        public bool _isHappyHour;
    }
    public class TableNumber : CommunicationObject
    {
        public string _tableId;
        public string _tableNo;
        public string _storeId;
        public override string ToString()
        {
            return _tableNo;
        }
    }
    public class Party : CommunicationObject
    {
        public string _partyId;
        public string _partyName;
        public override string ToString()
        {
            return _partyName;
        }
    }
    public class Steward : CommunicationObject
    {
        public string _stewardId;
        public string _stewardCode;
        public string _stewardName;
    }
    public class BillCancel : CommunicationObject
    {
        public int _billId;
        public string _billIds;
        public bool IsBillCancelled;
        public string _reason;
        public DateTime _cancelledDate;
        public BillActionType _action;
    }
    public class PayBillObject : CommunicationObject
    {
        public int _billId;
        public String _paymentMode;
        public int _memberId;
        public String _bankName;
        public int _creditCardType;
        public int _edcr;
        public String _creditCardNumber;
        public BillActionType _action;
        public double _amount;
        public int _userId;
    }
    public class Bill : CommunicationObject
    {
         public int _ID;
         public int _billId;
         public string _tableId;
         public string _otNo;
         public string _billNumber;
         public string _billType;
         public DateTime _billDate;
         public string _referenceNumber;
         public int _memberId;
         public int _stewardId;
         public int _storeId;
         public string _contractorsId;
         public Boolean _isCashBill;
         public Boolean _isBillCancelled;
         public DateTime _billCalncelDate;
         public string _reason;
         public double _amount;
         public int _createdBy;
         public DateTime _createdDate;
         public int _modifiedBy;
         public DateTime _modifiedDate;
         public Boolean _isFinalized;
         public string _billMode;
         public string _stewardCode;
         public string _stewardName;
         public int _userId;
         public string _userName;
         public int  _orderby;
         public string _printText;
         public string _printerName;
         
    }
    public class BillingItemTax : CommunicationObject
    {
        public int _browId;
        public int _btaxId;
        public int _billId;
        public int _itemId;
        public int _taxId;
        public string _taxType;
        public double _tax;
        public double _amount;
    }
    public class BillDetails : CommunicationObject
    {
          public int  _ID;
          public int _rwno;
          public int _billId;
          public int _itemId;
          public string _otNo;
          public string _baseUnitId;
          public string _salesUnitId;
          public double _quantity;
          public double _amount;
          public double _openingBalance;
          public Boolean _isHappyhr;
          public double _rate;
          public BillingItemTax[] _bTax;
          public int _itemSerialNo;
          public string _itemCode;
          public string _itemName;
          public string _baseUnit;
          public int _ItemStoreID;
    }
    
    public class ItemTax : CommunicationObject
    {
        public int _itemId;
        public int _taxId;
        public string _taxType;
        public double _tax;
        public string _taxFlag;
    }
    public class BillingItemDetails : CommunicationObject
    {
        public int _itemId;
        public string _itemCode;
        public string _itemName;
        public string _itemGroupId;
        public string _itemGroup;
        public string _itemCategoryId;
        public string _itemCategory;
        public bool _isStockCheckRequire;
        public double _availableQuantity;
        public string _baseUnitId;
        public string _salesUnitId;
        public string _baseUnit;
        public string _salesUnit;
        public double _happyhrRate;
        public double _rate;
        public ItemTax[] _itmTax;
        public string _sAcc;
        public string _itemSerialNo;
        public DateTime _dtAsOn;
        public int _storeId;
        public String _memberType;
    }
    public class PartyDetails : CommunicationObject
    {
        public int _partyId;
        public string _PartyName;
    }
    public class DeletedItemDetails : CommunicationObject
    {
        public int _billId;
        public int _itemId;
        public int _itemSerialNo;
    }
    public class BillingMemberDetails : CommunicationObject
    {
        public String _memberID;
        public String _accountNumber;
        public String _memberName;
        public String _clubID;
        public String _clubName;
        public String _cardPrefix;
        public bool _isGuest;
        public bool _isActive;
        public double _balAmt;
        public int _itemSrNo;
        public byte[] _mPhoto;
        public DateTime _curDateTime;
        public string _dependantID;
        public string _dependantName;
        public string _relationship;
        public string _storeId;
        public int _userId;
        public string _reason;
        public bool _IsSmartCard;
        public bool _IsRoomCard;
        public bool _IsCashCard;
        public int _roomBookID;
        public String _cardSerialNo;
        public double _MemberCreditLimit;
    }
    public class DependantMemberDetails : CommunicationObject
    {
        public String _dependantID;
        public string _dependantName;
        public string _realtion;
        public string _dob;
        public String _memberID;
        public String _accountNumber;
        public String _memberName;
        public String _category;
        public String _phoneNo;
        public String _mobileNo;
        public String _address;
        public String _email;
        public byte[] _dPhoto;
        public byte[] _mPhoto;
        public bool _isMember;
    }

    public class BillingBasicStatusMessagae : CommunicationObject
    {
        public bool _isSuccess;
        public String _message;
        public String _printText;
    }
    public class BillToStatusMessagae : CommunicationObject
    {
        public bool _isSuccess;
        public String _message;
        public String _printText;
    }
    public class BillingLoginResponse : CommunicationObject
    {
        public bool _isSuccess;
        public String _message;
        public String _personID;
        public String _userName;
        public int _userId;
        public String _posId;
        public BillingPermissions[] _permission;
    }
    public class BillingPermissions : CommunicationObject
    {
        public String _type;
        public bool _add;
        public bool _edit;
        public bool _delete;
        public bool _view;
    }
    public class BillingLoginRequest : CommunicationObject
    {
        public String _loginName;
        public String _password;
    }

    public class DependantMemberList : CommunicationObject
    {
        public DependantMemberDetails[] _depList;
    }

    public class BillingItemList : CommunicationObject
    {
        public BillingItemDetails[] _itemList;
    }
    //PartyDetails
    public class PartyList : CommunicationObject
    {
        public Party[] _partyList;
    }
    public class BillingTableList : CommunicationObject
    {
        public TableNumber[] _tables;
    }
    public class StewardList : CommunicationObject
    {
        public Steward[] _stewards;
    }
    public class MenuList : CommunicationObject
    {
        public BillingMenu[] _menu;
    }
     public class TextPrintBill : CommunicationObject
    {
        public string _printTextSnehaBar;
    }
    public class BillDetailList : CommunicationObject
    {
        public Bill _ID;
        public Bill _bill;
        public BillDetails[] _billList;
        public BillingMemberDetails _memb;
        public DeletedItemDetails[] _delItems;
        public BillActionType _action;
        public String _computerName;
        public KOTBillPrint[] _PrintTables;
        public TextPrintBill[] _TxtPrintSnehaBar;
    }
    public class BillSummaryList : CommunicationObject
    {
        public BillSummaryDetails[] _billSumList;
        public String _storeId;
        public String _billNumber;
        public String _billType;
        public DateTime _fromDate;
        public DateTime _toDate;
        public string _memberID;
        public BillActionType _action;
        public String _KOTNumber;
        public int _TableId;
        public String _Status;
        //public String _status;

    }
    public class PendingBillList : CommunicationObject
    {
        public PendingBillDetails[] _pedbillList;
        public String _storeId;
        public String _billNumber;
        public String _accountNumber;
        public String _billType;
        public DateTime _fromDate;
        public DateTime _toDate;
        public String _personCode;
        public BillActionType _action;

    } 
    public class DeletedItemList : CommunicationObject
    {
        public DeletedItemDetails[] _delItems;

    }
    public class BilledItem : CommunicationObject
    {
        public String _itemId;
        public String _itemCode;
        public String _itemName;
    }
    public class ItemGroup : CommunicationObject
    {
        public String _groupId;
        public String _groupCode;
        public String _groupName;
    }
    
    public class BilledItemList : CommunicationObject
    {
        public BilledItem[] _bItems;

    }
    public class ItemGroupList : CommunicationObject
    {
        public ItemGroup[] _iGroups;

    }

    public class ReportTable : CommunicationObject
    {
        public System.Data.DataTable dtReport;
        public ItemSalesReport[] itmSales;
        public ItemwiseSalesReport[] itmwise;
        public SalesSummaryReport[] salesSum;
        public StoreStockReport[] stockSum;
        public String _memberId;
        public DateTime _fromDate;
        public DateTime _toDate;
        public String _itemId;
        public string _pos;
        public string _tomemberId;
        public String _itemGrpId;
        public String _locationId;
        public String _order;
        public String _rptName;
        public String _rptType;

    }
    public class ItemSalesReport : CommunicationObject
    {
        public String _billNo;
        public DateTime _billDate;
        public String _memberId;
        public String _accNo;
        public String _memberName;
        public String _itemNo;
        public String _itemName;
        public String _unitId;
        public String _unit;
        public double _qty;
        public double _rate;
        public double _total;
        public String _otNo;
        public String _bearerid;
        public String _counter;
        public String _pos;
    }
    public class ItemwiseSalesReport : CommunicationObject
    {
        public String _billNo;
        public DateTime _billDate;
        public String _memberId;
        public String _accNo;
        public String _memberName;
        public String _itemNo;
        public String _itemName;
        public String _unitId;
        public String _unit;
        public double _qty;
        public double _rate;
        public double _total;
        public String _otNo;
        public String _bearerid;
        public String _counter;
        
    }
    public class SalesSummaryReport : CommunicationObject
    {
        
        public String _itemNo;
        public String _itemName;
        public double _qty;
        public double _rate; 
        public double _amount;
         
    }
    public class StoreStockReport : CommunicationObject
    {
        public String _itemId;
        public String _itemNo;
        public String _itemName;
        public String _grpCode;
        public String _grpName;
        public String _unitName;
        public double _opbal;
        public double _opbalbtl;
        public double _clbalbtl;
        public double _recqty;
        public double _issqty;
        public double _adjqty;
        public double _rate;
        public double _fval;
        public DateTime _trndate;
        public String _refno;
    }
    public class KOTBillPrintTableList : CommunicationObject
    {
        public KOTBillPrint[] _PrintTables;
    }
    public class KOTBillPrint : CommunicationObject
    {
        public String _TableNumber;
        public String _KOTNo;
        public String _StoreCode;
        public String _Counter;
        public String _StewardName;
        public String _MemberName;
        public String _AccountNumber;
        public String _Quantity;
        public String _ItemCode;
        public String _ItemName;
        public int _MemberID;
        public int _PersonID;
        public String _TableID;
        public string _computerName;
        public BillActionType _action;
        public int _StoreID;
        public int _GroupID;
        public int _ID;
        public double _QTY;
       // public String _billNo;
        //public String _Quantity;

    }
    public class KOTBillCancel : CommunicationObject
    {
        public int _ID;
        public double _Quantity;
        public double _Balance;
        public BillActionType _action;
        public double _NetAmt;
        public bool _isView;
    }
    public class ComboHead : CommunicationObject
    {
        public Combo[] _combo;
        public BillActionType _action;
    }
    public class Combo : CommunicationObject
    {
        public int _ID;
        public String _Value;
        public override string ToString()
        {
            return _Value;
        }
        
    }
    
}
