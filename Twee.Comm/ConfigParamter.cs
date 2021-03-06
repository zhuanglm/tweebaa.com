﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Comm
{
    public class ConfigParamter
    {
        /// <summary>
        /// 后台其它列表显示数目(会员中心)
        /// </summary>
        public const int pageSize = 10;
        /// <summary>
        /// 后台产品列表显示数目
        /// </summary>
        public const int prdPageSize = 20;
        /// <summary>
        /// 前台产品列表显示数目
        /// </summary>
        public const int frontPrdPageSize = 60;
        /// <summary>
        /// 后台一般列表显示数目
        /// </summary>
        public const int recordSize = 20;

        /// <summary>
        /// 叠图分享模板列表显示条数
        /// </summary>
        public const int templateSize = 10;

        /// <summary>
        /// 订单完成多少天之后，才可以提取收益金额。即过了退货期之后，退货期为7天
        /// </summary>
        public const int payMoneyAfterDay = 7;

        /// <summary>
        /// 目标评审个数（所有产品统一）
        /// </summary>
        public const int previewTarget = 300;

        /// <summary>
        ///  Tweebaa default ship method id 
        /// </summary>
        public const int iTweebaaDefaultShipMethodID = 1;  //Tweebaa-Standard 2-7 Business Days

        /// <summary>
        /// 1购物积分=0.0125$;
        /// </summary>
        public const decimal shoppingPointRate = 0.0125M;

        public enum CountryID
        {
            /// <summary>
            /// USA
            /// </summary>
            USA = 1,
            /// <summary>
            /// Canada
            /// </summary>
            Canada = 2
        }


        public enum Gender
        { 
            /// <summary>
            /// 男
            /// </summary>
            male=1,
            /// <summary>
            /// 女
            /// </summary>
            female=0,
            /// <summary>
            /// 不明
            /// </summary>
            unknow=2
        }

        public static Dictionary<int, string> GenderDic = new Dictionary<int, string> { 
         {0,"女"},
         {1,"男"},
         {2,"不明"}
        };


        /// <summary>
        /// 注册会员的状态
        /// </summary>
        public enum UserStatus
        { 
            /// <summary>
            /// 锁定
            /// </summary>
            locked=0,
            /// <summary>
            /// 正常
            /// </summary>
            normal=1,
            /// <summary>
            /// 等激活
            /// </summary>
            waitlive=2
        }



        public static Dictionary<int, string> UserStatusDic = new Dictionary<int, string> { 
         {0,"锁定"},
         {1,"正常"},
         {2,"待激活"}
        };


        /// <summary>
        /// 产品状态枚举:
        /// 【屏蔽:-1】【草稿:0】【评审中(大众):1】【预售中:2】【销售中:3】；
        /// 【评审中(推易吧):4】【评审失败(推易吧):5】【等待上架:6】【预售失败:7】
        /// </summary>
        public enum PrdSate
        {
            /// <summary>
            /// 屏蔽
            /// </summary>
            shield = -1,



            /// <summary>
            /// 草稿
            /// </summary>
            draft = 0,

            /// <summary>
            /// 进入大众评审前的审核中
            /// </summary>
            check=11,
            /// <summary>
            /// 进入大众评审前的审核失败
            /// </summary>
            checkFail=12,

            /// <summary>
            /// 大众评审中
            /// </summary>
            review = 1,
            /// <summary>
            /// 大众评审失败
            /// </summary>
            reviewFail = 8,

            /// <summary>
            /// 推易吧终审中
            /// </summary>
            tweeReview = 4,

            /// <summary>
            /// 推易吧评审失败
            /// </summary>
            reviewFalse = 5,

            /// <summary>
            /// 预售中
            /// </summary>
            preSale = 2,
            /// <summary>
            /// 预售失败
            /// </summary>
            saleFalse = 7,

            /// <summary>
            /// 等待上架中
            /// </summary>
            waitSale = 6,
            /// <summary>
            /// 拒绝上架
            /// </summary>
            cannotSale=10,

            /// <summary>
            /// 销售中
            /// </summary>
            sale = 3,
            /// <summary>
            /// 已下架
            /// </summary>
            downSale=9

        };

        /// <summary>
        /// 产品状态字典
        /// </summary>
        public static Dictionary<int, string> PrdSateDic = new Dictionary<int, string> { 
          {0,"草稿"},
          {1,"大众评审中"},
          {2,"预售中"},
          {7,"预售失败"},
          {4,"推易吧终审中"},
          {5,"推易吧终审失败"},
          {6,"等待上架"},
          {3,"销售中"},
          {-1,"屏蔽"},
          {8,"大众评审失败"},
          {9,"已下架"},
          {10,"拒绝上架"},
          {11,"初审中"},
          {12,"初审失败"}
        };

        //产权信息
        public static Dictionary<int, string> RightType = new Dictionary<int, string> { 
          {1,"自有产权"},{2,"授权经销"},{3,"无"}
        };
        //产品所在地
        public static Dictionary<int, string> ProAddress = new Dictionary<int, string> { 
          {1,"加拿大"},{2,"中国"},{3,"美国"}
        };
        //产品样品
        public static Dictionary<int,string> ProExample=new Dictionary<int,string> {
          {1,"免费样品"},{2,"收费样品"},{3,"不提供样品"}
        };
        //是否有库存
        public static Dictionary<int,string> ProStock=new Dictionary<int,string> {
          {1,"有"},{2,"无"}
        };
        //是否提供一件代发
        public static Dictionary<int, string> ProSend = new Dictionary<int, string> {
          {1,"提供"},{2,"不提供"}
        };
        //发货范围
        public static Dictionary<int, string> ProSendArea = new Dictionary<int, string> {
          {1,"仅限生产国"},{2,"全世界"},{3,"北美"},{4,"澳洲"},{5,"亚洲"}
        };
        //海外仓库
        public static Dictionary<int, string> ProStockout = new Dictionary<int, string> {
          {1,"提供"},{2,"不提供"}
        };
        //售后服务
        public static Dictionary<int, string> ProSaleservice = new Dictionary<int, string> {
          {1,"提供"},{2,"不提供"}
        };

        public  enum ShouYiType { 
            myfabu=1,
            mypingshen=2,
            myfenxiang=3
        }

        //public enum OrderType {  // This has been changed to OrderStatus
        //   //0 未支付，1待发货，2已发货，3已完成，-1 已作废
        //    weizhifu=0,
        //    daifahou=1,
        //    yifahou=2,
        //    yiwancheng=3,
        //    yizuofei=-1
        //}
        ////订单状态：0 未支付，1待发货，2已发货，3已完成，-1 已作废,-2申请退货中，-3退货中，-4待退款，-5退货完成,-6删除
        public enum OrderStatus
        {
            //0 未支付，1待发货，2已发货，3部份已发货 -1 已作废
            UnPaid = 0,
            WaitingToShip = 1,
            Shipped = 2,
            PartiallyShipped = 3,
            Cancelled = -1,
            ReturnRequest = -2 , //Add by Long base on Orderhead.cs
            ReturnProcessing = -3 ,
            WaitingToRefund = -4,
            RefundCompleted = -5,
            RecordDeleted = -6
        }


        #region 供货单状态,产品区上架与下架操作必须来改变这里的状态
        /// <summary>
        /// 供货单状态,产品区上架与下架操作必须来改变这里的状态
        /// </summary>
        public enum InventoryState
        {
            /// <summary>
            /// 保存草稿
            /// </summary>
            draft=0, //save = 0,  
            /// <summary>
            /// 提交审核
            /// </summary>
            submit = 1, 
            /// <summary>
            /// 已采纳
            /// </summary>
            accepted =2, //pass = 2,    
            /// <summary>
            /// 未采纳
            /// </summary>
            rejected=3, //nopass = 3,  
            /// <summary>
            /// 已推送仓库
            /// </summary>
            push=4,
            /// <summary>
            /// 已下采购单
            /// </summary>
            purchaseOrder=5,
            /// <summary>
            /// 已取消采购单
            /// </summary>
            cancelPurchaseOrder=6,
            /// <summary>
            /// 已入库
            /// </summary>
            inStorage=7,


            /// <summary>
            /// 已上架，【表示该产品已经可以销售】（点击上架按钮后改变状态为effect：99）
            /// 点击上架的前提条件为该产品的状态已经为已入库：7
            /// </summary>
            effect=99,
         
            /// <summary>
            /// 表示该产品已经下架不能进行买卖了
            /// </summary>
            uneffect=100 
        }
        /// <summary>
        /// 供货单状态,产品区上架与下架操作必须来改变这里的状态
        /// </summary>
        public static Dictionary<int, string> InventoryStateConfig = new Dictionary<int, string> {
          {0,"保存草稿"},
          {1,"提交审核"},
          {2,"已采纳"},  //已采纳之后，供货页面只能填写条形码，当状态值大于这个状态时供货页面所有信息都不能再保存
          {3,"未采纳"},
          {4,"已推送"}, //这里是指供货信息推送到仓库
          {5,"已下采购单"},
          {6,"已取消采购单"},
          {7,"已入库"}, //这里是指采购的产品已经入库
          {99,"已上架"}, //表示该产品已经有库存并以上架买卖
          {100,"已下架"} //表示该产品已经下架不能进行买卖了
        };
        /// <summary>
        /// 供货单状态,产品区上架与下架操作必须来改变这里的状态
        /// </summary>
        public static Dictionary<int, string> InventoryStateConfigEn = new Dictionary<int, string> {
          {0,"Save drafts"},
          {1,"Submit audit"},
          {2,"Has been taken"},  //已采纳之后，供货页面只能填写条形码，当状态值大于这个状态时供货页面所有信息都不能再保存
          {3,"Not taken"},
          {4,"Have pushed"}, //这里是指供货信息推送到仓库
          {5,"Under the purchase order"},
          {6,"Cancel the purchase order"},
          {7,"puted in storage"}, //这里是指采购的产品已经入库
          {99,"Has been on"}, //表示该产品已经有库存并以上架买卖
          {100,"Off the shelves"} //表示该产品已经下架不能进行买卖了
        }; 
        #endregion

        /// <summary>
        /// 支付宝绑定状态
        /// </summary>
        public enum PayAccountBind { 
             bind=1,//已经绑定
             unbind=0 //已经解除绑定
        }

        /// <summary>
        /// gift source
        /// </summary>
        public enum GiftSource
        {
            /// <summary>
            /// PassedTestSale
            /// </summary>
            PassTestSale = 1  // gift is given out when pass test sale
        }

        /// <summary>
        /// gift
        /// </summary>
        public enum Gift
        {
            /// <summary>
            /// PassedTestSale
            /// </summary>
            Product = 1,            // product as a gift
            MerchandseCredit = 2    // merchandise credt
        }

         
        /// <summary>
        /// gift status
        /// </summary>
        public enum GiftStatus
        {
            /// <summary>
            /// PassedTestSale
            /// </summary>
            Pending = 1,   
            Shipped = 2,  
            Cancelled = 3
        }


        /// <summary>
        /// ship partner
        /// </summary>
        public enum ShipPartner
        {
            Fosdick = 1,
            EOrder = 2,
            DropShipper=3
        }


        /// <summary>
        /// Dropshipper Order Status
        /// </summary>
        public enum DropshipperOrderStatus
        {
            Submitted = 1,
            Rejected =2,
            Backordered = 3,
            ReceivedByWarehouse = 4, 
            ReadyForShipping = 5, 
            SentToWarehouse=6,
            Shipped =7, 
            Delivered=8,
            Cancelled=9 
        }

        /// <summary>
        /// DropshipperOrderStatus
        /// </summary>
        public static Dictionary<int, string> DropshipperOrderStatusNameEn = new Dictionary<int, string> {
          {1,"Submitted"},
          {2,"Rejected"},  
          {3,"Backordered"},
          {4,"Received By Warehouse"}, 
          {5,"Ready For Shipping"},
          {6,"Sent To Warehouse"},
          {7,"Shipped"},
          {8,"Delivered"}, 
          {9,"Cancelled"} 
        };

        /// <summary>
        /// Fosdick order return reason
        /// </summary>
        public static Dictionary<int, string> FosdickOrderReturnReasonNameEn = new Dictionary<int, string> {
          {0,"Unknown"},
          {1,"Undeliverable"},
          {2,"Defective"},  
          {3,"Wrong Item"}, 
          {4,"No Longer Wanted"},
          {5,"Never Ordered"},
          {6,"Refused"},
          {7,"No reason given"}, 
          {8,"Wrong size or color"}, 
          {9,"Other"} 
        };


        /// <summary>
        /// Cash Withdraw Status
        /// 0:表示仅创建了该申请记录 1:表示该申请金额已经付款。2:表示该申请记录作废
        /// This status is used for the state in wn_ProfitOut table
        /// </summary>
        public enum CashWithdrawStatus
        {
            Request = 0,
            Accepted = 1,
            Rejected = 2
        }

        /// <summary>
        /// Profit out type
        /// 0:Cash Withdraw 1:Use for Shopping
        /// This status is used for the type in wn_ProfitOut table
        /// </summary>
        public enum ProfitOutType
        {
            CashWithdraw = 0,
            UseForShopping = 1
        }


        #region

        #endregion

    }
}
