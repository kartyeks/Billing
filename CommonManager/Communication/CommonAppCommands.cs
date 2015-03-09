using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Contains the commons which will be used for Common Processes
/// </summary>
public class CommonAppCommands : WebAppCommands
{
    public static readonly String LOGIN_REQUEST = "LOGIN_REQUEST";
    public static readonly String FORGOT_PASSWORD = "FORGOT_PASSWORD";
    public static readonly String CHANGE_PASSWORD = "CHANGE_PASSWORD";
    
    public static readonly String USER_DETAILS = "USER_DETAILS";
    public static readonly String UPDATE_USER = "UPDATE_USER";
    public static readonly String EMPBASEDUPDATE_USER = "EMPBASEDUPDATE_USER";
    

    public static readonly String UNLOCK_USER = "UNLOCK_USER";
    public static readonly String RESET_PASSWORD = "RESET_PASSWORD";
    public static readonly String ACTIVATE_USER = "ACTIVATE_USER";
    public static readonly String DEACTIVATE_USER = "DEACTIVATE_USER";

   
    public static readonly String STATE_DETAILS = "STATE_DETAILS";
    public static readonly String INACTIVE_USER = "INACTIVE_USER";

    public static readonly String STATECOMBO_DETAILS = "STATECOMBO_DETAILS";

    
}