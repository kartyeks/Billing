using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManager
{
    public class BillDefs
    {
        public static readonly String LoadError = "Error On Loading Member Details";
        public static readonly String MEMBER_VERIFIED = "Member verified";
        public static readonly String NO_FP = "Finger Print is not captured";

        public static readonly String PLACE_RIGHTFINGER = "Place right finger 4 times";
        public static readonly String PLACE_LEFTFINGER = "Place left finger 4 times";
        public static readonly String RECAPTURE = "Finger print catpure is finished\nDo you want to capture again";

        public static readonly String ENROLL_ERROR = "Error on enroll Member";
        public static readonly String MEMBER_INACTIVE = "Member is Inactive";
        public static readonly String MEMBER_NOTENROLLED = "Member is not enrolled";
        public static readonly String MEMBER_NOTSAVED = "Member is not saved, please save the Member Details";
        public static readonly String NO_MEMBER = "Please select the Member";

        public static readonly String MEMBER_SAVE_ERROR = "Error on saving Member Details";
        public static readonly String MEMBER_SAVE_SUCESS = "Member Details saved sucessfully";


        public static readonly String ERROR = "Alert";
        public static readonly String MSG = "Message";
        public static readonly String WARNING = "Warning";
                
        public static readonly String URLRegKey = "BILLURL";
        public static readonly String TIMEOUT = "TIMEOUT";

        //Login Messages
        public static readonly String NO_NAME = "Please enter login name";
        public static readonly String NO_PASSWORD = "Please enter password";

        //Logging Messages
        public static readonly String ENTRY_ERROR = "Error on entry log";
        public static readonly String LUNCH_ERROR = "Error on lunch log";

        public static readonly int MaxTimeOut = 60000;

        //Setting Messages
        public static readonly String NO_URL = "Please enter server URL";
        public static readonly String NO_TIMEOUT = "Please enter request Timeout";
        public static readonly String TIMEOUT_LIMIT = "Timeout cannot be greater than " + MaxTimeOut.ToString();
        
        //
        public static readonly String EXIT = "Exit";
        public static readonly String EXIT_CONFIRM = "Do you want to exit?";
        public static readonly String DELETE_CONFIRM = "Do you want to Delete ?";

        //Caddie entry
        public static readonly String NO_MEMBERNAME = "Please enter Member Name";
        public static readonly String NO_ACCOUNTNUMBER = "Please enter AccountNumber";
        public static readonly String NO_SMARTCARDNO = "Please enter Smart Card No.";
        public static readonly String NO_CLUBNAME = "Please select Affiliated Club";
        public static readonly String NO_REFERENCE = "Please enter Reference No.";
        public static readonly String NO_AMOUNT = "Please enter Amount";
        public static readonly String CODE_DUPLICATE = "Caddie code cannot be duplicated";
        public static readonly String NO_RowSelected = "Please Select a row";
        public static readonly String NO_RowSelectedForDelete = "Please Select a row to Delete";
        

        public static readonly String FILTER_LIKE = "Like";
        public static readonly String FILTER_CONTAINS = "Contains";

     
    }

    public enum BillRequestID
    {
        ItemListRequest = 1,
        MemberRequest=2,
        StewardList = 3,
        TableList = 4,
        MenuList = 5,
        DependantList = 6,
        BillNumber =7,
        BilledItem = 8,
        ItemGroup = 9,
        GodownList = 10,
        ItemListRequestCat = 11,
        BillTo = 12,
        KOTID = 13,
        CreditCardType =14,
        EdcrMaster = 15
    };

    public enum BillActionType
    {
        View = 1,
        Save=2,
        Update = 3, 
        Finalize=4,
        Success=5,
        Failure=6,
        NOCRLIMIT = 7,
        Modify = 8,
        Cancel=9,
        Print=10,
        KOTCancel = 11,
        Itemlist = 12,
        SaveVisitor=13
    };

}
