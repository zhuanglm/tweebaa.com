using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Twee.DataMgr;
using System.Reflection;
using System.Data;

namespace Twee.Mgr
{
    /// <summary>
    /// 仓库类
    /// </summary>
    public class StoragMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        StoragDataMgr mgr = new StoragDataMgr();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid storagGuid)
        {
            return mgr.Exists(storagGuid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Storag model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Storag model)
        {
            return mgr.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid storagGuid)
        {

            return mgr.Delete(storagGuid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string storagGuidlist)
        {
            return mgr.DeleteList(storagGuidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Storag GetModel(Guid storagGuid)
        {

            return mgr.GetModel(storagGuid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.Storag GetModelByCache(Guid storagGuid)
        {

            string CacheKey = "wn_storagModel-" + storagGuid;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = mgr.GetModel(storagGuid);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Twee.Model.Storag)objModel;
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
        public List<Twee.Model.Storag> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Storag> DataTableToList(DataTable dt)
        {
            List<Twee.Model.Storag> modelList = new List<Twee.Model.Storag>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Storag model;
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
       

        #region 后台方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool MgeExists(string storagName)
        {
            try
            {
                return mgr.MgeExists(storagName);
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
        public bool MgeAdd(string storagName, string belongArea, string sendArea, string remarktxt)
        {
            try
            {
                return mgr.MgeAdd(storagName, belongArea, sendArea, remarktxt);
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
        public bool MgeUpdate(string storagGuid, string storagName, string belongArea, string sendArea, string remarktxt)
        {
            try
            {
                return mgr.MgeUpdate(storagGuid, storagName, belongArea, sendArea, remarktxt);
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
        public bool MgeDelete(Guid storagGuid)
        {
            try
            {
                return mgr.MgeDelete(storagGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }  
        }

        /// <summary>
        /// 获得仓库及其配送区域列表
        /// </summary>
        public DataTable MgeGetList(string strWhere)
        {
            try
            {
                return mgr.MgeGetList(strWhere);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }  
        }

        /// <summary>
        /// 所有仓库列表
        /// </summary>
        public DataTable MgeGetAllStorag(string strWhere)
        {
            try
            {
                return mgr.MgeGetAllStorag(strWhere);
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
