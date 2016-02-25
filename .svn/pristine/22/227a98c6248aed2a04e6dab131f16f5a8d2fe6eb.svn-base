using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Mgr
{
    public partial class CollageDesignMgr
    {
        private readonly Twee.DataMgr.CollageDesignDataMgr mgr = new Twee.DataMgr.CollageDesignDataMgr();
        public CollageDesignMgr()
        {
        }


        #region  BasicMethod
        public void RemoveMyCollage(string strCollageID)
        {
            mgr.RemoveMyCollage(strCollageID);
        }
        public int GetMyCollageTotal(string strUserID, string beginTime, string endtime)
        {
            return mgr.GetMyCollageTotal(strUserID, beginTime, endtime);
        }
        public DataSet GetMyCollage(string strUserID, string beginTime, string endtime, int iFirst, int iLast)
        {
            return mgr.GetMyCollage(strUserID,beginTime,endtime,iFirst,iLast);
        }
        public void UpdateCollageView(string strCollageID)
        {
             mgr.UpdateCollageView(strCollageID);
        }
        public int GetPublishTotal()
        {
            return mgr.GetPublishTotal();
        }
        public string GetDesignEMailNotify(string sDesignID)
        {
            return mgr.GetDesignEMailNotify(sDesignID);
        }
        public void SetDesignEMailNotify(string sDesignID)
        {
             mgr.SetDesignEMailNotify(sDesignID);
        }
        public DataSet GetAllListForMobileApp(string strWhere)
        {

            return mgr.GetAllListForMobileApp(strWhere);
        }
        public int GetSearchTotal(string sKeywords)
        {
            return mgr.GetSearchTotal(sKeywords);
        }
        public List<Twee.Model.CollageDesign> GetListByPage(string strWhere,int iSortType,int iFirst,int iLast)
        {
            DataSet ds = mgr.GetListByPage(strWhere, iSortType,iFirst, iLast);
            return DataTableToList(ds.Tables[0]);
        }
        public DataSet GetDatasetListByPage(string strWhere, int iSortType, int iFirst, int iLast)
        {
            return mgr.GetListByPage(strWhere, iSortType, iFirst, iLast);
        }

        //取该用户草稿的总数
        public int GetMyDraftTotal(string sUserID)
        {
            return mgr.GetMyDraftTotal(sUserID);

        }
        public List<Twee.Model.CollageDesign> GetAllList(string strWhere)
        {
            DataSet ds = mgr.GetAllList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        public int GetMyPublishTotal(string sUserID)
        {
            return mgr.GetMyPublishTotal(sUserID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageDesign model)
        {
            return mgr.Add(model);
        }
        public int Add_Free_Style(Twee.Model.CollageDesign model)
        {
            return mgr.Add_Free_Style(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageDesign model)
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
        public DataSet GetFreeStyleDesignByID(string design_id)
        {
            return mgr.GetFreeStyleDesignByID(design_id);
        }
        public Twee.Model.CollageDesign GetDesignByID(string design_id)
        {
            return mgr.GetDesignByID(design_id);
        }

        public DataSet GetCollageListForMobileApp(string strWhere)
        {
            return mgr.GetCollageListForMobileApp(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageDesign> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.CollageDesign> DataTableToList(DataTable dt)
        {
            List<Twee.Model.CollageDesign> modelList = new List<Twee.Model.CollageDesign>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.CollageDesign model;
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
