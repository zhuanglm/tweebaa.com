using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Twee.Mgr;
using Twee.Comm;
using Twee.Model;
using AjaxPro;


namespace TweebaaWebApp2.Mgr.sysManager
{
    public partial class GroupList : System.Web.UI.Page
    {
        public int pageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(GroupList));
            if (!IsPostBack)
            {
                AspNetPager1.RecordCount = new AdminstratorMgr().GetGroupCount(string.Empty);
            }
            Bind();
        }

        public void Bind()
        {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startIndex = pageSize * pageIndex + 1;
            int endIndex = startIndex + pageSize - 1;
            string groupName = txtName.Value.Trim();
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(groupName))
            {
                where += " and T.MgrUser_Name like '%" + groupName + "%'";
            }
            
            AspNetPager1.RecordCount = new AdminstratorMgr().GetGroupCount(string.Empty);
            var modelList = new AdminstratorMgr().GetGroupListByPage(where,string.Empty,startIndex,endIndex);
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
        public string DeleteGroup(string sMgrGroupID)
        {
            try
            {
                if (new AdminstratorMgr().DeleteGroup(int.Parse(sMgrGroupID)) > 0)
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