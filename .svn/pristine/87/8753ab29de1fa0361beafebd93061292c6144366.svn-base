using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Data;
using Twee.DataMgr;
using log4net;
using Twee.Model;

public struct TransactionItemInfo
{
    public string id;
    public string name;
    public string sku;
    public string price;
    public string qty;
    // Fields, properties, methods and events go here...
}

public struct TransactionInfo
{
    public string ID;
    public string Source;
    public float Revenue;
    public float Shipping;
    public float Tax;
    public List<TransactionItemInfo> items;
    // Fields, properties, methods and events go here...
}

namespace Twee.Mgr
{
    public class OrderMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        OrderDataMgr mgr = new OrderDataMgr();
        #region 后台方法
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>     
        public DataTable MgeGetList(string strWhere)
        {
            try
            {
                return mgr.MgeGetList(strWhere);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("",ex);
            }
          
        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="txtData1"></param>
        /// <param name="txtData2"></param>
        /// <param name="orderCode"></param>
        /// <param name="txtUser"></param>
        /// <param name="txtRecive"></param>
        /// <param name="orderby"></param>
        /// <param name="state"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable MgeGetListAll(string prdName, string txtData1, string txtData2, string orderCode, string txtUser, string txtRecive, string orderby, string state, int startIndex, int endIndex)
        {
            try
            {
                 return mgr.MgeGetListAll(prdName,txtData1, txtData2, orderCode, txtUser, txtRecive, orderby, state, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
          

        }
        /// <summary>
        /// 获取订单记录总数
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="txtData1"></param>
        /// <param name="txtData2"></param>
        /// <param name="orderCode"></param>
        /// <param name="txtUser"></param>
        /// <param name="txtRecive"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int MgeGetRecordCount(string prdName, string txtData1, string txtData2, string orderCode, string txtUser, string txtRecive, string state)
        {
            try
            {
                return mgr.MgeGetRecordCount(prdName,txtData1, txtData2, orderCode, txtUser, txtRecive, state);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
           
        }


           /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>       
        private DataTable MgeGetOrderInfo(Guid orderGuid)
        {
            //return mgr.GetOrderInfo(orderGuid);
            return null;
        }

          /// <summary>
        /// 获取订单产品详情列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>       
        public DataTable MgeGetOrderProInfo(Guid orderGuid)
        {
            try
            {
                return mgr.MgeGetOrderProInfo(orderGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
           
        }

          /// <summary>
        /// 获取收货人详细信息
        /// </summary>
        /// <param name="orderGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetOrderPeopleInfo(Guid orderGuid)
        {
            try
            {
                return mgr.MgeGetOrderPeopleInfo(orderGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
            
        }

          /// <summary>
        /// 订单综合信息
        /// </summary>
        /// <param name="orderGuid"></param>
        /// <returns></returns>
        public Dictionary<string, string> MgeGetAllInfo(Guid orderGuid)
        {
            try
            {
                return mgr.MgeGetAllInfo(orderGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
           
        }

          /// <summary>
        /// 1改价/2支付/3发货/4完成/5作废
        /// </summary>
        /// <param name="dicUpdate">所有操作的参数集合</param>
        /// <param name="upAction">行为</param>
        /// <param name="orderGuid">订单ID</param>
        /// <returns></returns>
        public bool MgeUpDateInfo(Dictionary<string, string> dicUpdate, int upAction, Guid orderGuid)
        {
            try
            {
                return mgr.MgeUpDateInfo(dicUpdate, upAction, orderGuid);
            }         
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
            
        }

           /// <summary>
        /// 获取销售记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="state">2：预售区；3：销售区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <returns></returns>
        public DataTable MgeGetAllSale(string strWhere1, string strWhere2, string orderby, string state, int startIndex, int endIndex)
        {
            try
            {
                return mgr.MgeGetAllSale(strWhere1, strWhere2, orderby, state, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }
           
        }

           /// <summary>
        /// 获取订单所有产品图片
        /// </summary>
        /// <param name="headGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetOrderImg(string headGuid)
        {
            try
            {
                return mgr.MgeGetOrderImg(headGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw new Exception("", ex);
            }

        }

        public int MgeGetWarehouseShipOrderID(string sGuidNo)
        {
            return mgr.MgeGetWarehouseShipOrderID(sGuidNo);
        }

        #endregion

        #region  前台方法
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderHead"></param>
        /// <param name="listBody"></param>
        /// <returns></returns>
        public bool AddOrder(Orderhead orderHead, List<OrderBody> listBody)
        {
            return mgr.AddOrder(orderHead, listBody);
        }

        //Add by Long 2016/01/20 for Events claim free products
        public DataTable GetFreeProductInfoBySerialNo(string strSerialNo)
        {
            return mgr.GetFreeProductInfoBySerialNo(strSerialNo);
        }
        public void UpdateFreeProductClaimOrderNo(string strID, string strOrderNo)
        {
            mgr.UpdateFreeProductClaimOrderNo(strID, strOrderNo);
        }
        public void UpdateFreeProductIsClaim(string strOrderNo)
        {
            mgr.UpdateFreeProductIsClaim(strOrderNo);
        }
        public DataTable GetFreeProductGuidForEvents(string strUserGuid)
        {
            return mgr.GetFreeProductGuidForEvents(strUserGuid);
        }
        /*
         * 为了兼容老版本
         */
        public bool AddOrder2(Orderhead orderHead, List<OrderBody> listBody)
        {
            return mgr.AddOrder2(orderHead, listBody);
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="userGuid">用户id</param>
        /// <returns></returns>
        public DataTable GetOrder(Guid userGuid)
        {
            return mgr.GetOrder(userGuid);
        }
        /// <summary>
        /// 根据订单号查询订单信息
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public DataTable GetOrderByOrserNo(string orderNo)
        {
            return mgr.GetOrderByOrserNo(orderNo);
        }

        public int GetOrderState(string guidno)
        {
            return mgr.GetOrderState(guidno);
        }

        public string GetOrderEmail(string guidno)
        {
            return mgr.GetOrderEmail(guidno);
        }

        public string CreateOrderConfirmationEmailBody(string guidNo)
        {
            string strSQL="select * from wn_orderhead where guidno='"+guidNo+"'";
            string strRet = "";
            DataSet dsOrderHead = Twee.Comm.DbHelperSQL.Query(strSQL);
            float fDiscount = 0.0f;
            if (dsOrderHead != null && dsOrderHead.Tables.Count > 0 && dsOrderHead.Tables[0].Rows.Count > 0)
            {
                if(!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["userShopingAmount"].ToString())){
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["userShopingAmount"].ToString());
                }
                if(!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["useTweebuckAmount"].ToString())){
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["useTweebuckAmount"].ToString());
                }
                if(!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["useSharePointAmount"].ToString())){
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["useSharePointAmount"].ToString());
                }
                if(!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["useCouponAmount"].ToString())){
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["useCouponAmount"].ToString());
                }
               
                strSQL = "SELECT  a.*, b.name FROM   wn_orderBody AS a INNER JOIN wn_prd AS b ON a.prdGuid = b.prdGuid WHERE   (a.headGuid = '" + dsOrderHead.Tables[0].Rows[0]["guid"].ToString() + "')";
                DataSet dsOrderBody = Twee.Comm.DbHelperSQL.Query(strSQL);
                if (dsOrderBody != null && dsOrderBody.Tables.Count > 0 && dsOrderBody.Tables[0].Rows.Count > 0)
                {
                    float fTotal=0.0f;
                    for(int i=0;i< dsOrderBody.Tables[0].Rows.Count; i++){
                      strRet=strRet+"<tr><td style=\"border-top: #eee 1px solid; padding:30px 10px ;\">"+dsOrderBody.Tables[0].Rows[i]["name"].ToString() +"</td>";
                      strRet = strRet + "<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">" + Convert.ToInt32(float.Parse(dsOrderBody.Tables[0].Rows[i]["quantity"].ToString())) + "</td>";
                      strRet = strRet + "<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">$" + float.Parse(dsOrderBody.Tables[0].Rows[i]["buydanJia"].ToString()).ToString("0.00") +"</td>";
                      strRet=strRet+"<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">"+ float.Parse( dsOrderBody.Tables[0].Rows[i]["logisticscost"].ToString()).ToString("0.00")+"</td>";
                      float fUnit=float.Parse(dsOrderBody.Tables[0].Rows[i]["buydanJia"].ToString());
                      float fShipping = float.Parse(dsOrderBody.Tables[0].Rows[i]["logisticscost"].ToString());
                      float fSubTotal = fUnit + fShipping;
                        fTotal = fTotal + fSubTotal;
                      strRet=strRet+"<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">"+fSubTotal.ToString()+"</td></tr>";
                    
                    }

                    if(fDiscount >0){
                        fTotal = fTotal - fDiscount;
                        strRet=strRet+"<tr style=\" font-weight:bold; font-size:18px;\">";
                        strRet = strRet + "<td  style=\"text-align:right; padding:8px 60px;\" colspan=\"4\">Total Discount:</td>";
                        strRet=strRet+"<td class=\"alignright\" style=\"color:#C10003\">$"+fDiscount.ToString()+"</td>";
                        strRet=strRet+"</tr>";
                    }
                    strRet=strRet+"<tr style=\" font-weight:bold; font-size:18px;\">";
                    strRet = strRet + "<td  style=\"text-align:right; padding:8px 60px;\" colspan=\"4\">Total:</td>";
                    strRet=strRet+"<td class=\"alignright\" style=\"color:#C10003\">$"+fTotal.ToString()+"</td>";
                    strRet=strRet+"</tr>";
                    /*
                                                           
                                                          <tr style=" font-weight:bold; font-size:14px;">
                                                            <td  style="text-align:right; padding:8px 60px;" colspan="4">Estimated shipping:</td>
                                                            <td class="alignright">$36.00</td>
                                                        </tr>    */
                }
                
            }
            return strRet;
        }

        //added by Lance
        public TransactionInfo GetTransactionInfo4GA(string guidNo)
        {
            TransactionInfo transactioninfo = new TransactionInfo();

            string strSQL = "select * from wn_orderhead where guidno='" + guidNo + "'";
            string strRet = "";
            DataSet dsOrderHead = Twee.Comm.DbHelperSQL.Query(strSQL);
            float fDiscount = 0.0f;
            if (dsOrderHead != null && dsOrderHead.Tables.Count > 0 && dsOrderHead.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["userShopingAmount"].ToString()))
                {
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["userShopingAmount"].ToString());
                }
                if (!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["useTweebuckAmount"].ToString()))
                {
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["useTweebuckAmount"].ToString());
                }
                if (!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["useSharePointAmount"].ToString()))
                {
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["useSharePointAmount"].ToString());
                }
                if (!string.IsNullOrEmpty(dsOrderHead.Tables[0].Rows[0]["useCouponAmount"].ToString()))
                {
                    fDiscount = fDiscount + float.Parse(dsOrderHead.Tables[0].Rows[0]["useCouponAmount"].ToString());
                }

