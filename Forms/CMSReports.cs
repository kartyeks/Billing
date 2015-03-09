using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDACommunications;
namespace BillingManager.Forms
{
    public partial class CMSReports : Form
    {
        internal DataTable dtItem = null;
        internal string rptName = string.Empty;
        internal string rptType = string.Empty;
        internal DateTime dateFrom = DateTime.Today;
        internal DateTime dateTo = DateTime.Today;
        internal string storeName = string.Empty;
        internal string storeId = string.Empty;
        internal string withval = string.Empty;

        BillController _bController = BillController._billController;
        BilledItem[] bitms = null;
        BillingMenu[] bloc = null;
        BillingMenu[] bgod = null;
        ItemGroup[] grps = null;

        public CMSReports()
        {
            InitializeComponent();
            _bController = BillController._billController;
        }
        
        void CMSReports_Load(object sender, System.EventArgs e)
        {
              bloc= _bController.DataStore.GetMenu();
             cmbLocation.Items.Add("");
             cmbSStore.Items.Add("ALL");
             foreach (BillingMenu loc in bloc)
             {
                 cmbLocation.Items.Add(loc._storeName + "(" + loc._storeCode +")");
                 cmbSStore.Items.Add(loc._storeName + "(" + loc._storeCode + ")");
             }
             cmbLocation.SelectedIndex = 0;
             cmbSStore.SelectedIndex = 0;
             bgod = _bController.DataStore.GetGodown();
             cmbSGodown.Items.Add("ALL");
             foreach (BillingMenu loc in bgod)
             {
                 cmbSGodown.Items.Add(loc._storeName + "(" + loc._storeCode + ")");
             }
             cmbSGodown.SelectedIndex = 0;
             _bController.GetBilledItemList();
              bitms = _bController.DataStore.GetBilledItems();
             System.Collections.ArrayList aItms = new System.Collections.ArrayList();
             cmbItem.Items.Add("");
             cmbSItem.Items.Add("ALL");
             foreach (BilledItem itm in bitms)
             {
                 cmbItem.Items.Add(itm._itemName + "("+ itm._itemCode +")");
                 cmbSItem.Items.Add(itm._itemName + "(" + itm._itemCode + ")");
             }
             cmbItem.SelectedIndex = 0;
             _bController.GetItemGroups();
              grps = _bController.DataStore.GetItemGroups();
             cmbCategory.Items.Add("");
             cmbSGrp.Items.Add("ALL");
             foreach (ItemGroup gp in grps)
             {
                 cmbCategory.Items.Add(gp._groupName + "(" + gp._groupCode + ")");
                 cmbSGrp.Items.Add(gp._groupName + "(" + gp._groupCode + ")");
             }
             cmbCategory.SelectedIndex = 0;
             cmbOrder.SelectedIndex = 0;
             cmbType.SelectedIndex = 0;
             cmbPOS.SelectedIndex=0;
             cmbFrom.SelectedIndex = 0;
             cmbRType.SelectedIndex = 0;
             cmbSGrp.SelectedIndex = 0;
             cmbSItem.SelectedIndex = 0;
             cmbSOpt.SelectedIndex = 0;
             cmbSType.SelectedIndex = 0;
             cmbFor.SelectedIndex = 0;
        }


        private void btnGenarate_Click(object sender, EventArgs e)
        {
            GetReportData();
            CMSReportViewer objRpt = new CMSReportViewer();
            objRpt.Owner = this;
            objRpt.ShowDialog();
        }

