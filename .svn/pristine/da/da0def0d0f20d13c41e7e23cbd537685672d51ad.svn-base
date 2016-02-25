using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Home
{
    public partial class PayBind : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("<script type='text/javascript'>alert('非法链接')</script>");
                return;
            }
          
           
        }

       

        protected void btnBind_Click(object sender, EventArgs e)
        {
            var list = new Twee.Mgr.payaccountbindMgr().GetModelList(" userid='" + userGuid.ToString() + "' and bindstate=1");
            if (list.Count > 0)
            {
                alert("您已经绑定过账号了，如要重新绑定请先解绑");
                return;
            }
            string userName = txtname.Value;
            string usercode = txtcode.Value;
            string phone = txtphone.Value;
            string payaccount = txtpayaccount.Value;
            string isagree = hidagree.Value;
            string verfycode = txtphonecode.Value;

            if (string.IsNullOrEmpty(userName))
            {
                alert("请填写您的姓名"); return;
            }
            if (string.IsNullOrEmpty(usercode))
            {
                alert("请填写您的身份证"); return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                alert("请填写您的手机号"); return;
            }
            if (string.IsNullOrEmpty(payaccount))
            {
                alert("请填写您的支付宝账号"); return;
            }
            if (string.IsNullOrEmpty(isagree) || isagree!="1")
            {
                alert("您必须同意协议才可绑定"); return;
            }
            if (string.IsNullOrEmpty(verfycode))
            {
                alert("请填写您的手机验证码"); return;
            }
            try
            {
                Twee.Mgr.paybindverfycodeMgr verfyMgr = new Twee.Mgr.paybindverfycodeMgr();
                var verfymodel = verfyMgr.GetModel(Guid.Parse(userGuid.ToString()), phone);
                if (null == verfymodel || verfymodel.verfycode.Trim() != verfycode)
                {
                    alert("验证码不正确"); return;
                }
                Twee.Mgr.payaccountbindMgr bindMgr = new Twee.Mgr.payaccountbindMgr();
                Twee.Model.payaccountbind bind = new Twee.Model.payaccountbind();
                bind.userid = Guid.Parse(userGuid.ToString());
                bind.username = userName;
                bind.userphone = phone;
                bind.usercode = usercode;
                bind.payaccount = payaccount;
                bind.isagree = int.Parse(isagree);
                bind.createtime = DateTime.Now;
                bind.bindstate = (int)Twee.Comm.ConfigParamter.PayAccountBind.bind;
                int id = bindMgr.Add(bind);
                Response.Redirect("~/Home/BindSuccess.aspx");
            }
            catch (Exception ex) 
            {
                alert("非常抱歉，绑定失败了！");
            }
        }

        private void alert(string msg) {
            this.Page.ClientScript.RegisterClientScriptBlock(Page.GetType(),"","<script type='text/javascript'>alert('"+msg+"')</script>");
        }
    }
}