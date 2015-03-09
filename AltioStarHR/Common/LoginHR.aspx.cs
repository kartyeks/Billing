using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using IS91.Services;
using IS91.Services.Web;
using ApplicationManager;
using CommonManager.BusinessObjects;
using CommonManager.Entity;
using CommonManager.DTO;
using AltioStarHR.App_Code;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Collections.Specialized;
using System.Configuration;

namespace AltioStarHR.Common
{
    public partial class LoginHR : System.Web.UI.Page
    {
        Double browserVer;
        String[] strSpit;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (IsPostBack)
            {
                OnLogin();

            }
            //if (Request.Browser.Version.Contains("."))
            //{
            //    strSpit = Request.Browser.Version.Split('.');
            //    browserVer = Convert.ToDouble(strSpit[0] + "." + strSpit[1]);
            //}
            //else
            //    browserVer = Convert.ToDouble(Request.Browser.Version);

            //if ((Request.Browser.Browser == "IE" && browserVer < 7) ||
            //    (Request.Browser.Browser == "Firefox" && browserVer < 3.6) ||
            //    (Request.Browser.Browser == "AppleMAC-Safari" && browserVer < 5) ||
            //    (Request.Browser.Browser == "Opera" && browserVer < 9.1)
            //    )
            //{
            //    Button btn = (Button)Login1.FindControl("LoginButton");
            //    if (btn != null)
            //        btn.Enabled = false;

            //    HtmlTableCell ctrl = (HtmlTableCell)Login1.FindControl("tdLabel");
            //    if (ctrl != null)
            //        ctrl.Style["display"] = "";

            //}
        }

        private void OnLogin()
        {
            IS91.Services.Web.UserInfo UserObj;
            string dominName = string.Empty;
            string adPath = string.Empty;
            string strError = string.Empty;

            int LoginUserID = 0;
            User TmpUser = null;
            Int32 dbLoginType;
            UserObj = new ExtendedUserInfo();
            string userName = UserName.Value;
            string password = Password.Value;
            try
            {
                ////if (rdoCon.Checked)
                ////{
                    TmpUser = new Common_UserBusinessObject().GetUserByLogin(userName);
                    if (TmpUser != null)
                    {
                        if (TmpUser.LoginName.ToLower().ToString().Trim() == userName && TmpUser.Password.Trim() == IS91.Services.Common.EncryptB64String(password.ToString()))
                        {
                            LoginUserID = TmpUser.UserID;
                            UserObj.UserId = LoginUserID;
                            UserObj.GroupID = TmpUser.LoginType;//here EmployeeID will store in GroupID
                            UserObj.UserName = TmpUser.LoginName;
                            UserObj.GroupName = TmpUser.EmployeeID.ToString();

                            UserObj.GroupID = TmpUser.RoleID.ToString() + "_" + TmpUser.RoleName + "_" + TmpUser.LoginType;
                            Session["userInfo"] = UserObj;
                            hdnSuccess.Value = "true";
                            // Response.Redirect("default.aspx?serve=DashBoard", true);
                        }
                        else
                        {
                            hdnSuccess.Value = "false";
                        }

                    }
                    return;
               //// }
               ////    if (userName.ToLower().ToString().Trim() == "admin")
               ////         {

               ////             TmpUser = new Common_UserBusinessObject().GetUserByLogin(userName);
               ////             if (TmpUser != null)
               ////             {
               ////                 if (TmpUser.LoginName.ToLower().ToString().Trim() == userName && TmpUser.Password.Trim() == IS91.Services.Common.EncryptB64String(password.ToString()))
               ////                 {
               ////                     LoginUserID = TmpUser.UserID;
               ////                     UserObj.UserId = LoginUserID;
               ////                     UserObj.GroupID = TmpUser.LoginType;//here EmployeeID will store in GroupID
               ////                     UserObj.UserName = TmpUser.LoginName;
               ////                     UserObj.GroupName = TmpUser.EmployeeID.ToString();

               ////                     UserObj.GroupID = TmpUser.RoleID.ToString() + "_" + TmpUser.RoleName + "_" + TmpUser.LoginType;
               ////                     Session["userInfo"] = UserObj;
               ////                     hdnSuccess.Value = "true";
               ////                     // Response.Redirect("default.aspx?serve=DashBoard", true);
               ////                 }
               ////                 else
               ////                 {
               ////                     hdnSuccess.Value = "false";
               ////                 }
               ////             }
               ////        return;
               ////         }

               ////dominName = IS91.Services.Common.GetAppSetting("DomainName");// System.Environment.UserDomainName; //"ircaserver91.com";
               ////adPath = IS91.Services.Common.GetAppSetting("LDAPPath");// "LDAP://IRCA91SERVER";
               
               ////string  aUserName = IS91.Services.Common.GetAppSetting("AUserName");
               ////string aPwd= IS91.Services.Common.GetAppSetting("APassword");
               //// if (!String.IsNullOrEmpty(dominName) && !String.IsNullOrEmpty(adPath))
               //// {
               ////     if (true == AuthenticateUser(dominName,userName, password, adPath, out strError))
               ////     {
               ////         // Response.Redirect("default.aspx");// Authenticated user redirects to default.aspx

               ////         TmpUser = new Common_UserBusinessObject().GetUserByLogin(userName);
               ////         if (TmpUser != null)
               ////         {
               ////             if (TmpUser.LoginName.ToLower().ToString().Trim() == userName)// && TmpUser.Password.Trim() == password.ToString())
               ////             {

               ////                 LoginUserID = TmpUser.UserID;
               ////                 UserObj.UserId = LoginUserID;
               ////                 UserObj.GroupID = TmpUser.LoginType;//here EmployeeID will store in GroupID
               ////                 UserObj.UserName = TmpUser.LoginName;
               ////                 UserObj.GroupName = TmpUser.EmployeeID.ToString();

               ////                 UserObj.GroupID = TmpUser.RoleID.ToString() + "_" + TmpUser.RoleName + "_" + TmpUser.LoginType;
               ////                 Session["userInfo"] = UserObj;
               ////                 hdnSuccess.Value = "true";
               ////                 //  Response.Redirect("default.aspx?serve=DashBoard", true);

               ////             }
               ////             else // wrong username and password
               ////             {
               ////                 hdnSuccess.Value = "false";
               ////                 // do nothing, Login control will automatically show the failure message
               ////                 // if you are not using Login control, show the failure message explicitely
               ////             }
               ////         }
               ////         else
               ////         {
               ////             hdnSuccess.Value = "false";
               ////         }
               ////     }
               ////     else
               ////     {
               ////         hdnSuccess.Value = "false";
               ////     }
               //// }
                     
            }
            catch (Exception ex)
            {
                Logger.LogThis(ex);
            }
            finally
            {

            }
        }
        /// <summary>
        /// Fires when Login button will be clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        //{
        //    string jScriptValidator = string.Empty;

