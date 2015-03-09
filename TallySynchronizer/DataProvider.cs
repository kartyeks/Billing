using System;
using System.Collections.Generic;
using System.Text;
using IRCAKernel;
using TallySynchronizer;


namespace Tally
{
    public class DataProvider
    {
        private static DataProvider _instance;

        private static IRCASQLConnection _dbConnection;

        public static DataProvider GetDataProvider(String DBConnectionString)
        {
            if(_instance == null)                
            {
                _instance = new DataProvider(DBConnectionString);
            }

            return _instance;
        }

        private DataProvider(String DBConnectionString)
        {
            _dbConnection = new IRCASQLConnection(DBConnectionString, IRCASQLConnection.SQLConnectionType.MSSQL);
        }

        public TallyEntryIdentifier[] GetRecordsForDuplicateCheck(String StartDate, String EndDate)
        {

            String Qry = " SELECT"
                                             + " 	DISTINCT "
                                             + " 	TallyVoucherID,"
                                             + " 	TallyVoucherNumber,"
                                             + " 	VoucherType,"
                                             + " 	TransactionDate"
                                             + " FROM"
                                             + " 	Tally_Entry"
                                             + " WHERE"
                                             + "    TallyVoucherID <> 0";

            if (StartDate != "" && EndDate != "")
            {
                Qry += "	AND CONVERT(DATETIME,TransactionDate,103) between CONVERT(DATETIME,'{0}',103) AND CONVERT(DATETIME,'{1}',103) ";
            }
            else
            {
                Qry += " 	AND IsDuplicateChecked = 0";
            }

            String SQL = string.Format(Qry, StartDate, EndDate);

            Object[] results = _dbConnection.getResultSet(typeof(TallyEntryIdentifier), SQL).ToArray();

            TallyEntryIdentifier[] entries = new TallyEntryIdentifier[results.Length];

            Array.Copy(results, entries, entries.Length);

            return entries; 
        }

        public void UpdateDuplicateRecord(String VoucherID, String VoucherNumber)
        {
            const String Qry = " UPDATE"
                         + " 	Tally_Entry"
                         + " SET"
                         + " 	TallyVoucherID = {0},"
                         + " 	IsDuplicateChecked = 1"
                         + " WHERE"
                         + " 	TallyVoucherNumber = '{1}'";

            String SQL = string.Format(Qry, VoucherID, VoucherNumber);

            _dbConnection.execute(SQL);
        }

        public Transaction_Payments GetTransaction_Payments(int ID)
        {
            return (Transaction_Payments)_dbConnection.getResultObject(typeof(Transaction_Payments), ID);
        }

        public Transaction_Charges GetTransaction_Charges(int ID)
        {
            return (Transaction_Charges)_dbConnection.getResultObject(typeof(Transaction_Charges), ID);
        }

        public Transaction_Purchase GetTransaction_Purchase(int ID)
        {
            return (Transaction_Purchase)_dbConnection.getResultObject(typeof(Transaction_Purchase), ID);
        }

        public Transaction_CreditTransfers GetTransaction_CreditTransfers(int ID)
        {
            return (Transaction_CreditTransfers)_dbConnection.getResultObject(typeof(Transaction_CreditTransfers), ID);
        }