                strSQL = "SELECT  a.*, b.name FROM   wn_orderBody AS a INNER JOIN wn_prd AS b ON a.prdGuid = b.prdGuid WHERE   (a.headGuid = '" + dsOrderHead.Tables[0].Rows[0]["guid"].ToString() + "')";
                DataSet dsOrderBody = Twee.Comm.DbHelperSQL.Query(strSQL);
                if (dsOrderBody != null && dsOrderBody.Tables.Count > 0 && dsOrderBody.Tables[0].Rows.Count > 0)
                {
                    int itemnum = dsOrderBody.Tables[0].Rows.Count;


                    transactioninfo.items = new List<TransactionItemInfo>();

                    float fTotal = 0.0f;
                    for (int i = 0; i < dsOrderBody.Tables[0].Rows.Count; i++)
                    {
                        strRet = strRet + "<tr><td style=\"border-top: #eee 1px solid; padding:30px 10px ;\">" + dsOrderBody.Tables[0].Rows[i]["name"].ToString() + "</td>";
                        strRet = strRet + "<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">" + Convert.ToInt32(float.Parse(dsOrderBody.Tables[0].Rows[i]["quantity"].ToString())) + "</td>";
                        strRet = strRet + "<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">$" + float.Parse(dsOrderBody.Tables[0].Rows[i]["buydanJia"].ToString()).ToString("0.00") + "</td>";
                        strRet = strRet + "<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">" + float.Parse(dsOrderBody.Tables[0].Rows[i]["logisticscost"].ToString()).ToString("0.00") + "</td>";
                        float fUnit = float.Parse(dsOrderBody.Tables[0].Rows[i]["buydanJia"].ToString());
                        float fShipping = float.Parse(dsOrderBody.Tables[0].Rows[i]["logisticscost"].ToString());
                        float fSubTotal = fUnit + fShipping;
                        fTotal = fTotal + fSubTotal;
                        strRet = strRet + "<td style=\"border-top: #eee 1px solid; text-align:left; padding:10px;\">" + fSubTotal.ToString() + "</td></tr>";
                        
                        //Item Data info
                        TransactionItemInfo itemdata = new TransactionItemInfo();                        
                        itemdata.name = dsOrderBody.Tables[0].Rows[i]["name"].ToString();
                        itemdata.price = float.Parse(dsOrderBody.Tables[0].Rows[i]["buydanJia"].ToString()).ToString("0.00");
                        itemdata.qty = Convert.ToInt32(float.Parse(dsOrderBody.Tables[0].Rows[i]["quantity"].ToString())).ToString();
                        itemdata.sku = dsOrderBody.Tables[0].Rows[i]["prdGuid"].ToString();
                        transactioninfo.items.Add(itemdata);
                        
                    }

                    if (fDiscount > 0)
                    {
                        fTotal = fTotal - fDiscount;
                        strRet = strRet + "<tr style=\" font-weight:bold; font-size:18px;\">";
                        strRet = strRet + "<td  style=\"text-align:right; padding:8px 60px;\" colspan=\"4\">Total Discount:</td>";
                        strRet = strRet + "<td class=\"alignright\" style=\"color:#C10003\">$" + fDiscount.ToString() + "</td>";
                        strRet = strRet + "</tr>";
                    }
                    strRet = strRet + "<tr style=\" font-weight:bold; font-size:18px;\">";
                    strRet = strRet + "<td  style=\"text-align:right; padding:8px 60px;\" colspan=\"4\">Total:</td>";
                    strRet = strRet + "<td class=\"alignright\" style=\"color:#C10003\">$" + fTotal.ToString() + "</td>";
                    strRet = strRet + "</tr>";
                    /*
                                                           
                                                          <tr style=" font-weight:bold; font-size:14px;">
                                                            <td  style="text-align:right; padding:8px 60px;" colspan="4">Estimated shipping:</td>
                                                            <td class="alignright">$36.00</td>
                                                        </tr>    */
                    transactioninfo.ID = guidNo;
                    transactioninfo.Revenue = fTotal;

                }

            }


            return transactioninfo;
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="guidno">订单号</param>
        /// <param name="state">订单状态</param>
        /// <returns></returns>
        public bool UpdateOrderState(string guidno, int state)
        {
            bool b = mgr.UpdateOrderState(guidno, state);            
            if (b)
            {              
                UserGradeCalMgr grade=new UserGradeCalMgr();
                //Modify by Long 2015/11/4,只有state为1的情况下才更新 Shopping Point,否则，
                //其他状态也更新了，这样Shopping Point
                bool resu = false;
                if (state == 1)
                {
                    resu = grade.UpdateShopingPoint(guidno);
                }
                else
                {
                    resu = true;
                }
                string email = mgr.GetOrderEmail(guidno);
                if (!string.IsNullOrEmpty(email))
                {
                    Twee.Comm.Mailhelper.SendMail("Order:" + guidno, "Your order has been paid, waiting for delivery", email);
                }                
                return resu;
            }
            return b;
        }

        /// <summary>
        /// update logicticcost of order header
        /// </summary>
        /// <param name="guidno">订单号</param>
        /// <param name="dLogisticsCost">shipping fee</param>
        /// <returns></returns>
        public bool UpdateOrderLogisticsCost(string guidno, decimal dLogisticsCost)
        {
            return mgr.UpdateOrderLogisticsCost(guidno, dLogisticsCost);
        }
     

        /// <summary>
        /// table转换位list
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Twee.Model.Order> DataTableToList(DataTable dt)
        {
            List<Twee.Model.Order> modelList = new List<Twee.Model.Order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        #endregion

        #region 会员中心方法
        /// <summary>
        /// 查询待发货，已发货，已完成的个数，根据userid
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="ordertype">状态编号</param>
        /// <returns></returns>
        public string GetInfo(string userid, string ordertype) {
            return mgr.GetInfo(userid,ordertype);
        }

        /// <summary>
        /// 会员中心查询订单(根据会员id,查询所属订单号)
        /// </summary>
        /// <param name="userGuid">用户id</param>
        /// <returns></returns>
        public DataTable GetHomeOrder(Guid userGuid, string wnstat, string orderby, string strWhere, int startIndex, int endIndex)
       {
           return mgr.GetHomeOrder(userGuid, wnstat, orderby, strWhere, startIndex, endIndex);
        }

        /// <summary>
        /// 会员中心查询订单,记录数(根据会员id,查询所属订单号)
        /// </summary>
        /// <param name="userGuid">用户id</param>
        /// <param name="wnstat">订单状态</param>
        /// <returns></returns>
        public int GetHomeOrderRecordCount(Guid userGuid, string wnstat, string orderby, string strWhere)
        {
            return mgr.GetHomeOrderRecordCount(userGuid, wnstat, orderby, strWhere);

        }

        /// <summary>
        /// 会员中心查询订单(根据订单号，查询订单明细)
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public DataTable GetHomeOrderDetial(Guid headGuid)
        {
            return mgr.GetHomeOrderDetial(headGuid);
        }

        /// <summary>
        /// member center query order shipment details
        /// </summary>
        /// <param name="order no"></param>
        /// <returns></returns>
        public DataTable GetHomeOrderShipmentDetail(string sOrderNo)
        {
            return mgr.GetHomeOrderShipmentDetail(sOrderNo);
        }

        /// <summary>
        /// member center query order return details
        /// </summary>
        /// <param name="order no"></param>
        /// <returns></returns>
        public DataTable GetHomeOrderReturnDetail(string sOrderNo)
        {
            return mgr.GetHomeOrderReturnDetail(sOrderNo);
        }

        /// <summary>
        ///  查询订单信息（包括:订单时间、订单号、收货人电话、收货人姓名、物流公司、物流费；订单id和订单号输入其中一个即可）
        /// </summary>
        /// <param name="headGuid"></param>
        /// <returns></returns>
        public DataTable GetOrderHead(Guid headGuid, string orderNum)
        {
            return mgr.GetOrderHead(headGuid, orderNum);
        }

        /// <summary>
        /// 查询订单明细(用于收益计算：根据订单号OrderNo，查询订单明细)
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public DataTable GetOrderDetial(string orderNo)
        {
            return mgr.GetOrderDetial(orderNo);
        }
        public string GetGuestCheckoutUsernameByOrderno(string strOrderno)
        {
            return mgr.GetGuestCheckoutUsernameByOrderno(strOrderno);
        }
        /// <summary>
        /// 查询会员所有消费总额
        /// </summary>
        /// <param name="userGuid">会员id</param>
        /// <param name="orderState">订单状态</param>
        /// <returns></returns>
        public decimal GetSumShopMoney(string userGuid, Twee.Comm.ConfigParamter.OrderStatus orderState)
        {
            return mgr.GetSumShopMoney(userGuid, orderState); 

        }
        public decimal GetBonusShoppingPoint(string userGuid, Twee.Comm.ConfigParamter.OrderStatus orderState)
        {
            return mgr.GetBonusShoppingPoint(userGuid, orderState);
        }
        /// <summary>
        /// 查询用户用掉的消费积分
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>

        public decimal GetSumUsedShoppingPointsMoney(string userGuid)
        {
            return mgr.GetSumUsedShoppingPointsMoney(userGuid);
        }

        /// <summary>
        /// 查询插入购物积分所需的字段信息
        /// </summary>
        /// <param name="headGuid"></param>
        /// <returns></returns>
        public DataTable GetPointInfoByHeadGuid(string headGuid)
        {
            return mgr.GetPointInfoByHeadGuid(headGuid);
        }
        #endregion
    }
}
