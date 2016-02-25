using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class StoragDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid storagGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_storag");
            strSql.Append(" where storagGuid=@storagGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = storagGuid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Storag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_storag(");
            strSql.Append("storagGuid,storagName,belongArea,sendArea,remarktxt,number)");
            strSql.Append(" values (");
            strSql.Append("@storagGuid,@storagName,@belongArea,@sendArea,@remarktxt,@number)");
            SqlParameter[] parameters = {
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@storagName", SqlDbType.NVarChar,50),
					new SqlParameter("@belongArea", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sendArea", SqlDbType.NVarChar,500),
					new SqlParameter("@remarktxt", SqlDbType.NVarChar,500),
					new SqlParameter("@number", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.storagName;
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = model.sendArea;
            parameters[4].Value = model.remarktxt;
            parameters[5].Value = model.number;

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
        public bool Update(Twee.Model.Storag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_storag set ");
            strSql.Append("storagName=@storagName,");
            strSql.Append("belongArea=@belongArea,");
            strSql.Append("sendArea=@sendArea,");
            strSql.Append("remarktxt=@remarktxt,");
            strSql.Append("number=@number");
            strSql.Append(" where storagGuid=@storagGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@storagName", SqlDbType.NVarChar,50),
					new SqlParameter("@belongArea", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sendArea", SqlDbType.NVarChar,500),
					new SqlParameter("@remarktxt", SqlDbType.NVarChar,500),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.storagName;
            parameters[1].Value = model.belongArea;
            parameters[2].Value = model.sendArea;
            parameters[3].Value = model.remarktxt;
            parameters[4].Value = model.number;
            parameters[5].Value = model.storagGuid;

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
        public bool Delete(Guid storagGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_storag ");
            strSql.Append(" where storagGuid=@storagGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = storagGuid;

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
        public bool DeleteList(string storagGuidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_storag ");
            strSql.Append(" where storagGuid in (" + storagGuidlist + ")  ");
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
        public Twee.Model.Storag GetModel(Guid storagGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 storagGuid,storagName,belongArea,sendArea,remarktxt,number from wn_storag ");
            strSql.Append(" where storagGuid=@storagGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = storagGuid;

            Twee.Model.Storag model = new Twee.Model.Storag();
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
        public Twee.Model.Storag DataRowToModel(DataRow row)
        {
            Twee.Model.Storag model = new Twee.Model.Storag();
            if (row != null)
            {
                if (row["storagGuid"] != null && row["storagGuid"].ToString() != "")
                {
                    model.storagGuid = new Guid(row["storagGuid"].ToString());
                }
                if (row["storagName"] != null)
                {
                    model.storagName = row["storagName"].ToString();
                }
                if (row["belongArea"] != null && row["belongArea"].ToString() != "")
                {
                    model.belongArea = new Guid(row["belongArea"].ToString());
                }
                if (row["sendArea"] != null)
                {
                    model.sendArea = row["sendArea"].ToString();
                }
                if (row["remarktxt"] != null)
                {
                    model.remarktxt = row["remarktxt"].ToString();
                }
                if (row["number"] != null && row["number"].ToString() != "")
                {
                    model.number = int.Parse(row["number"].ToString());
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
            strSql.Append("select storagGuid,storagName,belongArea,sendArea,remarktxt,number ");
            strSql.Append(" FROM wn_storag ");
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
            strSql.Append(" storagGuid,storagName,belongArea,sendArea,remarktxt,number ");
            strSql.Append(" FROM wn_storag ");
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
            strSql.Append("select count(1) FROM wn_storag ");
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
                strSql.Append("order by T.storagGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_storag T ");
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
            parameters[0].Value = "wn_storag";
            parameters[1].Value = "storagGuid";
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
        public bool MgeExists(string storagName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_storag");
            strSql.Append(" where storagName=@storagName ");
            SqlParameter[] parameters = {
					 new SqlParameter("@storagName", SqlDbType.NVarChar,50)	};
            parameters[0].Value = storagName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool MgeAdd(string storagName, string belongArea, string sendArea, string remarktxt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_storag(");
            strSql.Append("storagGuid,storagName,belongArea,sendArea,remarktxt)");
            strSql.Append(" values (");
            strSql.Append("@storagGuid,@storagName,@belongArea,@sendArea,@remarktxt)");
            SqlParameter[] parameters = {
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@storagName", SqlDbType.NVarChar,50),
                    new SqlParameter("@belongArea", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@sendArea", SqlDbType.NVarChar,500),
                    new SqlParameter("@remarktxt", SqlDbType.NVarChar,500)                                   
                                    
        };
            Guid belongAreaGuid = new Guid(belongArea);
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = storagName;
            parameters[2].Value = belongAreaGuid;
            parameters[3].Value = sendArea;
            parameters[4].Value = remarktxt;

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
        public bool MgeUpdate(string storagGuid, string storagName, string belongArea, string sendArea, string remarktxt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_storag set ");
            strSql.Append("storagName=@storagName,belongArea=@belongArea,sendArea=@sendArea,remarktxt=@remarktxt");
            strSql.Append(" where storagGuid=@storagGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@storagName", SqlDbType.NVarChar,50),
                    new SqlParameter("@belongArea", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@sendArea", SqlDbType.NVarChar,500),
                    new SqlParameter("@remarktxt", SqlDbType.NVarChar,500)                                  
                                    
        };
            Guid guid = new Guid(storagGuid);
            Guid belongAreaGuid = new Guid(belongArea);
            parameters[0].Value = guid;
            parameters[1].Value = storagName;
            parameters[2].Value = belongAreaGuid;
            parameters[3].Value = sendArea;
            parameters[4].Value = remarktxt;

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
        public bool MgeDelete(Guid storagGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_storag ");
            strSql.Append(" where storagGuid=@storagGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = storagGuid;

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
        /// 获得仓库及其配送区域列表
        /// </summary>
        public DataTable MgeGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select s.*,a.areaName from  dbo.wn_storag s left join dbo.wn_sendArea a on s.belongArea=a.areaGuid  ");
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

        /// <summary>
        /// 所有仓库列表
        /// </summary>
        public DataTable MgeGetAllStorag(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select storagGuid,storagName from dbo.wn_storag ");
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
