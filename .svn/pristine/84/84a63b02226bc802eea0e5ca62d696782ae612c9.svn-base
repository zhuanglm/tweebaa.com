using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class PrdSpecDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid specguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_prdSpec");
            strSql.Append(" where specguid=@specguid ");
            SqlParameter[] parameters = {
					new SqlParameter("@specguid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = specguid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.PrdSpec model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prdSpec(");
            strSql.Append("specguid,prdguid,colorguid,specname,specvalue,edttime,number,price)");
            strSql.Append(" values (");
            strSql.Append("@specguid,@prdguid,@colorguid,@specname,@specvalue,@edttime,@number,@price)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@specguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@colorguid", SqlDbType.NVarChar,500),
					new SqlParameter("@specname", SqlDbType.NVarChar,50),
					new SqlParameter("@specvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal,8)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.colorguid;
            parameters[3].Value = model.specname;
            parameters[4].Value = model.specvalue;
            parameters[5].Value = model.edttime;
            parameters[6].Value = model.number;
            parameters[7].Value = model.price;

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
        public bool Update(Twee.Model.PrdSpec model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_prdSpec set ");
            strSql.Append("prdguid=@prdguid,");
            strSql.Append("colorguid=@colorguid,");
            strSql.Append("specname=@specname,");
            strSql.Append("specvalue=@specvalue,");
            strSql.Append("edttime=@edttime,");
            strSql.Append("number=@number,");
            strSql.Append("price=@price");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@colorguid", SqlDbType.NVarChar,500),
					new SqlParameter("@specname", SqlDbType.NVarChar,50),
					new SqlParameter("@specvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal,8),
					new SqlParameter("@specguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters[0].Value = model.prdguid;
            parameters[1].Value = model.colorguid;
            parameters[2].Value = model.specname;
            parameters[3].Value = model.specvalue;
            parameters[4].Value = model.edttime;
            parameters[5].Value = model.number;
            parameters[6].Value = model.price;
            parameters[7].Value = model.specguid;
            parameters[8].Value = model.idx;

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
        public bool Delete(int idx)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdSpec ");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@idx", SqlDbType.Int,4)
			};
            parameters[0].Value = idx;

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
        public bool Delete(Guid specguid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdSpec ");
            strSql.Append(" where specguid=@specguid ");
            SqlParameter[] parameters = {
					new SqlParameter("@specguid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = specguid;

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
        public bool DeleteList(string idxlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdSpec ");
            strSql.Append(" where idx in (" + idxlist + ")  ");
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
        public Twee.Model.PrdSpec GetModel(int idx)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 specguid,prdguid,colorguid,specname,specvalue,idx,edttime,number,price from wn_prdSpec ");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@idx", SqlDbType.Int,4)
			};
            parameters[0].Value = idx;

            Twee.Model.PrdSpec model = new Twee.Model.PrdSpec();
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
        public Twee.Model.PrdSpec DataRowToModel(DataRow row)
        {
            Twee.Model.PrdSpec model = new Twee.Model.PrdSpec();
            if (row != null)
            {
                if (row["specguid"] != null && row["specguid"].ToString() != "")
                {
                    model.specguid = new Guid(row["specguid"].ToString());
                }
                if (row["prdguid"] != null && row["prdguid"].ToString() != "")
                {
                    model.prdguid = new Guid(row["prdguid"].ToString());
                }
                if (row["colorguid"] != null)
                {
                    model.colorguid = row["colorguid"].ToString();
                }
                if (row["specname"] != null)
                {
                    model.specname = row["specname"].ToString();
                }
                if (row["specvalue"] != null)
                {
                    model.specvalue = row["specvalue"].ToString();
                }
                if (row["idx"] != null && row["idx"].ToString() != "")
                {
                    model.idx = int.Parse(row["idx"].ToString());
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
                if (row["number"] != null && row["number"].ToString() != "")
                {
                    model.number = int.Parse(row["number"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
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
            strSql.Append("select specguid,prdguid,colorguid,specname,specvalue,idx,edttime,number,price ");
            strSql.Append(" FROM wn_prdSpec ");
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
            strSql.Append(" specguid,prdguid,colorguid,specname,specvalue,idx,edttime,number,price ");
            strSql.Append(" FROM wn_prdSpec ");
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
            strSql.Append("select count(1) FROM wn_prdSpec ");
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
                strSql.Append("order by T.idx desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prdSpec T ");
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
            parameters[0].Value = "wn_prdSpec";
            parameters[1].Value = "idx";
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
        public bool MgeAdd(Guid prdGuid, string colorguid, string specname, string specvalue, int idx)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prdSpec(");
            strSql.Append("prdGuid,colorguid,specname,specvalue)");
            strSql.Append(" values (");
            strSql.Append("@prdGuid,@colorguid,@specname,@specvalue)");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@colorguid", SqlDbType.NVarChar,500),
                    new SqlParameter("@specname", SqlDbType.NVarChar,20),
                    new SqlParameter("@specvalue", SqlDbType.NVarChar,20),                  
                    new SqlParameter("@idx", SqlDbType.Int)                   
                                    
                                    };
            parameters[0].Value = prdGuid;
            parameters[1].Value = colorguid;
            parameters[2].Value = specname;
            parameters[3].Value = specvalue;
            parameters[4].Value = idx;

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

        //public bool Add(Guid prdGuid, string colorguid, string specname, string specvalue, decimal price, int number, int idx)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into wn_prdSpec(");
        //    strSql.Append("prdGuid,colorguid,specname,specvalue,price,number)");
        //    strSql.Append(" values (");
        //    strSql.Append("@prdGuid,@colorguid,@specname,@specvalue,@price,@number)");
        //    SqlParameter[] parameters = {
        //                new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
        //                new SqlParameter("@colorguid", SqlDbType.NVarChar,500),
        //                new SqlParameter("@specname", SqlDbType.NVarChar,20),
        //                new SqlParameter("@specvalue", SqlDbType.NVarChar,20),
        //                new SqlParameter("@price", SqlDbType.Decimal),
        //                new SqlParameter("@number", SqlDbType.Int),
        //                new SqlParameter("@idx", SqlDbType.Int)                   

        //                                };
        //    parameters[0].Value = prdGuid;
        //    parameters[1].Value = colorguid;
        //    parameters[2].Value = specname;
        //    parameters[3].Value = specvalue;
        //    parameters[4].Value = price;
        //    parameters[5].Value = number;
        //    parameters[6].Value = idx;

        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool MgeUpdate(Guid specguid, string specname, string specvalue, int idx)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_prdSpec set ");
            strSql.Append("specname=@specname");
            strSql.Append("specvalue=@specvalue");
            strSql.Append("idx=@idx");
            strSql.Append(" where specguid=@specguid ");
            SqlParameter[] parameters = {					
                    new SqlParameter("@specname", SqlDbType.NVarChar,20),
                    new SqlParameter("@specvalue", SqlDbType.NVarChar,20),    
                    new SqlParameter("@idx", SqlDbType.Int),   
                    new SqlParameter("@specguid", SqlDbType.UniqueIdentifier,16)
                                    };
            parameters[0].Value = specname;
            parameters[1].Value = specvalue;
            parameters[2].Value = idx;
            parameters[3].Value = specguid;
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
        public bool MgeDelete(Guid prdguid)
        {
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdSpec ");
            if (!string.IsNullOrEmpty(prdguid.ToString()))
            {
                strSql.Append(" where prdguid=@prdguid ");
                SqlParameter[] parameters = {
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16)			};
                parameters[0].Value = prdguid;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            else
            {
                rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            }

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
        /// 获得产品规格列表
        /// </summary>
        public DataTable MgeGetList(string prdguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s.*,c.colorname ");
            strSql.Append(" FROM  dbo.wn_prdSpec s  left join  dbo.wn_color c on s.colorguid=c.colorguid ");
            strSql.Append(" where s.prdguid='" + prdguid + "' order by s.idx asc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable MgeGetSpecColor(Guid prdguid, string specname, string specvalue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dbo.wn_prdSpec where  specname=@specname and specvalue=@specvalue  and  prdguid=@prdguid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@specname", SqlDbType.NVarChar,20),
                    new SqlParameter("@specvalue", SqlDbType.NVarChar,20)                                    
                                     };
            parameters[0].Value = prdguid;
            parameters[1].Value = specname;
            parameters[2].Value = specvalue;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        #endregion
    }
}
