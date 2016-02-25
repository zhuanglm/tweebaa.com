using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;
using Twee.Model;

namespace Twee.DataMgr
{  
    [Serializable]
    public partial class SupplyInforDataMgr
    {       
        public SupplyInforDataMgr()
		{}
        
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wn_supplyinfor");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Supplyinfor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wn_supplyinfor(");
            strSql.Append("guid,prtguid,typelist,companyname,companyurl,industry)");
			strSql.Append(" values (");
            strSql.Append("@guid,@prtguid,@typelist,@companyname,@companyurl,@industry)");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@typelist",SqlDbType.NVarChar,50),
                    new SqlParameter("@companyname", SqlDbType.NVarChar,50),
                    new SqlParameter("@companyurl", SqlDbType.NVarChar,50),
                    new SqlParameter("@industry", SqlDbType.NVarChar,50)   
                                        };
			parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.prtguid;
            parameters[2].Value = model.typelist;
            parameters[3].Value = model.companyname;
            parameters[4].Value = model.companyurl;
            parameters[5].Value = model.industry;

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
		public bool Update(Supplyinfor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wn_supplyinfor set ");
			strSql.Append("guid=@guid");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.guid;

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
			strSql.Append("delete from wn_supplyinfor ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_supplyinfor ");
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
		public Supplyinfor GetModel(Guid guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 guid from wn_supplyinfor ");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = guid;

			Supplyinfor model=new Supplyinfor();
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
		public Supplyinfor DataRowToModel(DataRow row)
		{
			Supplyinfor model=new Supplyinfor();
			if (row != null)
			{
				if(row["guid"]!=null && row["guid"].ToString()!="")
				{
					model.guid= new Guid(row["guid"].ToString());
				}
                if (row["companyname"] != null && row["companyname"].ToString() != "")
                {
                    model.companyname = row["companyname"].ToString();
                }
                if (row["companyurl"] != null && row["companyurl"].ToString() != "")
                {
                    model.companyurl = row["companyurl"].ToString();
                }
                if (row["industry"] != null && row["industry"].ToString() != "")
                {
                    model.industry = row["industry"].ToString();
                }
                if (row["typelist"] != null && row["typelist"].ToString() != "")
                {
                    model.typelist = row["typelist"].ToString();
                }
                if (row["prtguid"] != null && row["prtguid"].ToString() != "")
                {
                    model.prtguid = new Guid(row["guid"].ToString());
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = row["edttime"].ToString().ToDateTime();
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
			strSql.Append("select guid ");
			strSql.Append(" FROM wn_supplyinfor ");
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
			strSql.Append(" guid ");
			strSql.Append(" FROM wn_supplyinfor ");
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
			strSql.Append("select count(1) FROM wn_supplyinfor ");
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
			strSql.Append(")AS Row, T.*  from wn_supplyinfor T ");
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
			parameters[0].Value = "wn_supplyinfor";
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Supplyinfor GetPrdSupply(Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from wn_supplyinfor ");
            strSql.Append(" where prtGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = prdGuid;

            Supplyinfor model = new Supplyinfor();
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


		#endregion  ExtensionMethod
    }
}