        private void GetReportData()
        {
            if (rdoItemSales.Checked)
                rptName = "rdlcItemSales";
            else if (rdoItemwise.Checked)
                rptName = "rdlcItemwiseSales";
            else if (rdoSalesSumm.Checked)
                rptName = "rdlcSalesSummary";
            else if (rdoStock.Checked)
                rptName = "rdlcStoreStockSummary";

            int ind = 0;
            if (rptName == "rdlcItemSales")
            {
                ReportTable rpt = new ReportTable();
                rpt._memberId = txtMemberID.Text;
                rpt._fromDate = datFrom.Value;
                rpt._toDate = datTo.Value;
                rpt._pos = (cmbPOS.Text == "BAR" ? "1" : "2");
                rpt._rptType = (cmbType.Text == "Details" ? "1" : "2");
                rpt._rptName = rptName;
                _bController.GetReportTable(ref rpt);
                ItemSalesReport[] itms = rpt.itmSales;
                dtItem = GetItemSaleTable(itms);
                rptType = rpt._rptType;

            }
            else if (rptName == "rdlcItemwiseSales")
            {
                ReportTable rpt = new ReportTable();
                rpt._memberId = txtMemberID.Text;
                rpt._fromDate = datWFrom.Value;
                rpt._toDate = datWTo.Value;
                if (cmbItem.SelectedIndex == 0)
                {
                    rpt._itemId = "0";
                }
                else
                {
                    ind = Array.FindIndex(bitms, (x) => (x._itemName + "(" + x._itemCode + ")" == cmbItem.Text));
                    if (ind > -1)
                    {
                        rpt._itemId = bitms[ind]._itemId;
                    }
                }
                rpt._rptName = rptName;
                _bController.GetReportTable(ref rpt);
                ItemwiseSalesReport[] itmws = rpt.itmwise;
                dtItem = GetItemwiseSaleTable(itmws);
                rptType = rpt._rptType;

            }
            else if (rptName == "rdlcSalesSummary")
            {
                ReportTable rpt = new ReportTable();
                rpt._fromDate = datSFrom.Value;
                rpt._toDate = datSTo.Value;
                rpt._pos = (cmbPOS.Text == "BAR" ? "1" : "2");
                rpt._order = (cmbOrder.Text == "NONE" ? "1" : "2");
                rpt._locationId = (cmbOrder.Text == "NONE" ? "1" : "2");
                rpt._itemGrpId = (cmbOrder.Text == "NONE" ? "1" : "2");
                rpt._rptType = (cmbType.Text == "Details" ? "1" : "2");
                rpt._rptName = rptName;
                if (cmbLocation.SelectedIndex == 0)
                {
                    rpt._locationId = "0";
                }
                else
                {
                    ind = Array.FindIndex(bgod, (x) => (x._storeName + "(" + x._storeCode + ")" == cmbLocation.Text));
                    if (ind > -1)
                    {
                        rpt._locationId = bgod[ind]._storeId;
                    }
                }
                if (cmbCategory.SelectedIndex == 0)
                {
                    rpt._itemGrpId = "0";
                }
                else
                {
                    ind = Array.FindIndex(grps, (x) => (x._groupName + "(" + x._groupCode + ")" == cmbCategory.Text));
                    if (ind > -1)
                    {
                        rpt._itemGrpId = grps[ind]._groupId;
                    }
                }
                _bController.GetReportTable(ref rpt);
                SalesSummaryReport[] itms = rpt.salesSum;
                dtItem = GetSaleSummaryTable(itms);
                rptType = rpt._rptType;

            }
            else if (rptName == "rdlcStoreStockSummary")
            {
                ReportTable rpt = new ReportTable();
                rpt._fromDate = datSTFrom.Value;
                rpt._toDate = datSTTo.Value;
                rpt._rptType = (cmbSType.Text == "Details" ? "1" : "2");
                rpt._rptName = rptName;
                if (cmbFor.SelectedIndex == 0 || cmbFor.SelectedIndex == 2)
                {
                    if (cmbSGodown.SelectedIndex == 0)
                    {
                        rpt._locationId = "0";
                        storeName = "ALL Locations";
                    }
                    else
                    {
                        ind = Array.FindIndex(bgod, (x) => (x._storeName + "(" + x._storeCode + ")" == cmbSGodown.Text));
                        if (ind > -1)
                        {
                            rpt._locationId = bgod[ind]._storeId;
                            storeName = bgod[ind]._storeName;
                        }
                    }
                }
                else
                {
                    if (cmbSStore.SelectedIndex == 0)
                    {
                        rpt._locationId = "0";
                        storeName = "ALL Locations";
                    }
                    else
                    {
                        ind = Array.FindIndex(bloc, (x) => (x._storeName + "(" + x._storeCode + ")" == cmbSStore.Text));
                        if (ind > -1)
                        {
                            rpt._locationId = bloc[ind]._storeId;
                            storeName = bloc[ind]._storeName;
                        }
                    }
                }

                if (cmbCategory.SelectedIndex == 0)
                {
                    rpt._itemGrpId = "0";
                }
                else
                {
                    ind = Array.FindIndex(grps, (x) => (x._groupName + "(" + x._groupCode + ")" == cmbCategory.Text));
                    if (ind > -1)
                    {
                        rpt._itemGrpId = grps[ind]._groupId;
                    }
                }
                _bController.GetReportTable(ref rpt);
                StoreStockReport[] itms = rpt.stockSum;
                dtItem = GetItemStockSummaryTable(itms);
                rptType = rpt._rptType;
                storeId = rpt._locationId;
                withval = (rdoWVal.Checked ? "0" : "1"); 
                

            }
        }

