using System;
using System.Threading;
using IRCABrowserLocalService;
using Tally;
using IRCAKernel;

namespace TallySynchronizer
{
    public class Tally
    {
        private static readonly String DEFAULT_DATE = "DEFAULT";
        private static TallyConnection _tallyConnection;
        private StatusUpdater _StatusUpdater = null;
        private bool IsContra;

        private DataProvider _dataProvider;

        public Tally(String CompanyName, String TallyURL, String DBConnectionString, StatusUpdater StatusUpdater)
        {
            try
            {
                _tallyConnection = new TallyConnection(CompanyName, TallyURL);
                _dataProvider = DataProvider.GetDataProvider(DBConnectionString);
                _StatusUpdater = StatusUpdater;

                IsContra = false;

                IRCAAppSettings AppSetting =  IRCAAppSettings.getAppSettings(IRCAUtils.getAppSettingPathForExe(), IRCAUtils.getAppSettingsFileName());

                IsContra = String.Concat(AppSetting.getSettings("cancellation")).Equals("contra");

            }
            catch (Exception e)
            {
                TallyExceptionHandler.HandleException(e);
            }
        }

        public bool CheckDuplicates(String FromDate, String ToDate)
        {
            if (_dataProvider == null)
                return false;

            Mutex mutex = new Mutex(true, this.GetType().FullName + "DupCheck");

            if (!mutex.WaitOne(100))
            {
                return false;
            }

            Thread SyncThread = new Thread(
                new ThreadStart
                (
                    delegate()
                    {
                        try
                        {
                            TallyEntryIdentifier[] vouchers = _dataProvider.GetRecordsForDuplicateCheck(FromDate, ToDate);

                            foreach (TallyEntryIdentifier voucher in vouchers)
                            {
                                TallyVoucher voucherDetails = new TallyVoucher();

                                voucherDetails.VoucherID = voucher.TallyVoucherID.ToString();
                                voucherDetails.ReferenceNumber = voucher.TallyVoucherNumber;
                                voucherDetails.VoucherType = voucher.TallyVocuerType;
                                voucherDetails.TransactionDate = voucher.TransactionDate;
                                voucherDetails.OriginalTransactionDate = voucher.TransactionDate;

                                try
                                {
                                    VoucherDupDelResult dupDetails = _tallyConnection.ClearDuplicates(voucherDetails);

                                    TallyExceptionHandler.HandleMessage("Start check Voucher " + voucher.TallyVoucherNumber);

                                    if (dupDetails.IsSuccess)
                                    {
                                        if (dupDetails.DeletedDuplicates > 0)
                                        {
                                            _dataProvider.UpdateDuplicateRecord(dupDetails.RemainingEntryVoucherID, dupDetails.RemainingEntryVoucherNumber);

                                            TallyExceptionHandler.HandleMessage(dupDetails.DeletedDuplicates.ToString() + " Duplicate delete for " + voucher.TallyVoucherNumber);
                                        }
                                        else
                                        {
                                            _dataProvider.UpdateDuplicateRecord(voucher.TallyVoucherID.ToString(), voucher.TallyVoucherNumber);

                                            TallyExceptionHandler.HandleMessage("No Duplicate found for " + voucher.TallyVoucherNumber);
                                        }
                                    }
                                    else
                                    {
                                        throw (new TallyException(dupDetails.ErrorMessage, ""));
                                    }
                                }
                                catch (Exception e)
                                {
                                    TallyExceptionHandler.HandleException(new TallyException(e.Message, "Tally Voucher ID " + voucher.TallyVoucherID.ToString()));
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            TallyExceptionHandler.HandleException(e);
                        }
                    }
                ));

            SyncThread.IsBackground = true;
            SyncThread.Start();


            mutex.ReleaseMutex();

            return true;
        }

        public bool ManualSynchronize()
        {
            return ExportOffLineTransactions();
        }

        private bool ExportOffLineTransactions()
        {
            try
            {
                Mutex mutex = new Mutex(true, this.GetType().FullName + "TallySync");

                TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Waiting ");

                if (!mutex.WaitOne(100))
                {
                    TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " returning");

                    return false;
                }
                else
                {
                    DateTime ExportStartTime = DateTime.Now;
                    int ProcessedEntryCount = 1;
                    int MinEntryID = 0;

                    TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Entered ");
                    bool ContinueProcessing = true;

                    _StatusUpdater.SetMessage("Starting Synchronization...");

                    while (ContinueProcessing)
                    {
                        TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + ": Retrieving Pending Transactions ");
                        Tally_Entry[] PendingEntries = _dataProvider.GetAllPendingTransaction(MinEntryID);
                        TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + ": Retrieved " + PendingEntries.Length + " Pending Transactions ");

                        if (PendingEntries.Length == 0)
                        {
                            break;
                        }

                        TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + ": Retrieving Entry Details ");
                        for (int i = 0; i < PendingEntries.Length; i++)
                        {
                            _dataProvider.UpdateEntryDetails(PendingEntries[i]);
                        }
                        TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + ": Retrieved Entry Details ");

                        DateTime ProcessStartTime = DateTime.Now;

                        int LastUpdatedPendingEntry = -1;
                        for (int i = 0; i < PendingEntries.Length; i++)
                        {
                            try
                            {
                                MinEntryID = PendingEntries[i].ID;

                                Tally_EntryDetails[] tallyEntryDetails = PendingEntries[i].GetEntryDetails();

                                if (PendingEntries[i].EntryType == null || PendingEntries[i].EntryType.Trim() == String.Empty)
                                {
                                    TallyExceptionHandler.HandleMessage("<Error>Entry Type is missing for Tally Entry ->" + PendingEntries[i].ID + ". Entry Skipped.");
                                    PendingEntries[i].TallyVoucherID = 0;
                                    PendingEntries[i].ErrorMessage = "Entry Type Missing";
                                    continue;
                                }
                                else if (!(PendingEntries[i].EntryType == SyncType.NEW.ToString()))
                                {
                                    if (!PendingEntries[i].IsPreviousVersionExported)
                                    {
                                        PendingEntries[i].TallyVoucherID = 0;
                                        continue;
                                    }
                                }

                                try
                                {
                                    TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Processing Entry " + PendingEntries[i].ID.ToString());

                                    if (!UpdateTally(PendingEntries[i], tallyEntryDetails, (SyncType)Enum.Parse(typeof(SyncType), PendingEntries[i].EntryType, false)))
                                    {
                                        PendingEntries[i].TallyVoucherID = 0;
                                        TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Released ");
                                    }
                                    else
                                    {
                                        LastUpdatedPendingEntry = i;

                                        // Update the previous entry status in case two versions of the entry 
                                        // are being updated in this batch
                                        for (int j = i + 1; j < PendingEntries.Length; j++)
                                        {
                                            if (PendingEntries[j].CheckPreviousVersionEntry(PendingEntries[i]))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    TallyExceptionHandler.HandleException(e);

                                    ContinueProcessing = false;

                                    break;
                                }

                                ProcessedEntryCount++;
                                double ExportTime = (DateTime.Now - ExportStartTime).TotalSeconds;
                                double ProcessingTime = (DateTime.Now - ProcessStartTime).TotalSeconds;

                                if (null != _StatusUpdater && i > 0)
                                {
                                    String ProcessingSpeed = (i > ProcessingTime ? Math.Round(i / ProcessingTime, 2) + " Entries/Sec" : Math.Round(ProcessingTime / i, 2) + " Secs/Entry");

                                    _StatusUpdater.SetMessage("Processed " + ProcessedEntryCount + " Entries in " + Math.Round(ExportTime, 0) + " secs.  Processing Entries @ " + ProcessingSpeed);
                                }
                            }
                            catch (Exception e)
                            {
                                TallyExceptionHandler.HandleException(e);
                            }
                        }

                        TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Updating Tally Table ");
                        for (int i = 0; i <= LastUpdatedPendingEntry; i++)
                        {
                            try
                            {
                                _dataProvider.Update(PendingEntries[i]);
                            }
                            catch (Exception e)
                            {
                                TallyExceptionHandler.HandleException(e);
                            }
                        }
                        TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Updated Tally Table ");

                        if (ContinueProcessing)
                        {
                            _StatusUpdater.SetMessage("Synchronization Cycle Finished...");
                        }
                    }


                    mutex.ReleaseMutex();

                    TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Released ");

                    return true;
                }
            }
            catch (Exception e)
            {
                TallyExceptionHandler.HandleException(e);
                TallyExceptionHandler.HandleMessage("Thread " + this.GetHashCode() + " Released ");
                Mutex mutex = new Mutex(true, this.GetType().FullName + "TallySync");
                mutex.ReleaseMutex();
            }

