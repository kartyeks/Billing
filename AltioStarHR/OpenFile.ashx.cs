using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using HRManager.BusinessObjects; 
using HRManager.Entity.EmployeesInfo;
using HRManager.DTOEXT;
using System.IO;
using System.Text;
using HRManager.Entity;
using IRCAKernel;
using HRManager.Entity.Recruitment;
using Microsoft.Reporting.WebForms;

namespace AltioStarHR
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OpenFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {            
            String strDirectoryPath = String.Empty;           
            String openPath = String.Empty; // context.Request.QueryString["path"];
            String Empid = context.Request.QueryString["EmpID"];
            if (Empid == string.Empty) return;
            int EmpID = 0;
            Int32.TryParse(Empid, out EmpID);                     
            String LetterTypes = context.Request.QueryString["LetterType"];     
      
            if(LetterTypes != "OfferLetter")
                if (EmpID == 0) return;

            string strfilePath = string.Empty;
            string htmlfile = context.Request.QueryString["file"];

            String CAndID = context.Request.QueryString["CAndID"];
            int CandidateID = 0;
            Int32.TryParse(CAndID, out CandidateID);

            if (htmlfile != string.Empty && htmlfile != null)
            {
                strfilePath = htmlfile;
            }

            else
            {              
                if (LetterTypes == "RelievingLetter")
                {
                    strfilePath = "Relieving.htm";
                }
                if (LetterTypes == "ExperienceLetter")
                {
                    strfilePath = "Experience.htm";
                }  
                if(LetterTypes == "OfferLetter")
                {
                    strfilePath = "OfferLetter.htm";
                }
            }
            if (strfilePath == string.Empty) return;
            StringBuilder strResultB = null;

            String mode = context.Request.QueryString["mode"];
            String RootPath = AppDomain.CurrentDomain.BaseDirectory;

            if (mode == "fileopen")
            {
                strDirectoryPath = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "/HTMLEditor/");
                try
                {
                    context.Response.ContentType = "text/plain";
                    if (!Directory.Exists(Path.GetDirectoryName(strDirectoryPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(strDirectoryPath));

                    //openPath = @"E:\Projects\TitanHRMS\TitanHRMS\HTMLEditor\HTMLForm\" + openPath;
                    openPath = AppDomain.CurrentDomain.BaseDirectory + "HTMLEditor\\HTMLForm\\" + strfilePath;

                    if (!File.Exists(openPath)) return;
                    String fileName = Path.GetFileNameWithoutExtension(openPath);


                    IS91.Services.MIL.Html.HtmlDocument editDocument = new IS91.Services.MIL.Html.HtmlDocument();

                    string strFileName = Path.GetFileName(openPath);

                    if (LetterTypes == "OfferLetter")
                    {
                        if (new Candidate_HTMLEditorDetailsBusinessObject().DoesCandidateLetterExists(CandidateID, strFileName))
                        {
                            string strResult = string.Empty;
                            DataTable dtTable = new Candidate_HTMLEditorDetailsBusinessObject().getCandidateLetter(CandidateID, strFileName);
                            if (dtTable != null && dtTable.Rows.Count > 0)
                            {
                                strResult = dtTable.Rows[0]["HTMLContent"].ToString();
                            }
                            strResultB = new StringBuilder(strResult);
                        }
                        else
                        {
                            strResultB = new StringBuilder(System.IO.File.ReadAllText(openPath));
                            DataTable dt = new Candidate_Hired_SalaryBusinessObject().GetCandidateandSalaryDetails(CandidateID);
                            string nAME = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["MiddleName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                            string jOINdATE = ((DateTime)dt.Rows[0]["JoiningDate"]).ToString("dd/MM/yyyy");
                            double CTC = (double)dt.Rows[0]["CTC"];
                            String ESOP = dt.Rows[0]["ESOP"].ToString();
                            double yrbasic = Math.Round(CTC * 40 / 100);
                            double mntbasic = Math.Round(yrbasic / 12);
                            double yrhra = Math.Round(yrbasic * 40 / 100);
                            double mnthra = Math.Round(yrhra / 12);
                            double yrCA = 0;
                            double yrmedrei = 0;

                            DataTable dtTable = new Setting_ConfigurationBusinessObject().GetDataTable();
                            if (dtTable != null && dtTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtTable.Rows.Count; i++)
                                {
                                    if (dtTable.Rows[i]["Name"].ToString() == "Annual Conveyance Allowance")
                                        yrCA = Convert.ToDouble(dtTable.Rows[i]["Value"]);
                                    if (dtTable.Rows[i]["Name"].ToString() == "Medical Reimbursement")
                                        yrmedrei = Convert.ToDouble(dtTable.Rows[i]["Value"]);
                                }
                            }

                            double PF = Math.Round((yrbasic * 12) / 100);
                            double mntPF = Math.Round(PF / 12, 2);
                            double yrall = Math.Round((CTC - yrbasic - yrhra - yrCA - PF - (mntbasic + yrmedrei)));
                            double mntall = Math.Round(yrall / 12);
                            double mntCA = Math.Round(yrCA / 12);
                            double anualtotal = Math.Round(yrbasic + yrhra + yrall + yrCA);
                            double mntlytotal = Math.Round(mntbasic + mnthra + mntall + mntCA);
                            double mntleave = Math.Round(mntbasic / 12);
                            double mntmedrei = Math.Round(yrmedrei / 12);
                            double anualtotalB = Math.Round(mntbasic + yrmedrei);
                            double mntlytotalB = Math.Round(mntleave + mntmedrei);
                            double anualtotalAB = Math.Round(anualtotal + anualtotalB);
                            double mntlytotalAB = Math.Round(mntlytotal + mntlytotalB);
                            double anualtotalC = Math.Round(PF);
                            double mntlytotalC = Math.Round(mntPF);
                            double anualtotalABC = Math.Round(anualtotalAB + anualtotalC);
                            double mntlytotalABC = Math.Round(mntlytotalAB + mntlytotalC);

                            if (dt.Rows.Count > 0)
                            {
                                strResultB = strResultB.Replace("{Prm!date}", DateTime.Now.ToString("dd/MM/yyyy"));
                                strResultB = strResultB.Replace("{Prm!Name}", nAME);
                                strResultB = strResultB.Replace("{Prm!JoiningDate}", jOINdATE);
                                strResultB = strResultB.Replace("{Prm!CTC}", CTC.ToString());
                                strResultB = strResultB.Replace("{Prm!ESOP}", ESOP);
                                strResultB = strResultB.Replace("{Prm!annualbasic}", yrbasic.ToString());
                                strResultB = strResultB.Replace("{Prm!monthlybasic}", mntbasic.ToString());
                                strResultB = strResultB.Replace("{Prm!annualhouse}", yrhra.ToString());
                                strResultB = strResultB.Replace("{Prm!monthhouse}", mnthra.ToString());
                                strResultB = strResultB.Replace("{Prm!annualallowance}", yrall.ToString());
                                strResultB = strResultB.Replace("{Prm!monthallowance}", mntall.ToString());
                                strResultB = strResultB.Replace("{Prm!annualconallowance}", yrCA.ToString());
                                strResultB = strResultB.Replace("{Prm!monthconallowance}", mntCA.ToString());
                                strResultB = strResultB.Replace("{Prm!annualtotal}", anualtotal.ToString());
                                strResultB = strResultB.Replace("{Prm!monthtotal}", mntlytotal.ToString());
                                strResultB = strResultB.Replace("{Prm!annualleave}", mntbasic.ToString());
                                strResultB = strResultB.Replace("{Prm!monthleave}", mntleave.ToString());
                                strResultB = strResultB.Replace("{Prm!annualmedical}", yrmedrei.ToString());
                                strResultB = strResultB.Replace("{Prm!monthmedical}", mntmedrei.ToString());
                                strResultB = strResultB.Replace("{Prm!annualtotalb}", anualtotalB.ToString());
                                strResultB = strResultB.Replace("{Prm!monthtotalb}", mntlytotalB.ToString());
                                strResultB = strResultB.Replace("{Prm!annualtotalfixb}", anualtotalAB.ToString());
                                strResultB = strResultB.Replace("{Prm!monthtotalfixb}", mntlytotalAB.ToString());
                                strResultB = strResultB.Replace("{Prm!annualprovident}", PF.ToString());
                                strResultB = strResultB.Replace("{Prm!monthprovident}", mntPF.ToString());
                                strResultB = strResultB.Replace("{Prm!annualtoatlc}", anualtotalC.ToString());
                                strResultB = strResultB.Replace("{Prm!monthtotalc}", mntlytotalC.ToString());
                                strResultB = strResultB.Replace("{Prm!annualtoatlfixedpay}", anualtotalABC.ToString());
                                strResultB = strResultB.Replace("{Prm!monthtotalfixedpay}", mntlytotalABC.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (new HTMLEditorDetailsBusinessObject().IsEmployeeLetterExists(EmpID, strFileName))
                        {
                            string strResult = string.Empty;
                            DataTable dtTable = new HTMLEditorDetailsBusinessObject().getEmpLetter(EmpID, strFileName);
                            if (dtTable != null && dtTable.Rows.Count > 0)
                            {
                                strResult = dtTable.Rows[0]["HTMLContent"].ToString();
                            }
                            strResultB = new StringBuilder(strResult);
                        }
                        else
                        {
                            strResultB = new StringBuilder(System.IO.File.ReadAllText(openPath));
                            Employee emp = new Employee(EmpID);
                            String CompanyName = IS91.Services.Common.GetAppSetting("CompanyName");
                            String Place = new Location(emp.OccupationInfo.LocationID).LocationName;
                            String Name = emp.PersonalInfo.FirstName + " " + emp.PersonalInfo.MiddleName + " " + emp.PersonalInfo.LastName;
                            String companyName = string.Empty;
                            String FromDate = emp.OccupationInfo.JoiningDate.ToString("dd/MM/yyyy");
                            String LastWorkingDate = emp.OccupationInfo.ExitDate.ToString("dd/MM/yyyy");
                            String Designation = new Designation(emp.OccupationInfo.DesignationID).DesignationName;
                            String TeamName = new TeamDetail(emp.OccupationInfo.TeamID).TeamName;

                            if (fileName == "Relieving")
                            {
                                strResultB = strResultB.Replace("{Prm!place}", Place);
                                strResultB = strResultB.Replace("{Prm!date}", DateTime.Now.ToString("dd/MM/yyyy"));
                                strResultB = strResultB.Replace("{Prm!Name}", Name);
                                strResultB = strResultB.Replace("{Prm!LastWorkingDate}", LastWorkingDate);
                            }
                            else if (fileName == "Experience")
                            {
                                strResultB = strResultB.Replace("{Prm!place}", Place);
                                strResultB = strResultB.Replace("{Prm!date}", DateTime.Today.ToString("dd/MM/yyyy"));
                                strResultB = strResultB.Replace("{Prm!EmpName}", Name);
                                strResultB = strResultB.Replace("{Prm!Team}", TeamName);
                                strResultB = strResultB.Replace("{Prm!Designation}", Designation);
                                strResultB = strResultB.Replace("{Prm!frmdate}", FromDate);
                                strResultB = strResultB.Replace("{Prm!todate}", LastWorkingDate);
                            }
                        }
                    }

                    editDocument.LoadHtml(File.ReadAllText(openPath));
                    IS91.Services.MIL.Html.HtmlNode BodyTag = editDocument.DocumentNode.SelectSingleNode("//body");
                    if (BodyTag != null)
                    {
                        BodyTag.InnerHtml = String.Concat(strResultB, "");
                    }
                    String tmpString = editDocument.DocumentNode.OuterHtml.ToString();

                    IS91.Services.MIL.Html.HtmlNode metaNode = editDocument.DocumentNode.SelectSingleNode("meta[@http-equiv='Content-Type']");
                    if (metaNode == null)
                    {
                        metaNode = editDocument.CreateElement("meta");
                        metaNode.Attributes.Append("http-equiv", "Content-Type");
                        metaNode.Attributes.Append("content", "text/html; CHARSET=utf-8");
                        editDocument.DocumentNode.AppendChild(metaNode);
                        tmpString = editDocument.DocumentNode.OuterHtml.ToString();
                    }
                    context.Response.Write(tmpString);
                    return;
                }
                catch
                {
                    context.Response.Write(String.Empty);
                }
            }
            else if (mode == "email")
            {
                MailContent objEmail = new MailContent();
                string strFileExt = string.Empty;
                string mimeType, encoding, fileNameExtension;
                Warning[] warnings;
                string[] streams;
                ReportViewer ReportViewer1 = new ReportViewer();
                StringBuilder strResultBuild = null;
                IS91.Services.MIL.Html.HtmlDocument editDocument = new IS91.Services.MIL.Html.HtmlDocument();
                string strResult = string.Empty;
                string strFileName = Path.GetFileName(strfilePath);
                if (new HTMLEditorDetailsBusinessObject().IsEmployeeLetterExists(EmpID, strFileName))
                {
                    DataTable dtTable = new HTMLEditorDetailsBusinessObject().getEmpLetter(EmpID, strFileName);
                    if (dtTable != null && dtTable.Rows.Count > 0)
                    {
                        strResult = dtTable.Rows[0]["HTMLContent"].ToString();
                    }
                    strResultBuild = new StringBuilder(strResult);

                    //ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\ExitManagement\\RelievingLetter.rdlc";
                    //ReportDataSource rsrdlcOL = new ReportDataSource("ExitManagementDataSet_RelievingLetter", dtTable);
                    //ReportViewer1.LocalReport.DataSources.Add(rsrdlcOL);

                    //editDocument.LoadHtml(File.ReadAllText(strfilePath));
                    //IS91.Services.MIL.Html.HtmlNode BodyTag = editDocument.DocumentNode.SelectSingleNode("//body");
                    //if (BodyTag != null)
                    //{
                    //    BodyTag.InnerHtml = String.Concat(strResult, "");
                    //}
                    //String tmpString = editDocument.DocumentNode.OuterHtml.ToString();
                    //IS91.Services.MIL.Html.HtmlNode metaNode = editDocument.DocumentNode.SelectSingleNode("meta[@http-equiv='Content-Type']");
                    //if (metaNode == null)
                    //{
                    //    metaNode = editDocument.CreateElement("meta");
                    //    metaNode.Attributes.Append("http-equiv", "Content-Type");
                    //    metaNode.Attributes.Append("content", "text/html; CHARSET=utf-8");
                    //    editDocument.DocumentNode.AppendChild(metaNode);
                    //    tmpString = editDocument.DocumentNode.InnerHtml.ToString();
                    //}

                    string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "/Templates/");
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    String file = "";
                    if (LetterTypes == "RelievingLetter")
                    {
                         file = String.Concat(path, "Relieving.htm");
                    }
                    else
                    {
                         file = String.Concat(path, "Experience.htm");
                    }
                    if (File.Exists(file))
                        File.Delete(file);
                    // Create the file.
                    Byte[] info = null;
                    using (FileStream fs = File.Create(file))
                    { 
                        info = new UTF8Encoding(true).GetBytes(strResult);
                        // Add html information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //strFileExt = "pdf";
                    //strDirectoryPath = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "/Templates/");

                    //Byte[] pdfContent = ReportViewer1.LocalReport.Render(strFileExt.ToUpper(), null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                    //if (!Directory.Exists(Path.GetDirectoryName(strDirectoryPath)))
                    //    Directory.CreateDirectory(Path.GetDirectoryName(strDirectoryPath));

                    //String filePath = String.Concat(strDirectoryPath, "Offer_Letter.", strFileExt);

                    //if (File.Exists(filePath))
                    //    File.Delete(filePath);
                    //using (FileStream fs = File.Create(filePath))
                    //{
                    //    fs.Write(pdfContent, 0, pdfContent.Length);
                    //}
                    if (LetterTypes == "RelievingLetter")
                    {
                        String EmailMessageStr = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\Relieving.htm"));
                        EmailMessageStr = EmailMessageStr.Replace("{Prm!CompanyName}",
                                        IS91.Services.Common.GetAppSetting("CompanyName"));
                        objEmail.AddToAddress(dtTable.Rows[0]["EmailID"].ToString());
                        objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                        objEmail.Subject = "Relieving Letter";
                        objEmail.Body = EmailMessageStr;
                        objEmail.AddAttachment(info, objEmail.Subject + ".doc", "application/msword");
                        IRCAMailHandler.SendMail(objEmail);
                        info = null;
                    }
                    else
                    {
                        String EmailMessageStr = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\Experience.htm"));
                        EmailMessageStr = EmailMessageStr.Replace("{Prm!CompanyName}",
                                        IS91.Services.Common.GetAppSetting("CompanyName"));
                        objEmail.AddToAddress(dtTable.Rows[0]["EmailID"].ToString());
                        objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                        objEmail.Subject = "Experience Letter";
                        objEmail.Body = EmailMessageStr;
                        objEmail.AddAttachment(info, objEmail.Subject + ".doc", "application/msword");
                        IRCAMailHandler.SendMail(objEmail);
                        info = null;
                    }
                    
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
