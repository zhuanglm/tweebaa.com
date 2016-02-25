using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp2.Mgr
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(index));
            if (!IsPostBack)
            {
                string userName = HD.Common.CookieHelper.GetCookieValue("TWEE_CURRENT_USER_NAME");
                if (!string.IsNullOrEmpty(userName))
                    txtName.Value = userName;
                string sRelogin = Request["relogin"];
                if (sRelogin == "1")
                {
                    string sJScript = "<script>window.parent.location.href = 'index.aspx';</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", sJScript, false);
                }
 
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtName.Value;
            string userPwd = txtPwd.Value;
            string _userPwd = HD.Common.MD5Encrypt.GetStrMD5(userPwd);
            if (string.IsNullOrEmpty(userName))
            {
                //HD.Common.JavaScriptHelper.Alert(this.Page,"用户名不能为空"); return;
                HD.Common.JavaScriptHelper.Alert(this.Page, "Username cannot be blank"); return;
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                //HD.Common.JavaScriptHelper.Alert(this.Page,"用户密码不能为空"); return;
                HD.Common.JavaScriptHelper.Alert(this.Page, "Password cannot be blank"); return;
            }
            Twee.Model.MgrUser adm = new Twee.Model.MgrUser();
            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
            adm = mgr.GetSingle(userName, _userPwd);
            if (adm != null)
            {
                Session["CURRENT_USER"] = adm;
                if (chk.Checked)
                {
                    HD.Common.CookieHelper.SetCookie("TWEE_CURRENT_USER_NAME", userName);
                }
                Response.Redirect("~/Mgr/main.aspx");
            }
            else
            {
                //HD.Common.JavaScriptHelper.Alert(this.Page,"用户名或密码错误"); 
                HD.Common.JavaScriptHelper.Alert(this.Page, "Username or Password incorrect"); 
            }
        }

        [AjaxPro.AjaxMethod]
        public string gettest(int i)
        {
            return i++.ToString();
        }
    }
}