        //    //  IS91.Services.Web.UserInfo UserObj;
        //    IS91.Services.Web.UserInfo UserObj;
        //    string dominName = string.Empty;
        //    string adPath = string.Empty;
        //    string strError = string.Empty;

        //    int LoginUserID = 0;
        //    User TmpUser = null;
        //    Int32 dbLoginType;
        //    UserObj = new ExtendedUserInfo();
        //    string userName = Login1.UserName;
        //    string password = Login1.Password;
        //    bool rememberUserName = Login1.RememberMeSet;
        //    try
        //    {
        //        dominName = System.Environment.UserDomainName; //"ircaserver91.com";
        //        adPath = IS91.Services.Common.GetAppSetting("LDAPPath");// "LDAP://IRCA91SERVER";
        //        if (!String.IsNullOrEmpty(dominName) && !String.IsNullOrEmpty(adPath))
        //        {
        //            if (true == AuthenticateUser(dominName, userName, password, adPath, out strError))
        //            {
        //                // Response.Redirect("default.aspx");// Authenticated user redirects to default.aspx

        //                TmpUser = new Common_UserBusinessObject().GetUserByLogin(userName);
        //                if (TmpUser != null)
        //                {
        //                    if (TmpUser.LoginName.ToLower().ToString().Trim() == userName)// && TmpUser.Password.Trim() == password.ToString())
        //                    {
        //                        SessionManager.Session_EmpID = TmpUser.EmployeeID.ToString();
        //                        SessionManager.Session_LoginType = TmpUser.LoginType;
        //                        SessionManager.Session_Role = TmpUser.RoleName;
        //                        SessionManager.Session_RoleID = TmpUser.RoleID.ToString();
        //                        SessionManager.Session_EmpName = TmpUser.LoginName;
        //                        SessionManager.Session_UserID = TmpUser.UserID;

        //                        LoginUserID = TmpUser.UserID;
        //                        UserObj.UserId = LoginUserID;
        //                        UserObj.GroupID = TmpUser.LoginType;//here EmployeeID will store in GroupID
        //                        UserObj.UserName = TmpUser.LoginName;
        //                        UserObj.GroupName = TmpUser.EmployeeID.ToString();

        //                        UserObj.GroupID = TmpUser.RoleID.ToString() + "_" + TmpUser.RoleName + "_" + TmpUser.LoginType;
        //                        Session["userInfo"] = UserObj;
        //                        // Create forms authentication ticket
        //                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
        //                        1, // Ticket version
        //                        userName,// Username to be associated with this ticket
        //                        DateTime.Now, // Date/time ticket was issued
        //                        DateTime.Now.AddMinutes(50), // Date and time the cookie will expire
        //                        rememberUserName, // if user has chcked rememebr me then create persistent cookie
        //                            // roles, // store the user data, in this case roles of the user
        //                        FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.

