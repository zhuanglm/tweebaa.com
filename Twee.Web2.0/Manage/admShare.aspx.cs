using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class admShare : System.Web.UI.Page
    {
        private static string visitcount = "0";
        private static string successcount = "0";
        private static string prdcount = "0";
        private static string prdsumMoney = "0";
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

            ShareMgr share = new ShareMgr();
            string strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string userGuid = Request.QueryString["id"].ToString();
                strWhere += " and T.userguid='" + userGuid + "' ";
            }
            if (!string.IsNullOrEmpty(txtName.Value))
            {
                strWhere += " and T.name='" + txtName.Value.Trim() + "' ";
            }
            if (dllType.SelectedIndex != 0)
            {
                strWhere += " and T.sharetype='" + dllType.SelectedItem.Text + "' ";
            }

            if (!string.IsNullOrEmpty(txtDate1.Value))
            {
                strWhere += " and T.addtime>='" + txtDate1.Value.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtDate2.Value))
            {
                strWhere += " and T.addtime<='" + txtDate2.Value.Trim() + "' ";
            }

            int iTotalCount = 0;
            DataTable dt = share.MgeGetPersonShare(strWhere, "", startId, endId, out iTotalCount);
            if (dt != null)
            {
                var sum1 = dt.AsEnumerable().Select(row => row[5]).ToList();
                var visitcountSum = dt.AsEnumerable().Sum(s => s.Field<int>("visitcount"));
                var successcountSum = dt.AsEnumerable().Sum(s => s.Field<int>("successcount"));
                var prdcountSum = dt.AsEnumerable().Sum(s => s.Field<int>("prdcount"));
                var prdsumMoneySum = dt.AsEnumerable().Sum(s => s.Field<decimal>("prdsumMoney"));

                visitcount = visitcountSum.ToString();
                successcount = successcountSum.ToString();
                prdcount = prdcountSum.ToString();
                prdsumMoney = prdsumMoneySum.ToString();

                gridData.DataSource = dt;
                gridData.DataBind();
            }
            gridData.FooterRow.Cells[2].Text = "总计";
            gridData.FooterRow.Cells[5].Text = visitcount + " 次";
            gridData.FooterRow.Cells[6].Text = successcount + " 次";
            gridData.FooterRow.Cells[7].Text = prdcount + " 件";
            gridData.FooterRow.Cells[8].Text = prdsumMoney + " 元";
            //var sum = dt.AsEnumerable().Sum(s => s.Field<int>("number"));

            AspNetPager1.RecordCount = share.MgeGetAllShareCount(strWhere);
            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });



        }
        protected void gridData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridData.PageIndex = e.NewPageIndex;
            GetAll();
        }
        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //累加
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[2].Text = "总计";
                //e.Row.Cells[5].Text = visitcount + " 次";
                //e.Row.Cells[6].Text = successcount+" 次";
                //e.Row.Cells[7].Text = prdcount+" 件";
                //e.Row.Cells[8].Text = prdsumMoney+" 元";
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetAll();
        }
    }
}