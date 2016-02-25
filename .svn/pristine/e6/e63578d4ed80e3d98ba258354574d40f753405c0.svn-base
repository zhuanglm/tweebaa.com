using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
	/// <summary>
	/// 城市
	/// </summary>
	public partial class CityDataMgr
	{
        public CityDataMgr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CityID", "City"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CityID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from City");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.Int,4)
			};
			parameters[0].Value = CityID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Twee.Model.City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into City(");
			strSql.Append("CityName,ProID,CitySort)");
			strSql.Append(" values (");
			strSql.Append("@CityName,@ProID,@CitySort)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@CitySort", SqlDbType.Int,4)};
			parameters[0].Value = model.CityName;
			parameters[1].Value = model.ProID;
			parameters[2].Value = model.CitySort;

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
		public bool Update(Twee.Model.City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update City set ");
			strSql.Append("CityName=@CityName,");
			strSql.Append("ProID=@ProID,");
			strSql.Append("CitySort=@CitySort");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProID", SqlDbType.Int,4),
					new SqlParameter("@CitySort", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4)};
			parameters[0].Value = model.CityName;
			parameters[1].Value = model.ProID;
			parameters[2].Value = model.CitySort;
			parameters[3].Value = model.CityID;

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
		public bool Delete(int CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from City ");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.Int,4)
			};
			parameters[0].Value = CityID;

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
		public bool DeleteList(string CityIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from City ");
			strSql.Append(" where CityID in ("+CityIDlist + ")  ");
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
		public Twee.Model.City GetModel(int CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CityID,CityName,ProID,CitySort from City ");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.Int,4)
			};
			parameters[0].Value = CityID;

			Twee.Model.City model=new Twee.Model.City();
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
		public Twee.Model.City DataRowToModel(DataRow row)
		{
			Twee.Model.City model=new Twee.Model.City();
			if (row != null)
			{
				if(row["CityID"]!=null && row["CityID"].ToString()!="")
				{
					model.CityID=int.Parse(row["CityID"].ToString());
				}
				if(row["CityName"]!=null)
				{
					model.CityName=row["CityName"].ToString();
				}
				if(row["ProID"]!=null && row["ProID"].ToString()!="")
				{
					model.ProID=int.Parse(row["ProID"].ToString());
				}
				if(row["CitySort"]!=null && row["CitySort"].ToString()!="")
				{
					model.CitySort=int.Parse(row["CitySort"].ToString());
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
			strSql.Append("select CityID,CityName,ProID,CitySort ");
			strSql.Append(" FROM wn_City ");
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
			strSql.Append(" CityID,CityName,ProID,CitySort ");
			strSql.Append(" FROM City ");
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
			strSql.Append("select count(1) FROM City ");
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
				strSql.Append("order by T.CityID desc");
			}
			strSql.Append(")AS Row, T.*  from City T ");
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
			parameters[0].Value = "City";
			parameters[1].Value = "CityID";
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

