using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:PrdPricesDataMgr
    /// </summary>
    public partial class PrdPricesDataMgr
    {
        public PrdPricesDataMgr()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_prdprice");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Prdprice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prdprice(");
            strSql.Append("guid,prdguid,edttime,p1,p2,price,ruleid)");
            strSql.Append(" values (");
            strSql.Append("@guid,@prdguid,@edttime,@p1,@p2,@price,@ruleid)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@p1", SqlDbType.Decimal,5),
					new SqlParameter("@p2", SqlDbType.Decimal,5),
					new SqlParameter("@price", SqlDbType.Decimal,5),
					new SqlParameter("@ruleid", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.edttime;
            parameters[3].Value = model.p1;
            parameters[4].Value = model.p2;
            parameters[5].Value = model.price;
            parameters[6].Value = model.ruleid;

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

        public bool Add2(Twee.Model.Prdprice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prdprice(");
            strSql.Append("guid,prdguid,edttime,p1,p2,price,ruleid, ProductUploadBatchNo)");
            strSql.Append(" values (");
            strSql.Append("@guid,@prdguid,@edttime,@p1,@p2,@price,@ruleid, @ProductUploadBatchNo)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@p1", SqlDbType.Decimal,5),
					new SqlParameter("@p2", SqlDbType.Decimal,5),
					new SqlParameter("@price", SqlDbType.Decimal,5),
					new SqlParameter("@ruleid", SqlDbType.Int,4),
                    new SqlParameter("@ProductUploadBatchNo", SqlDbType.Int,4)
                                        };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.prdguid;
            parameters[2].Value = model.edttime;
            parameters[3].Value = model.p1;
            parameters[4].Value = model.p2;
            parameters[5].Value = model.price;
            parameters[6].Value = model.ruleid;
            if (model.UpLoadBatchNo == null) model.UpLoadBatchNo = -1;
            parameters[7].Value = model.UpLoadBatchNo;

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
        public bool Update(Twee.Model.Prdprice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_prdprice set ");
            strSql.Append("prdguid=@prdguid,");
            strSql.Append("edttime=@edttime,");
            strSql.Append("p1=@p1,");
            strSql.Append("p2=@p2,");
            strSql.Append("price=@price,");
            strSql.Append("ruleid=@ruleid");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@p1", SqlDbType.Decimal,5),
					new SqlParameter("@p2", SqlDbType.Decimal,5),
					new SqlParameter("@price", SqlDbType.Decimal,5),
					new SqlParameter("@ruleid", SqlDbType.Int,4),
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.prdguid;
            parameters[1].Value = model.edttime;
            parameters[2].Value = model.p1;
            parameters[3].Value = model.p2;
            parameters[4].Value = model.price;
            parameters[5].Value = model.ruleid;
            parameters[6].Value = model.guid;

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
        public bool Delete(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdprice ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdprice ");
            strSql.Append(" where guid in (" + guidlist + ")  ");
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
        public Twee.Model.Prdprice GetModel(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,prdguid,edttime,p1,p2,price,ruleid from wn_prdprice ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            Twee.Model.Prdprice model = new Twee.Model.Prdprice();
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
        public Twee.Model.Prdprice DataRowToModel(DataRow row)
        {
            Twee.Model.Prdprice model = new Twee.Model.Prdprice();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["prdguid"] != null && row["prdguid"].ToString() != "")
                {
                    model.prdguid = new Guid(row["prdguid"].ToString());
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
                if (row["p1"] != null && row["p1"].ToString() != "")
                {
                    model.p1 = decimal.Parse(row["p1"].ToString());
                }
                if (row["p2"] != null && row["p2"].ToString() != "")
                {
                    model.p2 = decimal.Parse(row["p2"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["ruleid"] != null && row["ruleid"].ToString() != "")
                {
                    model.ruleid = int.Parse(row["ruleid"].ToString());
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
            strSql.Append("select guid,prdguid,edttime,p1,p2,price,ruleid ");
            strSql.Append(" FROM wn_prdprice ");
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
            strSql.Append(" guid,prdguid,edttime,p1,p2,price,ruleid ");
            strSql.Append(" FROM wn_prdprice ");
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
            strSql.Append("select count(1) FROM wn_prdprice ");
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
            strSql.Append(")AS Row, T.*  from wn_prdprice T ");
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
            parameters[0].Value = "wn_prdprice";
            parameters[1].Value = "guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public int ExecSql(string sql) {
           return DbHelperSQL.ExecuteSql(sql);
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
            strSql.Append("select guid,prdguid,p1,p2,price,ruleid from  wn_prdprice ");
            //strSql.Append(" where id=@id and countfrom<=@buyCount and countto>=@buyCount");
            strSql.Append(" where ruleid=@id and p1<=@buyCount and p2>=@buyCount");

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@buyCount", SqlDbType.Int,4)
			};
            parameters[0].Value = ruleId;
            parameters[1].Value = buyCount;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["price"].ToString().ToDecimal();
            }
            return null;
        }

        #endregion  ExtensionMethod
    }
}

