using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp.Home
{
    public partial class Home : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;

        public string _fabu = string.Empty;
        public string _pingshen = string.Empty;
        public string _fenxiang = string.Empty;
        public string _weizhifu = string.Empty;
        public string _yifahuo = string.Empty;

        public Twee.Mgr.MoneyMgr moneyMgr = new Twee.Mgr.MoneyMgr();
        public Twee.Mgr.OrderMgr orderMgr = new Twee.Mgr.OrderMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
             bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                //Response.Write("<script type='text/javascript'>alert('非法链接')</script>");
                return;
            }
            int fabu = (int)Twee.Comm.ConfigParamter.ShouYiType.myfabu;
            int pingshen = (int)Twee.Comm.ConfigParamter.ShouYiType.mypingshen;
            int fenxiang = (int)Twee.Comm.ConfigParamter.ShouYiType.myfenxiang;
            _fabu = moneyMgr.GetShouYi(userGuid.ToString(), fabu.ToString())._DefaultToString("0.00");
            _pingshen = moneyMgr.GetShouYi(userGuid.ToString(), pingshen.ToString())._DefaultToString("0.00");
            _fenxiang = moneyMgr.GetShouYi(userGuid.ToString(), fenxiang.ToString())._DefaultToString("0.00");

            int weizhifu=(int)Twee.Comm.ConfigParamter.OrderStatus.UnPaid;
            int yifahou = (int)Twee.Comm.ConfigParamter.OrderStatus.Shipped;
            //int yiwancheng = (int)Twee.Comm.ConfigParamter.OrderStatus.OrderType.yiwancheng;

            _weizhifu = orderMgr.GetInfo(userGuid.ToString(), weizhifu.ToString())._DefaultToString("0");
            //_yifahuo = orderMgr.GetInfo(userGuid.ToString(), yiwancheng + "," + yifahou)._DefaultToString("0");
            _yifahuo = orderMgr.GetInfo(userGuid.ToString(), yifahou.ToString())._DefaultToString("0");
            
        }
    }
}