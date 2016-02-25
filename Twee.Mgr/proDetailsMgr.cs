using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;

namespace Twee.Mgr
{
    /// <summary>
    /// proDetailsMgr
    /// </summary>
    public partial class proDetailsMgr
    {
        private readonly Twee.DataMgr.proDetailsDataMgr dal = new DataMgr.proDetailsDataMgr();
        public proDetailsMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.proDetails model)
        {
            return dal.Add(model);
        }
        public int Add2(Twee.Model.proDetails model)
        {
            return dal.Add2(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.proDetails model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.proDetails GetModel(int id)
        {

            return dal.GetModel(id);
        }

        public List<Twee.Model.proDetails> GetEntityListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetEntityListByPage(strWhere,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.proDetails GetModel(string proid,string userid)
        {
            return dal.GetModel(proid,userid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.proDetails GetModelByCache(int id)
        {

            string CacheKey = "proDetailsMgrModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Twee.Model.proDetails)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.proDetails> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.proDetails> DataTableToList(DataTable dt)
        {
            List<Twee.Model.proDetails> modelList = new List<Twee.Model.proDetails>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.proDetails model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
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
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
         /// <summary>
        /// 分页获取竞价供货数据列表
        /// </summary>
        public DataSet GetInventoryByPage(string proName, string startTime, string endTime, string status, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            return dal.GetInventoryByPage(proName,startTime,endTime,status,orderby,startIndex,endIndex,out totalCount);
        }

        /// <summary>
        /// 采纳供货
        /// </summary>
        /// <param name="proid"></param>
        /// <param name="userid"></param>
        /// <param name="detailid"></param>
        /// <returns></returns>
        public string AcceptInventory(string proid, string userid, int detailid) {
            return dal.AcceptInventory(proid,userid,detailid);
        }
        /// <summary>
        /// 拒绝采纳该产品供货单
        /// </summary>
        /// <param name="detailid"></param>
        /// <returns></returns>
        public int UnAcceptInventory(string detailid) {
            return dal.UnAcceptInventory(detailid);
        }

        /// <summary>
        /// 修改供货单的状态
        /// </summary>
        /// <param name="proid">产品id</param>
        /// <param name="userid">供应商id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public bool UpdateInventoryState(string proid, string userid, int state)
        {
            return dal.UpdateInventoryState(proid, userid, state);
        }

        public List<Twee.Model.ProDetailSupplyType> GetSupplyTypeList()
        {
            return dal.GetSupplyTypeList();
        }

        public Twee.Model.ProDetailSupplyType GetSupplyTypeById(int id)
        {
            return dal.GetSupplyTypeById(id);
        }

        #endregion  ExtensionMethod
    }
}

