﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Mgr
{
    public partial class main : System.Web.UI.Page
    {
        public string current_username = string.Empty;
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
                }
            }
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\Mgr\\mgrConfig\\MgrTreeConfig.txt";
            _treeJson = mgrcomm.mgrHelper._MgrReadConfig(configPath);

        }



    }
}