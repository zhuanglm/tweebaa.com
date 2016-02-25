using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Com.Alipay;
using Twee.Mgr;
using Twee.Comm;

namespace TweebaaWebApp
{
    public partial class return_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);

                Response.Write("参数集合：" + Request.RequestContext.HttpContext);


                if (verifyResult)//验证成功
                {                 
                   
                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中页面跳转同步通知参数列表
                    //-----------------------------------------------------------------ydf
                    //商户订单号
                    string out_trade_no = Request.QueryString["out_trade_no"];
                    Response.Write("订单号：" + out_trade_no);

                    //减少库存,并修改订单状态为已支付，状态：1
                    if (!string.IsNullOrEmpty(out_trade_no))
                    {
                        //1. 修改库存
                        PrdStoragMgr Storag = new PrdStoragMgr();
                        OrderMgr orderMgr = new OrderMgr();
                        bool b1 = orderMgr.UpdateOrderState(out_trade_no,1);                       
                        if (b1==true)
                        {
                            Response.Write("修改订单状态成功！");
                        }
                        else
                        {
                            Response.Write("修改订单状态失败！");
                        }

                        bool b2 = Storag.UpdateStoragByOrder(out_trade_no.Trim());
                        if (b2==true)
                        {
                            Response.Write("修改库存成功！");
                        }
                        else
                        {
                            Response.Write("修改库存失败！");
                        }

                        //2. 创建发布者收益
                        //Guid? userGuid = CommUtil.IsLogion();
                        //ProfitMgr mgr = new ProfitMgr();
                        //bool b2 = mgr.PublishProfitCal(out_trade_no);
                        //if (b2==true)
                        //{
                        //    Response.Write("会员收益创建成功!");
                        //}
                        //else
                        //{
                        //    Response.Write("会员收益创建失败!");
                        //}
                       
                    }                   

                    //支付宝交易号
                    string trade_no = Request.QueryString["trade_no"];

                    //交易状态
                    string trade_status = Request.QueryString["trade_status"];

                    if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序
                    }
                    else
                    {
                        Response.Write("trade_status=" + Request.QueryString["trade_status"]);
                    }

                    //打印页面
                    Response.Write("验证成功<br />");

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——
                  
                }
                else//验证失败
                {
                    Response.Write("验证失败");
                }
            }
            else
            {
                Response.Write("无返回参数");
            }
        }

        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
        }
    }
}