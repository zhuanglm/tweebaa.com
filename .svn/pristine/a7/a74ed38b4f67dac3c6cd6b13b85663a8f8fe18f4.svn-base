using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Model;
using System.Text;

namespace TweebaaWebApp2.Mgr.Inventory
{
    public partial class InventoryReview : System.Web.UI.Page
    {
        public static Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();
        public static Twee.Mgr.PrdMgr prdMgr = new Twee.Mgr.PrdMgr();
        public static Twee.Mgr.CountryMgr areaMgr = new Twee.Mgr.CountryMgr();

        public string detail_id = string.Empty;
        public string pro_id = string.Empty;
        public string user_id = string.Empty;

        public string ph_ruleList = string.Empty;
        public string proCaiZhiContent = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (string.IsNullOrEmpty(Request["detailid"]))
                {
                    Response.Write("<script type='text/javascript'>alert('非法请求')</script>"); return;
                }
                
            }
            detail_id = Request["detailid"].Trim();
            var detailModel = new Twee.Mgr.proDetailsMgr().GetModel(int.Parse(detail_id));
            pro_id = detailModel.proid;
            user_id = detailModel.userid;

            hidProID.Value = pro_id;
            hidUserID.Value = user_id;
            hidDetailID.Value = detail_id;
            BindBasicInfo(detailModel);
            BindRuleAndPriceArea();
            proDetailOtherInfo();
        }

        #region 产品基本信息
        private void BindBasicInfo(Twee.Model.proDetails model)
        {
            var prd = prdMgr.GetModel(Guid.Parse(pro_id));
            var Cate = cateMgr.GetModel(prd.cateGuid);
            string proCate = "";
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

            labproName.Text = prd.name;
            labproType.Text = proCate;

            if (model.proaddress.Trim() == "-1")
                labAddress.Text = string.Empty;
            else
            {
                Country cc = areaMgr.GetModel(int.Parse(model.proaddress.Trim()));
                if (cc!=null)
                {
                    labAddress.Text = areaMgr.GetModel(int.Parse(model.proaddress.Trim())).country;
                }
                
            }
              

            labproRight.Text = GetConfigDicValue(Twee.Comm.ConfigParamter.RightType,model.proright.ToString());
            labExample.Text = GetConfigDicValue(Twee.Comm.ConfigParamter.ProExample, model.proexample.ToString());
            labproExampleInfo.Text = model.proexampleprice == null ? "" : "(￥" + model.proexampleprice.ToString()+")";
            labMin.Text = model.prosmallnum.ToString();
            labNum.Text = model.promodelnum.ToString();
            labStock.Text = GetConfigDicValue(Twee.Comm.ConfigParamter.ProStock, model.prostock.ToString());
            labStockNum.Text = model.stocknum == null ? "" : "  (生产周期：" + model.proexampleprice.ToString()+"天)";
        }

        private string GetConfigDicValue(Dictionary<int, string> dic, string keyVal) {
            return dic.Where(s => s.Key.ToString().Trim() == keyVal).Select(s => s.Value.Trim()).FirstOrDefault();
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
        #endregion

        #region 规格与价格区间
        private void BindRuleAndPriceArea()
        {
            //规格列表
            Twee.Mgr.proRulesMgr ruleMgr = new Twee.Mgr.proRulesMgr();
            List<Twee.Model.proRules> ruleList = ruleMgr.GetEntityList(" proid='"+pro_id+"' and userid='"+user_id+"'");
            if (ruleList == null || ruleList.Count == 0)
                return;
            //价格区间列表
            Twee.Mgr.proPriceAreaMgr priceMgr = new Twee.Mgr.proPriceAreaMgr();
            List<Twee.Model.proPriceArea> priceList = priceMgr.GetModelList(" proid='" + pro_id + "' and userid='" + user_id + "'");
            StringBuilder trString = new StringBuilder();
            foreach (var ruleItem in ruleList)
            {
                trString.Append("<tr>");
                trString.AppendFormat("<td>{0}</td>",ruleItem.prorule);
                trString.AppendFormat("<td><div style=' width:12px; height:12px; background-color:{0}' title='{1}'></div></td>", ruleItem.procolor,ruleItem.procolor);
                trString.AppendFormat("<td>{0}</td>", ruleItem.barcode);
                trString.AppendFormat("<td>{0}</td>", ruleItem.prostock);
                trString.AppendFormat("<td>{0}</td>", ruleItem.prosku);
                trString.AppendFormat("<td>{0}</td>", ruleItem.probulk);
                trString.AppendFormat("<td>{0}</td>", ruleItem.proweight);
                trString.AppendFormat("<td>{0}</td>", ruleItem.probox);
                trString.AppendFormat("<td>{0}</td>", ruleItem.prosize);
                trString.AppendFormat("<td>{0}</td>", ruleItem.proboxweight);
                trString.Append("</tr>");
                
                //价格区间
                trString.Append("<tr style=' background-color:#ededed;'>");
                trString.Append("<td align='right' valign='middle'>价格区间：</td>");
                trString.Append("<td colspan='9' align='left' valign='middle'>");

                var _area = priceList.Where(s => s.ruleid.ToString().Trim() == ruleItem.id.ToString().Trim())
                                               .Select(s => new { from = s.countfrom, to = s.countto, price = s.price }).ToList();
                foreach (var tem in _area)
                {
                    trString.AppendFormat("<div style='width:400px;border:1px solid gray; padding:2px; margin:2px;'>从：{0} 到：{1}  价格：{2} </div>",tem.from,tem.to,tem.price);
                }
                trString.Append("</td></tr>");
                
            }
            ph_ruleList = trString.ToString();

        } 
        #endregion

        #region 产品详情及仓储信息
        private void proDetailOtherInfo()
        {
            Twee.Mgr.proDetailOtherMgr mgr = new Twee.Mgr.proDetailOtherMgr();
            List<Twee.Model.proDetailOther> modelList = mgr.GetModelList(" proid='" + pro_id + "' and userid='" + user_id + "'");
            Twee.Model.proDetailOther model = null;
            if (modelList != null && modelList.Count > 0)
                model = modelList[0];
                if (model != null)
                {
                    labCaiZhi.Text = model.procaizhi;
                    proCaiZhiContent = HttpUtility.UrlPathEncode(model.procaizhicontent);
                    labDaiFa.Text = model.prosend;
                    labDaiFa.Text = GetConfigDicValue(Twee.Comm.ConfigParamter.ProSend, model.prosend.Trim().ToString());
                    string temp = "";
                    if (!string.IsNullOrEmpty(model.prosendarea))
                    {
                        string[] _sendarea = model.prosendarea.Split('_');
                        foreach (var str in _sendarea)
                        {
                            temp += "  " + GetConfigDicValue(Twee.Comm.ConfigParamter.ProSendArea, str.ToString());
                        }
                    }
                    labFaHuaArea.Text = temp;
                    labHaiWaiStock.Text = GetConfigDicValue(Twee.Comm.ConfigParamter.ProStockout, model.prostockout.Trim().ToString());
                    labHaiWaiStockInfo.Text = model.prostockoutinfo == null ? "" : "(" + model.prostockoutinfo + ")";
                    labService.Text = GetConfigDicValue(Twee.Comm.ConfigParamter.ProSaleservice, model.prosaleservice.Trim().ToString());
                    labServiceInfo.Text = model.prosaleserviceinfo == null ? "" : "(" + model.prosaleserviceinfo + ")";
                }
            } 
        #endregion

        /// <summary>
        /// 采纳该产品，更改proDetails表中这个用户的这个产品条记录的state为2，这个产品的其他用户记录state为3
        /// 并且在已采纳表中加入这条记录 
        /// 这里还必须加上一个验证，该产品的产品状态必须在  “推易吧终审中”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string proid=hidProID.Value;
            int Status = (int)Twee.Comm.ConfigParamter.PrdSate.tweeReview;
            //查询该产品的评审状态
            var proModel = new Twee.Mgr.PrdMgr().GetModel(Guid.Parse(proid));
            if (proModel == null)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('未能找到该产品，无法通过供货单');</script>");
                return;
            }
            int proStatus =(int)proModel.wnstat;
            if (Status != proStatus)
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('该产品没有进入推易吧终审，不能采纳供货单');</script>");
                //return;
            }

            string userid = hidUserID.Value;
            string detailid = hidDetailID.Value;
            Twee.Mgr.proDetailsMgr mgr = new Twee.Mgr.proDetailsMgr();
            string result = mgr.AcceptInventory(proid,userid,int.Parse(detailid));
            if (result == "1")
            {
                //var url = "Inventory/InventorySalePriceArea.aspx?proid=" + proid;
                //window.parent._addTab('供货评审', url);
                string scriptString = "<script type='text/javascript'>alert('成功采纳该供货单,跳转价格区间填写页面');";
                scriptString+="var url ='Inventory/InventorySalePriceArea.aspx?proid="+proid+"';";
                scriptString+="window.parent._addTab('供货销售价格区间', url);";
                scriptString += "</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", scriptString);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('采纳失败！');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string proid = hidProID.Value;
            string userid = hidUserID.Value;
            string detailid = hidDetailID.Value;
            Twee.Mgr.proDetailsMgr mgr = new Twee.Mgr.proDetailsMgr();
            if (mgr.UnAcceptInventory(detailid) > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "unaccept", "<script type='text/javascript'>alert('成功拒绝采纳该供货单');</script>");
            }
            else 
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('拒绝采纳该操作失败');</script>");
            }
        }

    }
}