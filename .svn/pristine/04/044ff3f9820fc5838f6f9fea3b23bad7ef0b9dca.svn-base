using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Twee.Mgr
{
    public partial class BugsReportMgr
    {
        private readonly Twee.DataMgr.BugsReportDataMgr mgr = new Twee.DataMgr.BugsReportDataMgr();

          public BugsReportMgr()
           {

            }
          public int GiveUserPoints(string bug_id, string points, string shopping_points, string sAdmin)
          {
              return mgr.GiveUserPoints(bug_id, points, shopping_points, sAdmin);
          }
          public bool UpdateBugStatus(string bug_id, string txtStatus)
          {
              return mgr.UpdateBugStatus(bug_id, txtStatus);
          }
          public DataTable GetBugsDetails(string bug_id)
          {
              return mgr.GetBugsDetails( bug_id);
          }
          public DataTable GetRankingRecords(string sKeyword, int startIndex, int endIndex)
          {
              return mgr.GetRankingRecords( sKeyword,  startIndex,  endIndex);
          }
          public int GetRankingTotal()
          {
              return mgr.GetRankingTotal();
          }
          public DataTable GetBugsRecords(string sKeyword, int startIndex, int endIndex)
          {
              return mgr.GetBugsRecords(sKeyword, startIndex, endIndex);

          }

          public int GetBugsTotal(string sKeyword)
          {
              return mgr.GetBugsTotal(sKeyword);
          }
          /// <summary>
          /// 增加一条数据
          /// </summary>
          public int Add(Twee.Model.BugsReport model)
          {
              return mgr.Add(model);
          }
    }
}
