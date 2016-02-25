using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public partial  class CheckoutTmpDataMgr
    {
        public CheckoutTmpDataMgr()
        {

        }
        public int Add(Twee.Model.CheckoutTmp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_checkout_tmp(");
            strSql.Append("OrderNo,checkout_useremail,checkout_shipping_details,checkout_order_extra,checkout_order_total,checkout_username,checkout_shoppingCartID)");
            strSql.Append(" values (");
            strSql.Append("@OrderNo,@checkout_useremail,@checkout_shipping_details,@checkout_order_extra,@checkout_order_total,@checkout_username,@checkout_shoppingCartID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@checkout_useremail", SqlDbType.NVarChar,50),
                    new SqlParameter("@checkout_shipping_details", SqlDbType.NVarChar,1000),
                    new SqlParameter("@checkout_order_extra", SqlDbType.NVarChar,2000),
					new SqlParameter("@checkout_order_total", SqlDbType.NText),
                    new SqlParameter("@checkout_username", SqlDbType.NVarChar,100),
                    new SqlParameter("@checkout_shoppingCartID",SqlDbType.NVarChar,2000)                   
                                        };
            parameters[0].Value = model.Ordernum;
            parameters[1].Value = model.shipping_useremail;
            parameters[2].Value = model.Shipping_details;  

            parameters[3].Value = model.Shipping_order_extra;
            parameters[4].Value = model.Shipping_order_total;
            parameters[5].Value = model.shipping_username;
            parameters[6].Value = model.ShoppingCartID;

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
        public Twee.Model.CheckoutTmp GetCheckoutTmp(string OrderNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from wn_checkout_tmp ");
            strSql.Append(" where OrderNo=@OrderNo");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = OrderNo;

            Twee.Model.CheckoutTmp model = new Twee.Model.CheckoutTmp();
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

        public Twee.Model.CheckoutTmp DataRowToModel(DataRow row)
        {
            Twee.Model.CheckoutTmp model = new Twee.Model.CheckoutTmp();
            if (row != null)
            {
                if (row["OrderNo"] != null && row["OrderNo"].ToString() != "")
                {
                    model.Ordernum = row["OrderNo"].ToString();
                }
                if (row["checkout_useremail"] != null)
                {
                    model.shipping_useremail = row["checkout_useremail"].ToString();
                }
                if (row["checkout_shipping_details"] != null && row["checkout_shipping_details"].ToString() != "")
                {
                    model.Shipping_details = row["checkout_shipping_details"].ToString();
                }
                if (row["checkout_order_extra"] != null && row["checkout_order_extra"].ToString() != "")
                {
                    model.Shipping_order_extra = row["checkout_order_extra"].ToString();
                }
                if (row["checkout_order_total"] != null && row["checkout_order_total"].ToString() != "")
                {
                    model.Shipping_order_total = row["checkout_order_total"].ToString();
                }
                if (row["checkout_username"] != null)
                {
                    model.shipping_username = row["checkout_username"].ToString();
                }
                if (row["checkout_shoppingCartID"] != null)
                {
                    model.ShoppingCartID = row["checkout_shoppingCartID"].ToString();
                }
            }
            return model;
        }
    }
}
