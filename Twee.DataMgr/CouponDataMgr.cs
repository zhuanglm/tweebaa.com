using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public partial class CouponDataMgr
    {
        public CouponDataMgr()
        { }

        public float CheckCoupon(string strCouponCode, string strOrderTotal, string strUserGuid)
        {
            float intRes = -99.99f;
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("[spCheckCouponCode]", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] parameters = new SqlParameter[] { 
                                new SqlParameter("@coupon_code",SqlDbType.NVarChar,50),
                                new SqlParameter("@userGuid", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@order_total",SqlDbType.Decimal),
                                new SqlParameter("@ret",SqlDbType.Decimal)
                            };
                        parameters[0].Value = strCouponCode;
                        parameters[1].Value = strUserGuid.ToGuid();
                        parameters[2].Precision = 18;
                        parameters[2].Scale = 2;
                        parameters[2].Value = strOrderTotal;
                        parameters[3].Precision = 18;
                        parameters[3].Scale = 2;
                        parameters[3].Direction = ParameterDirection.Output;

                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.ExecuteNonQuery();
                        intRes = float.Parse(parameters[3].Value.ToString()); //返回值:1成功，-1已存在
                       
                    }
                    catch (Exception ex)
                    {
                        Twee.Comm.CommUtil.GenernalErrorHandler(ex);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return intRes;
        }

        public int CouponAdd(Twee.Model.Coupons coupon)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_Coupons(");
            strSql.Append("coupon_type,coupon_code,coupon_amount,coupon_minimum_order,coupon_start_date,coupon_expire_date,uses_per_coupon,uses_per_user,is_restrict_to_products,is_restrict_to_categories,is_restrict_to_customers,coupon_active,coupon_title)");
            strSql.Append(" values (");
            strSql.Append("@coupon_type,@coupon_code,@coupon_amount,@coupon_minimum_order,@coupon_start_date,@coupon_expire_date,@uses_per_coupon,@uses_per_user,@is_restrict_to_products,@is_restrict_to_categories,@is_restrict_to_customers,@coupon_active,@coupon_title)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@coupon_type",SqlDbType.NChar,1),
                    new SqlParameter("@coupon_code",SqlDbType.NVarChar,50),
                    new SqlParameter("@coupon_amount",SqlDbType.Decimal),
                    new SqlParameter("@coupon_minimum_order",SqlDbType.Decimal),
                    new SqlParameter("@coupon_start_date",SqlDbType.DateTime),
                    new SqlParameter("@coupon_expire_date",SqlDbType.DateTime),
                    new SqlParameter("@uses_per_coupon",SqlDbType.SmallInt),
                    new SqlParameter("@uses_per_user",SqlDbType.SmallInt),
                    new SqlParameter("@is_restrict_to_products",SqlDbType.TinyInt),
                    new SqlParameter("@is_restrict_to_categories",SqlDbType.TinyInt),
                    new SqlParameter("@is_restrict_to_customers",SqlDbType.TinyInt),
                    new SqlParameter("@coupon_active",SqlDbType.TinyInt),
                    new SqlParameter("@coupon_title",SqlDbType.NVarChar,200),
           };
            parameters[0].Value = coupon.CouponType;
            parameters[1].Value = coupon.CouponCode;
            parameters[2].Value = coupon.CouponAmount;
            parameters[3].Value = coupon.CouponMinimumOrder;
            parameters[4].Value = coupon.CouponStartDate;
            parameters[5].Value = coupon.CouponExpireDate;
            parameters[6].Value = coupon.UsesPerCoupon;
            parameters[7].Value = coupon.UsesPerUser;
            parameters[8].Value = coupon.IsRestrictToProducts;
            parameters[9].Value = coupon.IsRestrictToCategories;
            parameters[10].Value = 0;// coupon.IsRestrictToCustomers;
            parameters[11].Value = coupon.CouponActive;
            parameters[12].Value = coupon.CouponName;
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
        public bool Update(Twee.Model.Coupons coupon)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_Coupons set ");
            strSql.Append("coupon_type=@coupon_type,coupon_code=@coupon_code,coupon_amount=@coupon_amount,coupon_minimum_order=@coupon_minimum_order,coupon_start_date=@coupon_start_date,coupon_expire_date=@coupon_expire_date,uses_per_coupon=@uses_per_coupon,uses_per_user=@uses_per_user,is_restrict_to_products=@is_restrict_to_products,is_restrict_to_categories=@is_restrict_to_categories,is_restrict_to_customers=@is_restrict_to_customers,coupon_active=@coupon_active,date_modified=@date_modified,coupon_title=@coupon_title");
            strSql.Append(" where coupon_id=@coupon_id");
            SqlParameter[] parameters = {
					new SqlParameter("@coupon_type",SqlDbType.NChar,1),
                    new SqlParameter("@coupon_code",SqlDbType.NVarChar,50),
                    new SqlParameter("@coupon_amount",SqlDbType.Decimal),
                    new SqlParameter("@coupon_minimum_order",SqlDbType.Decimal),
                    new SqlParameter("@coupon_start_date",SqlDbType.DateTime),
                    new SqlParameter("@coupon_expire_date",SqlDbType.DateTime),
                    new SqlParameter("@uses_per_coupon",SqlDbType.SmallInt),
                    new SqlParameter("@uses_per_user",SqlDbType.SmallInt),
                    new SqlParameter("@is_restrict_to_products",SqlDbType.TinyInt),
                    new SqlParameter("@is_restrict_to_categories",SqlDbType.TinyInt),
                    new SqlParameter("@is_restrict_to_customers",SqlDbType.TinyInt),
                    new SqlParameter("@coupon_active",SqlDbType.TinyInt),
                    new SqlParameter("@date_modified",SqlDbType.DateTime),
                    new SqlParameter("@coupon_title",SqlDbType.NVarChar,200),
                    new SqlParameter("@coupon_id",SqlDbType.Int),
           };
            parameters[0].Value = coupon.CouponType;
            parameters[1].Value = coupon.CouponCode;
            parameters[2].Value = coupon.CouponAmount;
            parameters[3].Value = coupon.CouponMinimumOrder;
            parameters[4].Value = coupon.CouponStartDate;
            parameters[5].Value = coupon.CouponExpireDate;
            parameters[6].Value = coupon.UsesPerCoupon;
            parameters[7].Value = coupon.UsesPerUser;
            parameters[8].Value = coupon.IsRestrictToProducts;
            parameters[9].Value = coupon.IsRestrictToCategories;
            parameters[10].Value = "0";// coupon.IsRestrictToCustomers;
            parameters[11].Value = coupon.CouponActive;
            parameters[12].Value = DateTime.Now;
            parameters[13].Value = coupon.CouponName;
            parameters[14].Value = coupon.CouponID;

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
            strSql.Append("delete from wn_Coupons ");
            strSql.Append(" where coupon_id=@id");
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
        public DataTable MgeGetPageCoupons(bool bActiveOnly, int iStartRow, int iEndRow, out int iTotalCount, string strWhere)
        {
            StringBuilder sSqlComm = new StringBuilder();

            sSqlComm.Append(" SELECT ROW_NUMBER() OVER ( order by TT.date_modified desc) as Row,  ");
            sSqlComm.Append("  TT.coupon_id,TT.coupon_start_date,TT.coupon_expire_date, TT.coupon_title, TT.coupon_code,TT.coupon_amount, TT.coupon_active from wn_Coupons as TT ");
            sSqlComm.Append(strWhere);
            if (bActiveOnly)
            {
                sSqlComm.Append(" and TT.coupon_active = 1");
            }

            // retrieve total count
            StringBuilder sSql = new StringBuilder();
            iTotalCount = 0;
            sSql.Append("select count(*) from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTotalCount = dt.Rows[0][0].ToString().ToInt();
                }
            }

            // retrieve data list
            sSql.Clear();
            sSql.Append("select * from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");
            sSql.Append(" where t.Row between " + iStartRow.ToString() + " and " + iEndRow.ToString());

            ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }
        public DataTable LoadSingleCoupon(string sCouponID)
        {
            StringBuilder sSqlComm = new StringBuilder();
            sSqlComm.Append("select * from wn_Coupons where coupon_id=" + sCouponID);
            DataSet ds = DbHelperSQL.Query(sSqlComm.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }
        public void ChangeCouponStatus(bool bIsActive,string sCouponID)
        {
            StringBuilder sSqlComm = new StringBuilder();
            if (bIsActive)
            {
                sSqlComm.Append("update wn_Coupons set coupon_active=1 where coupon_id=" + sCouponID);
            }
            else
            {
                sSqlComm.Append("update wn_Coupons set coupon_active=0 where coupon_id=" + sCouponID);
            }
            DbHelperSQL.ExecuteSql(sSqlComm.ToString());
        }
     }

}