        public Tally_Entry[] GetAllPendingTransaction(int MinID)
        {
            ReInitializeMaps();

            const String query =    " SELECT top 100 "
                                    + " 	A.ID,"
                                    + " 	A.TransactionType,"
                                    + " 	A.TransactionID,"
                                    + " 	A.TransactionVersion,"
                                    + " 	IsNull("
                                    + " 	("
                                    + " 		case when TallyVoucherID > 0 then TallyVoucherID"
                                    + " 		else "
                                    + " 			("
                                    + " 				Select "
                                    + " 					min(TallyVoucherID) "
                                    + " 				from "
                                    + " 					Tally_Entry C"
                                    + " 				Where"
                                    + " 					C.TransactionID = A.TransactionID and "
                                    + " 					C.TransactionType = A.TransactionType and"
                                    + " 					C.TallyVoucherID > 0"
                                    + " 			) "
                                    + " 		end"
                                    + " 	), 0) TallyVoucherID,"
                                    + " 	A.TransactionDate,"
                                    + " 	A.ExportedDate,"
                                    + " 	A.Narration,"
                                    + " 	A.VoucherType,"
                                    + " 	A.EntryType,"
                                    + " 	A.TallyVoucherNumber,"
                                    + " 	A.IsDuplicateChecked,"
                                    + " 	A.ErrorMessage,"
                                    + " 	convert(bit,IsNull(B.IsExported, 1)) IsPreviousVersionExported,    "
                                    + " 	IsNull(B.TransactionDate, A.TransactionDate) OriginalTransactionDate"
                                    + " FROM "
                                    + " 	Tally_Entry A"
                                    + " LEFT JOIN"
                                    + " ("
                                    + " 	Select "
                                    + " 		TransactionType, TransactionID, TransactionVersion, (case when TallyVoucherID>0 then 1 else 0 end) IsExported, TransactionDate"
                                    + " 	from "
                                    + " 		Tally_Entry "
                                    + " ) B"
                                    + " ON"
                                    + " 	A.TransactionType = B.TransactionType"
                                    + " 	and A.TransactionID = B.TransactionID"
                                    + " 	and A.TransactionVersion = (B.TransactionVersion + 1)"
                                    + " WHERE"
                                    + " 	A.TallyVoucherID = 0"
                                    + "     and A.ID > {0}" 
                                    + " ORDER BY ID ASC";

            String SQL = String.Format(query, MinID);

            Object[] result = _dbConnection.getResultSet(typeof(Tally_Entry), SQL).ToArray();

            Tally_Entry[] entries = new Tally_Entry[result.Length];

            Array.Copy(result, entries, entries.Length);

            return entries;
        }

        public void UpdateEntryDetails(Tally_Entry TallyEntry)
        {
            const String query = "SELECT "
                                + "     ID,"
                                + "    TallyEntryID,"
                                + "    CreditDebit,"
                                + "    LedgerID,"
                                + "    Amount"
                                + " FROM "
                                + "     Tally_EntryDetails "
                                + " WHERE "
                                + "     TallyEntryID = {0} "
                                + " ORDER BY "
                                + "     CreditDebit";

            String SQL = string.Format(query, TallyEntry.ID);

            Object[] result = _dbConnection.getResultSet(typeof(Tally_EntryDetails), SQL).ToArray();

            Tally_EntryDetails[] entries = new Tally_EntryDetails[result.Length];

            Array.Copy(result, entries, entries.Length);

            TallyEntry.SetEntryDetails(entries);
        }

        public void Update(Tally_Entry TallyEntry)
        {
            if (TallyEntry.TallyVoucherID > 0 && TallyEntry.ExportedDate < DateTime.Today)
            {
                TallyExceptionHandler.HandleMessage("Wrong ExportedDate:" + TallyEntry.ID);
            }

            _dbConnection.update(TallyEntry);
        }

        private static Dictionary<int, Tally_LedgerMaster> LedgerMasterStore = null;
        private static Dictionary<int, Tally_CMS_ChargeAccountMapping> ChargeAccountMappingStore = null;
        private static Dictionary<String, mChargeAccountCategory> AccountCategoryStore = null;

        private static void ReInitializeMaps()
        {
            LedgerMasterStore = null;
            ChargeAccountMappingStore = null;
            AccountCategoryStore = null;
        }

        internal Tally_LedgerMaster GetTally_LedgerMaster(int ID)
        {
            if (LedgerMasterStore == null)
            {
                List<Tally_LedgerMaster> DuplicateEntries = new List<Tally_LedgerMaster>();

                LedgerMasterStore = new Dictionary<int,Tally_LedgerMaster>();

                foreach (Object EntryObject in _dbConnection.getResultSet(typeof(Tally_LedgerMaster)))
                {
                    Tally_LedgerMaster MappingEntry = (Tally_LedgerMaster)EntryObject;

                    if (LedgerMasterStore.ContainsKey(MappingEntry.ID))
                    {
                        DuplicateEntries.Add(MappingEntry);
                    }
                    else
                    {
                        LedgerMasterStore.Add(MappingEntry.ID, MappingEntry);
                    }
                }

                foreach (Tally_LedgerMaster DuplicateEntry in DuplicateEntries)
                {
                    LedgerMasterStore.Remove(DuplicateEntry.ID);
                    TallyExceptionHandler.HandleMessage("Duplicate Ledger [" + DuplicateEntry.ID + "]<" + DuplicateEntry.LedgerName + "> ==> " + DuplicateEntry.ExportedName);
                }
            }

            return LedgerMasterStore.ContainsKey(ID) ? LedgerMasterStore[ID] : null;
        }

