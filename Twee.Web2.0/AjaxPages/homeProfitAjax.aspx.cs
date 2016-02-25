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
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class homeProfitAjax : BasePage
    {
        private Guid? userGuid;
       // ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
                    string beginTime = dic["beginTime"].ToString();
                    string endTime = dic["endTime"].ToString();
                    int currentPage = dic["page"].ToString().ToInt();
                    string type = dic["type"].ToString();
                    string prdName = dic["prdName"].ToString();
                    //string strWhere = "";
                    /*
                    if (!string.IsNullOrEmpty(beginTime))
                    {
                        strWhere += " and RedeemDate>='" + beginTime + "'";
                    }
                    if (!string.IsNullOrEmpty(endTime))
                    {
                        strWhere += " and RedeemDate<='" + endTime + "'";
                    }
                    */
                    Twee.Mgr.ProfitMgr mgr = new Twee.Mgr.ProfitMgr();
                    int pageIndex = currentPage - 1; //AspNetPager1.CurrentPageIndex - 1;
                    int startIndex = 10 * pageIndex + 1;
                    int endIndex = startIndex + 10 - 1;
                    int tatalCount = 0;
                    DataTable dt = mgr.GetHomeUserProfit(userGuid.Value, type, prdName, beginTime, endTime, startIndex, endIndex, out tatalCount);
                    //AspNetPager1.RecordCount = tatalCount;

                    string Info = JsonConvert.SerializeObject(dt);
                    Response.Clear();
                    Response.Write(Info.ToString());
                }
                if (action.Equals("queryhomecount"))
                {
                    string beginTime = dic["beginTime"].ToString();
                    string endTime = dic["endTime"].ToString();
                    //int currentPage = dic["page"].ToString().ToInt();
                    string type = dic["type"].ToString();
                    string prdName = dic["prdName"].ToString();
                    //string strWhere = "";

                    Twee.Mgr.ProfitMgr mgr = new Twee.Mgr.ProfitMgr();
                    int pageIndex = 1 - 1; //AspNetPager1.CurrentPageIndex - 1;
                    int startIndex = 10 * pageIndex + 1;
                    int endIndex = startIndex + 10 - 1;
                    int tatalCount = 0;
                    DataTable dt = mgr.GetHomeUserProfit(userGuid.Value, type, prdName, beginTime, endTime, startIndex, endIndex, out tatalCount);
                    //AspNetPager1.RecordCount = tatalCount;

                    //string Info = JsonConvert.SerializeObject(dt);
                    Response.Clear();
                    Response.Write(tatalCount);

                }
            }
        }
    }
}