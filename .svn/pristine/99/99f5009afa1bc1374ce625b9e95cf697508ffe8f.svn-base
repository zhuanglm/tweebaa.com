using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Comm;
using System.Data;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class UserGiftRewardDataMgr
    {

        /// <summary>
        /// get reward gift count
        /// </summary>
        public DataSet GetGiftStatusList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GiftStatus_ID, GiftStatus_Name ");
            strSql.Append("from wn_GiftStatus ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// get total shopping gift reward points
        /// </summary>
        public int GetTotalShoppingRewardPoint(string userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(UserGiftReward_ShoppingRewardPoint) as TotalShoppingRewardPoint ");
            strSql.Append("from wn_UserGiftReward ");
            strSql.Append("where userGuid='" + userID + "' ");
            strSql.Append("  and gift_ID = " +  ((int)ConfigParamter.Gift.MerchandseCredit).ToString());
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            //if (ds != null) {
            //    DataTable dt = ds.Tables[0];
            //    DataRow dr = dt.Rows[0];
            //    return (int)(dr[0]);
            //}
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.Rows[0];
                return dr[0].ToString().ToInt();
            }
            return 0;
        }


        /// <summary>
        /// get reward gift count
        /// </summary>
        public int GetMyGiftRewardCount(string userID, string giftName, string giftStatus, string begTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) ");
            strSql.Append(" FROM wn_userGiftReward a ");
            strSql.Append(" inner join wn_Gift b on a.Gift_ID = b.Gift_ID ");
            strSql.Append(" left join wn_prd e on a.ProductGuid = e.prdGuid");
            strSql.Append(" where a.UserGuid= '" + userID + "'");

            if (!string.IsNullOrEmpty(giftName.Trim()))
            {
                string sSqlLikeGift = CommUtil.GetSqlLike("b.Gift_Name", giftName);
                string sSqlLikeProductName = CommUtil.GetSqlLike("e.name", giftName);
                string sSqlLikeProductTag = CommUtil.GetSqlLike("e.txtTag", giftName);
                strSql.Append(" and (( " + sSqlLikeGift + ") or (" + sSqlLikeProductName + ") or (" + sSqlLikeProductTag + "))");
            }

            if (!string.IsNullOrEmpty(giftStatus.Trim()))
            {
                strSql.Append(" and a.GiftStatus_ID=" + giftStatus.Trim());
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                string sBegTime = Comm.CommUtil.ToDBDateFormat(begTime.Trim());
                strSql.Append(" and a.UserGiftReward_GrantDate>='" + sBegTime + " 0:00'");
            }

            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = Comm.CommUtil.ToDBDateFormat(endTime.Trim());
                strSql.Append(" and a.UserGiftReward_GrantDate<='" + sEndTime + " 23:59'");
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
        /// get my reward gift list
        /// </summary>
        public DataSet GetMyGiftRewardList(string userID, string giftName, string giftStatus, string orderBy, int startIndex, int endIndex, string begTime, string endTime)
        {

            StringBuilder strSql = new StringBuilder();

            // set order by
            if (string.IsNullOrEmpty(orderBy.Trim()))
            {
                orderBy = " a.UserGiftReward_GrantDate desc ";
            }

            strSql.Append("select * from (");
            strSql.Append("SELECT Row_number() over( order by " + orderBy + ") as Row, ");
            strSql.Append("a.UserGiftReward_GrantDate, a.UserGiftReward_Quantity, a.ProductGuid as ProductGuid, a.Gift_ID, a.UserGiftReward_ShoppingRewardPoint,  a.GiftStatus_ID, ");
            strSql.Append("b.Gift_Name, b.Gift_Detail, GiftSource_Name, d.GiftStatus_Name, e.name as ProductName");
            strSql.Append(" from wn_UserGiftReward a ");
            strSql.Append(" inner join wn_Gift b on a.Gift_ID = b.Gift_ID ");
            strSql.Append(" inner join wn_GiftSource c on a.GiftSource_ID = c.GiftSource_ID");
            strSql.Append(" inner join wn_GiftStatus d on a.GiftStatus_ID = d.GiftStatus_ID");
            strSql.Append(" left join wn_prd e on a.ProductGuid = e.prdGuid");
 
            strSql.Append(" where a.UserGuid= '" + userID + "'");

            if (!string.IsNullOrEmpty(giftName.Trim()))
            {
                string sSqlLikeGift = CommUtil.GetSqlLike("b.Gift_Name", giftName);
                string sSqlLikeProductName = CommUtil.GetSqlLike("e.name", giftName);
                string sSqlLikeProductTag = CommUtil.GetSqlLike("e.txtTag", giftName); 
                strSql.Append(" and (( " + sSqlLikeGift + ") or (" + sSqlLikeProductName +") or (" + sSqlLikeProductTag +  "))");
            }

            if (!string.IsNullOrEmpty(giftStatus.Trim()))
            {
                strSql.Append(" and a.GiftStatus_ID=" + giftStatus.Trim());
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                string sBegTime = Comm.CommUtil.ToDBDateFormat(begTime.Trim());
                strSql.Append(" and a.UserGiftReward_GrantDate>='" + sBegTime + " 0:00'");
            }

            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = Comm.CommUtil.ToDBDateFormat(endTime.Trim());
                strSql.Append(" and a.UserGiftReward_GrantDate<='" + sEndTime + " 23:59'");
            }

            //strSql.Append( " order by " + orderBy);

            strSql.Append(") T ");
            strSql.AppendFormat(" where Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

    }
}
