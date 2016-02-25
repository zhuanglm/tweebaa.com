﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
	/// <summary>
	/// 省
	/// </summary>
	public partial class ProvinceDataMgr
	{
        public ProvinceDataMgr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
	     	return DbHelperSQL.GetMaxID("ProID", "wn_Province"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wn_Province");
			strSql.Append(" where ProID=@ProID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Twee.Model.Province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wn_Province(");
			strSql.Append("ProName,ProSort,ProRemark)");
			strSql.Append(" values (");
			strSql.Append("@ProName,@ProSort,@ProRemark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProSort", SqlDbType.Int,4),
					new SqlParameter("@ProRemark", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ProName;
			parameters[1].Value = model.ProSort;
			parameters[2].Value = model.ProRemark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Twee.Model.Province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wn_Province set ");
			strSql.Append("ProName=@ProName,");
			strSql.Append("ProSort=@ProSort,");
			strSql.Append("ProRemark=@ProRemark");
			strSql.Append(" where ProID=@ProID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProSort", SqlDbType.Int,4),
					new SqlParameter("@ProRemark", SqlDbType.NVarChar,50),
					new SqlParameter("@ProID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProName;
			parameters[1].Value = model.ProSort;
			parameters[2].Value = model.ProRemark;
			parameters[3].Value = model.ProID;

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
		public bool Delete(int ProID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_Province ");
			strSql.Append(" where ProID=@ProID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProID;

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
		public bool DeleteList(string ProIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_Province ");
			strSql.Append(" where ProID in ("+ProIDlist + ")  ");
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
		public Twee.Model.Province GetModel(int ProID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProID,ProName,ProSort,ProRemark from wn_Province ");
			strSql.Append(" where ProID=@ProID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProID;

			Twee.Model.Province model=new Twee.Model.Province();
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
		public Twee.Model.Province DataRowToModel(DataRow row)
		{
			Twee.Model.Province model=new Twee.Model.Province();
			if (row != null)
			{
				if(row["ProID"]!=null && row["ProID"].ToString()!="")
				{
					model.ProID=int.Parse(row["ProID"].ToString());
				}
				if(row["ProName"]!=null)
				{
					model.ProName=row["ProName"].ToString();
				}
				if(row["ProSort"]!=null && row["ProSort"].ToString()!="")
				{
					model.ProSort=int.Parse(row["ProSort"].ToString());
				}
				if(row["ProRemark"]!=null)
				{
					model.ProRemark=row["ProRemark"].ToString();
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
			strSql.Append("select ProID,ProName,ProSort,ProRemark ");
			strSql.Append(" FROM wn_Province ");
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
			strSql.Append(" ProID,ProName,ProSort,ProRemark ");
			strSql.Append(" FROM wn_Province ");
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
			strSql.Append("select count(1) FROM wn_Province ");
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
				strSql.Append("order by T.ProID desc");
			}
			strSql.Append(")AS Row, T.*  from wn_Province T ");
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
			parameters[0].Value = "wn_Province";
			parameters[1].Value = "ProID";
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

