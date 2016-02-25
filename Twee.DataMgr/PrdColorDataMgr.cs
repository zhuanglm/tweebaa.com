using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;

namespace Twee.DataMgr
{
    public class PrdColorDataMgr
    {
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.PrdColor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prdColor(");
            strSql.Append("prdguid,colorguid,colorname,edttime)");
            strSql.Append(" values (");
            strSql.Append("@prdguid,@colorguid,@colorname,@edttime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@colorname", SqlDbType.NVarChar,50),
					new SqlParameter("@edttime", SqlDbType.DateTime)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.colorname;
            parameters[3].Value = model.edttime;

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
        public bool Update(Twee.Model.PrdColor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_prdColor set ");
            strSql.Append("prdguid=@prdguid,");
            strSql.Append("colorguid=@colorguid,");
            strSql.Append("colorname=@colorname,");
            strSql.Append("edttime=@edttime");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@colorname", SqlDbType.NVarChar,50),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters[0].Value = model.prdguid;
            parameters[1].Value = model.colorguid;
            parameters[2].Value = model.colorname;
            parameters[3].Value = model.edttime;
            parameters[4].Value = model.idx;

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
        public bool Delete(int idx)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdColor ");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@idx", SqlDbType.Int,4)
			};
            parameters[0].Value = idx;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idxlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prdColor ");
            strSql.Append(" where idx in (" + idxlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.PrdColor GetModel(int idx)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 prdguid,colorguid,colorname,idx,edttime from wn_prdColor ");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@idx", SqlDbType.Int,4)
			};
            parameters[0].Value = idx;

            Twee.Model.PrdColor model = new Twee.Model.PrdColor();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.PrdColor DataRowToModel(DataRow row)
        {
            Twee.Model.PrdColor model = new Twee.Model.PrdColor();
            if (row != null)
            {
                if (row["prdguid"] != null && row["prdguid"].ToString() != "")
                {
                    model.prdguid = new Guid(row["prdguid"].ToString());
                }
                if (row["colorguid"] != null && row["colorguid"].ToString() != "")
                {
                    model.colorguid = new Guid(row["colorguid"].ToString());
                }
                if (row["colorname"] != null)
                {
                    model.colorname = row["colorname"].ToString();
                }
                if (row["idx"] != null && row["idx"].ToString() != "")
                {
                    model.idx = int.Parse(row["idx"].ToString());
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select prdguid,colorguid,colorname,idx,edttime,colorvalue ");
            strSql.Append(" FROM wn_prdColor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" prdguid,colorguid,colorname,idx,edttime,colorvalue ");
            strSql.Append(" FROM wn_prdColor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wn_prdColor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.idx desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prdColor T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "wn_prdColor";
            parameters[1].Value = "idx";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region 前端  叠图需要

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetColor(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select colorvalue value ");
            strSql.Append(" FROM wn_prdColor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  

        #region 后台方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool MgeAdd(string colorName, string colorPic, int orderIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_color(");
            strSql.Append("colorguid,colorname,colorpic,idx)");
            strSql.Append(" values (");
            strSql.Append("@colorguid,@colorname,@colorpic,@idx)");
            SqlParameter[] parameters = {
				  new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16),
                  new SqlParameter("@colorname", SqlDbType.NVarChar,20),
                  new SqlParameter("@colorname", SqlDbType.NVarChar,250),
                  new SqlParameter("@colorname", SqlDbType.Int),
        };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = colorName;
            parameters[2].Value = colorPic;
            parameters[3].Value = orderIndex;

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
        /// 更新一条数据
        /// </summary>
        public bool MgeUpdate()
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update wn_color set ");
            //strSql.Append("colorguid=@colorguid");
            //strSql.Append(" where colorguid=@colorguid ");
            //SqlParameter[] parameters = {
            //            new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16)};
            //parameters[0].Value = model.colorguid;

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool MgeDelete(Guid colorguid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_color ");
            strSql.Append(" where colorguid=@colorguid ");
            SqlParameter[] parameters = {
					new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = colorguid;

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
        /// 获取颜色列表
        /// </summary>
        public DataTable MgeGetAllColor()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from wn_color ");

            //strSql.Append(" where colorguid=@colorguid ");
            //SqlParameter[] parameters = {
            //            new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16)			};
            //parameters[0].Value = colorguid;

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 获取某产品颜色
        /// </summary>
        public DataTable MgeGetPrdColor(string prdguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select colorguid,colorname from dbo.wn_prdColor where prdguid ='" + prdguid + "'");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 删除某产品颜色
        /// </summary>
        public bool MgeDeletePrdColor(string prdguid, string colorguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete  from dbo.wn_prdColor where prdguid ='" + prdguid + "'");
            if (!string.IsNullOrEmpty(colorguid))
            {
                strSql.Append(" and colorguid='" + colorguid + "'");
            }
            int resu = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (resu > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 添加某产品颜色
        /// </summary>
        public bool MgeAddPrdColor(Guid prdgui, Guid colorguid, string colorname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into  dbo.wn_prdColor (colorguid,prdguid, colorname,edttime) values(");
            strSql.Append(" @colorguid,@prdguid,@colorname,@edttime) ");
            SqlParameter[] parameters = {
				  new SqlParameter("@colorguid", SqlDbType.UniqueIdentifier,16),
                  new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
                  new SqlParameter("@colorname", SqlDbType.NVarChar,20),
                //  new SqlParameter("@idx", SqlDbType.Int,4),
                  new SqlParameter("@edttime", SqlDbType.DateTime),
        };
            parameters[0].Value = colorguid;
            parameters[1].Value = prdgui;
            parameters[2].Value = colorname;
            //parameters[3].Value = 0;
            parameters[3].Value = DateTime.Now;

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
        #endregion
    }
}
