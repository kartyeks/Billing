using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using HRManager.BusinessObjects;
using HRManager.Communication.Request;
using Microsoft.Reporting;
using IS91.Services.Web;
using HRManager.ReportBusinessObjects;
using Microsoft.Reporting.WebForms;
using System.IO;
using HRManager;
using HRManager.Entity.EmployeesInfo;
using HRManager.DTO;

namespace AltioStarHR.Masters
{
    public partial class rdlcReportViewer : _PageMaster
    {
        string Month = string.Empty;
        string Year = string.Empty;
        DateTime DOJdatetime = DateTime.Now;
        string strReportType = string.Empty;
        string DOJ = string.Empty;
        string strEmployeeID = string.Empty;
        string strEmployeeCode = string.Empty;
        string fromDate = string.Empty;
        string toDate = string.Empty;
        string cmbteamname = string.Empty;
        DateTime dtFromDate = DateTime.Now;
        DateTime dtToDate = DateTime.Now;
        DataTable dtTable = null;
        int IsTeam;
        int TeamID;
        int team;
        int AssetCategoryID;
        int AssetSubCategoryID;
        String EmploymentType = String.Empty;
        String EmployeeCode=String.Empty;
        String TeamName = String.Empty;
        String EmpType = String.Empty;
        String rHeader = String.Empty;
        ReportDataSource rsDS;
        ReportDataSource rsDS1;
        ReportDataSource rsDS2;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            UsesMSDrillDownReports = true;
            Month = string.Concat(Request.QueryString["Month"]);
            Year = string.Concat(Request.QueryString["Year"]);
            strEmployeeID = string.Concat(Request.QueryString["employeeid"]);
            strEmployeeCode = string.Concat(Request.QueryString["employeecode"]);
            strReportType = string.Concat(Request.QueryString["rtype"]);
            Int32.TryParse(string.Concat(Request.QueryString["isteam"]), out IsTeam);
            Int32.TryParse(string.Concat(Request.QueryString["teamid"]), out TeamID);
            fromDate = string.Concat(Request.QueryString["fromDate"]);
            toDate = string.Concat(Request.QueryString["toDate"]);
            Int32.TryParse(string.Concat(Request.QueryString["cmbteamname"]), out team);
            Int32.TryParse(string.Concat(Request.QueryString["assetcategory"]), out AssetCategoryID);
            Int32.TryParse(string.Concat(Request.QueryString["assetsubcategory"]), out AssetSubCategoryID);
            EmploymentType = string.Concat(Request.QueryString["cmbemptype"]);
            TeamName = string.Concat(Request.QueryString["teamname"]);
            rHeader = string.Concat(Request.QueryString["rHeader"]);

