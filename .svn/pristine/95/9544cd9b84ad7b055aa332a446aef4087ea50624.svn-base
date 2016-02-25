using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;
using System.Data;
using Twee.Comm;
using TweebaaWebApp.MasterPages;
using Newtonsoft.Json;

namespace TweebaaWebApp.Product
{
    
    public partial class shopCart2 : BasePage
    {
        public static readonly string picPath="https://tweebaa.com/";
        private Guid? userGuid;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("<script>alert('Please login！')</script>");
                return;
            }
            QueryShopCart();
        }

        /// <summary>
        /// 查询购物车
        /// </summary>
        private void QueryShopCart()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["cartids"]))
            {
                QueryByCartIds(CommHelper.GetStrDecode(Request.QueryString["cartids"].ToString()));
                return;
            }
            string state = Request.QueryString["state"].ToNullString();
            ShoppingcartMgr mgr = new ShoppingcartMgr();
            Shoppingcart shoppingcart = new Shoppingcart();
            DataTable dt = mgr.GetMyShopCart(state, userGuid.Value);
            repData.DataSource = dt;
            repData.DataBind();           

        }

         /// <summary>
         /// 根据购物车选择要结算的商品的 cartid查询
        /// </summary>
        /// <param name="cartids"></param>
        private void QueryByCartIds(string cartids)
        {
            ShoppingcartMgr mgr = new ShoppingcartMgr();         
            DataTable dt = mgr.GetMyCheckedShopCart(cartids, userGuid.Value);
            if (dt == null || dt.Rows.Count == 0)
            {
                repData.DataSource = dt;
                repData.DataBind();    
            }  
        }

    }
}