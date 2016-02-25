using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Model;
using System.Web.UI.HtmlControls;
using System.Text;


namespace TweebaaWebApp.Product
{
    public partial class inventory : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
       // public static Twee.Mgr.SendAreaMgr areaMgr = new Twee.Mgr.SendAreaMgr();
        public static Twee.Mgr.CountryMgr areaMgr = new Twee.Mgr.CountryMgr();
        public static Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();
        public static Twee.Mgr.PrdMgr prdMgr = new Twee.Mgr.PrdMgr();

        public static Twee.Mgr.proDetailsMgr proDetailsMgr = new Twee.Mgr.proDetailsMgr();
        public static Twee.Mgr.proRulesMgr proRulesMgr = new Twee.Mgr.proRulesMgr();
        public static Twee.Mgr.proPriceMgr proPriceMgr = new Twee.Mgr.proPriceMgr();
        public static Twee.Mgr.proDetailOtherMgr otherMgr = new Twee.Mgr.proDetailOtherMgr();

        public List<Country> areaList = areaMgr.GetModelList("");

        public string proId = string.Empty;
        public string userId = string.Empty;
        public string proName = string.Empty;
        public string proCate = string.Empty;
        public string flow = string.Empty;//供货单流程节点名称   如：已采纳，未采纳
        public string edit_right_script = string.Empty;//供货单的修改权限控制JS,位于页面底部
        public string Barcode = string.Empty; //标识是否是填写条码还是其他的



        public string ph_ruletr = string.Empty;
        public string ph_priceArea = string.Empty;

        public string _submitBtn = string.Empty;
        public string _saveBtn = string.Empty;

        public string _tbRuleTrHtml = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isLogion = CheckLogion(out userGuid);
                if (isLogion == false)
                {
                    Response.Redirect("~/User/login.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(Request["proid"]))
                    return;

                proId = Request["proid"].Trim();
                var prd = prdMgr.GetModel(Guid.Parse(proId));
                proName = prd.name;
                var Cate = cateMgr.GetModel(prd.cateGuid);
                if (Cate == null)
                {
                    proCate = string.Empty;
                }
                else
                {
                    int? layer = Cate.layer;
                    if (null == layer)
                        proCate = string.Empty;
                    var list = GetCateList(Cate);
                    list.ForEach(s => { proCate += ">" + s.name; });
                    if (!string.IsNullOrEmpty(proCate))
                        proCate = proCate.Substring(1);
                }

                userId =userGuid.ToString();

                GetDetails(proId, userId);
                GetRules();
                GetOther();
            }

        }

