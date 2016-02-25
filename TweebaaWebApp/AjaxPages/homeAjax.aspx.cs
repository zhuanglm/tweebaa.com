using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Reflection;
using Twee.Mgr;
using System.Data;
using Newtonsoft.Json;
using Twee.Model;
using Twee.Comm;
using System.Web.Script.Serialization;

namespace TweebaaWebApp.AjaxPages
{
    public partial class homeAjax : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);       
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string prdInfo = sr.ReadToEnd();           
            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(prdInfo); 

            Guid? userGuid = CommUtil.IsLogion();
             if (userGuid != null)
             {
                 string action = dic["action"].ToString();
                 if (!string.IsNullOrEmpty(action))
                 {
                     if (action == "1")
                     {
                         MySubpllay(userGuid.ToString()); //我的发布
                     }                   
                     if (action == "delete" && dic["id"]!=null && dic["id"].ToString() != "")
                     {
                         DelSubpllay(dic["id"].ToString());
                     }
                     if (action=="review")
                     {
                         MyReview(userGuid.ToString());//我的评审
                     }
                     else if (action == "queryhomecount")
                     {
                         MySubpllayCount(userGuid.ToString());
                     }
                     else if (action == "queryReviewcount")
                     {                         
                         MyReviewCount(userGuid.ToString());
                     }
                     else if (action=="queryPoint")
                     {
                         MyPoint(userGuid.ToString(),1);
                     }
                     else if (action == "querypointcount")
                     {
                         MyPointCount(userGuid.ToString(),1);
                     }                         
                     else if (action == "shopPoint")
                     {
                         MyPoint(userGuid.ToString(),2);
                     }
                     else if (action == "queryGiftRewardCount")
                     {
                         MyGiftRewardCount(userGuid.ToString());
                     }
                     else if (action == "queryGiftRewardList")
                     {
                         MyGiftRewardList(userGuid.ToString());
                     }
                     else if (action == "getGiftStatusList")
                     {
                         GetGiftStatusList();
                     }
                 }
                 else
                 {
                     Response.Clear();
                     Response.Write("error");
                     return;
                 }
             }
             else
             {
                 Response.Clear();
                 Response.Write("-1");//未登录
                 return;
             }
                
        }

        // get gift status list
        private void GetGiftStatusList()
        {
            try
            {
                Response.Clear();

                UserGiftRewardMgr mgr = new UserGiftRewardMgr();
                DataSet ds = mgr.GetGiftStatusList();
                DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("");
                    return;
                }
                string giftStatusList = JsonConvert.SerializeObject(dt);
                Response.Write(giftStatusList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //我的 reward gift 总数
        private void MyGiftRewardCount(string userID)
        {
            try
            {
                Response.Clear();
                string giftName = dic["giftName"].ToNullString();
                string giftStatus = dic["giftStatus"].ToNullString();
                string begTime = dic["begTime"].ToNullString();
                string endTime = dic["endTime"].ToNullString();
                UserGiftRewardMgr mgr = new UserGiftRewardMgr();
                int recordCount = mgr.GetMyGiftRewardCount(userID, giftName, giftStatus, begTime, endTime);
                int pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;

                Response.Clear();
                Response.Write(recordCount + "," + pageCount);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // my reward gift list
        private void MyGiftRewardList(string userID)
        {
            try
            {
                Response.Clear();
                string giftName = dic["giftName"].ToNullString();
                string giftStatus = dic["giftStatus"].ToNullString();
                string begTime = dic["begTime"].ToNullString();
                string endTime = dic["endTime"].ToNullString();
                int page = dic["page"].ToNullString().ToInt();

                string orderby = " a.UserGiftReward_GrantDate desc";


                //string cate = dic["cate"].ToNullString();
                //string prdName = dic["prdName"].ToNullString();              
                //string orderby = dic["orderby"].ToNullString();               
                //orderby = orderby == "" ? "addtime desc" : orderby;            

                UserGiftRewardMgr mgr = new UserGiftRewardMgr();
                int startIndex = ConfigParamter.pageSize * (page - 1) + 1;
                int endIndex = ConfigParamter.pageSize * page;
                DataSet ds = mgr.GetMyGiftRewardList(userID, giftName, giftStatus, orderby, startIndex, endIndex, begTime, endTime);
                DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("");
                    return;
                }
                string giftRewardInfo = JsonConvert.SerializeObject(dt);
                Response.Write(giftRewardInfo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //我的发布列表
        private void MySubpllay(string userID)
        {
            try
            {

                Response.Clear();
                string state = dic["state"].ToNullString();
                int page = dic["page"].ToNullString().ToInt();
                string orderby = "addtime desc";
                string begTime = dic["begTime"].ToNullString();
                string endTime = dic["endTime"].ToNullString();

                //string cate = dic["cate"].ToNullString();
                //string prdName = dic["prdName"].ToNullString();              
                //string orderby = dic["orderby"].ToNullString();               
                //orderby = orderby == "" ? "addtime desc" : orderby;            
              
                PrdMgr mgr = new PrdMgr();
                int startIndex = ConfigParamter.pageSize * (page - 1) + 1;
                int endIndex = ConfigParamter.pageSize * page;
                DataTable dt = mgr.GetMySubpllay(userID, "", "", state, orderby, startIndex, endIndex,begTime,endTime);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("");
                    return;
                }
                //List<Prd> lisMyPrd = mgr.DataTableToList2(dt);
                string prdInfo = JsonConvert.SerializeObject(dt);
                Response.Write(prdInfo);
            }
            catch (Exception)
            {
                
                throw;
            }
        
        
        }

        //我的发布总总数
        private void MySubpllayCount(string userID)
        {
            try
            {
                Response.Clear();
                string state = dic["state"].ToNullString();               
                string begTime = dic["begTime"].ToNullString();
                string endTime = dic["endTime"].ToNullString(); 
                PrdMgr mgr = new PrdMgr();
                int recordCount = mgr.GetMySubpllayCount(userID, "", "", state, begTime, endTime);
                int pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;

                Response.Clear();
                Response.Write(recordCount + "," + pageCount);  
            }
            catch (Exception)
            {

                throw;
            }

        }

        //删除某个发布
        private void DelSubpllay(string PrdID)
        {
            try
            {
                Response.Clear();
                PrdMgr mgr = new PrdMgr();
                bool b = mgr.Delete(PrdID.ToGuid().Value);  
                Response.Write(b.ToString());
            }
            catch (Exception)
            {
                Response.Write("false");               
            }


        }

        /// <summary>
        /// 我的评审列表
        /// </summary>
        /// <param name="userID"></param>
        private void MyReview(string userID)
        {
            try
            {
                Response.Clear();
                string state = dic["state"].ToNullString();
                int page = dic["page"].ToNullString().ToInt();
                string begTime = dic["begTime"].ToNullString();
                string endTime = dic["endTime"].ToNullString();
                ReviewMgr mgr = new ReviewMgr();
                int startIndex = ConfigParamter.pageSize * (page - 1) + 1;
                int endIndex = ConfigParamter.pageSize * page;
                DataTable lisMyReview = mgr.GetMyReview(userID, "", "", state, "", startIndex, endIndex, begTime, endTime);
                string myReview = JsonConvert.SerializeObject(lisMyReview);
                Response.Write(myReview);
            }
            catch (Exception)
            {
                Response.Write("");
            }
        

        }

        /// <summary>
        /// 我的评审总数
        /// </summary>
        /// <param name="userID"></param>
        private void MyReviewCount(string userID)
        {
            try
            {
                Response.Clear();
                string state = dic["state"].ToNullString();
                string begTime = dic["begTime"].ToNullString();
                string endTime = dic["endTime"].ToNullString();
                ReviewMgr mgr = new ReviewMgr();
                int recordCount = mgr.GetMyReviewCount(userID, "", "", state, begTime, endTime);
                int pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;

                Response.Clear();
                Response.Write(recordCount + "," + pageCount);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="type">积分类型：1：普通积分；2：购物积分</param>
        private void MyPoint(string userID,int pointType)
        {
            int page = dic["page"].ToString().ToInt();
            string type = dic["type"].ToString();
            int pageSize = ConfigParamter.pageSize;
            int start = (page - 1) * pageSize + 1;
            int end = page * ConfigParamter.pageSize;
            PointMgr mgr = new PointMgr();
            int totalCount = 0;
            string strWhere = " userid='" + userID + "' ";
            if (pointType == 2)
            {
                strWhere += " and type =4";
            }
            else
            {
                if (!string.IsNullOrEmpty(type))
                {
                    strWhere += " and type in (" + type + ")";
                }
            }           
            DataSet ds = mgr.GetListByPage(strWhere, "addTime desc", start, end, out totalCount);
            if (ds !=null && ds.Tables.Count>0 && totalCount > 0)
            {
                int pageCount = 0;
                pageCount = totalCount % pageSize == 0 ? totalCount / pageSize : totalCount / pageSize + 1;
                string data = JsonConvert.SerializeObject(ds.Tables[0]);
                data = data.Replace("]", ",{" + "\"totalCount" + "\":" + totalCount + "},{" + "\"pageCount" + "\":" + pageCount + "}]");
                Response.Clear();
                Response.Write(data);
                return;
            }
            Response.Write("");
        }

        private void MyPointCount(string userID, int pointType)
        { 
        
        }
    }
}