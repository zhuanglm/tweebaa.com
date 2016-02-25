using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.DataMgr;

namespace Twee.Mgr
{
    public class FavoriteMgr
    {

        private readonly FavoriteDataMgr mgr = new FavoriteDataMgr();
		
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(Guid prtguid, Guid userguid)
		{
            return mgr.Exists(prtguid, userguid);
		}

        public int GetMyCollageCollectionCount(string userID, string state, string beginTime, string endTime)
        {
            return mgr.GetMyCollageCollectionCount(userID, state, beginTime, endTime);
        }
                /// <summary>
        /// 增加一条CollageDesign数据
        /// </summary>
        public bool Add_CollageDesign_Favorite(Twee.Model.Favorite model)
        {
            return mgr.Add_CollageDesign_Favorite(model);
        }
        public bool CollageFavoriteExists(int iDesignID, Guid userguid)
        {
            return mgr.CollageFavoriteExists(iDesignID, userguid);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Twee.Model.Favorite model)
		{
            
			return mgr.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Twee.Model.Favorite model)
		{
			return mgr.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid guid)
		{
			
			return mgr.Delete(guid);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByUserPrd(Guid userGuid, Guid prdGuid)
        {

            return mgr.DeleteByUserPrd(userGuid, prdGuid);
        }

        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string guidlist )
		{
			return mgr.DeleteList(guidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Twee.Model.Favorite GetModel(Guid guid)
		{
			
			return mgr.GetModel(guid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Twee.Model.Favorite GetModelByCache(Guid guid)
		{
			
			string CacheKey = "wn_favoriteModel-" + guid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = mgr.GetModel(guid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Twee.Model.Favorite)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return mgr.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.Favorite> GetModelList(string strWhere)
		{
			DataSet ds = mgr.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.Favorite> DataTableToList(DataTable dt)
		{
			List<Twee.Model.Favorite> modelList = new List<Twee.Model.Favorite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Twee.Model.Favorite model;
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
			return mgr.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return mgr.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        #region 会员中心

        /// <summary>
        /// 获取会员中心我的收藏
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="state">产品状态</param>
        /// <param name="orderby">排序调价</param>
        /// <param name="beginTime">收藏开始时间</param>
        /// <param name="endTime">收藏结束时间</param>
        /// <param name="startIndex">记录号</param>
        /// <param name="endIndex">记录号</param>
        /// <returns></returns>
        public DataTable GetMyCollection(string userID, string state, string orderby, string beginTime, string endTime, int startIndex, int endIndex)
        {
            return mgr.GetMyCollection(userID, state, orderby, beginTime, endTime, startIndex, endIndex);
        }


        /// <summary>
        /// 获取会员中心我的收藏
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="state">产品状态</param>
        /// <param name="orderby">排序调价</param>
        /// <param name="beginTime">收藏开始时间</param>
        /// <param name="endTime">收藏结束时间</param>
        /// <param name="startIndex">记录号</param>
        /// <param name="endIndex"记录号></param>
        /// <returns></returns>
        public DataTable GetMyCollection2(string userID, string state, string orderby, string beginTime, string endTime, int startIndex, int endIndex)
        {
            return mgr.GetMyCollection2(userID, state, orderby, beginTime, endTime, startIndex, endIndex);
        }
        public DataTable GetMyCollageCollection2(string userID, string state, string orderby, string beginTime, string endTime, int startIndex, int endIndex)
        {
            return mgr.GetMyCollageCollection2(userID, state, orderby, beginTime, endTime, startIndex, endIndex);
        }
        /// <summary>
        /// 获取会员中心我的收藏总数
        /// </summary>        
        public int GetMyCollectionCount(string userID, string state, string beginTime, string endTime)
        {
            return mgr.GetMyCollectionCount(userID, state, beginTime,endTime);
        }

        #endregion 


		#endregion  ExtensionMethod
    }
}
