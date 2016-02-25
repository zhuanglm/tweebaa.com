using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using Twee.Comm;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:userQianDaoDataMgr
    /// </summary>
    public partial class userQianDaoDataMgr
    {
        public userQianDaoDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_userQianDao");
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
        public int Add(Twee.Model.userQianDao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_userQianDao(");
            strSql.Append("userid,createtime,message,txt1,txt2,txt3)");
            strSql.Append(" values (");
            strSql.Append("@userid,@createtime,@message,@txt1,@txt2,@txt3)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@message", SqlDbType.NVarChar,50),
					new SqlParameter("@txt1", SqlDbType.NVarChar,50),
					new SqlParameter("@txt2", SqlDbType.NVarChar,50),
					new SqlParameter("@txt3", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.createtime;
            parameters[2].Value = model.message;
            parameters[3].Value = model.txt1;
            parameters[4].Value = model.txt2;
            parameters[5].Value = model.txt3;

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
        public bool Update(Twee.Model.userQianDao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_userQianDao set ");
            strSql.Append("userid=@userid,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("message=@message,");
            strSql.Append("txt1=@txt1,");
            strSql.Append("txt2=@txt2,");
            strSql.Append("txt3=@txt3");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@message", SqlDbType.NVarChar,50),
					new SqlParameter("@txt1", SqlDbType.NVarChar,50),
					new SqlParameter("@txt2", SqlDbType.NVarChar,50),
					new SqlParameter("@txt3", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.createtime;
            parameters[2].Value = model.message;
            parameters[3].Value = model.txt1;
            parameters[4].Value = model.txt2;
            parameters[5].Value = model.txt3;
            parameters[6].Value = model.id;

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
            strSql.Append("delete from wn_userQianDao ");
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
            strSql.Append("delete from wn_userQianDao ");
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
        public Twee.Model.userQianDao GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userid,createtime,message,txt1,txt2,txt3 from wn_userQianDao ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.userQianDao model = new Twee.Model.userQianDao();
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
        public Twee.Model.userQianDao DataRowToModel(DataRow row)
        {
            Twee.Model.userQianDao model = new Twee.Model.userQianDao();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["userid"] != null)
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["message"] != null)
                {
                    model.message = row["message"].ToString();
                }
                if (row["txt1"] != null)
                {
                    model.txt1 = row["txt1"].ToString();
                }
                if (row["txt2"] != null)
                {
                    model.txt2 = row["txt2"].ToString();
                }
                if (row["txt3"] != null)
                {
                    model.txt3 = row["txt3"].ToString();
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
            strSql.Append("select id,userid,createtime,message,txt1,txt2,txt3 ");
            strSql.Append(" FROM wn_userQianDao ");
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
            strSql.Append(" id,userid,createtime,message,txt1,txt2,txt3 ");
            strSql.Append(" FROM wn_userQianDao ");
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
            strSql.Append("select count(1) FROM wn_userQianDao ");
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
            strSql.Append(")AS Row, T.*  from wn_userQianDao T ");
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
            parameters[0].Value = "wn_userQianDao";
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

        /// <summary>
        /// 得到最近签到与当前日期天数差,并判断是否连续一周签到（是的话奖励积分10分）
        /// </summary>
        public int? GetRecentlySingDay(string userGuid, out bool isContinuous7)
        {
            string date = DateTime.Now.ToString();
            isContinuous7 = false;
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(string.Format("select top 1 DATEDIFF(dd,createtime,'{1}') from wn_userQianDao  where userid='{0}' order by createtime desc;", userGuid, date));
            strSql.Append(string.Format("select top 7 DATEDIFF(dd,createtime,'{1}') from wn_userQianDao  where userid='{0}' order by createtime desc;", userGuid,date));     
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                DataTable dt2=ds.Tables[0];
                if (dt2.Rows.Count>=6&&dt2.Rows[5][0].ToString()=="6")
                {
                    isContinuous7 = true;
                }
                return ds.Tables[0].Rows[0][0].ToString().ToInt();
                
            }           
            return null;
        }


        /// <summary>
        /// 得到最近N天签到日期
        /// </summary>
        public DataTable GetRecentlySingDay(string userGuid)
        {
            //string date = DateTime.Now.ToString();           
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("select top 7 createtime,DATEDIFF(dd,createtime,getdate()) from wn_userQianDao  where userid='{0}' order by createtime desc;", userGuid));
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }


        #endregion  ExtensionMethod
    }
}