        private DataTable GetItemSaleTable(ItemSalesReport[] itms)
        {
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("BillDate", Type.GetType("System.DateTime"));
            dtReport.Columns.Add("BillNo", Type.GetType("System.String"));
            dtReport.Columns.Add("MemberID", Type.GetType("System.String"));
            dtReport.Columns.Add("AccountNumber", Type.GetType("System.String"));
            dtReport.Columns.Add("MemberName", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemNo", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemName", Type.GetType("System.String"));
            dtReport.Columns.Add("SalesUnitID", Type.GetType("System.String"));
            dtReport.Columns.Add("Unit", Type.GetType("System.String"));
            dtReport.Columns.Add("Quantity", Type.GetType("System.Double"));
            dtReport.Columns.Add("Rate", Type.GetType("System.Double"));
            dtReport.Columns.Add("Total", Type.GetType("System.Double"));
            dtReport.Columns.Add("OTNo", Type.GetType("System.String"));
            dtReport.Columns.Add("BearerID", Type.GetType("System.String"));
            dtReport.Columns.Add("Counter", Type.GetType("System.String"));
            dtReport.Columns.Add("POS", Type.GetType("System.String"));

            foreach (ItemSalesReport itm in itms)
            {
                DataRow dr = dtReport.NewRow();
                dr["BillNo"] = itm._billNo;
                dr["BillDate"] =(DateTime) itm._billDate;
                dr["MemberID"] =  itm._memberId;
                dr["AccountNumber"] = itm._accNo;
                dr["MemberName"] = itm._memberName;
                dr["ItemNo"] =  itm._itemNo;
                dr["ItemName"] =  itm._itemName;
                dr["SalesUnitID"] =  itm._unitId;
                dr["Unit"] = itm._unit;
                dr["Quantity"] = itm._qty;
                dr["Rate"] = itm._rate;
                dr["Total"] = itm._total;
                dr["OTNo"] = itm._otNo;
                dr["BearerID"] = itm._bearerid;
                dr["Counter"] = itm._counter;
                dr["POS"] = itm._pos;
                dtReport.Rows.Add(dr);

            }
            return dtReport;

        }

