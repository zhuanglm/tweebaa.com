using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
     public partial class MobileAppGameRankingDataMgr
    {
         public MobileAppGameRankingDataMgr()
         {

         }

         public string SaveGameInformationAfterUserWin(string layer, string plat_form, string screen, string userGuid,
             string sLocalPoint, string sLevel, string sVirtualProps,
             string game1, string game2, string game3, string game4, string game5, string game6)
         {
             string sRet = "-1";
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("[spMobileAppSaveUserInfoAndSyncData]", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] parameters = new SqlParameter[] { 
                            new SqlParameter("@layer",SqlDbType.NVarChar,50),
                            new SqlParameter("@plat_form",SqlDbType.NVarChar,50),
                            new SqlParameter("@screen",SqlDbType.NVarChar,50),
                            new SqlParameter("@userGuid",SqlDbType.UniqueIdentifier),
                            new SqlParameter("@sLocalPoint",SqlDbType.Int), 
                            new SqlParameter("@sLevel",SqlDbType.Int), 
                            new SqlParameter("@sVirtualProps",SqlDbType.Int), 
                            new SqlParameter("@game1",SqlDbType.Int), 
                            new SqlParameter("@game2",SqlDbType.Int), 
                            new SqlParameter("@game3",SqlDbType.Int), 
                            new SqlParameter("@game4",SqlDbType.Int), 
                            new SqlParameter("@game5",SqlDbType.Int), 
                            new SqlParameter("@game6",SqlDbType.Int), 
                            new SqlParameter("@out_total_point",SqlDbType.Int), 
                            new SqlParameter("@out_total_tools",SqlDbType.Int), 
                            };
                        parameters[0].Value = layer;
                        parameters[1].Value = plat_form;
                        parameters[2].Value = screen;
                        parameters[3].Value = userGuid.ToGuid();
                        parameters[4].Value =  sLocalPoint.ToInt();
                        parameters[5].Value =  sLevel.ToInt();
                        parameters[6].Value =  sVirtualProps.ToInt();
                        parameters[7].Value =  game1.ToInt();
                        parameters[8].Value = game2.ToInt();
                        parameters[9].Value = game3.ToInt();
                        parameters[10].Value =  game4.ToInt();
                        parameters[11].Value = game5.ToInt();
                        parameters[12].Value =  game6.ToInt();
                        parameters[13].Direction = ParameterDirection.Output;
                        parameters[14].Direction = ParameterDirection.Output;


                        Twee.Comm.CommHelper.WrtLog("sVirtualProps");
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.ExecuteNonQuery();                        
                        string  intPoints = parameters[13].Value.ToString(); 
                        string  intTools = parameters[14].Value.ToString();
                        sRet = intPoints + ":" + intTools;
                    }
                    catch (Exception ex)
                    {
                        CommHelper.WrtLog(ex.Message);
                        //intRes = "-97";//代码级错误
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return sRet;
         }
         public int AddGameScore(short iGameType, String sGamePlayer, int iGameScore)
         {
             if (sGamePlayer.Length > 10)
             {
                 StringBuilder strSql = new StringBuilder();
                 strSql.Append("insert into wn_MobileAppGameRanking(");
                 strSql.Append("game_type_id,game_player_guid,game_score,submit_date)");
                 strSql.Append(" values (");
                 strSql.Append("@game_type_id,@game_player_guid,@game_score,@submit_date)");
                 strSql.Append(";select @@IDENTITY");
                 SqlParameter[] parameters = {
                    new SqlParameter("@game_type_id",SqlDbType.TinyInt,2),
                    new SqlParameter("@game_player_guid",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@game_score",SqlDbType.Int,4),
                    new SqlParameter("@submit_date",SqlDbType.DateTime,8)
					};

                 parameters[0].Value = iGameType;
                 parameters[1].Value = sGamePlayer.ToGuid();
                 parameters[2].Value = iGameScore;
                 parameters[3].Value = DateTime.Now;


                 object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                 if (obj == null)
                 {
                     return 0;
                 }
                 else
                 {
                     int iRankID = Convert.ToInt32(obj);
                     return iRankID;
                 }
             }
             else
             {
                 return 0;
             }
         }
    }
}
