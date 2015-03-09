using System;
using System.Web;
using System.Web.UI;
using HRManager.DTO;
using HRManager.DTOEXT;
using HRManager.Entity.ExitManagement;
using System.IO;
using HRManager.BusinessObjects;

namespace AltioStarHR.ExitManagement
{
    public partial class UploadNdForm : Page
    {
        protected UploadNdForm()
        {
            EmpId = 0;
            int id = 0;
        }

        private int EmpId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnEmployeeID.Value = objCurrUser.GroupName;
            Response.Cache.SetNoStore();
            if (IsPostBack)
            {
                try
                {
                    int EmpId = Convert.ToInt32(hdnEmployeeID.Value);
                    int id = Convert.ToInt32(hdnID.Value);
                    if (EmpId != 0)
                        SaveFile(id);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                hdnID.Value = string.Concat(Request.QueryString["ID"]);
            }
        }
        private void SaveFile(int id)
        {
            id = Convert.ToInt32(hdnID.Value);
            EmpId = Convert.ToInt32(hdnEmployeeID.Value);
            HttpPostedFile requestFiles0 = Request.Files[0];
            var fileName = requestFiles0.FileName;
            if (fileName != string.Empty)
            {
                string strFile = Path.GetFileName(fileName);

                UploadExitManagementEXT em = new ExitManagementBusinessObject().UploadExitManagement(id);
                var objEmpDoc = new ExitMangement();
                if (em.EmpExitID == EmpId)
                {
                    String ISUpdate = new ExitMangement().ISActiveUpdate(EmpId);
                }
                objEmpDoc.EmployeeId = em.EmployeeID;
                objEmpDoc.ExitTypeId = em.ExitTypeID;
                objEmpDoc.ExitDate = em.ExitDate;
                objEmpDoc.DocumentName = strFile;
                objEmpDoc.IsActive = true;
              
                objEmpDoc.Save();
                string directoryName = Server.MapPath("~/Resources") + "\\ExitManagement\\";

                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                var saveLocation = Server.MapPath("~/Resources") + "\\ExitManagement\\" + objEmpDoc.EmployeeId + "_" + strFile;
                if (File.Exists(saveLocation))
                {
                    File.SetAttributes(saveLocation, FileAttributes.Normal);
                }

                uploadDocument.PostedFile.SaveAs(saveLocation);
                //ExitMangement noti = new ExitMangement();
                //noti.ExitManagementNotification(obj.EmployeeID, SaveLocation);
                var notification = new ExitManagementNotification();
                notification.EmployeeExitManagement(em.EmployeeID, em.ExitDate); 
            }

            Response.Write("<script>alert('Clearance form Uploaded Successfully');window.returnValue=true;window.close(); </script>");
        }
    }
}
