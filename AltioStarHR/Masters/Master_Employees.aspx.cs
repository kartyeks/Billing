using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRManager.Entity;
using System.Globalization;

namespace AltioStarHR.Masters
{
    public partial class Master_Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               // saveAllDetails();
            }
        }
        //public void saveAllDetails()
        //{
        //    Employees1 Empdetails = new Employees1();

        //    Empdetails.FirstName = personal_txtEmpFirstName.Value;
        //    Empdetails.LastName = personal_txtEmpMiddleName.Value;
        //    Empdetails.Initial = personal_txtEmpLastName.Value;
        //    Empdetails.ID = 0;
        //    Empdetails.EmpCode = personal_txtOtherID.Value;

        //    DateTime DateofBirth = DateTime.Today;
        //    DateofBirth = DateTime.ParseExact(hdndob.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    Empdetails.DOB = DateofBirth;

        //    if (hdngenderval.Value == "1")
        //    {
        //        Empdetails.Gender = "M";
        //    }
        //    else if (hdngenderval.Value == "2")
        //    {
        //        Empdetails.Gender = "F";
        //    }

        //    int msid;
        //    Int32.TryParse(hdnmsid.Value, out msid);
        //    Empdetails.MaritalStatusID = msid;


        //    Empdetails.PermanentAddress = txtPAddress.Value;
        //    Empdetails.CurrentAddress = txtCAddress.Value;
        //    Empdetails.MobileNumber = Mobile.Value;
        //    Empdetails.EmergencyContactNumber = Emergency.Value;
        //    Empdetails.EMailID = EmailID.Value;

        //    HttpPostedFile RequestFiles0 = Request.Files[0];
        //    Byte[] FilePhoto = null;
        //    if (RequestFiles0.ContentLength != 0)
        //    {
        //        FilePhoto = (Byte[])System.Array.CreateInstance(Type.GetType("System.Byte"), RequestFiles0.ContentLength);
        //    }

        //    Empdetails.Photo = FilePhoto;
        //    Empdetails.Save();
        //}
    }
}
