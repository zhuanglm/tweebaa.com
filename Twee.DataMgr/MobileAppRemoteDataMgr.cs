using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Twee.DataMgr;
using System.Reflection;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;
using Twee.Model;
using System.Collections.Specialized;


namespace Twee.DataMgr
{
    /*
     * 
     */
    public partial class MobileAppRemoteDataMgr
    {
        public MobileAppRemoteDataMgr()
		{
        
        }
        public int MobileAppRemoveMyCollage(String sDesignID, string sUserID)
        {
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update  wn_CollageDesign set CollageDesign_Status=6 where ");
            strSql2.Append("CollageDesign_ID='" + sDesignID + "' and CollageDesign_CreateUserGuid='");
            strSql2.Append(sUserID + "'");
            DbHelperSQLRemote.Remote_ExecuteSql(strSql2.ToString());
            return 1;
        }
        public int MobileAppDoRegister(string sUserGuid, string userName, string strNameEmailTel, string phone, string strPass, int countryId, int? knowwayid, string tuijieEmail, bool consent)
        {
            int intRes = -100;//默认错误
            string strLoginGuid = "";
            //string sYzm = HttpContext.Current.Session["checkcode"] as string;                    

            int Strength = (int)PasswordHelper.PasswordStrength(strPass);
            strPass = PasswordHelper.ToUpMd5(strPass);
            using (SqlConnection conn = new SqlConnection(DbHelperSQLRemote.strConnRemote))
            {
                using (SqlCommand cmd = new SqlCommand("[spMobileAppRegister]", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] parameters = new SqlParameter[] { 
                                new SqlParameter("@wnstat",SqlDbType.Int),
                                new SqlParameter("@guid", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@email",CommHelper.GetString( strNameEmailTel,true)),
                                new SqlParameter("@phone",phone),                               
                                new SqlParameter("@strPass", CommHelper.GetString(strPass,true)),
                                new SqlParameter("@Strength", Strength),
                                new SqlParameter("@userName",SqlDbType.NVarChar,50),
                                new SqlParameter("@countryId",SqlDbType.Int),
                                new SqlParameter("@knowwayid",SqlDbType.Int),
                                new SqlParameter("@tuijieEmail",SqlDbType.NVarChar),
                                new SqlParameter("@consenttime",SqlDbType.DateTime),
                            };
                        parameters[0].Direction = ParameterDirection.Output;
                        parameters[1].Value = sUserGuid.ToGuid();
                        parameters[6].Value = userName;
                        parameters[7].Value = countryId;
                        parameters[8].Value = knowwayid;
                        parameters[9].Value = tuijieEmail;
                        if (consent) parameters[10].Value = DateTime.Now;
                        else parameters[10].Value = DBNull.Value;
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.ExecuteNonQuery();
                        intRes = 1;
                        /*
                        intRes = parameters[0].Value.ToString(); //返回值:1成功，-1已存在
                        strLoginGuid = parameters[1].Value.ToString();
                        if (intRes == "1")
                        {
                            Mailhelper.SendRegEmail(strNameEmailTel, strLoginGuid, userName);
                            System.Collections.ArrayList a = new System.Collections.ArrayList();
                            a = MessageHelper.ReadHtmlFile("userActivation.htm", new string[2] { "#useremail#," + "", "#activeurl#," + "" + "#username#," + userName });
                            MessageHelper.AddMesage(a[0].ToString(), a[1].ToString(), strLoginGuid, strLoginGuid);
                        }
                         * */
                    }
                    catch (Exception ex)
                    {
                        CommHelper.WrtLog(ex.Message);
                        intRes = -97;//代码级错误
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return intRes;
        }
        public string MobileAppSaveGameInformationAfterUserWin(string layer, string plat_form, string screen, string userGuid,
                     string sLocalPoint, string sLevel, string sVirtualProps,
                     string game1, string game2, string game3, string game4, string game5, string game6)
        {
            string sRet = "-1";
            using (SqlConnection conn = new SqlConnection(DbHelperSQLRemote.strConnRemote))
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
                        parameters[4].Value = sLocalPoint.ToInt();
                        parameters[5].Value = sLevel.ToInt();
                        parameters[6].Value = sVirtualProps.ToInt();
                        parameters[7].Value = game1.ToInt();
                        parameters[8].Value = game2.ToInt();
                        parameters[9].Value = game3.ToInt();
                        parameters[10].Value = game4.ToInt();
                        parameters[11].Value = game5.ToInt();
                        parameters[12].Value = game6.ToInt();
                        parameters[13].Direction = ParameterDirection.Output;
                        parameters[14].Direction = ParameterDirection.Output;



                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.ExecuteNonQuery();
                        string intPoints = parameters[13].Value.ToString();
                        string intTools = parameters[14].Value.ToString();
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

        public void MobileAppSaveSpinRequest(string sMD5, string sTime)
        {

            string sSql = "insert into wn_MobileAppSpinLucky(Md5_CheckSum,Is_Lock,SpinDate) values('" + sMD5 + "',0,'" + sTime + "')";
            DbHelperSQLRemote.Remote_Query(sSql);
        }
        public void SaveSpin(string userGuid, string sMD5, string sPrizeID){
            string sSql = "update wn_MobileAppSpinLucky set Is_Lock=1,UserGuid='" + userGuid + "',Spin_PrizeID=" + sPrizeID + ",LastUpdateDate='" + System.DateTime.Now.ToString() + "' where Is_Lock=0 and Md5_CheckSum='" + sMD5 + "'";
            DbHelperSQLRemote.Remote_Query(sSql);

            if (sPrizeID.ToInt() == 6 || sPrizeID.ToInt() == 7)
            {
                string sAccount = "";
                if (sPrizeID.ToInt() == 6) sAccount = "5";
                if (sPrizeID.ToInt() == 7) sAccount = "10";

                //insert into 

                // write commision details to save 流水 
                sSql = "insert into wn_Profit(type,userId,[money],prdId,orderNo,state,remark,addTime,shareLevel,CommissionRate) values('App Daily Spin Reward','" + userGuid + "','" + sAccount + "',null,null,4,'App Daily Spin Reward',getdate(),0,0)";
                DbHelperSQLRemote.Remote_Query(sSql);
                /* 更新用户表 */
                sSql = "update wn_usergrade set tweebuck=tweebuck+" + sAccount + " where userguid='" + userGuid + "'";
                DbHelperSQLRemote.Remote_Query(sSql);

            }
        }
        public void SaveCollage(string sDesignID, string sType, string sTitle, string sDescription,string sDesignerGuid, string CollageDesign_HTML,
            string sImg, string products)
        {
                   // Twee.Comm.CommHelper.WrtLog("come into SaveCollage .........");
                //int iDesignID = Convert.ToInt32(sDesignID);
                //insert into wn_CollageDesignProduct

                //Twee.Comm.CommHelper.WrtLog("total=" + products.Count);
                   
                    
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into wn_CollageDesign(AppDesign_ID,");
                    strSql.Append("CollageTemp_ID,");
                    strSql.Append("CollageDesign_Status,");
                    strSql.Append("CollageCate_ID,");
                    strSql.Append("CollageDesing_Title,");
                    strSql.Append("CollageDesign_Tag,");
                    strSql.Append("CollageDesign_Inspiration,");
                    strSql.Append("CollageDesign_CreateUserGuid,");
                    strSql.Append("CollageDesign_CreateTime,");
                    strSql.Append("CollageDesign_UpdateTime,");
                    strSql.Append("CollageDesign_PublishTime,");
                    strSql.Append("CollageDesign_HTML,");
                    strSql.Append("CollageDesign_ThumbnailFileName,");
                    strSql.Append("Notify_Designer) values(");
                    strSql.Append(sDesignID); //CollageTemp_ID
                    strSql.Append(",0,"); //CollageTemp_ID
                    strSql.Append(sType + ","); //CollageDesign_Status
                    strSql.Append("0,"); //CollageCate_ID
                    strSql.Append("'" + sTitle + "',"); //CollageDesing_Title
                    strSql.Append("'',"); //CollageDesign_Tag
                    strSql.Append("'"+sDescription+"','"); //CollageDesign_Inspiration
                    strSql.Append(sDesignerGuid+"','");
                    strSql.Append(System.DateTime.Now.ToString()+"','");//CollageDesign_CreateTime
                    strSql.Append(System.DateTime.Now.ToString() + "','");//System.DateTime.Now.ToString()
                    strSql.Append(System.DateTime.Now.ToString() + "','");//System.DateTime.Now.ToString()
                    strSql.Append(CollageDesign_HTML + "','");//CollageDesign_HTML
                    //strSql.Append(sImg+"',"); //CollageDesign_ThumbnailFileName
                    //modify by Long 2016/01/13
                    strSql.Append("http://67.224.94.82/upload/UploadImg" + sImg + "',");
                    strSql.Append("0);select @@IDENTITY");
                    //DbHelperSQLRemote.Remote_ExecuteSql(strSql.ToString());
                     object obj = DbHelperSQLRemote.Remote_GetSingle(strSql.ToString());
                     if (obj == null)
                     {
                         //return 0;
                     }
                     else
                     {
                         int iDesignID = Convert.ToInt32(obj);
                         string[] products_ids = products.Split(',');
                         //Twee.Comm.CommHelper.WrtLog("total=" + products_ids.Length);
                         StringBuilder strSql2 = new StringBuilder();
                         //StringBuilder strSql3 = new StringBuilder();
                         for (int i = 0; i < products_ids.Length; i++)
                         {

                             //Is it a product ?
                             //Twee.Comm.CommHelper.WrtLog("products_ids[i].Length=" + products_ids[i].Length);
                             if (products_ids[i].Length > 10)
                             {
                                 string pID = products_ids[i];
                                 string pIndex = (i + 1).ToString();
                                 //Twee.Comm.CommHelper.WrtLog("1=" + pID + " 2=" + pIndex);
                                 strSql2.Clear();
                                 strSql2.Append("insert into wn_CollageDesignProduct(");
                                 strSql2.Append("CollageDesign_ID,prdGuid,iOrder)");
                                 strSql2.Append(" values (");
                                 strSql2.Append(iDesignID.ToString() + ",'" + pID + "'," + pIndex + ");");
                                 Twee.Comm.CommHelper.WrtLog("SaveCollage Remote sql=" + strSql2.ToString());

                                 DbHelperSQLRemote.Remote_ExecuteSql(strSql2.ToString());
                                 /*
                                 strSql3.Clear();
                                 strSql3.Append("insert into wn_QueryPool(QueryTable,QueryString,InsertDate) values('");
                                 strSql3.Append("wn_CollageDesignProduct','" + Twee.Comm.CommUtil.Base64Encode(strSql2.ToString()) + "',getdate())");
                                 DbHelperSQL.ExecuteSql(strSql3.ToString());
                                 Twee.Comm.CommHelper.WrtLog("strSql3=" + strSql3);*/
                             }
                         }
                     }
                    //Twee.Comm.CommHelper.WrtLog(strSql.ToString());
            /*
                   if (obj == null)
                   {
                       // return 0;
                       // context.Response.Write("0");
                   }
                   else
                   {
            * */

                   // }
        }

        public void RemoveFavour(string sDesignID, string sUserGuid)
        {
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from wn_favorite where ");
            strSql2.Append("sourcetype=2 and CollageDesign_ID='" + sDesignID + "' and userguid='");
            strSql2.Append(sUserGuid + "'");
            object obj = DbHelperSQLRemote.Remote_GetSingle(strSql2.ToString());
        }
        public void SaveFavour(string sDesignID, string sUserGuid)
        {
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into wn_favorite(");
            strSql2.Append("sourcetype,CollageDesign_ID,edttime,userguid)");
            strSql2.Append(" values (");
            strSql2.Append("2" + ",'" + sDesignID + "','" + System.DateTime.Now.ToString() + "','" + sUserGuid + "')");
            object obj = DbHelperSQLRemote.Remote_GetSingle(strSql2.ToString());
        }
    }
}
