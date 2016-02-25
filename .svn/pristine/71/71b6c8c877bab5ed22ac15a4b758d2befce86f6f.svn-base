using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using log4net;
using System.Reflection;
using Maticsoft.Common;

namespace Twee.Mgr
{
    public class MoneyMgr
    {
       ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
       Twee.DataMgr.MoneyDataMgr dataMgr = new DataMgr.MoneyDataMgr();

       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(Guid guid)
       {
           return dataMgr.Exists(guid);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public bool Add(Twee.Model.Money model)
       {
           return dataMgr.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Twee.Model.Money model)
       {
           return dataMgr.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(Guid guid)
       {

           return dataMgr.Delete(guid);
       }
       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool DeleteList(string guidlist)
       {
           return dataMgr.DeleteList(guidlist);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Twee.Model.Money GetModel(Guid guid)
       {

           return dataMgr.GetModel(guid);
       }

       /// <summary>
       /// 得到一个对象实体，从缓存中
       /// </summary>
       public Twee.Model.Money GetModelByCache(Guid guid)
       {

           string CacheKey = "wn_moneyModel-" + guid;
           object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
           if (objModel == null)
           {
               try
               {
                   objModel = dataMgr.GetModel(guid);
                   if (objModel != null)
                   {                      
                       int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                       Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                   }
               }
               catch { }
           }
           return (Twee.Model.Money)objModel;
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           return dataMgr.GetList(strWhere);
       }
       /// <summary>
       /// 获得前几行数据
       /// </summary>
       public DataSet GetList(int Top, string strWhere, string filedOrder)
       {
           return dataMgr.GetList(Top, strWhere, filedOrder);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Twee.Model.Money> GetModelList(string strWhere)
       {
           DataSet ds = dataMgr.GetList(strWhere);
           return DataTableToList(ds.Tables[0]);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Twee.Model.Money> DataTableToList(DataTable dt)
       {
           List<Twee.Model.Money> modelList = new List<Twee.Model.Money>();
           int rowsCount = dt.Rows.Count;
           if (rowsCount > 0)
           {
               Twee.Model.Money model;
               for (int n = 0; n < rowsCount; n++)
               {
                   model = dataMgr.DataRowToModel(dt.Rows[n]);
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
           return dataMgr.GetRecordCount(strWhere);
       }
       /// <summary>
       /// 分页获取数据列表
       /// </summary>
       public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
       {
           return dataMgr.GetListByPage(strWhere, orderby, startIndex, endIndex);
       }
       /// <summary>
       /// 分页获取数据列表
       /// </summary>
       //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
       //{
       //return dataMgr.GetList(PageSize,PageIndex,strWhere);
       //}

       #endregion  BasicMethod

       #region 后台方法
        /// <summary>
        /// 获取佣金列表
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        /// <param name="moneyType"></param>
        /// <param name="moneyTimeBegin"></param>
        /// <param name="moneyTimeEnd"></param>
        /// <param name="moneyState"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
       public DataTable MgeGetListByPage(string guid, string userName, string userEmail, string moneyType, string moneyTimeBegin, string moneyTimeEnd, string moneyState, int startIndex, int endIndex, string orderBy)
        {
            try
            {
                return dataMgr.MgeGetListByPage(guid, userName, userEmail, moneyType, moneyTimeBegin, moneyTimeEnd, moneyState, startIndex, endIndex, orderBy);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("",ex);
            }
           
          

        }

        /// <summary>
        /// 获取佣金列表记录数
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        /// <param name="moneyType"></param>
        /// <param name="moneyTimeBegin"></param>
        /// <param name="moneyTimeEnd"></param>
        /// <param name="moneyState"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
       public int MgeGetRecordCount(string userGuid, string userName, string userEmail, string moneyType, string moneyTimeBegin, string moneyTimeEnd, string moneyState, int startIndex, int endIndex, string orderBy)
        {
            try
            {
                return dataMgr.MgeGetRecordCount(userGuid, userName, userEmail, moneyType, moneyTimeBegin, moneyTimeEnd, moneyState, startIndex, endIndex, orderBy);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
         

        }

        #endregion

       #region 前台方法
         /// <summary>
        /// 根据USERID获取不同类型收益的总和
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="shouYiType">收益类型编号</param>
        /// <returns></returns>
       public string GetShouYi(string userid, string shouYiType) {
           return dataMgr.GetShouYi(userid,shouYiType);
       }

        #endregion

    }
}
