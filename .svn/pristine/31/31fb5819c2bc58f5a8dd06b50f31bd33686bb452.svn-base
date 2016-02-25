using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Mgr
{
     public partial class CollageTemplateMgr
    {
         private readonly Twee.DataMgr.CollageTemplateDataMgr mgr = new Twee.DataMgr.CollageTemplateDataMgr();

      public CollageTemplateMgr()
        {

        }

        #region  BasicMethod

      public Twee.Model.CollageTemplate GetTemplateByID(string templateID)
      {
          return mgr.GetTemplateByID(templateID);
      }
        public List<Twee.Model.CollageTemplate> GetListByPage(string strWhere, int iFirst, int iLast)
        {
            DataSet ds = mgr.GetListByPage(strWhere,iFirst,iLast);
            return DataTableToList(ds.Tables[0]);
        }

         
      public int GetBackgroundImgTotal()
      {
          return mgr.GetBackgroundImgTotal();
      }
      public int GetDecorationImgTotal(string sWhere)
      {
          return mgr.GetDecorationImgTotal(sWhere);
      }
      public List<Twee.Model.CollageBackgroundImg> GetBackgroundImg(string sPage)
      {
          return mgr.GetBackgroundImg(sPage);
      }
      public List<Twee.Model.CollageDecorationImg> GetDecorationImg(string sPage, string sPageDiv, string sWhere)
      {
          return mgr.GetDecorationImg(sPage,sPageDiv, sWhere);
        }
      public Twee.Model.CollageTemplate GetFirstRandom()
      {
          return mgr.GetFirstRandom();
      }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageTemplate model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageTemplate model)
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
        public List<Twee.Model.CollageTemplate> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageTemplate> DataTableToList(DataTable dt)
        {
            List<Twee.Model.CollageTemplate> modelList = new List<Twee.Model.CollageTemplate>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.CollageTemplate model;
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
