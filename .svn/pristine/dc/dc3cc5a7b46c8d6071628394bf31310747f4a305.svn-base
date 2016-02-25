using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.User
{
    public partial class logion : System.Web.UI.Page
    {
        public string op = string.Empty;//主要标识要跳转的页面
        public string args = string.Empty;//主要标识url中的参数

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["op"]))
                op = Request["op"].Trim();
            if (op == "buy")
                args = Request["id"].ToString();
            if(op=="submitreview")
                args=Request["id"].ToString();
            if (op == "preSaleBuy")
                args = Request["id"].ToString();
            if (op == "saleBuy")
                args = Request["id"].ToString();

        }
    }
}