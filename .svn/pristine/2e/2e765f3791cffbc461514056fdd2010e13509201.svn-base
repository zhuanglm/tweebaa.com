using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage.Ascx
{
    public partial class orders : System.Web.UI.UserControl
    {
        public string state { get; set; }
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

            //StringBuilder strWhere = new StringBuilder(" 1=1 ");
            //DateTime? beginTime = txtTime1.Text.ToDateTime();
            //DateTime? endTime = txtTime2.Text.ToDateTime();

            //if (beginTime != null)
            //{
            //    strWhere.Append(" and a.addtime>='" + beginTime + "'");
            //}
            //if (endTime != null)
            //{
            //    strWhere.Append(" and a.addtime<='" + endTime + "'");
            //}
            //if (txtCode.Text != "")
            //{
            //    string txt = txtCode.Text.Trim();
            //    if (ddlType.SelectedValue == "0")
            //    {
            //        strWhere.Append(" and a.guidno='" + txt + "'");
            //    }
            //    if (ddlType.SelectedValue == "1")
            //    {
            //        strWhere.Append(" and c.username='" + txt + "'");
            //    }
            //    if (ddlType.SelectedValue == "2")
            //    {
            //        strWhere.Append(" and a.reciveName='" + txt + "'");
            //    }

            //}
            //strWhere.Append(" and a.wnstat=" + state);

            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startId = pageSize * pageIndex + 1;
            int endId = startId + pageSize - 1;

            OrderMgr order = new OrderMgr();
            string date1 = txtTime1.Text.Trim();
            string date2 = txtTime2.Text.Trim();
            string orderCode = ddlType.SelectedIndex == 0 ? txtCode.Text.Trim() : "";
            string user = ddlType.SelectedIndex == 1 ? txtCode.Text.Trim() : "";
            string revive = ddlType.SelectedIndex == 2 ? txtCode.Text.Trim() : "";
            state = state == null ? "" : state;
            DataTable dt = order.MgeGetListAll("",date1, date2, orderCode, user, revive, "", state, startId, endId);
            gridData.DataSource = dt;
            gridData.DataBind();

            AspNetPager1.RecordCount = order.MgeGetRecordCount("",date1, date2, orderCode, user, revive, state);
            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });
        }
        //搜索
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetAll();

        }
        //导出
        protected void btnOutput_Click(object sender, EventArgs e)
        {


        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetAll();
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // e.Row.Cells[3].FindControl("divImg").i
            }
        }
        public string GetImg(string headGuid, string name, string pid)
        {
             OrderMgr order = new OrderMgr();

             DataTable dt = order.MgeGetOrderImg(headGuid);
            //var list = dt.AsEnumerable().Select(t => t.Field<Decimal>("fileurl")).ToList();
            StringBuilder strImg = new StringBuilder();

            //<img src="../<%#Eval("fileurl") %>" alt="<%#Eval("name") %>" width="50px" height="50px" /></a>

            foreach (DataRow dr in dt.Rows)
            {
                strImg.Append(" <a href='../newsaleproduct/" + pid + "' target='_blank'>");
                strImg.Append(" <img src='../");
                strImg.Append(dr["fileurl"]);
                strImg.Append("' alt='");
                strImg.Append(name);
                strImg.Append("' width=50 height=50 />");
                strImg.Append("</a>");
            }

            return strImg.ToString();
        }
    }
}