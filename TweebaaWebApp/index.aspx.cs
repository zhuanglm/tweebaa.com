﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp
{
    public partial class index : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string txtLogion;
        public string _popbox = "block;";
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (null != userGuid)
            {
                txtLogion = "1";
                _popbox = "none;";
            }
            else
            {
                txtLogion = "0";
            }
        }
    }
}