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

namespace AltioStarHR.Masters
{
    public partial class UploadDocument : System.Web.UI.Page
    {
        int EmpID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (IsPostBack)
            {
                try
                {
                    Int32.TryParse(hdnEmpID.Value, out EmpID);
                    if (EmpID != 0)
                        SaveFile(EmpID);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                hdnEmpID.Value = string.Concat(Request.QueryString["ID"]);

            }
        }
        protected void SaveFile(int EmpID)
        {
            Master_Employees objEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(EmpID);

            if (objEmp != null)
            {
                // declare the directory path
                string _directoryName = Server.MapPath("~/Resources") + "\\EmployeeDocuments\\" + EmpID;

                // check folder exists
                if (Directory.Exists(_directoryName))
                {
                    // ok, the directory exists
                }
                // if not then create
                else
                {
                    Directory.CreateDirectory(_directoryName);
                }
                string strFile = string.Empty;
                HttpPostedFile RequestFiles0 = Request.Files[0];
                string FileName = RequestFiles0.FileName;
                if (FileName != string.Empty)
                {
                    strFile = System.IO.Path.GetFileName(FileName);

                    string SaveLocation = Server.MapPath("~/Resources") + "\\EmployeeDocuments\\" + EmpID + "\\" + strFile;
                    if (System.IO.File.Exists(SaveLocation))
                    {
                        System.IO.File.SetAttributes(SaveLocation, System.IO.FileAttributes.Normal);
                    }

                    uploadDocument.PostedFile.SaveAs(SaveLocation);

                }

                Employee_Documents objEmpDoc = new Employee_Documents();
                string Title = ""; string Name = "";
                Title = documentTitle.Value;
                Name = System.IO.Path.GetFileName(FileName);
                objEmpDoc.EmployeeID = EmpID;
                objEmpDoc.DocumentTitle = Title;
                objEmpDoc.DocumentName = strFile;// Name;
                Employee_DocumentsBusinessObject objEmpDocBO = new Employee_DocumentsBusinessObject();
                objEmpDocBO.Create(objEmpDoc);

                Response.Write("<script>window.returnValue=true;window.close(); </script>");

            }

        }
    }
}
