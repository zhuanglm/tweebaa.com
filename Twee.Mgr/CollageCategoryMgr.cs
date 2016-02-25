using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.DataMgr;
using System.Collections.Generic;
using Maticsoft.Common;
using Twee.Model;
using System.Data;

namespace Twee.Mgr
{
    public partial class CollageCategoryMgr
    {
        private readonly Twee.DataMgr.CollageCategoryDataMgr mgr = new Twee.DataMgr.CollageCategoryDataMgr();

        public CollageCategoryMgr()
        {

        }

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageCategory model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageCategory model)
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
        public List<Twee.Model.CollageCategory> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageCategory> DataTableToList(DataTable dt)
        {
            List<Twee.Model.CollageCategory> modelList = new List<Twee.Model.CollageCategory>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.CollageCategory model;
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
