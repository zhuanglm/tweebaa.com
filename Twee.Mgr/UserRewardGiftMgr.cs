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
    public class UserRewardGiftMgr
    {
        private UserRewardGiftDataMgr mgr = new UserRewardGiftDataMgr();
        public int GetMyRewardGiftCount(string userID, string giftName, string giftStatus, string begTime, string endTime)
        {
            return mgr.GetMyRewardGiftCount(userID, giftName, giftStatus, begTime, endTime) ;
         }

        public DataSet GetMyRewardGift(string userID, string giftName, string giftStatus, string orderby, int startIndex, int endIndex, string begTime, string endTime)
        {
            return mgr.GetMyRewardGift(userID, giftName, giftStatus, orderby, startIndex, endIndex, begTime, endTime);
        }
        public DataSet GetGiftStatusList() 
        {
            return mgr.GetGiftStatusList();
        }

    }
}