            DOJ = string.Concat(Request.QueryString["dojdate"]);
            if (!IsPostBack)
            {
                if (strReportType != string.Empty && !IsPostBack)
                    LoadReport(strReportType);
            }
            //if (IsPostBack)
            //    ClearChildControlState();
        }
        private void LoadReport(string reptype)
        {

            switch (reptype)
            {
                case "rdlcAssetAssignTeamWise":


                    dtTable = new TeamWiseBusinessObject().GetTeamWiseBusinessObject(IsTeam, TeamID);
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcAssetAssignTeamWise.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_Teamwise", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                    }
                    break;

                case "rdlcAssetAssignUserWise":


                    dtTable = new TeamWiseBusinessObject().GetTeamWiseBusinessObject(IsTeam, TeamID);
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcAssetAssignUserWise.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_Userwise", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                    }
                    break;


                case "rdlcOutgoingAssets":

                    DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                    DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                    dtToDate = dtToDate.AddDays(1);
                    dtTable = new TeamWiseBusinessObject().GetOutgoingAssetsBusinessObject(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcOutgoingAssets.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_OutgoingAssets", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        ReportParameter[] prmsFile = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                        new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                                   };
                        this.ReportViewer1.LocalReport.SetParameters(prmsFile);

                    }
                    break;

                case "rdlcTeamwiseEmployee":

                    dtTable = new TeamWiseBusinessObject().GetTeamWiseEmployeeBusinessObject(TeamID);

                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Employee\\rdlcTeamwiseEmployee.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_TeamwiseEmployee", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                    }
                    break;


                case "rdlcAssetCategory":



                    if (AssetCategoryID != 0)
                    {
                        dtTable = new TeamWiseBusinessObject().GetAssetCategoryBusinessObject(AssetCategoryID);
                    }
                    else if (AssetSubCategoryID != 0)
                    {

                        dtTable = new TeamWiseBusinessObject().GetAssetSubCategoryBusinessObject(AssetSubCategoryID);
                    }
                    else if (AssetCategoryID == 0 || AssetSubCategoryID == 0)
                    {
                        dtTable = new TeamWiseBusinessObject().GetAllAssetBusinessObject();
                    }
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcAssetCategory.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_AssetCategorywise", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        ReportParameter[] prmsSalRegs = { new ReportParameter("PrmHeader", rHeader) };
                        ReportViewer1.LocalReport.SetParameters(prmsSalRegs);
                    }
                    break;




                case "rdlcJoiningType":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);


                        dtTable = new TeamWiseBusinessObject().GetEmployeeJoiningtypeBusinessObject(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Employee\\rdlcJoiningType.rdlc";
                            rsDS = new ReportDataSource("AssetAssigned_EmployeeJoining", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        }
                    }

                    break;
                case "rdlcExitEmployment":


                    dtTable = new TeamWiseBusinessObject().GetExitMgmtAssetsBusinessObject();
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Employee\\rdlcExitEmployment.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_ExitManagement", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                    }
                    break;

                case "rdlcEmployeeType":


                    dtTable = new TeamWiseBusinessObject().GetEmployeetypeBusinessObject(EmploymentType);
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Employee\\rdlcEmployeeType.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_Employee_Type", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                    }
                    break;


                case "rdlcAllEmployeeDetails":


                    DataTable alldataset = new TeamWiseBusinessObject().GetAllEmpdetailsBusinessObject();

                   
                    if (alldataset.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Employee\\rdlcAllEmployeeDetails.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_AllEmployeeDetails", alldataset);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        //ReportParameter[] prmsFld = { new ReportParameter("PrmEmployeeID",),
                        //                           };
                        //ReportViewer1.LocalReport.SetParameters(prmsFld);
                        ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                    }
                    break;

                case "rdlcEmployeeDetails":
                    String EmpCode = string.Concat(Request.QueryString["employeecode"]);
                    DataTable dtdetails = new Master_EmployeesBusinessObject().GetEmployeeDetailsEmpCode(EmpCode);
                    
