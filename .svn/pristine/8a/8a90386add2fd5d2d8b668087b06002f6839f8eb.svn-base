using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp.Product
{
    public partial class issueWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void checkLogin_click(object sender, EventArgs e)
        {
            Guid? uGuid = CommUtil.IsLogion();
            if (uGuid == null)
            {
                Response.Write("<script>alert('Please login！');window.location.href = '../User/login.aspx?op=submit';</script>");
                return;
            }
            else
            {
                Response.Write("<script>window.location.href = '../Product/issue.aspx';</script>");
                return;
            }
        }
        
    }
}