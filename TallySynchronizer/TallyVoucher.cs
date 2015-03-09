using System;
using System.Collections.Generic;

namespace TallySynchronizer
{

    /// <summary>
    /// Class represents a Voucher Entry in Tally and provides methods
    /// to create the XML format for tally import.
    /// </summary>
    public class TallyVoucher
    {
        public enum ActionType
        {
            Create,
            Alter,
            Cancel,
            Delete,
            Search
        }

        private static readonly String VoucherEntryAlternateXMLTemplate =
            "<ENVELOPE>\n" +
            "<HEADER>\n" +
            "<VERSION>1</VERSION>\n" +
            "<TALLYREQUEST>Import</TALLYREQUEST>\n" +
            "<TYPE>Data</TYPE>\n" +
            "<ID>All Masters</ID>\n" +
            "</HEADER>\n" +
            "<BODY>\n" +
            "<DESC>\n" +
            "<STATICVARIABLES>\n" +
            "<SVCURRENTCOMPANY>$TallyCompanyName$</SVCURRENTCOMPANY>\n" +
            "<IMPORTDUPS>@@DupIgnoreCombine</IMPORTDUPS>\n" +
            "</STATICVARIABLES>\n" +
            "</DESC>\n" +
            "<DATA>\n" +
            "<TALLYMESSAGE>\n" +
            "<VOUCHER DATE=\"$EntryDate$\" TAGNAME = \"$TagName$\" TAGVALUE=\"$TagValue$\" Action=\"$ModificationFlag$\">\n" +
            "<DATE>$TransactionDate$</DATE>\n" +
            "<NARRATION>$Narration$</NARRATION>\n" +
            "<VOUCHERTYPENAME>$VoucherType$</VOUCHERTYPENAME>\n" +
            "<VOUCHERNUMBER>$VoucherNumber$</VOUCHERNUMBER>\n" +
            "<REFERENCE>$ReferenceNumber$</REFERENCE>\n" +
            "$LedgerAccountEntries$\n" +
            "</VOUCHER>\n" +
            "</TALLYMESSAGE>\n" +
            "</DATA>\n" +
            "</BODY>\n" +
            "</ENVELOPE>";

        public static readonly String VoucherEntrySearchXMLTemplate =
            "<ENVELOPE>\n" +
            "<HEADER>\n" +
            "<VERSION>1</VERSION>\n" +
            "<TALLYREQUEST>Export</TALLYREQUEST>\n" +
            "<TYPE>Data</TYPE>\n" +
            "<ID>VoucherData</ID>\n" +
            "</HEADER>\n" +
            "<BODY>\n" +
            "<DESC>\n" +
            "<STATICVARIABLES>\n" +
            "<EXPLODEFLAG>Yes</EXPLODEFLAG>\n" +
            "<SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT>\n" +
            "</STATICVARIABLES>\n" +
            "<TDL>\n" +
            "<TDLMESSAGE>\n" +
            "<REPORT NAME=\"VoucherData\"><FORMS>Vouchers</FORMS></REPORT>\n" +
            "<FORM NAME=\"Vouchers\">\n" +
            "<PARTS>Vouchers</PARTS> \n" +
            "<XMLTAG>\"Vouchers\"</XMLTAG> \n" +
            "</FORM>\n" +
            "<PART NAME=\"Vouchers\">\n" +
            "<LINES>Vouchers</LINES> \n" +
            "<REPEAT>Vouchers : Collection of Vouchers</REPEAT> \n" +
            "<SCROLLED>Vertical</SCROLLED> \n" +
            "</PART>\n" +
            "<LINE NAME=\"Vouchers\">\n" +
            "<FIELDS>VoucherID</FIELDS>\n" +
            "<FIELDS>VoucherNumber</FIELDS>\n" +
            "<FIELDS>VoucherReferenceNumber</FIELDS>\n" +
            "</LINE>\n" +
            "<FIELD NAME=\"VoucherID\">\n" +
            "<SET>$VoucherID</SET> \n" +
            "<XMLTAG>\"LASTVCHID\"</XMLTAG> \n" +
            "</FIELD>\n" +
            "<FIELD NAME=\"VoucherNumber\">\n" +
            "<SET>$VoucherNumber</SET> \n" +
            "<XMLTAG>\"VCHNUM\"</XMLTAG> \n" +
            "</FIELD>\n" +
            "<FIELD NAME=\"VoucherReferenceNumber\">\n" +
            "<SET>$Reference</SET> \n" +
            "<XMLTAG>\"VCHREF\"</XMLTAG> \n" +
            "</FIELD>\n" +
            "<COLLECTION NAME=\"Collection of Vouchers\">\n" +
            "<TYPE>Voucher</TYPE>\n" +
            "<FILTERS>NoProfitsimple</FILTERS>\n" +
            "</COLLECTION>\n" +
            "<SYSTEM TYPE=\"Formulae\" NAME=\"NoProfitSimple\">$Condition$</SYSTEM>\n" +
            "</TDLMESSAGE>\n" +
            "</TDL>\n" +
            "</DESC>\n" +
            "</BODY>\n" +
            "</ENVELOPE>\n";

