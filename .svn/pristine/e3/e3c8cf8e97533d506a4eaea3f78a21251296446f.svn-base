using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.DataMgr;
using Twee.Model;
using System.Data;
using Twee.Comm;

namespace Twee.Mgr
{
    public class UserAddressMgr
    {
        private readonly UserAddressDataMgr mgr = new UserAddressDataMgr();
        public UserAddressMgr()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid guid)
		{
			return mgr.Exists(guid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Useraddress model)
		{
			return mgr.Add(model);
		}

          /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Useraddress model, out string addressGuid)
        {
            return mgr.Add(model, out addressGuid);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Useraddress model)
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
		public bool DeleteList(string guidlist )
		{
			return mgr.DeleteList(guidlist );
		}

        //Add by Long 2015/12/21
        public void AddZip2City(string strZip, string strCity, string strState, string strCountry)
        {
             mgr.AddZip2City(strZip, strCity, strState, strCountry);
        }
        public DataSet GetCityByZipcode(string strZip)
        {
            return mgr.GetCityByZipcode(strZip);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Useraddress GetModel(Guid guid)
		{
			
			return mgr.GetModel(guid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Useraddress GetModelByCache(Guid guid)
		{
			
			string CacheKey = "wn_useraddressModel-" + guid;
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
			return (Useraddress)objModel;
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
		public List<Useraddress> GetModelList(string strWhere)
		{
			DataSet ds = mgr.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Useraddress> DataTableToList(DataTable dt)
		{
			List<Useraddress> modelList = new List<Useraddress>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Useraddress model;
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
        /// <summary>
        /// 获得我的收货地址
        /// </summary>
        public DataTable GetMyAddress(Guid userGuid)
        {
            return mgr.GetMyAddress(userGuid);
        }

        /// <summary>
        /// 获得我的收货地址(根据记录guid)
        /// </summary>
        public DataTable GetAddressByGuid(string guid)
        {
            return mgr.GetAddressByGuid(guid);
        }
        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool SetDefault(Guid guid,Guid userGuid)
        {
            return mgr.SetDefault(guid, userGuid);
        }
		#endregion  ExtensionMethod
    }
}
