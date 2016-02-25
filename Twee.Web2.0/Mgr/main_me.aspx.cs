﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using Newtonsoft.Json;

namespace TweebaaWebApp2.Mgr
{
    public partial class main : System.Web.UI.Page
    {
        public string current_username = string.Empty;
        public Guid current_guid;
       public string _treeJson = string.Empty;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CURRENT_USER"] == null)
                {
                    Response.Redirect("~/Mgr/index.aspx");
                }
                else
                {
                    Twee.Model.MgrUser adm = (Twee.Model.MgrUser)Session["CURRENT_USER"];
                    current_username = adm.sName;
                    current_guid = adm.guid;
                }
            }
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\Mgr\\mgrConfig\\MgrTreeConfig.txt";
            _treeJson = mgrcomm.mgrHelper._MgrReadConfig(configPath);

            List<int> funclist = new List<int>{1101,111,121,123,1321};
            List<int> droplist = new List<int>();

            List<SysAdmMenu> menulist = JsonConvert.DeserializeObject<List<SysAdmMenu>>(_treeJson);

            for (int i = 0; i < menulist.Count; i++)
            {
                if (funclist.Contains(menulist[i].id))
                    continue;

                for (int j = menulist[i].children.Count - 1; j >= 0; j--)
                {
                    if (!funclist.Contains(menulist[i].children[j].id))
                    {
                        droplist.Add(menulist[i].children[j].id);
                    }
                }

            }


            if (droplist.Count > 0)
            {
                foreach (int x in droplist)
                {
                    for (int i = 0; i < menulist.Count; i++)
                    {
                        if (menulist[i].id == x)
                            menulist.Remove(menulist[i]);
                        else
                        {
                            for (int j = 0; j < menulist[i].children.Count; j++)
                                if (menulist[i].children[j].id == x)
                                    menulist[i].children.Remove(menulist[i].children[j]);

                            if (menulist[i].children.Count == 0)
                                menulist.Remove(menulist[i]);

                        }
                    }
                }
                _treeJson = JsonConvert.SerializeObject(menulist);
                //System.Diagnostics.Debug.Write(_treeJson);
            }
            
        }

    }

    public class SysAdmMenu
    {
        public int id;
        public string text;
        public string state;
        public List<SysAdmMenu_Child> children;
    }

    public class SysAdmMenu_Child
    {
        public int id;
        public string text;
        public MenuAttribute attributes;
    }

    public struct MenuAttribute
    {
        public string url;
    }
}