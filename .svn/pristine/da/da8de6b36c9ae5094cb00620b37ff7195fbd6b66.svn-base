using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Comm;
using System.Data;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class ShareDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_share");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Share model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_share(");
            strSql.Append("guid,prtguid,shareurl,sharetype,addtime,userguid,visitcount,successcount,prdcount,prdsumMoney)");
            strSql.Append(" values (");
            strSql.Append("@guid,@prtguid,@shareurl,@sharetype,@addtime,@userguid,@visitcount,@successcount,@prdcount,@prdsumMoney)");
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
					new SqlParameter("@prdsumMoney", SqlDbType.Decimal,9)};
            if (model.guid == null)
                parameters[0].Value = Guid.NewGuid();
            else
                parameters[0].Value = model.guid;
            if (model.prtguid != null)
                parameters[1].Value = model.prtguid;
            else
                parameters[1].Value = Guid.NewGuid();

            parameters[2].Value = model.shareurl;
            parameters[3].Value = model.sharetype;
            parameters[4].Value = model.addtime;
            parameters[5].Value = model.userguid;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = model.prdcount;
            parameters[9].Value = model.prdsumMoney;

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
        public bool Update(Twee.Model.Share model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_share set ");
            strSql.Append("prtguid=@prtguid,");
            strSql.Append("shareurl=@shareurl,");
            strSql.Append("sharetype=@sharetype,");
            strSql.Append("addtime=@addtime,");
            strSql.Append("userguid=@userguid,");
            strSql.Append("visitcount=@visitcount,");
            strSql.Append("successcount=@successcount,");
            strSql.Append("prdcount=@prdcount,");
            strSql.Append("prdsumMoney=@prdsumMoney");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@shareurl", SqlDbType.NVarChar,450),
					new SqlParameter("@sharetype", SqlDbType.NVarChar,50),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@visitcount", SqlDbType.Int,4),
					new SqlParameter("@successcount", SqlDbType.Int,4),
					new SqlParameter("@prdcount", SqlDbType.Int,4),
					new SqlParameter("@prdsumMoney", SqlDbType.Decimal,9),
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.prtguid;
            parameters[1].Value = model.shareurl;
            parameters[2].Value = model.sharetype;
            parameters[3].Value = model.addtime;
            parameters[4].Value = model.userguid;
            parameters[5].Value = model.visitcount;
            parameters[6].Value = model.successcount;
            parameters[7].Value = model.prdcount;
            parameters[8].Value = model.prdsumMoney;
            parameters[9].Value = model.guid;

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
            strSql.Append("delete from wn_share ");
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
            strSql.Append("delete from wn_share ");
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
        public Twee.Model.Share GetModel(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,prtguid,shareurl,sharetype,addtime,userguid,visitcount,successcount,prdcount,prdsumMoney from wn_share ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            Twee.Model.Share model = new Twee.Model.Share();
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
        public Twee.Model.Share DataRowToModel(DataRow row)
        {
            Twee.Model.Share model = new Twee.Model.Share();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select guid,prtguid,shareurl,sharetype,addtime,userguid,visitcount,successcount,prdcount,prdsumMoney ");
            strSql.Append(" FROM wn_share ");
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
            strSql.Append(" guid,prtguid,shareurl,sharetype,addtime,userguid,visitcount,successcount,prdcount,prdsumMoney ");
            strSql.Append(" FROM wn_share ");
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
            strSql.Append("select count(1) FROM wn_share ");
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
        /// 分页获取数据列表（会员中心）
        /// </summary>
        public DataSet GetListByPage(string strWhere,string userGuid, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.guid, TT.addtime,TT.sharetype,TT.shareurl,TT.userguid, p.prdguid, p.name, p.wnstat, p.saleprice,TT.visitcount,TT.successcount,TT.successcount*p.saleprice*rate.commissionratio mymoney,f.fileurl FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.addtime desc");
            }
            strSql.Append(")AS Row, T.*  from wn_share T ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                strSql.Append(" WHERE T.userguid='" + userGuid + "'");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append (" " + strWhere);
            }
            strSql.Append(" ) TT");          
            strSql.Append(" left join  dbo.wn_prd p on TT.prtguid=p.prdGuid ");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on p.prdGuid= f.prtguid ");
            strSql.Append(" left join (select ug.userguid, sp.commissionratio from  (select sharegrade,userguid from wn_usergrade where userguid='" + userGuid.ToUpper() + "') ug  left join   dbo.wn_sharegradeparam sp  on sp.grade=ug.sharegrade) rate on TT.userguid=rate.userguid ");
            strSql.AppendFormat(" where rate.userguid='" + userGuid.ToUpper() + "' and TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取数据列表总数（会员中心）
        /// </summary>
        public int GetShareCount(string strWhere, string userGuid, string sharetype, string begTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from wn_share where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere );
            }
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                strSql.Append(" and userguid = '" + userGuid + "'");
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                string sBegTime = CommUtil.ToDBDateFormat(begTime);
                strSql.Append(" and addtime>='" + sBegTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                strSql.Append(" and addtime<='" + sEndTime + " 23:59'");
            }
            if (!string.IsNullOrEmpty(sharetype))
            {
                strSql.Append(" and sharetype='" + sharetype + "'");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().ToInt();
            }
            return 0;
        }

        public DataSet GetShareCollageTotal(string userGuid)
        {

            StringBuilder sSql = new StringBuilder();
            sSql.Append(" select Sum(visitcount) as TotalVisitCount, sum(successcount) as TotalSoldQuantity,sum(prdsumMoney) as TotalShareCommission ");
            sSql.Append(" from wn_share where sourcetype=2 and userguid='" + userGuid + "'");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            return ds;
        }

        /// <summary>
        /// member center: grand total of total clicks, total sold QTY and total share commission of currect user
        /// </summary>
        public DataSet GetShareGrandTotal(string userGuid)
        {
            StringBuilder sSql = new StringBuilder();

            // select total clicks and sold qty
            sSql.Append(" select Sum(a.VisitCountSum) as TotalVisitCount, sum(isnull(b.SoldQuantitySum, 0)) as TotalSoldQuantity ");
            sSql.Append("from vw_ProductShareVisitCountSum a ");
            sSql.Append("left join vw_ProductShareSoldQuantitySum b on b.userguid = a.userGuid and b.prdguid=a.prdguid and b.sharetype=a.sharetype ");
            sSql.Append("where 1=1 ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                sSql.Append(" and a.userguid = '" + userGuid + "';");
            }

            // select share commission
            sSql.Append("select sum(money) as TotalShareCommission from wn_Profit ");
            sSql.Append(" where type='Share Income' ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                sSql.Append(" and userId = '" + userGuid + "';");
            }
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            return ds;
        }


        /// <summary>
        /// member center: get share summary total count. total clicks and total sold QTY
        /// </summary>
        public DataSet GetShareSummaryTotal(string userGuid, string prdGuid, string sharetype, string begTime, string endTime)
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append(" select Count(distinct a.Name) as TotalCount, Sum(b.VisitCountSum) as TotalVisitCount, sum(isnull(c.SoldQuantitySum, 0)) as TotalSoldQuantity ");
            sSql.Append("from wn_prd a ");
            sSql.Append("inner join vw_ProductShareVisitCountSum b on a.prdguid = b.prdGuid ");
            sSql.Append("left join vw_ProductShareSoldQuantitySum c on c.userguid = b.userGuid and c.prdguid=b.prdguid and c.sharetype=b.sharetype ");
            sSql.Append("left join vw_ProductShareLastShareGuid d on d.userguid = b.userGuid and d.prdguid=b.prdguid and d.sharetype=b.sharetype ");
            sSql.Append("where 1=1 ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                sSql.Append(" and b.userguid = '" + userGuid + "'");
            }
            if (!string.IsNullOrEmpty(prdGuid.Trim()))
            {
                sSql.Append(" and b.prdguid = '" + prdGuid + "'");
            }
            if (!string.IsNullOrEmpty(sharetype.Trim()))
            {
                sSql.Append(" and b.sharetype = '" + sharetype + "'");
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                string sBegTime = CommUtil.ToDBDateFormat(begTime);
                sSql.Append("  and d.addtime >='" + sBegTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                sSql.Append("  and d.addtime <='" + sEndTime + " 23:59'");
            }

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            return ds;
        }

        /// <summary>
        /// member center: get share summary
        /// </summary>
        public DataSet GetShareSummary(string userGuid, string prdGuid, string sharetype, string begTime, string endTime, int iStartIdx, int iEndIdx)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select a.name, b.userguid, b.prdguid, b.sharetype, d.ShareGuid, b.VisitCountSum, isnull(c.SoldQuantitySum, 0) as SoldQuantitySum ");
            sSql.Append("from wn_prd a ");
            sSql.Append("inner join vw_ProductShareVisitCountSum b on a.prdguid = b.prdGuid ");
            sSql.Append("left join vw_ProductShareSoldQuantitySum c on c.userguid = b.userGuid and c.prdguid=b.prdguid and c.sharetype=b.sharetype ");
            sSql.Append("inner join vw_ProductShareLastShareGuid d on d.userguid = b.userGuid and d.prdguid=b.prdguid and d.sharetype=b.sharetype ");
            sSql.Append("where 1=1 ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                sSql.Append(" and b.userguid = '" + userGuid + "'");
            }
            if (!string.IsNullOrEmpty(prdGuid.Trim()))
            {
                sSql.Append(" and b.prdguid = '" + prdGuid + "'");
            }
            if (!string.IsNullOrEmpty(sharetype.Trim()))
            {
                sSql.Append(" and b.sharetype = '" + sharetype + "'");
            }
            if (!string.IsNullOrEmpty(begTime.Trim())) 
            {
                string  sBegTime = CommUtil.ToDBDateFormat(begTime);
                sSql.Append("  and d.addtime >='" + sBegTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                sSql.Append("  and d.addtime <='" + sEndTime + " 23:59'");
            }

            sSql.Append(" and a.prdguid in (");
            sSql.Append("select T.prdguid from (");
            sSql.Append("select uniqueProduct.prdGuid, ROW_NUMBER() OVER (order by uniqueProduct.name) as Row  from ( ");
            sSql.Append("select distinct x.prdGuid, x.name ");
            sSql.Append("from wn_prd x ");
            sSql.Append("inner join vw_ProductShareVisitCountSum y on y.prdguid = x.prdGuid ");
            sSql.Append("inner join vw_ProductShareLastShareGuid z on z.userguid = y.userGuid and z.prdguid=y.prdguid and z.sharetype=y.sharetype ");
            sSql.Append("where 1=1 ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                sSql.Append(" and y.userguid = '" + userGuid + "'");
            }
            if (!string.IsNullOrEmpty(prdGuid.Trim()))
            {
                sSql.Append(" and y.prdguid = '" + prdGuid + "'");
            }
            if (!string.IsNullOrEmpty(sharetype.Trim()))
            {
                sSql.Append(" and y.sharetype = '" + sharetype + "'");
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                string sBegTime = CommUtil.ToDBDateFormat(begTime);
                sSql.Append("  and z.addtime >='" + sBegTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                sSql.Append("  and z.addtime <='" + sEndTime + " 23:59'");
            }
            sSql.Append(") as uniqueProduct");
            sSql.Append(") as T");  // end of select row-number
            sSql.AppendFormat(" where T.Row between {0} and {1}", iStartIdx, iEndIdx);
            sSql.Append(")");  // a.prdguid in 
            sSql.Append(" order by a.name");


            DataSet ds = DbHelperSQL.Query(sSql.ToString());
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
            parameters[0].Value = "wn_share";
            parameters[1].Value = "guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod


        #region  Extend扩展方法

        /// <summary>
        /// short a url for share
        /// <returns></returns>
        public string GetShortUrl(string sUrl)
        {
            StringBuilder sSql = new StringBuilder();
            int iShortUrlId = -1;
            // check if this URL is already shorten
            sSql.Append("select ShortUrl_ID from wn_ShortUrl");
            sSql.Append(" where ShortUrl_Url ='" + CommUtil.Quo(sUrl) + "'");
            DataSet ds = Comm.DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iShortUrlId = dt.Rows[0]["ShortUrl_ID"].ToString().ToInt();
                }
            }

            if (iShortUrlId == -1)
            {
                // get a new ShortUrlID
                iShortUrlId = Comm.DbHelperSQL.GetSeq("ShortUrlID");
                
                // insert a new short url record
                sSql.Clear();
                sSql.Append("insert into wn_ShortUrl(ShortUrl_ID, ShortUrl_Url) ");
                sSql.Append(" values(" + iShortUrlId.ToString() + ",'" + CommUtil.Quo(sUrl) + "')");
                int iRow = Comm.DbHelperSQL.ExecuteSql(sSql.ToString());
            }
            string sShortUrl = "https://www.tweebaa.com";
            if ( iShortUrlId != -1) sShortUrl = "https://www.tweebaa.com/t.aspx?id=" + iShortUrlId.ToString();
            return sShortUrl;
        }

        /// <summary>
        /// Get full url its short url id
        /// <returns></returns>
        public string GetFulltUrl(int iShortUrlId)
        {
            string sFullUrl = "https://www.tweebaa.com";
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select ShortUrl_Url from wn_ShortUrl");
            sSql.Append(" where ShortUrl_ID =" + iShortUrlId.ToString());
            DataSet ds = Comm.DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    sFullUrl = dt.Rows[0]["ShortUrl_Url"].ToString();
                }
            }
            return sFullUrl;
        }

        /// <summary>
        /// 根据url修改访问数加1，并计算分享者几分等级
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool UpdateVisitCount(string shareUrlGuid)
        {
            string strSql = "update wn_share set  visitcount+=1  where sourcetype=1 and guid='" + shareUrlGuid + "'";
            int i = DbHelperSQL.ExecuteSql(strSql);
            if (i>0)
            {               
                string strSql2 = "select visitcount,userguid from  wn_share  where guid='" + shareUrlGuid + "'";
                DataTable dt = DbHelperSQL.Query(strSql2).Tables[0];
                if (dt!=null&&dt.Rows.Count>0)
	            {
                    int visitCount=dt.Rows[0]["visitCount"].ToString().ToInt();
                    Guid shareUserID=dt.Rows[0]["userguid"].ToString().ToGuid().Value;
		            string strsql = "User_ShareIntegralCal";
                    SqlParameter[] paras = new SqlParameter[] { 
                        new SqlParameter("@shareUserID",SqlDbType.UniqueIdentifier),
                        new SqlParameter("@visitCount",SqlDbType.Int)
                    };
                    paras[0].Value = shareUserID;
                    paras[0].Direction = ParameterDirection.Input;
                    paras[1].Value = visitCount;
                    paras[1].Direction = ParameterDirection.Input;
                    int count = DbHelperSQL.RunProcedure_NonQuery(strsql, paras);
                    if (count > 0)
                    {
                        return true;
                    }           
	            }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查询所有产生订单的分享链接，包括未支付订单、已支付订单。 包含信息：
        /// 【分享链接url、url的id、分享者、分享方式、分享时间、链接被访问数、购买数量、
        /// 分享产品名称、id、分享金额（单价*数量）】
        /// </summary>
        /// <param name="type">orderType：0为分享链接产生的未完成订单、1为查询所有分享链接产生的已完成订单；2为查询所有分享连接产生的已支付订单并且已过退货期（即可提取）,空为查询链接产生的所有订单;
        /// shareType: sina、tx、qzone、rr、douban
        /// </param>
        /// <returns></returns>
        public DataTable GteShareOrder(string orderType,string shareType)
        {
            int afterDay = Comm.ConfigParamter.payMoneyAfterDay;//退货期
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select h.guidno orderNo,b.prdGuid,p.name,p.saleprice*b.quantity [money],b.shareId,s.shareurl,s.sharetype,s.userguid shareUser，s.visitcount,s.successcount,s.addtime ");
            strSql.Append(" from dbo.wn_orderBody b");
            strSql.Append(" left join   wn_orderhead h  on b.headGuid=h.guid ");
            strSql.Append(" left join wn_prd p on b.prdGuid=p.prdGuid ");
            strSql.Append(" left join wn_share s on b.shareId=s.guid");
            strSql.Append("where  b.shareId is not null  and h.wnstat=3");
            if (orderType=="0")
            {
                strSql.Append(" and h.wnstat<3");//产生的未完成订单
            }
            else if (orderType=="1")
            {
                strSql.Append(" and h.wnstat=3");//产生的已完成订单
            }
            else if (orderType == "2")
            {
                strSql.Append(" and DATEDIFF(DAY, h.payTime,GETDATE())>" + afterDay);//产生的可提取佣金订单
            }
            if (!string.IsNullOrEmpty(shareType))
            {
                strSql.Append(" and sharetype='"+shareType+"'");//分享方式
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds!=null&&ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            return null;        
        }

        /// <summary>
        /// 统计分享数据
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetShareCounByType(string userID)
        {
            string strSql = string.Format("select sharetype,COUNT(*) shareCount,sum(visitcount) visitCount,SUM(successcount) buyCount from wn_share where userguid='{0}' group by sharetype ", userID);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;        
        
        }

        /// <summary>
        /// 根据产品id查询其在表中是否已经存在分享链接
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public string IsExitShareUrl(string prdGuid, string shareType, string userGuid)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select guid,shareurl from wn_share ");
            sSql.Append(" where prtguid='" + prdGuid + "'" );
            sSql.Append("   and shareType ='" + shareType + "'");
            sSql.Append("   and userGuid ='" + userGuid + "'");
            DataSet ds = Comm.DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["guid"].ToString();
            }
            return null;
        }
        #endregion


        #region 会员中心


        #endregion

        #region 后台方法

        /// <summary>
        /// 获取用户分享记录
        /// </summary>
        public DataTable MgeGetPersonShare(string strWhere, string orderby, int startIndex, int endIndex, out int iTotalCount)
        {
            string strSqlTotalCount = "select count(1) 'recordcount' from (";

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.prtguid,TT.shareurl,TT.sharetype,TT.addtime,TT.userguid,TT.visitcount,TT.successcount,TT.prdcount,TT.prdsumMoney,u.username,p.name,p.idx,f.fileurl FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.addtime desc");
            }
            strSql.Append(")AS Row, T.*  from dbo.wn_share T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join dbo.wn_prd p on TT.prtguid=p.prdGuid  left join dbo.wn_user u on TT.userguid=u.guid left join dbo.wn_file f on p.prdGuid=f.fileguid");


            strSqlTotalCount += strSql.ToString() + ") as a;";
            string sTempCount = DbHelperSQL.Query(strSqlTotalCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(sTempCount))
                iTotalCount = int.Parse(sTempCount);
            else
                iTotalCount = 0;
            
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 获取用户分享记录数目
        /// </summary>
        public int MgeGetAllShareCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.addtime desc");
            strSql.Append(")AS Row, T.*  from dbo.wn_share T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join dbo.wn_prd p on TT.prtguid=p.prdGuid  left join dbo.wn_user u on TT.userguid=u.guid left join dbo.wn_file f on p.prdGuid=f.fileguid");

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
