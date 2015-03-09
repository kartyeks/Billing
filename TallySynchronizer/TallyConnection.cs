using System;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace TallySynchronizer
{
    public class TallyConnection
    {
        public enum UpdateStatus
        {
            CREATED,
            ALTERED,
            UPDATE_ERROR,
            TALLY_ERROR
        }

        public enum ErrorStatus
        {
            UNKNOWN,
            HOST_NOT_RUNNING,
            COMPANY_NOTFOUND,
            LEDGER_NOTFOUND = 33,
            LEDGER_NOTEXISTS = 38,
            WRONG_DATERANG,
        }

        // Company Name as created in Tally
        private String _TallyCompanyName;

        private String _TallyURL;

        private String _LastResponseString;

        private String _RequestXML;

        public String LastResponseString
        {
            get 
            { 
                return _LastResponseString; 
            }
        }

        private UpdateStatus _LastUpdateStatus;

        public UpdateStatus LastUpdateStatus
        {
            get 
            { 
                return _LastUpdateStatus; 
            }
        }

        public ErrorStatus ErrorNo
        {
            get
            {
                try
                {
                    String ErrorID = _LastResponseString;

                    if (_LastResponseString.StartsWith("Error communicating with tally server"))
                    {
                        return ErrorStatus.HOST_NOT_RUNNING;
                    }
                    else if(_LastResponseString.Contains("Could not set &apos;SVCurrentCompany&apos;"))
                    {
                        return ErrorStatus.COMPANY_NOTFOUND;
                    }
                    else if (_LastResponseString.Contains(" Out of Range"))
                    {
                        return ErrorStatus.WRONG_DATERANG;
                    }
                    else
                    {
                        return ErrorStatus.LEDGER_NOTEXISTS;
                    }
                }
                catch (Exception e)
                {
                    return ErrorStatus.UNKNOWN;
                }
                
                return ErrorStatus.UNKNOWN;
            }
        }

        public String RequestXML
        {
            get { return _RequestXML; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="CompanyName">Company Name as per Tally</param>
        public TallyConnection(String CompanyName, String TallyURL)
        {
            _TallyCompanyName = CompanyName;
            _TallyURL = TallyURL;
        }

        public void CreateLedgerAccount(TallyLedger LedgerAccount)
        {
            String MastersXML = LedgerAccount.GetLedgerXML(_TallyCompanyName);

            UploadTallyData(MastersXML);

            _LastUpdateStatus = GetStatusFromResponse(_LastResponseString);
        }

        public String CreateVoucherEntry(TallyVoucher VoucherEntry)
        {
            String VouchersXML = VoucherEntry.GetVoucherXML(_TallyCompanyName);

            UploadTallyData(VouchersXML);

            _LastUpdateStatus = GetStatusFromResponse(_LastResponseString);

            String VoucherID = String.Empty;

            if (_LastUpdateStatus == UpdateStatus.CREATED || _LastUpdateStatus == UpdateStatus.ALTERED)
            {
                VoucherID = GetVoucherIDFromLastUpdate();
            }

            return VoucherID;
        }

        public String AlterVoucherEntry(TallyVoucher VoucherEntry)
        {
            VoucherEntry.SetVoucherAlteration();

            String VouchersXML = VoucherEntry.GetVoucherXML(_TallyCompanyName);

            UploadTallyData(VouchersXML);

            _LastUpdateStatus = GetStatusFromResponse(_LastResponseString);

            String VoucherID = String.Empty;

            if (_LastUpdateStatus == UpdateStatus.ALTERED)
            {
                VoucherID = GetVoucherIDFromLastUpdate();
            }

            return VoucherID;
        }

        public String CancelVoucherEntry(TallyVoucher VoucherEntry)
        {
            VoucherEntry.SetVoucherCancellation();

            String VouchersXML = VoucherEntry.GetVoucherXML(_TallyCompanyName);

            UploadTallyData(VouchersXML);

            _LastUpdateStatus = GetStatusFromResponse(_LastResponseString);

            String VoucherID = String.Empty;

            if (_LastUpdateStatus == UpdateStatus.ALTERED)
            {
                VoucherID = GetVoucherIDFromLastUpdate();
            }

            return VoucherID;
        }

        public String DeleteVoucherEntry(TallyVoucher VoucherEntry)
        {
            VoucherEntry.SetVoucherDeletion();

            String VouchersXML = VoucherEntry.GetVoucherXML(_TallyCompanyName);

            UploadTallyData(VouchersXML);

            _LastUpdateStatus = GetStatusFromResponse(_LastResponseString);

            String VoucherID = String.Empty;

            if (_LastUpdateStatus == UpdateStatus.ALTERED)
            {
                VoucherID = GetVoucherIDFromLastUpdate();
            }

            return VoucherID;
        }

        public String SearchVoucherEntry(TallyVoucher VoucherEntry)
        {
            VoucherEntry.SetVoucherSearch();

            String VouchersXML = VoucherEntry.GetVoucherXML(_TallyCompanyName);

            UploadTallyData(VouchersXML);

            return GetVoucherNumberFromLastUpdate();
        }

        public String GetOldVoucherNumber(TallyVoucher VoucherEntry)
        {
            VoucherEntry.SetVoucherSearch();

            String VouchersXML = VoucherEntry.GetVoucherXML(_TallyCompanyName);

            UploadTallyData(VouchersXML);

            if (_LastUpdateStatus == UpdateStatus.TALLY_ERROR)
            {
                return "-1";
            }

            return GetVoucherNumberFromLastUpdate();
        }

        public String GetVoucherNumberFromLastUpdate()
        {
            String VoucherNumber = _LastResponseString;

            try
            {
                VoucherNumber = VoucherNumber.Remove(VoucherNumber.IndexOf("</VCHNUM>"));
                VoucherNumber = VoucherNumber.Remove(0, VoucherNumber.IndexOf("<VCHNUM>"));
                VoucherNumber = VoucherNumber.Replace("<VCHNUM>", String.Empty);
            }
            catch (Exception e)
            {
                return String.Empty;
            }

            return VoucherNumber;
        }

        public String GetReferenceFromLastUpdate()
        {
            String VoucherNumber = _LastResponseString;

            try
            {
                VoucherNumber = VoucherNumber.Remove(VoucherNumber.IndexOf("</VCHREF>"));
                VoucherNumber = VoucherNumber.Remove(0, VoucherNumber.IndexOf("<VCHREF>"));
                VoucherNumber = VoucherNumber.Replace("<VCHREF>", String.Empty);
            }
            catch (Exception e)
            {
                return String.Empty;
            }

            return VoucherNumber;
        }

        public String GetVoucherIDFromLastUpdate()
        {
            String VoucherNumber = _LastResponseString;

            VoucherNumber = VoucherNumber.Remove(VoucherNumber.IndexOf("</LASTVCHID>"));
            VoucherNumber = VoucherNumber.Remove(0, VoucherNumber.IndexOf("<LASTVCHID>"));
            VoucherNumber = VoucherNumber.Replace("<LASTVCHID>", String.Empty);

            return VoucherNumber;
        }

        public List<VoucherIdentificationDetails> GetVoucherIdentificationDetails()
        {
            List<VoucherIdentificationDetails> VouchersList = new List<VoucherIdentificationDetails>();

            String ResponseString = _LastResponseString;

            while (ResponseString.Contains("<LASTVCHID>"))
            {
                VoucherIdentificationDetails VoucherDetails = new VoucherIdentificationDetails();
 
                ResponseString = ResponseString.Remove(0, ResponseString.IndexOf("<LASTVCHID>"));
                ResponseString = ResponseString.Substring("<LASTVCHID>".Length);
                VoucherDetails.VoucherID = ResponseString.Substring(0, ResponseString.IndexOf("</LASTVCHID>"));
                ResponseString = ResponseString.Remove(0, ResponseString.IndexOf("</LASTVCHID>"));
                ResponseString = ResponseString.Substring("</LASTVCHID>".Length);

                ResponseString = ResponseString.Remove(0, ResponseString.IndexOf("<VCHNUM>"));
                ResponseString = ResponseString.Substring("<VCHNUM>".Length);
                VoucherDetails.VoucherNumber = ResponseString.Substring(0, ResponseString.IndexOf("</VCHNUM>"));
                ResponseString = ResponseString.Remove(0, ResponseString.IndexOf("</VCHNUM>"));
                ResponseString = ResponseString.Substring("</VCHNUM>".Length);

                ResponseString = ResponseString.Remove(0, ResponseString.IndexOf("<VCHREF>"));
                ResponseString = ResponseString.Substring("<VCHREF>".Length);
                VoucherDetails.ReferenceNumber = ResponseString.Substring(0, ResponseString.IndexOf("</VCHREF>"));
                ResponseString = ResponseString.Remove(0, ResponseString.IndexOf("</VCHREF>"));
                ResponseString = ResponseString.Substring("</VCHREF>".Length);

                VouchersList.Add(VoucherDetails);
            }

            return VouchersList;
        }

        public VoucherDupDelResult ClearDuplicates(TallyVoucher Voucher)
        {
            VoucherDupDelResult DuplicationDetails = new VoucherDupDelResult();

            SearchVoucherEntry(new TallyVoucher()
            {
                OriginalTransactionDate = Voucher.OriginalTransactionDate,
                VoucherType = Voucher.VoucherType,
                ReferenceNumber = Voucher.ReferenceNumber
            });
            
            List<VoucherIdentificationDetails> VoucherMatches = GetVoucherIdentificationDetails();

            DuplicationDetails.MatchingVouchers = VoucherMatches.Count;

            int EntryCount = 0;

            if (DuplicationDetails.MatchingVouchers > 1)
            {
                for (int i = VoucherMatches.Count - 1; i > 0 ; i--)
                {
                    VoucherIdentificationDetails VoucherDetails = VoucherMatches[i];

                    VoucherMatches.Remove(VoucherDetails);

                    if (VoucherDetails.VoucherID == Voucher.VoucherID)
                    {
                        // Move matching voucher to beginning of list and pick the new last one
                        VoucherMatches.Insert(0, VoucherDetails);
                        
                        VoucherDetails = VoucherMatches[i];

                        VoucherMatches.Remove(VoucherDetails);
                    }


                    // Delete Voucher
                    TallyVoucher DuplicateVoucher = new TallyVoucher() 
                    {
                        VoucherID = VoucherDetails.VoucherID,
                        OriginalTransactionDate = Voucher.OriginalTransactionDate,
                        VoucherType = Voucher.VoucherType,
                        ReferenceNumber = Voucher.ReferenceNumber
                    };

                    if (DeleteVoucherEntry(DuplicateVoucher) != String.Empty)
                    {
                        EntryCount++;
                    }
                }
            }

            DuplicationDetails.DeletedDuplicates = DuplicationDetails.MatchingVouchers - VoucherMatches.Count;

            DuplicationDetails.IsSuccess = true;

            if (VoucherMatches.Count > 0)
            {
                if (EntryCount != DuplicationDetails.DeletedDuplicates)
                {
                    DuplicationDetails.IsSuccess = false;
                    DuplicationDetails.ErrorMessage = "All duplicates are not removed";
                }

                DuplicationDetails.RemainingEntryVoucherID = VoucherMatches[0].VoucherID;
                DuplicationDetails.RemainingEntryVoucherNumber = VoucherMatches[0].VoucherNumber;
            }

            return DuplicationDetails;
        }

        private UpdateStatus GetStatusFromResponse(String Response)
        {
            UpdateStatus Status;

            if (Response.Contains("<CREATED>1</CREATED>"))
            {
                Status = UpdateStatus.CREATED;
            }
            else if (Response.Contains("<ALTERED>1</ALTERED>"))
            {
                Status = UpdateStatus.ALTERED;
            }
            else if (Response.Contains("<ERRORS>1</ERRORS>"))
            {
                Status = UpdateStatus.UPDATE_ERROR;
            }
            else 
            {
                Status = UpdateStatus.TALLY_ERROR;
            }

            return Status;
        }

        public String UploadTallyData(String TallyData)
        {
            WebClient web = new WebClient();

            web.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            _RequestXML = TallyData;

            _LastResponseString = String.Empty;

            try
            {
                _LastResponseString = web.UploadString(_TallyURL, "POST", TallyData);
                TallyExceptionHandler.HandleTrace(TallyData);
            }
            catch(Exception ex)
            {
                _LastUpdateStatus = UpdateStatus.TALLY_ERROR;
                _LastResponseString = "Error communicating with tally server at " + _TallyURL;
                
            }

            return _LastResponseString;
        }
    }

    public class VoucherIdentificationDetails
    {
        public String VoucherID = String.Empty;
        public String VoucherNumber = String.Empty;
        public String ReferenceNumber = String.Empty;
    }

    public class VoucherDupDelResult
    {
        public int MatchingVouchers = 0;
        public int DeletedDuplicates = 0;
        public String RemainingEntryVoucherID = String.Empty;
        public String RemainingEntryVoucherNumber = String.Empty;
        public bool IsSuccess;
        public String ErrorMessage;
    }
}
