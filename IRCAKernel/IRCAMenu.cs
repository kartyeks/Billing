using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCAKernel
{
    public abstract class IRCAMenu
    {
        private Dictionary<String, String> _Menu = new Dictionary<string, string>();
        protected String _DefaultMenu = String.Empty;

        public void SetMenu(String RoleName, String MenuString)
        {
            if (_Menu.ContainsKey(RoleName))
            {
                _Menu.Remove(RoleName);
            }

            _Menu.Add(RoleName, MenuString);
        }

        public String GetMenu(String RoleName)
        {
            if (_Menu.ContainsKey(RoleName))
            {
                return _Menu[RoleName];
            }

            return _DefaultMenu;
        }

        public String GetDefaultMenu()
        {
            return _DefaultMenu;
        }
    }
}
