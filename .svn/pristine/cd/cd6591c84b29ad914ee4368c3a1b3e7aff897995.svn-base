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
using Newtonsoft.Json;
using Twee.Model;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class prdShareAjax : System.Web.UI.Page
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
            if (action == "add")
            {
               
            }
            else if (action == "query")
            {
               
            }
            else if (action == "reviewPrd")
            {
                GetSalePrd();
            }
            else if (action == "reviewPrdCount")
            {
                GetSalePrdCount();
            }
            else if (action == "GetShortUrl")
            {
                GetShortUrl();
            }

        }


        /// <summary>
        /// Get short url for share
        /// </summary>
        public void GetShortUrl()
        {
            try
            {
                Response.Clear();
                string sShareUrl = dic["ShareUrl"].ToNullString();
 
                ShareMgr mgr = new ShareMgr();
                string sShortUrl = mgr.GetShortUrl(sShareUrl);
                Response.Write(sShortUrl);
            }
            catch (Exception)
            {
                Response.Write("https://www.tweebaa.com");
            }
        }


        /// <summary>
        /// 查询分享区产品列表 count
        /// </summary>
        /// <param name="prdName">产品名称</param>
        /// <param name="cate">类别</param>
        /// <param name="state">区域状态</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="page">页码</param>
        public void GetSalePrdCount()
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
                string sCacheFile = "ShareProductRankingDescPage1Count_" + xmlCache.GetDateString();
                bool bIsDataCasheable = IsDataCacheable(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex, pageSize);

                if (bIsDataCasheable)
                {
                    if (xmlCache.IsJsonFileExists(sCacheFile))
                    {
                        xmlCache.ReadCacheJson(this.Context, sCacheFile);
                        return;
                    }
                }


                PrdMgr mgr = new PrdMgr();
                DataTable dt = mgr.GetPrdShare(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);

                string sData = string.Empty;
                
                if (dt != null) {
                    sData = dt.Rows.Count.ToString();
                }
                Response.Write(dt.Rows.Count);

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
        /// 查询分享区产品列表
        /// </summary>
        /// <param name="prdName">产品名称</param>
        /// <param name="cate">类别</param>
        /// <param name="state">区域状态</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="page">页码</param>
        public void GetSalePrd()
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
                string sCacheFile = "ShareProductRankingDescPage1Data_" + xmlCache.GetDateString();
                bool bIsDataCasheable = IsDataCacheable(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex, pageSize);

                if (bIsDataCasheable)
                {
                    if (xmlCache.IsJsonFileExists(sCacheFile))
                    {
                        xmlCache.ReadCacheJson(this.Context, sCacheFile);
                        return;
                    }
                }


                PrdMgr mgr = new PrdMgr();
                DataTable dt = mgr.GetPrdShare(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);

                string sData = string.Empty;
                if (dt != null || dt.Rows.Count == 0)
                {
                    List<Prd> listReviewPrd = mgr.DataTableToList4(dt);
                    sData = JsonConvert.SerializeObject(listReviewPrd);
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