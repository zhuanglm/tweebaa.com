using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using System.Collections;

namespace TweebaaWebApp.Mgr.Inventory
{
    public partial class InventorySalePriceArea : System.Web.UI.Page
    {
        public string pro_id = string.Empty;
        public string ph_ruleList = string.Empty;
        public string ph_saleList = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request["proid"]))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('非法链接');</script>");
                    return;
                }
                else
                {
                    pro_id = Request["proid"].Trim();
                    hid_proid.Value = pro_id;
                }
                LoadInventoryRuleAndPriceArea();
            }
           
        }

        private void LoadInventoryRuleAndPriceArea()
        {
            Twee.Mgr.proDetailsMgr DetailMgr = new Twee.Mgr.proDetailsMgr();
            var detailList = DetailMgr.GetModelList(" proid='" + pro_id + "' and state='" + (int)Twee.Comm.ConfigParamter.InventoryState.pass + "'");
            if (detailList == null || detailList.Count == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('该产品并没有被采纳，不能填写销售价格区间！');</script>");
                return;
            }
            if (detailList.Count > 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('数据有误，该产品存在多条已采纳记录，请检查数据正确性！');</script>");
                return;
            }

            Twee.Model.proDetails model = detailList[0];
            //得到供货商ID
            string user_id = model.userid;
            //得到该供货商该产品的规格信息
            Twee.Mgr.proRulesMgr ruleMgr = new Twee.Mgr.proRulesMgr();
            List<Twee.Model.proRules> ruleList = ruleMgr.GetEntityList(" proid='" + pro_id + "' and userid='" + user_id + "'");
            if (ruleList == null || ruleList.Count == 0)
                return;


            #region 供货商的规格以及价格区间
            //供货商价格区间列表
            Twee.Mgr.proPriceAreaMgr priceMgr = new Twee.Mgr.proPriceAreaMgr();
            List<Twee.Model.proPriceArea> priceList = priceMgr.GetModelList(" proid='" + pro_id + "' and userid='" + user_id + "'");
            //供货商表格
            StringBuilder trString = new StringBuilder();
            //销售表格
            StringBuilder saleString = new StringBuilder();

            //销售价格区间列表
            List<string> _ruleids = ruleList.Select(s => s.id.ToString().Trim()).Distinct().ToList();
            string _tempRuleids = "";
            _ruleids.ForEach(s => { _tempRuleids += "," + s; });
            Twee.Mgr.PrdPriceMgr pMgr = new Twee.Mgr.PrdPriceMgr();
            var pricelistModel = pMgr.GetModelList(" ruleid in ("+_tempRuleids.Substring(1)+")");

            foreach (var ruleItem in ruleList)
            {
                trString.Append("<tr>");
                trString.AppendFormat("<td>{0}</td>", ruleItem.prorule);
                trString.AppendFormat("<td><div style=' width:12px; height:12px; background-color:{0}' title='{1}'></div></td>", ruleItem.procolor, ruleItem.procolor);
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


                #region 供货商提供的价格区间
                trString.Append("<div style=' width:350px; float:left;margin-right:5px;'>");
                trString.Append("<table style=' width:350px;'><tr><td style='font-weight:bold;'>供货商提供的价格区间</td></tr>");
                foreach (var tem in _area)
                {
                    trString.AppendFormat("<tr><td>从：{0} 到：{1}  价格：{2} </td></tr>", tem.from, tem.to, tem.price);
                }
                trString.Append("</table>");
                trString.Append("</div>"); 
                #endregion


                #region 填写销售价格区间
                trString.Append("<table class='tbSalePrice' style=' width:350px; margin-left:5px;' ruleid='" + ruleItem.id.ToString().Trim() + "'>");
                trString.Append("<tr class='title'><td style='font-weight:bold;'>添加销售价格区间&nbsp;<a href='javascript:void(0)' onclick='addPriceArea(this)' style='cursor:pointer;'>增加</a></td></tr>");

                var rule_price = pricelistModel.Where(s => s.ruleid.Value.ToString().Trim() == ruleItem.id.ToString().Trim()).ToList();
                if (rule_price == null || rule_price.Count == 0)
                {
                    trString.Append("<tr><td class='area'>");
                    trString.Append("从：<input type='text'  class='from' isnum='true' />");
                    trString.Append("到：<input type='text'  class='to' isnum='true' />");
                    trString.Append("价格：<input type='text' class='price' isnum='true' /> &nbsp;<a href='javascript:void(0)' onclick='deletePriceArea(this)' style='cursor:pointer;'>删除</a>");
                    trString.Append("</td></tr>");
                }
                else
                {
                    foreach (var p in rule_price)
                    {
                        trString.Append("<tr><td class='area'>");
                        trString.Append("从：<input type='text'  class='from' isnum='true' value='"+p.p1+"'/>");
                        trString.Append("到：<input type='text'  class='to' isnum='true' value='"+p.p2+"'/>");
                        trString.Append("价格：<input type='text' class='price' isnum='true' value='" + p.price + "' /> &nbsp;<a href='javascript:void(0)' onclick='deletePriceArea(this)' style='cursor:pointer;'>删除</a>");
                        trString.Append("</td></tr>");
                    }
                }
               
                
                trString.Append("</table>"); 
                #endregion

                trString.Append("</td></tr>");
                
            }
            ph_ruleList = trString.ToString();
            #endregion



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            pro_id = hid_proid.Value.Trim();
            string xmlString = hidPriceAreaXml.Value;
            if (string.IsNullOrEmpty(xmlString))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('销售价格区间录入有误，请检查！');</script>");
                return;
            }
// <tb>
//  <tr ruleid="34" from="12" to="12" price="23" />
//  <tr ruleid="34" from="23" to="22" price="223" />
//  <tr ruleid="35" from="33" to="332" price="23" />
//  <tr ruleid="35" from="232" to="23" price="2311" />
//</tb>
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            //取所有的规格ID
            XmlNodeList Nodes = xmlDoc.SelectNodes("/tb/tr");
            List<string> ruleIdList = new List<string>();
            if (Nodes == null || Nodes.Count == 0)
                return;

            StringBuilder insertSql = new StringBuilder ();
            
            foreach (XmlNode node in Nodes) {
                string ruleid = node.Attributes["ruleid"].Value;
                string from = node.Attributes["from"].Value;
                string to = node.Attributes["to"].Value;
                string price = node.Attributes["price"].Value;
                ruleIdList.Add(ruleid);
                insertSql.AppendFormat("insert into wn_prdprice (guid,prdguid,edttime,p1,p2,price,ruleid)");
                insertSql.AppendFormat(" values ('{0}','{1}','{2}',{3},{4},{5},{6});",Guid.NewGuid(),pro_id,System.DateTime.Now,from,to,price,ruleid);
            }
            string deleteSql = string.Empty;
            List<string> temp = ruleIdList.Distinct().Select(s=>s.Trim()).ToList();
            string ids=string.Empty;
            temp.ForEach(s => { ids += "," + s; });
            if (ids.Length > 0)
            {
                 deleteSql += "delete from wn_prdprice where ruleid in ("+ids.Substring(1)+");";
            }

            string allSql = deleteSql + insertSql.ToString();
            ArrayList sql_list = new ArrayList();
            sql_list.Add(allSql);
            try
            {
                Twee.Comm.DbHelperSQL.ExecuteSqlTran(sql_list);
                LoadInventoryRuleAndPriceArea();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('成功保存销售价格区间！');</script>");
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "accept", "<script type='text/javascript'>alert('数据保存失败，请检查！');</script>");
            }
            

        }


        


    }
}