        public Tally_CMS_ChargeAccountMapping GetAcMapping(int LedgerID)
        {
            if (ChargeAccountMappingStore == null)
            {
                const String Qry = " SELECT  "
                                    + "     ID,"
                                    + "     CMS_Ac_Type,"
                                    + "     CMS_Ac_ID,"
                                    + "     LedgerID"
                                    + " FROM "
                                    + "    Tally_CMS_ChargeAccountMapping ";

                ChargeAccountMappingStore = new Dictionary<int, Tally_CMS_ChargeAccountMapping>();

                List<Tally_CMS_ChargeAccountMapping> DuplicateEntries = new List<Tally_CMS_ChargeAccountMapping>();

                foreach (Object EntryObject in _dbConnection.getResultSet(typeof(Tally_CMS_ChargeAccountMapping), Qry))
                {
                    Tally_CMS_ChargeAccountMapping MappingEntry = (Tally_CMS_ChargeAccountMapping)EntryObject;

                    if (ChargeAccountMappingStore.ContainsKey(MappingEntry.LedgerID))
                    {
                        DuplicateEntries.Add(MappingEntry);
                    }
                    else
                    {
                        ChargeAccountMappingStore.Add(MappingEntry.LedgerID, MappingEntry);
                    }
                }

                foreach (Tally_CMS_ChargeAccountMapping DuplicateEntry in DuplicateEntries)
                {
                    ChargeAccountMappingStore.Remove(DuplicateEntry.ID);
                    TallyExceptionHandler.HandleMessage("Duplicate ChargeAccMap [" + DuplicateEntry.LedgerID + "]<" + DuplicateEntry.CMS_Ac_Type + "> ==> " + DuplicateEntry.CMS_Ac_ID);
                }
            }
                
            return ChargeAccountMappingStore.ContainsKey(LedgerID) ? ChargeAccountMappingStore[LedgerID] : null;
        }

        public mChargeAccountCategory GetmChargeAccountCategory(String ID)
        {
            if (AccountCategoryStore == null)
            {
                const String Qry = " SELECT "
                                     + " 	ChargeAcCategoryID,"
                                     + " 	ChargeAcCategory,"
                                     + " 	Name,"
                                     + " 	AcHeadsCode,"
                                     + " 	CreatedBy,"
                                     + " 	CreatedDate,"
                                     + " 	ModifiedBy,"
                                     + " 	ModifiedDate,"
                                     + " 	RecordVersion,"
                                     + " 	ProductID,"
                                     + " 	RecordActionTypeAED,"
                                     + " 	GlobalID,"
                                     + " 	IsServiceTaxApplicable,"
                                     + " 	IsReceiptApplicable,"
                                     + " 	IsSystemDefined,"
                                     + " 	AccCode"
                                     + " FROM "
                                     + "    mChargeAccountCategory ";

                String SQL = string.Format(Qry, ID);

                AccountCategoryStore = new Dictionary<string, mChargeAccountCategory>();

                List<mChargeAccountCategory> DuplicateEntries = new List<mChargeAccountCategory>();

                foreach (Object EntryObject in _dbConnection.getResultSet(typeof(mChargeAccountCategory), SQL))
                {
                    mChargeAccountCategory MappingEntry = (mChargeAccountCategory)EntryObject;

                    if (AccountCategoryStore.ContainsKey(MappingEntry.ChargeAcCategoryID))
                    {
                        DuplicateEntries.Add(MappingEntry);
                    }
                    else
                    {
                        AccountCategoryStore.Add(MappingEntry.ChargeAcCategoryID, MappingEntry);
                    }
                }

                foreach (mChargeAccountCategory DuplicateEntry in DuplicateEntries)
                {
                    AccountCategoryStore.Remove(DuplicateEntry.ChargeAcCategoryID);
                    TallyExceptionHandler.HandleMessage("Duplicate ChargeAccCategory [" + DuplicateEntry.AccCode + "]<" + DuplicateEntry.ChargeAcCategory + "> ==> " + DuplicateEntry.AcHeadsCode);
                }
            }
            
            return AccountCategoryStore.ContainsKey(ID) ? AccountCategoryStore[ID] : null;
        }
    }

    #region DTOS

    public class Tally_Entry
    {
        public int ID;
        public String TransactionType;
        public int TransactionID;
        public int TransactionVersion;
        public int TallyVoucherID;
        public DateTime TransactionDate;
        public DateTime ExportedDate;
        public String Narration;
        public String VoucherType;
        public String EntryType;
        public String TallyVoucherNumber;
        public bool IsDuplicateChecked;
        public String ErrorMessage;

