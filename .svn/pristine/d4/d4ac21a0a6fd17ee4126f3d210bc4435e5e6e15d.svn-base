using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using Twee.DataMgr;
using System.Data;

namespace Twee.Mgr
{
    public class ShareMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        ShareDataMgr mgr = new ShareDataMgr();

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
        public bool Add(Twee.Model.Share model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Share model)
        {
            return mgr.Update(model);
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
        public Twee.Model.Share GetModel(Guid guid)
        {

            return mgr.GetModel(guid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.Share GetModelByCache(Guid guid)
        {

            string CacheKey = "wn_shareModel-" + guid;
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
            return (Twee.Model.Share)objModel;
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
        public List<Twee.Model.Share> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Share> DataTableToList(DataTable dt)
        {
            List<Twee.Model.Share> modelList = new List<Twee.Model.Share>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Share model;
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
        public DataSet GetListByPage(string strWhere, string userGuid, string orderby, int startIndex, int endIndex)
        {
            return mgr.GetListByPage(strWhere, userGuid, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 获取数据列表总数（会员中心）
        /// </summary>
        public int GetShareCount(string strWhere, string userGuid, string sharetype, string begTime, string endTime)
        {
            return mgr.GetShareCount(strWhere, userGuid, sharetype, begTime, endTime);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return mgr.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod

        #region  Extend扩展方法

        /// <summary>
        /// Get full url by its short url id
        /// <returns></returns>
        public string GetFulltUrl(int iShortUrlId)
        {
            return mgr.GetFulltUrl(iShortUrlId);
        }
        
        /// <summary>
        /// short a url for share
        /// <returns></returns>
        public string GetShortUrl(string sUrl)
        {
            return mgr.GetShortUrl(sUrl);
        }
        /// <summary>
        /// 根据url修改访问数加1
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool UpdateVisitCount(string shareUrlGuid)
        {
            return mgr.UpdateVisitCount(shareUrlGuid); 
           
        }

       /// <summary>
       ///  查询所有产生订单的分享链接，包括未支付订单、已支付订单。 包含信息：
       ///  【分享链接url、url的id、分享者、分享方式、分享时间、链接被访问数、购买数量、
       ///  分享产品名称、id、分享金额（单价*数量）】      
       /// </summary>
        /// <param name="orderType">orderType：0为分享链接产生的未完成订单、1为查询所有分享链接产生的已完成订单2为查询所有分享连接产生的已支付订单并且已过退货期（即可提取）,空为查询链接产生的所有订单;；</param>
        /// <param name="shareType"> shareType: sina、tx、qzone、rr、douban/param></param>
       /// <returns></returns>
        public DataTable GteShareOrder(string orderType, string shareType)
        {
            return mgr.GteShareOrder(orderType,shareType);
        }

        /// <summary>
        /// 统计分享数据
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetShareCounByType(string userID)
        {
            return mgr.GetShareCounByType(userID);
        }

        /// <summary>
        /// 根据产品id查询其在表中是否已经存在分享链接
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public string IsExitShareUrl(string prdGuid, string shareType, string userGuid)
        {
            return mgr.IsExitShareUrl(prdGuid, shareType, userGuid);
        }

                /// <summary>
        /// member center: grand total of total clicks, total sold QTY and total share commission of currect user
        /// </summary>
        public DataSet GetShareGrandTotal(string userGuid)
        {
            return mgr.GetShareGrandTotal(userGuid);
        }
        public DataSet GetShareCollageTotal(string userGuid)
        {
            return mgr.GetShareCollageTotal(userGuid);
        }
        /// <summary>
        /// member center: get share summary total Count. total visit count and total sold quantity
        /// </summary>
        public DataSet GetShareSummaryTotal(string userGuid, string prdGuid, string sharetype, string begTime, string endTime)
        {
            return mgr.GetShareSummaryTotal(userGuid, prdGuid, sharetype, begTime, endTime);
        }

        /// <summary>
        /// member center: get share summary
        /// </summary>
        public DataSet GetShareSummary(string userGuid, string prdGuid, string sharetype, string begTime, string endTime, int iStartIdx, int iEndIdx)
        {
            return mgr.GetShareSummary(userGuid, prdGuid, sharetype, begTime, endTime, iStartIdx, iEndIdx);
        }


        #endregion

        #region 后台方法

        /// <summary>
        /// 获取用户分享记录
        /// </summary>
        public DataTable MgeGetPersonShare(string strWhere, string orderby, int startIndex, int endIndex, out int iTotalCount)
        {
            try
            {
                return mgr.MgeGetPersonShare(strWhere, orderby, startIndex, endIndex, out iTotalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          

        }

        /// <summary>
        /// 获取用户分享记录数目
        /// </summary>
        public int MgeGetAllShareCount(string strWhere)
        {
            try
            {
                return mgr.MgeGetAllShareCount(strWhere);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          

        }

        #endregion
    }
}
