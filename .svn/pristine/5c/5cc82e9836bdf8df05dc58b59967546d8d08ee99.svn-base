using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;


namespace Twee.Mgr
{
    public partial class MobileAppRemoteMgr
    {
        private readonly Twee.DataMgr.MobileAppRemoteDataMgr dal = new Twee.DataMgr.MobileAppRemoteDataMgr();
        public MobileAppRemoteMgr()
        { }

        public int MobileAppRemoveMyCollage(String sDesignID, string sUserID)
        {
            return dal.MobileAppRemoveMyCollage(sDesignID, sUserID);
        }

        public int MobileAppDoRegister(string sUserGuid, string userName, string strNameEmailTel, string phone, string strPass, int countryId, int? knowwayid, string tuijieEmail, bool consent)
        {
            return dal.MobileAppDoRegister( sUserGuid,  userName,  strNameEmailTel,  phone,  strPass,  countryId,  knowwayid,  tuijieEmail,  consent);
        }
        public string MobileAppSaveGameInformationAfterUserWin(string layer, string plat_form, string screen, string userGuid,
             string sLocalPoint, string sLevel, string sVirtualProps,
             string game1, string game2, string game3, string game4, string game5, string game6)
        {
            return dal.MobileAppSaveGameInformationAfterUserWin(layer, plat_form, screen, userGuid, sLocalPoint, sLevel, sVirtualProps, game1,
    game2, game3, game4, game5, game6);
        }
        public void MobileAppSaveSpinRequest(string sMD5, string sTime)
        {
            dal.MobileAppSaveSpinRequest(sMD5, sTime);
        }
        public void SaveSpin(string userGuid, string sMD5, string sPrizeID)
        {
            dal.SaveSpin(userGuid, sMD5, sPrizeID);
        }
        public void SaveCollage(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML,
    string sImg, string products)
        {
            dal.SaveCollage( sDesignID,  sType,  sTitle,  sDescription,  sDesignerGuid,  CollageDesign_HTML,
     sImg,  products);
        }
        public void RemoveFavour(string sDesignID, string sUserGuid)
        {
            dal.RemoveFavour(sDesignID, sUserGuid);
        }
        public void SaveFavour(string sDesignID, string sUserGuid)
        {
            dal.SaveFavour(sDesignID, sUserGuid);
        }
    }
}
