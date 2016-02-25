using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;

using Twee.Mgr;

namespace TweebaaWebApp.User
{
    public partial class UserRegCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserMgr mgr = new UserMgr();
            DataTable dt = mgr.MgeGetUserDailyRegisterCount();

            int iTotal = 0;
            if (dt != null) iTotal = dt.Rows.Count;
            labTotal.Text = iTotal.ToString();

            gvwUserRegCount.DataSource = dt;
            gvwUserRegCount.DataBind();
        }

       }
}