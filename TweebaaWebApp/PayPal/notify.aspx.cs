﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using Twee.Mgr;

namespace TweebaaWebApp.Paypal
{
    public partial class notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strFormValues;
            string strNewValue;
            string strResponse;
            //创建回复的 request
            //在 Sandbox 情况下， 设置：
            // WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");
            HttpWebRequest req = (HttpWebRequest)
            //WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");
            WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");
            //设置 request 的属性
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = HttpContext.Current.Request.BinaryRead(
            HttpContext.Current.Request.ContentLength);
            strFormValues = Encoding.ASCII.GetString(param);
            //建议在此将接受到的信息记录到日志文件中以确认是否收到 IPN 信息
            strNewValue = strFormValues + "&cmd=_notify-validate";
            req.ContentLength = strNewValue.Length;
            //发送 request
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(),
            System.Text.Encoding.ASCII);
            stOut.Write(strNewValue);
            stOut.Close();
            //回复 IPN 并接受反馈信息
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();
            stIn.Close();
            //确认 IPN 是否合法
            if (strResponse == "VERIFIED")
            {
                //付款成功
                //检查付款状态
                //检查 txn_id 是否已经处理过
                //检查 receiver_email 是否是您的 PayPal 账户中的 EMAIL 地址
                //检查付款金额和货币单位是否正确
                //处理这次付款， 包括写数据库               

                string out_trade_no = HttpContext.Current.Request["item_number1"].ToString().Trim();
                //string out_trade_no = "Twee20166823528360";
                if (!string.IsNullOrEmpty(out_trade_no))
                {
                    //1. 修改库存
                    PrdStoragMgr Storag = new PrdStoragMgr();
                    OrderMgr orderMgr = new OrderMgr();
                    bool b1 = orderMgr.UpdateOrderState(out_trade_no, 1);
                    if (b1 == true)
                    {
                        //Response.Write("修改订单状态成功！");
                    }
                    else
                    {
                        //Response.Write("修改订单状态失败！");
                    }

                    //bool b2 = Storag.UpdateStoragByOrder(out_trade_no.Trim());
                    //if (b2 == true)
                    //{
                    //    Response.Write("修改库存成功！");
                    //}
                    //else
                    //{
                    //    Response.Write("修改库存失败！");
                    //}
                }      

            }
            else if (strResponse == "INVALID")
            {
                //付款失败

                //string paypalInfo = strFormValues;
                //string dt = System.DateTime.Now.ToString();
                //string sql = "insert into paypal (notify,createtime) values ('INVALID','" + dt + "')";
                //Twee.Comm.DbHelperSQL.ExecuteSql(sql);

                Application["test"] = "INVALID";
                Response.Redirect("~/weclome.aspx");
            }
            else
            {
                Application["test"] = "no data paypal";
            }
        }
    }
}