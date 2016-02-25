using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp2.MasterPages;
using System.Reflection;
using log4net;
using System.Web.Script.Serialization;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class orderAjax : BasePage
    {
        private Guid? userGuid;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            //if (isLogion == false)
            //{
            //    Response.Write("-1");
            //    return;
            //}
            //else
            //{
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string cartInfo = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
                action = dic["action"].ToString();
                if (action == "add")
                {
                    AddOrder();
                }
                else if (action == "delet")
                {
                    DeletOrder();
                }
                else if (action == "query")
                {
                    QueryOrder();
                }
                else if (action == "queryhome")
                {
                    QueryHomeOrder();
                }
                else if (action == "queryhomecount")
                {
                    GetHomeOrderRecordCount();
                }
                else if (action=="detial")
                {
                    QueryHomeOrderDetial();
                }
                else if (action == "QueryHomeOrderShipmentDetail")
                {
                    QueryHomeOrderShipmentDetail();
                }
                else if (action == "QueryHomeOrderReturnDetail")
                {
                    QueryHomeOrderReturnDetail();
                }

                else if (action=="updateState")
                {
                    UpdateState();
                }
                else if (action == "updateLogisticsCost")
                {
                    UpdateLogisticsCost();
                }
                else if (action == "query_free_product")
                {
                    QueryFreeProduct();
                }

            //}
        }


        private void QueryFreeProduct()
        {
            if (userGuid == null)
            {
                Response.Write("-1");
            }
            else
            {
                string cartGuids = CommHelper.GetStrDecode(dic["cartGuid"].ToString());
                if (cartGuids == "" || cartGuids == "undefined")
                {
                    CookiesHelper cookie = new CookiesHelper();
                    string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                    cartGuids = cookie.getCookie(keyShopCart);
                    //  cookie.createCookie(keyShopCart, "", -1);
                }
                ShoppingcartMgr mgrShopCart = new ShoppingcartMgr();
                if (string.IsNullOrEmpty(cartGuids))
                {
                    /*
                    Response.Write("-2");
                    return;
                     * */
                    //get shopping cart from database
                    DataSet ds = mgrShopCart.GetList(" userguid='" + userGuid.ToString() + "'");
                    if (ds == null || ds.Tables.Count == 0)
                    {
                        Response.Write("-2");
                        return;
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            Response.Write("-2");
                            return;
                        }
                        cartGuids = "";
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            cartGuids = cartGuids + ds.Tables[0].Rows[i]["guid"].ToString() + ",";
                        }
                        cartGuids = cartGuids.Substring(0, cartGuids.Length - 1);
                    }
                }
                string[] ids = cartGuids.Split(',');
                Twee.Mgr.OrderMgr orderMgr = new OrderMgr();
                DataTable freeProductID = orderMgr.GetFreeProductGuidForEvents(userGuid.ToString());
                if (freeProductID == null)
                {
                    //No Record
                    Response.Write("-1");
                }
                else
                {
                    bool bHaveFreeProduct = false;
                    
                    for (int i = 0; i < ids.Length; i++)
                    {
                        string id = ids[i].ToString().Replace("'", "").Trim();
                        id = id.Replace("&#39;", "");
                        id = id.Replace("&#39;", "");
                        if (id.Length == Guid.Empty.ToString().Length) // && id == freeProductID.Rows[0]["ProductGuid"].ToString())
                        {
                            Shoppingcart shoppingcart = mgrShopCart.GetModel(id.ToGuid().Value);
                            if (shoppingcart != null && freeProductID.Rows[0]["ProductGuid"].ToString() == shoppingcart.prdguid.ToString())
                            {
                                bHaveFreeProduct = true;
                            }

                        }
                    }
                    if (!bHaveFreeProduct)
                    {
                        Response.Write("-1");
                    }
                    else if (bHaveFreeProduct && ids.Length > 2)
                    {
                        Response.Write("-1");//只能Checkout Free Product，不能包括其他产品
                    }
                    else if (bHaveFreeProduct && ids.Length == 1)
                    {
                        //update Order number
                        Response.Write("0");
                    }
                    else if (bHaveFreeProduct && ids.Length == 2 && ids[1].Length == 0)
                    {
                        //update Order number
                        Response.Write("0");
                    }
                    else
                    {
                        Response.Write("-1");
                    }
                }
            }
        }
        /// <summary>
        /// 从购物车选中支付数据添加到订单
        /// </summary>
        private void AddOrder()
        {
            try
            {
                string cartGuids = CommHelper.GetStrDecode(dic["cartGuids"].ToString());
                if (cartGuids != "")
                {
                    string[] ids = cartGuids.Split(',');
                    Orderhead orderHead = new Orderhead();
                    orderHead.guid = Guid.NewGuid();
                    orderHead.addressguid = dic["addressId"].ToString().ToGuid().Value;//订单收货地址guid
                    orderHead.guidno = CommUtil.CreateOrderNum();//订单编号
                    orderHead.messageWord = dic["message"].ToString();//订单留言
                    orderHead.userguid = userGuid.Value;//订单user
                    orderHead.wnstat = 1;//订单状态
                    List<OrderBody> listBody = new List<OrderBody>();
                    ShoppingcartMgr mgr = new ShoppingcartMgr();
                    proPriceAreaMgr price = new proPriceAreaMgr();
                    //string deleteCartIDs = "";
                    for (int i = 0; i < ids.Length; i++)
                    {
                        string id = ids[i].ToString().Replace("'", "").Trim();
                        Shoppingcart shoppingcart = mgr.GetModel(id.ToGuid().Value);
                        OrderBody orderBody = new OrderBody();
                        orderBody.guid = Guid.NewGuid();
                        orderBody.headGuid = orderHead.guid;//订单id
                        orderBody.prdGuid = shoppingcart.prdguid;//产品id
                        orderBody.quantity = shoppingcart.quantity;//产品数量
                        orderBody.idx = i;//该产品顺序号
                        orderBody.ruleid = shoppingcart.ruleid;//订单产品规格
                        //根据购买规格和数量获取对应销售价格
                        orderBody.buydanJia = price.GetSalePrice(orderBody.ruleid.Value, orderBody.quantity.Value);
                        orderBody.shipmethodid = shoppingcart.shipmethodid;
                        listBody.Add(orderBody);
                        //deleteCartIDs += "'" + ids[i].ToString() + "',";
                    }
                    OrderMgr orderMgr = new OrderMgr();
                    bool b = orderMgr.AddOrder(orderHead, listBody);
                    if (b)
                    {
                        //mgr.DeleteList(cartGuids);//删除购物车（在订单结算之后再删除该购物车记录）
                        Response.Write(orderHead.guidno);//订单创建成功，返回订单号
                        return;
                    }
                    Response.Write("0");
                }
            }
            catch (Exception)
            {
                Response.Write("0");
            }
           
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        private void QueryOrder()
        {
            try
            {
                if (userGuid==null)
                {
                    Response.Write("-1");
                    return;
                }
                string orderNo = dic["orderNo"].ToString();
                if (orderNo!="")
                {
                    OrderMgr orderMgr = new OrderMgr();
                    DataTable dt = orderMgr.GetOrderByOrserNo(orderNo);
                    //List<Order> listModel = orderMgr.DataTableToList(orderMgr.GetOrder(userGuid.Value));
                    string data = JsonConvert.SerializeObject(dt);
                    Response.Clear();
                    Response.Write(data);
                    return;
                }
                Response.Write("");
            }
            catch (Exception)
            {
                Response.Write("");
            }
          
        }

        /// <summary>
        /// 会员中心查询订单
        /// </summary>
        private void QueryHomeOrder()
        {
            try
            {
                if (userGuid == null)
                {
                    Response.Write("-1");
                    return;
                }
                string state = dic["state"].ToString() == "all" ? "" : dic["state"].ToString();//订单状态
                string beginTime = dic["beginTime"].ToString() == "undefined" ? "" : dic["beginTime"].ToString();
                string endTime = dic["endTime"].ToString() == "undefined" ? "" : dic["endTime"].ToString();
                string strWhere="";
                if (!string.IsNullOrEmpty(beginTime))
                {
                    strWhere += " and addtime>='" + beginTime + "'"; 
                }
                if (!string.IsNullOrEmpty(endTime))
                {
                    strWhere += " and addtime<='" + endTime + "'";
                }
                if (string.IsNullOrEmpty(state) || state == "undefined")
                {
                    state = "";
                }
                int page = dic["page"].ToString().ToInt();
                int pageSize = ConfigParamter.pageSize;
                int start = (page - 1) * pageSize+1;              
                int end = page * ConfigParamter.pageSize;
                OrderMgr orderMgr = new OrderMgr();
                DataTable dtHead = orderMgr.GetHomeOrder(userGuid.Value, state, "", strWhere, start, end);
                StringBuilder data = new StringBuilder();
                if (dtHead!=null && dtHead.Rows.Count>0)
                {   
                    for (int i = 0; i < dtHead.Rows.Count; i++)
                    {
                        string orderNo = dtHead.Rows[i]["guidno"].ToString();
                        string orderTime = dtHead.Rows[i]["addtime"].ToString();

                        /*
                        date differnt
                         **/
                        string DiffDate = dtHead.Rows[i]["DiffDate"].ToString();

                        string orderState = GetOrderState(dtHead.Rows[i]["wnstat"].ToString());
                        string headGuid=dtHead.Rows[i]["guid"].ToString();
                        string wnstat = dtHead.Rows[i]["wnstat"].ToString();
                        DataTable dtBody = orderMgr.GetHomeOrderDetial(headGuid.ToGuid().Value);

                        string strHaveShipmentDetail = "0";
                        string strHaveReturnInfo = "0";
                        string strTestSale="0";
                        for(int kk=0;kk<dtBody.Rows.Count;kk++){
                            int jj=dtBody.Rows[kk]["prdStat"].ToString().ToInt();
                            if(jj==2) strTestSale="1";

                            // this is only for fosdick, should add dropshipper Jack Cao 2015-12-02
                            if (dtBody.Rows[kk]["ShipmentDetail_ID"] != DBNull.Value) strHaveShipmentDetail = "1";
                            if (dtBody.Rows[kk]["ReturnInfo_ID"] != DBNull.Value) strHaveReturnInfo = "1";

                        }
                        //Modify by Long 2015/11/30 应该从orderbody里取价格，而不是从产品表里取，因为价格会随时变动的
                        var sumSalePrice = dtBody.AsEnumerable().Sum(s => s.Field<decimal>("bodymoney"));
                        //var sumSalePrice = dtBody.AsEnumerable().Sum(s => s.Field<decimal>("money"));//实际售价总和
                        var sumEstimateprice = dtBody.AsEnumerable().Sum(s => s.Field<decimal>("money2"));//建议零售价总和
                        //string expressprice = dtHead.Rows[0]["expressprice"].ToString() == "" ? "0" : dtHead.Rows[0]["expressprice"].ToString();//快递费用（该费用为物流公司表配置费用，非实际物流费用）
                        string expressprice = dtHead.Rows[0]["logisticscost"].ToString() == "" ? "0" : dtHead.Rows[0]["logisticscost"].ToString();
                        
                        string orderMoney = Math.Round((sumSalePrice.ToNullString().ToDecimal() + expressprice.ToDecimal()), 2).ToString();//订单实际金额
                        string offMoney = Math.Round((sumEstimateprice.ToNullString().ToDecimal() - sumSalePrice.ToNullString().ToDecimal()),2).ToString();//优惠金额（还需在详细规划业务逻辑） 

                        string orderInfo = JsonConvert.SerializeObject(dtBody);
                        data.Append(",{");
                        data.Append("\"headGuid\":\"" + headGuid + "\",");
                        data.Append("\"date\":\"" + orderTime + "\",");
                        data.Append("\"DiffDate\":\"" + DiffDate + "\",");
                        data.Append("\"HaveTestSale\":\"" + strTestSale + "\",");
                        data.Append("\"HaveShipmentDetail\":\"" + strHaveShipmentDetail + "\",");
                        data.Append("\"HaveReturnInfo\":\"" + strHaveReturnInfo + "\",");
                        
                        data.Append("\"orderNo\":\"" + orderNo + "\",");
                        data.Append("\"wnstat\":\"" + wnstat + "\",");
                        data.Append("\"orderMoney\":\"" + orderMoney + "\",");
                        data.Append("\"expressprice\":\"" + expressprice + "\",");
                        data.Append("\"offMoney\":\"" + offMoney + "\",");
                        data.Append("\"orderState\":\"" + orderState + "\",");
                        data.Append("\"doman\":\"" + System.Configuration.ConfigurationManager.AppSettings["prdImgDomain"] + "\",");
                        data.Append("\"orderInfo\":" + orderInfo);
                        data.Append("}");
                    }
                }
                string resu = data.ToString().Substring(1,data.ToString().Length-1);
                resu = "[" + resu + "]";
                Response.Clear();
                Response.Write(resu);
            }
            catch (Exception)
            {
                Response.Write("");
            }

        }

        /// <summary>
        /// 会员中心查询订单(查询记录数)
        /// </summary>
        private void GetHomeOrderRecordCount()
        {
            try
            {
                string beginTime = dic["beginTime"].ToString();
                string endTime = dic["endTime"].ToString();
                string strWhere = "";
                if (!string.IsNullOrEmpty(beginTime))
                {
                    strWhere += " and addtime>='" + beginTime + "'";
                }
                if (!string.IsNullOrEmpty(endTime))
                {
                    strWhere += " and addtime<='" + endTime + "'";
                }
                string state = dic["state"].ToString() == "all" ? "" : dic["state"].ToString();//订单状态  
                if (string.IsNullOrEmpty(state)||state=="undefined")
                {
                    state = "";
                }
                int recordCount = 0;
                int pageCount = 0;
                OrderMgr orderMgr = new OrderMgr();
                recordCount = orderMgr.GetHomeOrderRecordCount(userGuid.Value, state, "", strWhere);
                pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;

                Response.Clear();
                Response.Write(recordCount + "," + pageCount);
            }
            catch (Exception)
            {
                Response.Write("");
            }

        }

        /// <summary>
        /// 会员中心查询订单详情
        /// </summary>
        private void QueryHomeOrderDetial()
        {
            try
            {
                if (userGuid == null)
                {
                    Response.Write("-1");
                    return;
                }
                StringBuilder data = new StringBuilder();
                OrderMgr orderMgr = new OrderMgr();
                DataTable dtHead = orderMgr.GetOrderHead(dic["headguid"].ToString().ToGuid().Value, "");//订单头信息
                DataTable dtBody = orderMgr.GetHomeOrderDetial(dic["headguid"].ToString().ToGuid().Value);//订单明细

                string addressguid = dtHead.Rows[0]["addressguid"].ToString();//收货地址id
                UserAddressMgr mgr = new UserAddressMgr();
                DataTable dtAddress = mgr.GetList(" u.guid='" + addressguid + "'").Tables[0];
               
                string proName="";
                string cityName="";
                string address="";
                string zip = "";
                if (dtAddress!=null&&dtAddress.Rows.Count>0)
                {
                     proName = dtAddress.Rows[0]["ProName"].ToString();
                     cityName = dtAddress.Rows[0]["city"].ToString();
                     address = dtAddress.Rows[0]["address"].ToString();
                     zip = dtAddress.Rows[0]["zip"].ToString();
                }

                var sumSalePrice = dtBody.AsEnumerable().Sum(s => s.Field <decimal>("money"));//实际售价总和
                var sumEstimateprice = dtBody.AsEnumerable().Sum(s => s.Field<decimal>("money2"));//建议零售价总和
                
                //string orderMoney=sum.ToString()+

                string orderNo = dtHead.Rows[0]["guidno"].ToString();//订单号
                string orderTime = dtHead.Rows[0]["addtime"].ToString();//订单时间
                string expressNo = dtHead.Rows[0]["expressNo"].ToString();//快递单号
                string expressNoCompany = dtHead.Rows[0]["companyname"].ToString();//快递公司
                //string expressprice = dtHead.Rows[0]["expressprice"].ToString() == "" ? "0" : dtHead.Rows[0]["expressprice"].ToString();//快递费用（该费用为物流公司表配置费用，非实际物流费用）
                string expressprice = dtHead.Rows[0]["logisticscost"].ToString() == "" ? "0" : dtHead.Rows[0]["logisticscost"].ToString();
                        
                /*
                 userShopingAmount, useTweebuckAmount, useSharePointAmount
                 */
                string userShopingAmount = dtHead.Rows[0]["userShopingAmount"].ToString();
                string useTweebuckAmount = dtHead.Rows[0]["useTweebuckAmount"].ToString();
                string useSharePointAmount = dtHead.Rows[0]["useSharePointAmount"].ToString();

                string phone = dtHead.Rows[0]["phone"].ToString();//收件人手机
                string tel = dtHead.Rows[0]["tel"].ToString();//收件人电话
                string username = dtHead.Rows[0]["username"].ToString();//收件人姓名
                string prdMoney =  Math.Round(sumSalePrice,2).ToString();//实际商品金额
                string offMoney = Math.Round((sumEstimateprice.ToNullString().ToDecimal() - sumSalePrice.ToNullString().ToDecimal()),2).ToString();//优惠金额（还需在详细规划业务逻辑）               
                string orderMoney = Math.Round((sumSalePrice.ToNullString().ToDecimal() + expressprice.ToDecimal()),2).ToString();//订单实际金额
                string orderState = GetOrderState(dtHead.Rows[0]["wnstat"].ToString());//订单状态      
                //ConfigParamter.OrderType.daifahou.ToString();
                ConfigParamter.OrderStatus.WaitingToShip.ToString();
                string orderInfo = JsonConvert.SerializeObject(dtBody);
                data.Append("[{");
                data.Append("\"orderTime\":\"" + orderTime + "\",");
                data.Append("\"orderNo\":\"" + orderNo + "\",");
                data.Append("\"expressNo\":\"" + expressNo + "\",");
                data.Append("\"proName\":\"" + proName + "\",");
                data.Append("\"cityName\":\"" + cityName + "\",");
                data.Append("\"address\":\"" + address + "\",");
                data.Append("\"zip\":\"" + zip + "\",");
                data.Append("\"expressNoCompany\":\"" + expressNoCompany + "\",");
                data.Append("\"expressprice\":\"" + expressprice + "\",");
                data.Append("\"phone\":\"" + phone + "\",");
                data.Append("\"tel\":\"" + tel + "\",");
                data.Append("\"username\":\"" + username + "\",");
                data.Append("\"prdMoney\":\"" + prdMoney + "\",");
                data.Append("\"offMoney\":\"" + offMoney + "\",");

                data.Append("\"userShopingAmount\":\"" + userShopingAmount + "\",");
                data.Append("\"useTweebuckAmount\":\"" + useTweebuckAmount + "\",");
                data.Append("\"useSharePointAmount\":\"" + useSharePointAmount + "\",");  

                data.Append("\"orderMoney\":\"" + orderMoney + "\",");
                data.Append("\"orderState\":\"" + orderState + "\",");
                data.Append("\"doman\":\"" + System.Configuration.ConfigurationManager.AppSettings["prdImgDomain"] + "\",");
                data.Append("\"orderInfo\":" + orderInfo);
                data.Append("}]");
                Response.Clear();
                Response.Write(data.ToString());
            }
            catch (Exception)
            {
                Response.Write("");
            }

        }


        /// <summary>
        /// member center query order shipment details
        /// </summary>
        private void QueryHomeOrderShipmentDetail()
        {
            try
            {
                if (userGuid == null)
                {
                    Response.Write("-1");
                    return;
                }
                string sOrderNo = dic["orderNo"].ToString();
                OrderMgr orderMgr = new OrderMgr();
                DataTable dtDetail = orderMgr.GetHomeOrderShipmentDetail(sOrderNo);
                string data = JsonConvert.SerializeObject(dtDetail);
 
                Response.Clear();
                Response.Write(data);
            }
            catch (Exception)
            {
                Response.Write("");
            }

        }


        /// <summary>
        /// member center query order shipment details
        /// </summary>
        private void QueryHomeOrderReturnDetail()
        {
            try
            {
                if (userGuid == null)
                {
                    Response.Write("-1");
                    return;
                }
                string sOrderNo = dic["orderNo"].ToString();
                OrderMgr orderMgr = new OrderMgr();
                DataTable dtDetail = orderMgr.GetHomeOrderReturnDetail(sOrderNo);
                string data = JsonConvert.SerializeObject(dtDetail);

                Response.Clear();
                Response.Write(data.ToString());
            }
            catch (Exception)
            {
                Response.Write("");
            }

        }


        
        
        private void DeletOrder()
        {
            string ids = dic["ids"].ToString().TrimEnd(',');
            


        }

        private void UpdateState()
        {
            OrderMgr mgr = new OrderMgr();
            string orderNo = dic["orderNo"].ToString();
            string state=dic["state"].ToString();
            bool b = mgr.UpdateOrderState(orderNo, state.ToInt());
            if (b)
            {
                Response.Write("1");

                //Send out E-mail if use Canceled Order Or Return Good
                string strSubject = orderNo;
                if (state.ToInt() == -1) //User Cancel Order
                {
                    strSubject = " User Request Cancel Order,Order Number is " + strSubject;
                    Mailhelper.SendMail(strSubject, "", "service@tweebaa.com");
                }
                if (state.ToInt() == -2) //User return Goods 
                {
                    strSubject = " User Request Return Goods,Order Number is " + strSubject;
                    Mailhelper.SendMail(strSubject, "", "service@tweebaa.com");
                }
                return;
            }
            Response.Write("0");
        
        
        }


        private void UpdateLogisticsCost()
        {
            OrderMgr mgr = new OrderMgr();
            string orderNo = dic["orderNo"].ToString();
            decimal dLogisticsCost  = Decimal.Parse(dic["logisticscost"].ToString());
            bool b = mgr.UpdateOrderLogisticsCost(orderNo, dLogisticsCost);
            if (b)
            {
                Response.Write("1");
                return;
            }
            Response.Write("0");


        }

        
        
        /// <summary>
        /// 匹配订单状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private string GetOrderState(string state)
        {
            switch (state)
            {
                case "0":
                    return "Unpaid";
                case "1":
                    return "Waiting To Ship";
                case "2":
                    return "Shipped";
                case "3":
                    return "Partially shipped";
                case "-1":
                    return "Cancelled";
                case "-2":
                    return "Wait For Return";
                case "-3":
                    return "Return Processing";
                case "-4":
                    return "Wait For Return Money";
                case "-5":
                    return "Return Completed"; 
                default:
                    return state;                  
            }
        
        }       
    }
}