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
using Twee.Model;
using Newtonsoft.Json;

namespace TweebaaWebApp.AjaxPages
{
    public partial class prdSaleAjax : System.Web.UI.Page
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
                AddReview();
            }
            else if (action == "query")
            {
                QueryReview();
            }
            else if (action == "reviewPrd")
            {
                GetSalePrd();
            }
            else if (action == "reviewPrdCount")
            {
                GetSalePrdCount();
            }

        }
        /// <summary>
        /// 查询预售区产品列表
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
                //orderby = orderby == "" ? "addtime desc" : orderby;
                orderby = orderby == "" && state == "" ? " wnstat desc" : orderby;               
   
                PrdMgr mgr = new PrdMgr();
                int startIndex = ConfigParamter.prdPageSize * (page - 1) + 1;
                int endIndex = ConfigParamter.prdPageSize * page;
                DataTable dt = mgr.GetPrdSale(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("");
                    return;
                }
                List<Prd> listReviewPrd = mgr.DataTableToList3(dt);
                string prdInfo = JsonConvert.SerializeObject(listReviewPrd);
                Response.Write(prdInfo);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        /// <summary>
        /// 查询预售区产品列表 count
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
                DataTable dt = mgr.GetPrdSale(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("0");
                    return;
                }
                Response.Write(dt.Rows.Count);
            }
            catch (Exception ex)
            {
                CommHelper.WrtLog("GetPrdSale Error: " + ex.Message);
                Response.Write("0");
            }

        }


        /// <summary>
        /// 添加评审
        /// </summary>
        private void AddReview()
        {
            try
            {
                Response.Clear();
                string prdID = dic["id"].ToString();
                string content = CommHelper.GetStrDecode(dic["content"].ToString());
                string cmdtype = CommHelper.GetStrDecode(dic["cmdtype"].ToString());
                Review review = new Review();
                review.cmdtxt = content;
                review.prtguid = prdID.ToGuid().Value;
                review.cmdtype = cmdtype;
                review.edttime = DateTime.Now;
                Guid? uGuid = CommUtil.IsLogion();
                if (uGuid == null)
                {
                    Response.Write("-2");//未登录
                    return;
                }
                review.userguid = uGuid.Value;
                review.wnstat = 1;
                ReviewMgr mgr = new ReviewMgr();
                int isExit = mgr.HaveReviewed(review.prtguid, uGuid.Value);
                if (isExit==0)
                {
                    Response.Write("-1");//存在
                    return;
                }
                int suportCount = 0;
                if (mgr.Add(review,out suportCount))
                {
                    Response.Write("1");//成功
                    //UserGradeCalMgr grade = new UserGradeCalMgr();
                    //grade.MgePublishIntegralCal(uGuid.Value, suportCount, review.prtguid);//计算发布者积分
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
        /// 查询产品评审记录
        /// </summary>
        private void QueryReview()
        {
            if (dic["id"] != null && !string.IsNullOrEmpty(dic["id"].ToString()) && dic["id"].ToString() != "undefined")
            {


                string prdID = dic["id"].ToString();
                ReviewMgr mgr = new ReviewMgr();
                UserMgr userMgr = new UserMgr();
                int count = mgr.GetRecordCount(" prtguid='" + prdID + "'");
                DataSet ds = mgr.GetListByPage(" prtguid='" + prdID + "'", " edttime desc ", 0, 50);
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

     
    }
}