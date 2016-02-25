﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public partial class CollageDesignDataMgr
    {
        public CollageDesignDataMgr()
        {
        }

        public void RemoveMyCollage(string strCollageID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageDesign set CollageDesign_Status=6 where CollageDesign_ID=" + strCollageID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public int GetMyCollageTotal(string strUserID, string beginTime, string endtime)
        {
            StringBuilder strSql = new StringBuilder();
            if (beginTime.Length > 0 && endtime.Length > 0)
            {
                strSql.Append("select count(1) from vw_CollageShareTotalSaled where CollageDesign_CreateUserGuid='" + strUserID + "' and  CollageDesign_PublishTime>='" + beginTime + "' and CollageDesign_PublishTime<='" + endtime + "'");
            }
            else
            {
                strSql.Append("select count(1) from vw_CollageShareTotalSaled where CollageDesign_CreateUserGuid='" + strUserID + "'");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().ToInt();
            }
        }

        public DataSet GetMyCollage(string strUserID, string beginTime, string endtime, int iFirst, int iLast)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (");
            if (beginTime.Length > 0 && endtime.Length > 0)
            {
                strSql.Append("SELECT *, ROW_NUMBER() OVER (ORDER BY CollageDesign_PublishTime desc ) AS 'RowNumber' from vw_CollageShareTotalSaled T where CollageDesign_CreateUserGuid='" + strUserID + "' and CollageDesign_PublishTime>='" + beginTime + "' and CollageDesign_PublishTime<='" + endtime + "'");
            }
            else
            {
                strSql.Append("SELECT *, ROW_NUMBER() OVER (ORDER BY CollageDesign_PublishTime desc ) AS 'RowNumber' from vw_CollageShareTotalSaled T where CollageDesign_CreateUserGuid='" + strUserID + "'");
            }
            strSql.Append(") TT WHERE TT.RowNumber BETWEEN " + iFirst);
            strSql.Append(" AND " + iLast);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public void UpdateCollageView(string strCollageID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageDesign set Total_Viewed=Total_Viewed+1 where CollageDesign_ID=" + strCollageID);
            DbHelperSQL.ExecuteSql(strSql.ToString());

        }

        public int GetPublishTotal()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) as count FROM wn_CollageDesign a inner join wn_user b on a.CollageDesign_CreateUserGuid=b.guid where  CollageDesign_Status=2");

            
            
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().ToInt();
            }
        }
        public string GetDesignEMailNotify(string sDesignID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Notify_Designer,email FROM wn_CollageDesign a left join wn_user b on a.CollageDesign_CreateUserGuid=b.guid where CollageDesign_ID=" + sDesignID);

            string sRet = "";
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    sRet = rdr["Notify_Designer"].ToString() + rdr["email"].ToString();
                }
            }
            return sRet;
        }
        public void SetDesignEMailNotify(string sDesignID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageDesign set Notify_Designer=1  where CollageDesign_ID=" + sDesignID);

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

        }
        private void GetUserinfomation(string strUserID, Twee.Model.CollageDesign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.username, c.CityName, d.country FROM ");
            strSql.Append("wn_user AS b LEFT OUTER JOIN ");
            strSql.Append("wn_City AS c ON b.cityid = c.CityID LEFT OUTER JOIN ");
            strSql.Append("wn_country AS d ON b.countryId = d.id ");
            strSql.Append("where b.guid='" + strUserID + "'");
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    //iTotal = Convert.ToInt32(rdr["count"]);
                    if (rdr["username"] != null)
                    {
                        model.User_name = rdr["username"].ToString();

                    }
                    if (rdr["CityName"] != null)
                    {
                        model.City = rdr["CityName"].ToString();

                    }
                    if (rdr["country"] != null)
                    {
                        model.Country = rdr["country"].ToString();

                    }
                }
            }

        }
        public DataSet GetAllList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  wn_CollageDesign   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere);
            }


            //Twee.Comm.CommHelper.WrtLog(" load_all_publish sql=" + strSql);
            return DbHelperSQL.Query(strSql.ToString());

        }
        public DataSet GetAllListForMobileApp(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  wn_CollageDesign   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere);
            }


            //Twee.Comm.CommHelper.WrtLog(" load_all_publish sql=" + strSql);
            return DbHelperSQL.Query(strSql.ToString());

        }
        public DataSet GetListByPage(string strWhere,int iSortType, int iFirst, int iLast)
        {
            StringBuilder strSql = new StringBuilder();
            if (iSortType == 1)
            {
                strSql.Append("select a.*,b.username from (SELECT *, ROW_NUMBER() OVER (ORDER BY CollageDesign_PublishTime desc ) AS 'RowNumber'");
            }
            else
            {
                strSql.Append("select a.*,b.username from (SELECT *, ROW_NUMBER() OVER (ORDER BY CollageDesing_Title ) AS 'RowNumber'");
            }
            strSql.Append(" from wn_CollageDesign  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere );
            }

            strSql.Append(") as a inner join wn_user b on a.CollageDesign_CreateUserGuid=b.guid  WHERE RowNumber BETWEEN " + iFirst);
            strSql.Append("AND " + iLast);
            //Twee.Comm.CommHelper.WrtLog(" load_all_publish sql=" + strSql);
            return DbHelperSQL.Query(strSql.ToString());

        }
        public int GetSearchTotal(string sKeywords)
        {
            StringBuilder strSql = new StringBuilder();
            if (sKeywords.Length > 0)
            {
                string sTitleLike = CommUtil.GetSqlLike("CollageDesing_Title", sKeywords.Trim());
                string sTagLike = CommUtil.GetSqlLike("CollageDesign_Tag", sKeywords.Trim());
                string sInspiration = CommUtil.GetSqlLike("CollageDesign_Inspiration", sKeywords.Trim());

                string sLikes = "CollageDesign_Status=2 and (( " + sTitleLike + ") or (" + sTagLike + ") or (" + sInspiration + "))";
                strSql.Append("SELECT count(1) as count FROM wn_CollageDesign a inner join wn_user b on a.CollageDesign_CreateUserGuid=b.guid where " + sLikes);
            }
            else
            {
                strSql.Append("SELECT count(1) as count FROM wn_CollageDesign a inner join wn_user b on a.CollageDesign_CreateUserGuid=b.guid where  CollageDesign_Status=2");

            }
            
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().ToInt();
            }

        }
        public int GetMyDraftTotal(string sUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) as count FROM wn_CollageDesign where CollageDesign_CreateUserGuid = '" + sUserID + "' and CollageDesign_Status=1");

            int iTotal = 0;
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    iTotal = Convert.ToInt32(rdr["count"]);
                }
            }
            return iTotal;
        }

        public int GetDesignShareTotal(string sDesignID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) as count FROM wn_share where ColllageDesign_ID = " + sDesignID +  " and sourcetype=2");

            int iTotal = 0;
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    iTotal = Convert.ToInt32(rdr["count"]);
                }
            }
            return iTotal;
        }
        public int GetMyPublishTotal(string sUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) as count FROM wn_CollageDesign where CollageDesign_CreateUserGuid = '" + sUserID + "' and CollageDesign_Status=0");

            int iTotal = 0;
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    iTotal = Convert.ToInt32(rdr["count"]);
                }
            }
            return iTotal;
        }

        private DateTime FormatDatetimeString(string sDateTime)
        {
            //MM-dd-yyyy HH:mm:ss
            DateTime newDateTime = new DateTime(Convert.ToInt32(sDateTime.Substring(6, 4)), // Year
                                    Convert.ToInt32(sDateTime.Substring(0, 2)), // Month
                                    Convert.ToInt32(sDateTime.Substring(3, 2)), // Day
                                    Convert.ToInt32(sDateTime.Substring(11, 2)), //hour
                                    Convert.ToInt32(sDateTime.Substring(14, 2)), //minutes
                                    Convert.ToInt32(sDateTime.Substring(17, 2))); //second
            return newDateTime;
        }
        private void GetProudctsByDesignID(string sDesignID, Twee.Model.CollageDesign model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strIDs = new StringBuilder();

            strSql.Append("SELECT * from wn_CollageDesignProduct where CollageDesign_ID=" + sDesignID);
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {


                    if (rdr != null)
                    {
                        if (rdr["iOrder"] != null && rdr["iOrder"].ToString() != "")
                        {
                            int iOrder = int.Parse(rdr["iOrder"].ToString());
                            strIDs.Append(rdr["prdGuid"].ToString() + ",");
                            /*
                            if (iOrder == 1) model.Product_ID1 = rdr["prdGuid"].ToString();
                            if (iOrder == 2) model.Product_ID2 = rdr["prdGuid"].ToString();
                            if (iOrder == 3) model.Product_ID3 = rdr["prdGuid"].ToString();
                            if (iOrder == 4) model.Product_ID4 = rdr["prdGuid"].ToString();

                            if (iOrder == 5) model.Product_ID5 = rdr["prdGuid"].ToString();
                            if (iOrder == 6) model.Product_ID6 = rdr["prdGuid"].ToString();
                            if (iOrder == 7) model.Product_ID7 = rdr["prdGuid"].ToString();
                            if (iOrder == 8) model.Product_ID8 = rdr["prdGuid"].ToString();*/
                        }
                    }


                }
            }
            string s=strIDs.ToString();
            if (s.Length > 2) 
                s=s.Substring(0,s.Length-1); //remove last ","
            model.Product_ids = s;
        }
        public DataSet GetFreeStyleDesignByID(string design_id){

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.*,e.*,b.username, c.CityName, d.country FROM wn_CollageDesign a  ");
            strSql.Append(" inner OUTER JOIN ");
            strSql.Append("wn_user AS b ON a.CollageDesign_CreateUserGuid = b.guid LEFT OUTER JOIN ");
            strSql.Append("wn_City AS c ON b.cityid = c.CityID LEFT OUTER JOIN ");
            strSql.Append("wn_country AS d ON b.countryId = d.id ");
            strSql.Append("where CollageDesign_ID=" + design_id);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public Twee.Model.CollageDesign GetDesignByID(string design_id){

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.*,e.*,b.username, c.CityName, d.country FROM wn_CollageDesign a left join wn_CollageTemp e on a.CollageTemp_ID=e.CollageTemp_ID ");
            strSql.Append(" LEFT OUTER JOIN ");
            strSql.Append("wn_user AS b ON a.CollageDesign_CreateUserGuid = b.guid LEFT OUTER JOIN ");
            strSql.Append("wn_City AS c ON b.cityid = c.CityID LEFT OUTER JOIN ");
            strSql.Append("wn_country AS d ON b.countryId = d.id ");
            strSql.Append("where CollageDesign_ID=" + design_id);
            Twee.Model.CollageDesign model = new Twee.Model.CollageDesign();
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {


                    if (rdr != null)
                    {
                        if (rdr["CollageDesign_ID"] != null && rdr["CollageDesign_ID"].ToString() != "")
                        {
                            model.id = int.Parse(rdr["CollageDesign_ID"].ToString());
                            GetProudctsByDesignID(rdr["CollageDesign_ID"].ToString(),model);
                        }
                        if (rdr["CollageTemp_ID"] != null)
                        {
                            model.template_id = int.Parse(rdr["CollageTemp_ID"].ToString());
                        }
                        if (rdr["CollageDesign_Status"] != null)
                        {
                            model.status_id = short.Parse(rdr["CollageDesign_Status"].ToString());
                        }
                        if (rdr["CollageCate_ID"] != null)
                        {
                            model.cate_id = int.Parse(rdr["CollageCate_ID"].ToString());
                        }
                        if (rdr["CollageDesign_Tag"] != null)
                        {
                            model.tags = rdr["CollageDesign_Tag"].ToString();
                        }
                        if (rdr["CollageDesign_Inspiration"] != null)
                        {
                            model.Inspiration = rdr["CollageDesign_Inspiration"].ToString();
                        }
                        if (rdr["CollageDesing_Title"] != null)
                        {
                            model.CollageDesing_Title = rdr["CollageDesing_Title"].ToString();
                        }

                        if (rdr["CollageDesign_CreateUserGuid"] != null)
                        {
                            model.guid = new Guid(rdr["CollageDesign_CreateUserGuid"].ToString());
                        }
                        if (rdr["CollageDesign_CreateTime"] != null)
                        {
                            model.CreateTime = rdr["CollageDesign_CreateTime"].ToString();
                        }
                        if (rdr["CollageDesign_UpdateTime"] != null)
                        {
                            model.UpdateTime = rdr["CollageDesign_UpdateTime"].ToString();
                        }
                        if (rdr["CollageDesign_CreateTime"] != null)
                        {
                            model.CreateTime = rdr["CollageDesign_CreateTime"].ToString();
                        }
                        if (rdr["CollageDesign_PublishTime"] != null)
                        {
                            model.PublishTime = rdr["CollageDesign_PublishTime"].ToString();
                        }
                        if (rdr["CollageDesign_HTML"] != null)
                        {
                            model.innerHTML = rdr["CollageDesign_HTML"].ToString();
                        }
                        if (rdr["CollageDesign_ThumbnailFileName"] != null)
                        {
                            model.thumbnail = rdr["CollageDesign_ThumbnailFileName"].ToString();
                        }
                        if (rdr["CollageTemp_HTML"] != null)
                        {
                            model.TemplateHTML = rdr["CollageTemp_HTML"].ToString();
                        }

                        if (rdr["username"] != null)
                        {
                            model.User_name = rdr["username"].ToString();
                        }
                        if (rdr["CityName"] != null)
                        {
                            model.City = rdr["CityName"].ToString();
                        }
                        if (rdr["country"] != null)
                        {
                            model.Country = rdr["country"].ToString();
                        }
                    }
                    

                }
            }
            return model;
        }

        public int Add_Free_Style(Twee.Model.CollageDesign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_CollageDesign(");
            strSql.Append("CollageTemp_ID,CollageDesign_Status,CollageCate_ID,CollageDesing_Title,CollageDesign_Tag,CollageDesign_Inspiration,CollageDesign_CreateUserGuid,CollageDesign_CreateTime,CollageDesign_UpdateTime,CollageDesign_PublishTime,CollageDesign_HTML,CollageDesign_ThumbnailFileName,CollageDesign_JsonData)");
            strSql.Append(" values (");
            strSql.Append("@CollageTemp_ID,@CollageDesign_Status,@CollageCate_ID,@CollageDesing_Title,@CollageDesign_Tag,@CollageDesign_Inspiration,@CollageDesign_CreateUserGuid,@CollageDesign_CreateTime,@CollageDesign_UpdateTime,@CollageDesign_PublishTime,@CollageDesign_HTML,@CollageDesign_ThumbnailFileName,@CollageDesign_JsonData)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CollageTemp_ID",SqlDbType.Int,4),
                    new SqlParameter("@CollageDesign_Status",SqlDbType.TinyInt,1),
                    new SqlParameter("@CollageCate_ID",SqlDbType.Int,4),
                    new SqlParameter("@CollageDesing_Title",SqlDbType.NVarChar,300),
                    new SqlParameter("@CollageDesign_Tag",SqlDbType.NVarChar,300),
                    new SqlParameter("@CollageDesign_Inspiration",SqlDbType.NVarChar,500),
                    new SqlParameter("@CollageDesign_CreateUserGuid",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@CollageDesign_CreateTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_UpdateTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_PublishTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_HTML",SqlDbType.NText),
                    new SqlParameter("@CollageDesign_ThumbnailFileName",SqlDbType.NVarChar,300), 
                    new SqlParameter("@CollageDesign_JsonData",SqlDbType.NText),
					};

            parameters[0].Value = model.template_id;
            parameters[1].Value = model.status_id;
            parameters[2].Value = model.cate_id;
            parameters[3].Value = model.CollageDesing_Title;
            parameters[4].Value = model.tags;
            parameters[5].Value = model.Inspiration;
            parameters[6].Value = model.guid;
            parameters[7].Value = FormatDatetimeString(model.CreateTime); //Convert.ToDateTime(model.CreateTime);
            parameters[8].Value = FormatDatetimeString(model.UpdateTime); //Convert.ToDateTime(model.UpdateTime);
            parameters[9].Value = FormatDatetimeString(model.PublishTime); //Convert.ToDateTime(model.PublishTime);
            parameters[10].Value = model.innerHTML;
            parameters[11].Value = model.thumbnail;
            parameters[12].Value = model.TemplateHTML;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                int iDesignID = Convert.ToInt32(obj);
                // add to DesignProduct table
                StringBuilder strSql2 = new StringBuilder();

                if (model.Product_ID1.Length > 2)
                {

                    strSql2.Append("insert into wn_CollageDesignProduct(");
                    strSql2.Append("CollageDesign_ID,prdGuid,iOrder)");
                    strSql2.Append(" values (");
                    strSql2.Append("@CollageDesign_ID,@prdGuid,@iOrder)");
                    SqlParameter[] parameters2 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters2[0].Value = iDesignID;
                    parameters2[1].Value = new Guid(model.Product_ID1.Substring(2, model.Product_ID1.Length - 2));
                    parameters2[2].Value = 1;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters2);

                }
                //Is it a product ?
                /*
                if (model.Product_ID1.Length > 2 && model.Product_ID1.Substring(0, 2).Equals("P_"))
                {

                }

                if (model.Product_ID2.Length > 2 && model.Product_ID2.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters3 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters3[0].Value = iDesignID;
                    parameters3[1].Value = new Guid(model.Product_ID2.Substring(2, model.Product_ID2.Length - 2));
                    parameters3[2].Value = 2;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters3);
                }

                if (model.Product_ID3.Length > 2 && model.Product_ID3.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters4 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters4[0].Value = iDesignID;
                    parameters4[1].Value = new Guid(model.Product_ID3.Substring(2, model.Product_ID3.Length - 2));
                    parameters4[2].Value = 3;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters4);
                }

                if (model.Product_ID4.Length > 2 && model.Product_ID4.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID4.Substring(2, model.Product_ID4.Length - 2));
                    parameters5[2].Value = 4;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }

                if (model.Product_ID5.Length > 2 && model.Product_ID5.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID5.Substring(2, model.Product_ID5.Length - 2));
                    parameters5[2].Value = 5;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }
                if (model.Product_ID6.Length > 2 && model.Product_ID6.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID6.Substring(2, model.Product_ID6.Length - 2));
                    parameters5[2].Value = 6;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }
                if (model.Product_ID7.Length > 2 && model.Product_ID7.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID7.Substring(2, model.Product_ID7.Length - 2));
                    parameters5[2].Value = 7;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }
                if (model.Product_ID8.Length > 2 && model.Product_ID8.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID8.Substring(2, model.Product_ID8.Length - 2));
                    parameters5[2].Value = 8;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }*/
                return iDesignID;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageDesign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_CollageDesign(");
            strSql.Append("CollageTemp_ID,CollageDesign_Status,CollageCate_ID,CollageDesing_Title,CollageDesign_Tag,CollageDesign_Inspiration,CollageDesign_CreateUserGuid,CollageDesign_CreateTime,CollageDesign_UpdateTime,CollageDesign_PublishTime,CollageDesign_HTML,CollageDesign_ThumbnailFileName)");
            strSql.Append(" values (");
            strSql.Append("@CollageTemp_ID,@CollageDesign_Status,@CollageCate_ID,@CollageDesing_Title,@CollageDesign_Tag,@CollageDesign_Inspiration,@CollageDesign_CreateUserGuid,@CollageDesign_CreateTime,@CollageDesign_UpdateTime,@CollageDesign_PublishTime,@CollageDesign_HTML,@CollageDesign_ThumbnailFileName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CollageTemp_ID",SqlDbType.Int,4),
                    new SqlParameter("@CollageDesign_Status",SqlDbType.TinyInt,1),
                    new SqlParameter("@CollageCate_ID",SqlDbType.Int,4),
                    new SqlParameter("@CollageDesing_Title",SqlDbType.NVarChar,300),
                    new SqlParameter("@CollageDesign_Tag",SqlDbType.NVarChar,300),
                    new SqlParameter("@CollageDesign_Inspiration",SqlDbType.NVarChar,500),
                    new SqlParameter("@CollageDesign_CreateUserGuid",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@CollageDesign_CreateTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_UpdateTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_PublishTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_HTML",SqlDbType.NVarChar,4000),
                    new SqlParameter("@CollageDesign_ThumbnailFileName",SqlDbType.NVarChar,300)
					};

            parameters[0].Value = model.template_id;
            parameters[1].Value = model.status_id;
            parameters[2].Value = model.cate_id;
            parameters[3].Value = model.CollageDesing_Title;
            parameters[4].Value = model.tags;
            parameters[5].Value = model.Inspiration;
            parameters[6].Value = model.guid;
            parameters[7].Value = FormatDatetimeString(model.CreateTime); //Convert.ToDateTime(model.CreateTime);
            parameters[8].Value = FormatDatetimeString(model.UpdateTime); //Convert.ToDateTime(model.UpdateTime);
            parameters[9].Value = FormatDatetimeString(model.PublishTime); //Convert.ToDateTime(model.PublishTime);
            parameters[10].Value = model.innerHTML;
            parameters[11].Value = model.thumbnail;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                int iDesignID=Convert.ToInt32(obj);
                // add to DesignProduct table
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into wn_CollageDesignProduct(");
                strSql2.Append("CollageDesign_ID,prdGuid,iOrder)");
                strSql2.Append(" values (");
                strSql2.Append("@CollageDesign_ID,@prdGuid,@iOrder)");


                List<string> ProductID = new List<string>();
                if (model.Product_ids.Length > 0)
                {
                    string[] words = model.Product_ids.Split('|');
                    foreach (string word in words)
                    {
                        if (word.Length >=31)
                        {
                            if(!ProductID.Exists(x=> x == word))
                            {
                                ProductID.Add(word);
                            }
                        }
                    }
                }

                int i = 1;
                foreach (string ID in ProductID)
                {
                    SqlParameter[] parameters2 = 
                    {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters2[0].Value = iDesignID;
                    parameters2[1].Value = new Guid(ID);
                    parameters2[2].Value = i; i++;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters2);
                }
                /*

                //Is it a product ?
                if (model.Product_ID1.Length>2 && model.Product_ID1.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters2 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters2[0].Value = iDesignID;
                    parameters2[1].Value = new Guid(model.Product_ID1.Substring(2,model.Product_ID1.Length -2));
                    parameters2[2].Value = 1;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters2);
                }

                if (model.Product_ID2.Length > 2 && model.Product_ID2.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters3 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters3[0].Value = iDesignID;
                    parameters3[1].Value = new Guid(model.Product_ID2.Substring(2, model.Product_ID2.Length - 2));
                    parameters3[2].Value = 2;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters3);
                }

                if (model.Product_ID3.Length > 2 &&  model.Product_ID3.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters4 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters4[0].Value = iDesignID;
                    parameters4[1].Value = new Guid(model.Product_ID3.Substring(2, model.Product_ID3.Length - 2));
                    parameters4[2].Value = 3;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters4);
                }

                if (model.Product_ID4.Length > 2 && model.Product_ID4.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID4.Substring(2, model.Product_ID4.Length - 2));
                    parameters5[2].Value = 4;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }

                if (model.Product_ID5.Length > 2 && model.Product_ID5.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID5.Substring(2, model.Product_ID5.Length - 2));
                    parameters5[2].Value = 5;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }
                if (model.Product_ID6.Length > 2 && model.Product_ID6.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID6.Substring(2, model.Product_ID6.Length - 2));
                    parameters5[2].Value = 6;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }
                if (model.Product_ID7.Length > 2 && model.Product_ID7.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID7.Substring(2, model.Product_ID7.Length - 2));
                    parameters5[2].Value = 7;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }
                if (model.Product_ID8.Length > 2 && model.Product_ID8.Substring(0, 2).Equals("P_"))
                {
                    SqlParameter[] parameters5 = {
                        new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
                        new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@iOrder",SqlDbType.SmallInt,2)
                    };
                    parameters5[0].Value = iDesignID;
                    parameters5[1].Value = new Guid(model.Product_ID8.Substring(2, model.Product_ID8.Length - 2));
                    parameters5[2].Value = 8;
                    DbHelperSQL.GetSingle(strSql2.ToString(), parameters5);
                }*/
                return iDesignID;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageDesign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageDesign set ");
            strSql.Append("CollageTemp_ID=@CollageTemp_ID,");
            strSql.Append("CollageDesign_Status=@CollageDesign_Status,");
            strSql.Append("CollageCate_ID=@CollageCate_ID,");
            strSql.Append("CollageDesing_Title=@CollageDesing_Title,");
            strSql.Append("CollageDesign_Tag=@CollageDesign_Tag,");
            strSql.Append("CollageDesign_Inspiration=@CollageDesign_Inspiration,");
            strSql.Append("CollageDesign_CreateUserGuid=@CollageDesign_CreateUserGuid,");
            strSql.Append("CollageDesign_CreateTime=@CollageDesign_CreateTime,");
            strSql.Append("CollageDesign_UpdateTime=@CollageDesign_UpdateTime,");
            strSql.Append("CollageDesign_PublishTime=@CollageDesign_PublishTime,");
            strSql.Append("CollageDesign_HTML=@CollageDesign_HTML,");
            strSql.Append("CollageDesign_ThumbnailFileName=@CollageDesign_ThumbnailFileName");
            strSql.Append(" where CollageDesign_ID=@CollageDesign_ID");

            SqlParameter[] parameters = {
                    new SqlParameter("@CollageTemp_ID",SqlDbType.Int,4),
                    new SqlParameter("@CollageDesign_Status",SqlDbType.TinyInt,1),
                    new SqlParameter("@CollageCate_ID",SqlDbType.Int,4),
                    new SqlParameter("@CollageDesing_Title",SqlDbType.NVarChar,300),
                    new SqlParameter("@CollageDesign_Tag",SqlDbType.NVarChar,300),
                    new SqlParameter("@CollageDesign_Inspiration",SqlDbType.NVarChar,500),
                    new SqlParameter("@CollageDesign_CreateUserGuid",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@CollageDesign_CreateTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_UpdateTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_PublishTime",SqlDbType.DateTime,8),
                    new SqlParameter("@CollageDesign_HTML",SqlDbType.NVarChar,4000),
                    new SqlParameter("@CollageDesign_ThumbnailFileName",SqlDbType.NVarChar,300),
                    new SqlParameter("@CollageDesign_ID",SqlDbType.Int,4),
					};

            parameters[0].Value = model.template_id;
            parameters[1].Value = model.status_id;
            parameters[2].Value = model.cate_id;
            parameters[3].Value = model.CollageDesing_Title;
            parameters[4].Value = model.tags;
            parameters[5].Value = model.Inspiration;
            parameters[6].Value = model.guid;
            parameters[7].Value = FormatDatetimeString(model.CreateTime); //Convert.ToDateTime(model.CreateTime);
            parameters[8].Value = FormatDatetimeString(model.UpdateTime); //Convert.ToDateTime(model.UpdateTime);
            parameters[9].Value = FormatDatetimeString(model.PublishTime); //Convert.ToDateTime(model.PublishTime);
            parameters[10].Value = model.innerHTML;
            parameters[11].Value = model.thumbnail;
            parameters[12].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CollageDesign_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_CollageDesign ");
            strSql.Append(" where CollageDesign_ID=@CollageDesign_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = CollageDesign_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataSet GetCollageListForMobileApp(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * ");
            strSql.Append(" SELECT * ");
            strSql.Append("FROM   vw_CollageDesignForMobileApp");
           // strSql.Append("wn_user AS b ON a.CollageDesign_CreateUserGuid = b.guid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * ");
            strSql.Append(" SELECT a.CollageDesign_ID, a.CollageTemp_ID, a.CollageDesign_Status, a.CollageCate_ID, a.CollageDesing_Title, a.CollageDesign_Tag, a.CollageDesign_Inspiration, ");
            strSql.Append(" a.CollageDesign_CreateUserGuid, a.CollageDesign_CreateTime, a.CollageDesign_UpdateTime, a.CollageDesign_PublishTime, a.CollageDesign_HTML, ");
            strSql.Append("a.CollageDesign_ThumbnailFileName, b.username, c.CityName, d.country ");
            strSql.Append("FROM            wn_CollageDesign AS a LEFT OUTER JOIN ");
            strSql.Append("wn_user AS b ON a.CollageDesign_CreateUserGuid = b.guid LEFT OUTER JOIN ");
            strSql.Append("wn_City AS c ON b.cityid = c.CityID LEFT OUTER JOIN ");
            strSql.Append("wn_country AS d ON b.countryId = d.id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

  /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.CollageDesign DataRowToModel(DataRow row)
        {
            Twee.Model.CollageDesign model = new Twee.Model.CollageDesign();
            if (row != null)
            {
                if (row["CollageDesign_ID"] != null && row["CollageDesign_ID"].ToString() != "")
                {
                     model.id = int.Parse(row["CollageDesign_ID"].ToString());
                                    //get current desing total share couunt
                     int iTotalShare = GetDesignShareTotal(row["CollageDesign_ID"].ToString());
                     model.ShareTotalCount = iTotalShare;
                }
                if (row["CollageTemp_ID"] != null)
                {
                    model.template_id = int.Parse(row["CollageTemp_ID"].ToString());
                }
                if (row["CollageDesign_Status"] != null)
                {
                    model.status_id = short.Parse(row["CollageDesign_Status"].ToString());
                }
                if (row["CollageCate_ID"] != null)
                {
                    model.cate_id =int.Parse(row["CollageCate_ID"].ToString());
                }

                if (row["CollageDesing_Title"] != null)
                {
                    model.CollageDesing_Title = row["CollageDesing_Title"].ToString();
                }
                if (row["CollageDesign_Tag"] != null)
                {
                    model.tags = row["CollageDesign_Tag"].ToString();
                }
                if (row["CollageDesign_Inspiration"] != null)
                {
                    model.Inspiration = row["CollageDesign_Inspiration"].ToString();
                }
               

                if (row["CollageDesign_CreateUserGuid"] != null)
                {
                    model.guid =new Guid(row["CollageDesign_CreateUserGuid"].ToString());
                    if (row.Table.Columns.Contains("username"))
                    {
                        //have this columns, skip it
                    }
                    else
                    {
                        GetUserinfomation(row["CollageDesign_CreateUserGuid"].ToString(), model);
                    }
                }
                if (row["CollageDesign_CreateTime"] != null)
                {
                    model.CreateTime = row["CollageDesign_CreateTime"].ToString();
                }
                if (row["CollageDesign_UpdateTime"] != null)
                {
                    model.UpdateTime = row["CollageDesign_UpdateTime"].ToString();
                }
                if (row["CollageDesign_CreateTime"] != null)
                {
                    model.CreateTime = row["CollageDesign_CreateTime"].ToString();
                }
                if (row["CollageDesign_PublishTime"] != null)
                {
                    model.PublishTime = row["CollageDesign_PublishTime"].ToString();
                }
                if (row["CollageDesign_HTML"] != null)
                {
                    model.innerHTML = row["CollageDesign_HTML"].ToString();
                }
                if (row["CollageDesign_ThumbnailFileName"] != null)
                {
                    model.thumbnail = row["CollageDesign_ThumbnailFileName"].ToString();
                }
                if (row.Table.Columns.Contains("username") && row["username"] != null)
                {
                    model.User_name = row["username"].ToString();
                }
                if (row.Table.Columns.Contains("CityName") && row["CityName"] != null)
                {
                    model.City = row["CityName"].ToString();
                }
                if (row.Table.Columns.Contains("country") && row["country"] != null)
                {
                    model.Country = row["country"].ToString();
                }
                

            }
            return model;
        }    
    }
}
