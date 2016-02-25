using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.DataMgr;
using System.Reflection;
using log4net;
using System.Data;


namespace Twee.Mgr
{
    public class UserGiftRewardMgr
    {
        private UserGiftRewardDataMgr mgr = new UserGiftRewardDataMgr();
        public int GetMyGiftRewardCount(string userID, string giftName, string giftStatus, string begTime, string endTime)
        {
            return mgr.GetMyGiftRewardCount(userID, giftName, giftStatus, begTime, endTime);
        }


        public DataSet GetMyGiftRewardList(string userID, string giftName, string giftStatus, string orderby, int startIndex, int endIndex, string begTime, string endTime)
        {
            return mgr.GetMyGiftRewardList(userID, giftName, giftStatus, orderby, startIndex, endIndex, begTime, endTime);
        }


        public DataSet GetGiftStatusList()
        {
            return mgr.GetGiftStatusList();
        }

        public int GetTotalShoppingRewardPoint(string userID)
        {
            return mgr.GetTotalShoppingRewardPoint(userID);
        }

    }
}
