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

namespace AltioStarHR.LoanManagement
{
    public partial class Loan : System.Web.UI.Page
    {
        //public static readonly String ModuleName = "li_Employees_Loan_Loan";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();

        }
    }
}