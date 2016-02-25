using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp.Manage.Ascx
{
    public partial class admPeronPublish : System.Web.UI.UserControl
    {
        private static int pageSize = ConfigParamter.pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AspNetPager1.PageSize = pageSize;
                GetAll();
            }
        }

        //搜索
        protected void btnSerch_Click(object sender, EventArgs e)
        {

            GetAll();
        }

        public void GetAll()
        {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startId = pageSize * pageIndex + 1;
            int endId = startId + pageSize - 1;

            PrdMgr prd = new PrdMgr();
            string strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string userGuid = Request.QueryString["id"].ToString();
                strWhere += " and T.userGuid='" + userGuid + "' ";
            }
            if (!string.IsNullOrEmpty(txtName.Value))
            {
                strWhere += " and T.name='" + txtName.Value.Trim() + "' ";
            }
            if (ddlType.SelectedIndex != 0)
            {
                strWhere += " and T.wnstat=" + ddlType.SelectedValue;
            }
            if (!string.IsNullOrEmpty(txtDate1.Value))
            {
                strWhere += " and T.addtime>='" + txtDate1.Value.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtDate2.Value))
            {
                strWhere += " and T.addtime<='" + txtDate2.Value.Trim() + "' ";
            }

            DataTable dt = prd.MgeGetPersonPublish(strWhere, "", startId, endId);
            if (dt != null)
            {
                repData.DataSource = dt;
                repData.DataBind();
            }
            AspNetPager1.RecordCount = prd.MgeGetRecordCount(strWhere);
            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });

        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetAll();
        }
    }
}