using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using IRCAKernel;
using HRManager;
using HRManager.DTO;
using HRManager.BusinessObjects;
using AltioStarHR.App_Code;
using HRManager.Entity.EmployeeLeave;
using HRManager.Entity.Appraisal;

namespace AltioStarHR.Appraisal
{
    public partial class EmployeeGoalUpload : System.Web.UI.Page
    {
        int EmpID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnEmpID.Value = objCurrUser.GroupName;
            Response.Cache.SetNoStore();
            if (IsPostBack)
            {
                try
                {
                    if (hdnID.Value == "0")
                    {
                        SaveFile(Convert.ToInt32(hdnIntimationID.Value), Convert.ToInt32(hdnEmployeeID.Value));
                    }
                    else{
                        UpdateFile(Convert.ToInt32(hdnID.Value));
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else {
                
                hdnIntimationID.Value = string.Concat(Request.QueryString["IntimationID"]);
                hdnEmployeeID.Value = string.Concat(Request.QueryString["EmployeeID"]);
                hdnID.Value = string.Concat(Request.QueryString["ID"]);
            }
        }
        protected void SaveFile(int IntimationID, int EmployeeID)
        {
            EmpID = Convert.ToInt32(hdnEmpID.Value);
            string strFile = string.Empty;
            HttpPostedFile RequestFiles0 = Request.Files[0];
            string FileName = RequestFiles0.FileName;
            if (FileName != string.Empty)
            {
                strFile = System.IO.Path.GetFileName(FileName);

                //if (strFile.Contains(".docx"))
                //{
                    IntimationAppraisalEntity objEmpDoc = new IntimationAppraisalEntity();
                    //objEmpDoc.GetAppraisalEmpID(IntimationID,  EmployeeID);
                    objEmpDoc.ID = 0;
                    objEmpDoc.IntimationID = IntimationID;
                    objEmpDoc.EmployeeID = EmployeeID;
                    objEmpDoc.GoalOn = DateTime.Now;
                    objEmpDoc.GoalBy = EmpID;
                    objEmpDoc.Goals = strFile;
                    objEmpDoc.GradeOn = new DateTime(1900, 01, 01);
                    objEmpDoc.GradeBy = 0;
                    objEmpDoc.Grade = String.Empty;
                    objEmpDoc.PromotionOn = new DateTime(1900, 01, 01);
                    objEmpDoc.PromotionBy = 0;
                    objEmpDoc.PromotionTo = 0;
                    objEmpDoc.SalaryHikeOn = new DateTime(1900, 01, 01);
                    objEmpDoc.SalaryHikeBy = 0;
                    objEmpDoc.SalaryHikeAmount = "0";
                    objEmpDoc.Save();
                    string _directoryName = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + IntimationID + "\\Employee";

                    if (!Directory.Exists(_directoryName))
                    {
                        Directory.CreateDirectory(_directoryName);
                    }
                    string SaveLocation = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + IntimationID + "\\Employee\\" + EmployeeID + "_" + strFile;
                    if (System.IO.File.Exists(SaveLocation))
                    {
                        System.IO.File.SetAttributes(SaveLocation, System.IO.FileAttributes.Normal);
                    }
                    string e = Path.GetExtension(strFile);
                    
                    uploadDocument.PostedFile.SaveAs(SaveLocation);
                    AppraisalNotification noti = new AppraisalNotification();
                    noti.GoalSubmissionNotifination(EmployeeID, SaveLocation,e);

                }

                Response.Write("<script>alert('Goal submitted successfully');window.returnValue=true;window.close(); </script>");
            //}
        }
        protected void UpdateFile(int ID)
        {
            EmpID = Convert.ToInt32(hdnEmpID.Value);
            string strFile = string.Empty;
            HttpPostedFile RequestFiles0 = Request.Files[0];
            string FileName = RequestFiles0.FileName;
            if (FileName != string.Empty)
            {
                strFile = System.IO.Path.GetFileName(FileName);

                Appraisal_Employee obj = new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID);
                IntimationAppraisalEntity objEmpDoc = new IntimationAppraisalEntity();
                objEmpDoc.Update(obj);
                //objEmpDoc.GetAppraisalEmpID(IntimationID,  EmployeeID);
                //objEmpDoc.ID = 0;
                //objEmpDoc.IntimationID = IntimationID;
                //objEmpDoc.EmployeeID = EmployeeID;
                objEmpDoc.GoalOn = DateTime.Now;
                objEmpDoc.GoalBy = EmpID;
                objEmpDoc.Goals = strFile;                
                objEmpDoc.Save();
                string _directoryName = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + objEmpDoc.IntimationID + "\\Employee";

                if (!Directory.Exists(_directoryName))
                {
                    Directory.CreateDirectory(_directoryName);
                }
                string SaveLocation = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + objEmpDoc.IntimationID + "\\Employee\\" + objEmpDoc.EmployeeID + "_" + strFile;
                if (System.IO.File.Exists(SaveLocation))
                {
                    System.IO.File.SetAttributes(SaveLocation, System.IO.FileAttributes.Normal);
                }

                string e = Path.GetExtension(strFile);
                uploadDocument.PostedFile.SaveAs(SaveLocation);
                AppraisalNotification noti = new AppraisalNotification();
                noti.GoalSubmissionNotifination(objEmpDoc.EmployeeID, SaveLocation,e);

            }

            Response.Write("<script>alert('Goal updated successfully');window.returnValue=true;window.close(); </script>");
        }
    }
}
