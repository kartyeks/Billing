using System;
using System.Collections.Generic;
using System.Text;

namespace IRCAKernel
{
    public class MenuItem
    {
        private String _ID;
        private String _Title;
        private String _LinkRef;

        public MenuItem(String ID, String Title, String LinkRef)
        {
            this._ID = ID;
            this._Title = Title;
            this._LinkRef = LinkRef;
        }

        public String GetHTML()
        {
            return "<li id='" + _ID + "' runat='server'><a href='#' onclick='" + _LinkRef + "'>" + _Title + "</a></li>";
        }
    }

    public class Menu
    {
        public String _ID;
        public String _Title;
        public List<MenuItem> _MenuItems;
        public List<Menu> _SubMenu;

        public Menu(String ID, String Title)
        {
            this._ID = ID;
            this._Title = Title;
            this._MenuItems = new List<MenuItem>();
            this._SubMenu = new List<Menu>();
        }

        public void AddMenuItem(String ID, String Title, String LinkRef)
        {
            MenuItem Item = new MenuItem(ID, Title, LinkRef);

            if (!MenuItemExists(Item))
                _MenuItems.Add(Item);

        }

        public void AddMenu(Menu _Menu)
        {
            _SubMenu.Add(_Menu);
        }

        public Boolean MenuItemExists(MenuItem Item)
        {
            if (_MenuItems.Contains(Item))
                return true;

            foreach (Menu indMenu in _SubMenu)
            {
                if (indMenu.MenuItemExists(Item))
                    return true;
            }

            return false;
        }

        public Menu GetMenu(String ID)
        {
            if (_ID == ID)
                return this;

            Menu objMenu = null;

            foreach (Menu indMenu in _SubMenu)
            {
                objMenu = indMenu.GetMenu(ID);
                if (objMenu != null) break;
            }

            return objMenu;
        }

        public String GetMenuHTM()
        {
            StringBuilder menuHtm = new StringBuilder();

            if (_Title == String.Empty && _ID == String.Empty)
                menuHtm.Append("<ul id='nav'>");

            else
            {
                menuHtm.Append("<li id='" + _ID + "' runat='server'><a href='#'>" + _Title + "</a>");
                menuHtm.Append("<ul>");
            }

            foreach (Menu indMenu in _SubMenu)
            {
                menuHtm.Append(indMenu.GetMenuHTM());
            }

            foreach (MenuItem Item in _MenuItems)
            {
                menuHtm.Append(Item.GetHTML());
            }

            if (_Title == String.Empty && _ID == String.Empty)
                menuHtm.Append("</ul>");

            else
                menuHtm.Append("</ul></li>");


            return menuHtm.ToString();
        }

        public static String ConstructMenu(String[] ModuleNames, String[] Titles, String[] LinkRefs)
        {
            if (ModuleNames.Length != Titles.Length ||
                ModuleNames.Length != LinkRefs.Length ||
                Titles.Length != LinkRefs.Length ||
                ModuleNames.Length == 0)

                return String.Empty;

            StringBuilder sb = new StringBuilder();
            String[] modules;
            Menu MainMenu = new Menu(String.Empty, String.Empty);
            Menu tempMenu;
            String menuId = String.Empty;

            for (int i = 0; i < ModuleNames.Length; i++)
            {
                modules = ModuleNames[i].Split('_');

                if (modules.Length < 2)
                    return String.Empty;

                menuId = "li";

                for (int j = 1; j < modules.Length; j++)
                {
                    if (modules.Length != j + 1)
                    {
                        if (MainMenu.GetMenu(menuId + "_" + modules[j]) != null)
                        {
                            menuId += "_" + modules[j];
                            continue;
                        }

                        tempMenu = MainMenu.GetMenu(menuId);

                        menuId += "_" + modules[j];

                        if (tempMenu == null)
                            MainMenu.AddMenu(new Menu(menuId, modules[j]));

                        else
                            tempMenu.AddMenu(new Menu(menuId, modules[j]));
                    }
                    else
                    {

                        tempMenu = MainMenu.GetMenu(menuId);

                        if (tempMenu == null)
                            MainMenu.AddMenuItem(menuId + "_" + modules[j], Titles[i], LinkRefs[i]);

                        else
                            tempMenu.AddMenuItem(menuId + "_" + modules[j], Titles[i], LinkRefs[i]);
                    }

                }

            }
            return MainMenu.GetMenuHTM();

        }

    }
}
