using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AltioStarHR.App_Code;

namespace AltioStarHR
{
    public partial class RoleMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            //hdnmodule.Value = ModuleName;
            //hdnEmployeeID.Value = objCurrUser.GroupID.ToString();// This is an EmployeeID // IS91.Services.Common.GetAppSetting("EmployeeID");
            //hdnEmployeeID.Value = objCurrUser.GroupName;
            hdnEmployeeID.Value = string.Concat(objCurrUser.GroupName);
            hdnLoggedUserID.Value = string.Concat(objCurrUser.UserId);

            //Response.Cache.SetNoStore();

            ////hdnmodule.Value = Convert.ToString(Request.QueryString["Modulename"]).Replace("^", "&");
            //ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            //hdnRoleid.Value = SessionManager.Session_Role;// SessionManager.Session_RoleID;
        }
    }
}
