using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.User
{
    public partial class login_sns : System.Web.UI.Page
    {

            public string op = string.Empty;//主要标识要跳转的页面
            public string args = string.Empty;//主要标识url中的参数

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(Request["op"]))
                    op = Request["op"].Trim();

                //////Crosss Site Domain Scripting
                if (op.Length > 30 || op.IndexOf('%') >= 0 || op.ToLower().IndexOf("script") >= 0)
                {
                    op = string.Empty;
                    args = string.Empty;
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('OP not valid')", true);
                    return;
                }

                if (op == "buy")
                    args = Request["id"].ToString();
                if (op == "submitreview")
                    args = Request["id"].ToString();
                if (op == "preSaleBuy")
                    args = Request["id"].ToString();
                if (op == "saleBuy")
                    args = Request["id"].ToString();
                if (op == "CollageReview")
                    args = Request["id"].ToString();
                if (op == "tweebot_vote")
                    args = Request["id"].ToString();

            }
        
    }
}