        // Voucher Entry Fields
        public String ReferenceNumber = null;

        /// <summary>
        /// Date of the transaction
        /// </summary>
        public DateTime TransactionDate = DateTime.MinValue;

        /// <summary>
        /// Narration for the transaction
        /// </summary>
        public String Narration = null;

        /// <summary>
        /// Type of the voucher
        /// </summary>
        public String VoucherType = "";

        public String VoucherID = String.Empty;
        
        /// <summary>
        /// Date of original transaction needed for alter and cancel of vouchers only
        /// </summary>
        public DateTime OriginalTransactionDate = DateTime.MinValue;

        private ActionType VoucherActionType = ActionType.Alter;

        /// <summary>
        /// Ledger entry list
        /// </summary>
        public List<LedgerEntry> LedgerEntries = new List<LedgerEntry>();

        /// <summary>
        /// Ledger entries being debited
        /// </summary>
        public List<LedgerEntry> DebitedLedgerAccounts = new List<LedgerEntry>();

        public TallyVoucher AddCreditEntry(String LedgerName, double EntryAmount)
        {
            LedgerEntries.Add(new LedgerEntry() {LedgerAccountName =  LedgerName, Amount = EntryAmount, IsDeemedPositive = false});

            return this;
        }

        public TallyVoucher AddDebitEntry(String LedgerName, double EntryAmount)
        {
            LedgerEntries.Add(new LedgerEntry() { LedgerAccountName = LedgerName, Amount = EntryAmount, IsDeemedPositive = true });

            return this;
        }

        public void SetVoucherAlteration()
        {
            VoucherActionType = ActionType.Alter;
        }

        public void SetVoucherCancellation()
        {
            VoucherActionType = ActionType.Cancel;
        }

        public void SetVoucherDeletion()
        {
            VoucherActionType = ActionType.Delete;
        }

        public void SetVoucherSearch()
        {
            VoucherActionType = ActionType.Search;
        }

        // XML Conversion methods
        private String GetTallyTransactionDate()
        {
            String TransactionDateString =
                TransactionDate.Year.ToString() +
                (TransactionDate.Month < 10 ? "0" : "") + TransactionDate.Month.ToString() +
                (TransactionDate.Day < 10 ? "0" : "") + TransactionDate.Day.ToString();

            return TransactionDateString;
        }

        private String GetOriginalTransactionDate()
        {
            String TransactionDateString =
                OriginalTransactionDate.Year.ToString() +
                (OriginalTransactionDate.Month < 10 ? "0" : "") + OriginalTransactionDate.Month.ToString() +
                (OriginalTransactionDate.Day < 10 ? "0" : "") + OriginalTransactionDate.Day.ToString();

            return TransactionDateString;
        }

        private String GetNarrationDetail()
        {
            return "[" + ReferenceNumber + "]" + Narration;
        }

