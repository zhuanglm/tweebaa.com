using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;

namespace Twee.DataMgr
{
    public class VistLogDataMgr
    {
        #region  BasicMethod

        /// <summary>
		/// Get the today's visit count of a user for a specified product
		/// </summary>
        public int GetUserProductTodayVisitCount(string sUserGuid, string sPrdGuid)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Clear();
            sSql.Append("select count(*) from wn_VistLog ");
            sSql.Append(" where userId = '" + sUserGuid + "'");
            sSql.Append("   and prdID = '" + sPrdGuid + "'");
            sSql.Append("   and isBig30Second=1 ");
            sSql.Append("   and datediff(dd,getdate(),addTime)=0");
            int intUserProductTodayVisitCount = DbHelperSQL.QueryCount(sSql.ToString());
            return intUserProductTodayVisitCount;
        }        
        
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Twee.Model.VistLog model)
		{
            
			StringBuilder strSql=new StringBuilder();
            DB db = new DB();
            db.DBConnect();
            db.DBBeginTrans();

            // insert visit log
  			strSql.Append("insert into wn_VistLog(");
            strSql.Append("userId,prdID,addTime,isBig30Second)");
            strSql.Append(" values(") ;
            strSql.Append("'" + model.userId + "',");
            strSql.Append("'" + model.prdID  + "',");
            strSql.Append(" getdate(),");
            strSql.Append( model.isBig30Second? "1":"0");
            strSql.Append(")");
            
            db.DBExecute(strSql.ToString());

            // get the identity;
            int iNewVisitLogID = db.DBGetIdentity();
 
            // ------------------------------------------------------
            // --如果每天浏览了10个产品并且保持30秒以上，奖励分享积分5分
            // --浏览积分类型：5；购物积分类型：4
            //-------------------------------------------------------
            // get visit count in this day
            strSql.Clear();
            strSql.Append("select count( distinct prdID) from wn_VistLog "); 
            strSql.Append(" where userId = '" + model.userId + "'"); 
            strSql.Append("   and isBig30Second=1 "); 
            strSql.Append("   and datediff(dd,getdate(),addTime)=0");
            int intVisitCountToday = db.DBQueryCount(strSql.ToString());

            // check if user has already get the browser reward point
            strSql.Clear();
            strSql.Append("select COUNT(*) from wn_point ");
            strSql.Append(" where userid='" + model.userId + "'"); 
            strSql.Append(" and remark='BONUS! Browsed 10 products in 1 day'");
            strSql.Append(" and datediff(dd,getdate(),addTime)=0 ");
            int intRewardCountToday = db.DBQueryCount(strSql.ToString());
          
            if ( intVisitCountToday == 10 && intRewardCountToday ==0 ) {

                // +5
                strSql.Clear();
                strSql.Append("insert into wn_point values(3,'" + model.userId + "',null,null,5,'BONUS! Browsed 10 products in 1 day',GETDATE(),1)");
                db.DBExecute(strSql.ToString());

                // update user grade
                strSql.Clear();
                strSql.Append("update wn_userGrade set shareintegral=shareintegral+5, ");
                strSql.Append(" sharegrade=( select top 1 grade from dbo.wn_sharegradeparam where shareintegral+5>=integral order by grade desc ) ");
                strSql.Append(" where userguid='" + model.userId + "'");
                db.DBExecute(strSql.ToString());
            }

            db.DBCommitTrans();
            db.DBDisconnect();
/*
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wn_VistLog(");
            strSql.Append("userId,prdID,addTime,isBig30Second)");
			strSql.Append(" values (");
            strSql.Append("@userId,@prdID,@addTime,@isBig30Second)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.NVarChar,50),
					new SqlParameter("@prdID", SqlDbType.NVarChar,50),
					new SqlParameter("@addTime", SqlDbType.Date,3),
                    new SqlParameter("@isBig30Second", SqlDbType.Bit)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.prdID;
			parameters[2].Value = model.addTime;
            parameters[3].Value = model.isBig30Second;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
 */
            return iNewVisitLogID;
		}

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Twee.Model.VistLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wn_VistLog set ");
			strSql.Append("userId=@userId,");
			strSql.Append("prdID=@prdID,");
			strSql.Append("addTime=@addTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.NVarChar,50),
					new SqlParameter("@prdID", SqlDbType.NVarChar,50),
					new SqlParameter("@addTime", SqlDbType.Date,3),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.prdID;
			parameters[2].Value = model.addTime;
			parameters[3].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_VistLog ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_VistLog ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Twee.Model.VistLog GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,userId,prdID,addTime from wn_VistLog ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Twee.Model.VistLog model=new Twee.Model.VistLog();
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
		public Twee.Model.VistLog DataRowToModel(DataRow row)
		{
			Twee.Model.VistLog model=new Twee.Model.VistLog();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["userId"]!=null)
				{
					model.userId=row["userId"].ToString();
				}
				if(row["prdID"]!=null)
				{
					model.prdID=row["prdID"].ToString();
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
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
			strSql.Append("select id,userId,prdID,addTime ");
			strSql.Append(" FROM wn_VistLog ");
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
			strSql.Append(" id,userId,prdID,addTime ");
			strSql.Append(" FROM wn_VistLog ");
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
			strSql.Append("select count(1) FROM wn_VistLog ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wn_VistLog T ");
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
			parameters[0].Value = "wn_VistLog";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod


		#region  ExtensionMethod


     
      

		#endregion  ExtensionMethod
    }
}
