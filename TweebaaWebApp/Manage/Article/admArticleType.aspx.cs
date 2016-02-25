using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Comm;

namespace TweebaaWebApp.Manage.Article
{
    public partial class admArticleType : System.Web.UI.Page
    {
        ArticleTypeMgr mgr = new ArticleTypeMgr();
        private static int pageSize = ConfigParamter.pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewBind();
            }
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        //private void TypeBind()
        //{
        //    ddlType.Items.Add(new ListItem("--请选择--", "-1"));
        //    mgr.GetModelList("state=1").ForEach(s =>
        //    {
        //        ddlType.Items.Add(new ListItem(s.typename, s.id.ToString()));
        //    });
        //}

        private void GridViewBind()
        {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startIndex = pageSize * pageIndex + 1;
            int endIndex = startIndex + pageSize - 1;
            string typeName = txtName.Value;
            string state = ddlState.SelectedItem.Value;
            string startTime = txtDateStart.Value;
            string endTime = txtDateEnd.Value;
            string where =" 1=1 ";
            if (!string.IsNullOrEmpty(typeName))
                where += " and T.typename like '%"+typeName+"%'";
            if (!string.IsNullOrEmpty(state))
                where += " and T.state='"+state+"'";
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                where += " and T.createtime>='" + startTime + "' and T.createtime<='" + endTime + "'";

            gridData.DataSource = mgr.GetListByPage(where, string.Empty, startIndex, endIndex);
            gridData.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GridViewBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridViewBind();
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (mgr.Delete(id)) {
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>alert('删除成功');</script>");
                    GridViewBind();
                }
            }
        }

    }
}