            return false;
        }

        public void SynchronzieOffLineTransaction()
        {
            if (_dataProvider == null)
                return;

            Thread SyncThread = new Thread(
                new ThreadStart
                (
                    delegate()
                    {
                        try
                        {
                            ExportOffLineTransactions();
                        }
                        catch (Exception e)
                        {
                            TallyExceptionHandler.HandleException(e);
                        }
                    }
                ));

            SyncThread.IsBackground = true;
            SyncThread.Start();
        }

        public void SynchronzieTransaction()
        {
            SynchronzieOffLineTransaction();
        }

        private bool UpdateTally(Tally_Entry TallyEntry, Tally_EntryDetails[] TallyEntryDetails, SyncType Type)
        {
            return UpdateTally(TallyEntry, TallyEntryDetails, Type, 1);
        }

        private bool UpdateTally(Tally_Entry TallyEntry, Tally_EntryDetails[] TallyEntryDetails, SyncType Type, short RetryCount)
        {
            TallyVoucher voucher = new TallyVoucher();

            voucher.TransactionDate = TallyEntry.TransactionDate;
            voucher.OriginalTransactionDate = TallyEntry.OriginalDate;

            voucher.Narration = TallyEntry.Narration;
            voucher.VoucherType = TallyEntry.VoucherType;

            if (Type == SyncType.CAN || Type == SyncType.MOD)
            {
                if (!IsContra)
                {
                    voucher.OriginalTransactionDate = TallyEntry.OriginalDate;
                    voucher.TransactionDate = TallyEntry.TransactionDate;

                    voucher.VoucherID = TallyEntry.TallyVoucherID.ToString();

                    if (!TallyEntry.IsPreviousVersionExported)
                    {
                        return true;
                    }
                }
                else
                {
                    voucher.Narration = TallyEntry.Narration + " Contra for " + TallyEntry.TransactionID.ToString() + TallyEntry.TransactionType;
                }
            }

            if (IsContra && Type == SyncType.CAN)
            {
                voucher.ReferenceNumber = TallyEntry.TransactionID.ToString() + TallyEntry.TransactionType + "_CAN";
            }
            else
            {
                voucher.ReferenceNumber = TallyEntry.TransactionID.ToString() + TallyEntry.TransactionType;
            }

            bool NoLedgerEntry = true;

            foreach (Tally_EntryDetails details in TallyEntryDetails)
            {
                Tally_LedgerMaster ledger = _dataProvider.GetTally_LedgerMaster(details.LedgerID);

                if (ledger == null)
                {
                    String Message = "Ledger Mapping Not found for Entry Detail:" + details.ID;
                    String Data = "EntryID = " + TallyEntry.ID + "Ledger ID " + details.LedgerID;

                    TallyEntry.ErrorMessage = Message;

                    TallyException ex = new TallyException(Message, Data);
                    TallyExceptionHandler.HandleException(ex);

                    return true;
                }
                String LedgerName = ledger.ExportedName;

                if (details.Amount > 0)
                {
                    NoLedgerEntry = false;

                    if (IsContra && Type == SyncType.CAN)
                    {
                        if (details.CreditDebit.Trim().Equals(EntryType.DEBIT))
                        {
                            voucher.AddCreditEntry(LedgerName, details.Amount);
                        }
                        else
                        {
                            voucher.AddDebitEntry(LedgerName, details.Amount);
                        }
                    }
                    else
                    {
                        if (details.CreditDebit.Trim().Equals(EntryType.CREDIT))
                        {
                            voucher.AddCreditEntry(LedgerName, details.Amount);
                        }
                        else
                        {
                            voucher.AddDebitEntry(LedgerName, details.Amount);
                        }
                    }
                }
                else
                {
                    String Message = "Invalid Amount in Ledger Entry:" + details.ID;
                    String Data = "EntryID = " + TallyEntry.ID + "Ledger ID " + details.LedgerID + " Amount:" + details.Amount;

                    TallyEntry.ErrorMessage = Message;

                    TallyException ex = new TallyException(Message, Data);
                    TallyExceptionHandler.HandleException(ex);

                    return true;
                }
            }

            if (NoLedgerEntry)
            {
                return true;
            }

            try
            {
                if (Type == SyncType.CAN && (!IsContra))
                {
                    String voucherID = _tallyConnection.CancelVoucherEntry(voucher);

                    if (_tallyConnection.LastUpdateStatus == TallyConnection.UpdateStatus.ALTERED)
                    {
                        TallyEntry.TallyVoucherNumber = voucher.ReferenceNumber;
                        TallyEntry.TallyVoucherID = Convert.ToInt32(voucherID);
                        TallyEntry.ExportedDate = DateTime.Now;
                        TallyEntry.ErrorMessage = String.Empty;
                    }
                    else if (_tallyConnection.LastUpdateStatus == TallyConnection.UpdateStatus.CREATED)
                    {
                        TallyException ex = new TallyException("Error On Modification", String.Empty);
                        TallyExceptionHandler.HandleException(ex);

                        return false;
                    }
                    else if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.HOST_NOT_RUNNING
                        || _tallyConnection.ErrorNo == TallyConnection.ErrorStatus.COMPANY_NOTFOUND
                        )
                    {
                        TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                        throw ex;
                    }
                    else if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.WRONG_DATERANG)
                    {
                        TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                        TallyExceptionHandler.HandleException(ex);
                        return true;
                    }
                    else
                    {
                        TallyException ex = new TallyException("Unknown Error", String.Empty);
                        throw ex;
                    }
                }
                else if (Type == SyncType.MOD)
                {
                    String voucherID = _tallyConnection.AlterVoucherEntry(voucher);

                    if (_tallyConnection.LastUpdateStatus == TallyConnection.UpdateStatus.ALTERED)
                    {
                        TallyEntry.TallyVoucherNumber = voucher.ReferenceNumber;
                        TallyEntry.TallyVoucherID = Convert.ToInt32(voucherID);
                        TallyEntry.ExportedDate = DateTime.Now;
                        TallyEntry.ErrorMessage = String.Empty;
                    }
                    else
                    {
                        if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.HOST_NOT_RUNNING
                            || _tallyConnection.ErrorNo == TallyConnection.ErrorStatus.COMPANY_NOTFOUND
                            )
                        {
                            TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                            throw ex;
                        }
                        else if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.LEDGER_NOTFOUND ||
                                 _tallyConnection.ErrorNo == TallyConnection.ErrorStatus.LEDGER_NOTEXISTS
                                )
                        {
                            TallyException ex = new TallyException("Ledger Not Found", "\n\nRequest \n" + _tallyConnection.RequestXML
                                          + "\n\nResponse \n" + _tallyConnection.LastResponseString);

                            TallyExceptionHandler.HandleException(ex);

                            CreateLedgersForEntires(TallyEntryDetails);

                            if (RetryCount <= 2)
                            {
                                UpdateTally(TallyEntry, TallyEntryDetails, Type, ++RetryCount);
                            }
                            else
                            {
                                TallyException exc = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                                throw exc;
                            }

                            return true;
                        }
                        else if (_tallyConnection.LastUpdateStatus == TallyConnection.UpdateStatus.CREATED)
                        {
                            TallyException ex = new TallyException("Error On Modification", String.Empty);
                            TallyExceptionHandler.HandleException(ex);

                            return false;
                        }
                        else if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.WRONG_DATERANG)
                        {
                            TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                            TallyExceptionHandler.HandleException(ex);
                            return true;
                        }
                        else
                        {
                            TallyException ex = new TallyException("Unknown Error", String.Empty);
                            throw ex;
                        }
                    }
                }
                else if (Type == SyncType.NEW || (Type == SyncType.CAN && IsContra))
                {
                    String voucherID = _tallyConnection.CreateVoucherEntry(voucher);

                    if (voucherID != String.Empty)
                    {
                        TallyEntry.TallyVoucherNumber = voucher.ReferenceNumber;
                        TallyEntry.TallyVoucherID = Convert.ToInt32(voucherID);
                        TallyEntry.ExportedDate = DateTime.Now;
                        TallyEntry.ErrorMessage = String.Empty;
                    }
                    else
                    {
                        if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.LEDGER_NOTFOUND ||
                            _tallyConnection.ErrorNo == TallyConnection.ErrorStatus.LEDGER_NOTEXISTS
                           )
                        {
                            TallyException ex = new TallyException("Ledger Not Found", "\n\nRequest \n" + _tallyConnection.RequestXML
                                          + "\n\nResponse \n" + _tallyConnection.LastResponseString);

                            TallyExceptionHandler.HandleException(ex);

                            CreateLedgersForEntires(TallyEntryDetails);

                            if (RetryCount <= 2)
                            {
                                UpdateTally(TallyEntry, TallyEntryDetails, Type, ++RetryCount);
                            }

                            return true;
                        }
                        else if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.WRONG_DATERANG)
                        {
                            TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                            TallyExceptionHandler.HandleException(ex);
                            return true;
                        }
                        else if (_tallyConnection.ErrorNo == TallyConnection.ErrorStatus.HOST_NOT_RUNNING
                            || _tallyConnection.ErrorNo == TallyConnection.ErrorStatus.COMPANY_NOTFOUND
                            )
                        {
                            TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                            throw ex;
                        }
                        else
                        {
                            TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML, String.Empty);
                            throw ex;
                        }
                    }
                }
            }
            catch (TallyException te)
            {
                throw te;
            }
            catch (Exception e)
            {
                TallyEntry.TallyVoucherID = 0;
                TallyEntry.TallyVoucherNumber = "0";
                TallyEntry.ExportedDate = DateTime.Now;
                TallyEntry.ErrorMessage = e.Message;

                String Data = "\n\n EntryID = " + TallyEntry.ID
                              + "\n\n VoucherID = " + voucher.VoucherID
                              + "\n\n VoucherID = " + TallyEntry.TallyVoucherNumber
                              + "\n\n Request XML \n" + _tallyConnection.RequestXML
                              + "\n\n Response XML \n" + _tallyConnection.LastResponseString + "\n\n";
                TallyException ex = new TallyException(e.ToString(), Data);

                throw ex;
            }

            if (TallyEntry.TallyVoucherNumber != voucher.ReferenceNumber)
            {
                String Data = "\n\n EntryID = " + TallyEntry.ID
                              + "\n\n VoucherID = " + voucher.VoucherID
                              + "\n\n VoucherID = " + TallyEntry.TallyVoucherNumber
                              + "\n\n Request XML \n" + _tallyConnection.RequestXML
                              + "\n\n Response XML \n" + _tallyConnection.LastResponseString + "\n\n";

                TallyException ex = new TallyException("Voucher Number generation should be automatic", Data);

                TallyExceptionHandler.HandleException(ex);
            }

            return true;
        }

        private void CreateLedgersForEntires(Tally_EntryDetails[] TallyEntryDetails)
        {
            foreach (Tally_EntryDetails tmpDetails in TallyEntryDetails)
            {
                Tally_LedgerMaster ledger = _dataProvider.GetTally_LedgerMaster(tmpDetails.LedgerID);

                Tally_CMS_ChargeAccountMapping mapping = _dataProvider.GetAcMapping(tmpDetails.LedgerID);

                String GroupName;

                if (mapping.CMS_Ac_Type == AccountIDType.MEMBER)
                {
                    GroupName = TallyGroups.Sundry_Debtors;
                }
                else if (mapping.CMS_Ac_Type == AccountIDType.SUPPLIER_ACCOUNT)
                {
                    GroupName = TallyGroups.Sundry_Creditors;
                }
                else if (mapping.CMS_Ac_Type == AccountIDType.TAXACCOUNT)
                {
                    GroupName = TallyGroups.Current_Liabilities;
                }
                else if (mapping.CMS_Ac_Type == AccountIDType.PURCHASE_ACCOUNT)
                {
                    GroupName = TallyGroups.Purchase_Accounts;
                }
                else if (mapping.CMS_Ac_Type == AccountIDType.ROOM_CHARGE)
                {
                    GroupName = TallyGroups.Direct_Income;
                }
                else
                {
                    mChargeAccountCategory charge = _dataProvider.GetmChargeAccountCategory(mapping.CMS_Ac_ID);

                    if (charge.AccCode == ChargeAccountCode.BANK_ACCOUNT
                        || charge.AccCode == ChargeAccountCode.ECS_ACCOUNT)
                    {
                        GroupName = TallyGroups.Bank_Accounts;
                    }
                    else if (charge.AccCode == ChargeAccountCode.CARD_ACCOUNT)
                    {
                        GroupName = TallyGroups.Current_Assets;
                    }
                    else if (charge.AccCode == ChargeAccountCode.CASH_ACCOUNT)
                    {
                        GroupName = TallyGroups.Cash_In_Hand;
                    }
                    else if (charge.AccCode == ChargeAccountCode.PURCHASE)
                    {
                        GroupName = TallyGroups.Purchase_Accounts;
                    }
                    else if (charge.AccCode == ChargeAccountCode.TAX_ACCOUNT)
                    {
                        GroupName = TallyGroups.Current_Liabilities;
                    }
                    else
                    {
                        GroupName = TallyGroups.Direct_Income;
                    }
                }

                _tallyConnection.CreateLedgerAccount(new TallyLedger()
                {
                    LedgerName = ledger.LedgerName,
                    AliasName = ledger.ExportedName,
                    ParentGroupName = GroupName
                });

                if (_tallyConnection.LastUpdateStatus == TallyConnection.UpdateStatus.CREATED)
                {
                    TallyExceptionHandler.HandleMessage("Created Ledger:" + 
                        ledger.LedgerName + " Alias:" +
                        ledger.ExportedName + " Under Group:" +
                        GroupName);
                }
                else
                {
                    TallyException ex = new TallyException(_tallyConnection.LastResponseString + "\nResponse\n" + _tallyConnection.RequestXML,
                        "Ledger Name : " + ledger.LedgerName + "\nAlias Name : " + ledger.ExportedName
                                + "\n\n Request XML \n" + _tallyConnection.RequestXML
                                + "\n\n Response XML \n" + _tallyConnection.LastResponseString + "\n\n");

                    TallyExceptionHandler.HandleException(ex);
                }
            }
        }
    }

    public class TransactionTypes
    {
        public static readonly String CHARGE = "CHR";
        public static readonly String PAYMENT = "PAY";
        public static readonly String TRANSFER = "TRN";
        public static readonly String PURCHASE = "PUR";
    }

    public enum SyncType
    {
        NEW, MOD, CAN
    }

    public class EntryType
    {
        public static readonly String CREDIT = "Credit";
        public static readonly String DEBIT = "Debit";
    }

    public class TallyDefs
    {
        public readonly static String TALLYURL = "TestTallyURL";
        public readonly static String COMPANYNAME = "TestTallyCompany";
        public readonly static String ISTALLYENABLED = "IsTestTallyEnabled";
        public readonly static String TESTEXPORTDATE = "TestExportDate";
    }

    public class TallyGroups
    {
        public readonly static String Sundry_Debtors = "Sundry Debtors";
        public readonly static String Sundry_Creditors = "Sundry Creditors";
        public readonly static String Cash_In_Hand = "Cash-in-hand";
        public readonly static String Bank_Accounts = "Bank Accounts";
        public readonly static String Purchase_Accounts = "Purchase Accounts";
        public readonly static String Current_Liabilities = "Current Liabilities";
        public readonly static String Direct_Income = "Direct Incomes";
        public readonly static String Current_Assets = "Current Assets";
    }

    public class TransactionStatus
    {
        public static readonly String NEW = "NEW";
        public static readonly String MODIFIED = "MOD";
        public static readonly String CANCELED = "CAN";
    }

    public class AccountIDType
    {
        public static readonly String MEMBER = "MEM";
        public static readonly String CHARGEACCOUNT = "CHR";
        public static readonly String TAXACCOUNT = "TAX";
        public static readonly String SUPPLIER_ACCOUNT = "SUP";
        public static readonly String PURCHASE_ACCOUNT = "PUR";
        public static readonly String ROOM_CHARGE = "RCH";
    }

    public class ChargeAccountCode
    {
        public static readonly String CASH_ACCOUNT = "CSH";
        public static readonly String CARD_ACCOUNT = "CRD";
        public static readonly String BANK_ACCOUNT = "BNK";
        public static readonly String PARTY_ACCOUNT = "PAR";
        public static readonly String SMARTCARD_ACCOUNT = "GST";
        public static readonly String ECS_ACCOUNT = "ECS";
        public static readonly String SALES_ACCOUNT = "SAL";
        public static readonly String TAX_ACCOUNT = "TAX";
        public static readonly String CONTENGENCY_DEPOSIT = "CND";
        public static readonly String COVER_CHARGES = "CVR";
        public static readonly String SUR_CHARGE = "SUR";
        public static readonly String SERVICE_TAX = "SER";
        public static readonly String MONTHLYSERVICE_TAX = "MSE";
        public static readonly String PURCHASE = "PUR";
    }
}
