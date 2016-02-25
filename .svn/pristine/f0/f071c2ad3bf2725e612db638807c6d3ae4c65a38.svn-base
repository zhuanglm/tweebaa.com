using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public partial class CollageCategoryDataMgr
    {
        public CollageCategoryDataMgr()
        {
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageCategory  model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_CollageCate(");
            strSql.Append("CollageCate_Name)");
            strSql.Append(" values (");
            strSql.Append("@CollageCate_Name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageCate_Name", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.CategoryName;

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
        public bool Update(Twee.Model.CollageCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageCate set ");
            strSql.Append("CollageCate_Name=@CollageCate_Name");
            strSql.Append(" where CollageCate_ID=@CollageCate_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageCate_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@CollageCate_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CategoryName;
            parameters[1].Value = model.id;

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
        public bool Delete(int CollageCate_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_CollageCate ");
            strSql.Append(" where CollageCate_ID=@CollageCate_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageCate_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = CollageCate_ID;

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
            strSql.Append(" FROM wn_CollageCate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.CollageCategory DataRowToModel(DataRow row)
        {
            Twee.Model.CollageCategory model = new Twee.Model.CollageCategory();
            if (row != null)
            {
                if (row["CollageCate_ID"] != null && row["CollageCate_ID"].ToString() != "")
                {
                    model.id = int.Parse(row["CollageCate_ID"].ToString());
                }
                if (row["CollageCate_Name"] != null)
                {
                    model.CategoryName = row["CollageCate_Name"].ToString();
                }
            }
            return model;
        }
    }
}
