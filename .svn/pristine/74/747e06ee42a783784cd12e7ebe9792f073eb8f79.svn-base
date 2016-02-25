using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Mgr
{
    public partial class CollageDesignProductMgr
    {
    private readonly Twee.DataMgr.CollageDesignProductDataMgr mgr = new Twee.DataMgr.CollageDesignProductDataMgr();

      public CollageDesignProductMgr()
        {

        }

        #region  BasicMethod
      public int CheckCollageDesignValid(string sDesignID)
      {
          return mgr.CheckCollageDesignValid(sDesignID);
      }
      public List<Twee.Model.Prd> DataTableToList3(DataTable dt)
      {
          List<Twee.Model.Prd> modelList = new List<Twee.Model.Prd>();
          int rowsCount = dt.Rows.Count;
          if (rowsCount > 0)
          {
              Twee.Model.Prd model;
              for (int n = 0; n < rowsCount; n++)
              {
                  model = mgr.DataRowToModel3(dt.Rows[n]);
                  if (model != null)
                  {
                      modelList.Add(model);
                  }
              }
          }
          return modelList;
      }
      public DataTable GetPrdSale(string prdName, string cate, string focusCateIDs, string state, string orderby, int startIndex, int endIndex)
      {

          return mgr.GetPrdSale(prdName, cate, focusCateIDs, state, orderby, startIndex, endIndex);
      }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageDesignProduct model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageDesignProduct model)
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
        public List<Twee.Model.CollageDesignProduct> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageDesignProduct> DataTableToList(DataTable dt)
        {
            List<Twee.Model.CollageDesignProduct> modelList = new List<Twee.Model.CollageDesignProduct>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.CollageDesignProduct model;
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
