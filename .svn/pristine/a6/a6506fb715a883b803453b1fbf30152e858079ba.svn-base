using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Twee.Mgr;
using System.Collections.Specialized;
using System.IO;

namespace Twee.WebService
{

    /// <summary>
    /// Summary description for MobileAppDBWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MobileAppDBWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            //Twee.Comm.CommHelper.WrtLog("gggggggggggggggg");
            return "gggggggggggggggg Hello World";
        }

        [WebMethod]

        public int MobileAppRemoveMyCollage(String sDesignID, string sUserID)
        {
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();

            return mgr.MobileAppRemoveMyCollage(sDesignID, sUserID);

        }
        [WebMethod]
        public int MobileAppDoRegister(string sUserGuid, string userName, string strNameEmailTel, string phone, string strPass, int countryId, int? knowwayid, string tuijieEmail, bool consent)
        {
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            return mgr.MobileAppDoRegister( sUserGuid,  userName,  strNameEmailTel,  phone,  strPass,  countryId,  knowwayid,  tuijieEmail,  consent);
           // return 1;
        }
        [WebMethod]
        public String SaveGameInformationAfterUserWin(string layer, string plat_form, string screen, string userGuid,
                string sLocalPoint, string sLevel, string sVirtualProps,
                string game1, string game2, string game3, string game4, string game5, string game6)
        {
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            return mgr.MobileAppSaveGameInformationAfterUserWin(layer, plat_form, screen, userGuid, sLocalPoint, sLevel, sVirtualProps, game1,
            game2, game3, game4, game5, game6);
        }

        //daily_check_in 


       // Save_Spin_Request
        [WebMethod]
        public int SaveSpinRequest(string sMD5, string sTime)
        {
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            mgr.MobileAppSaveSpinRequest(sMD5, sTime);
            return 1;
        }

        //Save_Spin 
        [WebMethod]
        public int SaveSpin(string userGuid, string sMD5, string sPrizeID)
        {
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            mgr.SaveSpin(userGuid, sMD5, sPrizeID);
            return 1;
        }
        //Save_Collage 
        [WebMethod]
        public void SaveCollage(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML,
            string sImg, params string[] products)
        {
            /*
            Twee.Comm.CommHelper.WrtLog("111111111111111");
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            mgr.SaveCollage(sDesignID, sType, sTitle, sDescription, sDesignerGuid, CollageDesign_HTML,
                sImg,  products);
            Twee.Comm.CommHelper.WrtLog("22222222222");*/

        }

        [WebMethod]
        public int SaveCollageEx(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML,
            string sImg, string products)
        {
            //Twee.Comm.CommHelper.WrtLog("111111111111111");
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            
            mgr.SaveCollage(sDesignID, sType, sTitle, sDescription, sDesignerGuid, CollageDesign_HTML,
                sImg, products);
            //WriteLog("products=" + products);
            //Twee.Comm.CommHelper.WrtLog("22222222222");
            return 1;

        }
        private void WriteLog(string log)
        {
            string fname = Path.Combine(
                       Server.MapPath("/logs"), "logfile.txt");
            TextWriter tw = new StreamWriter(fname);
            tw.Write("Yada yada :" + log);
            tw.Close();

        }
        //remove_favour
        [WebMethod]
        public int RemoveFavour(string sDesignID, string sUserGuid)
        {
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            mgr.RemoveFavour(sDesignID, sUserGuid);
            return 1;
        }

        //save_favour
        [WebMethod]
        public int SaveFavour(string sDesignID, string sUserGuid)
        {
            Mgr.MobileAppRemoteMgr mgr = new MobileAppRemoteMgr();
            mgr.SaveFavour(sDesignID, sUserGuid);
            return 1;
        }
        
    }
}
