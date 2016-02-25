using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
namespace Twee.Comm
{
    /// <summary>
    /// 仓库接口
    /// </summary>
    public class WarehouseInterface
    {
        private string AppKey = System.Configuration.ConfigurationManager.AppSettings["AppKey"].ToString();
        private string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"].ToString();
        private string OwnerId = System.Configuration.ConfigurationManager.AppSettings["OwnerId"].ToString();
        private string StockId = System.Configuration.ConfigurationManager.AppSettings["StockId"].ToString();
        private string ShopId = System.Configuration.ConfigurationManager.AppSettings["ShopId"].ToString();
        private string WarehouseUser = System.Configuration.ConfigurationManager.AppSettings["WarehouseUser"].ToString();
        private string WarehousePwd = System.Configuration.ConfigurationManager.AppSettings["WarehousePwd"].ToString();
       
        private EBodyType m_bodyType = EBodyType.EType_JSON;

        #region 商品
        /// <summary>
        /// 1.导入商品
        /// </summary>
        /// <param name="dicProducts"></param>
        /// <param name="dicSkus"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string ProductSend(Dictionary<string, string> dicProducts, Dictionary<string, string> dicSkus, int count)
        {
            string dataProducts = JsonConvert.SerializeObject(dicProducts);
            string dataSkus = JsonConvert.SerializeObject(dicSkus);
            try
            {                  
                StringBuilder data = new StringBuilder();
                data.Append("{");
                data.Append("\"count\":\"").Append(count).Append("\"");
                data.Append(",\"products\":[").Append(dataProducts.Replace("}", ","));
                data.Append("\"skus\":[").Append(dataSkus);
                data.Append("]}");
                data.Append("]}");
                string resu = HttpPost("pushProducts", data.ToString());
                return resu;
            }
            catch (Exception)
            {                
                throw;
            }

        }

        /// <summary>
        /// 1.导入商品
        /// </summary>
        /// <param name="dicProducts"></param>
        /// <param name="dicSkus"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string ProductSend(string prdData)
        {           
            try
            {
                string resu = HttpPost("pushProducts", prdData);
                return resu;
            }
            catch (Exception)
            {
                throw;
            }
        }

