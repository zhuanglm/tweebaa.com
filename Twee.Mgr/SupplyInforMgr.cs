using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Model;
using System.Data;

namespace Twee.Mgr
{
    public class SupplyInforMgr
    {
        private readonly Twee.DataMgr.SupplyInforDataMgr mgr = new DataMgr.SupplyInforDataMgr();
        public SupplyInforMgr()
        { }
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
        public bool Add(Supplyinfor model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Supplyinfor model)
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
        public Supplyinfor GetModel(Guid guid)
        {

            return mgr.GetModel(guid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Supplyinfor GetModelByCache(Guid guid)
        {

            string CacheKey = "SupplyInforMgrModel-" + guid;
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
            return (Supplyinfor)objModel;
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
        public List<Supplyinfor> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Supplyinfor> DataTableToList(DataTable dt)
        {
            List<Supplyinfor> modelList = new List<Supplyinfor>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Supplyinfor model;
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
        #region  ExtensionMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Supplyinfor GetPrdSupply(Guid prdGuid)
        {
            return mgr.GetPrdSupply(prdGuid);          
        }


        #endregion  ExtensionMethod
    }
}
