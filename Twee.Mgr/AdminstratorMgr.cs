﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Mgr
{
   public class AdminstratorMgr
    {
       private readonly Twee.DataMgr.AdministratorDataMgr dal=new DataMgr.AdministratorDataMgr ();
		
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int iMgrUserID)
		{
            return dal.Exists(iMgrUserID);
		}

        public bool Exists(string sUserName, string sPassword)
        {
            return dal.Exists(sUserName, sPassword);
        }


        public Twee.Model.MgrUser GetSingle(string sUserName, string sPassword)
        {
            return dal.GetSingle(sUserName, sPassword);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Twee.Model.MgrUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Twee.Model.MgrUser model,bool flag)
		{
            if (flag)
                return dal.Update(model);
            else
                return dal.Update_No_Pwd(model);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateGroup(Twee.Model.MgrGroup model)
        {
            return dal.UpdateGroup(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int iMgrUserID)
		{

            return dal.Delete(iMgrUserID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sMgrUserIDList )
		{
            return dal.DeleteList(sMgrUserIDList);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Twee.Model.MgrUser GetModel(int iMgrUserID)
		{

            return dal.GetModel(iMgrUserID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.MgrGroup GetGrpModel(int iMgrGrpID)
        {

            return dal.GetGrpModel(iMgrGrpID);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Twee.Model.MgrUser GetModelByCache(int iMgrUserID)
		{

            string CacheKey = "adminstratorMgrModel-" + iMgrUserID.ToString();
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetGrpModel(iMgrUserID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Twee.Model.MgrUser)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.MgrUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.MgrUser> DataTableToList(DataTable dt)
		{
            List<Twee.Model.MgrUser> modelList = new List<Twee.Model.MgrUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Twee.Model.MgrUser model;
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
        public int GetGroupCount(string strWhere)
        {
            return dal.GetGroupCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetGroupListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetGroupListByPage(strWhere, orderby, startIndex, endIndex);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}


        public List<int> GetUserFunctionList(int iMgrUserID)
        {
            DataTable dt = dal.GetUserFunctionTable(iMgrUserID);
            if (dt == null)
                return null;

            List<int> funclist = new List<int>();

            foreach (DataRow dr in dt.Rows)
            {
                funclist.Add(int.Parse(dr["MgrFunction_ID"].ToString()));
                //System.Diagnostics.Debug.Write(dr["MgrFunction_ID"].ToString());
            }

            return funclist;
        }

        public bool IsFuncAllowed(int nUserID,int nFuncID)
        {
            List<int> funclist = GetUserFunctionList(nUserID);
            if (funclist.Contains(nFuncID))
                return true;
            else
                return false;
        }

        public int AddGroup(string sName, string sDesc, bool bActive, out string sErrMsg)
        {
            return dal.AddGroup(sName, sDesc, bActive, out sErrMsg);
        }

        public int DeleteGroup(int iGroupID)
        {
            return dal.DeleteGroup(iGroupID);
        }

        public int SetGroupFunctionList(int iGroupID, List<int> iFuncIDList)
        {
            return dal.SetGroupFunctionList(iGroupID, iFuncIDList);
        }

        public int SetUserGroupList(int iMgrUserID, List<int> iGroupIDList)
        {
            return dal.SetUserGroupList(iMgrUserID, iGroupIDList);
        }

        public DataTable GetGroupList()
        {
            return dal.GetGroupList();
        }

        public DataTable GetGroupFunctionList(int iGroupID)
        {
            return dal.GetGroupFunctionList(iGroupID);
        }

        public DataTable GetUserGroupList(int iMgrUserID)
        {
            return dal.GetUserGroupList(iMgrUserID);
        }

        
        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}