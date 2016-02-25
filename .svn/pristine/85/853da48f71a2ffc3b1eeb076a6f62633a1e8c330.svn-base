using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using Twee.Comm;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:mgrProStatusLogDataMgr
    /// </summary>
    public partial class mgrProStatusLogDataMgr
    {
        public mgrProStatusLogDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_mgrProStatusLog");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.mgrProStatusLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_mgrProStatusLog(");
            strSql.Append("proid,adminid,statusfrom,statusto,reasonid,exreason,passtime)");
            strSql.Append(" values (");
            strSql.Append("@proid,@adminid,@statusfrom,@statusto,@reasonid,@exreason,@passtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@adminid", SqlDbType.NVarChar,50),
					new SqlParameter("@statusfrom", SqlDbType.Int,4),
					new SqlParameter("@statusto", SqlDbType.Int,4),
					new SqlParameter("@reasonid", SqlDbType.Int,4),
					new SqlParameter("@exreason", SqlDbType.NVarChar,500),
					new SqlParameter("@passtime", SqlDbType.DateTime)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.adminid;
            parameters[2].Value = model.statusfrom;
            parameters[3].Value = model.statusto;
            parameters[4].Value = model.reasonid;
            parameters[5].Value = model.exreason;
            parameters[6].Value = model.passtime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Twee.Model.mgrProStatusLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_mgrProStatusLog set ");
            strSql.Append("proid=@proid,");
            strSql.Append("adminid=@adminid,");
            strSql.Append("statusfrom=@statusfrom,");
            strSql.Append("statusto=@statusto,");
            strSql.Append("reasonid=@reasonid,");
            strSql.Append("exreason=@exreason,");
            strSql.Append("passtime=@passtime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@adminid", SqlDbType.NVarChar,50),
					new SqlParameter("@statusfrom", SqlDbType.Int,4),
					new SqlParameter("@statusto", SqlDbType.Int,4),
					new SqlParameter("@reasonid", SqlDbType.Int,4),
					new SqlParameter("@exreason", SqlDbType.NVarChar,500),
					new SqlParameter("@passtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.adminid;
            parameters[2].Value = model.statusfrom;
            parameters[3].Value = model.statusto;
            parameters[4].Value = model.reasonid;
            parameters[5].Value = model.exreason;
            parameters[6].Value = model.passtime;
            parameters[7].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_mgrProStatusLog ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_mgrProStatusLog ");
            strSql.Append(" where id in (" + idlist + ")  ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.mgrProStatusLog GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,proid,adminid,statusfrom,statusto,reasonid,exreason,passtime from wn_mgrProStatusLog ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.mgrProStatusLog model = new Twee.Model.mgrProStatusLog();
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
        public Twee.Model.mgrProStatusLog DataRowToModel(DataRow row)
        {
            Twee.Model.mgrProStatusLog model = new Twee.Model.mgrProStatusLog();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["proid"] != null)
                {
                    model.proid = row["proid"].ToString();
                }
                if (row["adminid"] != null)
                {
                    model.adminid = row["adminid"].ToString();
                }
                if (row["statusfrom"] != null && row["statusfrom"].ToString() != "")
                {
                    model.statusfrom = int.Parse(row["statusfrom"].ToString());
                }
                if (row["statusto"] != null && row["statusto"].ToString() != "")
                {
                    model.statusto = int.Parse(row["statusto"].ToString());
                }
                if (row["reasonid"] != null && row["reasonid"].ToString() != "")
                {
                    model.reasonid = int.Parse(row["reasonid"].ToString());
                }
                if (row["exreason"] != null)
                {
                    model.exreason = row["exreason"].ToString();
                }
                if (row["passtime"] != null && row["passtime"].ToString() != "")
                {
                    model.passtime = DateTime.Parse(row["passtime"].ToString());
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
            strSql.Append("select id,proid,adminid,statusfrom,statusto,reasonid,exreason,passtime ");
            strSql.Append(" FROM wn_mgrProStatusLog ");
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
            strSql.Append(" id,proid,adminid,statusfrom,statusto,reasonid,exreason,passtime ");
            strSql.Append(" FROM wn_mgrProStatusLog ");
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
            strSql.Append("select count(1) FROM wn_mgrProStatusLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wn_mgrProStatusLog T ");
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
            parameters[0].Value = "wn_mgrProStatusLog";
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

