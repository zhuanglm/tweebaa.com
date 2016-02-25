using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Newtonsoft.Json;
using System.Text;

namespace TweebaaWebApp2.AjaxPages
{
    /// <summary>
    /// 规格和价格保存
    /// </summary>
    public partial class inventoryRuleSaveAjax : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isLogion = CheckLogion(out userGuid);
                if (isLogion == false)
                {
                    Response.Write("-1");
                    return;
                }
                else 
                {
                    string action = Request["action"];
                    if (string.IsNullOrEmpty(action)) {
                        Response.Write("-2");
                        return;
                    }
                    if (action == "saveRule") {
                        Response.Clear();
                        Response.Write(saveRule());
                        return;
                    }
                    if (action == "getPrices")
                    {
                        Response.Clear();
                        Response.Write(getPrices());
                        return;
                    }

                    if (action == "savePrices")
                    {
                        Response.Clear();
                        Response.Write(savePrices());
                        return;
                    }

                    if (action == "deleteRule")
                    {
                        Response.Clear();
                        Response.Write(deleteRule());
                        return;
                    }
                    
                }
            }
        }

        /// <summary>
        /// 保存规格
        /// </summary>
        /// <returns></returns>
        private string saveRule() {
            string proId = Request["proid"];
            string ruleid = Request["ruleid"];
            string rule = Request["rule"];
            string color = Request["color"];
            string barcode = Request["barcode"];
            string stock = Request["stock"];
            string prosku = Request["prosku"];
            string probulk = Request["probulk"];
            string proweight = Request["proweight"];
            string probox = Request["probox"];
            string prosize = Request["prosize"];
            string proboxweight = Request["proboxweight"];
            string protitleid = Request["protitleid"];

            Twee.Model.proRules ruleModel = new Twee.Model.proRules();
            ruleModel.barcode = barcode;
            ruleModel.probox = probox.ToString();
            ruleModel.proruletitle = protitleid._ToInt();
            ruleModel.prosize = prosize;
            ruleModel.prosku = prosku;
            ruleModel.proboxweight = proboxweight._ToDecimal();
            ruleModel.proweight = proweight.ToString();
            ruleModel.procolor = color;
            ruleModel.probulk = probulk.ToString();
            ruleModel.prostock = stock;
            ruleModel.prorule = rule;
            ruleModel.proid = proId;
            ruleModel.userid = userGuid.ToString();

            Twee.Mgr.proRulesMgr mgr = new Twee.Mgr.proRulesMgr();
            if (string.IsNullOrEmpty(ruleid))
            {
                return mgr.Add(ruleModel).ToString();
            }
            else 
            {
                ruleModel.id=int.Parse(ruleid.Trim());
                if (mgr.Update(ruleModel))
                    return ruleid;
                else
                    return "-3";
            }
        }

        /// <summary>
        /// 获取价格区间JSON
        /// </summary>
        /// <returns></returns>
        private string getPrices() {
            string ruleId =Request["ruleid"].Trim();
            Twee.Mgr.proPriceAreaMgr mgr = new Twee.Mgr.proPriceAreaMgr();
            List<Twee.Model.proPriceArea> list = new List<Twee.Model.proPriceArea>();
            list = mgr.GetModelList(" ruleid="+ruleId);
            if (list == null || list.Count == 0)
                return "-1"; //表示没有数据
            string json = JsonConvert.SerializeObject(list);
            return json;
        }

        /// <summary>
        /// 同时删除规格与该规格下的价格区间
        /// </summary>
        /// <returns></returns>
        private string deleteRule() {
            if (string.IsNullOrEmpty(Request["ruleids"]))
                return "-1";
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("delete from wn_prorules where id in ({0});", Request["ruleids"].Trim());
                sql.AppendFormat("delete from wn_proPriceArea where ruleid in ({0});", Request["ruleids"].Trim());
                Twee.Mgr.proRulesMgr mgr = new Twee.Mgr.proRulesMgr();
                mgr.ExecuteSql(sql.ToString());
                return "success";
            }
            catch (Exception ex) {
                return "error";
            }
        }


        /// <summary>
        /// 保存价格区间
        /// </summary>
        /// <returns></returns>
        private string savePrices() {
            if (string.IsNullOrEmpty(Request["ruleid"]))
                return "-1";
            if (string.IsNullOrEmpty(Request["proid"]))
                return "-1";
            if (string.IsNullOrEmpty(Request["pricearea"]))
                return "-1";

            string ruleid = Request["ruleid"].Trim();
            string proid = Request["proid"].Trim();
            string prices = Request["pricearea"];
            try
            {
                Twee.Mgr.proPriceAreaMgr mgr = new Twee.Mgr.proPriceAreaMgr();
                string deleteSql = "delete from  wn_proPriceArea where ruleid='"+ruleid+"'";
                mgr.DeleteListByRuleId(deleteSql);

                string[] pricesList = prices.Split(',');
                StringBuilder sql = new StringBuilder();
                int index = 0;
                foreach (var item in pricesList)
                {
                    string from = item.Split('_')[0];
                    string to = item.Split('_')[1];
                    string price = item.Split('_')[2];
                    if (index <= 10)
                    {
                        sql.Append("insert into wn_proPriceArea(ruleid,countfrom,countto,price,proid,userid,createtime)");
                        sql.Append(" values (");
                        sql.AppendFormat("'{0}',", ruleid);
                        sql.AppendFormat("{0},", from);
                        sql.AppendFormat("{0},", to);
                        sql.AppendFormat("{0},", price);
                        sql.AppendFormat("'{0}',", proid);
                        sql.AppendFormat("'{0}',", userGuid.ToString());
                        sql.AppendFormat("'{0}'", System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        sql.Append(");");
                    }
                    index++;
                }
                
                mgr.UpdateList(sql.ToString());
                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }
            
        }





    }
}