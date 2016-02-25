using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using Twee.Comm;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:payaccountbindDataMgr
    /// </summary>
    public partial class payaccountbindDataMgr
    {
        public payaccountbindDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_payaccountbind");
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
        public int Add(Twee.Model.payaccountbind model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_payaccountbind(");
            strSql.Append("userid,username,usercode,payaccount,userphone,isagree,bindstate,createtime)");
            strSql.Append(" values (");
            strSql.Append("@userid,@username,@usercode,@payaccount,@userphone,@isagree,@bindstate,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@usercode", SqlDbType.NVarChar,50),
					new SqlParameter("@payaccount", SqlDbType.NVarChar,100),
					new SqlParameter("@userphone", SqlDbType.NChar,10),
					new SqlParameter("@isagree", SqlDbType.Int,4),
					new SqlParameter("@bindstate", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.username;
            parameters[2].Value = model.usercode;
            parameters[3].Value = model.payaccount;
            parameters[4].Value = model.userphone;
            parameters[5].Value = model.isagree;
            parameters[6].Value = model.bindstate;
            parameters[7].Value = model.createtime;

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
        public bool Update(Twee.Model.payaccountbind model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_payaccountbind set ");
            strSql.Append("userid=@userid,");
            strSql.Append("username=@username,");
            strSql.Append("usercode=@usercode,");
            strSql.Append("payaccount=@payaccount,");
            strSql.Append("userphone=@userphone,");
            strSql.Append("isagree=@isagree,");
            strSql.Append("bindstate=@bindstate,");
            strSql.Append("createtime=@createtime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@usercode", SqlDbType.NVarChar,50),
					new SqlParameter("@payaccount", SqlDbType.NVarChar,100),
					new SqlParameter("@userphone", SqlDbType.NChar,10),
					new SqlParameter("@isagree", SqlDbType.Int,4),
					new SqlParameter("@bindstate", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.username;
            parameters[2].Value = model.usercode;
            parameters[3].Value = model.payaccount;
            parameters[4].Value = model.userphone;
            parameters[5].Value = model.isagree;
            parameters[6].Value = model.bindstate;
            parameters[7].Value = model.createtime;
            parameters[8].Value = model.id;

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
            strSql.Append("delete from wn_payaccountbind ");
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
            strSql.Append("delete from wn_payaccountbind ");
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
        public Twee.Model.payaccountbind GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userid,username,usercode,payaccount,userphone,isagree,bindstate,createtime from wn_payaccountbind ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.payaccountbind model = new Twee.Model.payaccountbind();
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
        public Twee.Model.payaccountbind DataRowToModel(DataRow row)
        {
            Twee.Model.payaccountbind model = new Twee.Model.payaccountbind();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.userid = new Guid(row["userid"].ToString());
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["usercode"] != null)
                {
                    model.usercode = row["usercode"].ToString();
                }
                if (row["payaccount"] != null)
                {
                    model.payaccount = row["payaccount"].ToString();
                }
                if (row["userphone"] != null)
                {
                    model.userphone = row["userphone"].ToString();
                }
                if (row["isagree"] != null && row["isagree"].ToString() != "")
                {
                    model.isagree = int.Parse(row["isagree"].ToString());
                }
                if (row["bindstate"] != null && row["bindstate"].ToString() != "")
                {
                    model.bindstate = int.Parse(row["bindstate"].ToString());
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
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
            strSql.Append("select id,userid,username,usercode,payaccount,userphone,isagree,bindstate,createtime ");
            strSql.Append(" FROM wn_payaccountbind ");
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
            strSql.Append(" id,userid,username,usercode,payaccount,userphone,isagree,bindstate,createtime ");
            strSql.Append(" FROM wn_payaccountbind ");
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
            strSql.Append("select count(1) FROM wn_payaccountbind ");
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
            strSql.Append(")AS Row, T.*  from wn_payaccountbind T ");
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
            parameters[0].Value = "wn_payaccountbind";
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

