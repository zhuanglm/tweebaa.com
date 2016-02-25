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
using Newtonsoft.Json;


namespace TweebaaWebApp2.AjaxPages
{
    public partial class HomeSharePointRedeem : BasePage
    {
        private static string action = "";
        Dictionary<string, object> dic = null;
        private Guid? userGuid;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                bool isLogion = CheckLogion(out userGuid);

                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string info = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(info);
                action = dic["action"].ToString();
                if (action.Equals("query_amount"))
                {
                    GetHistoryAmount();
                }
                if (action.Equals("query"))
                {
                    GetHistory();
                }
            }
            catch (Exception e1)
            {

                Twee.Comm.CommUtil.GenernalErrorHandler(e1);
            }
        }

        private void GetHistory()
        {
            string beginTime = dic["beginTime"].ToString();
            string endTime = dic["endTime"].ToString();
            string strWhere = "";
            if (!string.IsNullOrEmpty(beginTime))
            {
                strWhere += " and RedeemDate>='" + beginTime + "'";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += " and RedeemDate<='" + endTime + "'";
            }
            UserGradeCalMgr mgr = new UserGradeCalMgr();
            DataTable dt = mgr.GetHomeRedeemHistoryDetial(userGuid.Value, strWhere);
            string Info = JsonConvert.SerializeObject(dt);
            Response.Clear();
            Response.Write(Info.ToString());
        }
        private void GetHistoryAmount()
        {
            string beginTime = dic["beginTime"].ToString();
            string endTime = dic["endTime"].ToString();
            string strWhere = "";
            if (!string.IsNullOrEmpty(beginTime))
            {
                strWhere += " and RedeemDate>='" + beginTime + "'";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += " and RedeemDate<='" + endTime + "'";
            }

            int recordCount = 0;
            int pageCount = 0;
            UserGradeCalMgr mgr = new UserGradeCalMgr();
            recordCount = mgr.GetHomeRedeemRecordCount(userGuid.Value, strWhere);
            pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;

            Response.Clear();
            Response.Write(recordCount + "," + pageCount);

        }
    }
}