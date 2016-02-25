using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Data;

namespace TweebaaWebApp.Product
{
    public partial class preview : TweebaaWebApp.MasterPages.BasePage
    {

        private Guid? userGuid;

        public string proId = string.Empty;

        public string submitTime = string.Empty; //提交时间
        public string proName = string.Empty;
        public string proNum = string.Empty; //货号
        public string proRight = string.Empty; //产权信息
        public string smallNum = string.Empty; //最小起定量
        public string proStockout = string.Empty; //海外仓库
        public string proCaiZhi = string.Empty; //材质
        public string proAddress = string.Empty; //产品所在地
        public string proSend = string.Empty; //是否提供一件代发
        public string proSaleservice = string.Empty; //是否提供服务
        public string proSaleserviceinfo = string.Empty; //是否提供服务信息
        public string proExample = string.Empty; //样品
        public string proSendArea = string.Empty; //发货范围
        public string proStock = string.Empty; //库存情况
        public string proStockNum = string.Empty;
        public string proCreateTime = string.Empty;

        public string _ruleNameHtml = string.Empty;
        public string _stockHtml = string.Empty;
        public string _sukHtml = string.Empty;
        public string _blukHtml = string.Empty;
        public string _weightHtml = string.Empty;
        public string _boxHtml = string.Empty;
        public string _sizeHtml = string.Empty;
        public string _boxweightHtml = string.Empty;
        public string _priceHtml = string.Empty;
        public string content = string.Empty;
        public string pics = string.Empty;
        public string video = string.Empty;
        
        

        public Twee.Mgr.proDetailsMgr detailMgr = new Twee.Mgr.proDetailsMgr();
        public Twee.Mgr.proRulesMgr ruleMgr = new Twee.Mgr.proRulesMgr();
        public Twee.Mgr.proPriceMgr priceMgr = new Twee.Mgr.proPriceMgr();
        public Twee.Mgr.proDetailOtherMgr otherMgr = new Twee.Mgr.proDetailOtherMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("<script type='text/javascript'>alert('非法链接')</script>");
                return;
            }

