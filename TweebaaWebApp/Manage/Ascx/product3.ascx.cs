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
    public partial class product3 : System.Web.UI.UserControl
    {
        private static int pageSize = ConfigParamter.pageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
            gridData.Attributes.Add("style", "word-break:break-word;word-wrap:break-all;");
            if (!IsPostBack)
            {
                AspNetPager1.PageSize = pageSize;
                GetAll();
            }
        }
        public void GetAll()
        {
            PrdMgr prd = new PrdMgr();
       
            string prdName = txtName.Value.Trim();
            string userName = txtUser.Value.Trim();
            int index = AspNetPager1.CurrentPageIndex - 1;
            int startId = pageSize * index + 1;
            int endId = startId + pageSize - 1;
            DataTable dt = prd.MgeGetListSale(prdName, userName, "3", "", startId, endId);
            if (dt != null)
            {
                gridData.DataSource = dt;
                gridData.DataBind();
            }
            AspNetPager1.RecordCount = prd.MgeGetListReviewCount(prdName, userName, "3");
            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });

        }
        public string GetSum(object count, object price)
        {
            if (count != null && price != null)
            {
                return (count.ToString().ToInt() * price.ToString().ToDecimal()).ToString();
            }
            return "0";

        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (StrState == "2")
                //{
                //    e.Row.Cells[0].FindControl("hrfInfo2").Visible = false;
                //}
                //if (StrState == "3")
                //{
                //    e.Row.Cells[0].FindControl("hrfInfo1").Visible = false;
                //}
            }
        }

        //搜索
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetAll();

        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetAll();
        }
    }
}