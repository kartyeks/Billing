using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using IS91.Services;
using IS91.Services.Web;
using IS91.Services.License;
using ApplicationManager;
//using CommonManager.BusinessObjects;
//using CommonManager.Entity;
//using CommonManager.DTO;


namespace AltioStarHR.App_Code
{
    public class SessionManager
    {
        #region Fields

        private static readonly String SessErrMsg = "Session has expired! Please Login again";

        #endregion

        #region Session Property

        public static String Session_EmpID
        {
            get
            {
                if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["EmpID"])))
                    RedirectToLogin();

                return Convert.ToString(HttpContext.Current.Session["EmpID"]);
            }
            set
            {
                HttpContext.Current.Session["EmpID"] = value;
            }

        }
        public static String Session_RoleID
        {
            get
            {
                if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["RoleID"])))
                    RedirectToLogin();

                return Convert.ToString(HttpContext.Current.Session["RoleID"]);
            }
            set
            {
                HttpContext.Current.Session["RoleID"] = value;
            }

        }
       
        public static String Session_EmpTypeID
        {
            get
            {
                if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["EmpTypeID"])))
                    RedirectToLogin();

                return Convert.ToString(HttpContext.Current.Session["EmpTypeID"]);
            }
            set
            {
                HttpContext.Current.Session["EmpTypeID"] = value;
            }

        }

        public static String Session_LoginType
        {
            get
            {
                if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["LoginType"])))
                    RedirectToLogin();

                return Convert.ToString(HttpContext.Current.Session["LoginType"]);
            }
            set
            {
                HttpContext.Current.Session["LoginType"] = value;
            }

        }
        public static String Session_EmpName
        {
            get
            {
                if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["EmpName"])))
                    RedirectToLogin();

                return Convert.ToString(HttpContext.Current.Session["EmpName"]);
            }
            set
            {
                HttpContext.Current.Session["EmpName"] = value;
            }

        }
        public static String Session_Role
        {
            get
            {
                if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["Role"])))
                    RedirectToLogin();

                return Convert.ToString(HttpContext.Current.Session["Role"]);
            }
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }

        }
        //public static String Session_GroupName
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["GroupName"])))
        //            RedirectToLogin();

        //        return Convert.ToString(HttpContext.Current.Session["GroupName"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["GroupName"] = value;
        //    }

        //}

        //public static Int32 Session_EmployeeID
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["EmployeeID"] == null)
        //            RedirectToLogin();

        //        return Convert.ToInt32(HttpContext.Current.Session["EmployeeID"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["EmployeeID"] = value;
        //    }

        //}

        //public static String Session_UserName
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["UserName"])))
        //            RedirectToLogin();

        //        return Convert.ToString(HttpContext.Current.Session["UserName"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["UserName"] = value;
        //    }

        //}

        public static Int32 Session_UserID
        {
            get
            {
                if (HttpContext.Current.Session["UserID"] == null ||
                    Convert.ToInt32(HttpContext.Current.Session["UserID"]) == 0)
                    RedirectToLogin();

                return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }

        }

        //public static Int32 Session_Role
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["Role"] == null ||
        //            Convert.ToInt32(HttpContext.Current.Session["Role"]) == 0)
        //            RedirectToLogin();

        //        return Convert.ToInt32(HttpContext.Current.Session["Role"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["Role"] = value;
        //    }

        //}
        //public static String Session_Role
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["Role"] == null ||
        //            Convert.ToInt32(HttpContext.Current.Session["Role"]) == 0)
        //            RedirectToLogin();

        //        return Convert.ToString(HttpContext.Current.Session["Role"]);               
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["Role"] = value;
        //    }

        //}

        //public static String Session_Password
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["Password"])))
        //            RedirectToLogin();

        //        return Convert.ToString(HttpContext.Current.Session["Password"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["Password"] = value;
        //    }

        //}

        //public static Int32 Session_Territory
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["Territory"] == null)
        //            RedirectToLogin();

        //        return Convert.ToInt32(HttpContext.Current.Session["Territory"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["Territory"] = value;
        //    }

        //}

        //public static Int32 Session_StateID
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["StateID"] == null)
        //            RedirectToLogin();

        //        return Convert.ToInt32(HttpContext.Current.Session["StateID"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["StateID"] = value;
        //    }

        //}

        //public static Int32 Session_PlantID
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["PlantID"] == null)
        //            RedirectToLogin();

        //        return Convert.ToInt32(HttpContext.Current.Session["PlantID"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["PlantID"] = value;
        //    }

        //}

        //public static Int32 Session_ZoneID
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["ZoneID"] == null)
        //            RedirectToLogin();

        //        return Convert.ToInt32(HttpContext.Current.Session["ZoneID"]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["ZoneID"] = value;
        //    }

        //}

        #endregion

        #region Session Methods

        private static void RedirectToLogin()
        {
            addJavascript("alert('" + SessErrMsg + "')", "RedirectJavascript");
            HttpContext.Current.Response.Redirect("~/Common/LoginHR.aspx");

        }

        #endregion

        #region Common Utility methods

        public static void addJavascript(string scriptContent, string key)
        {
            if (HttpContext.Current.Handler is Page)
            {
                Page curPage = HttpContext.Current.Handler as Page;
                curPage.ClientScript.RegisterClientScriptBlock(curPage.GetType(), key,
                    "<script defer='defer' type='text/javascript'>" +
                        scriptContent +
                    "</script>");
            }
        }

        #endregion
    }
}
