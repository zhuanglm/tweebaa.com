using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Data;
using Twee.Comm;
using Newtonsoft.Json;
using Twee.Model;

namespace TweebaaWebApp.Manage
{
    public partial class admSendPrdToStorge : System.Web.UI.Page
    {
        private static int pageSize = ConfigParamter.pageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            gridData.Attributes.Add("style", "word-break:break-word;word-wrap:break-all;");
            if (!IsPostBack)
            {
                AspNetPager1.PageSize = pageSize;
                GetAll();
            }
        }
        //获取可以导入仓库的产品信息：=等待上架中的产品(状态=6) + 并且是已经采纳供货的(状态=2)
        public void GetAll()
        {
            PrdMgr prd = new PrdMgr();           
            string prdName = txtName.Value.Trim();
            string userName = txtUser.Value.Trim();
            int index = AspNetPager1.CurrentPageIndex - 1;
            int startId = pageSize * index + 1;
            int endId = startId + pageSize - 1;
            int sumCount=0;
            DataTable dt = prd.MgeGetPrdSendToStorge( prdName,"", startId, endId, out sumCount);         
            if (dt != null)
            {
                gridData.DataSource = dt;
                gridData.DataBind(); 
            }
            AspNetPager1.RecordCount = sumCount;
            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });

        }

        //批量推送
        protected void btnSendAll_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = hidIds.Value.TrimEnd(';');
                string[] strArr = ids.Split(';');
                products products = new products();
                proRulesMgr rules = new proRulesMgr();
                List<PrdSendModel> listData = new List<PrdSendModel>();
                string OwnerId = System.Configuration.ConfigurationManager.AppSettings["OwnerId"].ToString();
                for (int i = 0; i < strArr.Length; i++)
                {
                    string[] arrs = strArr[i].ToString().Split(',');
                    string userid = arrs[1].ToString();
                    string prdid = arrs[0].ToString();
                    string prdname = arrs[2].ToString();
                    DataTable dtRules = rules.GetPrdRules(userid, prdid);
                    PrdSendModel model = new PrdSendModel();
                    model.owner_id = OwnerId;
                    model.product_id = prdid;

                    model.product_name = prdname;
                    model.product_title = prdname;
                    model.remark = "";//以上为产品主要信息
                    model.sku = dtRules;//为产品规格信息      
                    listData.Add(model);
                }
                products.models = listData;
                string data = JsonConvert.SerializeObject(products.models);
                data = "{ \"count\":\"" + strArr.Length + "\", \"products\":" + data + "}";
                WarehouseInterface house = new WarehouseInterface();
                string resu = house.ProductSend(data);
                dynamic json = Json.Deserialize(resu);//解析json    
                string resuCode = json.errorCode;
                if (resuCode == "100")
                {
                    //导入成功后，修改该供货单状态为：已推送4
                    proDetailsMgr proDetial = new proDetailsMgr();
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        string[] arrs = strArr[i].ToString().Split(',');
                        string userid = arrs[1].ToString();
                        string prdid = arrs[0].ToString();
                        proDetial.UpdateInventoryState(prdid, userid, (int)ConfigParamter.InventoryState.push);

                    }

                }
            }
            catch (Exception)
            {                
                throw;
            }
                      
            #region
            //Json格式
            //{
            //  “count”:”2”,
            //  “products”:
            //     [ 
            //        {
            //          “owner_id”: “”,
            //          “product_id”: “”,        
            //          “skus”: 
            //           [
            //             {
            //              “sku_id”: “”,        
            //              “product_code”: “” 
            //             }
            //           ]
            //       } 
            //    ]
            //}

            //{
            //    "owner_id": null,
            //    "product_id": null,
            //    "sku": [
            //        {
            //            "prdguid": "6289d34d-020e-4884-a1c8-f2dfd75d8ad2",
            //            "userGuid": "d30b4735-bbf5-49ec-9abc-ac31c15bd631"                 
            //        }           

            //    ]
            //}





            #endregion
        }

        //单个推送
        protected void btnSend_Click(object sender, EventArgs e)
        {
           

           
        }

        //搜索
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetAll();

        }
       
        //翻页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetAll();
        }

        //获取产品图片路径
        public string GetPic(string img)
        {
            string strHost = System.Configuration.ConfigurationManager.AppSettings["prdImgDomain"].ToString();
            img = strHost + img.Replace("big", "small");
            return img;

        }

        
    }
}