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
using System.IO;
using AltioStarHR.App_Code;

namespace AltioStarHR.Masters
{
    public partial class InvestmentGroup : System.Web.UI.Page
    {
        //public static readonly String ModuleName = "li_Setup_Relation";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            //hdnmodule.Value = ModuleName;

            //hdnEmployeeID.Value = objCurrUser.GroupID.ToString();// This is an EmployeeID // IS91.Services.Common.GetAppSetting("EmployeeID");
           // hdnEmployeeID.Value = objCurrUser.GroupName;
        }
    }
}