using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using Twee.Model;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class TemplateDataMgr
    {
        public TemplateDataMgr()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_template");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Template model,out int? id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_template(");
            strSql.Append("imgurl,user_id,title,type,result,addtime)");
            strSql.Append(" values (");
            strSql.Append("@imgurl,@user_id,@title,@type,@result,@addtime);");
            SqlParameter[] parameters = {					
					new SqlParameter("@imgurl", SqlDbType.NVarChar,50),
					new SqlParameter("@user_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
                    new SqlParameter("@result", SqlDbType.NVarChar,5000),
                    new SqlParameter("@addtime", SqlDbType.DateTime)};           
            parameters[0].Value = model.imgurl;
            parameters[1].Value = model.user_id;
            parameters[2].Value = model.title;
            parameters[3].Value = model.type;
            parameters[4].Value = model.result;
            parameters[5].Value = DateTime.Now;
         
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            DataSet ds = DbHelperSQL.Query(" select MAX(id) id from dbo.wn_template;");
            if (rows > 0)
            {
                id = ds.Tables[0].Rows[0][0].ToString().ToInt();
                return true;
            }
            else
            {
                id = null;
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Template model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_template set ");
            strSql.Append("id=@id,");
            strSql.Append("imgurl=@imgurl,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("title=@title,");
            strSql.Append("type=@type");
            strSql.Append("result=@result");
            strSql.Append("addtime=@addtime");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,50),
					new SqlParameter("@user_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
                    new SqlParameter("@result", SqlDbType.NVarChar,5000),
                    new SqlParameter("@addtime", SqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.imgurl;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.title;
            parameters[4].Value = model.type;
            parameters[5].Value = model.result;
            parameters[6].Value = DateTime.Now;

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
            strSql.Append("delete from wn_template ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
            strSql.Append("delete from wn_template ");
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
        public Template GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,imgurl,user_id,title,type,description,result,addtime from wn_template ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            Template model = new Template();
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
        public Template DataRowToModel(DataRow row)
        {
            Template model = new Template();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["imgurl"] != null)
                {
                    model.imgurl = row["imgurl"].ToString();
                }
                if (row["user_id"] != null && row["user_id"].ToString() != "")
                {
                    model.user_id = new Guid(row["user_id"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["type"] != null && row["type"].ToString() != "")
                {
                    model.type = row["type"].ToString();
                }
                if (row["description"] != null && row["description"].ToString() != "")
                {
                    model.description = row["description"].ToString();
                }
                if (row["result"] != null && row["result"].ToString() != "")
                {
                    model.result = row["result"].ToString();
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = row["addtime"].ToString().ToDateTime().Value;
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
            strSql.Append("select id,imgurl,user_id,title,type ");
            strSql.Append(" FROM wn_template ");
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
            strSql.Append(" id,imgurl,user_id,title,type ");
            strSql.Append(" FROM wn_template ");
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
            strSql.Append("select count(1) FROM wn_template ");
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
            strSql.Append("SELECT id,imgurl,user_id,title,type,TT.username,TT.result FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*,u.username from wn_template T ");
            strSql.Append("  left join  dbo.wn_user  u on T.user_id=u.guid  ");
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
            parameters[0].Value = "wn_template";
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
