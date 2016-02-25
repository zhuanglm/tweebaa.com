using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Twee.Comm;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Net;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class shareAjax : TweebaaWebApp2.MasterPages.BasePage
    {

        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        private  Guid? userGuid;
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
        
            // get action
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string cartInfo = sr.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
            action = dic["action"].ToString();

            // check if user is login
            bool isLogin = CheckLogion(out userGuid);

            // do action of query user login
            if (action == "queryuserlogin")
            {
                if (isLogin)
                {
                    Response.Write("1");
                }
                else
                {
                    Response.Write("0");
                    return;
                }
            }
            if (action == "queryusersharegrade")
            {
                Twee.Mgr.UserGradeCalMgr mgr = new Twee.Mgr.UserGradeCalMgr();
                DataTable dt = mgr.GetUserShareGrade(userGuid);
                string sShareGrade = "1,50";  // share level and commission 
                if (dt != null && dt.Rows.Count > 0)
                {
                    sShareGrade = dt.Rows[0]["sharegrade"].ToString() + "," + dt.Rows[0]["sratio"].ToString(); 
                }
                Response.Write(sShareGrade);
                return;

            }
            if (action == "share")
            {
                if (isLogin) // do share with login
                {
                    Response.Clear();
                    string proid = dic["proid"].ToString();
                    string url = dic["url"].ToString();
                    string type = dic["type"].ToString();
                    Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                    string shareId = mgr.IsExitShareUrl(proid, type, userGuid.ToString());
                    if (!string.IsNullOrEmpty(shareId))
                    {
                        Response.Write(shareId);
                        return;
                    }
                    Twee.Model.Share model = new Twee.Model.Share();
                    model.guid = Guid.NewGuid();
                    model.prtguid = proid.ToGuid().Value;
                    model.userguid = userGuid.Value;
                    model.sharetype = type;
                    model.shareurl = url + "_" + model.guid;
                    model.addtime = System.DateTime.Now;
                    mgr.Add(model);                   
                    Response.Write(model.guid);
                    return;
                }
                else // not login
                {
                    // return a empty share guid
                    Response.Clear();
                    Response.Write("");
                    return;
                }
            }

    
            // following needs user login             
            if (isLogin == false)
            {
                Response.Write("-1");
                return;
            }
            else
            {
                //System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                //string cartInfo = sr.ReadToEnd();
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
                //action = dic["action"].ToString();
                if (action == "query")
                {
                    Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                    string prdId = string.Empty;
                    string type = dic["type"].ToString();
                    string beginTime = dic["beginTime"].ToString();
                    string endTime = dic["endTime"].ToString();
                    string order = dic["order"].ToString();
                    int startIndex = 1;
                    int endIndex = ConfigParamter.recordSize;
                    if (dic["page"].ToNullString() != "")
                    {
                        int page = dic["page"].ToString().ToInt();
                        startIndex = (page - 1) * ConfigParamter.recordSize + 1;
                        endIndex = page * ConfigParamter.recordSize;
                    }

                    DataSet ds = mgr.GetShareSummary(userGuid.ToString(), prdId, type, beginTime, endTime, startIndex, endIndex);
                    string data = "";
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        data = JsonConvert.SerializeObject(ds.Tables[0]);
                    }
                    Response.Clear();
                    Response.Write(data);
                }
                else if (action == "query_collage")  //Add by Long
                {
                    //Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                    Twee.Mgr.CollageShareMgr mgr = new Twee.Mgr.CollageShareMgr();
                    string type = dic["type"].ToString();
                    string beginTime = dic["beginTime"].ToString();
                    string endTime = dic["endTime"].ToString();
                    StringBuilder strWhere = new StringBuilder();
                    if (!string.IsNullOrEmpty(type))
                    {
                        strWhere.Append(" and sharetype='" + type.ToLower() + "'");
                    }
                    if (!string.IsNullOrEmpty(beginTime))
                    {
                        //strWhere.Append("and addtime>'" + beginTime + "'");
                        string sBeginDate = CommUtil.ToDBDateFormat(beginTime);
                        strWhere.Append(" and addtime>='" + sBeginDate + " 0:00'");
                    }
                    if (!string.IsNullOrEmpty(endTime))
                    {
                        //strWhere.Append("and addtime<'" + endTime + "'");
                        string sEndDate = CommUtil.ToDBDateFormat(endTime);
                        strWhere.Append(" and addtime<='" + sEndDate + " 23:59'");
                    }
                    strWhere.Append(" and sourcetype=2"); //Add by Long for seprate product or collage design

                    string order = dic["order"].ToString();
                    int startIndex = 1;
                    int endIndex = ConfigParamter.recordSize;
                    if (dic["page"].ToNullString() != "")
                    {
                        int page = dic["page"].ToString().ToInt();
                        startIndex = (page - 1) * ConfigParamter.recordSize + 1;
                        endIndex = page * ConfigParamter.recordSize;
                    }

                    DataSet ds = mgr.GetListByPage(strWhere.ToString(), userGuid.ToString(), order, startIndex, endIndex);
                    string data = "";
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        data = JsonConvert.SerializeObject(ds.Tables[0]);
                    }
                    Response.Clear();
                    Response.Write(data);
                }
                else if (action == "queryhomecount_collage")
                {
                    try
                    {
                        string type = dic["type"].ToNullString();
                        string begTime = dic["begTime"].ToNullString();
                        string endTime = dic["endTime"].ToNullString();
                        Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                        int recordCount = mgr.GetShareCount("sourcetype=2", userGuid.Value.ToString(), type, begTime, endTime);
                        //int pageCount = recordCount % 10 == 0 ? recordCount / ConfigParamter.pageSize : recordCount / 10 + 1;
                        //modify by long , it should be ConfigParamter.pageSize not 10
                        int pageCount = recordCount % ConfigParamter.recordSize == 0 ? recordCount / ConfigParamter.recordSize : recordCount / ConfigParamter.recordSize + 1;
                        Response.Clear();
                        Response.Write(recordCount + "," + pageCount);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else if (action == "queryhomecount")
                {
                    try
                    {
                        string prdId = string.Empty;
                        string type = dic["type"].ToNullString();
                        string begTime = dic["begTime"].ToNullString();
                        string endTime = dic["endTime"].ToNullString();
                        Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                        DataSet ds = mgr.GetShareSummaryTotal(userGuid.Value.ToString(), prdId, type, begTime, endTime);
   //                     int pageCount = recordCount % 10 == 0 ? recordCount / ConfigParamter.pageSize : recordCount / 10 + 1;
                        //modify by long , it should be ConfigParamter.pageSize not 10
                        int recordCount = 0;
                        int totalVisitCount = 0;
                        int totalSoldQuantity = 0;
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                DataRow dr = dt.Rows[0];
                                recordCount = dr["TotalCount"].ToString().ToInt();
                                totalVisitCount = dr["TotalVisitCount"].ToString().ToInt();
                                totalSoldQuantity = (int)(dr["TotalSoldQuantity"].ToString().ToDecimal());
                            }
                        }
                        int pageCount = recordCount % ConfigParamter.recordSize == 0 ? recordCount / ConfigParamter.recordSize : recordCount / ConfigParamter.recordSize + 1;
                        Response.Clear();
                        Response.Write(recordCount + "," + pageCount + "," + totalVisitCount + "," + totalSoldQuantity) ;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                else if (action == "queryhomegrandtotal")
                {
                    try
                    {
                        Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                        DataSet ds = mgr.GetShareGrandTotal(userGuid.Value.ToString());
                        int totalVisitCount = 0;
                        int totalSoldQuantity = 0;
                        decimal totalShareCommission = 0.0M;
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                DataRow dr = dt.Rows[0];
                                totalVisitCount = dr["TotalVisitCount"].ToString().ToInt();
                                totalSoldQuantity = (int)(dr["TotalSoldQuantity"].ToString().ToDecimal());
                            }
                            dt = ds.Tables[1];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                totalShareCommission = dt.Rows[0]["TotalShareCommission"].ToString().ToDecimal();
                            }
                         }
                        Response.Clear();
                        Response.Write(totalVisitCount.ToString() + "," + totalSoldQuantity.ToString() + "," + totalShareCommission.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else if (action == "queryhomeCollagetotal")
                {
                    try
                    {
                        Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                        DataSet ds = mgr.GetShareCollageTotal(userGuid.Value.ToString());
                        int totalVisitCount = 0;
                        int totalSoldQuantity = 0;
                        decimal totalShareCommission = 0.0M;
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                DataRow dr = dt.Rows[0];
                                totalVisitCount = dr["TotalVisitCount"].ToString().ToInt();
                                totalSoldQuantity = (int)(dr["TotalSoldQuantity"].ToString().ToDecimal());
                                totalShareCommission = dt.Rows[0]["TotalShareCommission"].ToString().ToDecimal();
                            }
                            
                        }
                        Response.Clear();
                        Response.Write(totalVisitCount.ToString() + "," + totalSoldQuantity.ToString() + "," + totalShareCommission.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

            }
        }
    }
}