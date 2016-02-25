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
    public partial class admPublistGradeParam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }

        }
        private void GetData()
        {
            PublistGradeParamMgr grade = new PublistGradeParamMgr();
            DataTable dt = grade.MgeGetList(" ");
            gridData.DataSource = dt;
            gridData.DataBind();

        }
        protected void gridData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridData.EditIndex = e.NewEditIndex;

            GetData();

            ((TextBox)(gridData.Rows[e.NewEditIndex].Cells[6].FindControl("txtReviewMin"))).ReadOnly = false;
            ((TextBox)(gridData.Rows[e.NewEditIndex].Cells[6].FindControl("txtReviewMax"))).ReadOnly = false;
            ((TextBox)(gridData.Rows[e.NewEditIndex].Cells[7].FindControl("txtPresaMin"))).ReadOnly = false;
            ((TextBox)(gridData.Rows[e.NewEditIndex].Cells[7].FindControl("txtPresaMax"))).ReadOnly = false;
        }

        protected void gridData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridData.EditIndex = -1;
            GetData();
        }

        //删除
        protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PublistGradeParamMgr grade = new PublistGradeParamMgr();
            Guid guid = new Guid(gridData.DataKeys[e.RowIndex].Value.ToString());
            bool resu = grade.MgeDelete(guid);
            if (resu)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('删除成功')", true);

            }
            GetData();
        }

        //更新
        protected void gridData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            PublistGradeParamMgr gradeParam = new PublistGradeParamMgr();

            int grade = ((TextBox)(gridData.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToInt();
            int integral = ((TextBox)(gridData.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToInt();
            int reviewreward = ((TextBox)(gridData.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToInt();
            int reviewsupportmin = ((TextBox)(gridData.Rows[e.RowIndex].Cells[5].FindControl("txtReviewMin"))).Text.ToInt();
            int reviewsupportmax = ((TextBox)(gridData.Rows[e.RowIndex].Cells[5].FindControl("txtReviewMax"))).Text.ToInt();
            int presaleward = ((TextBox)(gridData.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToInt();
            int presalesupportmin = ((TextBox)(gridData.Rows[e.RowIndex].Cells[7].FindControl("txtPresaMin"))).Text.ToInt();
            int presalesupportmax = ((TextBox)(gridData.Rows[e.RowIndex].Cells[7].FindControl("txtPresaMax"))).Text.ToInt();
            int commissionratio = ((TextBox)(gridData.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToInt();
            bool resu = false;
            if ((gridData.Rows[0].Cells[10].Controls[0] as LinkButton).Text == "增加")
            {
                resu = gradeParam.MgeAdd(grade, integral, reviewreward, presaleward, reviewsupportmin, reviewsupportmax, presalesupportmin, presalesupportmax, commissionratio);
                if (resu)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('添加成功')", true);
                }
            }
            else
            {
                string guid = gridData.DataKeys[e.RowIndex].Value.ToString();
                Guid guidUpdate = new Guid(guid);
                resu = gradeParam.MgeUpdate(guidUpdate, grade, integral, reviewreward, presaleward, reviewsupportmin, reviewsupportmax, presalesupportmin, presalesupportmax, commissionratio);
                if (resu)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert3", "alert('修改成功')", true);
                }
            }
            gridData.EditIndex = -1;
            GetData();
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    //   ((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "javascript:return(confirm('确认删除该条记录吗？'))");


                }
            }
        }
        protected void gridData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tcHeader = e.Row.Cells;
                tcHeader.Clear();



                //第一行表头
                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].Text = "编号</th>";
                tcHeader[0].Attributes.Add("rowspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].Text = "等级</th>";
                tcHeader[1].Attributes.Add("rowspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].Text = "等级积分</th>";
                tcHeader[2].Attributes.Add("rowspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].Text = "评审区</th>";
                tcHeader[3].Attributes.Add("colspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Text = "预售区</th>";
                tcHeader[4].Attributes.Add("colspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].Text = "佣金比例(千分比)</th>";
                tcHeader[5].Attributes.Add("rowspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].Text = "选择</th>";
                tcHeader[6].Attributes.Add("rowspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].Text = "编辑</th>";
                tcHeader[7].Attributes.Add("rowspan", "2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].Text = "删除</th></tr><tr>";
                tcHeader[8].Attributes.Add("rowspan", "2");

                //第二行表头        

                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].Text = "奖励积分</th>";
                // tcHeader[9].Attributes.Add("bgcolor", "Green");
                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].Text = "支持数区间</th>";
                // tcHeader[10].Attributes.Add("bgcolor", "Green");
                tcHeader.Add(new TableHeaderCell());
                tcHeader[11].Text = "奖励积分</th>";
                //  tcHeader[11].Attributes.Add("bgcolor", "Green");
                tcHeader.Add(new TableHeaderCell());
                tcHeader[12].Text = "支持数区间</th>";
                //   tcHeader[12].Attributes.Add("bgcolor", "Green");

            }



        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            PublistGradeParamMgr grade = new PublistGradeParamMgr();
            DataTable dt = grade.MgeGetList("");
            DataView dv = dt.DefaultView;
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            dv = dt.DefaultView;

            gridData.EditIndex = 0;

            gridData.DataSource = dv;
            gridData.DataKeyNames = new string[] { "guid" };
            gridData.DataBind();
            ((TextBox)(gridData.Rows[0].Cells[6].FindControl("txtReviewMin"))).ReadOnly = false;
            ((TextBox)(gridData.Rows[0].Cells[6].FindControl("txtReviewMax"))).ReadOnly = false;
            ((TextBox)(gridData.Rows[0].Cells[7].FindControl("txtPresaMin"))).ReadOnly = false;
            ((TextBox)(gridData.Rows[0].Cells[7].FindControl("txtPresaMax"))).ReadOnly = false;

            (gridData.Rows[0].Cells[10].Controls[0] as LinkButton).Text = "增加";
        }
    }
}