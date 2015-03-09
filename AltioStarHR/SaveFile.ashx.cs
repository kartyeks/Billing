//using System;
//using System.Collections;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.Services;
//using System.Web.Services.Protocols;
//using System.Xml.Linq;
//using System.IO;
//using System.Text;
//using HRManager.DTO;
//using HRManager.BusinessObjects;

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
using HRManager.DTO;
using HRManager.Entity.Recruitment;

namespace AltioStarHR
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class SaveFile : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        static String defalutFileContent = "{0}";
        String AppRoot = String.Concat(AppDomain.CurrentDomain.BaseDirectory);
        String EmpID = string.Empty;
        String CandID = string.Empty;
        String LetterTypes = string.Empty;
        //ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);

        public void ProcessRequest(HttpContext context)
        {

            // String savePath = context.Request.QueryString["filePath"];
            String savePath = string.Empty;
            EmpID = context.Request.QueryString["EmpID"];
            CandID = context.Request.QueryString["CAndID"];
            if (EmpID == string.Empty) return;
            int intEmpID = 0;
            Int32.TryParse(EmpID, out intEmpID);
            string EmpType = string.Empty;
            string EmpSubType = string.Empty;
            LetterTypes = context.Request.QueryString["LetterType"];  

            if (LetterTypes != "OfferLetter")
                if (intEmpID == 0) return;

            string htmlfile = context.Request.QueryString["file"];
            if (htmlfile != string.Empty)
            {
                savePath = htmlfile;
            }
            else
            {                         
                if (LetterTypes == "RelievingLetter")
                {
                    savePath = "Relieving.htm";
                }
                if (LetterTypes == "ExperienceLetter")
                {
                    savePath = "Experience.htm";
                }
                if (LetterTypes == "OfferLetter")
                {
                    savePath = "OfferLetter.htm";
                }
            }
            if (savePath == string.Empty) return;

            context.Response.ContentType = "text/plain";
            String selectedFile = Path.GetFileName(String.Concat(savePath, String.Empty));
            if (String.IsNullOrEmpty(selectedFile))
            {
                context.Response.Write("Error while saving the contents."); return;
            }

            selectedFile = String.Concat(AppRoot, "HTMLEditor\\HTMLForm\\", selectedFile);
            // selectedFile = Path.GetFullPath(savePath);
            StreamReader oStrmRdr = new StreamReader(context.Request.InputStream);
            Stream baseStream = oStrmRdr.BaseStream;
            RepositionStream(ref baseStream);

            try
            {
                File.SetAttributes(selectedFile, FileAttributes.Normal);
                String Contents = FixFileContents(selectedFile, oStrmRdr.ReadToEnd().Trim());

                IS91.Services.MIL.Html.HtmlDocument docTemp = new IS91.Services.MIL.Html.HtmlDocument();
                docTemp.LoadHtml(Contents);
                IS91.Services.MIL.Html.HtmlNode metaNode = docTemp.DocumentNode.SelectSingleNode("meta[@http-equiv='Content-Type']");
                if (metaNode == null)
                {
                    metaNode = docTemp.CreateElement("meta");
                    metaNode.Attributes.Append("http-equiv", "Content-Type");
                    metaNode.Attributes.Append("content", "text/html; CHARSET=utf-8");
                    docTemp.DocumentNode.AppendChild(metaNode);
                    Contents = docTemp.DocumentNode.OuterHtml.ToString();
                }

                string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "/Templates/");
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                String file = "";
                if (LetterTypes == "RelievingLetter")
                {
                     file = String.Concat(path, "Relieving.htm");
                }
                else if (LetterTypes == "OfferLetter")
                {
                    file = String.Concat(path, "OfferLetter.htm");
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
                    info = new UTF8Encoding(true).GetBytes(Contents);                    
                    fs.Write(info, 0, info.Length);
                }         
                File.WriteAllText(file, Contents);
                saveToDatabase(selectedFile, Contents, context);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        protected void saveToDatabase(String fileName, String htmlContent, HttpContext context)
        {
            try
            {
                if (LetterTypes == "OfferLetter")
                {
                    String Res = String.Empty;
                    CandidateHTMLEditorDetails edit = new CandidateHTMLEditorDetails().GetAllCandidateHTMLData(Int32.Parse(CandID));
                    String strfileName = Path.GetFileName(fileName);
                    if (edit != null)
                    {
                        edit.CandidateID = Int32.Parse(CandID);
                        edit.EditedByUser = Convert.ToInt32(1);
                        edit.EditedDateTime = DateTime.Now;
                        edit.HTMLFileName = strfileName;
                        edit.HTMLContent = htmlContent;
                        Res = edit.Save();
                    }
                    if (Res == String.Empty)
                    {
                        CandidateInterviewStatus intv = new CandidateInterviewStatus().GeInterviewStatusByCandidateID(Int32.Parse(CandID));
                        intv.CandidateStatus = CandidateStatusDescription.OfferIssued;
                        intv.Save();
                    }
                }
                else
                {
                    HTMLEditorDetails EditedHTMLDetail = new HTMLEditorDetails();
                    String strfileName = Path.GetFileName(fileName);
                    if (EditedHTMLDetail != null)
                    {
                        EditedHTMLDetail.EditedByUser = 1;
                        EditedHTMLDetail.EMPID = Int32.Parse(EmpID);
                        EditedHTMLDetail.EditedDateTime = DateTime.Now;
                        EditedHTMLDetail.HTMLFileName = strfileName;
                        EditedHTMLDetail.HTMLContent = htmlContent;
                        new HTMLEditorDetailsBusinessObject().Create(EditedHTMLDetail);
                        //While giving Relieving and Experienced letters the employee will deactivate and will not display in grid
                        Master_Employees objEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(Int32.Parse(EmpID));
                        if (objEmp != null)
                        {
                            objEmp.IsActive = false;
                            new Master_EmployeesBusinessObject().Update(objEmp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        String FixFileContents(String FilePath, String FileContent)
        {
            if (!File.Exists(FilePath))
            {
                return String.Format(defalutFileContent, FileContent);
            }
            IS91.Services.MIL.Html.HtmlDocument mDocument = new IS91.Services.MIL.Html.HtmlDocument();
            mDocument.LoadHtml(File.ReadAllText(FilePath));
            IS91.Services.MIL.Html.HtmlNode BodyTag = mDocument.DocumentNode.SelectSingleNode("//body");
            if (BodyTag == null)
            {
                return String.Format(defalutFileContent, FileContent);
            }
            BodyTag.InnerHtml = String.Concat(FileContent, "");
            return mDocument.DocumentNode.OuterHtml;
        }

        void RepositionStream(ref Stream xStream)
        {
            if (!(xStream == null))
            {
                if ((xStream.Length > 0))
                {
                    if ((xStream.Position != 0))
                    {
                        xStream.Position = 0;
                    }
                }
            }
        }
    }
}
