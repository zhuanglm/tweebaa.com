using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp.Manage
{
    public partial class admUser : System.Web.UI.Page
    {
        private static int pageSize = ConfigParamter.pageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AspNetPager1.PageSize = pageSize;
                BindData();
            }
        }

        //搜索
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindData();

        }
        //产品控件传参     0 全部，1评审区，2预售区，3销售区
        private void BindData()
        {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            UserMgr user = new UserMgr();

            string strWhere1 = " 1=1 ";
            string strWhere2 = " 1=1 ";
            if (!string.IsNullOrEmpty(txtUser.Value))
            {
                strWhere1 += " and username='" + txtUser.Value.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtEmail.Value))
            {
                strWhere1 += " and email='" + txtEmail.Value.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtDate1.Value))
            {
                strWhere1 += " and regtime>='" + txtDate1.Value.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtDate2.Value))
            {
                strWhere1 += " and regtime<='" + txtDate2.Value.Trim() + "' ";
            }
            if (ddlState.SelectedIndex != 0)
            {
                strWhere1 += " and wnstat='" + ddlState.SelectedValue + "' ";
            }

            int startId = pageSize * pageIndex + 1;
            int endId = startId + pageSize - 1;

            DataTable dt = user.MgeGetListByPage(strWhere1, strWhere2, "", startId, endId);
            gridData.DataSource = dt;
            gridData.DataBind();
            AspNetPager1.RecordCount = user.MgeGetRecordCount(strWhere1);

            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();

        }
    }
}