                    int CID = 0; int EID = 0;
                    byte[] img = null;
                    byte[] finalimage = null;
                    String imagestr = string.Empty;
                    if (dtdetails.Rows.Count > 0)
                    {
                        // CID = Convert.ToInt32(dtdetails.Rows[0]["CandidateID"]);
                        EID = Convert.ToInt32(dtdetails.Rows[0]["ID"]);

                        img = new Master_EmployeesBusinessObject().GetEmployeeImageByEmpCode(EmpCode);

                        if (img == null)
                        {
                            
                        }
                        else
                        {
                            using (MemoryStream ms = new MemoryStream(img))
                            {
                                System.Drawing.Image PassImage = System.Drawing.Image.FromStream(ms, false, true);

                                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(PassImage, 115, 122);

                                using (MemoryStream m1 = new MemoryStream())
                                {
                                    bmp.Save(m1, System.Drawing.Imaging.ImageFormat.Gif);
                                    finalimage = m1.ToArray();
                                }
                            }

                            imagestr = Convert.ToBase64String(finalimage);
                        }
                    }
                    String hra = "0";
                    String lta = "0";
                    String med = "0";
                    String pf = "0";
                    String spl = "0";
                    String con = "0";
                    String ctc = "0";
                    String esop = "0";
                    
                  
                    Employee_Salary EmpDetails = new Employee_SalaryBusinessObject().GetEmployeeSalaryDetails(EID);
                    if (EmpDetails.ID != 0)
                    {
                        CTCDetails CTC = HREmployeeManager.CalculateCTCDetails(EmpDetails.CTC);
                        hra = CTC.HRA;
                        lta = CTC.LTA;
                        med = CTC.MED;
                        pf = CTC.PF;
                        spl = CTC.SPL;
                        con = CTC.CON;
                        ctc = EmpDetails.CTC.ToString(CultureInfo.InvariantCulture);
                        esop = EmpDetails.ESOP.ToString();
                        
                    }
                    
                   
                    DataSet dtset1= new TeamWiseBusinessObject().GetEmployeedetailsBusinessObject(EID);
                    DataTable dtTableEmpInfo = dtset1.Tables[0];
                    DataTable dtTableCareerSummaryDetails = dtset1.Tables[1];
                    DataTable dtEducationDetails = dtset1.Tables[2];
                    if (dtTableEmpInfo.Rows.Count<= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Employee\\rdlcEmployeeDetails.rdlc";
                        rsDS = new ReportDataSource("AssetAssigned_EmployeeDetails", dtTableEmpInfo);
                        rsDS1 = new ReportDataSource("AssetAssigned_CareerSummary", dtTableCareerSummaryDetails);
                        rsDS2 = new ReportDataSource("AssetAssigned_EducationDetails", dtEducationDetails);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS1);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS2);
                        ReportParameter[] prmsSalRegs =
                        {
                            new ReportParameter("prmImage", imagestr),
                            new ReportParameter("prmHRA", hra),
                            new ReportParameter("prmLTA", lta),
                            new ReportParameter("prmMED", med),
                            new ReportParameter("prmPF", pf),
                            new ReportParameter("prmSPL", spl),
                            new ReportParameter("prmCON", con),
                            new ReportParameter("prmCTC", ctc),
                            new ReportParameter("prmESOP", esop)
                            
                        };
                        ReportViewer1.LocalReport.SetParameters(prmsSalRegs);
                    }
                    break;


                case "rdlcSalaryDetails":

                    int mnt = 0; int yr = 0;
                    int.TryParse(Month, out mnt);
                    int.TryParse(Year, out yr);
                    dtTable = new PayrollDetailsBusinessObject().GetEmployeeDetailsForPayroll(strEmployeeID, mnt, yr);
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Payroll\\rdlcPayslip.rdlc";
                        rsDS = new ReportDataSource("Payroll_SalaryRegister", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        int mnths = 0;
                        int.TryParse(Month, out mnths);
                        String mnames = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mnths) + " " + Year;
                        ReportParameter[] prmsSalRegs = { new ReportParameter("PrmYear", mnames) };
                        ReportViewer1.LocalReport.SetParameters(prmsSalRegs);
                    }
                    break;
                case "rdlcSalaryRegister":


                    dtTable = new PayrollDetailsBusinessObject().GetSalaryRegister(Month, Year);
                    if (dtTable.Rows.Count <= 0)
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                    }
                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Payroll\\rdlcSalaryRegister.rdlc";
                        rsDS = new ReportDataSource("Payroll_SalaryRegister", dtTable);
                        ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        int mnth = 0;
                        int.TryParse(Month, out mnth);
                        String mname = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mnth) + " " + Year;
                        ReportParameter[] prmsSalReg = { new ReportParameter("PrmYear", mname) };
                        ReportViewer1.LocalReport.SetParameters(prmsSalReg);
                    }
                    break;


                case "rdlcLeaveBalance":
                    if (TeamID == 0 || TeamID != 0)
                    {

                        dtTable = new Leave_RequestBusinessObject().GetLeaveReportBalance(TeamID);
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Leave\\rdlcLeaveBalance.rdlc";
                            rsDS = new ReportDataSource("LeaveDataSet_LeaveBalanceReport", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("Prmteam", cmbteamname)
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;
                case "rdlcLeaveRequest":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new Leave_RequestBusinessObject().GetLeaveReportRequest(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"), TeamID);
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Leave\\rdlcLeaveRequest.rdlc";
                            rsDS = new ReportDataSource("LeaveDataSet_LeaveRequestReport", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;
                //case "rdlcWorkFromHome":
                //    if (fromDate != String.Empty && toDate != String.Empty)
                //    {
                //        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                //        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                //        dtToDate = dtToDate.AddDays(1);

                //        dtTable = new Leave_RequestBusinessObject().GetWorkFromHomeReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"), TeamID);
                //        if (dtTable.Rows.Count <= 0)
                //        {
                //            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                //        }
                //        else
                //        {
                //            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Leave\\rdlcWorkFromHome.rdlc";
                //            rsDS = new ReportDataSource("LeaveDataSet_WorkFromHomeReport", dtTable);
                //            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                //            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                //                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                //                               };
                //            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                //        }
                //    }
                //    break;
                case "rdlcEmpActivityLeave":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new Leave_RequestBusinessObject().GetLeaveReportActivity(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"), TeamID);
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Leave\\rdlcEmpActivityLeave.rdlc";
                            rsDS = new ReportDataSource("LeaveDataSet_LeaveAcitvityReport", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

                case "rdlcResignationExitManagementReport":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);
                        dtTable = new ExitManagementBusinessObject().GetExitManagementResignationReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));

                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\ExitManagement\\rdlcResignationExitManagementReport.rdlc";
                            rsDS = new ReportDataSource("ExitManagementDataSet_ExitManagementResignation", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

                case "rdlcTerminationExitManagementReport":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new ExitManagementBusinessObject().GetExitManagementTerminationReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\ExitManagement\\rdlcTerminationExitManagementReport.rdlc";
                            rsDS = new ReportDataSource("ExitManagementDataSet_ExitManagementTerminarion", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

                case "rdlcTeamWiseExitManagementReport":
                    if (TeamID == 0 || TeamID != 0)
                    {

                        dtTable = new ExitManagementBusinessObject().GetExitManagementTeamWiseReport(Convert.ToInt32(TeamID));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\ExitManagement\\rdlcTeamWiseExitManagementReport.rdlc";
                            rsDS = new ReportDataSource("ExitManagementDataSet_ExitManagementTeam", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("Prmteam", cmbteamname)
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;
                case "rdlcPromotionReport":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        string[] fdate = fromDate.Split(' ')[0].Split('/');
                        string[] tdate = toDate.Split(' ')[0].Split('/');
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new AppraisalBusinessObject().GetPromotionReport(fdate[2] + '-' + fdate[1] + '-' + fdate[0], dtToDate.Year.ToString() + '-' + dtToDate.Month.ToString() + '-' + dtToDate.Day.ToString(), TeamID);
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Appraisal\\rdlcPromotionReport.rdlc";
                            rsDS = new ReportDataSource("xsdAppraisal_Promotion", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        }
                    }
                    break;
                case "rdlcSalaryHikeReport":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        string[] fdate = fromDate.Split(' ')[0].Split('/');
                        string[] tdate = toDate.Split(' ')[0].Split('/');
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new AppraisalBusinessObject().GetSalaryHikeReport(fdate[2] + '-' + fdate[1] + '-' + fdate[0], dtToDate.Year.ToString() + '-' + dtToDate.Month.ToString() + '-' + dtToDate.Day.ToString(), TeamID);
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Appraisal\\rdlcSalaryHikeReport.rdlc";
                            rsDS = new ReportDataSource("xsdAppraisal_Hike", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                        }

                    }
                    break;

                case "rdlcCandidateDetailsbyConsultant":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new CandiateBusinessObject().GetCandidateDetailsbyConsultantReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Recruitment\\rdlcCandidateDetailsbyConsultant.rdlc";
                            rsDS = new ReportDataSource("RecruitmentDataSet_ConsultantDetails", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

                case "rdlcCandidateDetailsbyReferral":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new CandiateBusinessObject().GetCandidateDetailsbyReferralReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Recruitment\\rdlcCandidateDetailsbyReferral.rdlc";
                            rsDS = new ReportDataSource("RecruitmentDataSet_CandidateReferrelDetails", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

                case "rdlcCandidateInterviewDetailsReport":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new CandiateBusinessObject().GetCandidateInterviewDetailsReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Recruitment\\rdlcCandidateInterviewDetailsReport.rdlc";
                            rsDS = new ReportDataSource("RecruitmentDataSet_InterviewDetails", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

                case "rdlcOfferLetterIssuedReport":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new CandiateBusinessObject().GetOfferLetterIssuedReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Recruitment\\rdlcOfferLetterIssuedReport.rdlc";
                            rsDS = new ReportDataSource("RecruitmentDataSet_CandidateIssueOfferLetter", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

                case "rdlcShortlistedCandidateApplicationDetails":
                    if (fromDate != String.Empty && toDate != String.Empty)
                    {
                        DateTime.TryParseExact(fromDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtFromDate);
                        DateTime.TryParseExact(toDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToDate);
                        dtToDate = dtToDate.AddDays(1);

                        dtTable = new CandiateBusinessObject().GetShortlistedCandidateReport(dtFromDate.ToString("yyyy-MM-dd"), dtToDate.ToString("yyyy-MM-dd"));
                        if (dtTable.Rows.Count <= 0)
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\rdlcNoData.rdlc";
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\Recruitment\\rdlcShortlistedCandidateApplicationDetails.rdlc";
                            rsDS = new ReportDataSource("RecruitmentDataSet_ShortlistedCandidate", dtTable);
                            ReportViewer1.LocalReport.DataSources.Add(rsDS);
                            ReportParameter[] prmsLeaveFields = { new ReportParameter("PrmFromdt", dtFromDate.ToString("dd-MM-yyyy")),
                                                    new ReportParameter("PrmTodt", dtToDate.AddDays(-1).ToString("dd-MM-yyyy"))
                                               };
                            this.ReportViewer1.LocalReport.SetParameters(prmsLeaveFields);
                        }
                    }
                    break;

            }
        }
        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            String subRpt = e.ReportPath;
            int ID = 0;
            int EmployeeID = 0;
            switch (subRpt)
            {
                case "rdlcCareerSummary":
                   string aaEmployeeID = e.Parameters[0].Values[0].ToString();
                   if (aaEmployeeID != string.Empty)
                    {
                        Int32.TryParse(aaEmployeeID, out ID);
                        DataTable dttable = new TeamWiseBusinessObject().GetAllEmpCareerSumary(ID);
                        ReportDataSource CareerSummary = new ReportDataSource("AssetAssigned_AllEMPCareerSummary", dttable);
                        e.DataSources.Clear();
                        e.DataSources.Add(CareerSummary);
                   }
                    break;
                case "rdlcEducationDetails":
                    string EEmployeeID = e.Parameters[0].Values[0].ToString();
                    if (EEmployeeID != string.Empty)
                    {
                        Int32.TryParse(EEmployeeID,out ID );
                        DataTable Edttable = new TeamWiseBusinessObject().GetAllEmpEducationDetails(ID);
                        ReportDataSource Education = new ReportDataSource("AssetAssigned_AllEMPEducationDetails", Edttable);
                        e.DataSources.Clear();
                        e.DataSources.Add(Education);
                    }
                    break;
            }
        }
    }
}
