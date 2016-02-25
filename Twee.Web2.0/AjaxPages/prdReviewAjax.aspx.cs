using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using log4net;
using System.Reflection;
using Twee.Model;
using Twee.Comm;
using Twee.Mgr;
using System.Data;
using Newtonsoft.Json;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class prdReviewAjax : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;
        string prdId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string reviewInfo = sr.ReadToEnd();
         
            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(reviewInfo);
            action = dic["action"].ToString();

            if (dic.Keys.Contains("id")&&dic["id"]!=null)
            {
                string urlShareId = "";//链接在数据库中的id
                prdId = CommUtil.GetUrlPrdId(dic["id"].ToString(), out urlShareId);
               
            }                

            if (action=="add")
            {
                AddReview(prdId);
            }
            else if (action=="query")
            {
                int startIndex =Convert.ToInt32( dic["startIndex"].ToString());
                int endIndex = Convert.ToInt32(dic["endIndex"].ToString());
                QueryReview(prdId,startIndex,endIndex);
            }
            else if (action == "reviewPrd")
            {
                GetReviewPrd();
            }
            else if (action == "reviewPrdCount")
            {
                GetReviewPrdCount();
            }
            
            else if (action == "delete")
	        {
                Delete();
	        }
            else if (action == "getFocusCate")
            {
                GetFocusCate();
            }
            else if (action == "queryLogin")
            {
                QueryLogin();
            }
            else if (action == "load_comment_total")
            {
                string prdGuid = dic["PrdGuid"].ToNullString();
                ReviewMgr mgr = new ReviewMgr();
                string ss = mgr.GetProductCommentsTotal(prdGuid);
                Response.Write(ss);
            }
            else if (action == "load_Comments_By_Page")
            {
                string prdGuid = dic["PrdGuid"].ToNullString();
                string page = dic["page"].ToNullString();
                int iPage = int.Parse(page);
                if (iPage <= 0) iPage = 1;

                string pageDiv = dic["pageDiv"].ToNullString();
                int iPageDiv = int.Parse(pageDiv);
                if (iPageDiv <= 0) iPageDiv = 20;
                int startIndex = iPageDiv * (iPage - 1) + 1;
                int endIndex = iPageDiv * iPage;
                ReviewMgr mgr = new ReviewMgr();
                DataTable dt = mgr.GetProductCommentsByPage(prdGuid, startIndex, endIndex);
                string prdInfo = JsonConvert.SerializeObject(dt);
                Response.Write(prdInfo);
            }
            

        }
        /// <summary>
        /// 添加评审
        /// </summary>
        private void AddReview(string proId)
        {
            try
            {
                Response.Clear();
                string prdID = prdId;//产品id
                string content =Twee.Comm.CommHelper.GetStrDecode(dic["content"].ToString());//评审内容
                string cmdtype =Twee.Comm.CommHelper.GetStrDecode( dic["cmdtype"].ToString());//评审类型
                string publishUser = dic["publishUser"].ToString();//该产品的发布者id
                string verify = dic["verify"].ToString(); // verify watermark

                Review review = new Review();
                review.cmdtxt = content;
                review.prtguid = prdID.ToGuid().Value;
                review.cmdtype = cmdtype;
                if (cmdtype.Contains("7"))
                {
                    review.cmdtype2 = 1;//1表示支持记录，0表示不支持记录
                }
                else
                {
                    review.cmdtype2 = 0;
                }
                review.edttime = DateTime.Now;
                Guid? uGuid = CommUtil.IsLogion();
                if (uGuid == null)
                {
                    Response.Write("-2");//未登录
                    return;
                }

                // verify in-case-sensitive
                if ( verify.ToUpper() != Request.Cookies["WaterMarkSubmitReview"]["text"])
                {
                    Response.Write("-3");// very not successful
                    return;
                }
               
                
                review.userguid = uGuid.Value;
                review.wnstat = 1;
                ReviewMgr mgr = new ReviewMgr();
                //bool isExit=mgr.HaveReviewed(review.prtguid,uGuid.Value);
                //if (isExit)
                //{
                //    Response.Write("-1");//存在
                //    return;
                //}
                int suportCount=0;
                if (mgr.Add(review,out suportCount))
                {
                    Response.Write("1");//成功
                    //UserGradeCalMgr grade = new UserGradeCalMgr();
                    //grade.MgePublishIntegralCal(publishUser.ToGuid().Value, suportCount, review.prtguid);//计算发布者积分
                }
                else
                {
                    Response.Write("0");//失败
                }
            }
            catch (Exception ex)
            {
                Response.Write("-1");
            }        
        
        }

        /// <summary>
        /// query user login status
        /// </summary>
        private void QueryLogin()
        {
            try
            {
                Response.Clear();
                Guid? uGuid = CommUtil.IsLogion();
                if (uGuid == null)
                {
                    Response.Write("0");//未登录
                    return;
                }
                else
                {
                    Response.Write("1");//已登录
                }
            }
            catch (Exception ex)
            {
                Response.Write("-1");
            }

        }

        /// <summary>
        /// 查询产品评审记录
        /// </summary>
        private void QueryReview(string proId,int startIndex,int endIndex)
        {
            if (!string.IsNullOrEmpty(proId) && proId != "undefined")
            {               
                ReviewMgr mgr = new ReviewMgr();
                UserMgr userMgr = new UserMgr();

                int count = mgr.GetRecordCount(" prtguid='" + proId + "'");
                DataSet ds = mgr.GetListByPage(" prtguid='" + proId + "'", " edttime desc ", startIndex, endIndex);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    List<Review> listData = mgr.DataTableToList(dt);
                    for (int i = 0; i < listData.Count; i++)
                    {
                        listData[i].username = userMgr.GetUserNameByID(listData[i].userguid.ToString());
                    }
                    string data = JsonConvert.SerializeObject(listData);
                    Response.Clear();
                    Response.Write(data);
                }
            }
            else
            {
                Response.Clear();
                Response.Write("");
            }
        }

        /// <summary>
        /// 查询by focud categories
        /// </summary>
        public void GetFocusCate()
        {
            try
            {
                Response.Clear();

                XMLCache xmlCache = new XMLCache();

                string sCacheFile = "ByFocusCategory_" + xmlCache.GetDateString();

                if (xmlCache.IsJsonFileExists(sCacheFile))
                {
                    xmlCache.ReadCacheJson(this.Context, sCacheFile);
                }
                else
                {


                    PrdMgr mgr = new PrdMgr();
                    DataTable dt = mgr.GetFocusCate();
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        Response.Write("");
                        return;
                    }
                    //List<Prd> listReviewPrd = mgr.DataTableToList2(dt);
                    string focusCateInfo = JsonConvert.SerializeObject(dt);
                    Response.Write(focusCateInfo);
                    xmlCache.WriteJsonFile(Context, focusCateInfo, sCacheFile);
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }

        }

        /// <summary>
        /// 查询评审区产品列表 count
        /// </summary>
        /// <param name="prdName">产品名称</param>
        /// <param name="cate">类别</param>
        /// <param name="state">区域状态</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="page">页码</param>
        public void GetReviewPrdCount()
        {
            try
            {
                Response.Clear();
                string prdName = Uri.UnescapeDataString(dic["prdName"].ToNullString());
                string cate = dic["cate"].ToNullString();
                string state = dic["state"].ToNullString();
                string focusCateIDs = dic["focusCateIDs"].ToNullString();
                string prdCate1 = dic["prdCate1"].ToNullString();
                string prdCate2 = dic["prdCate2"].ToNullString();
                string prdCate3 = dic["prdCate3"].ToNullString();
                string orderby = dic["orderby"].ToNullString();
                int page = dic["page"].ToNullString().ToInt();
                int pageSize = dic["pageSize"].ToNullString().ToInt();

                int startIndex = 1;
                int endIndex = int.MaxValue;

                orderby = orderby == "" ? "ranking desc" : orderby;

                // cache
                XMLCache xmlCache = new XMLCache();
                string sCacheFile = "EvaluateProductRankingDescPage1Count_" + xmlCache.GetDateString();
                bool bIsDataCasheable = IsDataCacheable(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex, pageSize);

                if (bIsDataCasheable)
                {
                    if (xmlCache.IsJsonFileExists(sCacheFile))
                    {
                        xmlCache.ReadCacheJson(this.Context, sCacheFile);
                        return;
                    }
                }

                //产品名称、买点特色、价格、发布时间、状态、评审人数           
                PrdMgr mgr = new PrdMgr();
                DataTable dt = mgr.GetPrdReview(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
                string sData = "0";
                if (dt != null)
                {
                    sData = dt.Rows.Count.ToString();
                }

                Response.Write(sData);

                // cache
                if (bIsDataCasheable)
                {
                    xmlCache.WriteJsonFile(Context, sData, sCacheFile);
                }
                
            }
            catch (Exception)
            {
                Response.Write("0");
            }

        }




       /// <summary>
        /// 查询评审区产品列表
       /// </summary>
       /// <param name="prdName">产品名称</param>
       /// <param name="cate">类别</param>
       /// <param name="state">区域状态</param>
       /// <param name="orderby">排序条件</param>
       /// <param name="page">页码</param>
        public void GetReviewPrd()
        {
            try
            {
                Response.Clear();          
                string prdName = Uri.UnescapeDataString(dic["prdName"].ToNullString());
                string cate = dic["cate"].ToNullString();
                string state = dic["state"].ToNullString();
                string focusCateIDs = dic["focusCateIDs"].ToNullString();
                string prdCate1 = dic["prdCate1"].ToNullString();
                string prdCate2 = dic["prdCate2"].ToNullString();
                string prdCate3 = dic["prdCate3"].ToNullString();
                string orderby = dic["orderby"].ToNullString();
                int page = dic["page"].ToNullString().ToInt();
                int pageSize = dic["pageSize"].ToNullString().ToInt();

                int startIndex = pageSize * (page - 1) + 1;
                int endIndex = pageSize * page;

                orderby = orderby == "" ? "ranking desc" : orderby;

                // cache
                XMLCache xmlCache = new XMLCache();
                string sCacheFile = "EvaluateProductRankingDescPage1Data_" + xmlCache.GetDateString();
                bool bIsDataCasheable = IsDataCacheable(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex, pageSize);

                if (bIsDataCasheable)
                {
                    if (xmlCache.IsJsonFileExists(sCacheFile))
                    {
                        xmlCache.ReadCacheJson(this.Context, sCacheFile);
                        return;
                    }
                }

                //产品名称、买点特色、价格、发布时间、状态、评审人数           
                PrdMgr mgr = new PrdMgr();
                DataTable dt = mgr.GetPrdReview(prdName, cate, focusCateIDs,prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
                string sData = string.Empty;
                if (dt != null && dt.Rows.Count > 0)
                {
                    sData = JsonConvert.SerializeObject(dt);
                }

                Response.Write(sData);

                // cache
                if (bIsDataCasheable)
                {
                    xmlCache.WriteJsonFile(Context, sData, sCacheFile);
                }

            }
            catch (Exception)
            {
                Response.Write("");
            }
          
        }


        /// <summary>
        /// 临时功能：屏蔽
        /// </summary>
        private void Delete()
        {
            Guid prdGuid = dic["id"].ToString().ToGuid().Value;
            PrdMgr mgr = new PrdMgr();
            //bool b = mgr.UpdatePrdState(10, prdGuid);
            bool b = mgr.Delete(prdGuid);
            if (b==true)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
            
        
        }

        private bool IsDataCacheable(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex, int pageSize)
        {
            // do not cache when user is login because favorite status depends on login user
            Guid? userGuid = CommUtil.IsLogion();
            if (userGuid != null) return false;

            // only cache first page of default search of by ranking desc, no other conditions 
            if (startIndex == 1 &&
                pageSize == 21 &&
                 string.IsNullOrEmpty(prdName) &&
                 string.IsNullOrEmpty(cate) &&
                 string.IsNullOrEmpty(focusCateIDs) &&
                 string.IsNullOrEmpty(prdCate1) &&
                 string.IsNullOrEmpty(prdCate2) &&
                 string.IsNullOrEmpty(prdCate3) &&
                 string.IsNullOrEmpty(state) &&
                 orderby.Trim().ToLower().IndexOf("ranking desc") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}