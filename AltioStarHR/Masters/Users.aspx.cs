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

namespace AltioStarHR.Masters
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnLoginType.Value = Request.QueryString["mod"];
            if (hdnLoginType.Value == "EMP")
            {
                hdnEmpName.Value = Request.QueryString["empName"];
                hdnEmployeeID.Value = Request.QueryString["empID"];
            }
            else if (hdnLoginType.Value == "CNT")
            {
                hdnCntName.Value = Request.QueryString["consultantName"];
                hdnConsultantID.Value = Request.QueryString["cnsID"];
            }
            
        }
    }
}
