using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Reflection;
using System.Web.Script.Serialization;
using Twee.Comm;
using Twee.Mgr;
using System.Data;
using Twee.Model;
using Newtonsoft.Json;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class SendWholesaleInquiryEmail : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string reviewInfo = sr.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(reviewInfo);

            action = dic["action"].ToString();
            if (action == "WholesaleInquiry")
            {
                SendEmail();
            }
        }

        private void SendEmail()
        {
            string emailSubject = HttpUtility.UrlDecode(dic["subject"].ToNullString());
            string emailTo = HttpUtility.UrlDecode(dic["to"].ToNullString());
            string emailBody = HttpUtility.UrlDecode(dic["body"].ToNullString());

            bool b = Mailhelper.SendMail(emailSubject, emailBody, emailTo);
            if (b)
            {
                Response.Write("1");
                return;
            }
            else
            {
                Response.Write("0");
                return;
            }
 
        }
    }
}