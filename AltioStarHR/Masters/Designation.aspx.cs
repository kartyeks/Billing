using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltioStarHR.Masters
{
    public partial class Designation1 : System.Web.UI.Page
    {
        public static readonly String ModuleName = "li_Setup_Designation";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnmodule.Value = ModuleName;
            //hdnEmployeeID.Value = objCurrUser.GroupID.ToString();// This is an EmployeeID // IS91.Services.Common.GetAppSetting("EmployeeID");
            hdnEmployeeID.Value = objCurrUser.GroupName;
        }
    }

}
 