        /// <summary>
        /// Returns the XML String representing the details of this Voucher Entry
        /// </summary>
        /// <returns>XML String if data is valid, throws exceptions otherwise</returns>
        public String GetVoucherXML(String TallyCompanyName)
        {
            // Check if critical data has been provided
            if (VoucherActionType == ActionType.Search)
            {
                if (String.IsNullOrEmpty(VoucherID) && String.IsNullOrEmpty(ReferenceNumber))
                {
                    throw new Exception("Voucher ID/ReferenceNumber not provided");
                }
                else
                {
                    String VoucherSearchXML = VoucherEntrySearchXMLTemplate;

                    if (!String.IsNullOrEmpty(VoucherID))
                    {
                        VoucherSearchXML = VoucherSearchXML.Replace("$Condition$", "$VoucherID = " + VoucherID);
                    }
                    else
                    {
                        VoucherSearchXML = VoucherSearchXML.Replace("$Condition$", "$Reference = \"" + ReferenceNumber + "\"");
                    }

                    return VoucherSearchXML;
                }
            }
            else if 
                (
                    (VoucherActionType == ActionType.Alter || VoucherActionType == ActionType.Create) &&
                    (LedgerEntries == null || LedgerEntries.Count == 0)
                )
            {
                throw new Exception("Ledger Account Details not provided");
            }
            else if (VoucherType == "")
            {
                throw new Exception("Voucher Type not provided");
            }
            else if ((VoucherActionType == ActionType.Alter || VoucherActionType == ActionType.Create) && DateTime.MinValue == TransactionDate)
            {
                throw new Exception("Transaction Date not provided");
            }
            else if ((VoucherActionType == ActionType.Cancel || VoucherActionType == ActionType.Delete) && DateTime.MinValue == OriginalTransactionDate)
            {
                throw new Exception("Original Transaction Date not provided");
            }
            else if (VoucherActionType != ActionType.Create && String.IsNullOrEmpty(ReferenceNumber))
            {
                throw new Exception("Reference Number Needed for modification not provided");
            }
            else if (VoucherActionType != ActionType.Create && OriginalTransactionDate == DateTime.MinValue)
            {
                throw new Exception("Voucher Original Entry Date Needed for modification not provided");
            }
            else
            {
                double TotalAmount = 0;

                foreach (LedgerEntry Entry in LedgerEntries)
                {
                    TotalAmount += Entry.LedgerEntryAmount;
                }

                if (TotalAmount != 0)
                {
                    throw new Exception("Errorneous Ledger Entries provided");
                }

                String VoucherXML = VoucherEntryAlternateXMLTemplate
                                        .Replace("$VoucherNumber$", ReferenceNumber)
                                        .Replace("$ModificationFlag$", VoucherActionType.ToString())
                                        .Replace("$EntryDate$", GetOriginalTransactionDate());

                if (VoucherActionType == ActionType.Create || VoucherActionType == ActionType.Alter || VoucherActionType == ActionType.Cancel)
                {
                    VoucherXML = VoucherXML.Replace("$TagName$", "Reference");
                    VoucherXML = VoucherXML.Replace("$TagValue$", ReferenceNumber);
                }
                else if (VoucherActionType == ActionType.Delete)
                {
                    VoucherXML = VoucherXML.Replace("$TagName$", "Voucher ID");
                    VoucherXML = VoucherXML.Replace("$TagValue$", VoucherID);
                }

                VoucherXML = VoucherXML.Replace("$TallyCompanyName$", XMLEncode(TallyCompanyName));
                VoucherXML = VoucherXML.Replace("$TransactionDate$", GetTallyTransactionDate());
                VoucherXML = VoucherXML.Replace("$Narration$", XMLEncode(GetNarrationDetail()));
                VoucherXML = VoucherXML.Replace("$VoucherType$", VoucherType.ToString());
                VoucherXML = VoucherXML.Replace("$ReferenceNumber$", ReferenceNumber);
                
                String LedgerEntriesXML = String.Empty;

                foreach (LedgerEntry Entry in LedgerEntries)
                {
                    LedgerEntriesXML += Entry.GetLedgerAccountXML();
                }

                VoucherXML = VoucherXML.Replace("$LedgerAccountEntries$", LedgerEntriesXML);

                return VoucherXML;
            }

        }

        private String XMLEncode(String Data)
        {
            Data = Data
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#39;");

            return Data;
        }
    }

    public class LedgerEntry
    {
        private readonly String _LedgerEntryXMLTemplate =
                        "<ALLLEDGERENTRIES.LIST>\n" +
                        "<LEDGERNAME>$LedgerAccountName$</LEDGERNAME>\n" +
                        "<ISDEEMEDPOSITIVE>$IsDeemedPositive$</ISDEEMEDPOSITIVE>\n" +
                        "<AMOUNT>$Amount$</AMOUNT>\n" +
                        "</ALLLEDGERENTRIES.LIST>\n";

        /// <summary>
        /// Name of the ledger Account
        /// </summary>
        public String LedgerAccountName = null;

        /// <summary>
        /// Amount of the transaction
        /// </summary>
        public double Amount = 0.0;

        /// <summary>
        /// Whether the amount is deemed positive
        /// </summary>
        public bool IsDeemedPositive;

        public double LedgerEntryAmount
        {
            get
            {
                return (IsDeemedPositive ? -1 : 1) * Amount;
            }
        }

        public String GetLedgerAccountXML()
        {
            // Check if critical data has been provided
            if (String.IsNullOrEmpty(LedgerAccountName))
            {
                if (IsDeemedPositive)
                {
                    throw new Exception("Credited Ledger Account Name not provided");
                }
                else
                {
                    throw new Exception("Debited Ledger Account Name not provided");
                }
            }
            else if (0 == Amount)
            {
                throw new Exception("Amount not provided");
            }
            else
            {
                String LedgerXML = _LedgerEntryXMLTemplate;

                LedgerXML = LedgerXML.Replace("$LedgerAccountName$", XMLEncode(LedgerAccountName));
                LedgerXML = LedgerXML.Replace("$Amount$", Convert.ToString(LedgerEntryAmount));
                LedgerXML = LedgerXML.Replace("$IsDeemedPositive$", IsDeemedPositive? "Yes": "No");

                return LedgerXML;
            }
        }

        private String XMLEncode(String Data)
        {
            Data = Data
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#39;");

            return Data;
        }
    }
}
