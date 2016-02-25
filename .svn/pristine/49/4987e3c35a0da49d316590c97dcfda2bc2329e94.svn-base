using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp
{
     
    public partial class sale : System.Web.UI.Page
    {
        private string AppKey = System.Configuration.ConfigurationManager.AppSettings["AppKey"].ToString();
        private string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"].ToString();
        private string OwnerId = System.Configuration.ConfigurationManager.AppSettings["OwnerId"].ToString();
        private string StockId = System.Configuration.ConfigurationManager.AppSettings["StockId"].ToString();
        private string ShopId = System.Configuration.ConfigurationManager.AppSettings["ShopId"].ToString();
        private string WarehouseUser = System.Configuration.ConfigurationManager.AppSettings["WarehouseUser"].ToString();
        private string WarehousePwd = System.Configuration.ConfigurationManager.AppSettings["WarehousePwd"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductSend();//入库
          // PushPurchase();
           // PurchaseInStockQuery();
            //InventoryQuery();
           // SendOrder();
            //OrderDeliverQuery();
            //OrderCancel();
           OrderStateQuery();
          
        }

        #region 产品

        /// <summary>
        /// 1.产品导入
        /// </summary>
        /// <returns></returns>
        public void ProductSend()
        {
            //{"reqLogGuid":"DFC9525A9ABF42C6A18F8F546E89FA09","errorText":"code:180,message:货主ID,商品编号,商品简称,商品标题 不能有空！owner_id:260136,product_id:,product_name:,product_title:","data":"","errorCode":"190"}

            //{"reqLogGuid":"EB6CE64231A84932A6884F8FBD4F5A5D","errorText":"code:180,message:规格编号,规格名称,商品条码,易燃性,易爆性,是否液体 不能有空！sku_id:,sku_name:,product_code:","data":"","errorCode":"190"}

            Dictionary<string, string> dicProducts = new Dictionary<string, string>();
            Dictionary<string, string> dicSkus = new Dictionary<string, string>();
            int count = 1;
            dicProducts.Add("owner_id", OwnerId);//Y货主ID
            dicProducts.Add("product_id", "prd001112522");//Y商品编号
            dicProducts.Add("product_name", "产品1");//Y商品简称
            dicProducts.Add("product_title", "产品1");// Y商品标题
            dicProducts.Add("category", "");// 商品类目(调类目接口获取)
            dicProducts.Add("remark", "");// 备注
            dicSkus.Add("sku_id", "01");// Y规格编号
            dicSkus.Add("sku_name", "尺寸");// Y规格名称
            dicSkus.Add("sku_img_url", "");// 规格图片
            dicSkus.Add("length", "");// 长
            dicSkus.Add("width", "");// 宽
            dicSkus.Add("height", "");// 高
            dicSkus.Add("product_code", "20140201ydf123");// Y商品条码
            dicSkus.Add("Product_Stock_Type", "");// 商品库存类型:s库存商品、V虚拟商品、F辅料、P外包材、N内包材、H耗材
            dicSkus.Add("is_kit", "");// 是否套件（暂不支持）
            dicSkus.Add("category", "");// 商品类目(详见附表一)
            dicSkus.Add("flammable", "0");//Y 易燃性（0否1是）
            dicSkus.Add("explosive", "0");//Y 爆性（0否1是
            dicSkus.Add("liquid", "0");//Y 是否液体（0否1是
            dicSkus.Add("unit_weight", "");// 重量
            dicSkus.Add("unit_sell_price", "");// 售价
            dicSkus.Add("unit_discount_price", "");// 折扣价
            dicSkus.Add("unit_cost", "");// 单位成本
            dicSkus.Add("unit_purchase_cost", "");// 进货价格
            dicSkus.Add("has_barcode", "1");// 1 实物有条码  0  没有条码
            WarehouseInterface warehouse = new WarehouseInterface();
            warehouse.ProductSend(dicProducts, dicSkus, count);


        }

        /// <summary>
        /// 2.采购单导入
        /// </summary>
        public void PushPurchase()
        {   
            Dictionary<string, string> dicPurchase = new Dictionary<string, string>();
            Dictionary<string, string> dicSkus = new Dictionary<string, string>();
            dicPurchase.Add("stock_id", StockId);//Y网仓仓库Id
            dicPurchase.Add("owner_id", OwnerId);//Y货主ID
            dicPurchase.Add("purchase_no", "20140125");//Y采购单号
            dicPurchase.Add("transporter_id", "230096");//运输商
            dicPurchase.Add("out_sid", "201501241554");// 运单号
            dicPurchase.Add("supplier_id", "");// 供应商ID
            dicPurchase.Add("create_date", DateTime.Now.ToString().Replace("/","-"));// Y建立日期
            dicPurchase.Add("plan_ship_date", DateTime.Now.ToString().Replace("/", "-"));// Y计划发货日期
            dicPurchase.Add("plan_arrival_date", DateTime.Now.ToString().Replace("/", "-"));// Y计划到货日期
            dicPurchase.Add("remark", "尺寸");// 备注
            dicPurchase.Add("audit_date", DateTime.Now.ToString().Replace("/", "-"));// Y审核日期
            dicSkus.Add("product_code", "20150124000001");// Y商品条码
            dicSkus.Add("qty", "100");// Y数量
            dicSkus.Add("unit_purchase_cost", "80");//单位价格     
            WarehouseInterface warehouse = new WarehouseInterface();
            warehouse.PushPurchase(dicPurchase, dicSkus);
        }

        /// <summary>
        /// 采购单入库数据查询  
        /// </summary>
        public void PurchaseInStockQuery()
        {   
            Dictionary<string, string> dicPurchase = new Dictionary<string, string>();          
        
            dicPurchase.Add("stock_id", StockId);//Y
            dicPurchase.Add("owner_id", OwnerId);// Y货主ID
            dicPurchase.Add("purchase_no", "20140125");//Y采购单号          
            dicPurchase.Add("bill_type", "1");//1.外部单号 2.网仓单号
            WarehouseInterface warehouse = new WarehouseInterface();
            warehouse.PurchaseInStockQuery(dicPurchase);
        
        }       
        


        #endregion


        #region 库存


        /// <summary>
        /// 库存查询
        /// </summary>
        /// <returns></returns>
        public void InventoryQuery()
        {
            Dictionary<string, string> dicInventoryQuery = new Dictionary<string, string>();
            dicInventoryQuery.Add("stock_id", StockId);
            dicInventoryQuery.Add("owner_id", OwnerId);
            dicInventoryQuery.Add("product_code", "20150124000001");   //20141231012050
            dicInventoryQuery.Add("page_no", "1");
            dicInventoryQuery.Add("page_size", "10");
            WarehouseInterface warehouse = new WarehouseInterface();
            warehouse.InventoryQuery(dicInventoryQuery);

        }

        #endregion

        #region 订单

        /// <summary>
        /// 发送订单
        /// </summary>
        private void SendOrder()
        {
            //string count, string order_no, string stock_id, string transporter_id, string shop_id, string order_create_time, string order_pay_time, string buyer_nick, string receiver_country, string receiver_province, string receiver_city, string receiver_county, string receiver_address, string receiver_zip, string receiver_name, string receiver_mobile, string receiver_phone, string request_ship_date, string need_invoice, string invoice_name, string invoice_content, string payment, string total_fee, string discount_fee, string post_fee, string need_card, string card_content, string create_date, string goodlist_file_url, string pack_file_url, string out_sid, string product_code, string qty, string payment, string discount_fee, string shop_id, string owner_id, string sell_price, string product_code, string order_no

            //{"reqLogGuid":"D8969B5FF02B452CA189709681FDFCE8","errorText":"","subMessage":"","data":{"failed_list":[{"reason":"订单号:201412310001 order_create_timeorder_pay_time  不能为空\n商品编号:product_code  不能为空! \n商品编号:product_code product_code qty shop_id owner_id  不能为空! \n","order_no":"201412310001"},{"reason":"订单号:201412310001 stock_id order_create_timeorder_pay_time buyer_nick receiver_country receiver_provice receiver_city receiver_county receiver_address receiver_name receiver_mobile skus  不能为空\n","order_no":"201412310001"}],"successs_count":"0","total_count":"2","failed_count":"2"},"errorCode":"100"}



            Dictionary<string, string> dicTrades = new Dictionary<string, string>();
            Dictionary<string, string> dicSkus = new Dictionary<string, string>();
            string product_code = "20150124000001";//条码
            string order_no = "201501240005";
            string count = "1";
            dicTrades.Add("appkey", AppKey);
            dicTrades.Add("count", count);//Y导入订单数量
            dicTrades.Add("order_no", order_no);//Y订单号
            dicTrades.Add("stock_id", StockId);//Y网仓仓库Id (附表三)
            dicTrades.Add("transporter_flag", "0");//Y是否已指定快递 0否1是
            dicTrades.Add("transporter_id", "");//运输商(附表二)当TRANSPORTER_FLAG为1时必填

            dicTrades.Add("shop_id", ShopId);//Y店铺
            dicTrades.Add("order_create_time", DateTime.Now.ToString().Replace("/","-"));//Y拍单时间
            dicTrades.Add("order_pay_time", DateTime.Now.ToString().Replace("/", "-"));//Y付款时间
            dicTrades.Add("buyer_nick", "于东飞");//Y买家昵称
            dicTrades.Add("receiver_country", "中国");//Y收货人国家
            dicTrades.Add("receiver_province", "上海");//Y省
            dicTrades.Add("receiver_city", "上海");//Y市
            dicTrades.Add("receiver_county", "中国");//Y县/区
            dicTrades.Add("receiver_address", "保税区");//Y地址
            dicTrades.Add("receiver_zip", "200000");
            dicTrades.Add("receiver_name", "张三");//Y收件人姓名
            dicTrades.Add("receiver_mobile", "13894939652");//Y收件人移动电话
            dicTrades.Add("receiver_phone", "13894939652");
            dicTrades.Add("request_ship_date", "");
            dicTrades.Add("need_invoice", "0");//Y是否需要发票
            dicTrades.Add("invoice_name", "");
            dicTrades.Add("invoice_content", "");
            dicTrades.Add("payment", "");
            dicTrades.Add("total_fee", "100");//总金额
            dicTrades.Add("discount_fee", "10");//优惠金额
            dicTrades.Add("post_fee", "25");//邮费
            dicTrades.Add("need_card", "0");//Y需要贺卡
            dicTrades.Add("card_content", "");
            dicTrades.Add("create_date", "");
            dicTrades.Add("goodlist_file_url", "www.baidu.com");
            dicTrades.Add("pack_file_url", "");
            dicTrades.Add("out_sid", "20140808058");//快点单号

            dicSkus.Add("product_code", product_code);//Y条码
            dicSkus.Add("qty", "8");//Y数量
            dicSkus.Add("payment", "102");//实付金额
            dicSkus.Add("discount_fee", "10");//优惠金额
            dicSkus.Add("shop_id", ShopId);//Y店铺
            dicSkus.Add("owner_id", OwnerId);//Y货主
            dicSkus.Add("sell_price", "10");//购买单价

            Twee.Comm.WarehouseInterface warehouse = new Twee.Comm.WarehouseInterface();
            warehouse.SendOrder(dicTrades, dicSkus, product_code, order_no, count);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <returns></returns>
        public void OrderCancel()
        {
            Dictionary<string, string> dicOrderCancel = new Dictionary<string, string>();
            string order_no = "201501240002";
            dicOrderCancel.Add("stock_id", StockId);//Y仓库    
            dicOrderCancel.Add("shop_id", ShopId);//Y店铺
            dicOrderCancel.Add("order_no", order_no);//订单号
            dicOrderCancel.Add("remark", "");// 1 发货时间(默认值1)
            WarehouseInterface warehouse = new WarehouseInterface();
            warehouse.OrderCancel(dicOrderCancel);
            
        }

        /// <summary>
        /// 【订单发货查询】
        /// 用于外部查询订单发货情况，返回发货快递公司，单号 ，发货时间
        /// 只有订单状态处于［500-600］之间才能返回快递信息，状态不在此区间时不要调用此接口
        /// 请求method： tradeDeliverQuery
        /// 当查询无数据时返回错误，并无data数据返回
        /// </summary>
        private void OrderDeliverQuery()
        {
            Dictionary<string, string> dicDeliverQuery = new Dictionary<string, string>();
            string order_no = "201501240003";
            dicDeliverQuery.Add("stock_id", StockId);//Y仓库    
            dicDeliverQuery.Add("shop_id", ShopId);//Y店铺
            dicDeliverQuery.Add("order_no", order_no);//订单号
            dicDeliverQuery.Add("time_type", "");// 1 发货时间(默认值1)
            dicDeliverQuery.Add("begin_date", "2014-12-30 15:33:12");// 规则：1. BEGIN_ DATE有值时End_DATE必填 2．ORDER_NO和｛BEGIN _DATE,End_ DATE｝必填一个
            dicDeliverQuery.Add("end_date", "2015-12-31 19:33:12");// 
            dicDeliverQuery.Add("page_no", "1");// 页码 BEGIN_ DATE不为空时必传
            dicDeliverQuery.Add("page_size", "10");// 每页行数BEGIN_ DATE不为空时必传
            WarehouseInterface warehouse = new WarehouseInterface();
            warehouse.OrderDeliverQuery(dicDeliverQuery);
        }

        /// <summary>
        /// 【订单状态查询】
        /// 用于外部及时同步订单状态
        /// 订单状态不处于［500至600］且不等于990和995时可调用此接口
        /// 当查询到订单状态处于［500至600］后不要再调用此接口，可调用订单发货详情接口
        /// 990，995订单已取消或删除
        /// 请求method： tradeStatusQuery
        /// 当查询无数据时返回错误，并无data数据返回
        /// </summary>
        private void OrderStateQuery()
        {
            Dictionary<string, string> dicOrders = new Dictionary<string, string>();
            string order_no = "201501240005";
            dicOrders.Add("stock_id", StockId);//Y仓库    
            dicOrders.Add("shop_id", ShopId);//Y店铺
            dicOrders.Add("order_no", order_no);//订单号
            dicOrders.Add("time_type", "1");// 1订单最后更新时间(默认) 2付款时间 3发货时间 4系统创建时间 5平台创建时间
            dicOrders.Add("status", "");// 订单状态
            dicOrders.Add("begin_create_date", "2012-10-31 17:45:40");// 格式2012-10-31 17:45:40 ;对应订单中日期 规则：1. BEGIN_DATE有值时End_DATE必填 2ORDER_NO和｛BEGIN _ DATE,End _DATE｝必填一个
            dicOrders.Add("end_create_date", "2015-10-31 17:45:40");// 
            dicOrders.Add("page_no", "1");// 页码
            dicOrders.Add("page_size", "10");// 每页行数
            Twee.Comm.WarehouseInterface warehouse = new Twee.Comm.WarehouseInterface();
            warehouse.OrderStateQuery(dicOrders);


//订单状态：

//100	等待审核
//120	等待客服审核
//130	审核完成
//300	等待仓库处理
//310	等待打印
//320	打印完成
//350	正在拣选
//400	拣料完成
//420	包装完成
//430	终检完成
//450	下料完成
//500	交接完成
//550	快递系统录入
//555	目的省匹配
//560	目的市匹配
//565	目的区匹配
//600	客户签收
//900	锁定
//920	异常
//930	库存不足
//935	预售等货
//940	拣选缺货
//98	暂存
//990	作废
//995	删除

        }

       

        #endregion


    }
}