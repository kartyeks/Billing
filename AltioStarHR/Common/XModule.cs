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
using CommonManager.BusinessObjects;
using CommonManager.Entity;
using CommonManager.DTO;
using AltioStarHR.App_Code;
using System.DirectoryServices;



//namespace KurlonHRManager.App_Code
//{
    public static class XModule
    {
        public static IS91.Services.License.LicenseItem LicItem = null;
        public static void AppInitIS91Services()
        {
           /* IS91.Services.Common.InitAgruments Args = new IS91.Services.Common.InitAgruments();
            Args.IS91_CustomAuthenticate = new IS91.Services.Web.ApplicationModule.IS91_CustomAuthenticateEventHandler(ref IS91_CustomAuthenticate);
            Args.IS91_CustomDBAuthenticate = new IS91.Services.Web.ApplicationModule.IS91_CustomDBAuthenticateEventHandler(ref IS91_CustomDBAuthenticate);

            IS91.Services.Common.InitIS91Services(Args);
            */
            using (LicenseKey Lic = new LicenseKey())
            {
                LicItem = Lic.LoadLicense(String.Empty);
            }
          
        }
        static void IS91_CustomAuthenticate(String Username, Boolean isNTLM, ref String Password2Check, ref Boolean isAuthenticated, ref ApplicationModule.UnSucessfullLoginReason reason)
        {
            if (Username != IS91.Services.Common.GetAppSetting("AppSAdminLogin"))
            {
                isAuthenticated = false;
            }
            else
            {
                isAuthenticated = true;

                Password2Check = IS91.Services.Common.GetAppSetting("AppSAdminLoginPWD");
            }
        }
        static Boolean AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
        {
            Errmsg = "";
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
               // search.Filter = "(Administrator=" + username + ")";
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
            }
            return true;
        }
        static void IS91_CustomDBAuthenticate(String Username, int LoginRole, Boolean isNTLM, ref String Password2Check, ref Boolean isAuthenticated, ref IS91.Services.Web.UserInfo UserObj, ref ApplicationModule.UnSucessfullLoginReason reason)
        {
            string dominName = string.Empty;
            string adPath = string.Empty;
            string strError = string.Empty;
            int LoginUserID = 0;
            try
            {
                User User = null;
                Int32 dbLoginType;
                UserObj = new ExtendedUserInfo();
                Boolean isBlockedUser = false;
                Password2Check = "@rchies";

                try
                {
                    //foreach (string key in ConfigurationSettings.AppSettings.Keys)
                    //{
                        //dominName = key.Contains("ircaserver91.com") ? ConfigurationSettings.AppSettings[key] : dominName;
                        //adPath = key.Contains("ircas") ? ConfigurationSettings.AppSettings[key] : adPath;
                        dominName = System.Environment.UserDomainName; //"ircaserver91.com";
                      //  adPath = "LDAP://irca91server.ircaserver91.com";
                      //  adPath = "LDAP://irca91server/CN=users,DC=ircaserver91,DC=net";
                        adPath = "LDAP://IRCA91SERVER";
                        if (!String.IsNullOrEmpty(dominName) && !String.IsNullOrEmpty(adPath))
                        {
                            if (true == AuthenticateUser(dominName, Username, Password2Check, adPath, out strError))
                            {
                               // Response.Redirect("default.aspx");// Authenticated user redirects to default.aspx
                            }
                            //else
                            //{
                            //    dominName = string.Empty;
                            //    adPath = string.Empty;
                            //    if (String.IsNullOrEmpty(strError))
                            //    {
                            //        return;
                            //    }
                            //}
                        }

                  //  }
                    //if (!string.IsNullOrEmpty(strError))
                    //{
                    //    lblError.Text = "Invalid user name or Password!";
                    //}
                }
                catch
                {

                }
                finally
                {

                } 




                isAuthenticated = IRCADigestNTLM_Authenticate(Username, LoginRole, out dbLoginType, out User, ref isBlockedUser);

                LoginUserID = User.UserID;
                UserObj.UserId = LoginUserID;
                UserObj.GroupID = User.LoginType;//here EmployeeID will store in GroupID
                UserObj.UserName = User.LoginName;
                UserObj.GroupName = User.EmployeeID.ToString();
               
                UserObj.GroupID = User.RoleID.ToString() + "_" +User.RoleName + "_"+User.LoginType;
                // SessionManager sesman = new SessionManager();
               // SessionManager.Session_EmpID = User.EmployeeID.ToString();
                ////if (LoginUserID != 1)
                ////    SessionManager.Session_EmpTypeID = new HRManager.Entity.Employees(User.EmployeeID).EmploymentType.ToString();
                ////SessionManager.Session_LoginType = User.EmpType;
                ////SessionManager.Session_EmpName = User.EmployeeName;

                Password2Check = "";
                if (!isAuthenticated)
                {
                    return;
                }
                Password2Check = User.Password.Trim();


            }
            catch (Exception ex)
            {
                IS91.Services.Logger.LogThis(ex);
            }
        }

        static Boolean IRCADigestNTLM_Authenticate(String UserLoginName, Int32 LoginRole, out Int32 CurLoginRole, out User UserLoginObject, ref Boolean isUserBlocked)
        {
            User TempUserLoginObject = null;
            try
            {
                TempUserLoginObject = new Common_UserBusinessObject().GetUserByLogin(UserLoginName);
            }
            catch (Exception e)
            {
                IS91.Services.Logger.LogThis(e);
            }

            UserLoginObject = TempUserLoginObject;

            CurLoginRole = LoginRole;
            if (TempUserLoginObject.IsActive == false)
            {
                return false;
            }

            return (TempUserLoginObject != null);

        }
    }

