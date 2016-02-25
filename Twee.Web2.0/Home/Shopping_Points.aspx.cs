using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Data;
using Twee.Mgr;


namespace TweebaaWebApp2.Home
{
    public partial class Shopping_Points : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid? userGuid = CommUtil.IsLogion();
                if (userGuid != null)
                {
                    Twee.Mgr.UserGradeCalMgr mgr = new Twee.Mgr.UserGradeCalMgr();
                    DataTable dt = mgr.GetUserGrade(userGuid.Value);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //发布者
                        /*
                        int iPublishLevel = Int32.Parse(dt.Rows[0]["publishgrade"].ToString());
                        if (iPublishLevel == 0) iPublishLevel = 1;
                        labPGrade.Text = iPublishLevel.ToString();//等级

                        //labPGrade.Text = dt.Rows[0]["publishgrade"].ToString();//等级
                        labPIntegral.Text = dt.Rows[0]["publishintegral"].ToString();//积分
                        //labPIntegralRemove.Text = dt.Rows[0][""].ToString();
                        labPRatio.Text = (dt.Rows[0]["pratio"].ToString().ToDecimal() / 100).ToString();//佣金比例


                        //评审者
                        int iReviewLevel = Int32.Parse(dt.Rows[0]["reviewgrade"].ToString());
                        if (iReviewLevel == 0) iReviewLevel = 1;
                        labRGrade.Text = iReviewLevel.ToString();//等级

                        //labRGrade.Text = dt.Rows[0]["reviewgrade"].ToString();//等级
                        labRIntegral.Text = dt.Rows[0]["reviewintegral"].ToString();//积分
                        //labRIntegralRemove.Text = dt.Rows[0][""].ToString();
                        labRRatio.Text = (dt.Rows[0]["rratio1"].ToString().ToDecimal() / 100).ToString();//佣金比例


                        //分享者
                        int iShareLevel = 0;
                        if (!DBNull.Value.Equals(dt.Rows[0]["sharegrade"])) iShareLevel = Int32.Parse(dt.Rows[0]["sharegrade"].ToString());
                        if (iShareLevel == 0) iShareLevel = 1;
                        labSGrade.Text = iShareLevel.ToString();//等级

                        //labSGrade.Text = dt.Rows[0]["sharegrade"].ToString();//等级
                        labSIntegral.Text = dt.Rows[0]["shareintegral"].ToString();//积分
                        //labSIntegralRemove.Text = dt.Rows[0][""].ToString();
                        labSRatio.Text = (dt.Rows[0]["sratio"].ToString().ToDecimal() / 10).ToString();//佣金比例
                         * */

                        /*
                        decimal iShoppingPoint = 0M;
                        if (!DBNull.Value.Equals(dt.Rows[0]["shopingpoint"])) iShoppingPoint = dt.Rows[0]["shopingpoint"].ToString().ToDecimal();
                        labAvailablePoint.Text = iShoppingPoint.ToString();
                        labSumShop2.Text = Math.Round(iShoppingPoint * 0.0125M, 2).ToString();
                        */

                        OrderMgr order = new OrderMgr();
                        decimal shoppingMoney = order.GetSumShopMoney(userGuid.ToString(), ConfigParamter.OrderStatus.Shipped);    //change 3 --2 
                        decimal shoppingBobusMoney = order.GetBonusShoppingPoint(userGuid.ToString(), ConfigParamter.OrderStatus.Shipped);   //Bonus
                        decimal used_shopping_money = order.GetSumUsedShoppingPointsMoney(userGuid.ToString());
                        decimal shoppingMoneyPending = order.GetSumShopMoney(userGuid.ToString(), ConfigParamter.OrderStatus.WaitingToShip);

                        //get bonus shopping point
                        decimal shoppingPendingBonus = order.GetBonusShoppingPoint(userGuid.ToString(), ConfigParamter.OrderStatus.WaitingToShip);//Bonus

                        // shopping gift reward
                        UserGiftRewardMgr giftMgr = new UserGiftRewardMgr();
                        int iGiftShoppingPoint = giftMgr.GetTotalShoppingRewardPoint(userGuid.ToString());

                        shoppingMoney += iGiftShoppingPoint;
                        shoppingMoney += shoppingBobusMoney;

                        shoppingMoneyPending += shoppingPendingBonus;

                        shoppingMoney = shoppingMoney - used_shopping_money * 80;
                        labAvailablePoint.Text = Math.Round(shoppingMoney, 2).ToString();
                        labSumShop2.Text = Math.Round(shoppingMoney * 0.0125M, 2).ToString();
                        labSumShopPending.Text = Math.Round(shoppingMoneyPending, 2).ToString();

                    }
                }
            }
        }
    }
}