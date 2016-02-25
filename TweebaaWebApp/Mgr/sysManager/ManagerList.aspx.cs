﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Twee.Mgr;
using Twee.Comm;
using Twee.Model;
using AjaxPro;


namespace TweebaaWebApp.Mgr.sysManager
{
    public partial class ManagerList : System.Web.UI.Page
    {
        public int pageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(ManagerList));
            if (!IsPostBack)
            {
                AspNetPager1.RecordCount = new AdminstratorMgr().GetRecordCount(string.Empty);
            }
            Bind();
        }

        public void Bind()
        {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startIndex = pageSize * pageIndex + 1;
            int endIndex = startIndex + pageSize - 1;
            string userName = txtName.Value.Trim();
            string startTime = ddStart.Value.Trim();
            string endTime = ddEnd.Value.Trim();
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(userName))
            {
                where += " and T.loginNo like '%" + userName + "%'";
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                where += " and createtime between '"+startTime+"' and '"+endTime+"'";
            }
            AspNetPager1.RecordCount = new AdminstratorMgr().GetRecordCount(string.Empty);
            var modelList = new AdminstratorMgr().GetListByPage(where,string.Empty,startIndex,endIndex);
            Repeater1.DataSource = modelList;
            Repeater1.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Bind();
        }

        [AjaxPro.AjaxMethod]
        public string DeleteUser(string sMgrUserID)
        {
            try
            {
                if (new AdminstratorMgr().Delete(int.Parse(sMgrUserID)))
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}