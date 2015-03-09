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

namespace AltioStarHR.Common
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnUserid.Value = objCurrUser.UserId.ToString();


            string strDetails = objCurrUser.GroupID.ToString(); //This will contain RoleID and RoleName and Logintype
            String[] strSpit;
            strSpit = strDetails.Split('_');
            if (strSpit.Length != 0)
            {
                hdnLoginType.Value = strSpit[2];
            }
            if (hdnLoginType.Value == "EMP")
            {
                //Response.Redirect("~/Login.aspx?ReturnPath=" + Server.UrlEncode(Request.Url.ToString()));
                chgpwd.Visible = false;
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                chgpwd.Visible = true;
                hdnEmployeeID.Value = objCurrUser.GroupName;
                hdnLoginName.Value = objCurrUser.UserName.ToString();
            }

        }
    }
}
