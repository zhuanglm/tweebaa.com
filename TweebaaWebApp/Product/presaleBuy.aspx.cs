﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Comm;
using System.Data;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using log4net;
using System.Reflection;
using TweebaaWebApp.MasterPages;
using Twee.Model;

namespace TweebaaWebApp.Product
{
  
    public partial class presaleBuy : BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string _ruleName = string.Empty;//规格名称
        public string _firstColor = string.Empty;
        public string _firstRuleStoreNum = "0";//首次加载计算第一个规格的库存
        public string _allColor = string.Empty;
        public string _jsonRuleAndColor = string.Empty;
        public string _proid = string.Empty;
        public string _passCount = "3"; // will be implent later
        public Prd _model;
        public Guid _prdGuid;
        public string _imgUrl = string.Empty;
        public string _proRuleTitle = string.Empty;
        public bool   _favorite = false;  // when login if the product is the user's favoriate product.
        public string _sCurVer = "0";

        protected void Page_Load(object sender, EventArgs e)
        {

            _sCurVer = CommUtil.GetCurrentVersion();

            bool isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                
                _userid = userGuid.ToString();
               
            }

            #region 于东飞代码(逻辑已经迁移到 pwdAjax.aspx.cs下)
            //string url = Request.Url.ToString();
            //if (url.Contains("isshare"))
            //{
            //    ShareMgr share = new ShareMgr();
            //    DataSet ds = share.GetList("shareurl='" + url + "'");
            //    if (ds!=null&&ds.Tables.Count>0)
            //    {
            //        DataTable dt = ds.Tables[0];
            //        Guid? shareUser = dt.Rows[0]["userguid"].ToString().ToGuid();//分享者id
            //        string shareGuid = dt.Rows[0]["guid"].ToString();//该分享链接id

            //        CookiesHelper cookie = new CookiesHelper();
            //        //string cookieName = System.Configuration.ConfigurationManager.AppSettings["cookieshareUrl"].ToString();
            //        string cookieValue = cookie.getCookie(shareGuid);//是以分享链接的数据库id作为cookie的key值的
            //        if (string.IsNullOrEmpty(cookieValue))
            //        {
            //            //如果分享链接的cookie不存在，则修改链接的访问数加1
            //            bool b1 = share.UpdateVisitCount(url);
            //            if (b1)
            //            {
            //                //修改访问数后，创建该链接的cookie,设置有效期1天。  1天后，cookie消失，再访问才计数
            //                bool b2 = cookie.createCookie(shareGuid, shareGuid, 1);
            //            }
                       
            //        }

                    
            //    }
            //}
            #endregion

            #region lcs

            if (string.IsNullOrEmpty(Request["id"]))
            {
                //Response.Write("<script type='text/javascript'>alert('非法链接')</script>");
                Response.Redirect("~/product/prdSaleAll.aspx");
                return;
            }
            string proid = Request["id"].Trim();
            _proid = proid;
            
            string shareID = string.Empty;
            string prdID = Twee.Comm.CommUtil.GetUrlPrdId(_proid, out shareID);

            _prdGuid = (Guid)Twee.Comm.CommUtil.ToGuid(prdID);
            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();

            FileMgr fileMgr = new FileMgr();
            List<Twee.Model.File> listFile = fileMgr.GetModelList("prdguid='" + prdID + "'");
            _imgUrl = "https://tweebaa.com/" + listFile[0].fileurl;

            _model = mgr.GetModel(_prdGuid);


            // when product is shared out, the proid has two parts  prdGuid + "_" + shareGuid
            //int iPos = proid.IndexOf('_');
            //if (iPos != -1)
            //{
            //    _proid = proid.Substring(0, iPos);
            //}

