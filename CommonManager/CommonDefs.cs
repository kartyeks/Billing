using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services;

namespace CommonManager
{
    public class CommonDefs
    {
        public static readonly String DEFAULT_PASSWORD = "123456789";

        /// <summary>
        /// Contains the static string which will be displayed on login module
        /// </summary>
        public class LoginMessages
        {
            public static readonly String LOGIN_FAILURE = "Invalid User ID or Password\nInvalid login attempt count ";
            public static readonly String INACTIVE_USER = "User Is not active";
            public static readonly String LOCKED_USER = "Account has been locked";
            public static readonly String INVALID_ATTEMPT_EXCEEDED =  "Exceeded the maximum invalid attempt limit"
                                                          + "\nUser account has been locked"
                                                          + "\nPlease contact administrator!!";


            public static readonly String PASSWORD_CHANGE_SUCCESS = "Password has been changed successfully";
            public static readonly String PASSWORD_CHANGE_FAILURE = "Error on changing password";
            public static readonly String SAME_PASSWORD = "Old and new passwords cannot be same";

            public static readonly String FORGOT_PASSWORD_ERROR = "Unable to send the email! (Check For SMTP Settings)";
            public static readonly String FORGOT_PASSWORD_SUCCESS = "The login details have been sent to the registered EMail ID";
            public static readonly String FORGOT_INVALID_LOGIN = "Invalid Login Name";
            public static readonly String FORGOT_INVALID_EMAIL = "Invalid Email ID";
            public static readonly String FORGOT_LOGIN_NAME = "Your HR Application Login Name: ";
            public static readonly String FORGOT_PSSWORD = "Your HR Application Login Password: ";
            public static readonly String FORGOT_LOGIN = "HR Application Login Detail";
            public static readonly String RESET_PASSWORD = "HR Application Login Password has been Reset";



        }

        /// <summary>
        /// Contains the static string which will be displayed on Users module
        /// </summary>
        public class UserMessages
        {
            public static readonly String EMAIL_EXISTS = "The given eMailID exists already";
            public static readonly String LOGINNAME_EXISTS = "The given Login name exists already";
            public static readonly String USER_UPDATE_SUCCESS = "User details updated successfully";
            public static readonly String USER_ADDED_SUCCESS = "User details added successfully";
            public static readonly String USER_UPDATE_FAILURE = "Error on updating the user details";

            public static readonly String EMPTY_LOGINNAME = "Login name cannot be empty";

            public static readonly String RESET_PASSWORD_SUCCESS = "Password has been reset successfully";
            public static readonly String RESET_PASSWORD_FAILURE = "Error on Password reset";

            public static readonly String UNLOCK_SUCCESS = "User unlocked successfully";
            public static readonly String UNLOCK_FAILURE = "Error on unlock user";

            public static readonly String DEACTIVATE_SUCCESS = "User deactivated successfully";
            public static readonly String DEACTIVATE_FAILURE = "Error on deactivate the user";

            public static readonly String ACTIVATE_SUCCESS = "User activated successfully";
            public static readonly String ACTIVATE_FAILURE = "Error on activate the user";
        }

        public class TaxExemptionTypeMassage
        {
            public static readonly String UPDATE_TAX_EXEMPTION_FAILURE = "Error on updating the Tax Exemption Type details";
        
            public static readonly String ACTIVATE_TAX_EXEMPTION_FAILURE = "Error on activate the Tax Exemption Type details";
        
            public static readonly String DEACTIVATE_TAX_EXEMPTION_FAILURE = "Error on deactivate the Tax Exemption Type details";
        }
        //public class TaxExemptionTypeMassage
        //{
        //    public static readonly String UPDATE_TAX_EXEMPTION_FAILURE = "Error on updating the Tax Exemption Type details";
        //}

        /// <summary>
        /// Contains the static string which will be displayed on login module
        /// </summary>
        public class DepartmentMessages
        {
            public static readonly String EMPTY_DEPARTMENTNAME = "Department name cannot be empty";
            public static readonly String DEPARTMENTNAME_EXISTS = "The given Department name exists already";            
        }

        /// <summary>
        /// Contains the static string which will be related to State / Country
        /// </summary>
        public class StateCountryMessages
        {
            public static readonly String NO_STATES = "No states are available of selected country";
            public static readonly String NO_COUNTRY = "No countries are available";
        }

        /// <summary>
        /// The mail templates which will be sent to user
        /// </summary>
        public class UserMails
        {
            public static readonly String PASSWORD_SUBJECT = "Your Login Details for " + Common.GetAppSetting("ApplicationName");

            public static readonly String PASSWORD_BODY = "Dear {0} User,"
                                                         + "\n Your login details for the application are as below"
                                                         + "\n Login Name {1}"
                                                         + "\n Password   {2}"
                                                         + "\n\n\n For {0}";
        }
    }
}
