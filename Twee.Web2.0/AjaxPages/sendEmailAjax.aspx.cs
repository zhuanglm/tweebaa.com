using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
using Twee.Model;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class sendEmailAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            SendEmail();
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        private void SendEmail()
        {
            try
            {
                string email = Request["email"].ToNullString();
                UserMgr userMgr = new UserMgr();
                List<Twee.Model.User> list = userMgr.GetModelList(" email='" + email + "'");
                if (list != null && list.Count > 0)
                {
                    Twee.Model.User user = list[0];
                    string sAction = Request["action"].ToNullString();
                    if (string.IsNullOrEmpty(sAction))
                    {
                        bool b = Mailhelper.SendFindPassEmail(user.username, email, user.guid.ToString());
                        if (b)
                        {
                            Response.Write("success");
                            return;
                        }
                        else
                        {
                            Response.Write("false");
                            return;
                        }
                    }
                    else
                    {
                        if (sAction == "ReActivation")
                        {
                            //SendRegEmail(string stremail, string strguid,string username)
                            Mailhelper.SendRegEmail(email, user.guid.ToString(), user.username);
                            Response.Write("success");
                            return;
                        }
                    }
                   
                }
                Response.Write("-1");
                return;
            }
            catch (Exception)
            {
                Response.Write("false");
                throw;
            }          
             
        
        }
    }
}