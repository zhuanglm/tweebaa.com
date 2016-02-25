using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class PrdStoragDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid psGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_prdStorag");
            strSql.Append(" where psGuid=@psGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@psGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = psGuid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.PrdStorag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prdStorag(");
            strSql.Append("psGuid,prdGuid,storagGuid,number,promptNumber,prostoreinfo,ruleid )");
            strSql.Append(" values (");
            strSql.Append("@psGuid,@prdGuid,@storagGuid,@number,@promptNumber,@prostoreinfo,@ruleid)");
            SqlParameter[] parameters = {
					new SqlParameter("@psGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@promptNumber", SqlDbType.Int,4),
                                        new SqlParameter("@prostoreinfo", SqlDbType.Xml),
                                        new SqlParameter("@ruleid", SqlDbType.Int),
                                        };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = model.number;
            parameters[4].Value = model.promptNumber;
            parameters[5].Value = model.prostoreinfo;
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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.PrdStorag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_prdStorag set ");
            strSql.Append("prdGuid=@prdGuid,");
            strSql.Append("storagGuid=@storagGuid,");
            strSql.Append("number=@number,");
            strSql.Append("promptNumber=@promptNumber");
            strSql.Append("prostoreinfo=@prostoreinfo");
            strSql.Append("ruleid=@ruleid");
            strSql.Append(" where psGuid=@psGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@storagGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@promptNumber", SqlDbType.Int,4),
                    new SqlParameter("@prostoreinfo", SqlDbType.Xml),
                    new SqlParameter("@ruleid", SqlDbType.Int),
					new SqlParameter("@psGuid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.prdGuid;
            parameters[1].Value = model.storagGuid;
            parameters[2].Value = model.number;
            parameters[3].Value = model.promptNumber;
            parameters[4].Value = model.prostoreinfo;
            parameters[5].Value = model.ruleid;
            parameters[6].Value = model.psGuid;

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
        public bool Delete(Guid psGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdStorag ");
            strSql.Append(" where psGuid=@psGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@psGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = psGuid;

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
        public bool DeleteList(string psGuidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdStorag ");
            strSql.Append(" where psGuid in (" + psGuidlist + ")  ");
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
        public Twee.Model.PrdStorag GetModel(Guid psGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 psGuid,prdGuid,storagGuid,number,promptNumber,prostoreinfo,ruleid from wn_prdStorag ");
            strSql.Append(" where psGuid=@psGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@psGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = psGuid;

            Twee.Model.PrdStorag model = new Twee.Model.PrdStorag();
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
        public Twee.Model.PrdStorag GetModelByPrdId(Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 psGuid,prdGuid,storagGuid,number,promptNumber,prostoreinfo,ruleid from wn_prdStorag ");
            strSql.Append(" where prdGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = prdGuid;

            Twee.Model.PrdStorag model = new Twee.Model.PrdStorag();
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
        public Twee.Model.PrdStorag DataRowToModel(DataRow row)
        {
            Twee.Model.PrdStorag model = new Twee.Model.PrdStorag();
            if (row != null)
            {
                if (row["psGuid"] != null && row["psGuid"].ToString() != "")
                {
                    model.psGuid = new Guid(row["psGuid"].ToString());
                }
                if (row["prdGuid"] != null && row["prdGuid"].ToString() != "")
                {
                    model.prdGuid = new Guid(row["prdGuid"].ToString());
                }
                if (row["storagGuid"] != null && row["storagGuid"].ToString() != "")
                {
                    model.storagGuid = new Guid(row["storagGuid"].ToString());
                }
                if (row["number"] != null && row["number"].ToString() != "")
                {
                    model.number = int.Parse(row["number"].ToString());
                }
                if (row["promptNumber"] != null && row["promptNumber"].ToString() != "")
                {
                    model.promptNumber = int.Parse(row["promptNumber"].ToString());
                }
                if (row["prostoreinfo"] != null && row["prostoreinfo"].ToString() != "")
                {
                    model.prostoreinfo = row["prostoreinfo"].ToString();
                }
                if (row["ruleid"] != null && row["ruleid"].ToString() != "")
                {
                    model.ruleid =Convert.ToInt32 (row["ruleid"]);
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
            strSql.Append("select psGuid,prdGuid,storagGuid,number,promptNumber,prostoreinfo,ruleid ");
            strSql.Append(" FROM wn_prdStorag ");
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
            strSql.Append(" psGuid,prdGuid,storagGuid,number,promptNumber,prostoreinfo,ruleid ");
            strSql.Append(" FROM wn_prdStorag ");
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
            strSql.Append("select count(1) FROM wn_prdStorag ");
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
                strSql.Append("order by T.psGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prdStorag T ");
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
            parameters[0].Value = "wn_prdStorag";
            parameters[1].Value = "psGuid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region 前台 订单
        /// <summary>
        /// 根据订单产品数量修改库存（在付款成功后调用该方法）
        /// </summary>
        /// <param name="guidno"></param>
        public bool UpdateStoragByOrder(string guidno)
        {
            string strSql = string.Format("update dbo.wn_prdStorag  set number=number-b.quantity from dbo.wn_prdStorag inner join  (select prdGuid,quantity,ruleid from wn_orderBody where headGuid=(select guid from  dbo.wn_orderhead where guidno='{0}')) b on dbo.wn_prdStorag.prdGuid=b.prdGuid and b.ruleid= dbo.wn_prdStorag.ruleid ", guidno);
            int count = DbHelperSQL.ExecuteSql(strSql);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 后台方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool MgeExists(Guid prdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_prdStorag");
            strSql.Append(" where prdGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = prdGuid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool MgeAdd(Guid prdGuid, string storagGuid, int number, int promptNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prdStorag(");
            strSql.Append("prdGuid,storagGuid,number,promptNumber)");
            strSql.Append(" values (");
            strSql.Append("@prdGuid,@storagGuid,@number,@promptNumber)");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@storagGuid", SqlDbType.NVarChar,500),
                    new SqlParameter("@number", SqlDbType.Int),
                    new SqlParameter("@promptNumber", SqlDbType.Int)  
         };
            parameters[0].Value = prdGuid;
            parameters[1].Value = storagGuid;
            parameters[2].Value = number;
            parameters[3].Value = promptNumber;
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
        public bool MgeUpdate(Guid psGuid, string storagGuid, int number, int promptNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_prdStorag set ");

            strSql.Append("storagGuid=@storagGuid,number=@number,promptNumber=@promptNumber");
            strSql.Append(" where psGuid=@psGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@psGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@storagGuid", SqlDbType.NVarChar,500),
                    new SqlParameter("@number", SqlDbType.Int),
                    new SqlParameter("@promptNumber", SqlDbType.Int)                                      
                 };
            parameters[0].Value = psGuid;
            parameters[1].Value = storagGuid;
            parameters[2].Value = number;
            parameters[3].Value = promptNumber;

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
        public bool MgeDelete(Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdStorag ");
            strSql.Append(" where prdGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = prdGuid;

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
        /// 获取产品库存信息
        /// </summary>
        /// <param name="prdGuid">产品id</param>
        /// <param name="prdGuid">产品名称</param>
        /// <param name="storaName">仓库名称</param>
        /// <param name="belongArea">所属区域</param>
        /// <param name="sendArea">配送区域</param>
        /// <param name="storaNumber0">库存起始值</param>
        /// <param name="storaNumber1">库存终止值</param>
        /// <param name="isPrompt">true查询小于等于警界值的产品，false反之,空查询全部</param>
        /// <returns></returns>
        public DataTable MgeGetPrdStora(string prdGuid, string prdName, string storaName, string belongArea, string sendArea, string storaNumber0, string storaNumber1, string isPrompt)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select ps.psGuid, p.prdGuid,p.name,s.storagName,s.storagGuid,ps.number,ps.promptNumber,s.belongArea,");
            sqlStr.Append(" (select areaName from  dbo.wn_sendArea a  where areaGuid=s.belongArea) belongAreaName,");
            //sqlStr.Append(" (select  ''''+ replace(s.sendArea,',',''',''')+'''') sendAreaName");
            sqlStr.Append(" s.sendArea as sendAreaName");
            sqlStr.Append(" from  dbo.wn_prd p");
            sqlStr.Append(" left join dbo.wn_prdStorag ps on p.prdGuid=ps.prdGuid");
            sqlStr.Append(" left join  dbo.wn_storag s on ps.storagGuid=s.storagGuid");
            sqlStr.Append(" where 1=1");
            if (!string.IsNullOrEmpty(prdGuid))
            {
                sqlStr.Append(" and p.prdGuid ='" + prdGuid + "'");
            }
            if (!string.IsNullOrEmpty(prdName))
            {
                sqlStr.Append(" and p.name like'%" + prdName + "%'");
            }
            if (!string.IsNullOrEmpty(storaName))
            {
                sqlStr.Append(" and s.storagName ='" + storaName + "'");
            }
            if (!string.IsNullOrEmpty(belongArea))
            {
                sqlStr.Append(" and  s.belongArea ='" + belongArea + "'");
            }
            if (!string.IsNullOrEmpty(sendArea))
            {
                // sqlStr.Append(" and s.sendArea ='" + belongArea + "'");
            }
            if (!string.IsNullOrEmpty(storaNumber0))
            {
                sqlStr.Append(" and  ps.number >=" + storaNumber0);
            }
            if (!string.IsNullOrEmpty(storaNumber1))
            {
                sqlStr.Append(" and  ps.number <=" + storaNumber1);
            }
            if (!string.IsNullOrEmpty(isPrompt))
            {
                if (isPrompt == "true")
                {
                    sqlStr.Append(" and  ps.number <=  ps.promptNumber");
                }
                else if (isPrompt == "false")
                {
                    // sqlStr.Append(" and  ps.number >=  ps.promptNumber");
                }

            }

            DataSet ds = DbHelperSQL.Query(sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        #endregion
    }
}
