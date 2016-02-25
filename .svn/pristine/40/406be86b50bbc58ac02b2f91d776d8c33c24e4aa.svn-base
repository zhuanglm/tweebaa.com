using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using System.Data;
using Twee.DataMgr;

namespace Twee.Mgr
{
    public class ReviewgradeparamMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        ReviewgradeparamDataMgr mgr = new ReviewgradeparamDataMgr();

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Reviewgradeparam model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Reviewgradeparam model)
        {
            return mgr.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            return mgr.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Reviewgradeparam GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return mgr.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.Reviewgradeparam GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "wn_reviewgradeparamModel-";
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = mgr.GetModel();
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Twee.Model.Reviewgradeparam)objModel;
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
        public List<Twee.Model.Reviewgradeparam> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Reviewgradeparam> DataTableToList(DataTable dt)
        {
            List<Twee.Model.Reviewgradeparam> modelList = new List<Twee.Model.Reviewgradeparam>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Reviewgradeparam model;
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
        /// 增加一条数据
        /// </summary>      
        public bool MgeAdd(int grade, int integral, int reviewreward, int commissionratio1, int commissionratio2, int commissionratio3)
        {
            try
            {
                return mgr.MgeAdd(grade, integral, reviewreward, commissionratio1, commissionratio2, commissionratio3);
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
        public bool MgeUpdate(Guid guid, int grade, int integral, int reviewreward, int commissionratio1, int commissionratio2, int commissionratio3)
        {

            try
            {
                return mgr.MgeAdd(grade, integral, reviewreward, commissionratio1, commissionratio2, commissionratio3);
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
        public bool MgeDelete(Guid guid)
        {
            try
            {
                return mgr.MgeDelete(guid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        /// <summary>
        /// 获得数据列表
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
        /// 获取记录总数
        /// </summary>        
        public int MgeGetRecordCount(string strWhere)
        {
            try
            {
                return mgr.MgeGetRecordCount(strWhere);
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
