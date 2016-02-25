using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
using TweebaaWebApp2.MasterPages;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class homePersonalData : BasePage
    {
        private Guid? userGuid;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
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
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string info = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(info);
                action = dic["action"].ToString();
                if (action.Equals("query"))
                {
                    GetCurrentUser();
                }
                else if (action.Equals("save"))
                {
                    Save();
                }
            }
        }

        private void GetCurrentUser()
        {
            // 获取当前用户邮箱
            string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
            var userMgr = new UserMgr();
            var user = userMgr.GetModel(userGuid.Value, userEmail);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Response.Write(js.Serialize(user));
        }

        private void Save()
        {
            var gender = int.Parse(dic["gender"].ToString());
            int? month =null; //dic["month"];
            if (dic["month"].ToString() != "-1")
                month = Convert.ToInt32(dic["month"].ToString());
            int? date = null;//dic["date"];
            if (dic["date"].ToString() != "-1")
                date = Convert.ToInt32(dic["date"].ToString());
            int? year = null;//dic["year"];
            if (dic["year"].ToString() != "-1")
                year = Convert.ToInt32(dic["year"].ToString());
            int? jobid=null;
            if(dic["jobid"].ToString()!="-1")
             jobid =Convert.ToInt32 (dic["jobid"].ToString());


            // 获取当前用户邮箱
            string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
            var userMgr = new UserMgr();
            var user = userMgr.GetModel(userGuid.Value, userEmail);
            user.gender = gender;
            if (year != null && month != null && date != null && month != null)
            {
                user.birthday = DateTime.Parse(string.Format("{0}-{1}-{2}", year, month, date));
            }
            else
            {
                user.birthday = null;
            }
            user.jobid = jobid;
            if (userMgr.Update(user))
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
        }
    }
}