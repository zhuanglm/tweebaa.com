﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:paybindverfycodeDataMgr
    /// </summary>
    public partial class paybindverfycodeDataMgr
    {
        public paybindverfycodeDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_paybindverfycode");
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
        public int Add(Twee.Model.paybindverfycode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_paybindverfycode(");
            strSql.Append("phone,verfycode,createtime,userid)");
            strSql.Append(" values (");
            strSql.Append("@phone,@verfycode,@createtime,@userid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.NChar,30),
					new SqlParameter("@verfycode", SqlDbType.NChar,10),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@userid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.phone;
            parameters[1].Value = model.verfycode;
            parameters[2].Value = model.createtime;
            parameters[3].Value = model.userid;

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
        public bool Update(Twee.Model.paybindverfycode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_paybindverfycode set ");
            strSql.Append("phone=@phone,");
            strSql.Append("verfycode=@verfycode,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("userid=@userid");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.NChar,30),
					new SqlParameter("@verfycode", SqlDbType.NChar,10),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@userid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.phone;
            parameters[1].Value = model.verfycode;
            parameters[2].Value = model.createtime;
            parameters[3].Value = model.userid;
            parameters[4].Value = model.id;

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
            strSql.Append("delete from wn_paybindverfycode ");
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
            strSql.Append("delete from wn_paybindverfycode ");
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
        public Twee.Model.paybindverfycode GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,phone,verfycode,createtime,userid from wn_paybindverfycode ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.paybindverfycode model = new Twee.Model.paybindverfycode();
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
        public Twee.Model.paybindverfycode GetModel(Guid userid,string phone)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,phone,verfycode,createtime,userid from wn_paybindverfycode ");
            strSql.AppendFormat(" where userid='{0}' and phone='{1}' order by createtime desc",userid.ToString(),phone);
            //SqlParameter[] parameters = {
            //        new SqlParameter("@userid", SqlDbType.UniqueIdentifier,16),
            //        new SqlParameter("@phone",SqlDbType.NChar,30)
            //};
            //parameters[0].Value = userid;
            //parameters[1].Value = phone;

            Twee.Model.paybindverfycode model = new Twee.Model.paybindverfycode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public Twee.Model.paybindverfycode DataRowToModel(DataRow row)
        {
            Twee.Model.paybindverfycode model = new Twee.Model.paybindverfycode();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["verfycode"] != null)
                {
                    model.verfycode = row["verfycode"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.userid = new Guid(row["userid"].ToString());
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
            strSql.Append("select id,phone,verfycode,createtime,userid ");
            strSql.Append(" FROM wn_paybindverfycode ");
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
            strSql.Append(" id,phone,verfycode,createtime,userid ");
            strSql.Append(" FROM wn_paybindverfycode ");
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
            strSql.Append("select count(1) FROM wn_paybindverfycode ");
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
            strSql.Append(")AS Row, T.*  from wn_paybindverfycode T ");
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
            parameters[0].Value = "wn_paybindverfycode";
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

