using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using TweebaaWebApp2.MasterPages;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class payBindAjax : BasePage
    {
        private static string action = "";
        private Guid? userGuid;
        public string _action = string.Empty;
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("-1");
                return;
            }
            else
            {
                string action = Request["action"];
                string phone = Request["phone"];
                if (action == "bind")
                {
                    
                    string code = string.Empty;
                    string userid = userGuid.ToString();
                    Random rand = new Random();
                    for (int i = 0; i < 6; i++)
                    {
                        int r = rand.Next(10);
                        code += r;
                    }
                    Twee.Model.paybindverfycode model = new Twee.Model.paybindverfycode();
                    model.userid = Guid.Parse(userid);
                    model.phone = phone;
                    model.verfycode = code;
                    model.createtime = System.DateTime.Now;
                    Twee.Mgr.paybindverfycodeMgr mgr = new Twee.Mgr.paybindverfycodeMgr();
                    int id= mgr.Add(model);
                    if (id != 0) {
                        SendSms(phone,code);
                    }
                }
            }

        }

        private void SendSms(string phone,string code) {
            Twee.Comm.SMSSend sms = new Twee.Comm.SMSSend();
            string templatedId = System.Configuration.ConfigurationManager.AppSettings["templatedId"].ToString();
            sms.SendSMS(phone, templatedId, code);//短信
        }



    }
}