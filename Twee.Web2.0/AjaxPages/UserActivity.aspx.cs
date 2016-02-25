using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Web.Script.Serialization;
using Twee.Model;
using Twee.Mgr;
namespace TweebaaWebApp2.AjaxPages
{
    public partial class UserActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid? userGuid = CommUtil.IsLogion();
            if (userGuid != null)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string info = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Dictionary<string, object> dic = js.Deserialize<Dictionary<string, object>>(info);
                if (dic["action"] != null)
                {
                    VistLogMgr visitMgr = new VistLogMgr();
                    string action = dic["action"].ToString();
                    if (action == "addVisit")
                    {
                        string prdID = dic["id"].ToString();
                        string shareUrlId = "";
                        prdID = CommUtil.GetUrlPrdId(prdID, out shareUrlId);
                        VistLog visit = new VistLog();
                        visit.prdID = prdID.ToString();
                        visit.userId = userGuid.ToString();
                        visit.addTime = DateTime.Now;
                        visit.isBig30Second = true;                        
                        visitMgr.Add(visit);
                    }
                    if (action=="getCount")
                    {
                       int count = visitMgr.GetRecordCount("userId='" + userGuid.ToString() + "' and DATEDIFF(DD,addTime,GETDATE())=0");
                       int left = (10 - count) > 0 ? (10 - count) : 0;
                       Response.Write(left.ToString());
                       return;
                    }

                    if (action == "getUserProductTodayVisitCount")
                    {
                        string sPrdID = dic["id"].ToString();
                        string sShareUrlId = "";
                        sPrdID = CommUtil.GetUrlPrdId(sPrdID, out sShareUrlId);
 
                        int iCount = visitMgr.GetUserProductTodayVisitCount(userGuid.ToString(), sPrdID.ToString());
                        Response.Write(iCount.ToString());
                        return;
                    }
                }

            }
            else
            {
                Response.Write("-1");               
            }
        }
    }
}