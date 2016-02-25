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
    public partial class AdmimPrdStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArea();
                BindStora();
                GetData();
            }
        }
        private void GetData()
        {
            PrdStoragMgr prdStorag = new PrdStoragMgr();

            string prdGuid = "";
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                prdGuid = Request.QueryString["id"].ToString();
            }
            string prdName = txtName.Value.Trim();
            string storaName = ddlStora.SelectedValue;
            string belongArea = ddlBelongArea.SelectedValue;
            string sendArea = ddlSendArea.SelectedValue;
            string storaNumber0 = txtNumber0.Value.Trim();
            string storaNumber1 = txtNumber1.Value.Trim();
            string prompt = ddlPrompt.SelectedValue;
            DataTable dt = prdStorag.MgeGetPrdStora(prdGuid, prdName, storaName, belongArea, sendArea, storaNumber0, storaNumber1, prompt);
            gridData.DataSource = dt;
            gridData.DataBind();
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// 绑定地区
        /// </summary>
        private void BindArea()
        {
            SendAreaMgr area = new SendAreaMgr();
            DataTable dt = area.MgeGetList("");
            ddlBelongArea.DataTextField = "areaName";
            ddlBelongArea.DataValueField = "areaGuid";
            ddlBelongArea.DataSource = dt;
            ddlBelongArea.DataBind();
            ListItem li0 = new ListItem("全部", "");
            ddlBelongArea.Items.Insert(0, li0);

            ddlSendArea.DataTextField = "areaName";
            ddlSendArea.DataValueField = "areaGuid";
            ddlSendArea.DataSource = dt;
            ddlSendArea.DataBind();
            ListItem li1 = new ListItem("全部", "");
            ddlSendArea.Items.Insert(0, li1);
        }

        /// <summary>
        /// 绑定仓库
        /// </summary>
        private void BindStora()
        {
            StoragMgr storag = new StoragMgr();
            DataTable dt = storag.MgeGetAllStorag("");
            ddlStora.DataValueField = "storagGuid";
            ddlStora.DataTextField = "storagName";
            ddlStora.DataSource = dt;
            ddlStora.DataBind();
            ListItem li = new ListItem("全部", "");
            ddlStora.Items.Insert(0, li);

        }


        /// <summary>
        /// 获取配送区域
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string GetSenaArea(string ids)
        {
            string areaStr = "";
            SendAreaMgr area = new SendAreaMgr();
            DataTable dt = area.MgeGetList("");
            var list = dt.AsEnumerable().Select(t => t.Field<Guid>("areaGuid")).ToList();
            string[] strIds = ids.Split(',');
            for (int i = 0; i < strIds.Length; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (strIds[i] == dt.Rows[j]["areaGuid"].ToString())
                    {
                        areaStr += "【" + dt.Rows[j]["areaName"].ToString() + "】 ";
                    }

                }
            }
            return areaStr;

        }


        protected void lkbEdit_Click(object sender, EventArgs e)
        {
            GetData();
            int index = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            gridData.EditIndex = index;

            Label labStora = gridData.Rows[index].Cells[3].FindControl("labStoraName") as Label;
            DropDownList ddlStoraSelect = gridData.Rows[index].Cells[3].FindControl("ddlStoraSelect") as DropDownList;
            labStora.Visible = false;
            ddlStoraSelect.Visible = true;

            StoragMgr storag = new StoragMgr();
            DataTable dt = storag.MgeGetAllStorag("");
            ddlStoraSelect.DataValueField = "storagGuid";
            ddlStoraSelect.DataTextField = "storagName";
            ddlStoraSelect.DataSource = dt;
            ddlStoraSelect.DataBind();
            ddlStoraSelect.Items.FindByText(labStora.Text).Selected = true;



        }
        //修改库存
        protected void lkbUpdate_Click(object sender, EventArgs e)
        {
            int index = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            HiddenField hidID = gridData.Rows[index].Cells[0].FindControl("hidId") as HiddenField;
            if (hidID != null)
            {
                Guid psid = new Guid(hidID.Value);
                DropDownList ddlStoraSelect = gridData.Rows[index].Cells[3].FindControl("ddlStoraSelect") as DropDownList;
                string storagGuid = ddlStoraSelect.SelectedValue;
                int storaNumber = gridData.Rows[index].Cells[6].Text.Trim().ToInt();
                int promptNumber = gridData.Rows[index].Cells[6].Text.Trim().ToInt();

                PrdStoragMgr prdStorag = new PrdStoragMgr();
                bool b = prdStorag.MgeUpdate(psid, storagGuid, storaNumber, promptNumber);
                if (b)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert3", "alert('修改成功')", true);
                }
                gridData.EditIndex = -1;
                GetData();
            }
        }





        protected void gridData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridData.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GetData();

            Label labStora = gridData.Rows[index].Cells[2].FindControl("labStoraName") as Label;
            DropDownList ddlStoraSelect = gridData.Rows[index].Cells[2].FindControl("ddlStoraSelect") as DropDownList;
            labStora.Visible = false;
            ddlStoraSelect.Visible = true;

            StoragMgr storag = new StoragMgr();
            DataTable dt = storag.MgeGetAllStorag("");
            ddlStoraSelect.DataValueField = "storagGuid";
            ddlStoraSelect.DataTextField = "storagName";
            ddlStoraSelect.DataSource = dt;
            ddlStoraSelect.DataBind();
            if (ddlStoraSelect.Items.FindByText(labStora.Text) != null)
            {
                ddlStoraSelect.Items.FindByText(labStora.Text).Selected = true;
            }
        }

        protected void gridData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridData.EditIndex = -1;
            GetData();
        }


        //更新
        protected void gridData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int index = e.RowIndex;

            HiddenField hidID = gridData.Rows[index].Cells[0].FindControl("hidId") as HiddenField;
            if (hidID != null && !string.IsNullOrEmpty(hidID.Value))
            {
                Guid psid = new Guid(hidID.Value);
                DropDownList ddlStoraSelect = gridData.Rows[index].Cells[3].FindControl("ddlStoraSelect") as DropDownList;
                string storagGuid = ddlStoraSelect.SelectedValue;

                int storaNumber = ((TextBox)(gridData.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToInt();
                int promptNumber = ((TextBox)(gridData.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToInt();

                PrdStoragMgr prdStorag = new PrdStoragMgr();
                bool b = prdStorag.MgeUpdate(psid, storagGuid, storaNumber, promptNumber);
                if (b)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('修改成功')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('该产品不属于任何仓库，请联系仓库管理员核查数据！')", true);
            }
            gridData.EditIndex = -1;
            GetData();
        }

    }
}