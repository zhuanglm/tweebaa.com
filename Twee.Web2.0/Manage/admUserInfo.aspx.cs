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
    public partial class admUserInfo : System.Web.UI.Page
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
                    txtLastLogin.Text = dr["acttime"].ToString();
                    txtRegisTime.Text = dr["regtime"].ToString();
                }

            }
        }
        public void BindReviewInfo()
        {


        }
        public void BindPubInfo()
        {


        }
        public void BindShareInfo()
        {


        }

        public string GetID()
        {
            string userID = Request.QueryString["id"].ToString();
            return userID;
        }

    }
}