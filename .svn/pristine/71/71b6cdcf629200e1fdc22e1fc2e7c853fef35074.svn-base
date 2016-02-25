using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Twee.Comm;

namespace TweebaaWebApp.AjaxPages
{
    public partial class inventoryAjax :  TweebaaWebApp.MasterPages.BasePage
    {
        //以后这里所有的代码要变成事务操作【这里要注意】

        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        private Guid? userGuid;
        Dictionary<string, object> dic = null;

        Twee.Mgr.proDetailsMgr proDetailsMgr = new Twee.Mgr.proDetailsMgr();//基本数据
        Twee.Mgr.proRulesMgr proRulesMgr = new Twee.Mgr.proRulesMgr();//规格数据
        Twee.Mgr.proPriceMgr proPriceMgr = new Twee.Mgr.proPriceMgr();//每个规格的价格区间
        Twee.Mgr.proDetailOtherMgr otherMgr = new Twee.Mgr.proDetailOtherMgr();//后来新增的其它基本数据
        public string _action = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request["action"]))
                {
                    Response.Write("bad request");
                    return;
                }
                else
                {
                    _action = Request["action"].Trim();
                }



                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string pageInfo = sr.ReadToEnd();
                if (string.IsNullOrEmpty(pageInfo))
                    return;

                try
                {
                    List<string> jsonList = pageInfo.Split('§').ToList();

                    #region  添加产品详细信息

                    Dictionary<string, object> proDetailDic = new Dictionary<string, object>();
                    string proDetailInfo = jsonList[0];
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    proDetailDic = js.Deserialize<Dictionary<string, object>>(proDetailInfo);
                    Twee.Model.proDetails model = new Twee.Model.proDetails();
                    if (!string.IsNullOrEmpty(proDetailDic["id"].ToString()))
                        model.id = Convert.ToInt32(proDetailDic["id"].ToString());
                    model.proid = proDetailDic["proid"].ToString();
                    model.proright = proDetailDic["proright"].ToString()._ToInt();
                    model.proaddress = proDetailDic["proaddress"].ToString();
                    model.proexample = proDetailDic["proexample"].ToString()._ToInt();
                    model.proexampleprice = proDetailDic["proexampleprice"].ToString()._ToDecimal();
                    model.prosmallnum = proDetailDic["prosmallnum"].ToString();
                    model.promodelnum = proDetailDic["promodelnum"].ToString();
                    model.prostock = proDetailDic["stock"].ToString()._ToDecimal();
                    model.stocknum = proDetailDic["stocknum"].ToString()._ToInt();
                    model.state = proDetailDic["state"].ToString()._ToInt();
                    model.userid = proDetailDic["userid"].ToString();
                    if (_action=="add")
                        proDetailsMgr.Add(model);
                    if(_action=="update")
                        proDetailsMgr.Update(model);

                    #endregion

                    #region 添加规格详细信息
                    //Dictionary<string, object> proRuleDic = new Dictionary<string, object>();
                    //var rulejson = jsonList[1];
                    //if (string.IsNullOrEmpty(rulejson))
                    //    return;
                    //var proRuleInfo = jsonList[1].Split('※');
                    //JavaScriptSerializer jsRule = new JavaScriptSerializer();
                    //foreach (string item in proRuleInfo)
                    //{
                    //    proRuleDic = jsRule.Deserialize<Dictionary<string, object>>(item);
                    //    Twee.Model.proRules ruleModel = new Twee.Model.proRules();
                    //    ruleModel.id = Convert.ToInt32(proRuleDic["id"].ToString());
                    //    ruleModel.proid = proRuleDic["proid"].ToString();
                    //    ruleModel.userid = proRuleDic["userid"].ToString();
                    //    ruleModel.proruletitle = proRuleDic["proruletitle"].ToString()._ToInt();
                    //    ruleModel.prorule = proRuleDic["prorule"].ToString();
                    //    ruleModel.prostock = proRuleDic["prostock"].ToString();
                    //    ruleModel.prosku = proRuleDic["prosku"].ToString();
                    //    ruleModel.proweight = proRuleDic["proweight"].ToString()._ToDecimal();
                    //    ruleModel.proboxweight = proRuleDic["proboxweight"].ToString()._ToDecimal();
                    //    ruleModel.probox = proRuleDic["probox"].ToString()._ToDecimal();
                    //    ruleModel.prosize = proRuleDic["prosize"].ToString();
                    //    ruleModel.probulk = proRuleDic["probulk"].ToString()._ToDecimal();
                    //    ruleModel.procolor = proRuleDic["procolor"].ToString();
                    //    if (_action == "add")
                    //        proRulesMgr.Add(ruleModel);
                    //    if (_action == "update")
                    //    {
                    //        if(ruleModel.id!=-1)
                    //           proRulesMgr.Update(ruleModel);
                    //        else
                    //            proRulesMgr.Add(ruleModel);
                    //    }
                    //}

                    #endregion

                    #region 添加价格区间
                    //Dictionary<string, object> proPriceDic = new Dictionary<string, object>();
                    //var pricejson = jsonList[2];
                    //if (string.IsNullOrEmpty(pricejson))
                    //    return;
                    //JavaScriptSerializer jsPrice = new JavaScriptSerializer();
                    //string[] pric = pricejson.Split('＆');
                    //List<Twee.Model.proPrice> list = new List<Twee.Model.proPrice>();
                    //foreach (string str in pric)
                    //{
                    //    Twee.Model.proPrice k = jsPrice.Deserialize<Twee.Model.proPrice>(str);
                    //    list.Add(k);
                    //}
                    ////list = jsPrice.Deserialize<List<Twee.Model.proPrice>>(pricejson);
                    //if (list == null)
                    //    return;
                    //foreach (var item in list)
                    //{
                    //    if (_action == "add")
                    //        proPriceMgr.Add(item);
                    //    if (_action == "update")
                    //    {
                    //        if(item.id!=-1)
                    //            proPriceMgr.Update(item);
                    //        else
                    //            proPriceMgr.Add(item);
                    //    }
                    //}

                    #endregion

                    #region  添加材质以及仓储信息
                    Dictionary<string, object> proDetailOtherDic = new Dictionary<string, object>();
                    string proDetailOtherInfo = jsonList[1];
                    JavaScriptSerializer jsOther = new JavaScriptSerializer();
                    proDetailOtherDic = js.Deserialize<Dictionary<string, object>>(proDetailOtherInfo);
                    Twee.Model.proDetailOther pro = new Twee.Model.proDetailOther();
                    if (!string.IsNullOrEmpty(proDetailOtherDic["id"].ToString()))
                       pro.id =Convert.ToInt32( proDetailOtherDic["id"].ToString()) ;
                    pro.userid = proDetailOtherDic["userid"].ToString();
                    pro.proid = proDetailOtherDic["proid"].ToString();
                    pro.procaizhi = proDetailOtherDic["procaizhi"].ToString();
                    pro.procaizhicontent = proDetailOtherDic["procaizhicontent"].ToString();
                    pro.prosend = proDetailOtherDic["prosend"].ToString();
                    pro.prosendarea = proDetailOtherDic["prosendarea"].ToString();
                    pro.prostockout = proDetailOtherDic["prostockout"].ToString();
                    pro.prostockoutinfo = proDetailOtherDic["prostockoutinfo"].ToString();
                    pro.prosaleservice = proDetailOtherDic["prosaleservice"].ToString();
                    pro.prosaleserviceinfo = proDetailOtherDic["prosaleserviceinfo"].ToString();
                    if(_action=="add")
                        otherMgr.Add(pro);
                    if (_action == "update")
                        otherMgr.Update(pro);

                    #endregion

                    Response.Clear();
                    if (_action == "add")
                    {
                        Response.Write("add_success");
                    }
                    if (_action == "update")
                    {
                        Response.Write("update_success");
                    }
                }
                catch (Exception ex)
                {
                    Response.Clear();
                    if (_action == "add")
                        Response.Write("add_fail");
                    if (_action == "update")
                        Response.Write("update_fail");
                }
            }
        }

       
    }
}