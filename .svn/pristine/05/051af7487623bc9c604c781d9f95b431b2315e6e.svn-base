using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Twee.Mgr
{
    public partial class CollageShareMgr
    {
        private readonly Twee.DataMgr.CollageShareDataMgr mgr = new Twee.DataMgr.CollageShareDataMgr();

               public CollageShareMgr()
        {

        }

        #region  BasicMethod
        public int CollageSplitShareCommission(string sOrderID)
        {
            return mgr.CollageSplitShareCommission(sOrderID);   
        }
        public DataSet GetListByPage(string strWhere, string userGuid, string orderby, int startIndex, int endIndex)
        {
            return mgr.GetListByPage(strWhere, userGuid, orderby, startIndex, endIndex);

        }
        public int AddPointsList(string sShareID)
        {
            return mgr.AddPointsList(sShareID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageShare model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageShare model)
        {
            return mgr.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CollageCate_ID)
        {

            return mgr.Delete(CollageCate_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageShare> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageShare> DataTableToList(DataTable dt)
        {
            List<Twee.Model.CollageShare> modelList = new List<Twee.Model.CollageShare>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.CollageShare model;
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
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
