using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Comm;

namespace Twee.DataMgr
{
    public class WebsiteActivity
    {

       /// <summary>
       /// 发布区双积分活动
       /// </summary>
       /// <returns></returns>
        public bool DoublePointsForPublich()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_publishgradeparam set reviewreward=reviewreward*2 "); 
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
        /// 评审区双积分活动
        /// </summary>
        /// <returns></returns>
        public bool DoublePointsForReview()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_reviewgradeparam set reviewreward=reviewreward*2 ");
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
        /// 分享区双积分活动
        /// </summary>
        /// <returns></returns>
        public bool DoublePointsForShare()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_sharegradeparam set visitreward=visitreward*2,buyreward=buyreward*2 ");
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
    }
}
