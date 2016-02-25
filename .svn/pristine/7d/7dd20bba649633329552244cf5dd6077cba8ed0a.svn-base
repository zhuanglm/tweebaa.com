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
    public partial class admPersonShare : System.Web.UI.UserControl
    {
        private static string userGuid = "";
        private static int pageSize = ConfigParamter.pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

            ShareMgr share = new ShareMgr();
            string strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                userGuid = Request.QueryString["id"].ToString();
                strWhere += " and T.userguid='" + userGuid + "' ";
            }
            if (!string.IsNullOrEmpty(txtName.Value))
            {
                strWhere += " and T.name='" + txtName.Value.Trim() + "' ";
            }

            if (!string.IsNullOrEmpty(txtDate1.Value))
            {
                strWhere += " and T.addtime>='" + txtDate1.Value.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtDate2.Value))
            {
                strWhere += " and T.addtime<='" + txtDate2.Value.Trim() + "' ";
            }

            int iTotalCount=0;
            DataTable dt = share.MgeGetPersonShare(strWhere, "", startId, endId, out iTotalCount);
            if (dt != null)
            {
                repData.DataSource = dt;
                repData.DataBind();
            }

            AspNetPager1.RecordCount = share.MgeGetAllShareCount(strWhere);
            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });

        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetAll();
        }
    }
}