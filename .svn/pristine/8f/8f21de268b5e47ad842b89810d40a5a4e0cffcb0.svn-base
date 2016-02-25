using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp2.Mgr.personalMgr
{
    public partial class changePwd : System.Web.UI.Page
    {
        public string current_username = string.Empty;
        public int currentID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(changePwd));
            if (!IsPostBack)
            {
                if (Session["CURRENT_USER"] == null)
                {
                    Response.Redirect("~/Mgr/index.aspx");
                }
                else
                {
                    Twee.Model.MgrUser adm = (Twee.Model.MgrUser)Session["CURRENT_USER"];
                    current_username = adm.sName;
                    currentID = adm.iID;
                }
            }
            
        }

         [AjaxPro.AjaxMethod]
        public string Save(string pwd)
        {
            Twee.Model.MgrUser adm = (Twee.Model.MgrUser)Session["CURRENT_USER"];
            current_username = adm.sName;
            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
            var bRe = true;
            if (pwd == string.Empty)
            {
                return "fail";
            }
            else
            {
                adm.sPassword = HD.Common.MD5Encrypt.GetStrMD5(pwd);
                bRe = mgr.Update(adm,true);
                if(bRe)
                    return "success";
                else
                    return "fail";
            }

        }
    }
}
