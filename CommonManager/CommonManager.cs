using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using CommonManager.Entity;
//using CommonManager.DTO;
//using CommonManager.BusinessObjects;
using IRCAKernel;
using IS91.Services;
using CommonManager.Entity;
using CommonManager.BusinessObjects;
using CommonManager.DTO;

namespace CommonManager
{
    public class CommonManager
    {
        #region User

        //public static String LoginRequest(String LoginName,String Password)
        //{
        //    User User = new User(LoginName);

        //    return User.Login(Password);
        //}

        public static User[] GetUsers(string Type)
        {
            return User.GetAllEmployeeUsers(Type);//.GetAllUsers();
        }
        //public static User[] GetInActiveUsers(string Type)
        //{
        //    return User.GetInActiveUsers(Type);//.GetAllUsers();
        //}
        public static String getempbasedusers(int EmployeeID,String LoginType)
        {
            return Common_UserBusinessObject.GetEmpBasedUsers(EmployeeID,LoginType);
        }


        public static String UpdateUser(int UserID, int employeeID, String LoginName, String Password, int UpdatedBy,String LoginType)
        {
            try
            {
                User User = new User(LoginName);
                if (UserID == 0)
                    User.UserID = UserID;

                User.EmployeeID = employeeID;
                User.LoginName = LoginName;
                User.Password = IS91.Services.Common.EncryptB64String(Password); //Password;               
                User.UpdatedBy = UpdatedBy;
                User.LoginType = LoginType;

                String Status = User.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, CommonDefs.UserMessages.USER_UPDATE_FAILURE, UserID.ToString())
                    );
                return CommonDefs.UserMessages.USER_UPDATE_FAILURE;
            }
        }

        public static String ResetPassword(int ID, int EmployeeID, String LoginType)
        {
            int forreset = Common_UserBusinessObject.GetResetUsers(ID, EmployeeID, LoginType);
            String reset = "";
            
            String UserReset = new User(forreset).ResetPassword(IS91.Services.Common.EncryptB64String(CommonDefs.DEFAULT_PASSWORD),1);

            return reset;
            //return Common_UserBusinessObject.GetResetUsers(ID, EmployeeID, LoginType);
        }
        public static String ResetPassword(int UserID, int ResetBy)
        {
            
            try
            {
                return new User(UserID).ResetPassword(CommonDefs.DEFAULT_PASSWORD, ResetBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, CommonDefs.UserMessages.USER_UPDATE_FAILURE, UserID.ToString())
                    );
                return CommonDefs.UserMessages.RESET_PASSWORD_FAILURE;
            }
        }

        //public static String ForgotPassword(string LoginName, string EmailID)
        //{
        //    try
        //    {
        //       // return new User().UpdateUser(LoginName, EmailID);
        //        return User.UpdateUser(LoginName, EmailID);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, CommonDefs.LoginMessages.FORGOT_PASSWORD_ERROR, EmailID.ToString())
        //            );
        //        return CommonDefs.LoginMessages.FORGOT_PASSWORD_ERROR;
        //    }
        //}
        //public static String UnlockUser(int UserID,int UnlockBy)
        //{
        //    try
        //    {
        //        return new User(UserID).UnLock(UnlockBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, CommonDefs.UserMessages.USER_UPDATE_FAILURE, UserID.ToString())
        //            );
        //        return CommonDefs.UserMessages.USER_UPDATE_FAILURE;
        //    }
        //}

        //public static String ActivateUser(int UserID,int ActivatedBy)
        //{
        //    try
        //    {
        //        return new User(UserID).Activate(ActivatedBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, CommonDefs.UserMessages.USER_UPDATE_FAILURE, UserID.ToString())
        //            );
        //        return CommonDefs.UserMessages.ACTIVATE_FAILURE;
        //    }
        //}

        //public static String DeActivateUser(int UserID,int DeactivatedBy)
        //{
        //    try
        //    {
        //        return new User(UserID).DeActivate(DeactivatedBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, CommonDefs.UserMessages.USER_UPDATE_FAILURE, UserID.ToString())
        //            );
        //        return CommonDefs.UserMessages.USER_UPDATE_FAILURE;
        //    }
        //}

        public static String ChangePassword(int UserID, String Password)
        {
            try
            {
                return new User(UserID).ChangePassword(Password);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, CommonDefs.UserMessages.USER_UPDATE_FAILURE, UserID.ToString())
                    );
                return CommonDefs.LoginMessages.PASSWORD_CHANGE_FAILURE;
            }
        }

        //public static String ForgotPassword(int UserID)
        //{
        //    try
        //    {
        //        User User = new User(UserID);

        //        User.ResetPassword(Math.Abs(DateTime.Now.ToString().GetHashCode()).ToString(),1);

        //        MailService Mail = new MailService();

        //        MailContent Content = new MailContent();

        //        //Content.AddRecipient(RecipientTypes.TO, User.EMailID);

        //        Content.Subject = CommonDefs.UserMails.PASSWORD_SUBJECT;
        //        Content.Body = String.Format(CommonDefs.UserMails.PASSWORD_SUBJECT
        //                        , Common.GetAppSetting("ApplicationName")
        //                        , User.LoginName
        //                        , User.Password
        //                        );

        //        Mail.sendMail(Content);

        //        return String.Empty;

        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, CommonDefs.UserMessages.USER_UPDATE_FAILURE, UserID.ToString())
        //            );
        //        return CommonDefs.LoginMessages.FORGOT_PASSWORD_ERROR;
        //    }
        //}

        ///// <summary>
        ///// Return all Designation
        ///// </summary>
        ///// <returns>Array of the object of Designation class</returns>
        //public static User[] GetUser()
        //{
        //    return User.GetAllUsers();
        //}

        #endregion

        #region State

        //public static Country[] GetCountryDetails()
        //{
        //    return Country.GetAllCountry();
        //}

        //public static State[] GetStatesForCountry(int CountryID)
        //{
        //    return State.GetStates(CountryID);
        //}
        //public static State[] GetStatesForZone(int ZoneID)
        //{
        //    return State.GetStatesForZone(ZoneID);
        //}


        #endregion

    }
}
