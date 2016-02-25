using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Home
{
    public partial class PayUnBind : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string account = string.Empty;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("<script type='text/javascript'>alert('非法链接')</script>");
                return;
            }
            if (!IsPostBack)
            {
                var list = new Twee.Mgr.payaccountbindMgr().GetModelList(" userid='" + userGuid.ToString() + "' and bindstate=1");
                if (list.Count > 0)
                    account = list[0].payaccount;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new Twee.Mgr.payaccountbindMgr().GetModelList(" userid='" + userGuid.ToString() + "' and bindstate=1");
                if (list.Count > 0)
                {
                    Twee.Model.payaccountbind bind = list[0];
                    bind.bindstate = 0;
                    bool res = new Twee.Mgr.payaccountbindMgr().Update(bind);
                    if (res)
                    {
                        alert("账号解绑成功！");
                    }
                }
                else
                {
                    alert("目前您尚未有可解绑的账号");
                }


            }
            catch (Exception ex)
            {
                alert("账号解绑失败，请联系管理员");
            }
        }

        private void alert(string msg)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script type='text/javascript'>alert('" + msg + "')</script>");
        }
    }
}