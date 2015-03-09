using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltioStarHR.Inventory
{
    public partial class AssetOutgoingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnLoggedinID.Value = string.Concat(objCurrUser.GroupName);
            hdnOutgoingID.Value = string.Concat(Request.QueryString["ougoingassetid"]);
        }
    }
}
