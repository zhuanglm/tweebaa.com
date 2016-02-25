using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Mgr;
using Twee.Model;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using Twee.Comm;
using System.Data;
using Newtonsoft.Json;


namespace TweebaaWebApp2.Games.SlotMachine
{
    /// <summary>
    /// Summary description for SlotMachineDBHandle
    /// </summary>
    public class SlotMachineDBHandle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            Dictionary<string, object> dic = null;
            //context.Response.Write("Hello World");
            //get all parameter
            //String s = context.Request["imgBase64"];
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream);
                string reviewInfo = sr.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(reviewInfo);

                Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();

                if (dic["action"].Equals("load_lucky_winner"))
                {
                    string sSql = "SELECT   top 10     a.username, b.AddDate, c.SlotMachinePrizeText";
                    sSql = sSql + " FROM            wn_user AS a INNER JOIN ";
                    sSql = sSql + " wn_SlotMachineLucky AS b ON a.guid = b.UserGuid LEFT OUTER JOIN ";
                    sSql = sSql + "  wn_SlotMachinePrize AS c ON b.SlotMachinePrizeID = c.SlotMachinePrize_ID ";
                    sSql = sSql + "WHERE        ({ fn LENGTH(c.SlotMachinePrizeText) } > 0) ORDER BY b.AddDate DESC,b.SlotMachinePrizeID desc";
                    DataSet ds = DbHelperSQL.Query(sSql);
                    if (ds == null || ds.Tables.Count == 0)
                    {
                        context.Response.Write("1");
                    }
                    else
                    {

                        DataTable dt2 = ds.Tables[0];
                        string data = JsonConvert.SerializeObject(ds.Tables[0]);
                        context.Response.Write(data);
                    }
                }
            }
            catch (Exception e)
            {
                context.Response.Write("1");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}