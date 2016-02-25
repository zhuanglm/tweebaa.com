using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Twee.Model;
namespace Twee.Mgr
{
	/// <summary>
    /// CityMgr
	/// </summary>
	public partial class CityMgr
	{
		private readonly Twee.DataMgr.CityDataMgr mgr=new DataMgr.CityDataMgr();
        public CityMgr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return mgr.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CityID)
		{
			return mgr.Exists(CityID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Twee.Model.City model)
		{
			return mgr.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Twee.Model.City model)
		{
			return mgr.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CityID)
		{
			
			return mgr.Delete(CityID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CityIDlist )
		{
			return mgr.DeleteList(CityIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Twee.Model.City GetModel(int CityID)
		{
			
			return mgr.GetModel(CityID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Twee.Model.City GetModelByCache(int CityID)
		{
			
			string CacheKey = "wn_CityModel-" + CityID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = mgr.GetModel(CityID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Twee.Model.City)objModel;
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
		public List<Twee.Model.City> GetModelList(string strWhere)
		{
			DataSet ds = mgr.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.City> DataTableToList(DataTable dt)
		{
			List<Twee.Model.City> modelList = new List<Twee.Model.City>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Twee.Model.City model;
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

		#endregion  ExtensionMethod
	}
}

