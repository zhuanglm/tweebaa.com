using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.DataMgr;
using log4net;
using System.Reflection;

namespace Twee.Mgr
{
    public class PatentMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        PatentDataMgr mgr = new PatentDataMgr();

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Patent model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Patent model)
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
        public Twee.Model.Patent GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return mgr.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.Patent GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "wn_patentModel-";
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
            return (Twee.Model.Patent)objModel;
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
        public List<Twee.Model.Patent> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Patent> DataTableToList(DataTable dt)
        {
            List<Twee.Model.Patent> modelList = new List<Twee.Model.Patent>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Patent model;
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

        #region  后台方法

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>      
        public DataTable MgeGetList()
        {
            try
            {
                return mgr.MgeGetList();
            }
            catch (Exception)
            {                
                throw;
            }

        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <returns></returns>       
        public DataTable MgeGetList(string userName, bool state, out int count)
        {
            try
            {
                return mgr.MgeGetList(userName, state, out count);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // <summary>
        /// 分页查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <returns></returns>      
        public DataTable MgeGetListByPage(string userName, bool state, int pageSize, int currentPage)
        {
            try
            {
                return mgr.MgeGetListByPage(userName, state, pageSize, currentPage);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>       
        public bool MgeDelete(string guid)
        {
            try
            {
                return mgr.MgeDelete(guid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>    
        public bool MgeUpdate(string guid, string panName, string panCode)
        {
            try
            {
                return mgr.MgeUpdate(guid, panName, panCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询专利详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable MgeGetInfo(string id)
        {
            try
            {
                return mgr.MgeGetInfo(id);
            }
            catch (Exception)
            {
                throw;
            }

        }


        #endregion
    }
}