        //                        // To give more security it is suggested to hash it
        //                        string hashCookies = FormsAuthentication.Encrypt(ticket);
        //                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket

        //                        // Add the cookie to the response, user browser
        //                        Response.Cookies.Add(cookie);
        //                        // Get the requested page from the url
        //                        string returnUrl = Request.QueryString["ReturnUrl"];
        //                        // check if it exists, if not then redirect to default page
        //                        if (returnUrl == null) returnUrl = "~/Common/DashBoard.aspx";
        //                        //  if (returnUrl == null) returnUrl = "default.aspx?serve=DashBoard";//&rl=0";// "default.aspx?serve=DashBoard&rl=0"; //"Default.aspx?serve=DashBoard";
        //                        //  Response.Redirect(returnUrl);
        //                        // Server.Transfer(returnUrl);
        //                        Server.Execute(returnUrl);
        //                    }
        //                    else // wrong username and password
        //                    {
        //                        // do nothing, Login control will automatically show the failure message
        //                        // if you are not using Login control, show the failure message explicitely
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (userName.ToLower().ToString().Trim() == "admin")
        //                {

        //                    TmpUser = new Common_UserBusinessObject().GetUserByLogin(userName);
        //                    if (TmpUser != null)
        //                    {
        //                        if (TmpUser.LoginName.ToLower().ToString().Trim() == userName)// && TmpUser.Password.Trim() == password.ToString())
        //                        {
        //                            SessionManager.Session_EmpID = TmpUser.EmployeeID.ToString();
        //                            SessionManager.Session_LoginType = TmpUser.LoginType;
        //                            SessionManager.Session_Role = TmpUser.RoleName;
        //                            SessionManager.Session_RoleID = TmpUser.RoleID.ToString();
        //                            SessionManager.Session_EmpName = TmpUser.LoginName;
        //                            SessionManager.Session_UserID = TmpUser.UserID;

        //                            LoginUserID = TmpUser.UserID;
        //                            UserObj.UserId = LoginUserID;
        //                            UserObj.GroupID = TmpUser.LoginType;//here EmployeeID will store in GroupID
        //                            UserObj.UserName = TmpUser.LoginName;
        //                            UserObj.GroupName = TmpUser.EmployeeID.ToString();

        //                            UserObj.GroupID = TmpUser.RoleID.ToString() + "_" + TmpUser.RoleName + "_" + TmpUser.LoginType;
        //                            Session["userInfo"] = UserObj;
        //                            // Create forms authentication ticket
        //                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
        //                            1, // Ticket version
        //                            userName,// Username to be associated with this ticket
        //                            DateTime.Now, // Date/time ticket was issued
        //                            DateTime.Now.AddMinutes(50), // Date and time the cookie will expire
        //                            rememberUserName, // if user has chcked rememebr me then create persistent cookie
        //                                // roles, // store the user data, in this case roles of the user
        //                            FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.

        //                            // To give more security it is suggested to hash it
        //                            string hashCookies = FormsAuthentication.Encrypt(ticket);
        //                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket

        //                            // Add the cookie to the response, user browser
        //                            Response.Cookies.Add(cookie);
        //                            // Get the requested page from the url
        //                            string returnUrl = Request.QueryString["ReturnUrl"];
        //                            // check if it exists, if not then redirect to default page
        //                            if (returnUrl == null) returnUrl = "~/Common/DashBoard.aspx";
        //                            //  if (returnUrl == null) returnUrl = "default.aspx?serve=DashBoard";//&rl=0";// "default.aspx?serve=DashBoard&rl=0"; //"Default.aspx?serve=DashBoard";
        //                            //  Response.Redirect(returnUrl);
        //                            // Server.Transfer(returnUrl);
        //                            Server.Execute(returnUrl);
        //                        }
        //                        else // wrong username and password
        //                        {
        //                            // do nothing, Login control will automatically show the failure message
        //                            // if you are not using Login control, show the failure message explicitely
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    dominName = string.Empty;
        //                    adPath = string.Empty;
        //                    if (strError != string.Empty)
        //                    {
        //                        Response.Write("<script language=javascript>alert('" + strError + "');</script>");
        //                        // ClientScript.RegisterStartupScript(this.GetType(), "LoginError", string.Format("alert('" + strError + "');", Login1.FailureText.Replace("'", "\\'")), true);
        //                        // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + strError + "');", true);
        //                        // ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Showalert();", true);
        //                        //jScriptValidator = "<script> alert('" + strError + "');";
        //                        //jScriptValidator += "window.returnValue=true;window.close();";
        //                        //jScriptValidator += " </script>";
        //                        Server.Execute("~/Common/LoginHR.aspx");
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogThis(ex);
        //    }
        //    finally
        //    {

