using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Mgr
{
    public partial class CollageCommentMgr
    {
        private readonly Twee.DataMgr.CollageCommentDataMgr mgr = new Twee.DataMgr.CollageCommentDataMgr();

          public CollageCommentMgr()
        {

        }

        #region  BasicMethod
        /// <summary>
        /// 取该 DesignID的评论总数
        /// </summary>
        /// <param name="sDesignID"></param>
        /// <returns></returns>
          public int GetCommentsTotal(string sDesignID)
          {
              return mgr.GetCommentsTotal(sDesignID);

          }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageComments model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageComments model)
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

        public List<Twee.Model.CollageComments> GetListByPage(string strWhere, int iFirst, int iLast)
        {
            DataSet ds = mgr.GetListByPage(strWhere,iFirst,iLast);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageComments> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageComments> DataTableToList(DataTable dt)
        {
            List<Twee.Model.CollageComments> modelList = new List<Twee.Model.CollageComments>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.CollageComments model;
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