            try
            {
                #region get product favorate status of current user.
                Guid prdGuid = new Guid(prdID);
                if (userGuid != null) {
                    _favorite = new Twee.Mgr.FavoriteMgr().Exists(prdGuid, (System.Guid)userGuid);
                }
                #endregion

                #region get review count
                int passCount = new Twee.Mgr.ReviewMgr().GetReviewCountByProid(prdID);//后台统计得出
                _passCount = passCount.ToString();
                #endregion

                #region 根据产品ID取供货表中已生效状态为4的唯一产品

                Twee.Model.proDetails details = new Twee.Mgr.proDetailsMgr().GetModelList(" state=" + (int)Twee.Comm.ConfigParamter.InventoryState.pass + " and proid='" + proid + "'").FirstOrDefault();
                if (details == null)
                {
                    Response.Write("<script type='text/javascript'>alert('No sales')</script>");
                    //Response.Redirect("~/product/prdSaleAll.aspx");
                    return;
                }
                string userid = details.userid.Trim();

                //取规格
                List<Twee.Model.proRules> rules = new Twee.Mgr.proRulesMgr().GetModelList(" proid='" + prdID + "' and userid='" + userid + "'");
                if (rules != null && rules.Count > 0)
                {
                    var supplyTypeId = rules.First().proruletitle.Value;
                    var supplyType = new Twee.Mgr.proDetailsMgr().GetSupplyTypeById(supplyTypeId);
                    _proRuleTitle = supplyType.prodetailType;

                    //取规格ID集
                    List<int> ruleIds = rules.Select(s => s.id).ToList();
                    string _ruleIds = string.Empty;
                    ruleIds.ForEach(s => { _ruleIds += "," + s; });
                    //取规格名称，过滤重复
                    List<string> ruleNames = rules.Select(s => s.prorule.Trim()).Distinct().ToList();

                    #region 拼接规格与颜色的JSON
                    StringBuilder jsonRuleAndColor = new StringBuilder();
                    foreach (var item in rules)
                    {
                        jsonRuleAndColor.AppendFormat(",{2}\"ruleid\":\"{0}\",\"color\":\"{1}\"{3}", item.id.ToString(), item.procolor, "{", "}");
                    }
                    if (jsonRuleAndColor.ToString().Length > 0)
                    {
                        _jsonRuleAndColor += "[" + jsonRuleAndColor.ToString().Substring(1) + "]";
                    }
                    #endregion

                    #region 生成规格 HTML
                    //<span onclick="changeColor(this)" ruleid="21" class="jsclick on">33</span>
                    StringBuilder html_ruleName = new StringBuilder();
                    int rule_index = 0;
                    foreach (string rule_name in ruleNames)
                    {
                        string temp_ruleidbyname = "";
                        rules.Where(s => s.prorule.Trim() == rule_name.Trim()).ToList().ForEach(s => { temp_ruleidbyname += "," + s.id; });
                        var temp_rules = rules.Where(s => s.prorule.Trim() == rule_name.Trim()).Select(s => s).ToList();
                        if (rule_index == 0) //第一个规格默认选中
                        {
                            html_ruleName.AppendFormat("<span onclick='_PreChangeRule(this)' class=\"jsclick on\" ruleids='{1}'>{0}</span>", rule_name, temp_ruleidbyname.Substring(1));
                            //加载该规格的所有颜色
                            StringBuilder temp_color_first = new StringBuilder();
                            foreach (var t_rule in temp_rules)
                            {
                                string t_color = string.Empty;
                                if (string.IsNullOrEmpty(t_rule.procolor) || t_rule.procolor == "无")
                                {
                                    t_color = "无";
                                }
                                if (t_rule.procolor == "#fff")
                                {
                                    //t_color = "white";
                                    temp_color_first.AppendFormat("<div class=\"selectColor\" onclick=\"_ChangeColor(this)\" ruleid='{1}'><div style=\" background:{0}; font:8px;border:solid 1px gray; text-align:center;\">{2}</div></div>", t_rule.procolor, t_rule.id, t_color);
                                }
                                else
                                {
                                    temp_color_first.AppendFormat("<div class=\"selectColor\" onclick=\"_PreChangeColor(this)\" ruleid='{1}'><div style=\" background:{0}; font:10px; text-align:center;\">{2}</div></div>", t_rule.procolor, t_rule.id, t_color);
                                }                               
                            }
                            _firstColor = temp_color_first.ToString();

                            //加载该规格下的库存
                            //var prdStoragList = new Twee.Mgr.PrdStoragMgr().GetModelList(" ruleid in (" + temp_ruleidbyname.Substring(1) + ")").ToList();
                            //if (prdStoragList != null && prdStoragList.Count > 0)
                            //{
                            //    _firstRuleStoreNum = prdStoragList.Select(s => s.number).Sum().ToString();
                            //}
                        }
                        else
                        {
                            html_ruleName.AppendFormat("<span onclick='_PreChangeRule(this)' ruleids='{1}'>{0}</span>", rule_name, temp_ruleidbyname.Substring(1));
                        }
                        rule_index++;
                    }
                    _ruleName = html_ruleName.ToString();
                    #endregion


                    #region 产品访问记录
                    /*
                    CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                    if (userGuid != null)
                    {
                        VistLog visit = new VistLog();
                        visit.prdID = prdID.ToString();
                        visit.userId = userGuid.ToString();
                        visit.addTime = DateTime.Now;
                        VistLogMgr visitMgr = new VistLogMgr();
                        visitMgr.Add(visit);
                    }*/
                    #endregion
                }

                #endregion


                
            }
            catch (Exception ex)
            {
                log.Error("预售页面日志：" + System.DateTime.Now.ToString("yyyy-MM-dd hhmmss") + "  错误：  " + ex.Message);
                Response.Clear();
                Response.Write("<script type='text/javascript'>alert('Sorry, the product waiting for uploading!');</script>");
            }

            #endregion


        }
    }
}