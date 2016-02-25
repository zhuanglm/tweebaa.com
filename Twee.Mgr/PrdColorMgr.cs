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
    public class PrdColorMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        PrdColorDataMgr mgr = new PrdColorDataMgr();
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.PrdColor model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.PrdColor model)
        {
            return mgr.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int idx)
        {

            return mgr.Delete(idx);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idxlist)
        {
            return mgr.DeleteList(idxlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.PrdColor GetModel(int idx)
        {

            return mgr.GetModel(idx);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.PrdColor GetModelByCache(int idx)
        {

            string CacheKey = "wn_prdColorModel-" + idx;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = mgr.GetModel(idx);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Twee.Model.PrdColor)objModel;
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
        public List<Twee.Model.PrdColor> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.PrdColor> DataTableToList(DataTable dt)
        {
            List<Twee.Model.PrdColor> modelList = new List<Twee.Model.PrdColor>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.PrdColor model;
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetColor(string strWhere)
        {
            return mgr.GetColor(strWhere);
        }

        #region 后台方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool MgeAdd(string colorName, string colorPic, int orderIndex)
        {
            try
            {
                return mgr.MgeAdd(colorName, colorPic, orderIndex);
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
        public bool MgeUpdate()
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update wn_color set ");
            //strSql.Append("colorguid=@colorguid");
            //strSql.Append(" where colorguid=@colorguid ");
            //SqlParameter[] parameters = {
            //            new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16)};
            //parameters[0].Value = model.colorguid;

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool MgeDelete(Guid colorguid)
        {
            try
            {
                return mgr.MgeDelete(colorguid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }


        /// <summary>
        /// 获取颜色列表
        /// </summary>
        public DataTable MgeGetAllColor()
        {
            try
            {
                return mgr.MgeGetAllColor();
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        /// <summary>
        /// 获取某产品颜色
        /// </summary>
        public DataTable MgeGetPrdColor(string prdguid)
        {
            try
            {
                return mgr.MgeGetPrdColor(prdguid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        /// <summary>
        /// 删除某产品颜色
        /// </summary>
        public bool MgeDeletePrdColor(string prdguid, string colorguid)
        {
            try
            {
                return mgr.MgeDeletePrdColor(prdguid, colorguid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }
        /// <summary>
        /// 添加某产品颜色
        /// </summary>
        public bool MgeAddPrdColor(Guid prdgui, Guid colorguid, string colorname)
        {
            try
            {
                return mgr.MgeAddPrdColor(prdgui, colorguid, colorname);
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
