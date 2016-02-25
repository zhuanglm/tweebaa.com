using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public partial class CollageShareDataMgr
    {
        public CollageShareDataMgr()
        {
        }

        /// <summary>
        /// 当用户click分享链接回来的时候，给分享者和设计者加分
        /// </summary>
        public int CollageSplitShareCommission(string sOrderID)
        {
            IDataParameter[] parameters = new IDataParameter[]{ 
                new SqlParameter("@orderno", SqlDbType.NVarChar,50)};

            parameters[0].Value = sOrderID;

            string storedProcName = "spCollageSplitCommission";

            int iRet = DbHelperSQL.RunProcedure_NonQuery(storedProcName, parameters);

            return iRet;

        }

        public DataSet GetListByPage(string strWhere, string userGuid, string orderby, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * from (SELECT a.guid, a.sourcetype, a.prtguid, a.shareurl, a.sharetype, a.addtime, a.userguid, a.visitcount, a.successcount, a.prdcount, a.prdsumMoney, b.CollageDesing_Title, ROW_NUMBER() OVER (ORDER BY  addtime desc ) AS 'RowNumber'");
            
            strSql.Append(" FROM  wn_share AS a LEFT OUTER JOIN");
            strSql.Append(" wn_CollageDesign AS b ON a.ColllageDesign_ID = b.CollageDesign_ID");
            strSql.Append(" WHERE   a.userguid = '"+userGuid+"'");
            if (strWhere.Trim() != "")
            {
                strSql.Append("" + strWhere);
            }
            strSql.Append(") as c WHERE RowNumber BETWEEN " + startIndex);
            strSql.Append(" AND " + endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 当用户click分享链接回来的时候，给分享者和设计者加分
        /// </summary>
        public int AddPointsList(string sShareID)
        {
            IDataParameter[] parameters = new IDataParameter[]{ 
                new SqlParameter("@share_guid", SqlDbType.UniqueIdentifier,16),
                new SqlParameter("@return_val", SqlDbType.Int,4)};

            parameters[0].Value = new Guid(sShareID);
            parameters[1].Value = 0;
            string storedProcName="CollageDesign_Add_SharePoints";

            int iRet = DbHelperSQL.RunProcedure_NonQuery(storedProcName, parameters);

            return iRet;

        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageShare model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_share(");
            strSql.Append("guid,prtguid,shareurl,sharetype,addtime,userguid,visitcount,successcount,prdcount,prdsumMoney,sourcetype,ColllageDesign_ID)");
            strSql.Append(" values (");
            strSql.Append("@guid,@prtguid,@shareurl,@sharetype,@addtime,@userguid,@visitcount,@successcount,@prdcount,@prdsumMoneys,@sourcetype,@ColllageDesign_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@shareurl", SqlDbType.NVarChar,450),
					new SqlParameter("@sharetype", SqlDbType.NVarChar,50),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@visitcount", SqlDbType.Int,4),
					new SqlParameter("@successcount", SqlDbType.Int,4),
					new SqlParameter("@prdcount", SqlDbType.Int,4),
					new SqlParameter("@prdsumMoneys", SqlDbType.Decimal,9),
                    new SqlParameter("@sourcetype", SqlDbType.Int,4),
                    new SqlParameter("@ColllageDesign_ID", SqlDbType.Int,4)};
            if (model.guid == null)
                parameters[0].Value = Guid.NewGuid();
            else
                parameters[0].Value = model.guid;
            
            parameters[1].Value = Guid.NewGuid();

            parameters[2].Value = model.shareurl;
            parameters[3].Value = model.sharetype;
            parameters[4].Value = model.addtime;
            parameters[5].Value = model.userguid;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = model.prdcount;
            parameters[9].Value = model.prdsumMoney;

            parameters[10].Value = model.Sourcetype;
            parameters[11].Value = model.CollageDesign_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageShare model)
        {
            /*
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageShare set ");
            strSql.Append("CollageDesign_ID=@CollageDesign_ID,CollageShare_Type=@CollageShare_Type,CollageShare_URL=@CollageShare_URL,CollageShare_CreateTime=@CollageShare_CreateTime,userguid=@userguid,CollageShare_VisitCount=@CollageShare_VisitCount,CollageShare_SuccessCount=@CollageShare_SuccessCount ");
            strSql.Append(" where CollageShare_ID=@CollageShare_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                    new SqlParameter("@CollageShare_Type",SqlDbType.NVarChar,50),
                    new SqlParameter("@CollageShare_URL",SqlDbType.NVarChar,500),
                    new SqlParameter("@CollageShare_CreateTime",SqlDbType.DateTime,8),
                    new SqlParameter("@userguid",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@CollageShare_VisitCount",SqlDbType.Int,4),
                    new SqlParameter("@CollageShare_SuccessCount",SqlDbType.Int,4),                                        
                    new SqlParameter("@CollageShare_ID",SqlDbType.Int,4)
            };
            parameters[0].Value = model.design_id;
            parameters[1].Value = model.ShareType;
            parameters[2].Value = model.URL;
            parameters[3].Value = Convert.ToDateTime(model.CreateTime);
            parameters[4].Value = model.guid;
            parameters[5].Value = model.VisitCount;
            parameters[6].Value = model.SuccessCount;
            parameters[7].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
             * */
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CollageShare_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_CollageShare ");
            strSql.Append(" where CollageShare_ID=@CollageShare_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageTemp_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = CollageShare_ID;

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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM wn_CollageShare ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.CollageShare DataRowToModel(DataRow row)
        {
            Twee.Model.CollageShare model = new Twee.Model.CollageShare();

            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["prtguid"] != null && row["prtguid"].ToString() != "")
                {
                    model.prtguid = new Guid(row["prtguid"].ToString());
                }
                if (row["shareurl"] != null)
                {
                    model.shareurl = row["shareurl"].ToString();
                }
                if (row["sharetype"] != null)
                {
                    model.sharetype = row["sharetype"].ToString();
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["userguid"] != null && row["userguid"].ToString() != "")
                {
                    model.userguid = new Guid(row["userguid"].ToString());
                }
                if (row["visitcount"] != null && row["visitcount"].ToString() != "")
                {
                    model.visitcount = int.Parse(row["visitcount"].ToString());
                }
                if (row["successcount"] != null && row["successcount"].ToString() != "")
                {
                    model.successcount = int.Parse(row["successcount"].ToString());
                }
                if (row["prdcount"] != null && row["prdcount"].ToString() != "")
                {
                    model.prdcount = int.Parse(row["prdcount"].ToString());
                }
                if (row["prdsumMoney"] != null && row["prdsumMoney"].ToString() != "")
                {
                    model.prdsumMoney = decimal.Parse(row["prdsumMoney"].ToString());
                }


                if (row["ColllageDesign_ID"] != null && row["ColllageDesign_ID"].ToString() != "")
                {
                    model.CollageDesign_ID = int.Parse(row["ColllageDesign_ID"].ToString());
                }
            }
            return model;
        }        
    }
}
