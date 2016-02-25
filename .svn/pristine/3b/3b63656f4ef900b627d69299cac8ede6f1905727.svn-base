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
    /// <summary>
    /// 库存类
    /// </summary>
    public class PrdStoragMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        PrdStoragDataMgr mgr = new PrdStoragDataMgr();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid psGuid)
        {
            return mgr.Exists(psGuid);
        }

        public Twee.Model.PrdStorag GetModelByPrdId(Guid prdGuid) {
            return mgr.GetModelByPrdId(prdGuid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.PrdStorag model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.PrdStorag model)
        {
            return mgr.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid psGuid)
        {

            return mgr.Delete(psGuid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string psGuidlist)
        {
            return mgr.DeleteList(psGuidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.PrdStorag GetModel(Guid psGuid)
        {

            return mgr.GetModel(psGuid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.PrdStorag GetModelByCache(Guid psGuid)
        {

            string CacheKey = "wn_prdStoragModel-" + psGuid;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = mgr.GetModel(psGuid);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Twee.Model.PrdStorag)objModel;
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
        public List<Twee.Model.PrdStorag> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.PrdStorag> DataTableToList(DataTable dt)
        {
            List<Twee.Model.PrdStorag> modelList = new List<Twee.Model.PrdStorag>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.PrdStorag model;
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

        #region 前台 订单
        /// <summary>
        /// 根据订单产品数量修改库存（在付款成功后调用该方法）
        /// </summary>
        /// <param name="guidno"></param>
        public bool UpdateStoragByOrder(string guidno)
        {
            return mgr.UpdateStoragByOrder(guidno);

        }

        #endregion

        #region 后台方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool MgeExists(Guid prdGuid)
        {
            try
            {
                return mgr.Exists(prdGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool MgeAdd(Guid prdGuid, string storagGuid, int number, int promptNumber)
        {
            try
            {
                return mgr.MgeAdd(prdGuid, storagGuid, number, promptNumber);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool MgeUpdate(Guid psGuid, string storagGuid, int number, int promptNumber)
        {
            try
            {
                return mgr.MgeUpdate(psGuid, storagGuid, number, promptNumber);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool MgeDelete(Guid prdGuid)
        {
            try
            {
                return mgr.MgeDelete(prdGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        /// <summary>
        /// 获取产品库存信息
        /// </summary>
        /// <param name="prdGuid">产品id</param>
        /// <param name="prdGuid">产品名称</param>
        /// <param name="storaName">仓库名称</param>
        /// <param name="belongArea">所属区域</param>
        /// <param name="sendArea">配送区域</param>
        /// <param name="storaNumber0">库存起始值</param>
        /// <param name="storaNumber1">库存终止值</param>
        /// <param name="isPrompt">true查询小于等于警界值的产品，false反之,空查询全部</param>
        /// <returns></returns>
        public DataTable MgeGetPrdStora(string prdGuid, string prdName, string storaName, string belongArea, string sendArea, string storaNumber0, string storaNumber1, string isPrompt)
        {
            try
            {
                return mgr.MgeGetPrdStora(prdGuid, prdName, storaName, belongArea, sendArea, storaNumber0, storaNumber1, isPrompt);
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
