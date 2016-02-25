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
            DataTable dtActivated = mgr.MgeGetActivatedUserDailyRegisterCount();

            lblTotal.Text = "0";
            lblActivatedTotal.Text = "0";
            if (dt != null)
            {
                object objTotal = dt.Compute("SUM(count)", null);
                lblTotal.Text = objTotal.ToString();
            }

            if (dtActivated != null)
            {
                object objActivatedTotal = dtActivated.Compute("SUM(count)", null);
                lblActivatedTotal.Text = objActivatedTotal.ToString();
            }
            gvwUserRegCount.DataSource = dt;
            gvwUserRegCount.DataBind();
        }
    } 
}