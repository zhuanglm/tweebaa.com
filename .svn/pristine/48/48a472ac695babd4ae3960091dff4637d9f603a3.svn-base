using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Comm;
using System.Data.SqlClient;
using System.Data;

namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:PointDataMgr
    /// </summary>
    public partial class PointDataMgr
    {
        public PointDataMgr()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.Point model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_point(");
            strSql.Append("type,userId,prdId,orderNo,point,remark,addTime,state)");
            strSql.Append(" values (");
            strSql.Append("@type,@userId,@prdId,@orderNo,@point,@remark,@addTime,@state)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.NVarChar,20),
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@prdId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@orderNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@point", SqlDbType.Decimal,2),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Int,4)};
            parameters[0].Value = model.type;
            parameters[1].Value = model.userId;

            parameters[2].Value = model.prdId;
            parameters[3].Value = model.orderNo;
            parameters[4].Value = model.point;

            parameters[5].Value = model.remark;
            parameters[6].Value = model.addTime;
            parameters[7].Value = model.state;

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
        public bool Update(Twee.Model.Point model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_point set ");
            strSql.Append("type=@type,");
            strSql.Append("userId=@userId,");
            strSql.Append("remark=@remark,");
            strSql.Append("addTime=@addTime,");
            strSql.Append("state=@state");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.NVarChar,20),
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.type;
            parameters[1].Value = model.userId;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.addTime;
            parameters[4].Value = model.state;
            parameters[5].Value = model.id;

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
            strSql.Append("delete from wn_point ");
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
            strSql.Append("delete from wn_point ");
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
        public Twee.Model.Point GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,type,userId,remark,addTime,state from wn_point ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.Point model = new Twee.Model.Point();
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
        public Twee.Model.Point DataRowToModel(DataRow row)
        {
            Twee.Model.Point model = new Twee.Model.Point();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["userId"] != null && row["userId"].ToString() != "")
                {
                    model.userId = new Guid(row["userId"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["addTime"] != null && row["addTime"].ToString() != "")
                {
                    model.addTime = DateTime.Parse(row["addTime"].ToString());
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
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
            strSql.Append("select id,type,userId,prdId,point,remark,addTime,state ");
            strSql.Append(" FROM wn_point ");
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
            strSql.Append(" id,type,userId,prdId,point,remark,addTime,state ");
            strSql.Append(" FROM wn_point ");
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
            strSql.Append("select count(1) FROM wn_point ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex,out int totalCount)
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
            strSql.Append(")AS Row, T.*  from wn_point T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append(";select count(*) from wn_point");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds!=null&&ds.Tables.Count>1)
            {
                totalCount = ds.Tables[1].Rows[0][0].ToString().ToInt();
            }
            else
            {
                totalCount = 0;
            }
            return ds;
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
            parameters[0].Value = "wn_point";
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
