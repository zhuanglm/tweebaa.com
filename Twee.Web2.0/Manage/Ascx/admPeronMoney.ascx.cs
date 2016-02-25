using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage.Ascx
{
    public partial class admPeronMoney : System.Web.UI.UserControl
    {
        private static int flag = 0;
        private static string userGuid = "";
        private static int pageSize = ConfigParamter.pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AspNetPager1.PageSize = pageSize;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    userGuid = Request.QueryString["id"].ToString();
                    BindData();
                }
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnAll_Click(object sender, EventArgs e)
        {
            // flag = 1;
            //  BindData("");
        }



        public void BindData()
        {
            MoneyMgr money = new MoneyMgr();
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startId = pageSize * pageIndex + 1;
            int endId = startId + pageSize - 1;


            DataTable dt = money.MgeGetListByPage(userGuid, "", "", ddlType.SelectedValue, txtDate1.Value.Trim(), txtDate2.Value.Trim(), ddlState.SelectedValue, startId, endId, "");
            if (dt != null)
            {
                repData.DataSource = dt;
                repData.DataBind();
            }

            AspNetPager1.RecordCount = money.MgeGetRecordCount(userGuid, "", "", ddlType.SelectedValue, txtDate1.Value.Trim(), txtDate2.Value.Trim(), ddlState.SelectedValue, startId, endId, "");

            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, this.AspNetPager1.PageSize });

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
    }
}