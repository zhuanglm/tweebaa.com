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
    public class PrdSpecMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        PrdSpecDataMgr mgr = new PrdSpecDataMgr();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid specguid)
        {
            return mgr.Exists(specguid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.PrdSpec model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.PrdSpec model)
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
        public bool Delete(Guid specguid)
        {

            return mgr.Delete(specguid);
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
        public Twee.Model.PrdSpec GetModel(int idx)
        {

            return mgr.GetModel(idx);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.PrdSpec GetModelByCache(int idx)
        {

            string CacheKey = "wn_prdSpecModel-" + idx;
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
            return (Twee.Model.PrdSpec)objModel;
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
        public List<Twee.Model.PrdSpec> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.PrdSpec> DataTableToList(DataTable dt)
        {
            List<Twee.Model.PrdSpec> modelList = new List<Twee.Model.PrdSpec>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.PrdSpec model;
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
        public bool MgeAdd(Guid prdGuid, string colorguid, string specname, string specvalue, int idx)
        {
            try
            {
                return mgr.MgeAdd(prdGuid, colorguid, specname, specvalue, idx);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        //public bool Add(Guid prdGuid, string colorguid, string specname, string specvalue, decimal price, int number, int idx)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into wn_prdSpec(");
        //    strSql.Append("prdGuid,colorguid,specname,specvalue,price,number)");
        //    strSql.Append(" values (");
        //    strSql.Append("@prdGuid,@colorguid,@specname,@specvalue,@price,@number)");
        //    SqlParameter[] parameters = {
        //                new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
        //                new SqlParameter("@colorguid", SqlDbType.NVarChar,500),
        //                new SqlParameter("@specname", SqlDbType.NVarChar,20),
        //                new SqlParameter("@specvalue", SqlDbType.NVarChar,20),
        //                new SqlParameter("@price", SqlDbType.Money),
        //                new SqlParameter("@number", SqlDbType.Int),
        //                new SqlParameter("@idx", SqlDbType.Int)                   

        //                                };
        //    parameters[0].Value = prdGuid;
        //    parameters[1].Value = colorguid;
        //    parameters[2].Value = specname;
        //    parameters[3].Value = specvalue;
        //    parameters[4].Value = price;
        //    parameters[5].Value = number;
        //    parameters[6].Value = idx;

        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool MgeUpdate(Guid specguid, string specname, string specvalue, int idx)
        {
            try
            {
                return mgr.MgeUpdate(specguid, specname, specvalue, idx);
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
        public bool MgeDelete(Guid prdguid)
        {
            try
            {
                return mgr.MgeDelete(prdguid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }


        /// <summary>
        /// 获得产品规格列表
        /// </summary>
        public DataTable MgeGetList(string prdguid)
        {
            try
            {
                return mgr.MgeGetList(prdguid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          
        }

        public DataTable MgeGetSpecColor(Guid prdguid, string specname, string specvalue)
        {
            try
            {
                return mgr.MgeGetSpecColor(prdguid, specname, specvalue);
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
