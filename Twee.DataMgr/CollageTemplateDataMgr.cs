﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public partial class CollageTemplateDataMgr
    {
        public CollageTemplateDataMgr()
        {

        }

        public DataSet GetListByPage(string strWhere, int iFirst, int iLast)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (SELECT *, ROW_NUMBER() OVER (ORDER BY CollageTemp_ID ) AS 'RowNumber'");
            strSql.Append(" from wn_CollageTemp  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere +" and CollageTemp_IsActive=1");
            }
            else
            {
                strSql.Append("where CollageTemp_IsActive=1");
            }
            strSql.Append(") as a WHERE RowNumber BETWEEN " + iFirst);
            strSql.Append("AND " + iLast);
            return DbHelperSQL.Query(strSql.ToString());

        }
        public int GetBackgroundImgTotal()
        {
            

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) as count FROM wn_CollageDecorationImg where CollageDecorationImg_IsActive=5");

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
        public int GetDecorationImgTotal(string sWhere)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) as count FROM wn_CollageDecorationImg where " + sWhere);

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

        public List<Twee.Model.CollageBackgroundImg> GetBackgroundImg(string sPage)
        {
            List<Twee.Model.CollageBackgroundImg> model_list=new List<Twee.Model.CollageBackgroundImg>();

            StringBuilder strSql = new StringBuilder();

            int iPage = int.Parse(sPage);
            int iFirst = (iPage -1) * 20 + 1;
            int iLast = iPage * 20;

            strSql.Append("select * from (SELECT *, ROW_NUMBER() OVER (ORDER BY CollageBackgroundImg_ID ) AS 'RowNumber'");
            strSql.Append(" from wn_CollageDecorationImg  ");
            strSql.Append("where CollageDecorationImg_IsActive=5");
            
            strSql.Append(") as a WHERE RowNumber BETWEEN " + iFirst);
            strSql.Append("AND " + iLast);

           // strSql.Append("SELECT * FROM wn_CollageBackgroundImg where CollageBackgroundImg_IsActive=1");


            
            
            using(SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    Twee.Model.CollageBackgroundImg model = new Twee.Model.CollageBackgroundImg();

                    model.CollageBackgroundImg_ID = Convert.ToInt32(rdr["CollageBackgroundImg_ID"]);
                    model.CollageBackgroundImg_Name =rdr["CollageBackgroundImg_Name"].ToString();
                    model.CollageBackgroundImg_TransparentName=rdr["CollageBackgroundImg_TransparentName"].ToString();
                    model_list.Add(model);
                }
            }
            return model_list;

        }

        public List<Twee.Model.CollageDecorationImg> GetDecorationImg(string sPage, string sPageDiv, string sWhere)
        {
            List<Twee.Model.CollageDecorationImg> model_list=new List<Twee.Model.CollageDecorationImg>();

            StringBuilder strSql = new StringBuilder();

            int iPage = int.Parse(sPage);
            int iPageDiv = int.Parse(sPageDiv);
            if (iPageDiv < 0) iPageDiv = 20;
            int iFirst = (iPage - 1) * iPageDiv + 1;
            int iLast = iPage * iPageDiv;

            strSql.Append("select * from (SELECT *, ROW_NUMBER() OVER (ORDER BY CollageDecorationImg_ID desc) AS 'RowNumber'");
            strSql.Append(" from wn_CollageDecorationImg  ");
            strSql.Append("where " + sWhere);

            strSql.Append(") as a WHERE RowNumber BETWEEN " + iFirst);
            strSql.Append("AND " + iLast);

          //  strSql.Append("SELECT * FROM wn_CollageDecorationImg where CollageDecorationImg_IsActive=1");

            using(SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    Twee.Model.CollageDecorationImg model = new Twee.Model.CollageDecorationImg();
                    model.CollageDecorationImg_ID =Convert.ToInt32(rdr["CollageDecorationImg_ID"]);
                    model.CollageDecorationImg_Name =rdr["CollageDecorationImg_Name"].ToString();
                    model.CollageDecorationImgTransparentName=rdr["CollageDecorationImgTransparentName"].ToString();
                    model_list.Add(model);
                }
            }
            return model_list;

        }
        public Twee.Model.CollageTemplate GetTemplateByID(string templateID)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM wn_CollageTemp where CollageTemp_IsActive=1 and CollageTemp_ID=");
            strSql.Append(templateID);


            Twee.Model.CollageTemplate model = new Twee.Model.CollageTemplate();
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    model.id = Convert.ToInt32(rdr["CollageTemp_ID"]);
                    model.Name = rdr["CollageTemp_Name"].ToString();
                    model.Thumbnail = rdr["CollageTemp_ThumbnailFileName"].ToString();
                    model.innerHTML = rdr["CollageTemp_HTML"].ToString();
                    //string column = rdr["ColumnName"].ToString();
                    //int columnValue = Convert.ToInt32(rdr["ColumnName"]);
                    //var myString = rdr.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                    // Do somthing with this rows string, for example to put them in to a list
                    //listDeclaredElsewhere.Add(myString);
                }
            }
            return model;

        }

        /*
         *  用户进入 Collage 的时候，随机取一条记录
         */
        public Twee.Model.CollageTemplate GetFirstRandom()
        {

            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM wn_CollageTemp where CollageTemp_IsActive=1 ORDER BY NEWID()");


            
            Twee.Model.CollageTemplate model = new Twee.Model.CollageTemplate();
            using(SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    model.id=Convert.ToInt32(rdr["CollageTemp_ID"]);
                    model.Name=rdr["CollageTemp_Name"].ToString();
                    model.Thumbnail=rdr["CollageTemp_ThumbnailFileName"].ToString();
                    model.innerHTML=rdr["CollageTemp_HTML"].ToString();
                    //string column = rdr["ColumnName"].ToString();
                    //int columnValue = Convert.ToInt32(rdr["ColumnName"]);
                    //var myString = rdr.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                    // Do somthing with this rows string, for example to put them in to a list
                    //listDeclaredElsewhere.Add(myString);
                }
            }
            return model;
            
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageTemplate model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_CollageTemp(");
            strSql.Append("CollageTemp_Name,CollageTemp_ThumbnailFileName,CollageTemp_HTML)");
            strSql.Append(" values (");
            strSql.Append("@CollageTemp_Name,@CollageTemp_ThumbnailFileName,@CollageTemp_HTML)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageTemp_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@CollageTemp_ThumbnailFileName", SqlDbType.NVarChar,50),
                    new SqlParameter("@CollageTemp_HTML", SqlDbType.NVarChar,3000)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Thumbnail;
            parameters[2].Value = model.innerHTML;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.CollageTemplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageTemp set ");
            strSql.Append("CollageTemp_Name=@CollageTemp_Name,");
            strSql.Append("CollageTemp_ThumbnailFileName=@CollageTemp_ThumbnailFileName,");
            strSql.Append("CollageTemp_HTML=@CollageTemp_HTML");
            
            strSql.Append(" where CollageCate_ID=@CollageCate_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageTemp_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@CollageTemp_ThumbnailFileName", SqlDbType.NVarChar,50),
                    new SqlParameter("@CollageTemp_HTML", SqlDbType.NVarChar,3000),
					new SqlParameter("@CollageTemp_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Thumbnail;
            parameters[2].Value = model.innerHTML;
            parameters[3].Value = model.id;

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
        public bool Delete(int CollageTemp_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_CollageTemp ");
            strSql.Append(" where CollageTemp_ID=@CollageTemp_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageTemp_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = CollageTemp_ID;

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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM wn_CollageTemp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere + " and CollageTemp_IsActive=1");
            }
            else
            {
                strSql.Append("where CollageTemp_IsActive=1");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.CollageTemplate DataRowToModel(DataRow row)
        {
            Twee.Model.CollageTemplate model = new Twee.Model.CollageTemplate();
            if (row != null)
            {
                if (row["CollageTemp_ID"] != null && row["CollageTemp_ID"].ToString() != "")
                {
                    model.id = int.Parse(row["CollageTemp_ID"].ToString());
                }
                if (row["CollageTemp_Name"] != null)
                {
                    model.Name = row["CollageTemp_Name"].ToString();
                }
                if (row["CollageTemp_ThumbnailFileName"] != null)
                {
                    model.Thumbnail = row["CollageTemp_ThumbnailFileName"].ToString();
                }
                if (row["CollageTemp_HTML"] != null)
                {
                    model.innerHTML = row["CollageTemp_HTML"].ToString();
                }

            }
            return model;
        }        
    }
}
