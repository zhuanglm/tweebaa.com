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

namespace TweebaaWebApp.AjaxPages
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
                string prdName = dic["prdName"].ToNullString();
                string cate = dic["cate"].ToNullString();
                string state = dic["state"].ToNullString();
                string focusCateIDs = dic["focusCateIDs"].ToNullString();
                string prdCate1 = dic["prdCate1"].ToNullString();
                string prdCate2 = dic["prdCate2"].ToNullString();
                string prdCate3 = dic["prdCate3"].ToNullString();
                string orderby = dic["orderby"].ToNullString();
                int page = dic["page"].ToNullString().ToInt();
                orderby = orderby == "" ? "addtime desc" : orderby;

                PrdMgr mgr = new PrdMgr();
                int startIndex = 1;
                int endIndex = int.MaxValue;
                DataTable dt = mgr.GetPrdShare(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("0");
                    return;
                }
                Response.Write(dt.Rows.Count);
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
                string prdName = dic["prdName"].ToNullString();
                string cate = dic["cate"].ToNullString();
                string state = dic["state"].ToNullString();
                string focusCateIDs = dic["focusCateIDs"].ToNullString();
                string prdCate1 = dic["prdCate1"].ToNullString();
                string prdCate2 = dic["prdCate2"].ToNullString();
                string prdCate3 = dic["prdCate3"].ToNullString();
                string orderby = dic["orderby"].ToNullString();
                int page = dic["page"].ToNullString().ToInt();
                orderby = orderby == "" ? "addtime desc" : orderby;

                PrdMgr mgr = new PrdMgr();
                int startIndex = ConfigParamter.prdPageSize * (page - 1) + 1;
                int endIndex = ConfigParamter.prdPageSize * page;
                DataTable dt = mgr.GetPrdShare(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("");
                    return;
                }
                List<Prd> listReviewPrd = mgr.DataTableToList4(dt);
                string prdInfo = JsonConvert.SerializeObject(listReviewPrd);
                Response.Write(prdInfo);
            }
            catch (Exception)
            {
                Response.Write("");
            }

        }
    }
}