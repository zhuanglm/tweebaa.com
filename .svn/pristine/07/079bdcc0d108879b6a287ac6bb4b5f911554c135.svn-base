using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp.User
{
    public partial class updateEmail : System.Web.UI.Page
    {
        public string _script = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.Params["id"];
            var email = Request.Params["email"];
            var userMgr = new UserMgr();

            StringBuilder scriptString = new StringBuilder();
            scriptString.Append("<script type='text/javascript'>");
            scriptString.Append("var i=5;var intervalid; ");
            scriptString.Append("intervalid = setInterval('fun()', 1000); ");
            scriptString.Append("function fun() { if (i == 0) { window.location.href = '../user/login.aspx'; clearInterval(intervalid); } document.getElementById('mes').innerHTML = i; i--; } ");
            scriptString.Append("</script>");
            if (userMgr.UpdateEmail(id, email))
            {
                //Page.ClientScript.RegisterStartupScript(Page.GetType(),"",scriptString.ToString());
                _script = scriptString.ToString();
            }
            else
            {
                fail.Style.Add("display","block");
                success.Style.Add("display","none");
            }
        }
    }
}