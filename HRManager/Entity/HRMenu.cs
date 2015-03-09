using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCAKernel;
using HRManager.BusinessObjects;

namespace HRManager.Entity
{
    public class HRMenu : IRCAMenu
    {
        private static HRMenu _Instance;
        private static string _role;
        private static string _menu;
        public static String Role
        {
            set
            {
                _role = value;

            }
        }
        public static String MenuString
        {
            set
            {
                _menu = value;

            }
        }

        public static HRMenu Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HRMenu();
                }

                return _Instance;
            }
        }

        private HRMenu()
        {
            //  SetMenu(_role, _menu);
            //  if (_role.ToLower().Contains("admin"))
            //     _DefaultMenu = _menu;
        }

        //public static string GetMenuString(string rolename)
        //{
        //    if (_Instance == null) _Instance = HRMenu.Instance;
        //    string mnu = _Instance.GetMenu(rolename);
        //    if (mnu == string.Empty)
        //    {
        //        mnu = new Common_UserBusinessObject().GetMenuString(rolename);
        //        _Instance.SetMenu(rolename, mnu);
        //    }
        //    return mnu;
        //}
        public static string GetMenuString(string rolename)
        {
            return new Master_RoleBusinessObject().GetMenuString(rolename);
        }
    }

    public class HRMenuString
    {
        public string menuString;
    }
}
