using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using IS91.Services;
using IS91.Services.Web;
using IS91.Services.DataBlock;
using IRCAKernel;
using HRManager;
using HRManager.DTO;
using HRManager.BusinessObjects;

namespace AltioStarHR.Masters
{
    public partial class UploadFile : System.Web.UI.Page
    {
        int ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (IsPostBack)
            {
                try
                {
                    Int32.TryParse(hdnID.Value, out ID);
                    HttpPostedFile RequestFiles0 = Request.Files[0];
                    IRCAKernel.IRCAExceptionHandler.HandleMessage("file length:" + RequestFiles0.ContentLength);
                    Byte[] fileData = (Byte[])System.Array.CreateInstance(Type.GetType("System.Byte"), RequestFiles0.ContentLength);
                    RequestFiles0.InputStream.Read(fileData, 0, RequestFiles0.ContentLength);

                    if (ID != 0)
                        SaveFile(ID, fileData);
                }
                catch (Exception ex)
                {
                    IRCAExceptionHandler.HandleException(ex);
                    throw (ex);
                }
            }
            else
            {
                hdnID.Value = string.Concat(Request.QueryString["ID"]);
            }
        }
        protected void SaveFile(int ID, Byte[] fileData)
        {
            try
            {
                Master_Employees objEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(ID);
                if (objEmp != null)
                {
                    IRCAKernel.IRCAExceptionHandler.HandleMessage("actual length:" + fileData.Length);
                    objEmp.Photo = fileData;
                    new Master_EmployeesBusinessObject().Update(objEmp);
                    Response.Write("<script>window.returnValue=true;window.close(); </script>");
                }
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                throw (ex);
            }
        }
    }
}
