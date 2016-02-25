using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Mgr
{
    public partial class MobileAppGameRankingMgr
    {
          private readonly Twee.DataMgr.MobileAppGameRankingDataMgr mgr = new Twee.DataMgr.MobileAppGameRankingDataMgr();

          public MobileAppGameRankingMgr()
            {

           }
          public string SaveGameInformationAfterUserWin(string layer, string plat_form, string screen, string userGuid,
      string sLocalPoint, string sLevel, string sVirtualProps,
      string game1, string game2, string game3, string game4, string game5, string game6)
          {
              return mgr.SaveGameInformationAfterUserWin(layer, plat_form, screen, userGuid, sLocalPoint, sLevel, sVirtualProps, game1,
                  game2, game3, game4, game5, game6);
          }
          public int AddGameScore(short iGameType, String sGamePlayer, int iGameScore)
          {

              return mgr.AddGameScore(iGameType, sGamePlayer, iGameScore);
          }
    }
}
