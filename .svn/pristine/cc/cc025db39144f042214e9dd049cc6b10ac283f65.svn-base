using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using Twee.Comm;
using System.Configuration;
using Twee.Model;

namespace TweebaaWebApp.Home
{
    public partial class SupplyCheckList : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
        private static int pageSize = 20;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Redirect ("~/User/login.aspx");
                return;
            }
            this.AspNetPager1.CustomInfoHTML = string.Format("The current page{0}/{1} {2}records {3} record per page ", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, this.AspNetPager1.PageSize });
            if (!IsPostBack) {
                Bind();
            }
        }

        private void Bind() {
            Twee.Mgr.CountryMgr areaMgr = new Twee.Mgr.CountryMgr();
            string state = hidstate.Value;
            string _startTime = startTime.Value;
            string _endTime = endTime.Value;
            List<Twee.Model.proDetails> detailList = GetProDetailList(state,_startTime,_endTime);
            List<Twee.Model.SupplyCheckListQueryModel> queryList = new List<Twee.Model.SupplyCheckListQueryModel>();
            foreach (var item in detailList)
            {
                Twee.Model.SupplyCheckListQueryModel model = new Twee.Model.SupplyCheckListQueryModel();
                model.promodelnum = item.promodelnum._ObjToString();
                Country ctry = areaMgr.GetModel(int.Parse(item.proaddress));
                model.proaddress = "";
                if (ctry!=null)
                {
                    model.proaddress = ctry.country;
                }
               
                model.proid = item.proid._ObjToString();
                model.state = GetState(item.state._ObjToString());
                model.prosmallnum = item.prosmallnum._ObjToString();
                model.createtime = item.createtime._DateTimeToString();
                Twee.Mgr.PrdMgr prdMgr = new Twee.Mgr.PrdMgr();
                var prd = prdMgr.GetModel(Guid.Parse(item.proid));
                if (null == prd)
                {
                    model.proname = string.Empty;
                    model.imgsrc = string.Empty;
                }
                else
                {
                    Twee.Mgr.FileMgr file=new Twee.Mgr.FileMgr ();
                    var fileModel=file.GetModelList(" prdGuid='"+item.proid+"' and idx=0").FirstOrDefault();
                    model.proname = prd.name;
                    if (fileModel!=null)
                    {
                        model.imgsrc = ConfigurationManager.AppSettings["prdImgDomain"] + fileModel.fileurl.Replace("big","small");
                    }                    
                }
                Twee.Mgr.proRulesMgr ruleMgr = new Twee.Mgr.proRulesMgr();
                var ruleList = ruleMgr.GetEntityList(" proid='"+item.proid+"' and userid='"+userGuid.ToString()+"'");
                string ruleids = string.Empty;
                ruleList.Select(s => s.id).Distinct().ToList().ForEach(s =>
                {
                    ruleids += "," + s;
                });
                if (ruleids.Length > 0)
                {
                    var priceArea = new Twee.Mgr.proPriceAreaMgr().GetModelList(" ruleid in (" + ruleids.Substring(1) + ");");
                    if (priceArea != null && priceArea.Count > 0)
                    {
                        decimal minPrice = priceArea.Select(s => s.price.Value).Min();
                        decimal maxPrice = priceArea.Select(s => s.price.Value).Max();
                        model.minprice = minPrice.ToString();
                        model.maxprice = maxPrice.ToString();
                    }
                }
                

                queryList.Add(model);
            }

            repGrid.DataSource = queryList;
            repGrid.DataBind();
        }

        public static string GetState(string keyVal)
        {
            var dic = Twee.Comm.ConfigParamter.InventoryStateConfigEn;
            return dic.Where(s => s.Key.ToString() == keyVal.Trim()).Select(s => s.Value.Trim()).FirstOrDefault();
        }

        private List<Twee.Model.proDetails> GetProDetailList(string state, string startTime, string endTime)
        {
            List<Twee.Model.proDetails> list = new List<Twee.Model.proDetails>();
            Twee.Mgr.proDetailsMgr prodetailMgr = new Twee.Mgr.proDetailsMgr();
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startIndex = pageSize * pageIndex + 1;
            int endIndex = startIndex + pageSize - 1;

            string where = " 1=1 and userid='"+userGuid.ToString()+"'";
            if (!string.IsNullOrEmpty(state) && state!="-1")
                where += " and state=" + state;
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                where += " and (createtime>='"+startTime+"' and createtime<='"+endTime+"')";;

            //DataTable dt = prodetailMgr.GetListByPage(where,"",startIndex,endIndex).Tables[0];
            list = prodetailMgr.GetEntityListByPage(where, "", startIndex, endIndex);

            return list;
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind();
        }

        private List<T> DataTableToList<T>(T obj,DataTable dt) {
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows) { 
                  Type t=typeof(T);
                  PropertyInfo[] info = t.GetProperties();
                  foreach (DataColumn col in dt.Columns) {
                      info.Where(s => s.Name.ToLower() == col.ColumnName.ToLower())
                            .Select(s => s).First().SetValue(obj,row[col.ColumnName].ToString(),null);                 
                  }
                  list.Add(obj);
            }
            return list;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }




    }
    
}