            if (string.IsNullOrEmpty(Request["proid"]))
            {
                Response.Write("<script type='text/javascript'>alert('非法链接')</script>");
                return;
            }
            else
            {
                proId = Request["proid"].Trim();
            }
            BasicInfo();
            ListBind();
            PicBind();
        }

        #region 基本信息

        private void BasicInfo() {
            
            var detail = detailMgr.GetModel(proId,userGuid.ToString());
            var pro=new Twee.Mgr.PrdMgr().GetModel(Guid.Parse(proId));
            var other = otherMgr.GetModel(proId, userGuid.ToString());
            if (detail == null)
                return;
            if (pro == null)
                return;
            if (other == null)
                return;
             //submitTime = ; //提交时间
             proName =pro.name ;
             proNum =detail.promodelnum ; //货号
             proRight = GetDicVal(detail.proright._ObjToString(), Twee.Comm.ConfigParamter.RightType); //产权信息
             smallNum = detail.prosmallnum; //最小起定量
             proStockout = GetDicVal(other.prostockout._ObjToString(),Twee.Comm.ConfigParamter.ProStockout); //海外仓库
             proCaiZhi =other.procaizhi ; //材质
             proAddress = new Twee.Mgr.SendAreaMgr().GetModel(Guid.Parse( detail.proaddress)).areaName;//detail.proaddress,Twee.Comm.ConfigParamter.ProAddress); //产品所在地
             proSend = GetDicVal(other.prosend,Twee.Comm.ConfigParamter.ProSend); //是否提供一件代发
             proSaleservice = GetDicVal(other.prosaleservice,Twee.Comm.ConfigParamter.ProSaleservice); //是否提供服务
             proSaleserviceinfo =other.prosaleserviceinfo ; //是否提供服务信息
             proExample = GetDicVal(detail.proexample._ObjToString(), Twee.Comm.ConfigParamter.ProExample); //样品
             proSendArea =SendArea(other.prosendarea.ToString()) ; //发货范围
             proStock = GetDicVal(detail.prostock.Value._ObjToString(), Twee.Comm.ConfigParamter.ProStock); //库存情况
             proCreateTime = detail.createtime._ObjToString();
             proStockNum =detail.stocknum._ObjToString();
             content = other.procaizhicontent._ObjToString();
        }

        #endregion

        #region 列表
        

        private void ListBind() { 
            Twee.Mgr.proRulesMgr proRulesMgr = new Twee.Mgr.proRulesMgr();
            Twee.Mgr.proPriceMgr proPriceMgr = new Twee.Mgr.proPriceMgr();
            string where = " proid='" + proId + "' and userid='" +userGuid.ToString() +"'";
            var rules = proRulesMgr.GetEntityList(where);
            var prices = proPriceMgr.GetEntityList(where);
            if (rules == null)
                return;
            if (prices == null)
                return;
            
            //规格
            foreach (var item in rules) {
                var temp_price = prices.Where(s => s.prorule.Trim() == item.prorule.Trim()).ToList();
                var height = "";
                if (temp_price != null && temp_price.Count > 0)
                {
                    _priceHtml += "<dd style='height:auto; line-height:auto;'>" + GetPrices(temp_price) + "</dd>";
                    height = temp_price.Select(s => s.propricejson.Split(',').Length).Max() * 36 + "px"; //这里没办法得去算一下高度
                }
                _ruleNameHtml += "<dd style='height:"+height+"; line-height:auto;'>" + item.prorule._ObjToString() + "</dd>";
                _stockHtml += "<dd style='height:"+height+"; line-height:auto;'>" + item.prostock._ObjToString() + "</dd>";
                _sukHtml += "<dd style='height:" + height + "; line-height:auto;'>" + item.prosku._ObjToString() + "</dd>";
                _sizeHtml += "<dd style='height:" + height + "; line-height:auto;'>" + item.prosize._ObjToString() + "</dd>";
                _boxHtml += "<dd style='height:" + height + "; line-height:auto;'>" + item.probox._ObjToString() + "</dd>";
                _boxweightHtml += "<dd style='height:" + height + "; line-height:auto;'>" + item.proboxweight._ObjToString() + "</dd>";
                _blukHtml += "<dd style='height:" + height + "; line-height:auto;'>" + item.probulk._ObjToString() + "</dd>";
                _weightHtml += "<dd style='height:" + height + "; line-height:auto;'>" + item.proweight._ObjToString() + "</dd>";
                
            }
            
        }

        #endregion

        #region 图片列表与视频

        private void PicBind() {
            var picList = new Twee.Mgr.FileMgr().GetList(" prdguid='"+proId+"'");
            string host = Request.Url.Host;
            string port = Request.Url.Port._ObjToString();
            if (string.IsNullOrEmpty(port))
                host = host + "/";
            else
                host = host + ":" + port + "/";
            if (picList == null || picList.Tables[0].Rows.Count == 0)
                return;
            foreach (DataRow item in picList.Tables[0].Rows) {
                string picUrl=host+item["fileurl"]._ObjToString();
                string picName = item["filename"]._ObjToString();
                pics += "<li><img src='"+picUrl+"' width='68' height='68' alt='"+picName+"'></li>";
            }

            var prd = new Twee.Mgr.PrdMgr().GetModel(Guid.Parse(proId));
            video = host + prd.videoUrl;
        }

        #endregion

        


        #region 公共函数

        private static string GetDicVal(string k, Dictionary<int, string> dic) {
            if (string.IsNullOrEmpty(k) || null == dic || dic.Count == 0)
                return string.Empty;
            return dic.Where(s => s.Key.ToString() == k).Select(s => s.Value).FirstOrDefault();
        }

        private static string SendArea(string k) {
            string res = string.Empty;
            var array = k.Split('_').ToArray();
            foreach (var s in array) {
                res += "," + GetDicVal(s,Twee.Comm.ConfigParamter.ProSendArea);
            }
            if (!string.IsNullOrEmpty(res))
                return res.Substring(1);
            else
                return string.Empty;
        }

        private string GetPrices(List<Twee.Model.proPrice> list) {
            string res = string.Empty;
            foreach (var pric in list)
            {
                var arr = pric.propricejson.Split(',');
                foreach (var item in arr)
                {
                    var temp = item.Split('_');
                    if (temp.Length < 3)
                        continue;
                    res += "<span>从</span><b>" + temp[0]._ObjToString() + "</b><span>到</span><b>" + temp[1]._ObjToString() + "</b><span>￥</span><b>" + temp[2]._ObjToString() + "</b><br/>";
                }
            }
            return res;
        }

        #endregion



    }
}