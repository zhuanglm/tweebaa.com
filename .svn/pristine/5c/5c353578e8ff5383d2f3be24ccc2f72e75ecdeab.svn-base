using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:proPriceDataMgr
    /// </summary>
    public partial class proPriceDataMgr
    {
        public proPriceDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_proPrice");
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
        public int Add(Twee.Model.proPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_proPrice(");
            strSql.Append("proid,userid,prorule,prosuggestprice,propricejson)");
            strSql.Append(" values (");
            strSql.Append("@proid,@userid,@prorule,@prosuggestprice,@propricejson)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@prorule", SqlDbType.NVarChar,50),
					new SqlParameter("@prosuggestprice", SqlDbType.Decimal,9),
					new SqlParameter("@propricejson", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.prorule;
            parameters[3].Value = model.prosuggestprice;
            parameters[4].Value = model.propricejson;

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
        public bool Update(Twee.Model.proPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_proPrice set ");
            strSql.Append("proid=@proid,");
            strSql.Append("userid=@userid,");
            strSql.Append("prorule=@prorule,");
            strSql.Append("prosuggestprice=@prosuggestprice,");
            strSql.Append("propricejson=@propricejson");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@prorule", SqlDbType.NVarChar,50),
					new SqlParameter("@prosuggestprice", SqlDbType.Decimal,9),
					new SqlParameter("@propricejson", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.prorule;
            parameters[3].Value = model.prosuggestprice;
            parameters[4].Value = model.propricejson;
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
            strSql.Append("delete from wn_proPrice ");
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
            strSql.Append("delete from wn_proPrice ");
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
        public Twee.Model.proPrice GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,proid,userid,prorule,prosuggestprice,propricejson from wn_proPrice ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.proPrice model = new Twee.Model.proPrice();
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
        public Twee.Model.proPrice DataRowToModel(DataRow row)
        {
            Twee.Model.proPrice model = new Twee.Model.proPrice();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["proid"] != null)
                {
                    model.proid = row["proid"].ToString();
                }
                if (row["userid"] != null)
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["prorule"] != null)
                {
                    model.prorule = row["prorule"].ToString();
                }
                if (row["prosuggestprice"] != null && row["prosuggestprice"].ToString() != "")
                {
                    model.prosuggestprice = decimal.Parse(row["prosuggestprice"].ToString());
                }
                if (row["propricejson"] != null && row["propricejson"].ToString() != "")
                {
                    model.propricejson = row["propricejson"].ToString();
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
            strSql.Append("select id,proid,userid,prorule,prosuggestprice,propricejson ");
            strSql.Append(" FROM wn_proPrice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Twee.Model.proPrice> GetEntityList(string where) {
            List<Twee.Model.proPrice> list = new List<Model.proPrice>();
            DataTable dt = GetList(where).Tables[0];
            if (null == dt || dt.Rows.Count == 0)
                return null;
            foreach (DataRow row in dt.Rows) {
                list.Add(DataRowToModel(row));
            }
            return list;

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
            strSql.Append(" id,proid,userid,prorule,prosuggestprice,propricejson ");
            strSql.Append(" FROM wn_proPrice ");
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
            strSql.Append("select count(1) FROM wn_proPrice ");
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
            strSql.Append(")AS Row, T.*  from wn_proPrice T ");
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
            parameters[0].Value = "wn_proPrice";
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