        #region 公用函数
        Func<string, string, string> isRadioCheckedFuc = (key, val) =>
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            if (key == val)
                return "hRadio hRadio_Checked";
            else
                return string.Empty;
        };

        Func<string, string, string> ddlFuc = (k, v) =>
        {
            if (k == v)
                return "selected";
            else
                return string.Empty;
        };

        Func<string, string, string> checkFuc = (k, v) =>
        {
            if (k == v)
                return "checked";
            else
                return string.Empty;
        };
        #endregion

        #region 新产品基本信息

        private void GetDetails(string proid, string userid)
        {
            Twee.Model.proDetails detail = new proDetails();
            detail = proDetailsMgr.GetModel(proid, userid);

            #region 供货单走向状态信息
            if (detail !=null && detail.state != null)
            {
                flow = GetState(detail.state.ToString().Trim());
            }
            #endregion

            #region 主键
            HtmlGenericControl proDetailid = new HtmlGenericControl();
            StringBuilder detailidString = new StringBuilder();
            if (null == detail || string.IsNullOrEmpty(detail.id.ToString()))
                detailidString.AppendFormat("<input type='hidden' id='probaseid' style=' display:none;' value='{0}'></label>", string.Empty);
            else
                detailidString.AppendFormat("<input type='hidden' id='probaseid' style=' display:none;' value='{0}'></label>", detail.id.ToString());
            proDetailid.InnerHtml = detailidString.ToString();
            ph_prodetailid.Controls.Add(proDetailid);
            #endregion

            #region 产权信息
            HtmlGenericControl proRight = new HtmlGenericControl();
            StringBuilder radioString = new StringBuilder();
            string checkString = string.Empty;
            if (null != detail && !string.IsNullOrEmpty(detail.id.ToString()))
            {
                checkString = detail.proright.Value.ToString();
            }
            radioString.AppendFormat("<input name='proRight' type='radio' value='1'  /><label name='proRight' value='1'  class='{0}'>Self Owned</label>", isRadioCheckedFuc("1", checkString));
            radioString.AppendFormat("<input name='proRight' type='radio' value='2'  /><label name='proRight' value='2'  class='{0}'>Licensed</label>", isRadioCheckedFuc("2", checkString));
            radioString.AppendFormat("<input name='proRight' type='radio' value='3' /><label name='proRight' value='3'  class='{0}'>None</label>", isRadioCheckedFuc("3", checkString));

            proRight.InnerHtml = radioString.ToString();
            ph_proRight.Controls.Add(proRight);
            #endregion

            #region 产品所在地
            HtmlGenericControl proAddress = new HtmlGenericControl();
            Func<string, string, string> addressFuc = (k, v) =>
            {
                if (k == v)
                    return "selected";
                else
                    return string.Empty;
            };
            string seloption = string.Empty;
            if (null == detail || string.IsNullOrEmpty(detail.id.ToString()))
            {
                seloption += string.Format("<option value='-1' {0}>{1}</option>", addressFuc("-1", "-1"), "--please select--"); ;
            }
            else
            {
                seloption += string.Format("<option value='-1' {0}>{1}</option>", addressFuc("-1", detail.proaddress), "--please select--");
            }
            if (null != areaList && areaList.Count > 0)
            {
                foreach (var item in areaList)
                {
                    string temp = string.Empty;
                    if (detail != null)
                        temp = detail.proaddress;
                    seloption += string.Format("<option value={0} {2}>{1}</option>", item.id, item.country, addressFuc(item.id.ToString(), temp));
                }
            }
            proAddress.InnerHtml = seloption;
            ph_proAddress.Controls.Add(proAddress);
            #endregion

            #region 产品样品
            HtmlGenericControl proExample = new HtmlGenericControl();
            string checkExampleString = string.Empty;
            string proexampleprice_str = string.Empty;
            StringBuilder radioExampleString = new StringBuilder();
            if (null != detail && !string.IsNullOrEmpty(detail.id.ToString()))
            {
                checkExampleString = detail.proexample.Value.ToString();
                proexampleprice_str = detail.proexampleprice == null ? "" : detail.proexampleprice.Value.ToString();
            }

            radioExampleString.AppendFormat("<input name='proExample' type='radio' value='1'  /><label name='proExample' value='1' class='{0}'>Free Sample</label>", isRadioCheckedFuc("1", checkExampleString));
            radioExampleString.AppendFormat("<input name='proExample' type='radio' value='2'  /><label name='proExample' value='2' class='{0}'>Charged Sample</label><span class=\"hideInput\">$<input type=\"text\" id=\"proExamplePrice\" value='{1}' style=\"width:45px;\" isnum='true' /></span>", isRadioCheckedFuc("2", checkExampleString), proexampleprice_str);
            radioExampleString.AppendFormat("<input name='proExample' type='radio' value='3' /><label name='proExample' value='3' class='{0}'>Not provided</label>", isRadioCheckedFuc("3", checkExampleString));

            proExample.InnerHtml = radioExampleString.ToString();
            hp_proExample.Controls.Add(proExample);
            #endregion

            #region 最小定量与货号
            HtmlGenericControl prosmallNum = new HtmlGenericControl();
            string prosmall_str = string.Empty;
            if (null != detail && !string.IsNullOrEmpty(detail.id.ToString()))
            {
                prosmall_str = detail.prosmallnum.ToString();
            }
            string prosmallNumString = string.Format("<input type=\"text\" class=\"text\" id=\"smallNum\" isnum='true'  value='{0}' style=\"width:120px; padding-right: 50px;\" onkeyup=\"value=value.replace(/[^\\d.]/g,'')\">", prosmall_str);
            prosmallNum.InnerHtml = prosmallNumString;
            ph_smallNum.Controls.Add(prosmallNum);

            HtmlGenericControl proNum = new HtmlGenericControl();
            string proNum_str = string.Empty;
            if (null != detail && !string.IsNullOrEmpty(detail.id.ToString()))
            {
                proNum_str = detail.promodelnum.ToString();
            }
            string proNumString = string.Format("<input type=\"text\" id=\"proNum\" value='{0}' class=\"text\" style=\"width:120px; padding-right: 50px;\" >", proNum_str);
            proNum.InnerHtml = proNumString;
            ph_proNum.Controls.Add(proNum);
            #endregion

            #region 是否有库存
            HtmlGenericControl proStock = new HtmlGenericControl();
            string proStockString = string.Empty;
            string stocknum_str = string.Empty;
            StringBuilder radioStockString = new StringBuilder();
            if (null != detail && !string.IsNullOrEmpty(detail.id.ToString()))
            {
                proStockString = detail.prostock.Value.ToString();
                stocknum_str = detail.stocknum.ToString();
            }
            radioStockString.AppendFormat("<input name='stock' type='radio' value='1'  /><label name='stock'  value='1' class='{0}'>Yes</label>", isRadioCheckedFuc("1", proStockString));
            radioStockString.AppendFormat("<input name='stock' type='radio' value='2'  /><label name='stock'  value='2' class='{0}'>No</label>", isRadioCheckedFuc("2", proStockString));
            radioStockString.AppendFormat("<span class=\"hideInput\">Production lead time（day）<input type=\"text\" id=\"stockNum\" isnum='true'  value='{0}' style=\"width:65px;\"/></span>", stocknum_str);

            proStock.InnerHtml = radioStockString.ToString();
            ph_stock.Controls.Add(proStock);
            #endregion

            #region 提交与保存，条形码
            SubmitAndSave(detail);
            InputBarcode(detail);
            #endregion
        }

        #endregion

        #region 提交与保存按钮权限

        public void SubmitAndSave(Twee.Model.proDetails details) {
            if (null == details)
            {
                _submitBtn = "<a href=\"javascript:void(0)\" onclick=\"SendToServer('send')\" class=\"yulanbtn\">Send</a>";
                _saveBtn = "<a href=\"javascript:void(0)\" onclick=\"SendToServer('save')\" class=\"btn save-btn fr\">Save drafts</a>";
            }
            else
            {
                var state = details.state;
                if (state < 2 || state == null || state==3)
                {
                    _submitBtn = "<a href=\"javascript:void(0)\" onclick=\"SendToServer('send')\" class=\"yulanbtn\">Send</a>";
                    _saveBtn = "<a href=\"javascript:void(0)\" onclick=\"SendToServer('save')\" class=\"btn save-btn fr\">Save drafts</a>";
                }
            }
        }

        #endregion

        #region 规格表格编辑权限，以及条形码权限

        private void InputBarcode(Twee.Model.proDetails detail) 
        {
            if (detail == null || detail.state == null)
                return;
            int? state = detail.state;
            Barcode = state.Value.ToString();
            StringBuilder script = new StringBuilder();
            //表示已经通过评审
            if (state == (int)Twee.Comm.ConfigParamter.InventoryState.pass)
            {
                //将页面上DIV id为tbRuleOption的区域隐藏
                
                script.Append("<script  type='text/javascript'>");
                script.Append("$('#tbRuleOption').hide();");
                string kk = @"$('#tbRule').find('tr').each(function(){
                                            $(this).find('img').removeAttr('onclick');
                                            $(this).find(""div[class='color']"").removeAttr('onclick');
                                            $(this).find(""input[type='text']"").attr('disabled','disabled');
                                            $(this).find(""select"").attr('disabled','disabled');
                                            $(this).find(""input[class='barcode']"").removeAttr('disabled');
                                            $(this).find(""input[class='price']"").css('display','none');
                                            $(this).find(""input[class='price']"").attr('disabled','disabled');
                                     });";
                script.Append(kk);
                script.Append("</script>");
            }
            if (state > (int)Twee.Comm.ConfigParamter.InventoryState.pass)
            {
                script.Append("<script  type='text/javascript'>");
                script.Append("$('#tbRuleOption').hide();");
                string kk = @"$('#tbRule').find('tr').each(function(){
                                            $(this).find('img').removeAttr('onclick');
                                            $(this).find(""div[class='color']"").removeAttr('onclick');
                                            $(this).find(""input[type='text']"").attr('disabled','disabled');
                                            $(this).find(""select"").attr('disabled','disabled');
                                            $(this).find(""input[type='button']"").css('display','none');
                                            $(this).find(""input[class='price']"").attr('disabled','disabled');
                                            $(this).find(""input[type='button']"").attr('disabled','disabled');
                                     });";
                script.Append(kk);
                script.Append("</script>");
            }
            edit_right_script = script.ToString();
        }

        #endregion

        #region 规格及包装及价格区间

        private void GetRules()
        {
            List<Twee.Model.proRules> list = new List<proRules>();
            list = proRulesMgr.GetEntityList(" proid='" + proId + "' and userid='" + userId + "'");

            #region 规格下拉框
            string ruleTitle = string.Empty;
            if (null != list && list.Count > 0)
                ruleTitle = list.Select(s => s.proruletitle).FirstOrDefault().ToString();
            //string ruleTitle = list.Select(s => s.proruletitle).FirstOrDefault().ToString();

            var supplyTypeList = new Twee.Mgr.proDetailsMgr().GetSupplyTypeList();

            StringBuilder ddl = new StringBuilder();
            if (supplyTypeList != null && supplyTypeList.Count > 0)
            {
                foreach (var item in supplyTypeList)
                {
                    ddl.AppendFormat("<option {0} value=\"{1}\">{2}</option>", ddlFuc(item.id.ToString(), ruleTitle), item.id.ToString(), item.prodetailType);
                    //ddl.AppendFormat("<option {0} value=\"1\">Item#/SKU#</option>", ddlFuc("1", ruleTitle));
                    //ddl.AppendFormat("<option {0} value=\"2\">Size</option>", ddlFuc("2", ruleTitle));
                    //ddl.AppendFormat("<option {0} value=\"3\">Others</option>", ddlFuc("3", ruleTitle));
                }
            }

            HtmlGenericControl ddlGentor = new HtmlGenericControl();
            ddlGentor.InnerHtml = ddl.ToString();
            ph_ruleddl.Controls.Add(ddlGentor);
            #endregion

            

            #region 规格文本框
            string textRule = string.Empty;
            if (null != list && list.Count != 0)
            {   
                //规格名称
                var RuleNameList = list.Select(s => s.prorule.Trim()).Distinct().ToList();
                for (int i = 0; i < RuleNameList.Count; i++)
                {
                    textRule += "<div class='js-eg-box' id='rule_" + i.ToString() + "'>";
                    textRule += "<input type=\"text\" id='ruleitem_" + i.ToString() + "' onkeyup='RuleText(this)' class=\"txt\"  value='" + list[i].prorule + "'  onfocus=\"if(this.value=='example：10*10*10cm')this.value='';this.style.color='#333'\" onblur=\"if(this.value==''){this.value='example：10*10*10cm';this.style.color='#ccc'}\"  />";
                    textRule += "<a href='javascript:void(0)' onclick='DeleteProRule(" + i.ToString() + ")'>delete</a>";
                    textRule += "</div>";
                }
            }
            HtmlGenericControl textGentor = new HtmlGenericControl();
            textGentor.InnerHtml = textRule;
            hp_ruleArea.Controls.Add(textGentor);
            #endregion


            #region 规格表格
            //<div class='color' style='width:12px; height:12px; float:left; cursor:pointer; margin:2px; background:" + aaa + "' onclick=deleteColor(this) title='delete color'></div>

            if (list != null && list.Count > 0) 
            {
                int index = 0;
                //规格名称
                var RuleNameList = list.Select(s => s.prorule.Trim()).Distinct().ToList();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (var name in RuleNameList) {
                    dic.Add(name, name);
                }
                
                foreach (var item in list) {
                    var trItem = "<tr id='trrule'>";
                    //trItem += "<td class=\"w120\"><input type='text' value='10*10*10cm' id='proruletitle' tips='-1' readonly='readonly' style='border:0px;' /></td>";
                    trItem += "<td><input type='checkbox' class='chk' value='"+item.id+"'/></td>";
                    trItem += "<td>" + GenerateSelectControl(dic,item.prorule.Trim()) + "</td>";
                    trItem += "<td><input type='text' class='procolor' id=ruleitemtext_" + index + " style='display:none;' value='"+item.procolor+"' /><div class='color' style='width:12px; height:12px; float:left; cursor:pointer; margin:2px; background:" + item.procolor + "' onclick=deleteColor(this) title='delete color'></div><a style=\"border:0;margin:0 0 0 3px\" align=\"absmiddle\" ><img style='cursor:pointer;' id=ruleitemimg_" + index + " src='../Images/color.png'/ onclick=iColorShow('ruleitemtext_" + index + "','ruleitemimg_" + index + "') />&nbsp;</a></td>";
                    trItem += "<td><input type=\"text\" class='barcode'  value='"+item.barcode+"'/></td>";
                    trItem += "<td><input type=\"text\" class='stock' value='"+item.prostock+"' /></td>";
                    trItem += "<td><input type=\"text\" class='prosku' value='" + item.prosku + "' /></td>";
                    trItem += "<td><input type=\"text\" class='probulk'  value='" + item.probulk + "' /></td>";
                    trItem += "<td><input type=\"text\"  class='proweight'  value='" + item.proweight + "' /></td>";
                    trItem += "<td><input type=\"text\"  class='probox'  value='" + item.probox + "' /></td>";
                    trItem += "<td><input type=\"text\" class='prosize' value='" + item.prosize + "' /></td>";
                    trItem += "<td><input type=\"text\"  class='proboxweight'  value='" + item.proboxweight + "' /></td>";
                    trItem += "<td><input type='button' style='cursor:pointer;' value='save' onclick='saveRule(this)' /></td>";
                    trItem += "<td><input type='button' style='cursor:pointer;' value='range' class='price' onclick='openPrice(this)'  /></td>";
                    trItem += "</tr>";
                    index++;
                    _tbRuleTrHtml += trItem;
                }
            }

            #endregion

            #region 规格表格
            //string trRule = string.Empty;
            //if (list != null && list.Count > 0)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        trRule += "<tr id='trrule_" + i.ToString() + "'>";
            //        trRule += "<td class=\"w120\"><input type='text' value='" + list[i].prorule.ToString() + "' id='proruletitle' tips='" + list[i].id.ToString() + "'  readonly='readonly' style='border:0px;' /></td>";
            //        trRule += "<td class=\"kucun w80\"><input type=\"text\" class='stock' value='" + list[i].prostock.ToString() + "' isnum='true'  /></td>";
            //        trRule += "<td class=\"sku w120\"><input type=\"text\" class='prosku' value='" + list[i].prosku.ToString() + "' /></td>";
            //        trRule += "<td class=\"w80\"><input type=\"text\" class='probulk' value='" + list[i].probulk.ToString() + "' isnum='true'  /></td>";
            //        trRule += "<td class=\"w80\"><input type=\"text\"  class='proweight' value='" + list[i].proweight.ToString() + "' isnum='true'  /></td>";
            //        trRule += "<td class=\"w75\"><input type=\"text\"  class='probox' value='" + list[i].probox.ToString() + "' isnum='true'  /></td>";
            //        trRule += "<td class=\"w120\"><input type=\"text\" class='prosize' value='" + list[i].prosize.ToString() + "'   /></td>";
            //        trRule += "<td class=\"kg\"><input type=\"text\"  class='proboxweight' value='" + list[i].proboxweight.ToString() + "' isnum='true'  /></td>";
            //        trRule += "</tr>";
            //    }
            //}
            //ph_ruletr = trRule;
            //// HtmlGenericControl trGentor = new HtmlGenericControl();
            ////trGentor.TagName = "span style='display:none;'";
            ////trGentor.InnerHtml = trRule;
            ////ph_ruletr.Controls.Add(trGentor);
            #endregion

            #region 价格区间
            //string price = string.Empty;
            //List<Twee.Model.proPrice> priceList = new List<proPrice>();
            //priceList = new Twee.Mgr.proPriceMgr().GetEntityList(" proid='" + proId + "' and userid='" + userId + "' ");
            //if (null != priceList && priceList.Count != 0)
            //{
            //    for (int i = 0; i < priceList.Count; i++)
            //    {
            //        price += "<tr id='prrule_" + i.ToString() + "'>";
            //        price += "<td class=\"w120\"><input type='text' value='" + priceList[i].prorule.ToString() + "' id='proruletitle' tips='" + priceList[i].id.ToString() + "'  class='t' readonly='readonly' style='border:0px;' /></td>";
            //        price += "<td class=\"w120 price\"><input type=\"text\" id='suggest' value='" + priceList[i].prosuggestprice.ToString() + "' class=\"livetxt\" placeholder=\"数量\" isnum='true' /></td>";
            //        price += "<td class=\"qujian\">";
            //        price += "<dl>";
            //        string[] priceArea = priceList[i].propricejson.Split(',');
            //        int _index = 0;
            //        foreach (string area in priceArea)
            //        {
            //            var priceval = area.Split('_');
            //            if (_index == 0)
            //                price += "<dd>从<input type=\"text\" id='pricefrom' value='" + priceval[0] + "' class=\"livetxt\" placeholder=\"数量\" isnum='true'  />到<input type=\"text\" id='priceto' value='" + priceval[1] + "' class=\"livetxt\" placeholder=\"数量\" isnum='true'  />$<input type=\"text\" id='price' value='" + priceval[2] + "' class=\"livetxt\" placeholder=\"价格\" isnum='true'  /> <a  class=\"add-eg l\"  onclick=AddPriceArea(this)>增加</a></dd>";
            //            else
            //                price += "<dd>从<input type=\"text\" id='pricefrom' value='" + priceval[0] + "' class=\"livetxt\" placeholder=\"数量\" isnum='true' />到<input type=\"text\" id='priceto' value='" + priceval[1] + "' class=\"livetxt\" placeholder=\"数量\" isnum='true'  />$<input type=\"text\" id='price' value='" + priceval[2] + "' class=\"livetxt\" placeholder=\"价格\" isnum='true' /><a href=\"#\" class=\"del-parent l\">删除</a></dd>";
            //            _index++;
            //        }
            //        price += "</dl>";
            //        price += "</td>";
            //        price += "</tr>";
            //    }
            //}
            //ph_priceArea = price;
            ////HtmlGenericControl priceGentor = new HtmlGenericControl();
            ////priceGentor.TagName = "span style='display:none;'";
            ////priceGentor.InnerHtml = price;
            ////ph_priceArea.Controls.Add(priceGentor);
            #endregion



        }

        #endregion

        #region  产品详情以及仓储信息
        public static string proOtherId = string.Empty;
        public static string proCaiZhi = string.Empty;
        public static string proCaiZhiContent = string.Empty;

        private void GetOther()
        {
            Twee.Model.proDetailOther other = new proDetailOther();
            var kc = otherMgr.GetEntityList(" proid='" + proId + "' and userid='" + userId + "'");
            if (kc != null)
            {
                other = kc.FirstOrDefault();
                proOtherId = other.id.ToString();
                proCaiZhi = other.procaizhi.ToString();
                proCaiZhiContent = Microsoft.JScript.GlobalObject.unescape(other.procaizhicontent);
            }

            #region 一件代发
            HtmlGenericControl prosend = new HtmlGenericControl();
            string checkString = string.Empty;
            if (other != null && other.id > 0)
                checkString = other.prosend.ToString();
            StringBuilder sendString = new StringBuilder();
            sendString.AppendFormat("<input name='prosend' type='radio' value='1'  /><label name='prosend' value='1'  class='{0}'>Provide</label>", isRadioCheckedFuc("1", checkString));
            sendString.AppendFormat("<input name='prosend' type='radio' value='2'  /><label name='prosend' value='2' class='{0}'>Not provided</label>", isRadioCheckedFuc("2", checkString));
            prosend.InnerHtml = sendString.ToString();
            ph_proSend.Controls.Add(prosend);
            #endregion

            #region 发货范围
            HtmlGenericControl sendarea = new HtmlGenericControl();
            StringBuilder sendareaString = new StringBuilder();
            string prosendarea_str = string.Empty;
            if (other != null && other.id > 0)
                prosendarea_str = other.prosendarea.ToString();

            Func<string, string, string> labChk = (k, v) =>
            {
                if (string.IsNullOrEmpty(k) || string.IsNullOrEmpty(v))
                    return string.Empty;
                if (k == v)
                    return "checkbox checked";
                else
                    return "checkbox";
            };

            Func<string, string, string> _chk = (k, v) =>
            {
                string chkString = string.Empty;
                var temp = v.Split('_');
                foreach (string str in temp)
                {
                    if (k == str)
                    {
                        chkString = "checked";
                        break;
                    }
                }
                return chkString;
            };
            sendareaString.AppendFormat("<input type=\"checkbox\" value=\"1\"  {0}   style=\"display: none;\"><label  class=\"checkbox\" >China </label>", _chk("1", prosendarea_str));
            sendareaString.AppendFormat("<input type=\"checkbox\" value=\"2\"  {0}   style=\"display: none;\"><label  class=\"checkbox\" >Worldwide </label>", _chk("2", prosendarea_str));
            sendareaString.AppendFormat("<input type=\"checkbox\" value=\"3\"  {0}   style=\"display: none;\"><label  class=\"checkbox\" >North America </label>", _chk("3", prosendarea_str));
            sendareaString.AppendFormat("<input type=\"checkbox\" value=\"4\"  {0}   style=\"display: none;\"><label  class=\"checkbox\" >Australia </label>", _chk("4", prosendarea_str));
            sendareaString.AppendFormat("<input type=\"checkbox\" value=\"5\"  {0}   style=\"display: none;\"><label  class=\"checkbox\" >Asia </label>", _chk("5", prosendarea_str));
            sendarea.InnerHtml = sendareaString.ToString();
            ph_sendArea.Controls.Add(sendarea);
            #endregion

            #region 海外仓库
            StringBuilder stockout = new StringBuilder();
            string stockout_str = string.Empty;
            string prostockoutinfo_str = string.Empty;
            if (other != null && other.id > 0)
            {
                stockout_str = other.prostockout.ToString().Trim();
                prostockoutinfo_str = other.prostockoutinfo.ToString().Trim();
            }
            stockout.AppendFormat("<input name=\"prostockout\" type=\"radio\" value=\"1\"   style=\"display: none;\"><label name=\"prostockout\" value=\"1\" class=\"{0}\">Provide</label>", isRadioCheckedFuc("1", stockout_str));
            stockout.AppendFormat("<input type=\"text\" id=\"prostockoutinfo\" value='{0}'   class=\"jsinput\"/>", prostockoutinfo_str);
            stockout.AppendFormat("<input name=\"prostockout\" type=\"radio\" value=\"2\"  style=\"display: none;\"><label name=\"prostockout\" value=\"2\" class=\"{0}\">Not Provided</label>", isRadioCheckedFuc("2", stockout_str));
            HtmlGenericControl stockoutControl = new HtmlGenericControl();
            stockoutControl.InnerHtml = stockout.ToString();
            ph_outStock.Controls.Add(stockoutControl);
            #endregion

            #region 售后服务
            StringBuilder saleservice = new StringBuilder();
            string saleservice_str = string.Empty;
            string saleserviceinfo_str = string.Empty;
            if (other != null && other.id > 0)
            {
                saleservice_str = other.prosaleservice.ToString().Trim();
                saleserviceinfo_str = other.prosaleserviceinfo.ToString().Trim();
            }
            saleservice.AppendFormat("<input name=\"prosaleservice\" type=\"radio\" value=\"1\"   style=\"display: none;\"><label name=\"prosaleservice\" value=\"1\" class=\"{0}\">Provide</label>", isRadioCheckedFuc("1", saleservice_str));
            saleservice.AppendFormat("<input type=\"text\" id=\"prosaleserviceinfo\" value='{0}'   class=\"jsinput\"/>", saleserviceinfo_str);
            saleservice.AppendFormat("<input name=\"prosaleservice\" type=\"radio\" value=\"2\"  style=\"display: none;\"><label name=\"prosaleservice\" value=\"2\" class=\"{0}\">Not Provide</label>", isRadioCheckedFuc("2", saleservice_str));
            HtmlGenericControl saleserviceControl = new HtmlGenericControl();
            saleserviceControl.InnerHtml = saleservice.ToString();
            ph_saleservice.Controls.Add(saleserviceControl);
            #endregion

        }

        #endregion

        /// <summary>
        /// 生成选中下拉框
        /// </summary>
        /// <param name="itemDic"></param>
        /// <param name="selectedKey"></param>
        /// <returns></returns>
        private string GenerateSelectControl(Dictionary<string, string> itemDic, string selectedKey) {
            StringBuilder select = new StringBuilder();
            select.Append("<select style='width:85px;' class='ruleSel'>");
            foreach (var item in itemDic) {
                string selected=string.Empty;
                if(item.Key.Trim()==selectedKey)
                    selected="selected";
                select.AppendFormat("<option value='{0}' {1}>{2}</option>",item.Key.Trim(),selected,item.Value);
            }
            select.Append("</select>");
            return select.ToString();
        }

        private List<Twee.Model.PrdCate> GetCateList(Twee.Model.PrdCate model)
        {
            List<Twee.Model.PrdCate> list = new List<PrdCate>();
            Guid guid = model.guid;
            int? currentLayer = model.layer;
            string currentName = model.name;
            Guid tempGuid = model.prtGuid;
            list.Add(model);
            while (currentLayer > 0)
            {
                currentLayer = currentLayer - 1;
                var prtModel = cateMgr.GetModel(tempGuid);
                list.Add(prtModel);
                tempGuid = prtModel.prtGuid;
            }
            list.Reverse();
            return list;
        }

        public static string GetState(string keyVal)
        {
            var dic = Twee.Comm.ConfigParamter.InventoryStateConfig;
            return dic.Where(s => s.Key.ToString() == keyVal.Trim()).Select(s => s.Value.Trim()).FirstOrDefault();
        }

        public static string IsChecked(string key, string value)
        {
            if (key == value)
                return "checked";
            else
                return string.Empty;
        }
    }
}