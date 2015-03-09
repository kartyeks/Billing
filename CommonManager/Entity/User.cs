using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonManager.DTO;
using CommonManager.BusinessObjects;
using IRCA.Communication;
using IRCAKernel;
using IS91.Services;
using IS91.Services.Web;
//using CommonManager.DTOEXT;


namespace CommonManager.Entity
{
    /// <summary>
    /// The entiry of user. This will be displayed on grid, so implements JGridDataObject
    /// </summary>
    public class User : JGridDataObject
    {
        private static readonly int MAXLOGINATTEMPT = 3;

        private int _UserID;
        private String _Sno;

        private String _LoginName;
        private String _Password;
        private bool _IsActive;
        private bool _IsChangePassword;
        private bool _IsLocked;
        private short _InvalidLoginCount;
        private DateTime _LastLoginTime = DateTime.Now;
        private int _UpdateBy;
        private bool _IsDefaultUser;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;

        private int _EmployeeID;
        private int _RoleID;
        private string _EmployeeName;
        private string _EmailID;
        private string _LoginType;
        private string _RoleName;

        private bool _IsNew;

        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }
        }

        public String Sno
        {
            get
            {
                return _Sno;
            }
            set
            {
                _Sno = value;

            }
        }
        public int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;

                if (_UserID == 0)
                {
                    _IsNew = true;
                }
            }
        }
        public string LoginType
        {
            get
            {
                return _LoginType;
            }
            set
            {
                _LoginType = value;

            }
        }
        public String EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                _EmailID = value;
            }
        }
        public String LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }
        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        public bool IsChangePassword
        {
            get
            {
                return _IsChangePassword;
            }
            set
            {
                _IsChangePassword = value;
            }
        }
        public short InvalidLoginCount
        {
            get
            {
                return _InvalidLoginCount;
            }
            set
            {
                _InvalidLoginCount = value;
            }
        }
        public bool IsLocked
        {
            get
            {
                return _IsLocked;
            }
            set
            {
                _IsLocked = value;
            }
        }
        public DateTime LastLoginTime
        {
            get
            {
                return _LastLoginTime;
            }
            set
            {
                _LastLoginTime = value;
            }
        }

        public int RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }

        public String EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        public String RoleName
        {
            get
            {
                return _RoleName;
            }
            set
            {
                _RoleName = value;
            }
        }

        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        public bool IsDefaultUser
        {
            get { return _IsDefaultUser; }
            set { _IsDefaultUser = value; }
        }

        /// <summary>
        /// Updates the data from DTO to Entity
        /// </summary>
        /// <param name="User">DTO</param>
        private void Update(Common_User User)
        {
            if (User != null)
            {
                _UserID = User.ID;
                _EmployeeID = User.EmployeeID;
                _LoginName = User.LoginName;
                _Password = User.Password;
                _IsActive = User.IsActive;
                _IsChangePassword = User.IsChangePassword;
                _IsLocked = User.IsLocked;
                _LastLoginTime = User.LastLoginTime;
                //_InvalidLoginCount = User.InvalidLoginCount;
                _CreatedBy = User.CreatedBy;
                _ModifiedBy = User.ModifiedBy;
                _CreatedDate = User.CreatedDate;
                _ModifiedDate = User.ModifiedDate;
                _IsDefaultUser = User.IsDefaultUser;
                _LoginType = User.LoginType;
                _IsNew = false;
                //if (User is Common_UserExt)
                //{
                //    _RoleID = ((Common_UserExt)User).RoleID;
                //    _RoleName = ((Common_UserExt)User).Role;
                //}
            }
            else
            {
                _IsNew = true;
            }
        }
        private void Update(User User)
        {
            if (User != null)
            {
                _UserID = User.UserID;
                _EmployeeID = User.EmployeeID;
                _LoginName = User.LoginName;
                _Password = User.Password;
                _IsActive = User.IsActive;
                _IsChangePassword = User.IsChangePassword;
                _IsLocked = User.IsLocked;
                _LastLoginTime = User.LastLoginTime;
                _InvalidLoginCount = User.InvalidLoginCount;
                _IsDefaultUser = User.IsDefaultUser;
                _EmployeeName = User.EmployeeName;
                _EmailID = User.EmailID;
                _RoleID = User.RoleID;
                _RoleName = User.RoleName;
                _LoginType = User.LoginType;
                _RoleName = User.RoleName;
                _RoleID = User.RoleID;
                _IsNew = false;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Construct entity from DTO
        /// </summary>
        /// <param name="User">DTO</param>
        public User(Common_User User)
        {
            Update(User);
        }

        /// <summary>
        /// Updates the data from DTO to Entity
        /// </summary>
        /// <param name="User">DTO</param>
        //private void Update(User User)
        //{
        //    if (User != null)
        //    {
        //        _UserID = User.UserID;
        //        _EmployeeID = User.EmployeeID;
        //        _LoginName = User.LoginName;
        //        _Password = User.Password;
        //        _IsActive = User.IsActive;
        //        _IsChangePassword = User.IsChangePassword;
        //        _IsLocked = User.IsLocked;
        //        _LastLoginTime = User.LastLoginTime;
        //        _InvalidLoginCount = User.InvalidLoginCount;
        //        _IsDefaultUser = User.IsDefaultUser;
        //        _EmployeeName = User.EmployeeName;
        //        _EmpType = User.EmpType;
        //        _IsNew = false;
        //    }
        //    else
        //    {
        //        _IsNew = true;
        //    }
        //}
        /// <summary>
        /// Construct entity from DTO
        /// </summary>
        /// <param name="User">DTO</param>
        public User(User User)
        {
            Update(User);
        }
        /// <summary>
        /// Construct the entity by the loginname
        /// </summary>
        /// <param name="LoginName">User Login Name</param>
        public User(String LoginName)
        {
            Update(new Common_UserBusinessObject().GetUserByLoginName(LoginName));
        }

        /// <summary>
        /// Construct the entity by the User ID
        /// </summary>
        /// <param name="UserID">User ID</param>
        public User(int UserID)
        {
            Common_User User = new Common_UserBusinessObject().GetCommon_User(UserID);

            if (User == null && UserID > 0)
            {
                throw new IRCAException("Invalid User", UserID.ToString());
            }

            Update(User);
        }

        public User(int ID, string ColName)
        {
            Common_User User = new Common_UserBusinessObject().GetCommon_UserByEmp(ID, ColName);

            if (User == null && UserID > 0)
            {
                throw new IRCAException("Invalid User", UserID.ToString());
            }

            Update(User);
        }

        /// <summary>
        /// Construct the entity by the User ID
        /// </summary>
        /// <param name="UserID">User ID</param>
        public static string UpdateUser(string LoginName, string EmailID)
        {
            //SmtpMail MailObj = new SmtpMail();
            //if (!new Common_UserBusinessObject().IsLoginNameExists(LoginName, 0))
            //{
            //    return CommonDefs.LoginMessages.FORGOT_INVALID_LOGIN;
            //}
            //string email = new Common_UserBusinessObject().GetUserEmailID(LoginName);
            //if (EmailID != email)
            //{
            //    return CommonDefs.LoginMessages.FORGOT_INVALID_EMAIL;
            //}
            //Common_User objUser = new Common_UserBusinessObject().GetUserByLoginNames(LoginName);
            //string password = Math.Abs(DateTime.Now.ToString().GetHashCode()).ToString();
            //if (password != "")
            //{
            //    objUser.Password = IS91.Services.Common.EncryptB64String(password);
            //    new Common_UserBusinessObject().Update(objUser);

            //    String EmailMessageStr = "Application Login Details : <br />" + CommonDefs.LoginMessages.FORGOT_LOGIN_NAME + LoginName + " <br /> " + CommonDefs.LoginMessages.FORGOT_PSSWORD + password;
            //    string subject = CommonDefs.LoginMessages.FORGOT_LOGIN;

            //    MailObj.Subject = subject;
            //    MailObj.Body = EmailMessageStr;
            //    MailObj.BodyFormat = SmtpMail.BodyFormatTypes.HTML;
            //    MailObj.FromAddress = Common.GetAppSetting("smtpFromEmail");
            //    MailObj.AddRecipient(EmailID);
            //    MailObj.EmbedImages = Convert.ToBoolean(Common.GetAppSetting("smtpEmbedImages"));
            //    try
            //    {
            //        MailObj.Send(false);
            //    }
            //    catch (Exception ex)
            //    {

            //        return CommonDefs.LoginMessages.FORGOT_PASSWORD_ERROR;
            //    }
            //}
            //else
            //{
            //    return CommonDefs.LoginMessages.FORGOT_PASSWORD_ERROR;
            //}

            return string.Empty;
        }

        /// <summary>
        /// Construct new user entity
        /// </summary>
        public User()
        {
            _UserID = 0;
            _Password = "";
            _IsNew = true;
        }

        /// <summary>
        /// Will save the user without any validation. If new user, the new record gets created on DB.
        /// </summary>
        /// <returns></returns>
        public String SaveUser()
        {
            Common_User User = new Common_User();
            User.EmployeeID = _EmployeeID;
            User.LoginName = _LoginName;
            //User.Password = IS91.Services.Common.EncryptB64String(_Password);
            User.IsActive = _IsActive;
            User.IsChangePassword = _IsChangePassword;
            User.IsLocked = _IsLocked;
            User.LastLoginTime = _LastLoginTime;
            User.InvalidLoginCount = _InvalidLoginCount;
            User.LoginType = _LoginType;
            User.ModifiedBy = _UpdateBy;
            User.ModifiedDate = DateTime.Now;
            if (_Password == CommonDefs.DEFAULT_PASSWORD)
                User.Password = IS91.Services.Common.EncryptB64String(_Password);
            else
                User.Password = _Password;

            if (_IsNew)
            {
                User.IsDefaultUser = false;
                User.IsActive = true;
                User.CreatedBy = _UpdateBy;
                User.CreatedDate = DateTime.Now;

                User.ID = new Common_UserBusinessObject().Create(User);
            }
            else
            {
                User.IsDefaultUser = _IsDefaultUser;
                User.ID = _UserID;
                new Common_UserBusinessObject().Update(User);
            }

            return String.Empty;
        }

        /// <summary>
        /// Validates and save. Validation fails returns the error message. For success returns empty
        /// </summary>
        /// <returns>Validation Message</returns>
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveUser();
        }

        /// <summary>
        /// Validate the parameters. Retuns empty for success and error message for failure
        /// </summary>
        /// <returns>Validation Message</returns>
        private String Validate()
        {
            Common_UserBusinessObject UserBO = new Common_UserBusinessObject();

            if (_LoginName == String.Empty)
            {
                return CommonDefs.UserMessages.EMPTY_LOGINNAME;
            }
            else if (UserBO.IsLoginNameExists(_LoginName, _UserID))
            {
                return CommonDefs.UserMessages.LOGINNAME_EXISTS;
            }
            //else if (UserBO.IsEMailExists(_EMailID,_UserID))
            //{
            //    return CommonDefs.UserMessages.EMAIL_EXISTS;
            //}

            return String.Empty;
        }

        /// <summary>
        /// Validate login by checking the password. Based on the invalid attempt, user will get locked.
        /// Retuns empty for success and error message for failure 
        /// </summary>
        /// <param name="Password">User Password</param>
        /// <returns>Login Response</returns>
        public String Login(String Password)
        {
            String Result;

            if (_UserID != 0 && _Password == Password)
            {
                Result = String.Empty;
            }
            else if (!IsActive)
            {
                Result = CommonDefs.LoginMessages.INACTIVE_USER;
            }
            else if (IsLocked)
            {
                Result = CommonDefs.LoginMessages.LOCKED_USER;
            }
            else
            {
                if (++_InvalidLoginCount <= MAXLOGINATTEMPT)
                {
                    Result = CommonDefs.LoginMessages.LOGIN_FAILURE + _InvalidLoginCount;
                }
                else
                {
                    _IsLocked = true;
                    Result = CommonDefs.LoginMessages.INVALID_ATTEMPT_EXCEEDED;
                }
            }

            _LastLoginTime = DateTime.Now;

            SaveUser();

            return Result;
        }

        /// <summary>
        /// Reset new password
        /// </summary>
        /// <param name="Password">New Password</param>
        /// <param name="ResetBy">The user who resets the password</param>
        /// <returns>Message</returns>
        /// 

       
        public String ResetPassword(String Password, int ResetBy)
        {
            string saveUserRetVal = string.Empty;

            _UpdateBy = ResetBy;
            _Password = Password;// IS91.Services.Common.EncryptB64String(Password);
            _IsChangePassword = true;

            saveUserRetVal = SaveUser();

            //send email
            try
            {
                MailContent MailObj = new MailContent();
                String EmailMessageStr = "Application Login Details : <br />" +
                                        CommonDefs.LoginMessages.FORGOT_LOGIN_NAME + _LoginName + " <br /> " +
                                        CommonDefs.LoginMessages.FORGOT_PSSWORD + IS91.Services.Common.DecryptB64String(Password);
                string subject = CommonDefs.LoginMessages.RESET_PASSWORD;
                MailObj.Subject = subject;
                MailObj.Body = EmailMessageStr;
                //MailObj.BodyFormat = MailContent.BodyFormatTypes.HTML;
                MailObj.FromAddress = Common.GetAppSetting("smtpFromEmail");
                string email = new Common_UserBusinessObject().GetUserEmailIDOnReset(_LoginName);
                if (email != String.Empty)
                {
                    MailObj.AddToAddress(email);
                    //MailObj.Attachments( Convert.ToBoolean(Common.GetAppSetting("smtpEmbedImages")));
                    IRCAMailHandler.SendMail(MailObj);
                }
            }
            catch (Exception ex)
            {
                //sending email on reset is secondary activity. 
                //Reset is used by admin to gain acess to user's login(in case of emergency)
                //user (whose login was reset) needs to be notified by email. 
                //But if this sending fails, no need to return error for the reset action itself. Just log it.                

                //return CommonDefs.LoginMessages.FORGOT_PASSWORD_ERROR;
            }
            return saveUserRetVal;
        }

        /// <summary>
        /// Activates the user
        /// </summary>
        /// <param name="ActivatedBy">The user who Activates the user</param>
        /// <returns>Message</returns>
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveUser();
        }

        /// <summary>
        /// Deactivates the user
        /// </summary>
        /// <param name="DeActivatedBy">The user who Deactivates  the user</param>
        /// <returns>Message</returns>
        public String DeActivate(int DeActivatedBy)
        {
            _UpdateBy = DeActivatedBy;
            _IsActive = false;

            return SaveUser();
        }

        /// <summary>
        /// Unlock the user who locked by system
        /// </summary>
        /// <param name="UnLockedBy">The user who unlocks  the user</param>
        /// <returns>Message</returns>
        public String UnLock(int UnLockedBy)
        {
            _UpdateBy = UnLockedBy;
            _IsLocked = false;

            return SaveUser();
        }

        /// <summary>
        /// Will be used when user changes password
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public String ChangePassword(String Password)
        {
            Password = IS91.Services.Common.EncryptB64String(Password);
            if (Password == _Password)
            {
                return CommonDefs.LoginMessages.SAME_PASSWORD;
            }

            _Password = Password;

            return SaveUser();
        }

        /// <summary>
        /// Get All the users
        /// </summary>
        /// <returns>Array of User objects</returns>
        public static User[] GetAllUsers()
        {
            //Common_User[] UsersDT = new Common_UserBusinessObject().GetCommon_User();
            Common_User[] UsersDT = new Common_UserBusinessObject().GetAllUser();

            User[] Users = new User[UsersDT.Length];

            for (int i = 0; i < Users.Length; i++)
            {
                Users[i] = new User(UsersDT[i]);
            }

            return Users;
        }
        /// <summary>
        /// Get All the users
        /// </summary>
        /// <returns>Array of User objects</returns>
        public static User[] GetAllEmployeeUsers(string Type)
        {
            Common_User[] UsersDT = new Common_UserBusinessObject().GetCommon_User();
            User[] UsersDetails = new Common_UserBusinessObject().GetUserEmployees(Type);//.GetCommon_User();
            return UsersDetails;
        }
        public static User[] GetInActiveUsers(string Type)
        {
            //Common_User[] UsersDT = new Common_UserBusinessObject().GetCommon_User();
            User[] UsersDetails = new Common_UserBusinessObject().GetInActiveUsers(Type);//.GetCommon_User();
            return UsersDetails;
        }

        #region JGridDataObject Members

        /// <summary>
        /// Returns the object which has the fields suppose to be displayed on grid
        /// </summary>
        /// <returns></returns>
        public object GetGridData()
        {
            UserDisplayDetails User = new UserDisplayDetails();

            User.Sno = _Sno;
            User.UserID = _UserID;
            User.EmployeeID = _EmployeeID;
            //  User.CandidateID = _CandidateID;
            User.EmployeeName = _EmployeeName;
            User.Password = _Password;
            User.LoginName = _LoginName;
            User.EmailID = _EmailID;
            User.IsActive = _IsActive;
            User.IsLocked = _IsLocked;
            User.LastLoginTime = _LastLoginTime;
            if (_LoginType == "EMP")
                User.LoginType = "Employee";
            else
                User.LoginType = "Consultant";


            return User;
        }

        #endregion
    }

    /// <summary>
    /// Contains the fields which will be displayed on screen
    /// </summary>
    public class UserDisplayDetails
    {
        public String Sno;
        public String EmpType;
        public int UserID;
        public int EmployeeID;
        public int CandidateID;
        public String EmployeeName;
        public String LoginName;
        public String EmailID;
        public bool IsActive;
        public bool IsLocked;
        public DateTime LastLoginTime;
        public String Password;
        public String LoginType;

    }
}
