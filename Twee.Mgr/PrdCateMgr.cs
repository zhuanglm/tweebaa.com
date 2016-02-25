using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.DataMgr;
using System.Data;
using log4net;
using System.Reflection;

namespace Twee.Mgr
{
    public class PrdCateMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        PrdCateDataMgr mgr = new PrdCateDataMgr();
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
        public bool Add(Twee.Model.PrdCate model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.PrdCate model)
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
        public Twee.Model.PrdCate GetModel(Guid guid)
        {

            return mgr.GetModel(guid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.PrdCate GetModelByCache(Guid guid)
        {

            string CacheKey = "wn_prdCateModel-" + guid;
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
            return (Twee.Model.PrdCate)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return mgr.GetList(strWhere);
        }

        public List<Twee.Model.PrdCate> _GetList() {
            return mgr._GetList();
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
        public List<Twee.Model.PrdCate> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.PrdCate> DataTableToList(DataTable dt)
        {
            List<Twee.Model.PrdCate> modelList = new List<Twee.Model.PrdCate>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.PrdCate model;
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
        /// 获取类别列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>

        public DataTable MgeGetPrdCateList(string strWhere)
        {
            try
            {
                return mgr.MgeGetPrdCateList(strWhere);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          

        }
        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        /// <param name="prtGuid"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool MgeAddCate(Guid guid, string name, int layer, string prtGuid, int idx)
        {
            try
            {
                return mgr.MgeAddCate(guid, name, layer, prtGuid, idx);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        /// <summary>
        /// 修改类别
        /// </summary>
        /// <returns></returns>
        public bool MgeUpdateCate(Guid guid, string name, int layer, string prtGuid, int idx)
        {
            try
            {
                return mgr.MgeUpdateCate(guid, name, layer, prtGuid, idx);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          


        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool MgeDeleteCate(Guid guid)
        {
            try
            {
                return mgr.MgeDeleteCate(guid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          

        }

        /// <summary>
        /// 修改类别名称
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public bool UpdateTypeName(string guid, string typeName)
        {
            return mgr.UpdateTypeName(guid,typeName);
        }

        public List<string> GetSonTypeName(string parentId)
        {
            return mgr.GetSonTypeName(parentId);
        }
        #endregion

        #region 叠图：类别列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GePicCate(string strWhere)
        {
            return mgr.GePicCate(strWhere);
        }

        #endregion
    }
}
