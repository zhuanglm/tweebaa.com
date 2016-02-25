using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp.Manage
{
    public partial class admReviewgradeparam : System.Web.UI.Page
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

            ReviewgradeparamMgr grade = new ReviewgradeparamMgr();
            DataTable dt = grade.MgeGetList(" ");
            gridData.DataSource = dt;
            gridData.DataBind();

        }
        protected void gridData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridData.EditIndex = e.NewEditIndex;
            GetData();
        }

        protected void gridData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridData.EditIndex = -1;
            GetData();
        }

        //删除
        protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ReviewgradeparamMgr grade = new ReviewgradeparamMgr();
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

            ReviewgradeparamMgr gradeParam = new ReviewgradeparamMgr();

            int grade = ((TextBox)(gridData.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToInt();
            int integral = ((TextBox)(gridData.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToInt();
            int reviewReward = ((TextBox)(gridData.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToInt();
            int commissionratio1 = ((TextBox)(gridData.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToInt();
            int commissionratio2 = ((TextBox)(gridData.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToInt();
            int commissionratio3 = ((TextBox)(gridData.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToInt();


            bool resu = false;
            if ((gridData.Rows[0].Cells[9].Controls[0] as LinkButton).Text == "增加")
            {
                resu = gradeParam.MgeAdd(grade, integral, reviewReward, commissionratio1, commissionratio2, commissionratio3);
                if (resu)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('添加成功')", true);
                }
            }
            else
            {
                string guid = gridData.DataKeys[e.RowIndex].Value.ToString();
                Guid guidUpdate = new Guid(guid);
                resu = gradeParam.MgeUpdate(guidUpdate, grade, integral, reviewReward, commissionratio1, commissionratio2, commissionratio3);
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

        //新增
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            ReviewgradeparamMgr grade = new ReviewgradeparamMgr();
            DataTable dt = grade.MgeGetList("");
            DataView dv = dt.DefaultView;
            DataRow dr = dt.NewRow();

            dt.Rows.InsertAt(dr, 0);
            dv = dt.DefaultView;
            gridData.EditIndex = 0;
            gridData.DataSource = dv;
            gridData.DataKeyNames = new string[] { "guid" };
            gridData.DataBind();
            (gridData.Rows[0].Cells[9].Controls[0] as LinkButton).Text = "增加";
        }
    }
}