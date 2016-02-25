using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:proDetailOtherDataMgr
    /// </summary>
    public partial class proDetailOtherDataMgr
    {
        public proDetailOtherDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_proDetailOther");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.proDetailOther model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_proDetailOther(");
            strSql.Append("proid,userid,procaizhi,procaizhicontent,prosend,prosendarea,prostockout,prostockoutinfo,prosaleservice,prosaleserviceinfo)");
            strSql.Append(" values (");
            strSql.Append("@proid,@userid,@procaizhi,@procaizhicontent,@prosend,@prosendarea,@prostockout,@prostockoutinfo,@prosaleservice,@prosaleserviceinfo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@procaizhi", SqlDbType.NVarChar,250),
					new SqlParameter("@procaizhicontent", SqlDbType.Text),
					new SqlParameter("@prosend", SqlDbType.NVarChar,50),
					new SqlParameter("@prosendarea", SqlDbType.NVarChar,50),
					new SqlParameter("@prostockout", SqlDbType.NChar,10),
					new SqlParameter("@prostockoutinfo", SqlDbType.NVarChar,250),
					new SqlParameter("@prosaleservice", SqlDbType.NChar,10),
					new SqlParameter("@prosaleserviceinfo", SqlDbType.NVarChar,250)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.procaizhi;
            parameters[3].Value = model.procaizhicontent;
            parameters[4].Value = model.prosend;
            parameters[5].Value = model.prosendarea;
            parameters[6].Value = model.prostockout;
            parameters[7].Value = model.prostockoutinfo;
            parameters[8].Value = model.prosaleservice;
            parameters[9].Value = model.prosaleserviceinfo;

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
        public bool Update(Twee.Model.proDetailOther model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_proDetailOther set ");
            strSql.Append("proid=@proid,");
            strSql.Append("userid=@userid,");
            strSql.Append("procaizhi=@procaizhi,");
            strSql.Append("procaizhicontent=@procaizhicontent,");
            strSql.Append("prosend=@prosend,");
            strSql.Append("prosendarea=@prosendarea,");
            strSql.Append("prostockout=@prostockout,");
            strSql.Append("prostockoutinfo=@prostockoutinfo,");
            strSql.Append("prosaleservice=@prosaleservice,");
            strSql.Append("prosaleserviceinfo=@prosaleserviceinfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@procaizhi", SqlDbType.NVarChar,250),
					new SqlParameter("@procaizhicontent", SqlDbType.Text),
					new SqlParameter("@prosend", SqlDbType.NVarChar,50),
					new SqlParameter("@prosendarea", SqlDbType.NVarChar,50),
					new SqlParameter("@prostockout", SqlDbType.NChar,10),
					new SqlParameter("@prostockoutinfo", SqlDbType.NVarChar,250),
					new SqlParameter("@prosaleservice", SqlDbType.NChar,10),
					new SqlParameter("@prosaleserviceinfo", SqlDbType.NVarChar,250),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.procaizhi;
            parameters[3].Value = model.procaizhicontent;
            parameters[4].Value = model.prosend;
            parameters[5].Value = model.prosendarea;
            parameters[6].Value = model.prostockout;
            parameters[7].Value = model.prostockoutinfo;
            parameters[8].Value = model.prosaleservice;
            parameters[9].Value = model.prosaleserviceinfo;
            parameters[10].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_proDetailOther ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_proDetailOther ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Twee.Model.proDetailOther GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,proid,userid,procaizhi,procaizhicontent,prosend,prosendarea,prostockout,prostockoutinfo,prosaleservice,prosaleserviceinfo from wn_proDetailOther ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.proDetailOther model = new Twee.Model.proDetailOther();
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
        public Twee.Model.proDetailOther GetModel(string proid,string userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,proid,userid,procaizhi,procaizhicontent,prosend,prosendarea,prostockout,prostockoutinfo,prosaleservice,prosaleserviceinfo from wn_proDetailOther ");
            strSql.Append(" where proid=@proid and userid=@userid");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = proid;
            parameters[1].Value = userid;

            Twee.Model.proDetailOther model = new Twee.Model.proDetailOther();
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
        public Twee.Model.proDetailOther DataRowToModel(DataRow row)
        {
            Twee.Model.proDetailOther model = new Twee.Model.proDetailOther();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["proid"] != null)
                {
                    model.proid = row["proid"].ToString();
                }
                if (row["userid"] != null)
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["procaizhi"] != null)
                {
                    model.procaizhi = row["procaizhi"].ToString();
                }
                if (row["procaizhicontent"] != null)
                {
                    model.procaizhicontent = row["procaizhicontent"].ToString();
                }
                if (row["prosend"] != null)
                {
                    model.prosend = row["prosend"].ToString();
                }
                if (row["prosendarea"] != null)
                {
                    model.prosendarea = row["prosendarea"].ToString();
                }
                if (row["prostockout"] != null)
                {
                    model.prostockout = row["prostockout"].ToString();
                }
                if (row["prostockoutinfo"] != null)
                {
                    model.prostockoutinfo = row["prostockoutinfo"].ToString();
                }
                if (row["prosaleservice"] != null)
                {
                    model.prosaleservice = row["prosaleservice"].ToString();
                }
                if (row["prosaleserviceinfo"] != null)
                {
                    model.prosaleserviceinfo = row["prosaleserviceinfo"].ToString();
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
            strSql.Append("select id,proid,userid,procaizhi,procaizhicontent,prosend,prosendarea,prostockout,prostockoutinfo,prosaleservice,prosaleserviceinfo ");
            strSql.Append(" FROM wn_proDetailOther ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Twee.Model.proDetailOther> GetEntityList(string where) {
            List<Twee.Model.proDetailOther> list = new List<Model.proDetailOther>();
            DataTable dt = GetList(where).Tables[0];
            if (null == dt || dt.Rows.Count == 0)
                return null;
            foreach (DataRow row in dt.Rows) {
                list.Add(DataRowToModel(row));
            }
            return list;
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
            strSql.Append(" id,proid,userid,procaizhi,procaizhicontent,prosend,prosendarea,prostockout,prostockoutinfo,prosaleservice,prosaleserviceinfo ");
            strSql.Append(" FROM wn_proDetailOther ");
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
            strSql.Append("select count(1) FROM wn_proDetailOther ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wn_proDetailOther T ");
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
            parameters[0].Value = "wn_proDetailOther";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

