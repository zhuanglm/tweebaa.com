﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Comm;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public class ShoppingcartDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_shoppingcart");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Shoppingcart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_shoppingcart(");
            strSql.Append("guid,cookieguid,prdguid,quantity,edttime,userguid,shareId,ruleid)");
            strSql.Append(" values (");
            strSql.Append("@guid,@cookieguid,@prdguid,@quantity,@edttime,@userguid,@shareId,@ruleid)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cookieguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@quantity", SqlDbType.Decimal,8),
					new SqlParameter("@edttime", SqlDbType.DateTime),
                    new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@shareId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ruleid", SqlDbType.Int)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = null;
            parameters[2].Value = model.prdguid;
            parameters[3].Value = model.quantity;
            parameters[4].Value = model.edttime;
            parameters[5].Value = model.userguid;
            parameters[6].Value = model.shareId;
            parameters[7].Value = model.ruleid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加一条数据,输出该记录id
        /// </summary>
        public bool Add(Twee.Model.Shoppingcart model,out string guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_shoppingcart(");
            strSql.Append("guid,cookieguid,prdguid,quantity,edttime,userguid,shareId,ruleid)");
            strSql.Append(" values (");
            strSql.Append("@guid,@cookieguid,@prdguid,@quantity,@edttime,@userguid,@shareId,@ruleid)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cookieguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@quantity", SqlDbType.Decimal,8),
					new SqlParameter("@edttime", SqlDbType.DateTime),
                    new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@shareId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ruleid", SqlDbType.Int)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = null;
            parameters[2].Value = model.prdguid;
            parameters[3].Value = model.quantity;
            parameters[4].Value = model.edttime;
            parameters[5].Value = model.userguid;
            parameters[6].Value = model.shareId;
            parameters[7].Value = model.ruleid;
            guid = parameters[0].Value.ToString();
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Shoppingcart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_shoppingcart set ");
            strSql.Append("cookieguid=@cookieguid,");
            strSql.Append("prdguid=@prdguid,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("edttime=@edttime");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@cookieguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@quantity", SqlDbType.Decimal,8),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.cookieguid;
            parameters[1].Value = model.prdguid;
            parameters[2].Value = model.quantity;
            parameters[3].Value = model.edttime;
            parameters[4].Value = model.guid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid guid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from wn_shoppingcart ");
                strSql.Append(" where guid=@guid ");
                SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
                parameters[0].Value = guid;

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
           
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string guidlist)
        {
            try
            {
                guidlist = FormatShippingCartGuid(guidlist);
                if (guidlist.Substring(0, 1) == "'")
                {

                }
                else
                {
                    guidlist = "'" + guidlist + "'";
                }
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from wn_shoppingcart ");
                strSql.Append(" where guid in (" + guidlist + ")  ");
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return false;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Shoppingcart GetModel(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,cookieguid,prdguid,quantity,edttime,userguid,shareId,ruleid, ShipMethod_ID, shipfee from wn_shoppingcart ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            Twee.Model.Shoppingcart model = new Twee.Model.Shoppingcart();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Shoppingcart DataRowToModel(DataRow row)
        {
            Twee.Model.Shoppingcart model = new Twee.Model.Shoppingcart();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["cookieguid"] != null && row["cookieguid"].ToString() != "")
                {
                    model.cookieguid = new Guid(row["cookieguid"].ToString());
                }
                if (row["prdguid"] != null && row["prdguid"].ToString() != "")
                {
                    model.prdguid = new Guid(row["prdguid"].ToString());
                }
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = decimal.Parse(row["quantity"].ToString());
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
                if (row["userguid"] != null && row["userguid"].ToString() != "")
                {
                    model.userguid = new Guid(row["userguid"].ToString());
                }
                if (row["shareId"] != null && row["shareId"].ToString() != "")
                {
                    model.shareId = new Guid(row["shareId"].ToString());
                }
                if (row["ruleid"] != null && row["ruleid"].ToString() != "")
                {
                    model.ruleid = row["ruleid"].ToString().ToInt();
                }
                if (row["ShipMethod_ID"] != null && row["ShipMethod_ID"].ToString() != "")
                {
                    model.shipmethodid = row["ShipMethod_ID"].ToString().ToInt();
                }
                if (row["shipfee"] != null && row["shipfee"].ToString() != "")
                {
                    model.shipfee = row["shipfee"].ToString().ToDecimal();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select guid,cookieguid,prdguid,quantity,edttime ");
            strSql.Append(" FROM wn_shoppingcart ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" guid,cookieguid,prdguid,quantity,edttime ");
            strSql.Append(" FROM wn_shoppingcart ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wn_shoppingcart TT left join (select price,ruleid,p1,p2 from wn_prdprice ) parea  on TT.ruleid=parea.ruleid  where (TT.quantity between parea.p1 and parea.p2)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// get shopping cart quantity count
        /// </summary>
        public int GetShoppingCartQtyCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(TT.quantity) FROM wn_shoppingcart TT left join (select price,ruleid,p1,p2 from wn_prdprice ) parea  on TT.ruleid=parea.ruleid  where (TT.quantity between parea.p1 and parea.p2)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.guid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_shoppingcart T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "wn_shoppingcart";
            parameters[1].Value = "guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod


        #region  ExtensionMethod

        #region  会员中心

        /// <summary>
        /// 我的购物车（分页）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMyShopCart(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.guid,TT.prdguid,TT.quantity,TT.edttime,TT.userguid,f.fileurl,p.estimateprice,p.saleprice,p.wnstat FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.guid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_shoppingcart T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join  (select name,estimateprice,saleprice,wnstat from  [dbo].[wn_prd]) p on TT.prdguid= p.prdguid ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds!=null&&ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            return null;
        
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
            StringBuilder strSql2 = new StringBuilder();
            StringBuilder strSql3 = new StringBuilder();
            //预售数据
            strSql2.Append("SELECT TT.guid,TT.prdguid,TT.quantity,TT.edttime,TT.userguid,TT.ruleid,f.fileurl,p.estimateprice,p.saleprice,money=0.00,TT.quantity*p.saleprice as premoney,p.name,p.wnstat,pr.color,pr.prorule  FROM wn_shoppingcart TT  ");
            strSql2.Append(" left join (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql2.Append(" left join (select prdguid, name,estimateprice,saleprice,wnstat from  [dbo].[wn_prd]) p on TT.prdguid= p.prdguid ");   
            strSql2.Append(" left join wn_proRules pr on TT.ruleid=pr.id");
            strSql2.AppendFormat(" WHERE TT.userguid='{0}' and p.wnstat='2'", userGuid);

            //销售数据
            strSql3.Append("SELECT TT.guid,TT.prdguid,TT.quantity,TT.edttime,TT.userguid,TT.ruleid,f.fileurl,p.estimateprice,p.saleprice,parea.price,TT.quantity* parea.price as money,TT.quantity*p.saleprice as premoney,p.name,p.wnstat,pr.color,pr.prorule  FROM wn_shoppingcart TT  ");
            strSql3.Append(" left join (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql3.Append(" left join (select prdguid, name,estimateprice,saleprice,wnstat from  [dbo].[wn_prd]) p on TT.prdguid= p.prdguid ");
            strSql3.Append(" left join (select price,ruleid,countfrom,countto from wn_proPriceArea ) parea  on TT.ruleid=parea.ruleid");
            strSql3.Append(" left join wn_proRules pr on TT.ruleid=pr.id");
            strSql3.AppendFormat(" WHERE parea.countfrom<=TT.quantity and parea.countto>=TT.quantity  and TT.userguid='{0}'", userGuid);
            strSql3.AppendFormat(" and p.wnstat='3'");
            DataSet ds = new DataSet();
            if (state=="2")
            {
                ds = DbHelperSQL.Query(strSql2.ToString());               
            }
            else if (state=="3")
            {
                ds = DbHelperSQL.Query(strSql3.ToString());                            
            }
            else if (state=="")
            {
                ds = DbHelperSQL.Query(strSql2.ToString() + ";" + strSql3.ToString());               
            }
            if (ds!=null && ds.Tables.Count==1)
            {
                 return ds.Tables[0];
            }
            else if (ds!=null && ds.Tables.Count==2)
            {
                DataTable dt2 = ds.Tables[0];
                DataTable dt3 = ds.Tables[1];
                dt2.Merge(dt3);
                return dt2;
            }           
          
            return null;

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
            if(!string.IsNullOrEmpty(cartids))
                cartids = FormatShippingCartGuid(cartids);

            if (userGuid == null && string.IsNullOrEmpty(cartids))
            {
                return null;
            }
            StringBuilder strSql = new StringBuilder();           
            strSql.Append("SELECT TT.guid,TT.prdguid,TT.quantity,TT.edttime,TT.userguid,f.fileurl,p.estimateprice,p.saleprice,parea.price,TT.quantity* parea.price as money,TT.quantity*p.saleprice as premoney, TT.ShipMethod_ID, p.name,p.wnstat,pr.color,pr.id as proRulesID,pr.prorule,pr.prosku,pr.ShipFrom_ID,pr.proweight, pr.IsCustomerFreeShip, pr.ShipPartner_ID, pr.ShipFrom_ID FROM wn_shoppingcart TT  ");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join  (select prdguid, name,estimateprice,saleprice,wnstat from  [dbo].[wn_prd]) p on TT.prdguid= p.prdguid ");
            strSql.Append(" left join (select price,ruleid,p1,p2 from wn_prdprice ) parea  on TT.ruleid=parea.ruleid ");
            strSql.Append(" left join wn_proRules pr on TT.ruleid=pr.id");           
            strSql.AppendFormat(" WHERE (TT.quantity between parea.p1 and parea.p2)");

            if (userGuid != null)
            {
                //RemoveCookieCartToDataBase(userGuid, cartids);
                strSql.AppendFormat(" and TT.userguid='{0}'", userGuid);
            }           
            else if ((userGuid == null || userGuid.ToString() == "") && !string.IsNullOrEmpty(cartids))
            {
                if (cartids.Length > 10)
                {
                    if (cartids.Substring(0, 1) != "'") cartids = "'" + cartids;
                    if (cartids.Substring(cartids.Length - 1, 1) != "'") cartids = cartids + "'";
                    strSql.AppendFormat(" and TT.guid in ({0}) and userGuid='{1}'", cartids, CommUtil.GetDummyGuid());
                }
            }
            //else if (userGuid != null && !string.IsNullOrEmpty(cartids))
            //{
            //    strSql.AppendFormat(" and TT.guid in ({0}) and TT.userguid='{1}'", cartids, userGuid );
            //}
            //if (userGuid != null && userGuid.ToString() != "" && string.IsNullOrEmpty(cartids))
            //{
            //    strSql.AppendFormat(" and TT.userguid='{0}'", userGuid);
            //}            
            //else if ((userGuid == null || userGuid.ToString() == "") && !string.IsNullOrEmpty(cartids))
            //{
            //    strSql.AppendFormat(" and TT.guid in ({0})", cartids);
            //}
            //else
            //{
            //    strSql.AppendFormat(" and (TT.userguid='{0}' or TT.guid in ({1}))",userGuid, cartids);
            //}
            strSql.AppendFormat(" order by TT.prdguid");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
      

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Shoppingcart DataRowToModel2(DataRow row)
        {
            Twee.Model.Shoppingcart model = new Twee.Model.Shoppingcart();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["prdguid"] != null && row["prdguid"].ToString() != "")
                {
                    model.prdguid = new Guid(row["prdguid"].ToString());
                }
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = decimal.Parse(row["quantity"].ToString());
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
                if (row["userguid"] != null && row["userguid"].ToString() != "")
                {
                    model.userguid = row["userguid"].ToString().ToGuid().Value;
                }
                if (row["fileurl"] != null && row["fileurl"].ToString() != "")
                {
                    model.fileurl = row["fileurl"].ToString();
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = row["estimateprice"].ToString().ToDecimal();
                }
                if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                {
                    model.saleprice = row["saleprice"].ToString().ToDecimal();
                }
                if (row["name"] != null && row["name"].ToString() != "")
                {
                    model.name = row["name"].ToString();
                }
                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = row["wnstat"].ToString();
                }
                if (row["money"] != null && row["money"].ToString() != "")
                {
                    model.money = row["money"].ToNullString().ToDecimal();
                }      


            }
            return model;
        }

        #endregion

        /// <summary>
        /// 修改购物车购买数量
        /// </summary>
        /// <param name="cartGuid">记录id</param>
        /// <param name="number">购买数量</param>
        /// <returns></returns>
        public bool UpdateShoupCartNum(string cartGuid,int number)
        {
            string strSql = "update  wn_shoppingcart set quantity=" + number + " where guid='" + cartGuid + "'";
            int resu = DbHelperSQL.ExecuteSql(strSql);
            if (resu>0)
            {
                return true;
            }
            return false;
        
        }
        /// <summary>
        /// 修改购物车购买数量累加
        /// </summary>
        /// <param name="cartGuid">记录id</param>
        /// <param name="number">新增购买数量</param>
        /// <returns></returns>
        public bool AddShoupCartNum(string cartGuid, int number)
        {
            try
            {
                string strSql = "update  wn_shoppingcart set quantity=quantity+" + number + " where guid='" + cartGuid + "'";
                int resu = DbHelperSQL.ExecuteSql(strSql);
                if (resu > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return false;

        }
        /// <summary>
        /// 判断该产品是否已经在购物车存在（登录状态）
        /// </summary>
        /// <param name="usretId"></param>
        /// <param name="prdGuid"></param>
        /// <returns>该产品的购物车id</returns>
        public string CheckIsInChart(string usretId,string prdGuid,int ruleid)
        {
            string strSql1 = "select guid from dbo.wn_shoppingcart where userguid='" + usretId + "' and prdguid='" + prdGuid + "' and ruleid=" + ruleid;
            DataSet ds = DbHelperSQL.Query(strSql1);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0]["guid"].ToString();
            }
            return null;
        }

        string FormatShippingCartGuid(string shopCartGuid)
        {
            if (shopCartGuid == null) return "''";
            string[] temp = shopCartGuid.Split(',');
            string sRet = "'";
            if (temp.Length > 1)
            {
                foreach (string s in temp)
                {
                    if (s.Length >= 36)
                    {
                        sRet = sRet + s.Replace("'", "").Replace("'", "").Replace("&#39;", "").Replace("&#39;", "");
                        sRet = sRet + "','";
                    }
                }
                sRet = sRet.Substring(0, sRet.Length - 2);
            }
            else
            {
                sRet = shopCartGuid;
            }
           // if (sRet.Substring(sRet.Length - 1, 1) != "'") sRet = sRet + "'";
            return sRet;

        }

        /// <summary>
        /// 判断该产品是否已经在购物车存在（未登录状态）
        /// </summary>
        /// <param name="shopCartGuid"></param>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public string CheckIsInChartNotLogin(string shopCartGuid, string prdGuid, int ruleid)
        {
            try
            {
                shopCartGuid = FormatShippingCartGuid(shopCartGuid);
                //1='7517a6a0-91e8-4ac2-832b-b28d02a72171,'c0a7a189-52ee-4e6b-9b73-ed3933426ee9' 
                string strSql1 = "";
                if (shopCartGuid.Substring(0, 1) == "'")
                {
                    //Modify by Long 2016/01/08 for To-Do-list 106
                    strSql1 = "select guid from dbo.wn_shoppingcart where userguid='00000000-0000-0000-0000-000000000000' and guid in (" + shopCartGuid + ") and prdguid='" + prdGuid + "' and ruleid=" + ruleid.ToString();
                }
                else
                {
                    //Modify by Long 2016/01/08 for To-Do-list 106
                    strSql1 = "select guid from dbo.wn_shoppingcart where userguid='00000000-0000-0000-0000-000000000000' and guid in ('" + shopCartGuid + "') and prdguid='" + prdGuid + "' and ruleid=" + ruleid.ToString();
                }
                DataSet ds = DbHelperSQL.Query(strSql1);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["guid"].ToString();
                }
                return null;
            }
            catch (Exception e)
            {
                Twee.Comm.CommHelper.WrtLog("CheckIsInChartNotLogin 1=" + shopCartGuid + " 2=" + prdGuid + " 3=" + ruleid);
                Twee.Comm.CommUtil.GenernalErrorHandler(  e);
            }
            return null;
        }

        /// <summary>
        /// 将未登录购物车数据移到数据库
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="cartids"></param>
        public bool RemoveCookieCartToDataBase(Guid? userGuid, string cartids)
        {
            try
            {
                if (string.IsNullOrEmpty(cartids))
                {
                    return false;
                }
               // cartids = cartids.Replace("'", "");

                //string strSql = string.Format("update wn_shoppingcart set userguid='{0}' where guid in({1});", userGuid, cartids);
                //int resu = DbHelperSQL.ExecuteSql(strSql);

                //----------------------------------------------------------------------
                // jack cao 2015-10-29
                // cannot just update userguid because there may have same product/rule, it needs to merge in this case 
                //----------------------------------------------------------------------
                // get shopping cart info for  all the items in the shipping cart created by cookie
                int iAffectedRow = 0;
                string strSql = "select guid, prdguid, ruleid, quantity, shareid from wn_shoppingcart where userguid='00000000-0000-0000-0000-000000000000' and guid in(" + cartids + ")";
                DataSet dsCookie = DbHelperSQL.Query(strSql);
                if (dsCookie == null ) return false;
                if (dsCookie.Tables.Count == 0) return false;

                DataTable dtCookie = dsCookie.Tables[0];

                DB db = new DB();
                db.DBConnect();
                db.DBBeginTrans();

                foreach (DataRow drCookie in dtCookie.Rows)
                {
                    string sCookieGuid = drCookie["guid"].ToString();
                    string sCookiePrdGuid = drCookie["prdguid"].ToString();
                    int sCookieRuleID  = drCookie["ruleid"].ToString().ToInt();
                    decimal dCookieQuantity = drCookie["quantity"].ToString().ToDecimal();
                    string sCookieShareID = string.Empty;
                    if ( drCookie["shareid"] != DBNull.Value) sCookieShareID = drCookie["shareid"].ToString();

                    // search by product id and rule id of current user
                    strSql = "select guid, prdguid, ruleid, quantity, shareid from wn_shoppingcart where prdguid='" + sCookiePrdGuid + "' and ruleid=" + sCookieRuleID.ToString() + " and userguid='" + userGuid.ToString() + "'";

                    DataSet dsDatabase = db.DBQuery(strSql);

                    bool bMergeItem = false;

                    if (dsDatabase != null) 
                        if (dsDatabase.Tables.Count > 0 ) 
                            if (dsDatabase.Tables[0].Rows.Count > 0 ) bMergeItem = true;

                    if (bMergeItem)
                    {
                        // merge
                        DataRow drDatabase = dsDatabase.Tables[0].Rows[0];

                        // merge two product item together
                        string sDatabaseGuid = drDatabase["guid"].ToString();
                        string sDatabasePrdGuid = drDatabase["prdguid"].ToString();
                        int sDatabaseRuleID = drDatabase["ruleid"].ToString().ToInt();
                        decimal dDatabaseQuantity = drDatabase["quantity"].ToString().ToDecimal();
                        string sDatabaseShareID = string.Empty;
                        if (drDatabase["shareid"] != DBNull.Value) sDatabaseShareID = drDatabase["shareid"].ToString();

                        // add quantity together
                        decimal dNewQuantity = dCookieQuantity + dDatabaseQuantity;

                        // if both has share id, just keep the share id of database
                        // if database has not share id and cookie has shareid then keep cookie share ID
                        string sNewShareID = sDatabaseShareID;
                        if (sNewShareID == string.Empty && sCookieShareID != string.Empty) sNewShareID = sCookieShareID;

                        strSql = "update wn_shoppingcart set quantity = " + dNewQuantity.ToString();
                        if (sNewShareID != string.Empty)
                        {
                            strSql = strSql + ", shareID ='" + sNewShareID + "'";
                        }
                        strSql = strSql + " where guid='" + sDatabaseGuid + "'";
                        iAffectedRow = db.DBExecute(strSql);

                        // delete the shopping cart item of the cookie
                        strSql = "delete from wn_shoppingcart where guid='" + sCookieGuid + "'";
                        iAffectedRow = db.DBExecute(strSql);

                        // the shopcart cookie shoud be deleted. it is deleted at the end of the process   Jack Cao 2016-01-12
                        //// need to remove the merged id from cookie
                        //CookiesHelper cookie = new CookiesHelper();

                        //string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                        //string shopCartCookie = cookie.getCookie(keyShopCart);
                        //if (!string.IsNullOrEmpty(shopCartCookie))
                        //{
                        //    List<string> ids = shopCartCookie.Split(',').ToList<String>();
                        //    ids.Remove("'" + sCookieGuid + "'");
                        //    string sNewCartCookie = string.Empty;
                        //    foreach (var id in ids)
                        //    {
                        //        sNewCartCookie += id + ",";
                        //    }
                        //    cookie.createCookie(keyShopCart, sNewCartCookie.TrimEnd(','), 7);
                        //}
                    }
                    else
                    {
                        // do not merge just update the user iD
                        strSql = "update wn_shoppingcart set userguid='" + userGuid.ToString() + "' where guid ='" + sCookieGuid + "'";
                        iAffectedRow = db.DBExecute(strSql);
                    }

                }
                db.DBCommitTrans();
                db.DBDisconnect();

                // delete the shopping cart cookies
                CookiesHelper cookie = new CookiesHelper();
                string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                cookie.delCookie(keyShopCart);

                return true;
                
                //if (resu > 0)
                //{
                //    //string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                //    //CookiesHelper cookie = new CookiesHelper();
                //    //cookie.createCookie(keyShopCart, "", 0);
                //   
                //}
                //return false;
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return false;
        }
 
        /// <summary>
        /// Get Ship fee list by weight
        /// </summary>
        /// <param name="sWeight"></param>
        public DataTable GetShipFeeListByWeight(string sWeight, string sCountryID, string sZip)
        {
            try
            {
                decimal dWeight = 0;
                bool isDecimal = Decimal.TryParse(sWeight, out dWeight);
                int iWeight = 1;
                if (isDecimal)
                {
                    iWeight = (int)(Math.Round(dWeight, MidpointRounding.AwayFromZero));
                }
                if (iWeight <= 0)
                {
                    iWeight = 1;
                }

                // max weight is 70 for fosdick
                if (iWeight > 70)
                {
                    iWeight = 70;
                }

                int iCountryID = Int32.Parse(sCountryID);
                int iZone = GetZoneByZip(iCountryID, sZip);
                // select ship fee list
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select b.ShipMethod_ID, b.ShipMethod_Name, (a.ShipFee_Amount + a.ShipFee_SurCharge + a.ShipFee_SurCharge) as ShipFee_Total, b.ShipMethod_IsFree");
                sSql.Append(" from wn_ShipFee a");
                sSql.Append(" inner join wn_ShipMethod b on a.ShipMethod_ID = b.ShipMethod_ID");
                sSql.Append("    where a.ShipFee_Weight=" + iWeight.ToString());
                sSql.Append("      and a.Country_ID=" + sCountryID);
                sSql.Append("      and a.ShipFee_Zone=" + iZone.ToString());

                DataSet ds = DbHelperSQL.Query(sSql.ToString());
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return null;
        }

        /// <summary>
        /// Get Drop-Shiper Ship fee list by country, total proce and ship from
        /// </summary>
        /// <param name="sCountryID, sTotalPrice"></param>
        public DataTable GetDropShipperShipFeeList(string sCountryID, string sTotalPrice, int iShipFromID)
        {
            try
            {
                decimal dTotalPrice = 0;
                bool isDecimal = Decimal.TryParse(sTotalPrice, out dTotalPrice);
                int iCountryID = Int32.Parse(sCountryID);

                // select ship fee list
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select b.ShipMethod_ID, b.ShipMethod_Name ");
                sSql.Append(",case a.DropShipperShipFee_UseAmount when 1 then a.DropShipperShipFee_Amount else " + dTotalPrice.ToString() + "*a.DropShipperShipFee_Percent/100 end as ShipFee_Total");
                sSql.Append(",b.ShipMethod_IsFree ");
                sSql.Append("from wn_DropShipperShipFee a ");
                sSql.Append("cross join wn_ShipMethod b ");
                sSql.Append("inner join wn_ShipFrom2ShipMethod c on c.ShipMethod_ID = b.ShipMethod_ID ");
                sSql.Append("where a.Country_ID =" + sCountryID);
                sSql.Append("  and a.DropShipperShipFee_TotalPriceFrom <=" + dTotalPrice.ToString() + " and a.DropShipperShipFee_TotalPriceTo >" +  dTotalPrice.ToString()) ;
                sSql.Append("  and b.ShipMethod_ShipToCountryID=" + sCountryID);
                sSql.Append("  and c.ShipFrom_ID =" + iShipFromID.ToString());

                DataSet ds = DbHelperSQL.Query(sSql.ToString());
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return null;
        }


        /// <summary>
        /// Get Drop-Shiper flat Ship fee by country and total price
        /// </summary>
        /// <param name="sCountryID, sTotalPrice"></param>
        public decimal GetDropShipperFlatShipFee(string sCountryID, string sTotalPrice)
        {
            decimal dShipFee = 0;
            try
            {
                decimal dTotalPrice = 0;
                bool isDecimal = Decimal.TryParse(sTotalPrice, out dTotalPrice);
                int iCountryID = Int32.Parse(sCountryID);

                // select ship fee 
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select case a.DropShipperShipFee_UseAmount when 1 then a.DropShipperShipFee_Amount else " + dTotalPrice.ToString() + "*a.DropShipperShipFee_Percent/100 end as ShipFee_Total ");
                sSql.Append("from wn_DropShipperShipFee a ");
                sSql.Append("where a.Country_ID =" + sCountryID);
                sSql.Append("  and a.DropShipperShipFee_TotalPriceFrom <=" + dTotalPrice.ToString() + " and a.DropShipperShipFee_TotalPriceTo >" + dTotalPrice.ToString());
 
                DataSet ds = DbHelperSQL.Query(sSql.ToString());
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dShipFee = dt.Rows[0][0].ToString().ToDecimal();
                    }
                }
                return dShipFee;
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return dShipFee;
        }

        /// <summary>
        /// Get province tax
        /// </summary>
        public DataTable GetProvinceTax(string sCountryID, string sProvinceID)
        {
            try
            {
                int iCountryID = Int32.Parse(sCountryID);
                int iProvinceID = Int32.Parse(sProvinceID);

                // USA there is no tax
                if (iCountryID == (int)(ConfigParamter.CountryID.USA)) return null;

                StringBuilder sSql = new StringBuilder();
                sSql.Append("select ProvinceTax_ID, ProvinceTax_GST, ProvinceTax_HST, ProvinceTax_QST");
                sSql.Append(" from wn_ProvinceTax");
                sSql.Append("    where Country_ID=" + iCountryID.ToString());
                sSql.Append("      and Province_ID=" + iProvinceID.ToString());

                DataSet ds = DbHelperSQL.Query(sSql.ToString());
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return null;
        }

        /// <summary>
        /// Get Product Ship to Country Free
        /// </summary>
        public int GetProductShipToCountryFree(int iCountryID, int iRuleID)
        {
            int iShipToCountryFree = 0;   // not free
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select b.proid, b.prosku,  a.ProductShipToCountry_IsFree from wn_ProductShipToCountry a");
                sSql.Append(" inner join wn_prorules b on b.proid = a.prdGuid and b.userid = a.userGuid");
                sSql.Append(" where a.Country_ID = " + iCountryID.ToString() );
                sSql.Append(" and b.id =" + iRuleID.ToString());

                DataSet ds = DbHelperSQL.Query(sSql.ToString());
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        iShipToCountryFree = dt.Rows[0]["ProductShipToCountry_IsFree"].ToString().ToInt();
                    }
                }
                return iShipToCountryFree;
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }
            return iShipToCountryFree;
        }



        /// <summary>
        /// Get zone by zip
        /// </summary>
        public int GetZoneByZip(int iCountryID, string sZip)
        {
 
            int iZone = 6;  // default fosdick ship to USA Zone#
            if (iCountryID == (int)(ConfigParamter.CountryID.USA))
            {
                // USA always use Zone 6
                iZone = 6;
                return iZone;
            }

            // select zone by zip
            // first 3 character is the zip area
            string sZoneArea = sZip.Substring(0, 3);

            StringBuilder sSql = new StringBuilder();
            sSql.Append("select ZipZone_Zone  ");
            sSql.Append(" from wn_ZipZone");
            sSql.Append("    where Country_ID=" + iCountryID.ToString());
            sSql.Append("       and ZipZone_Zip='" + sZoneArea + "'");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if ( dt != null && dt.Rows.Count > 0) {
                    DataRow dr = dt.Rows[0];
                    iZone = dr["ZipZone_Zone"].ToString().ToInt();
                }
            }
            return iZone;
        }

        /// <summary>
        /// set ship method of product in a shopping cart 
        /// </summary>
        public bool SetShipMethod(string cartGuid, string prdGuid, int iShipMethodID, string sShipFee)
        {
            try
            {
                string strSql = "update wn_shoppingcart set ShipMethod_ID=" + iShipMethodID.ToString() + ", ShipFee=" + sShipFee + " where guid='" + cartGuid + "' and prdguid='" + prdGuid + "'";
                int resu = DbHelperSQL.ExecuteSql(strSql);
                if (resu > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);

            }
            return false;

        }
        
        #endregion  ExtensionMethod
    }
}
