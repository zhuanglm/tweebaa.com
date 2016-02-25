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
    public partial class adminAddStorage : System.Web.UI.Page
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
            BindArea();
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {

                string id = Request.QueryString["id"].ToString();
                StoragMgr storag = new StoragMgr();
                DataTable dt = storag.MgeGetList(" s.storagGuid='" + id + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["storagName"].ToString();
                    txtRem.Text = dt.Rows[0]["remarktxt"].ToString();
                    string belongArea = dt.Rows[0]["belongArea"].ToString();
                    string sendArea = dt.Rows[0]["sendArea"].ToString();
                    if (!string.IsNullOrEmpty(belongArea) && ddlBelogArea.Items.FindByValue(belongArea) != null)
                    {
                        ddlBelogArea.Items.FindByValue(belongArea).Selected = true;
                    }
                    if (!string.IsNullOrEmpty(sendArea))
                    {
                        string[] bID = sendArea.Split(',');
                        for (int i = 0; i < bID.Length; i++)
                        {
                            if (ckbArea.Items.FindByValue(bID[i]) != null)
                            {
                                ckbArea.Items.FindByValue(bID[i]).Selected = true;
                            }

                        }
                    }

                }
            }

        }
        /// <summary>
        /// 绑定地区
        /// </summary>
        private void BindArea()
        {
            SendAreaMgr area = new SendAreaMgr();
            DataTable dt = area.MgeGetList("");
            ddlBelogArea.DataTextField = "areaName";
            ddlBelogArea.DataValueField = "areaGuid";
            ddlBelogArea.DataSource = dt;
            ddlBelogArea.DataBind();

            ckbArea.DataTextField = "areaName";
            ckbArea.DataValueField = "areaGuid";
            ckbArea.DataSource = dt;
            ckbArea.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sendArea = "";
            for (int i = 0; i < ckbArea.Items.Count; i++)
            {
                if (ckbArea.Items[i].Selected == true)
                {
                    sendArea += ckbArea.Items[i].Value + ",";
                }
            }

            bool b = false;
            StoragMgr storag = new StoragMgr();
            string resu = "";
            if (!string.IsNullOrEmpty(Request.QueryString["type"]))
            {
                string type = Request.QueryString["type"].ToString();
                //增加
                if (type == "1")
                {

                    b = storag.MgeAdd(txtName.Text.Trim(), ddlBelogArea.SelectedValue, sendArea.TrimEnd(','), txtRem.Text.Trim());
                    if (b)
                    {
                        resu = "添加成功";
                    }
                    else
                    {
                        resu = "添加失败";
                    }

                }
                //修改
                else if (type == "2")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        string id = Request.QueryString["id"].ToString();
                        b = storag.MgeUpdate(id, txtName.Text.Trim(), ddlBelogArea.SelectedValue, sendArea.TrimEnd(','), txtRem.Text.Trim());
                        if (b)
                        {
                            resu = "修改成功";
                        }
                        else
                        {
                            resu = "修改失败";
                        }

                    }

                }
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('" + resu + "')", true);
            }
        }
    }
}