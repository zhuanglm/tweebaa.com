using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class AdmimManageArea : System.Web.UI.Page
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
            SendAreaMgr area = new SendAreaMgr();
            DataTable dt = area.MgeGetList(" ");
            gridData.DataSource = dt;
            gridData.DataBind();

        }
        protected void lkbEdit_Click(object sender, EventArgs e)
        {
            int index = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            gridData.EditIndex = index;
            gridData.Rows[index].Cells[4].Visible = true;
            GetData();
        }
        protected void lkbDele_Click(object sender, EventArgs e)
        {
            int index = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            SendAreaMgr area = new SendAreaMgr();
            Guid guid = new Guid(gridData.DataKeys[index].Value.ToString());
            bool resu = area.MgeDelete(guid);
            if (resu)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('删除成功')", true);

            }
            GetData();

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
            SendAreaMgr area = new SendAreaMgr();
            Guid guid = new Guid(gridData.DataKeys[e.RowIndex].Value.ToString());
            bool resu = area.MgeDelete(guid);
            if (resu)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('删除成功')", true);
            }
            GetData();
        }

        //更新
        protected void gridData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SendAreaMgr area = new SendAreaMgr();
            string areaName = ((TextBox)(gridData.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            string remakTxt = ((TextBox)(gridData.Rows[e.RowIndex].Cells[2].Controls[0])).Text;

            bool resu = false;
            if ((gridData.Rows[0].Cells[4].Controls[0] as LinkButton).Text == "增加")
            {
                resu = area.MgeAdd(areaName, remakTxt);
                if (resu)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert3", "alert('添加成功')", true);
                }
            }
            else
            {
                string guid = gridData.DataKeys[e.RowIndex].Value.ToString();
                Guid guidUpdate = new Guid(guid);
                resu = area.MgeUpdate(guidUpdate, areaName, remakTxt);
                if (resu)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert4", "alert('修改成功')", true);
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

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SendAreaMgr area = new SendAreaMgr();
            DataTable dt = area.MgeGetList("");

            DataView dv = dt.DefaultView;


            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            dv = dt.DefaultView;

            gridData.EditIndex = 0;

            gridData.DataSource = dv;
            gridData.DataKeyNames = new string[] { "areaGuid" };
            gridData.DataBind();
            //  ((TextBox)(gridData.Rows[0].Cells[1].FindControl("txtArea"))).ReadOnly = false;
            //  ((TextBox)(gridData.Rows[0].Cells[2].FindControl("txtRemark"))).ReadOnly = false;


            (gridData.Rows[0].Cells[4].Controls[0] as LinkButton).Text = "增加";
        }
    }
}