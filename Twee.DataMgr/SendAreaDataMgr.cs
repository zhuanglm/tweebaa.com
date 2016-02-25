using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class SendAreaDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid areaGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_sendArea");
            strSql.Append(" where areaGuid=@areaGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = areaGuid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.SendArea model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_sendArea(");
            strSql.Append("areaGuid,areaName,remarkTxt)");
            strSql.Append(" values (");
            strSql.Append("@areaGuid,@areaName,@remarkTxt)");
            SqlParameter[] parameters = {
					new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@areaName", SqlDbType.NVarChar,50),
					new SqlParameter("@remarkTxt", SqlDbType.NVarChar,500)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.areaName;
            parameters[2].Value = model.remarkTxt;

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
        public bool Update(Twee.Model.SendArea model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_sendArea set ");
            strSql.Append("areaName=@areaName,");
            strSql.Append("remarkTxt=@remarkTxt");
            strSql.Append(" where areaGuid=@areaGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaName", SqlDbType.NVarChar,50),
					new SqlParameter("@remarkTxt", SqlDbType.NVarChar,500),
					new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.areaName;
            parameters[1].Value = model.remarkTxt;
            parameters[2].Value = model.areaGuid;

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
        public bool Delete(Guid areaGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_sendArea ");
            strSql.Append(" where areaGuid=@areaGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = areaGuid;

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
        public bool DeleteList(string areaGuidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_sendArea ");
            strSql.Append(" where areaGuid in (" + areaGuidlist + ")  ");
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
        public Twee.Model.SendArea GetModel(Guid areaGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 areaGuid,areaName,remarkTxt from wn_sendArea ");
            strSql.Append(" where areaGuid=@areaGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = areaGuid;

            Twee.Model.SendArea model = new Twee.Model.SendArea();
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
        public Twee.Model.SendArea DataRowToModel(DataRow row)
        {
            Twee.Model.SendArea model = new Twee.Model.SendArea();
            if (row != null)
            {
                if (row["areaGuid"] != null && row["areaGuid"].ToString() != "")
                {
                    model.areaGuid = new Guid(row["areaGuid"].ToString());
                }
                if (row["areaName"] != null)
                {
                    model.areaName = row["areaName"].ToString();
                }
                if (row["remarkTxt"] != null)
                {
                    model.remarkTxt = row["remarkTxt"].ToString();
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
            strSql.Append("select areaGuid,areaName,remarkTxt ");
            strSql.Append(" FROM wn_sendArea ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Twee.Model.SendArea> _GetList() {
            List<Twee.Model.SendArea> list = new List<Model.SendArea>();
            DataTable datatable = GetList(string.Empty).Tables[0];
            if (null == datatable)
                return null;
            foreach (DataRow row in datatable.Rows) {
                list.Add(DataRowToModel(row));
            }
            return list;

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
            strSql.Append(" areaGuid,areaName,remarkTxt ");
            strSql.Append(" FROM wn_sendArea ");
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
            strSql.Append("select count(1) FROM wn_sendArea ");
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
                strSql.Append("order by T.areaGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_sendArea T ");
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
            parameters[0].Value = "wn_sendArea";
            parameters[1].Value = "areaGuid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region 后台方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool MgeExists(string areaName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_sendArea");
            strSql.Append(" where areaName=@areaName ");
            SqlParameter[] parameters = {
					 new SqlParameter("@areaName", SqlDbType.NVarChar,50)};
            parameters[0].Value = areaName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool MgeAdd(string areaName, string remarkTxt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_sendArea(");
            strSql.Append("areaGuid,areaName,remarkTxt)");
            strSql.Append(" values (");
            strSql.Append("@areaGuid,@areaName,@remarkTxt)");
            SqlParameter[] parameters = {
                    new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16),         
					new SqlParameter("@areaName", SqlDbType.NVarChar,50),                                    
                    new SqlParameter("@remarkTxt", SqlDbType.NVarChar,500)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = areaName;
            parameters[2].Value = remarkTxt;

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
        public bool MgeUpdate(Guid areaGuid, string areaName, string remarkTxt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_sendArea set ");
            strSql.Append("areaName=@areaName,remarkTxt=@remarkTxt");
            strSql.Append(" where areaGuid=@areaGuid ");
            SqlParameter[] parameters = {
            new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16),
            new SqlParameter("@areaName", SqlDbType.NVarChar,50),                                    
            new SqlParameter("@remarkTxt", SqlDbType.NVarChar,500)};
            parameters[0].Value = areaGuid;
            parameters[1].Value = areaName;
            parameters[2].Value = remarkTxt;

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
        public bool MgeDelete(Guid areaGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_sendArea ");
            strSql.Append(" where areaGuid=@areaGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = areaGuid;

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
        /// 获得数据列表
        /// </summary>
        public DataTable MgeGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select areaGuid, areaName,remarkTxt ");
            strSql.Append(" FROM wn_sendArea ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        #endregion
    }
}
