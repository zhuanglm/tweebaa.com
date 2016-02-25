using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Model;

namespace Twee.Mgr
{
    public class ShoppingcartMgr
    {
       private readonly Twee.DataMgr.ShoppingcartDataMgr mgr=new DataMgr.ShoppingcartDataMgr();
       public ShoppingcartMgr()
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
		public bool Add(Twee.Model.Shoppingcart model)
		{
			return mgr.Add(model);
		}

        /// <summary>
        /// 增加一条数据,输出该记录id
        /// </summary>
        public bool Add(Twee.Model.Shoppingcart model, out string guid)
        {
            return mgr.Add(model,out guid);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Twee.Model.Shoppingcart model)
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

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Twee.Model.Shoppingcart GetModel(Guid guid)
		{
			
			return mgr.GetModel(guid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Twee.Model.Shoppingcart GetModelByCache(Guid guid)
		{
			
			string CacheKey = "wn_shoppingcartModel-" + guid;
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
			return (Twee.Model.Shoppingcart)objModel;
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
		public List<Twee.Model.Shoppingcart> GetModelList(string strWhere)
		{
			DataSet ds = mgr.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.Shoppingcart> DataTableToList(DataTable dt)
		{
			List<Twee.Model.Shoppingcart> modelList = new List<Twee.Model.Shoppingcart>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Twee.Model.Shoppingcart model;
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
        /// get shopping cart quantity count
        /// </summary>
        public int GetShoppingCartQtyCount(string strWhere)
        {
            return mgr.GetShoppingCartQtyCount(strWhere);
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
        #region  会员中心

        /// <summary>
        /// 我的购物车(分页)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMyShopCart(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return mgr.GetMyShopCart(strWhere, orderby, startIndex, endIndex);   
            
        }

        /// <summary>
        /// 我的购物车(不分页)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMyShopCart(string state, Guid userGuid)
        {
            return mgr.GetMyShopCart(state, userGuid);   
        }

        /// <summary>
        /// 我的购物车，根据选择要结算购物车ids(不分页)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMyCheckedShopCart(string cartids, Guid? userGuid)
        {
            return mgr.GetMyCheckedShopCart(cartids, userGuid);
        }

        /// <summary>
        /// 获取数据对象集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Twee.Model.Shoppingcart> DataTableToList2(DataTable dt)
        {
            List<Twee.Model.Shoppingcart> modelList = new List<Twee.Model.Shoppingcart>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Shoppingcart model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel2(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        #endregion

        /// <summary>
        /// 修改购物车购买数量
        /// </summary>
        /// <param name="cartGuid">记录id</param>
        /// <param name="number">购买数量</param>
        /// <returns></returns>
        public bool UpdateShoupCartNum(string cartGuid, int number)
        {
            return mgr.UpdateShoupCartNum(cartGuid, number);
        }


        /// <summary>
        /// 修改购物车购买数量累加
        /// </summary>
        /// <param name="cartGuid">记录id</param>
        /// <param name="number">新增购买数量</param>
        /// <returns></returns>
        public bool AddShoupCartNum(string cartGuid, int number)
        {
            return mgr.AddShoupCartNum(cartGuid, number);

        }
        /// <summary>
        /// 判断该产品是否已经在购物车存在
        /// </summary>
        /// <param name="usretId"></param>
        /// <param name="prdGuid"></param>
        /// <returns>该产品的购物车id</returns>
        public string CheckIsInChart(string usretId, string prdGuid, int ruleid)
        {
            return mgr.CheckIsInChart(usretId, prdGuid, ruleid);
        }
         /// <summary>
        /// 判断该产品是否已经在购物车存在（未登录状态）
        /// </summary>
        /// <param name="shopCartGuid"></param>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public string CheckIsInChartNotLogin(string shopCartGuid, string prdGuid, int ruleid)
        {
            return mgr.CheckIsInChartNotLogin(shopCartGuid, prdGuid, ruleid);
        }
        /// <summary>
        /// 将未登录购物车数据移到数据库
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="cartids"></param>
        public bool RemoveCookieCartToDataBase(Guid? userGuid, string cartids)
        {
            return mgr.RemoveCookieCartToDataBase(userGuid, cartids);
        }

        /// <summary>
        /// Get Ship fee list by weight
        /// </summary>
        /// <param name="sWeight"></param>
        public DataTable GetShipFeeListByWeight(string sWeight, string sCountryID, string sZip)
        {
            return mgr.GetShipFeeListByWeight(sWeight, sCountryID, sZip);
        }

        /// <summary>
        /// Get Drop-Shiper Ship fee list
        /// </summary>
        /// <param name="sCountryID, sTotalPrice"></param>
        public DataTable GetDropShipperShipFeeList(string sCountryID, string sTotalPrice, int iShipFromID)
        {
            return mgr.GetDropShipperShipFeeList(sCountryID, sTotalPrice, iShipFromID);
        }


        /// <summary>
        /// Get Drop-Shiper flat Ship fee by country and total price
        /// </summary>
        /// <param name="sCountryID, sTotalPrice"></param>
        public decimal GetDropShipperFlatShipFee(string sCountryID, string sTotalPrice)
        {
            return mgr.GetDropShipperFlatShipFee(sCountryID, sTotalPrice);
        }

        /// <summary>
        /// Get Product Ship to Country Free
        /// </summary>
        public int GetProductShipToCountryFree(int iCountryID, int iRuleID)
        {
            return mgr.GetProductShipToCountryFree(iCountryID, iRuleID);
        }

        /// <summary>
        /// set ship method
        /// </summary>
         public bool SetShipMethod(string cartGuid, string prdGuid, int iShipMethodID, string sShipFee)
        {
            return mgr.SetShipMethod(cartGuid, prdGuid, iShipMethodID, sShipFee);
        }


        /// <summary>
        /// Get province tax
        /// </summary>
         public DataTable GetProvinceTax(string sCountryID, string sProvinceID)
         {
             return mgr.GetProvinceTax(sCountryID, sProvinceID);
         }
		#endregion  ExtensionMethod
    }
}
