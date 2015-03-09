using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AltioStarHR.App_Code;

namespace AltioStarHR.Masters
{
    public partial class Master_Holidays : System.Web.UI.Page
    {
        public static readonly String ModuleName = "li_Setup_Holiday";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            //hdnEmployeeID.Value = objCurrUser.GroupName;
            hdnEmployeeID.Value = objCurrUser.GroupName;
        }
    }
}
