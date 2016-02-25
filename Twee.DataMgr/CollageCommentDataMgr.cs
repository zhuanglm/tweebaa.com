using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;



namespace Twee.DataMgr
{
    public partial  class CollageCommentDataMgr
    {
        public CollageCommentDataMgr()
        {
        }
        public int GetCommentsTotal(string sDesignID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) as count FROM wn_CollageComments where CollageDesign_ID = " + sDesignID );

            int iTotal = 0;
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    iTotal = Convert.ToInt32(rdr["count"]);
                }
            }
            return iTotal;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageComments model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_CollageComments(");
            strSql.Append("CollageDesign_ID,user_id,comments,create_time)");
            strSql.Append(" values (");
            strSql.Append("@CollageDesign_ID,@user_id,@comments,@create_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4),
                    new SqlParameter("@user_id",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@comments", SqlDbType.NVarChar,500),
                    new SqlParameter("@create_time", SqlDbType.DateTime,8)};
            parameters[0].Value = model.CollageDesign_ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.comments;
            parameters[3].Value = model.CreateTime;

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
        public bool Update(Twee.Model.CollageComments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageComments set ");
            strSql.Append("prdGuid=@prdGuid");
            strSql.Append(" where CollageDesign_ID=@CollageDesign_ID and iOrder=@iOrder");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4),
                    new SqlParameter("@comments", SqlDbType.NVarChar,500),
                    new SqlParameter("@create_time", SqlDbType.DateTime,8)};
            parameters[0].Value = model.CollageDesign_ID;
            parameters[1].Value = model.comments;
            parameters[2].Value = model.CreateTime;

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
        public bool Delete(int CollageComments_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_CollageComments ");
            strSql.Append(" where CollageComments_ID=@CollageComments_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageComments_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = CollageComments_ID;

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

        public DataSet GetListByPage(string strWhere, int iFirst, int iLast)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (SELECT *, ROW_NUMBER() OVER (ORDER BY CollageComments_ID desc) AS 'RowNumber'");
            strSql.Append(" from wn_CollageComments a left join wn_user b on a.user_id=b.guid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere);
            }
            strSql.Append(") as a WHERE RowNumber BETWEEN " + iFirst);
            strSql.Append("AND " + iLast);
            return DbHelperSQL.Query(strSql.ToString());

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM wn_CollageComments a left join wn_user b on a.user_id=b.guid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere+" order by CollageComments_ID desc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
  /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.CollageComments DataRowToModel(DataRow row)
        {
            Twee.Model.CollageComments model = new Twee.Model.CollageComments();
            if (row != null)
            {
                if (row["CollageDesign_ID"] != null && row["CollageDesign_ID"].ToString() != "")
                {
                    model.CollageDesign_ID = int.Parse(row["CollageDesign_ID"].ToString());
                }
                if (row["comments"] != null)
                {
                    model.comments = row["comments"].ToString();
                }
                if (row["create_time"] != null)
                {
                    model.CreateTime= row["create_time"].ToString();
                }
                if (row["username"] != null)
                {
                    model.UserName = row["username"].ToString();
                }
                
            }
            return model;
        }
    }
}
