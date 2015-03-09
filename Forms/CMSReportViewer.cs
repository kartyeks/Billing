using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Reflection;

namespace BillingManager.Forms
{
    public partial class CMSReportViewer : Form
    {
        public CMSReportViewer()
        {
            InitializeComponent();
        }
        string frmdate = string.Empty;
        string todate = string.Empty;
        private void CMSReportViewer_Load(object sender, EventArgs e)
        {
            ReportParameter[] rptParam = null;
            ReportDataSource rptDSrc = null;
            this.rptViewer.RefreshReport();
            rptViewer.LocalReport.EnableExternalImages = true;
            if (((CMSReports)this.Owner).rptName == "rdlcItemSales")
            {
                rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                if (((CMSReports)this.Owner).rptType == "2")
                //    rptViewer.LocalReport.ReportEmbeddedResource = "BillingManager.Reports.rdlcItemSalesSummary.rdlc";
                  rptViewer.LocalReport.ReportPath =AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcItemSalesSummary.rdlc";
                else
                    rptViewer.LocalReport.ReportPath =AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcItemSalesDetails.rdlc";
                   //rptViewer.LocalReport.ReportEmbeddedResource = "BillingManager.Reports.rdlcItemSalesDetails.rdlc";
                   
                //Stream resourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream("BillingManager.Reports.rdlcItemSalesDetails.rdlc");
                /*rptViewer.LocalReport.ReportEmbeddedResource = @"Resources\rdlcItemSalesSummary.rdlc";*/
              /*  using (StreamReader rdlcSR = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"Reports\rdlcItemSalesSummary.rdlc")) 
                {
                    rptViewer.LocalReport.LoadReportDefinition(rdlcSR);
                    rptViewer.LocalReport.Refresh(); 
                }
               
                */
                //this.rptViewer.LocalReport.LoadReportDefinition(resourceStream);

 

               rptDSrc = new ReportDataSource("Accounts_ItemSalesSummary", ((CMSReports)this.Owner).dtItem);
                rptViewer.LocalReport.DataSources.Add(rptDSrc);
                rptParam = new ReportParameter[] {
                                  new ReportParameter("PrmFromDate", ""),
                                 new ReportParameter("PrmToDate", ""),
                                 new ReportParameter("PrmCopyRight", "" ),
                                 new ReportParameter("PrmFooter",""),
                                 new ReportParameter("PrmRptHeader","" ), 
                                 new ReportParameter("PrmAllRight",""),
                                 new ReportParameter("PrmImagePath","file://" +AppDomain.CurrentDomain.BaseDirectory +"cmslogo.jpg"), //
                                 new ReportParameter("PrmCompanyLogoPath",""),
                                 new ReportParameter("PrmAddress","")
                    };
                this.rptViewer.LocalReport.SetParameters(rptParam);
                this.rptViewer.RefreshReport(); 
            }
            else if (((CMSReports)this.Owner).rptName == "rdlcItemwiseSales")
            {
                rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                rptViewer.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcItemWiseSalesDetails.rdlc";


                 rptDSrc = new ReportDataSource("Accounts_ItemSales", ((CMSReports)this.Owner).dtItem);
                rptViewer.LocalReport.DataSources.Add(rptDSrc);
                 rptParam = new ReportParameter[] {
                                  new ReportParameter("PrmFromDate", ""),
                                 new ReportParameter("PrmToDate", ""),
                                 new ReportParameter("PrmCopyRight", "" ),
                                 new ReportParameter("PrmFooter",""),
                                 new ReportParameter("PrmRptHeader","" ), 
                                 new ReportParameter("PrmAllRight",""),
                                 new ReportParameter("PrmImagePath","file://" +AppDomain.CurrentDomain.BaseDirectory +"cmslogo.jpg"), //
                                 new ReportParameter("PrmCompanyLogoPath",""),
                                 new ReportParameter("PrmAddress","")
                    };
                this.rptViewer.LocalReport.SetParameters(rptParam);
                this.rptViewer.RefreshReport();
            }
            else if (((CMSReports)this.Owner).rptName == "rdlcSalesSummary")
            {
                rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                if (((CMSReports)this.Owner).rptType == "2")
                    rptViewer.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcSalesSummary.rdlc";
                else
                    rptViewer.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcSalesSummaryDetails.rdlc";


                rptDSrc = new ReportDataSource("Accounts_SalesSummary", ((CMSReports)this.Owner).dtItem);
                rptViewer.LocalReport.DataSources.Add(rptDSrc);
                rptParam = new ReportParameter[] {
                                  new ReportParameter("PrmFromDate", ""),
                                 new ReportParameter("PrmToDate", ""),
                                 new ReportParameter("PrmCopyRight", "" ),
                                 new ReportParameter("PrmFooter",""),
                                 new ReportParameter("PrmRptHeader","" ), 
                                 new ReportParameter("PrmAllRight",""),
                                 new ReportParameter("PrmImagePath","file://" +AppDomain.CurrentDomain.BaseDirectory +"cmslogo.jpg"), //
                                 new ReportParameter("PrmCompanyLogoPath",""),
                                 new ReportParameter("PrmAddress","")
                    };
                this.rptViewer.LocalReport.SetParameters(rptParam);
                this.rptViewer.RefreshReport();
            }
            else if (((CMSReports)this.Owner).rptName == "rdlcStoreStockSummary")
            {
                rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                if (((CMSReports)this.Owner).rptType == "2")
                {
                    rptViewer.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcStoreStockSummarywv.rdlc";
                }
                else
                    rptViewer.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcStoreStockSummarywv.rdlc";
                frmdate = ((CMSReports)this.Owner).dateFrom.ToString("dd/MM/yyyy");
                todate = ((CMSReports)this.Owner).dateTo.ToString("dd/MM/yyyy");
                if (((CMSReports)this.Owner).dateFrom.Year <= 1900)
                {
                    frmdate = "";
                    todate = "AS ON " + todate;
                }
                else
                {
                    frmdate = "FROM " + frmdate;
                    todate = " TO " + todate;
                }
                string storeName = ((CMSReports)this.Owner).storeName;
                string strTblHdr = String.Concat(storeName, " STOCK DETAILS SUMMARY "); ;
                string withVal = ((CMSReports)this.Owner).withval;
                rptDSrc = new ReportDataSource("Inventory_StoreStockSummary", ((CMSReports)this.Owner).dtItem);
                rptViewer.LocalReport.DataSources.Add(rptDSrc);
                rptParam = new ReportParameter[] {
                                  new ReportParameter("PrmFromDate", frmdate),
                                 new ReportParameter("PrmToDate", todate),
                                 new ReportParameter("PrmCopyRight", "" ),
                                 new ReportParameter("PrmFooter",""),
                                 new ReportParameter("PrmRptHeader","" ), 
                                 new ReportParameter("PrmAllRight",""),
                                 new ReportParameter("PrmImagePath","file://" +AppDomain.CurrentDomain.BaseDirectory +"cmslogo.jpg"), //
                                 new ReportParameter("PrmCompanyLogoPath",""),
                                 new ReportParameter("PrmAddress",""),
                                 new ReportParameter("PrmTableHeader",strTblHdr),
                                 new ReportParameter("PrmWithValue",withVal),
                    };
                this.rptViewer.LocalReport.SetParameters(rptParam);
                this.rptViewer.RefreshReport();
            }
        }
    }
}