        private DataTable GetItemwiseSaleTable(ItemwiseSalesReport[] itms)
        {
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("BillDate", Type.GetType("System.DateTime"));
            dtReport.Columns.Add("BillNo", Type.GetType("System.String"));
            dtReport.Columns.Add("MemberID", Type.GetType("System.String"));
            dtReport.Columns.Add("AccountNumber", Type.GetType("System.String"));
            dtReport.Columns.Add("MemberName", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemNo", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemName", Type.GetType("System.String"));
            dtReport.Columns.Add("SalesUnitID", Type.GetType("System.String"));
            dtReport.Columns.Add("Unit", Type.GetType("System.String"));
            dtReport.Columns.Add("Quantity", Type.GetType("System.Double"));
            dtReport.Columns.Add("Rate", Type.GetType("System.Double"));
            dtReport.Columns.Add("Total", Type.GetType("System.Double"));
            dtReport.Columns.Add("OTNo", Type.GetType("System.String"));
            dtReport.Columns.Add("BearerID", Type.GetType("System.String"));
            dtReport.Columns.Add("Counter", Type.GetType("System.String"));

            foreach (ItemwiseSalesReport itm in itms)
            {
                DataRow dr = dtReport.NewRow();
                dr["BillNo"] = itm._billNo;
                dr["BillDate"] = (DateTime)itm._billDate;
                dr["MemberID"] = itm._memberId;
                dr["AccountNumber"] = itm._accNo;
                dr["MemberName"] = itm._memberName;
                dr["ItemNo"] = itm._itemNo;
                dr["ItemName"] = itm._itemName;
                dr["SalesUnitID"] = itm._unitId;
                dr["Unit"] = itm._unit;
                dr["Quantity"] = itm._qty;
                dr["Rate"] = itm._rate;
                dr["Total"] = itm._total;
                dr["OTNo"] = itm._otNo;
                dr["BearerID"] = itm._bearerid;
                dr["Counter"] = itm._counter;
                dtReport.Rows.Add(dr);

            }
            return dtReport;

        }
        private DataTable GetSaleSummaryTable(SalesSummaryReport[] itms)
        {
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("ItemCode", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemName", Type.GetType("System.String"));
            dtReport.Columns.Add("Quantity", Type.GetType("System.Double"));
            dtReport.Columns.Add("Rate", Type.GetType("System.Double"));
            dtReport.Columns.Add("Amount", Type.GetType("System.Double"));
            
            foreach (SalesSummaryReport itm in itms)
            {
                DataRow dr = dtReport.NewRow();
                dr["ItemCode"] = itm._itemNo;
                dr["ItemName"] = itm._itemName;
                dr["Quantity"] = itm._qty;
                dr["Rate"] = itm._rate;
                dr["Amount"] = itm._amount;
                dtReport.Rows.Add(dr);

            }
            return dtReport;

        }
        private DataTable GetItemStockSummaryTable(StoreStockReport[] itms)
        {
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("ItemID", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemCode", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemName", Type.GetType("System.String"));
            dtReport.Columns.Add("ItemGroupId", Type.GetType("System.String"));
            dtReport.Columns.Add("GroupCode", Type.GetType("System.String"));
            dtReport.Columns.Add("GroupName", Type.GetType("System.String"));
            dtReport.Columns.Add("UnitName", Type.GetType("System.String"));
            dtReport.Columns.Add("OpeningbalanceBtl", Type.GetType("System.Double"));
            dtReport.Columns.Add("OpeningBalance", Type.GetType("System.Double"));
            dtReport.Columns.Add("ReceivedQty", Type.GetType("System.Double"));
            dtReport.Columns.Add("IssuedQty", Type.GetType("System.Double"));
            dtReport.Columns.Add("AdjustedQty", Type.GetType("System.Double"));
            dtReport.Columns.Add("ClosedBtl", Type.GetType("System.Double"));
            dtReport.Columns.Add("Rate", Type.GetType("System.Double"));
            dtReport.Columns.Add("FinalValue", Type.GetType("System.Double"));
            

            foreach (StoreStockReport itm in itms)
            {
                DataRow dr = dtReport.NewRow();
                dr["ItemCode"] = itm._itemId;
                dr["ItemCode"] = itm._itemNo;
                dr["ItemName"] = itm._itemName;
                dr["GroupCode"] = itm._grpCode;
                dr["GroupName"] = itm._grpName;
                dr["UnitName"] = itm._unitName;
                dr["OpeningbalanceBtl"] = itm._opbalbtl;
                dr["OpeningBalance"] = itm._opbal;
                dr["ReceivedQty"] = itm._recqty;
                dr["IssuedQty"] = itm._issqty;
                dr["AdjustedQty"] = itm._adjqty;
                dr["ClosedBtl"] = itm._clbalbtl;
                dr["Rate"] = itm._rate;
                dr["FinalValue"] = itm._fval;
                dtReport.Rows.Add(dr);
            }
            return dtReport;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoItemSales_CheckedChanged(object sender, EventArgs e)
        {
            OnReportChange();
        }
        private void OnReportChange()
        {
            grpItemSale.Visible = false;
            grpItemwise.Visible=false;
            grpSalesSumm.Visible = false;
            grpItemStock.Visible = false;
            if (rdoItemSales.Checked)
            {
                grpItemSale.Visible = true;
            }
            else if (rdoItemwise.Checked)
            {
                grpItemwise.Visible = true;
            }
            else if (rdoSalesSumm.Checked)
            {
                grpSalesSumm.Visible = true;
            }
            else if (rdoStock.Checked)
            {
                grpItemStock.Visible = true;
            }
        }

        private void rdoItemwise_CheckedChanged(object sender, EventArgs e)
        {
            OnReportChange();
        }

        private void rdoSalesSumm_CheckedChanged(object sender, EventArgs e)
        {
            OnReportChange();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            GetReportData();
            if (dtItem == null)
            {
                return;
            }
            if (dtItem.Rows.Count == 0)
            {
                return;
            }
            MSExcel mse = new MSExcel();
             if (rdoItemSales.Checked)
                rptName = "rdlcItemSales";
            else if (rdoItemwise.Checked)
                rptName = "rdlcItemwiseSales";
            else if (rdoSalesSumm.Checked)
                rptName = "rdlcSalesSummary";
             else if (rdoStock.Checked)
                 rptName = "rdlcStockSummary";
            int ind = 0;
            string strH = string.Empty;
            if (rptName == "rdlcItemSales")
            {
                if (datFrom.Value.Year <= 1900)
                    strH = "ITEM SALES REPORT As On " + datTo.Value.ToString("dd/MM/yyyy");
                else
                    strH = "ITEM SALES REPORT From " + datFrom.Value.ToString("dd/MM/yyyy") + " To " + datTo.Value.ToString("dd/MM/yyyy");
                mse.GetItemSalesReport(dtItem, strH, cmbType.Text == "Details" ? "1" : "2");
            }
            else if (rptName == "rdlcItemwiseSales")
            {
                if (datWFrom.Value.Year <= 1900)
                    strH = "ITEMWISE SALES REPORT As On " + datWTo.Value.ToString("dd/MM/yyyy");
                else
                    strH = "ITEMWISE SALES REPORT From " + datWFrom.Value.ToString("dd/MM/yyyy") + " To " + datWTo.Value.ToString("dd/MM/yyyy");
         
                mse.GetItemwiseSalesReport(dtItem, strH);
            }
            else if (rptName == "rdlcSalesSummary")
            {
                mse.GetSalesSummaryReport(dtItem, "SALES SUMMARY", cmbType.Text == "Details" ? "1" : "2");
            }
            else if (rptName == "rdlcStockSummary")
            {
                 if (cmbSStore.Text != "")
                        storeName = cmbSStore.Text;
                    else
                        storeName = "ALL Location ";
                    string strTblHdr = String.Concat(storeName, " STOCK DETAILS SUMMARY ");
                    if (datSFrom.Value.Year <= 1900)
                    {
                        strH = strTblHdr + " AS ON " + datSTo.Value.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        strH = strTblHdr + " FROM " + datSFrom.Value.ToString("dd/MM/yyyy") + " TO " + datSFrom.Value.ToString("dd/MM/yyyy");
                    }
                mse.GetStockSummaryReport(dtItem, strH, rdoWVal.Checked?"true":"false");
            }
            //mse.Open("");
          // mse.Close();
        }

        private void cmbFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFor.Text.ToUpper() == "GODOWN")
            {
                cmbSGodown.Visible = true;
                cmbSStore.Visible = false;
            }
            else if (cmbFor.Text.ToUpper() == "POS")
            {
                cmbSGodown.Visible = false;
                cmbSStore.Visible = true;
            }
            else if (cmbFor.Text.ToUpper() == "ALL")
            {
                cmbSGodown.Visible = false;
                cmbSStore.Visible = false;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSOpt.Text.ToLower() == "groupwise")
            {
                cmbSGrp.Visible = true;
                cmbSItem.Visible = false;
            }
            else
            {
                cmbSGrp.Visible = false;
                cmbSItem.Visible = true;
            }
        }
    }
}