         /// <summary>
        /// 2.采购单导入
        /// </summary>
        public string PushPurchase(Dictionary<string, string> dicPurchase, Dictionary<string, string> dicSkus)
        {
            string dataProducts = JsonConvert.SerializeObject(dicPurchase);
            string dataSkus = JsonConvert.SerializeObject(dicSkus);
            try
            {
                StringBuilder data = new StringBuilder();               
                data.Append(dataProducts.Replace("}", ","));
                data.Append("\"skus\":[").Append(dataSkus);
                data.Append("]}");              
                string resu = HttpPost("pushPurchase", data.ToString());
                return resu;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 3.采购单入库数据查询  
        /// </summary>
        public string PurchaseInStockQuery(Dictionary<string, string> dicPurchase)
        {  
            try
            {
                string dataPurchase = JsonConvert.SerializeObject(dicPurchase);
                string resu = HttpPost("purchaseInStockQuery", dataPurchase);
                return resu;
            }
            catch (Exception)
            {
                throw;
            }
        }       
        
        #endregion


        #region 订单
        /// <summary>
        /// 发送订单
        /// </summary>       
        public string SendOrder(Dictionary<string, string> dicTrades, Dictionary<string, string> dicSkus, string product_code, string order_no, string count)
        {

            #region
            //Dictionary<string,string> dicTrades;
            //dicTrades.Add("count", count);
            //dicTrades.Add("order_no", order_no); 
            //dicTrades.Add("stock_id", stock_id);
            //dicTrades.Add("transporter_id", transporter_id);
            //dicTrades.Add("shop_id", shop_id); 
            //dicTrades.Add("order_create_time", order_create_time);
            //dicTrades.Add("order_pay_time", order_pay_time);
            //dicTrades.Add("buyer_nick", buyer_nick); 
            //dicTrades.Add("receiver_country", receiver_country);
            //dicTrades.Add("receiver_province", receiver_province);
            //dicTrades.Add("receiver_city", receiver_city);
            //dicTrades.Add("receiver_county", receiver_county);
            //dicTrades.Add("receiver_address", receiver_address);
            //dicTrades.Add("receiver_zip", receiver_zip); 
            //dicTrades.Add("receiver_name", receiver_name);
            //dicTrades.Add("receiver_mobile", receiver_mobile);
            //dicTrades.Add("receiver_phone", receiver_phone);
            //dicTrades.Add("request_ship_date", request_ship_date); 
            //dicTrades.Add("need_invoice", need_invoice); 
            //dicTrades.Add("invoice_name", invoice_name); 
            //dicTrades.Add("invoice_content", invoice_content); 
            //dicTrades.Add("payment", payment); 
            //dicTrades.Add("total_fee", total_fee);
            //dicTrades.Add("discount_fee", discount_fee); 
            //dicTrades.Add("post_fee", post_fee);
            //dicTrades.Add("need_card", need_card); 
            //dicTrades.Add("card_content", card_content);
            //dicTrades.Add("create_date", create_date);
            //dicTrades.Add("goodlist_file_url", goodlist_file_url);
            //dicTrades.Add("pack_file_url", pack_file_url);
            //dicTrades.Add("out_sid", out_sid);

            //Dictionary<string, string> dicSkus;
            //dicSkus.Add("product_code", product_code);
            //dicSkus.Add("qty", qty);
            //dicSkus.Add("payment", payment);
            //dicSkus.Add("discount_fee", discount_fee);
            //dicSkus.Add("shop_id", shop_id);
            //dicSkus.Add("owner_id", owner_id);
            //dicSkus.Add("sell_price", sell_price);

            //string product_code;
            //string order_no;

            #endregion
            string dataTrades = JsonConvert.SerializeObject(dicTrades);
            string dataSkus = JsonConvert.SerializeObject(dicSkus);

            try
            {            
                // 构建Body
                StringBuilder data = new StringBuilder();

                data.Append("{");
                data.Append("\"count\":\"").Append(count).Append("\"");
                data.Append(",\"trades\":[").Append(dataTrades.Replace("}", ","));
                data.Append("\"skus\":[").Append(dataSkus);
                //data.Append(",{\"product_code\":\"").Append(product_code).Append("\"");
                data.Append("]}");
                data.Append("]}");
                // {"count":"2","trades":[{"skus:[{},{'product_code':''}]"},{"order_no":""}]};                  
             
               string resu = HttpPost("pushTrades", data.ToString());
               
                
               return resu;
               
               
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="dicOrderCancel"></param>
        /// <returns></returns>
        public string OrderCancel(Dictionary<string, string> dicOrderCancel)
        { 
            
            string data = JsonConvert.SerializeObject(dicOrderCancel);
            string resuStr = HttpPost("cancelTrade", data);
            var resuData = JsonConvert.DeserializeObject(resuStr);            

            //返回Json格式：
            //{
            //  “flag”: “”,
            //  “reason”: “”
            //}
            return resuData.ToString();
        }
        /// <summary>
        /// 查询订单状态
        /// </summary>
        public void OrderStateQuery(Dictionary<string, string> dicOrders)
        {
            string data = JsonConvert.SerializeObject(dicOrders);
            string resuStr = HttpPost("tradeStatusQuery", data);
            var resuData = JsonConvert.DeserializeObject(resuStr);            

            //返回json
            //Json格式：
            //{
            //  “total_count”: “”,
            //  “page_no”: “”,
            //  “page_size”: “”,
            //  “page_num”: “”,
            //  “trades”: [
            //{
            //      “order_no”: “”,
            //      “status”: “”,
            //“transporter_id”: “”,
            //         “out_ids”: “”

            //  },
            //{
            //      “order_no”: “”,
            //      “status”: “”
            //  }
            // ]
            //}

        
        }

        /// <summary>
        /// 查询订单发货情况
        /// </summary>
        public void OrderDeliverQuery(Dictionary<string, string> dicDeliverQuery)
        {
            string data = JsonConvert.SerializeObject(dicDeliverQuery);
            string resuStr = HttpPost("tradeDeliverQuery", data);
            var resuData = JsonConvert.DeserializeObject(resuStr);    
        
            //返回Json：
            //{
            //  “total_count”: “”,
            //  “page_no”: “”,
            //  “page_size”: “”,
            //  “page_num”: “”,
            //  “trades”:[
            // {
            //      “order_no”: “”,
            //      “transporter_id”: “”,
            //      “out_ids”: “”,
            //      “weight”: “”,
            //      “ship_date”:””,
            //      “flag”:”1”
            //},
            //{}
            //  ]
            //}

        }

        #endregion

        #region 库存

        /// <summary>
        /// 库存查询
        /// </summary>
        /// <param name="dicInventoryQuery"></param>
        /// <returns></returns>
        public string InventoryQuery(Dictionary<string, string> dicInventoryQuery)
        {
            string data = JsonConvert.SerializeObject(dicInventoryQuery);
            string resuStr = HttpPost("inventoryQuery", data);
            var resuData = JsonConvert.DeserializeObject(resuStr);
            return resuData.ToString();
        }

        #endregion

        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="method">请求方法</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private string HttpPost(string method,string data)
        {
            try
            {
                //调用实例：http://ecmapi.iscs.com.cn/openapi/do?v_appkey=100001&v_appsign=5029C3055D51555112B60B33000122D5&v_format=xml&v_ timestamp=2012-10-31 17:45:40&v_method=pushProducts
                string v_timestamp=DateTime.Now.ToString().Replace("/","-");
                string sign = AppKey + AppSecret + v_timestamp;
                //sign = CommHelper.GetStrEncode(sign);
                string v_appsign = CommHelper.To32Md52(sign);              
                string uriStr = string.Format("http://testapi.iscs.com.cn/openapi/do?v_appkey={0}&v_appsign={1}&v_format=json&v_timestamp={2}&v_method={3}&v_data={4}", AppKey, v_appsign, v_timestamp, method, data);

                Uri address = new Uri(uriStr);
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                request.Method = "POST";
                Encoding myEncoding = Encoding.GetEncoding("utf-8");
                // 构建Body
          
                request.Accept = "application/json";                
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                //request.ContentType = "application/json;charset=utf-8";               
             
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(data);
                // 开始请求
                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);               
                }
                // 获取请求
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseStr = reader.ReadToEnd();
                    if (responseStr != null && responseStr.Length > 0)
                    {
                        response.Close();
                        return responseStr;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        
        
        }


      


    }
}
