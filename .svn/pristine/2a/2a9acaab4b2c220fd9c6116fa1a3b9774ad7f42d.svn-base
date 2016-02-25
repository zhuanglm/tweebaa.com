using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;

namespace Twee.DataMgr
{
    public class ReviewgradeparamDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Reviewgradeparam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_reviewgradeparam(");
            strSql.Append("guid,grade,integral,reviewreward,commissionratio1,commissionratio2,commissionratio3)");
            strSql.Append(" values (");
            strSql.Append("@guid,@grade,@integral,@reviewreward,@commissionratio1,@commissionratio2,@commissionratio3)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@grade", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@reviewreward", SqlDbType.Int,4),
					new SqlParameter("@commissionratio1", SqlDbType.Int,4),
					new SqlParameter("@commissionratio2", SqlDbType.Int,4),
					new SqlParameter("@commissionratio3", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.grade;
            parameters[2].Value = model.integral;
            parameters[3].Value = model.reviewreward;
            parameters[4].Value = model.commissionratio1;
            parameters[5].Value = model.commissionratio2;
            parameters[6].Value = model.commissionratio3;

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
        public bool Update(Twee.Model.Reviewgradeparam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_reviewgradeparam set ");
            strSql.Append("guid=@guid,");
            strSql.Append("grade=@grade,");
            strSql.Append("integral=@integral,");
            strSql.Append("reviewreward=@reviewreward,");
            strSql.Append("commissionratio1=@commissionratio1,");
            strSql.Append("commissionratio2=@commissionratio2,");
            strSql.Append("commissionratio3=@commissionratio3");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@grade", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@reviewreward", SqlDbType.Int,4),
					new SqlParameter("@commissionratio1", SqlDbType.Int,4),
					new SqlParameter("@commissionratio2", SqlDbType.Int,4),
					new SqlParameter("@commissionratio3", SqlDbType.Int,4)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.integral;
            parameters[3].Value = model.reviewreward;
            parameters[4].Value = model.commissionratio1;
            parameters[5].Value = model.commissionratio2;
            parameters[6].Value = model.commissionratio3;

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
            strSql.Append("delete from wn_reviewgradeparam ");
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
        public Twee.Model.Reviewgradeparam GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,grade,integral,reviewreward,commissionratio1,commissionratio2,commissionratio3 from wn_reviewgradeparam ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            Twee.Model.Reviewgradeparam model = new Twee.Model.Reviewgradeparam();
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
        public Twee.Model.Reviewgradeparam DataRowToModel(DataRow row)
        {
            Twee.Model.Reviewgradeparam model = new Twee.Model.Reviewgradeparam();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["grade"] != null && row["grade"].ToString() != "")
                {
                    model.grade = int.Parse(row["grade"].ToString());
                }
                if (row["integral"] != null && row["integral"].ToString() != "")
                {
                    model.integral = int.Parse(row["integral"].ToString());
                }
                if (row["reviewreward"] != null && row["reviewreward"].ToString() != "")
                {
                    model.reviewreward = int.Parse(row["reviewreward"].ToString());
                }
                if (row["commissionratio1"] != null && row["commissionratio1"].ToString() != "")
                {
                    model.commissionratio1 = int.Parse(row["commissionratio1"].ToString());
                }
                if (row["commissionratio2"] != null && row["commissionratio2"].ToString() != "")
                {
                    model.commissionratio2 = int.Parse(row["commissionratio2"].ToString());
                }
                if (row["commissionratio3"] != null && row["commissionratio3"].ToString() != "")
                {
                    model.commissionratio3 = int.Parse(row["commissionratio3"].ToString());
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
            strSql.Append("select guid,grade,integral,reviewreward,commissionratio1,commissionratio2,commissionratio3 ");
            strSql.Append(" FROM wn_reviewgradeparam ");
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
            strSql.Append(" guid,grade,integral,reviewreward,commissionratio1,commissionratio2,commissionratio3 ");
            strSql.Append(" FROM wn_reviewgradeparam ");
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
            strSql.Append("select count(1) FROM wn_reviewgradeparam ");
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
            strSql.Append(")AS Row, T.*  from wn_reviewgradeparam T ");
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
            parameters[0].Value = "wn_reviewgradeparam";
            parameters[1].Value = "guid";
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
        /// 增加一条数据
        /// </summary>      
        public bool MgeAdd(int grade, int integral, int reviewreward, int commissionratio1, int commissionratio2, int commissionratio3)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_reviewgradeparam(");
            strSql.Append("guid,grade,integral,reviewreward,commissionratio1,commissionratio2,commissionratio3)");
            strSql.Append(" values (");
            strSql.Append("@guid,@grade,@integral,@reviewreward,@commissionratio1,@commissionratio2,@commissionratio3)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@grade", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@reviewreward", SqlDbType.Int,4),				
					new SqlParameter("@commissionratio1", SqlDbType.Int,4),
                    new SqlParameter("@commissionratio2", SqlDbType.Int,4),
                    new SqlParameter("@commissionratio3", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = grade;
            parameters[2].Value = integral;
            parameters[3].Value = reviewreward;
            parameters[4].Value = commissionratio1;
            parameters[5].Value = commissionratio2;
            parameters[6].Value = commissionratio3;
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
        public bool MgeUpdate(Guid guid, int grade, int integral, int reviewreward, int commissionratio1, int commissionratio2, int commissionratio3)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_reviewgradeparam set ");
            strSql.Append("guid=@guid,");
            strSql.Append("grade=@grade,");
            strSql.Append("integral=@integral,");
            strSql.Append("reviewreward=@reviewreward,");
            strSql.Append("commissionratio1=@commissionratio1,");
            strSql.Append("commissionratio2=@commissionratio2,");
            strSql.Append("commissionratio3=@commissionratio3");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@grade", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@reviewreward", SqlDbType.Int,4),				
					new SqlParameter("@commissionratio1", SqlDbType.Int,4),
                    new SqlParameter("@commissionratio2", SqlDbType.Int,4),
                    new SqlParameter("@commissionratio3", SqlDbType.Int,4)};
            parameters[0].Value = guid;
            parameters[1].Value = grade;
            parameters[2].Value = integral;
            parameters[3].Value = reviewreward;
            parameters[4].Value = commissionratio1;
            parameters[5].Value = commissionratio2;
            parameters[6].Value = commissionratio3;

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
        public bool MgeDelete(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_reviewgradeparam where guid=@guid");

            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					};
            parameters[0].Value = guid;
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
            strSql.Append("select guid,grade,integral,reviewreward,commissionratio1,commissionratio2,commissionratio3 ");
            strSql.Append(" FROM wn_reviewgradeparam ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by grade asc  ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>        
        public int MgeGetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wn_reviewgradeparam ");
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
        #endregion
    }
}
