﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using AjaxPro;
using System.Configuration;

namespace TweebaaWebApp2.User
{
    public partial class loginGuest : System.Web.UI.Page
    {
        public string op1 = string.Empty;//主要标识要跳转的页面
        public string args = string.Empty;//主要标识url中的参数

        public string _knowWay = string.Empty;

        public string sGuestCheckoutURL;
        public string browserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            browserName = myBrowserCaps.Browser;

            Utility.RegisterTypeForAjax(typeof(loginGuest));
            /*
            int IsSandbox = int.Parse(ConfigurationManager.AppSettings.Get("IsPaypal_Sandbox").ToString());
            if (IsSandbox > 0)
            {*/
                sGuestCheckoutURL = "/Product/CheckoutShipping.aspx";
           /*
             }
            else
            {
                sGuestCheckoutURL = "/Product/shopOrder.aspx";
            }*/
            if (!string.IsNullOrEmpty(Request["op"]))
                op1 = Request["op"].Trim();
            if (op1 == "buy")
                args = Request["id"].ToString();
            if (op1 == "submitreview")
                args = Request["id"].ToString();
            if (op1 == "preSaleBuy")
                args = Request["id"].ToString();
            if (op1 == "saleBuy")
                args = Request["id"].ToString();
            if (op1 == "shopOrder")
                args = Request["id"].ToString();

            if (!IsPostBack)
            {
                /*
                Twee.Mgr.CountryMgr mgr = new Twee.Mgr.CountryMgr();
                DataSet ds = mgr.GetAllList();
                if (ds != null && ds.Tables.Count > 0)
                {
                    selectCountry.DataSource = ds.Tables[0];
                    selectCountry.DataValueField = "id";
                    selectCountry.DataTextField = "country";
                    selectCountry.DataBind();
                }

                Twee.Mgr.knowTweeWayMgr wayMgr = new Twee.Mgr.knowTweeWayMgr();
                var wayDt = wayMgr.GetModelList(string.Empty);
                StringBuilder op = new StringBuilder();
                if (wayDt != null && wayDt.Count > 0)
                {
                    foreach (var item in wayDt)
                    {
                        op.AppendFormat("<option value='{0}'>{1}</option>", item.id.ToString(), item.way);
                    }
                }
                _knowWay = "<option value='-1' selected>--please select--</option><option value='-2'>Friend</option>" + op.ToString();
                 **/
            }
        }

        [AjaxPro.AjaxMethod]
        public string verfy_account(string op, string str)
        {
            Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
            string retureString = "success";
            if (op == "email")
            {
                if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.Trim()))
                {
                    retureString = "empty";
                }
                else
                {
                    if (mgr.ExistsByEmail(str))
                        retureString = "fail";
                }
            }
            if (op == "username")
            {
                if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.Trim()))
                {
                    retureString = "empty";
                }
                else
                {
                    if (mgr.ExistsByUserName(str))
                        retureString = "fail";
                }
            }
            return retureString;
        }
    }
}