        [NonSerialized] public bool IsPreviousVersionExported;
        [NonSerialized] public DateTime OriginalDate;

        private Tally_EntryDetails[] _EntryDetails = null;

        private Tally_Entry _PreviousVersionEntry = null;

        public bool CheckPreviousVersionEntry(Tally_Entry value)
        {
            if (null == _PreviousVersionEntry && 
                this.TransactionType == value.TransactionType && 
                this.TransactionID == value.TransactionID && 
                this.TransactionVersion == (value.TransactionVersion + 1))
            {
                _PreviousVersionEntry = value;
                IsPreviousVersionExported = (_PreviousVersionEntry.TallyVoucherID != 0);

                return true;
            }

            return false;
        }

        public void SetEntryDetails(Tally_EntryDetails[] EntryDetails)
        {
            _EntryDetails = EntryDetails;
        }

        public Tally_EntryDetails[] GetEntryDetails()
        {
            return _EntryDetails;
        }
    }

    public class Tally_EntryDetails
    {
        public int ID;
        public int TallyEntryID;
        public String CreditDebit;
        public int LedgerID;
        public double Amount;
    }

    public class TallyEntryIdentifier
    {
        public int TallyVoucherID;
        public String TallyVoucherNumber;
        public String TallyVocuerType;
        public DateTime TransactionDate;
    }

    public class Transaction_Payments
    {
        public int ID;
        public String ClubAccountID;
        public String Towards;
        public String ToWardsType;
        public Double Amount;
        public DateTime PaymentDate;
        public String PaymentType;
        public String PaymentMode;
        public String Status;
        public String Remarks;
        public String PaymentRef;
        public String CreatedBy;
        public DateTime CreatedDate;
        public String ModifiedBy;
        public DateTime ModifiedDate;
        public int VersionNo;
        public String ReceiptNo;
        public String PayeeRef;
        public String LocationRef;
    }

    public class Transaction_Charges
    {
        public int ID;
        public String MemberID;
        public String ChargeAcID;
        public Double Amount;
        public DateTime ChargeDateTime;
        public String ChargeType;
        public String Status;
        public String Remarks;
        public String ChargeRef;
        public String CreatedBy;
        public DateTime CreatedDate;
        public String ModifiedBy;
        public DateTime ModifiedDate;
        public int VersionNo;
        public String ReceiptNo;
    }

    public class Transaction_Purchase
    {
        public int ID;
        public String SupplierID;
        public DateTime PurchaseDate;
        public Double Amount;
        public Double Tax;
        public String PurchaseType;
        public String Status;
        public String Remarks;
        public String PurchaseRef;
        public String CreatedBy;
        public DateTime CreatedDateTime;
        public String ModifiedBy;
        public DateTime ModifiedDateTime;
        public String ReceiptNo;
        public int VersionNo;
    }

    public class Transaction_CreditTransfers
    {
        public int ID;
        public String FromType;
        public String FromAc;
        public String ToType;
        public String ToAc;
        public Double Amount;
        public DateTime TransferDateTime;
        public String TransferType;
        public String Status;
        public String Remarks;
        public String TransferRef;
        public String CreatedBy;
        public DateTime CreatedDate;
        public String ModifiedBy;
        public DateTime ModifiedDate;
        public int VersionNo;
        public String ReceiptNo;
    }

    public class StringResult
    {
        public String Result;
    }

    public class IntResult
    {
        public int Result;
    }

    public class DateResult
    {
        public DateTime Result;
    }

    public class Tally_LedgerMaster
    {
        public int ID;
        public String LedgerName;
        public String ExportedName;
    }

    public class Tally_CMS_ChargeAccountMapping
    {
        public  int ID;
        public  String CMS_Ac_Type;
        public  String CMS_Ac_ID;
        public  int LedgerID;
    }

    public class mChargeAccountCategory
    {
        public String ChargeAcCategoryID;
        public String ChargeAcCategory;
        public String Name;
        public String AcHeadsCode;
        public String CreatedBy;
        public DateTime CreatedDate;
        public String ModifiedBy;
        public DateTime ModifiedDate;
        public int RecordVersion;
        public String ProductID;
        public String RecordActionTypeAED;
        public Guid GlobalID;
        public bool IsServiceTaxApplicable;
        public bool IsReceiptApplicable;
        public bool IsSystemDefined;
        public String AccCode;
    }

    #endregion
}
