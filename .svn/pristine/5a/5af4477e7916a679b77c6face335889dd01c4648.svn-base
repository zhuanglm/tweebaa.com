using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;
namespace Twee.DataMgr
{
    public partial class BugsReportDataMgr
    {
        public BugsReportDataMgr()
        {

        }
        public int GiveUserPoints(string bug_id,string points,string shopping_points,string sAdmin)
        {

            IDataParameter[] parameters = new IDataParameter[]{ 
                new SqlParameter("@Bugs_ID", SqlDbType.Int,4),
                new SqlParameter("@Points", SqlDbType.Int,4),
                new SqlParameter("@ShoppingPoint", SqlDbType.Int,4),
                new SqlParameter("@AssignUserID", SqlDbType.UniqueIdentifier,16)};

            parameters[0].Value = int.Parse(bug_id);
            parameters[1].Value = int.Parse(points);
            parameters[2].Value = int.Parse(shopping_points);
            parameters[3].Value = new Guid(sAdmin);

            string storedProcName = "spBugsReport_Reward";

            int iRet = DbHelperSQL.RunProcedure_NonQuery(storedProcName, parameters);
            return iRet;
        }
        public bool  UpdateBugStatus(string bug_id,string txtStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_BugsReport set status=" + txtStatus + " where BugsReport_ID=" + bug_id);

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
        public DataTable GetBugsDetails(string bug_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.*,b.username ");
            strSql.Append(" FROM  wn_BugsReport a left join wn_user b on a.UserGuid=b.guid ");
            strSql.Append("where BugsReport_ID=" + bug_id);
            //strSql.Append("ORDER BY total_points DESC)");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetRankingRecords(string sKeyword, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();

            //select * from (SELECT a.*,b.username, ROW_NUMBER() OVER (ORDER BY  total_points desc) AS 'RowNumber' from vwBugsTopRanking a left join wn_user b on a.UserGuid=b.guid ) as a WHERE RowNumber BETWEEN 1AND 5

            strSql.Append("SELECT Top 50 a.*,b.username, ROW_NUMBER() OVER (ORDER BY total_points desc) AS 'RowNumber'");
            strSql.Append(" from vwBugsTopRanking a left join wn_user b on a.UserGuid=b.guid ");
            if (sKeyword.Trim() != "")
            {
                string sBugsTitle = Comm.CommUtil.GetSqlLike("BugsTitle", sKeyword);
                string sBugsDescription = Comm.CommUtil.GetSqlLike("BugsDescription", sKeyword);
                strSql.Append("where " + sBugsTitle + " or " + sBugsDescription);
            }
           // strSql.Append(") as a ");
           // strSql.Append("AND " + endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public int GetRankingTotal()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) as count FROM (SELECT UserGuid, COUNT(*) AS total_num, SUM(SubmitZone) AS total_points ");
            strSql.Append(" FROM            wn_BugsRewardLists");
            strSql.Append("GROUP BY UserGuid");
            strSql.Append("ORDER BY total_points DESC)");

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

        public DataTable GetBugsRecords(string sKeyword, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * from (SELECT a.*,b.username, ROW_NUMBER() OVER (ORDER BY CreateTime desc) AS 'RowNumber'");
            strSql.Append(" from wn_BugsReport a left join wn_user b on a.UserGuid=b.guid ");
            if (sKeyword.Trim() != "")
            {
                string sBugsTitle = Comm.CommUtil.GetSqlLike("BugsTitle", sKeyword);
                string sBugsDescription = Comm.CommUtil.GetSqlLike("BugsDescription", sKeyword);
                strSql.Append("where " + sBugsTitle + " or " + sBugsDescription);
            }
            strSql.Append(") as a WHERE RowNumber BETWEEN " + startIndex);
            strSql.Append("AND " + endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public int GetBugsTotal(string sKeyword)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT count(*) as count FROM wn_BugsReport");
            if (sKeyword.Trim() != "")
            {
                string sBugsTitle = Comm.CommUtil.GetSqlLike("BugsTitle", sKeyword);
                string sBugsDescription = Comm.CommUtil.GetSqlLike("BugsDescription", sKeyword);
                strSql.Append(" where " + sBugsTitle + " or " + sBugsDescription);
            }
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
        ///        
        public int Add(Twee.Model.BugsReport model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_BugsReport(");
            strSql.Append("BugsType,BrowserType,BugsLevel,BugsTitle,BugsDescription,UserGuid,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@BugsType,@BrowserType,@BugsLevel,@BugsTitle,@BugsDescription,@UserGuid,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BugsType", SqlDbType.TinyInt,2),
                    new SqlParameter("@BrowserType", SqlDbType.NVarChar,50),
                    new SqlParameter("@BugsLevel", SqlDbType.TinyInt,2),
                    new SqlParameter("@BugsTitle", SqlDbType.NVarChar,300),
                    new SqlParameter("@BugsDescription", SqlDbType.NVarChar,3000),
                    new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.BugsType;
            parameters[1].Value = model.BrowserType;
            parameters[2].Value = model.BugsLevel;
            parameters[3].Value = model.BugsTitle;
            parameters[4].Value = model.BugsDescription;
            parameters[5].Value = model.UserGuid;
            parameters[6].Value = model.CreateTime;
            

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
    }
}
