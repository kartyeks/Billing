using System;

namespace TallySynchronizer
{
    /// <summary>
    /// Class represents a Ledger account in Tally and provides methods
    /// to create the XML format for tally import.
    /// </summary>
    public class TallyLedger
    {
        // Ledger Account XML Template
        private static readonly String LedgerXMLTemplate =
            "<ENVELOPE>" +
            "<HEADER>" +
            "<VERSION>1</VERSION>" +
            "<TALLYREQUEST>Import</TALLYREQUEST>" +
            "<TYPE>Data</TYPE>" +
            "<ID>All Masters</ID>" +
            "</HEADER>" +
            "<BODY>" +
            "<DESC>" +
            "<STATICVARIABLES>" +
            "<SVCURRENTCOMPANY>$TallyCompanyName$</SVCURRENTCOMPANY>" +
            "<IMPORTDUPS>@@DupIgnoreCombine</IMPORTDUPS>" +
            "</STATICVARIABLES>" +
            "</DESC>" +
            "<DATA>" +
            "<TALLYMESSAGE>" +
            "<LEDGER NAME=\"$LedgerName$\">" +
            "<PARENT>$ParentGroupName$</PARENT>" +
            "<LANGUAGENAME.LIST>" +
            "<NAME.LIST TYPE=\"String\">" +
            "<NAME>$LedgerName$</NAME>" +
            "<NAME>$AliasName$</NAME>" +
            "</NAME.LIST>" +
            "</LANGUAGENAME.LIST>" +
            "</LEDGER>" +
            "</TALLYMESSAGE>" +
            "</DATA>" +
            "</BODY>" +
            "</ENVELOPE>";

        private static String AddressLineXMLTemplate = "<ADDRESS>$AddressLine$</ADDRESS>";
        // Ledger Account Fields

        /// <summary>
        /// Name of the ledger Account
        /// </summary>
        public String LedgerName = null;

        /// <summary>
        /// Alias Name of the ledger Account
        /// </summary>
        public String AliasName = null;

        /// <summary>
        /// Name of the Group in Tally to which this ledger Account is to be added.
        /// Should be an existing Group in tally.
        /// </summary>
        public String ParentGroupName = null;

        /// <summary>
        /// Returns the XML String representing the details of this ledger account
        /// </summary>
        /// <returns>XML String if data is valid, throws exceptions otherwise</returns>
        public String GetLedgerXML(String TallyCompanyName)
        {
            // Check if critical data has been provided
            if (String.IsNullOrEmpty(LedgerName))
            {
                throw new Exception("LedgerName not provided");
            }
            else if (String.IsNullOrEmpty(AliasName))
            {
                throw new Exception("AliasName not provided");
            }
            else if (String.IsNullOrEmpty(ParentGroupName))
            {
                throw new Exception("ParentGroupName not provided");
            }
            else
            {
                String LedgerXML = LedgerXMLTemplate;

                LedgerXML = LedgerXML.Replace("$TallyCompanyName$", XMLEncode(TallyCompanyName));
                LedgerXML = LedgerXML.Replace("$LedgerName$", XMLEncode(LedgerName));

                String AddressXML = AddressLineXMLTemplate;

                LedgerXML = LedgerXML.Replace("$AddressLines$", XMLEncode(AddressXML));

                LedgerXML = LedgerXML.Replace("$ParentGroupName$", XMLEncode(ParentGroupName));
                LedgerXML = LedgerXML.Replace("$AliasName$", XMLEncode(AliasName));

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
