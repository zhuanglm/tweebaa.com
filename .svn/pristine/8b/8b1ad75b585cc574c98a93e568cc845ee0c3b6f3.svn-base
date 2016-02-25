using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp.Mgr.sysManager
{
    public partial class Manager : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(Manager));
            hidID.Value = string.Empty;
            if (string.IsNullOrEmpty(Request["id"]))
            {
                linkBtnSave.Style.Add("display", "none");
            }
            else
            {
                linkBtnRegister.Style.Add("display", "none");
                string sMgrUserID = Request["id"].Trim();
                hidID.Value = sMgrUserID;
                var model = new Twee.Mgr.AdminstratorMgr().GetModel(int.Parse(sMgrUserID));
                txtName.Value = model.sName;
                //selRole.SelectedValue = model.role.ToString().Trim();
                //selState.SelectedValue = model.wnstat.ToString().Trim();
            }
        }

        protected void linkBtnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtName.Value;
            string userPwd = txtPwd.Value;
            string role = selRole.SelectedValue;
            string state = selState.SelectedValue;
            if (string.IsNullOrEmpty(userName))
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('登录名不能为空')"); return;
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('登录密码不能为空')"); return;
            }
            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
            Twee.Model.MgrUser model = new Twee.Model.MgrUser();
            model.sName = userName;
            model.sPassword = HD.Common.MD5Encrypt.GetStrMD5(userPwd);
            //model.wnstat = int.Parse(state);
            //model.role = int.Parse(role);
            if (mgr.Add(model))
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('注册成功')");
            }
            else
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('注册失败')");
            }
        }

        [AjaxPro.AjaxMethod]
        public string Save(string id,string userName,string pwd,string role,string state)
        {
            Twee.Model.MgrUser adm = new Twee.Model.MgrUser();
            adm.iID = int.Parse(id);
            adm.sName = userName;
            adm.sPassword =HD.Common.MD5Encrypt.GetStrMD5(pwd);
            //adm.wnstat = int.Parse(state);
            //adm.role = int.Parse(role);
            if (new Twee.Mgr.AdminstratorMgr().Update(adm))
            {
                return "success";
            }
            else
            {
                return "fail";
            }
            

        }
    }
}