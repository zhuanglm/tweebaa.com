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
    public partial class admUserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    BindUserInfo();
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string userID = Request.QueryString["id"].ToString();
                Guid guid = new Guid(userID);
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('请输入姓名')", true);

                }
                UserMgr user = new UserMgr();

                DateTime dt = txtBirth.Text.ToDateTime() == null ? Convert.ToDateTime("1900-01-01") : txtBirth.Text.ToDateTime().Value;
                bool b = user.MgeUpdate(ddlState.SelectedValue.ToInt(), txtName.Text.Trim(), txtPhone.Text.Trim(), dt, "", guid);
                if (b == true)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('修改成功')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert3", "alert('操作失败，请重试')", true);


                }
                BindUserInfo();

            }

        }

        public void BindUserInfo()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string userID = Request.QueryString["id"].ToString();
                UserMgr user = new UserMgr();
                DataTable dt = user.MgeGetList(" u.guid='" + userID + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtName.Text = dr["username"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtPhone.Text = dr["phone"].ToString();
                    txtSex.Text = "";
                    txtBirth.Text = dr["birthday"].ToString();
                    txtAddress.Text = "";
                    if (!string.IsNullOrEmpty(dr["wnstat"].ToString()))
                    {
                        ddlState.Items.FindByValue(dr["wnstat"].ToString()).Selected = true;
                    }

                }

            }
        }

        public string GetID()
        {
            string userID = Request.QueryString["id"].ToString();
            return userID;
        }

    }
}