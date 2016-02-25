using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Mgr
{
    public class SharePrdMgr
    {
        private readonly Twee.DataMgr.SharePrdDataMgr mgr = new Twee.DataMgr.SharePrdDataMgr();
        public SharePrdMgr()
		{}
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.SharePrd model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.SharePrd model)
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
        public Twee.Model.SharePrd GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return mgr.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.SharePrd GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "SharePrdModel-";
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
            return (Twee.Model.SharePrd)objModel;
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
        public List<Twee.Model.SharePrd> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.SharePrd> DataTableToList(DataTable dt)
        {
            List<Twee.Model.SharePrd> modelList = new List<Twee.Model.SharePrd>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.SharePrd model;
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

        #region  ExtensionMethod  叠图分享


        /// <summary>
        /// 分页获取叠图产品区数据列表
        /// </summary>
        public DataSet GetSharePrdByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return mgr.GetSharePrdByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取叠图产品区数据列表
        /// </summary>
        public List<Twee.Model.SharePrd> GetSharePrdByPage2(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = mgr.GetSharePrdByPage(strWhere, orderby, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);           
        }     
       
        #endregion  ExtensionMethod
    }
}
