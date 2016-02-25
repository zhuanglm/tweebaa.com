using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.DataMgr;
using log4net;
using System.Reflection;
using System.Data;

namespace Twee.Mgr
{     

    public class ReviewMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        ReviewDataMgr mgr = new ReviewDataMgr();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid guid)
        {
            return mgr.Exists(guid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Review model, out int suportCount)
        {
            return mgr.Add(model,out suportCount);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Review model)
        {
            return mgr.Update(model);
        }

        public string GetProductCommentsTotal(string PrdGuid)
        {
            return mgr.GetProductCommentsTotal(PrdGuid);
        }
        public DataTable GetProductCommentsByPage(string PrdGuid, int iFirst, int iLast)
        {
            return mgr.GetProductCommentsByPage(PrdGuid, iFirst, iLast);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid guid)
        {

            return mgr.Delete(guid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string guidlist)
        {
            return mgr.DeleteList(guidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Review GetModel(Guid guid)
        {

            return mgr.GetModel(guid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.Review GetModelByCache(Guid guid)
        {

            string CacheKey = "wn_reviewModel-" + guid;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = mgr.GetModel(guid);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Twee.Model.Review)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return mgr.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return mgr.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Review> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Review> DataTableToList(DataTable dt)
        {
            List<Twee.Model.Review> modelList = new List<Twee.Model.Review>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Review model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return mgr.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return mgr.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return mgr.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod

        #region Extend

        /// <summary>
        /// 是否已经评审过该产品
        /// </summary>
        public int HaveReviewed(Guid prdguid, Guid userguid)
        { 
            return mgr.HaveReviewed(prdguid,userguid);
        }

        /// <summary>
        /// Get reviewed YesNo answers to questions
        /// </summary>
        /// <param name="prdguid"></param>
        /// <param name="userguid"></param>
        /// <returns></returns>
        public string GetReviewedYesNo(Guid prdguid, Guid userguid, out string reviewComment)
        {
            return mgr.GetReviewedYesNo(prdguid, userguid, out reviewComment);
        }

        /// <summary>
        /// 根据产品id, 评审类型查询该评审类型的所有评审者:1表示支持进入销售的，0表示不支持进入销售的
        /// </summary>
        /// <param name="prdGuid">产品id</param>
        /// <param name="type">1表示支持进入销售的，0表示不支持进入销售的</param>
        /// <returns></returns>
        public DataTable GetReviewUserByType(Guid prdguid, int type)
        {
            return mgr.GetReviewUserByType(prdguid, type);

        }

        /// 获取会员中心我的评审
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMyReview(string userID, string prdName, string cate, string state, string orderby, int startIndex, int endIndex, string begTime, string endTime)
        {
            DataTable dt = mgr.GetMyReview(userID, prdName, cate, state, orderby, startIndex, endIndex,begTime, endTime);
            return dt;
        }
        /// <summary>
        /// 获取会员中心我的评审总数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="prdName"></param>
        /// <param name="cate"></param>
        /// <param name="state"></param>
        /// <param name="begTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetMyReviewCount(string userID, string prdName, string cate, string state, string begTime, string endTime)
        {
            return mgr.GetMyReviewCount(userID, prdName, cate, state, begTime, endTime);
           
        }
        
        /// 获取会员中心我的evaluate grand total of "Successful Rate" and "Earn Gifts"
        /// Total number of evaulated products with answer "Yes"
        /// Total number of promoted products (from test-sale, buy-now and etc) evaulated products with answer "Yes"
        /// total number of Evaluation gifts rewards
        /// </summary>
        /// <param name="userID"></param>
        /// <returns> return a dataset with three tables</returns>
        public DataSet GetMyEvaluateGrandTotal(string userGuid)
        {
            return mgr.GetMyEvaluateGrandTotal(userGuid);
        }

        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.MyReview> DataTableToList2(DataTable dt)
        {
            List<Twee.Model.MyReview> modelList = new List<Twee.Model.MyReview>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.MyReview model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel2(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        #endregion

        #region 后台方法

        /// <summary>
        /// 查询评审记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable MgeGetAllReview(string strWhere1, string strWhere2, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return mgr.MgeGetAllReview(strWhere1, strWhere2, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }  

        }



        public int MgeGetAllReviewCount(string strWhere1, string strWhere2)
        {
            try
            {
                return mgr.MgeGetAllReviewCount(strWhere1, strWhere2);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }  

        }

        /// <summary>
        /// 根据产品ID查询该产品的评审总数
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public int GetReviewCountByProid(string proid)
        {
            return mgr.GetReviewCountByProid(proid);
        }


        #endregion
    }
}
