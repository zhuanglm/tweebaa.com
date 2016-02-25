using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class PatentDataMgr
    {
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Patent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_patent(");
            strSql.Append("guid,userguid,prdguid,patentname,patentcode,patenttime,createtime,state,patentcontent)");
            strSql.Append(" values (");
            strSql.Append("@guid,@userguid,@prdguid,@patentname,@patentcode,@patenttime,@createtime,@state,@patentcontent)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@patentname", SqlDbType.NVarChar,50),
					new SqlParameter("@patentcode", SqlDbType.NVarChar,50),
					new SqlParameter("@patenttime", SqlDbType.DateTime),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Bit,1),
					new SqlParameter("@patentcontent", SqlDbType.NVarChar,4000)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = model.patentname;
            parameters[4].Value = model.patentcode;
            parameters[5].Value = model.patenttime;
            parameters[6].Value = model.createtime;
            parameters[7].Value = model.state;
            parameters[8].Value = model.patentcontent;

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
        public bool Update(Twee.Model.Patent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_patent set ");
            strSql.Append("guid=@guid,");
            strSql.Append("userguid=@userguid,");
            strSql.Append("prdguid=@prdguid,");
            strSql.Append("patentname=@patentname,");
            strSql.Append("patentcode=@patentcode,");
            strSql.Append("patenttime=@patenttime,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("state=@state,");
            strSql.Append("patentcontent=@patentcontent");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@patentname", SqlDbType.NVarChar,50),
					new SqlParameter("@patentcode", SqlDbType.NVarChar,50),
					new SqlParameter("@patenttime", SqlDbType.DateTime),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Bit,1),
					new SqlParameter("@patentcontent", SqlDbType.NVarChar,4000)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.userguid;
            parameters[2].Value = model.prdguid;
            parameters[3].Value = model.patentname;
            parameters[4].Value = model.patentcode;
            parameters[5].Value = model.patenttime;
            parameters[6].Value = model.createtime;
            parameters[7].Value = model.state;
            parameters[8].Value = model.patentcontent;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_patent ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

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
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Patent GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,userguid,prdguid,patentname,patentcode,patenttime,createtime,state,patentcontent from wn_patent ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            Twee.Model.Patent model = new Twee.Model.Patent();
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
        public Twee.Model.Patent DataRowToModel(DataRow row)
        {
            Twee.Model.Patent model = new Twee.Model.Patent();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["userguid"] != null && row["userguid"].ToString() != "")
                {
                    model.userguid = new Guid(row["userguid"].ToString());
                }
                if (row["prdguid"] != null && row["prdguid"].ToString() != "")
                {
                    model.prdguid = new Guid(row["prdguid"].ToString());
                }
                if (row["patentname"] != null)
                {
                    model.patentname = row["patentname"].ToString();
                }
                if (row["patentcode"] != null)
                {
                    model.patentcode = row["patentcode"].ToString();
                }
                if (row["patenttime"] != null && row["patenttime"].ToString() != "")
                {
                    model.patenttime = DateTime.Parse(row["patenttime"].ToString());
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    if ((row["state"].ToString() == "1") || (row["state"].ToString().ToLower() == "true"))
                    {
                        model.state = true;
                    }
                    else
                    {
                        model.state = false;
                    }
                }
                if (row["patentcontent"] != null)
                {
                    model.patentcontent = row["patentcontent"].ToString();
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
            strSql.Append("select guid,userguid,prdguid,patentname,patentcode,patenttime,createtime,state,patentcontent ");
            strSql.Append(" FROM wn_patent ");
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
            strSql.Append(" guid,userguid,prdguid,patentname,patentcode,patenttime,createtime,state,patentcontent ");
            strSql.Append(" FROM wn_patent ");
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
            strSql.Append("select count(1) FROM wn_patent ");
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
                strSql.Append("order by T.guid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_patent T ");
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
            parameters[0].Value = "wn_patent";
            parameters[1].Value = "guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  后台方法

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>      
        public DataTable MgeGetList()
        {
            string sql = "select p.*,u.username from  dbo.wn_patent p left join  dbo.wn_user u on p.userguid=u.guid ";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <returns></returns>       
        public DataTable MgeGetList(string userName, bool state, out int count)
        {
            count = 0;
            StringBuilder sbStr = new StringBuilder("");
            if (!string.IsNullOrEmpty(userName))
            {
                sbStr.Append(" where  u.username=@username and p.state=@state  ");
            }
            SqlParameter[] paras = new SqlParameter[]
        {
          new SqlParameter("@userName",userName),         
          new SqlParameter("@state",state)          
        };

            string sql = "select p.*,u.username from  dbo.wn_patent p left join  dbo.wn_user u on p.userguid=u.guid " + sbStr.ToString();

            DataSet ds = DbHelperSQL.Query(sql, paras);
            if (ds.Tables.Count > 0)
            {
                count = ds.Tables[0].Rows.Count;
                return ds.Tables[0];
            }
            return null;

        }

        // <summary>
        /// 分页查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <returns></returns>      
        public DataTable MgeGetListByPage(string userName, bool state, int pageSize, int currentPage)
        {
            StringBuilder sbStr = new StringBuilder("");
            if (!string.IsNullOrEmpty(userName))
            {
                sbStr.Append(" where u.username=@username and p.state=@state  ");
            }
            SqlParameter[] paras = new SqlParameter[]
        {
          new SqlParameter("@username",userName),         
          new SqlParameter("@state",state)          
        };
            string sqlpage = "";
            DataSet ds = new DataSet();
            if (sbStr.ToString() == "")
            {
                sqlpage = "Select Top  " + pageSize + "p.*,u.username from dbo.wn_patent p left join  dbo.wn_user u on p.userguid=u.guid  where p.guid not in(select top " + pageSize * currentPage + " dbo.wn_patent.guid from dbo.wn_patent ) ";
                ds = DbHelperSQL.Query(sqlpage);
            }
            else
            {
                sqlpage = "Select Top  " + pageSize + "p.*,u.username from dbo.wn_patent p left join  dbo.wn_user u on p.userguid=u.guid" + sbStr.ToString() + " and p.guid not in(select top " + pageSize * currentPage + " dbo.wn_patent.guid from dbo.wn_patent ) ";
                ds = DbHelperSQL.Query(sqlpage, paras);
            }
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>       
        public bool MgeDelete(string guid)
        {
            SqlParameter[] paras = new SqlParameter[]
        {
          new SqlParameter("@guid",guid)      
               
        };
            string sql = "delete from  dbo.wn_patent  where guid=@guid";

            int resu = DbHelperSQL.ExecuteSql(sql, paras);
            if (resu > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>    
        public bool MgeUpdate(string guid, string panName, string panCode)
        {
            Guid gid = new Guid(guid);

            SqlParameter[] paras = new SqlParameter[]
        {
         
          new SqlParameter("@guid",gid),
          new SqlParameter("@patentname",panName),
          new SqlParameter("@patentcode",panCode)
               
        };
            //string sql = "update dbo.wn_patent set patentname=@patentname,patentcode=@patentcode where guid='" + gid + "'";
            string sql = "update dbo.wn_patent set patentname=@patentname,patentcode=@patentcode where guid=@guid";

            int resu = DbHelperSQL.ExecuteSql(sql, paras);
            if (resu > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查询专利详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable MgeGetInfo(string id)
        {
            string sql = "Select  p.*,u.username from dbo.wn_patent p left join  dbo.wn_user u on p.userguid=u.guid where p.guid='" + id + "'";

            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }


        #endregion
    }
}
