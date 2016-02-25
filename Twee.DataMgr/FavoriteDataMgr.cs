﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Data;

namespace Twee.DataMgr
{
    public class FavoriteDataMgr
    {
        public FavoriteDataMgr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录(修改过)
		/// </summary>
		public bool Exists(Guid prtguid,Guid userguid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wn_favorite");
            strSql.Append(" where prtguid=@prtguid and userguid=@userguid ");
			SqlParameter[] parameters = {
				new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16)	,
                new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = prtguid;
            parameters[1].Value = userguid;
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public bool CollageFavoriteExists(int iDesignID, Guid userguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_favorite");
            strSql.Append(" where CollageDesign_ID=@CollageDesign_ID and userguid=@userguid ");
            SqlParameter[] parameters = {
				new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4)	,
                new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = iDesignID;
            parameters[1].Value = userguid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 增加一条CollageDesign数据
        /// </summary>
        public bool Add_CollageDesign_Favorite(Twee.Model.Favorite model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_favorite(");
            strSql.Append("guid,userguid,edttime,sourcetype,CollageDesign_ID)");
            strSql.Append(" values (");
            strSql.Append("@guid,@userguid,@edttime,@sourcetype,@CollageDesign_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@edttime", SqlDbType.DateTime),
                        new SqlParameter("@sourcetype", SqlDbType.TinyInt,2),
                        new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.userguid;
            parameters[2].Value = model.edttime;

            parameters[3].Value = model.Sourcetype;
            parameters[4].Value = model.CollageDesign_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            try
            {
                /*
                 * Add by Long 2015/12/09
                 * 做数据同步用
                 */
                if (Twee.Comm.CommUtil.IsDALSync())
                {
                    //如果是主服务器，则使用web service 异步更新Slave DB
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = strSql.ToString();
                    foreach (SqlParameter para in parameters)
                    {
                        cmd.Parameters.Add(para);
                    }
                    // cmd.Parameters. parameters;

                    string strSQL = Twee.Comm.CommUtil.ConvertCommandParamatersToLiteralValues(cmd);
                    DbHelperSQL.SaveQueryString(strSQL);
                }
                
            }
            catch (Exception ee)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(ee);

            }

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
		/// 增加一条数据
		/// </summary>
		public bool Add(Twee.Model.Favorite model)
		{
            
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wn_favorite(");
			strSql.Append("guid,userguid,prtguid,edttime)");
			strSql.Append(" values (");
			strSql.Append("@guid,@userguid,@prtguid,@edttime)");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@edttime", SqlDbType.DateTime)};
			parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.userguid;
			parameters[2].Value = model.prtguid;
			parameters[3].Value = model.edttime;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Twee.Model.Favorite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wn_favorite set ");
			strSql.Append("userguid=@userguid,");
			strSql.Append("prtguid=@prtguid,");
			strSql.Append("edttime=@edttime");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.userguid;
			parameters[1].Value = model.prtguid;
			parameters[2].Value = model.edttime;
			parameters[3].Value = model.guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_favorite ");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool DeleteByUserPrd(Guid userGuid, Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_favorite ");
            strSql.Append(" where prtguid=@prdGuid and userguid=@userGuid");
            SqlParameter[] parameters = {
					new SqlParameter("@userGuid", SqlDbType.UniqueIdentifier,16), 
                    new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16) };
            parameters[0].Value = userGuid;
            parameters[1].Value = prdGuid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            // always return true no matter if the how many records are deleted.
            return true;
        }

        /// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_favorite ");
			strSql.Append(" where guid in ("+guidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public Twee.Model.Favorite GetModel(Guid guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 guid,userguid,prtguid,edttime from wn_favorite ");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = guid;

			Twee.Model.Favorite model=new Twee.Model.Favorite();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Twee.Model.Favorite DataRowToModel(DataRow row)
		{
			Twee.Model.Favorite model=new Twee.Model.Favorite();
			if (row != null)
			{
				if(row["guid"]!=null && row["guid"].ToString()!="")
				{
					model.guid= new Guid(row["guid"].ToString());
				}
				if(row["userguid"]!=null && row["userguid"].ToString()!="")
				{
					model.userguid= new Guid(row["userguid"].ToString());
				}
				if(row["prtguid"]!=null && row["prtguid"].ToString()!="")
				{
					model.prtguid= new Guid(row["prtguid"].ToString());
				}
				if(row["edttime"]!=null && row["edttime"].ToString()!="")
				{
					model.edttime=DateTime.Parse(row["edttime"].ToString());
				}
                //以下为扩展字段
                if (row["name"] != null && row["name"].ToString() != "")
                {
                    model.name = row["name"].ToString();
                }
                if (row["fileurl"] != null && row["fileurl"].ToString() != "")
                {
                    model.fileurl = row["fileurl"].ToString();
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = row["estimateprice"].ToString().ToDecimal();
                }
                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = row["wnstat"].ToString();
                }
                if (row["reviewCount"] != null && row["reviewCount"].ToString() != "")
                {
                    model.reviewCount = row["reviewCount"].ToString().ToInt();
                }

                if (row["saleCount"] != null && row["saleCount"].ToString() != "")
                {
                    model.saleCount = row["saleCount"].ToString().ToInt();
                }
                if (row["summoney"] != null && row["summoney"].ToString() != "")
                {
                    model.summoney = row["summoney"].ToString().ToInt();
                }
                if (row["reviewCount"] != null && row["reviewCount"].ToString() != "")
                {
                    model.presaleendtime = row["presaleendtime"].ToString().ToDateTime();
                }
                
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select guid,userguid,prtguid,edttime ");
			strSql.Append(" FROM wn_favorite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" guid,userguid,prtguid,edttime ");
			strSql.Append(" FROM wn_favorite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wn_favorite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.guid desc");
			}
			strSql.Append(")AS Row, T.*  from wn_favorite T ");
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
			parameters[0].Value = "wn_favorite";
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
        /// <param name="endIndex"记录号></param>
       /// <returns></returns>
        public DataTable GetMyCollection(string userID, string state, string orderby, string beginTime, string endTime, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TT.[guid],TT.[userguid],TT.[prtguid],TT.[edttime],r.[name],r.[estimateprice],r.[wnstat],f.fileurl,rev.reviewCount FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.edttime desc");
            }
            strSql.Append(")AS Row, T.*  from wn_favorite T where 1=1 ");

            if (!string.IsNullOrEmpty(beginTime))
            {
                strSql.Append(" and edttime >= '" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and edttime <= '" + endTime + "'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }         
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prtguid= f.prtguid ");
            strSql.Append(" left join (select prdguid,name,estimateprice,wnstat  from [dbo].[wn_prd] ) r on TT.prtguid=r.prdguid ");
            strSql.Append(" left join (select prtguid,COUNT(*) reviewCount from [dbo].[wn_review]  group by prtguid ) rev on TT.prtguid=rev.prtguid ");
            strSql.Append(" where 1=1 ");
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }



        public DataTable GetMyCollageCollection2(string userID, string state, string orderby, string beginTime, string endTime, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.edttime desc");
            }
            strSql.Append(")AS Row, T.*,b.CollageDesing_Title,b.CollageDesign_ThumbnailFileName,b.CollageDesign_Inspiration  from wn_favorite T left join  wn_CollageDesign b on T.CollageDesign_ID=b.CollageDesign_ID  where sourcetype=2 ");

            if (!string.IsNullOrEmpty(beginTime))
            {
                strSql.Append(" and edttime >= '" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and edttime <= '" + endTime + "'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }
            strSql.Append(" ) TT");
            //strSql.Append(" ");
                /*
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prtguid= f.prtguid ");
            strSql.Append(" left join (select prdguid,name,estimateprice,wnstat,presaleendtime,presaleforward, txtjj from [dbo].[wn_prd] ) r on TT.prtguid=r.prdguid ");
            strSql.Append(" left join (select prtguid,COUNT(*) reviewCount from [dbo].[wn_review]  group by prtguid ) rev on TT.prtguid=rev.prtguid ");

            strSql.Append(" left join (select distinct b.prdGuid,c.saleCount from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) saleCount from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on r.prdGuid=s.prdGuid ");
            */

            strSql.Append(" where 1=1 ");
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
        /// <summary>
        /// 获取会员中心我的收藏列表
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
            StringBuilder strSql = new StringBuilder();


            /*
            strSql.Append("SELECT  TT.[guid],TT.[userguid],TT.[prtguid],TT.[edttime],r.[name],r.[estimateprice],r.[wnstat], r.txtjj, f.fileurl,rev.reviewCount,s.saleCount,r.[estimateprice]*s.saleCount as summoney,r.[presaleendtime], DateDiff(Day, getdate(), r.[presaleendtime]) as presaleendday,  r.presaleforward, x.MinFinalSalePrice FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.edttime desc");
            }
            strSql.Append(")AS Row, T.*  from wn_favorite T where 1=1 ");

            if (!string.IsNullOrEmpty(beginTime))
            {
                string sBeginTime = CommUtil.ToDBDateFormat(beginTime);
                strSql.Append(" and edttime >= '" + sBeginTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                strSql.Append(" and edttime <= '" + sEndTime + " 23:59'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }

            if (!string.IsNullOrEmpty(state))
            {
                strSql.Append(" and prtguid in (select prdGuid from wn_prd where wnstat = " + state + ")");
            }


            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prtguid= f.prtguid ");
            strSql.Append(" left join (select prdguid,name,estimateprice,wnstat,presaleendtime,presaleforward, txtjj from [dbo].[wn_prd] ) r on TT.prtguid=r.prdguid ");
            strSql.Append(" left join (select prtguid,COUNT(*) reviewCount from [dbo].[wn_review]  group by prtguid ) rev on TT.prtguid=rev.prtguid ");

            strSql.Append(" left join (select distinct b.prdGuid,c.saleCount from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) saleCount from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on r.prdGuid=s.prdGuid ");
            strSql.Append(" left join vw_ProductMinFinalSalePrice x on x.prdGuid = TT.prtguid");

            strSql.Append(" where 1=1 ");
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
             * */
            ////change to View (vw_MyFavorite) As the sorting doesn't work by Long
            strSql.Append("select * from (");
            strSql.Append("SELECT ROW_NUMBER() OVER (order by T.edttime desc) AS Row, T.*  from vw_MyFavorite T where 1=1 ");
            if (!string.IsNullOrEmpty(beginTime))
            {
                string sBeginTime = CommUtil.ToDBDateFormat(beginTime);
                strSql.Append(" and edttime >= '" + sBeginTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                strSql.Append(" and edttime <= '" + sEndTime + " 23:59'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }
            strSql.AppendFormat(" ) As TT where  TT.Row between {0} and {1}", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        /// <summary>
        /// 获取会员中心我的收藏总数
        /// </summary>        
        public int GetMyCollageCollectionCount(string userID, string state, string beginTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from  wn_favorite f left join wn_CollageDesign p on f.CollageDesign_ID=p.CollageDesign_ID  where sourcetype=2 ");

            if (!string.IsNullOrEmpty(beginTime))
            {
                strSql.Append(" and f.edttime >= '" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and f.edttime <= '" + endTime + "'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and f.userguid = '" + userID + "'");
            }
            /*
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and p.wnstat = '" + state + "'");
            }
             * */
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().ToInt();
            }
            return 0;

        }

        /// <summary>
        /// 获取会员中心我的收藏总数
        /// </summary>        
        public int GetMyCollectionCount(string userID, string state,  string beginTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from  wn_favorite f left join wn_prd p on f.prtguid=p.prdGuid  where 1=1 ");         
          
            if (!string.IsNullOrEmpty(beginTime))
            {
                strSql.Append(" and f.edttime >= '" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and f.edttime <= '" + endTime + "'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and f.userguid = '" + userID + "'");
            }
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and p.wnstat = '" + state + "'");
            }          
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().ToInt();
            }
            return 0;

        }

        /// <summary>
        /// 获取会员中心我的收藏（预售产品）
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="state">产品状态</param>
        /// <param name="orderby">排序调价</param>
        /// <param name="beginTime">收藏开始时间</param>
        /// <param name="endTime">收藏结束时间</param>
        /// <param name="startIndex">记录号</param>
        /// <param name="endIndex"记录号></param>
        /// <returns></returns>
        public DataTable GetMyCollectionPresale(string userID, string state, string orderby, string beginTime, string endTime, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TT.[guid],TT.[userguid],TT.[prtguid],TT.[edttime],r.[name],r.[estimateprice],r.[wnstat],f.fileurl FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.edttime desc");
            }
            strSql.Append(")AS Row, T.*  from wn_favorite T where 1=1 ");

            if (!string.IsNullOrEmpty(beginTime))
            {
                strSql.Append(" and edttime >= '" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and edttime <= '" + endTime + "'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prtguid= f.prtguid ");
            strSql.Append(" left join (select prdguid,name,estimateprice  from [dbo].[wn_prd] ) r on TT.prtguid=r.prdguid ");
            strSql.Append(" where 1=1 ");
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        #endregion 

		#endregion  ExtensionMethod
    }
}
