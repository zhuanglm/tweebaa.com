using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:proPriceAreaDataMgr
    /// </summary>
    public partial class proPriceAreaDataMgr
    {
        public proPriceAreaDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_proPriceArea");
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
        public int Add(Twee.Model.proPriceArea model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_proPriceArea(");
            strSql.Append("ruleid,countfrom,countto,price,proid,userid,suggestprice,createtime)");
            strSql.Append(" values (");
            strSql.Append("@ruleid,@countfrom,@countto,@price,@proid,@userid,@suggestprice,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ruleid", SqlDbType.Int,4),
					new SqlParameter("@countfrom", SqlDbType.Decimal,9),
					new SqlParameter("@countto", SqlDbType.Decimal,9),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@suggestprice", SqlDbType.Decimal,9),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
            parameters[0].Value = model.ruleid;
            parameters[1].Value = model.countfrom;
            parameters[2].Value = model.countto;
            parameters[3].Value = model.price;
            parameters[4].Value = model.proid;
            parameters[5].Value = model.userid;
            parameters[6].Value = model.suggestprice;
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
        public bool Update(Twee.Model.proPriceArea model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_proPriceArea set ");
            strSql.Append("ruleid=@ruleid,");
            strSql.Append("countfrom=@countfrom,");
            strSql.Append("countto=@countto,");
            strSql.Append("price=@price,");
            strSql.Append("proid=@proid,");
            strSql.Append("userid=@userid,");
            strSql.Append("suggestprice=@suggestprice,");
            strSql.Append("createtime=@createtime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ruleid", SqlDbType.Int,4),
					new SqlParameter("@countfrom", SqlDbType.Decimal,9),
					new SqlParameter("@countto", SqlDbType.Decimal,9),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@suggestprice", SqlDbType.Decimal,9),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ruleid;
            parameters[1].Value = model.countfrom;
            parameters[2].Value = model.countto;
            parameters[3].Value = model.price;
            parameters[4].Value = model.proid;
            parameters[5].Value = model.userid;
            parameters[6].Value = model.suggestprice;
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
            strSql.Append("delete from wn_proPriceArea ");
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
            strSql.Append("delete from wn_proPriceArea ");
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
        public Twee.Model.proPriceArea GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ruleid,countfrom,countto,price,proid,userid,suggestprice,createtime from wn_proPriceArea ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.proPriceArea model = new Twee.Model.proPriceArea();
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
        public Twee.Model.proPriceArea DataRowToModel(DataRow row)
        {
            Twee.Model.proPriceArea model = new Twee.Model.proPriceArea();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ruleid"] != null && row["ruleid"].ToString() != "")
                {
                    model.ruleid = int.Parse(row["ruleid"].ToString());
                }
                if (row["countfrom"] != null && row["countfrom"].ToString() != "")
                {
                    model.countfrom = decimal.Parse(row["countfrom"].ToString());
                }
                if (row["countto"] != null && row["countto"].ToString() != "")
                {
                    model.countto = decimal.Parse(row["countto"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["proid"] != null)
                {
                    model.proid = row["proid"].ToString();
                }
                if (row["userid"] != null)
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["suggestprice"] != null && row["suggestprice"].ToString() != "")
                {
                    model.suggestprice = decimal.Parse(row["suggestprice"].ToString());
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
            strSql.Append("select id,ruleid,countfrom,countto,price,proid,userid,suggestprice,createtime ");
            strSql.Append(" FROM wn_proPriceArea ");
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
            strSql.Append(" id,ruleid,countfrom,countto,price,proid,userid,suggestprice,createtime ");
            strSql.Append(" FROM wn_proPriceArea ");
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
            strSql.Append("select count(1) FROM wn_proPriceArea ");
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
            strSql.Append(")AS Row, T.*  from wn_proPriceArea T ");
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
            parameters[0].Value = "wn_proPriceArea";
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

        public bool UpdateList(string sqlList) {
            return DbHelperSQL.ExecuteSql(sqlList) > 0;
        }
        public bool DeleteListByRuleId(string sql) {
            return DbHelperSQL.ExecuteSql(sql) > 0;
        }

        public int ExecuteSql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 根据规格id获取价格区间
        /// </summary>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        public DataTable GetPriceByRuleID(int ruleId)
        {          
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ruleid,countfrom,countto,price,proid from wn_proPriceArea ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = ruleId;

            Twee.Model.proPriceArea model = new Twee.Model.proPriceArea();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds!=null&&ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 根据选购的【产品规格】和【购买数量】 查询对应价格
        /// </summary>
        /// <param name="ruleId">规格id</param>
        /// <param name="buyCount">购买数量</param>
        /// <returns></returns>
        public decimal? GetSalePrice(int ruleId, decimal buyCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ruleid,countfrom,countto,price,proid from wn_proPriceArea ");
            //strSql.Append(" where id=@id and countfrom<=@buyCount and countto>=@buyCount");
            strSql.Append(" where ruleid=@id and countfrom<=@buyCount and countto>=@buyCount");

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@buyCount", SqlDbType.Int,4)
			};
            parameters[0].Value = ruleId;
            parameters[1].Value = buyCount;
            Twee.Model.proPriceArea model = new Twee.Model.proPriceArea();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0]["price"].ToString().ToDecimal();
            }
            return null;
        }
        #endregion  ExtensionMethod
    }
}