        //    }
        /* /*  Errmsg = "";
            string domainAndUsername = domain + @"\" + authUname;
            DirectoryEntry entry = new DirectoryEntry(LdapPath);//
                //, domainAndUsername, aPwd);
            entry.AuthenticationType = AuthenticationTypes.Anonymous;
           
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(User=" + username + ")";
                //search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
                // Update the new path to the user in the directory
                LdapPath = result.Path;
                // string _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                return false;
                throw new Exception("Error authenticating user." + ex.Message);
            }*/
        // string ldapConn = GetLDAPConnection(domain, username, password);
        /*  Errmsg = "";
            string domainAndUsername = domain + @"\" + authUname;
            DirectoryEntry entry = new DirectoryEntry(LdapPath);//
                //, domainAndUsername, aPwd);
            entry.AuthenticationType = AuthenticationTypes.Anonymous;
           
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(User=" + username + ")";
                //search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
                // Update the new path to the user in the directory
                LdapPath = result.Path;
                // string _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                return false;
                throw new Exception("Error authenticating user." + ex.Message);
            }*/
           // string ldapConn = GetLDAPConnection(domain, username, password);*/
        //}


        private Boolean AuthenticateUser(string domain,string username, string password, string LdapPath, out string Errmsg)
        {
            Errmsg = string.Empty;
            bool bln = false;
            try
            {
                string method = IS91.Services.Common.GetAppSetting("AMethod");
                string domainstr = IS91.Services.Common.GetAppSetting("Domain");
                if (method == string.Empty)
                {
                 //  using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
                    //changed by archana LDAP server was not contacting 18/09/2014
                   using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainstr, "DC='" + domainstr + "'; DC=local"))
                    {
                        // validate the credentials
                        bln = pc.ValidateCredentials(username, password);
                       /* if (bln)
                        {
                            UserPrincipal usr = UserPrincipal.FindByIdentity(pc,
                                              IdentityType.SamAccountName,
                                              username);

                            if (usr != null)
                            {
                                bln = usr.Enabled.HasValue ? usr.Enabled.Value : false;
                                if (usr.IsAccountLockedOut())
                                    bln = false;
                            }
                        }*/
                    }
                   
                }
                else
                {
                    DirectoryEntry entry = new DirectoryEntry(LdapPath, username, password);
                    try
                    {
                        object obj = entry.NativeObject;
                    }
                    catch (DirectoryServicesCOMException comExc)
                    {
                        Logger.LogThis(comExc);
                        return false;
                    }
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = string.Format("(SAMAccountName={0})", username);
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();
                    if (result != null)
                    {
                        bln = true;
                    }
                }
               // PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                // find a user
                //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);

                //if (user != null)
                //{
                //    // do something here....     
                //}
               // 
               /* DirectoryEntry entry = new DirectoryEntry(LdapPath);
                DirectorySearcher srch = new DirectorySearcher("CN=raghu,OU=India,OU=Employees,OU=Users,DC=ircaserver91,DC=com"); //"CN=Amit Atharkar (Admin Account),OU=India,OU=Employees,OU=Users,OU=_RMA,DC=rma,DC=lan"
                SearchResult sr = srch.FindOne();
                DirectoryEntry myGroup = sr.GetDirectoryEntry();*/
                
                //try
                //{
                //    object obj = entry.NativeObject;
                //}
                //catch (DirectoryServicesCOMException comExc)
                //{
                //    Logger.LogThis(comExc);
                //    return false;
                //}

                //DirectorySearcher search = new DirectorySearcher(entry);
                //search.Filter = string.Format("(SAMAccountName={0})", username);
                //search.PropertiesToLoad.Add("cn");
                //SearchResult result = search.FindOne();
            }
            catch(Exception ex)
            {
                Logger.LogThis(ex);
                Errmsg = ex.Message;
                return bln;
            }
            return bln;
        }
        private string GetLDAPConnection(string a_Domain, string a_Username, string a_Password)
        {
            // Get the domain controller server for the specified domain
            NameValueCollection domains = (NameValueCollection)ConfigurationManager.GetSection("domains");
            string domainController = domains[a_Domain.ToLower()];

            string ldapConn = string.Format("LDAP://{0}/rootDSE", domainController);

            DirectoryEntry root = new DirectoryEntry(ldapConn, a_Username, a_Password);
            string serverName = root.Properties["defaultNamingContext"].Value.ToString();
            return string.Format("LDAP://{0}/{1}", domainController, serverName);
        }
    }
}
