using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
//using System.IO;
namespace TweebaaWebApp2.AjaxPages
{
    public partial class pwdAjax : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);  
            string prdInfo = sr.ReadToEnd();  
            //string prdID = Request.Params.Get("id");
            //action = Request.Params.Get("action");
            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(prdInfo);
            string prdID = dic["id"].ToString();
            string shareUrlId = "";
            prdID = CommUtil.GetUrlPrdId(prdID,out shareUrlId);

            if (!string.IsNullOrEmpty(shareUrlId))//说明是通过分享链接访问页面的
            {
                ShareVisitAction(shareUrlId);//改变分享链接访问数
            }

            action = dic["action"].ToString();

            if (!string.IsNullOrEmpty(action))
            {              
                if (action == "save" && (string.IsNullOrEmpty(prdID) || prdID == "undefined"))
                {
                    Add(0); //保存预览
                }
                else if (action == "submitAdd" && (string.IsNullOrEmpty(prdID) || prdID == "undefined"))
                {
                    Add((int)(Twee.Comm.ConfigParamter.PrdSate.check)); //直接提交发布 不用预览 Jack Cao
                }
                else if (action == "save" && !string.IsNullOrEmpty(prdID) && prdID != "undefined")
                {
                    Update(prdID);//返回修改
                }
                else if (action == "add" && !string.IsNullOrEmpty(prdID) && prdID != "undefined")
                {
                    Submit((int)(Twee.Comm.ConfigParamter.PrdSate.check), prdID.ToGuid().Value); //提交发布【这里状态值改为11，是指在进入大众评审前的审核】
                }
                else if (action == "edit")
                {
                    GetPrdModel(prdID);//加载编辑信息   
                }
                else if (action == "review")
                {
                    GetReviewPrd(prdID);
                }
                else if (action == "query")
                {
                    GetPrd("","1","",1,50);//查询列表
                }
                else if (action == "queryViewPreviewComment")
                {
                    QueryViewPreviewComment(prdID);
                }
                else if (action=="savePic")
                {
                    SavePic(prdID);
                }
                else if (action == "GetPrdCate") // get all categories of a prduct
                {
                    GetPrdCate(prdID);
                }
                else if (action == "change_sku")
                {
                    ChangeSKU(prdID);
                }

            }
            else
            {
                Response.Clear(); 
                Response.Write("error");
                return;
            }          
            
        }

        /// <summary>
        /// query if user can view preview comment
        /// user can view if login and ( the user is the submitter or evaluater)
        /// </summary>
        private void QueryViewPreviewComment(string prdID)
        {
            try
            {
                Response.Clear();

                // check if the user is login or not
                Guid? userGuid = CommUtil.IsLogion();
                if (userGuid == null)
                {
                    Response.Write("0");//未登录
                    return;
                }

                // check if the user is the submitter of the product
                Guid prdGuid = new Guid(prdID);
                PrdMgr prdMgr = new PrdMgr();
                bool isUserSubmitter = prdMgr.IsUserSubmitter((Guid)userGuid, prdGuid);
                bool isUserEvaluator = prdMgr.IsUserEvaluator((Guid)userGuid, prdGuid);
                if (!isUserSubmitter && !isUserEvaluator)
                {
                    Response.Write("0");
                }
            }
            catch (Exception ex)
            {
                Response.Write("-1");
            }
            Response.Write("1");
        }

        /// <summary>
        /// 保存产品
        /// </summary>
        public void Add(int prdState)
        {
            try
            {
                PrdMgr mgr = new PrdMgr();
                Prd prd = new Prd();               
                Guid prdGuid = new Guid();
                CookiesHelper cookie = new Twee.Comm.CookiesHelper();                
                Guid? uGuid = CommUtil.IsLogion();
                if (uGuid == null)
                {
                    Response.Write("-2");//未登录
                    return;
                }

                string result = "1";
                string name = CommHelper.GetStrDecode(dic["prdName"].ToNullString());//产品名称 
                string cateGuid = CommHelper.GetStrDecode(dic["prdCate"].ToNullString());//产品类别
                string cate1GuidList = CommHelper.GetStrDecode(dic["prdCate1List"].ToNullString());//all level 1 product categories 
                string cate2GuidList = CommHelper.GetStrDecode(dic["prdCate2List"].ToNullString());//all level 2 product categories 
                string cate3GuidList = CommHelper.GetStrDecode(dic["prdCate3List"].ToNullString());//all level 3 product categories 
                string txtTag = CommHelper.GetStrDecode(dic["prdTag"].ToNullString());//tag
                string txtjl = CommHelper.GetStrDecode(dic["prdAdvantage"].ToNullString());//卖点特色        
                string txtinfo = CommHelper.GetStrDecode(dic["prdContent"].ToNullString());//产品详情
                string answer = CommHelper.GetStrDecode(dic["prdAnswer"].ToNullString());//产品解决的问题         
                //string videoUrl = CommHelper.GetStrDecode(dic["prdVideo"].ToNullString());//产品视频
                string videoUrl =dic["prdVideo"].ToNullString();//产品视频(不要解密)

                decimal estimateprice = CommHelper.GetStrDecode(dic["prdPrice"].ToNullString()).ToDecimal();//产品建议零售价       
                string prdSupplyPrice = CommHelper.GetStrDecode(dic["prdSupplyPrice"].ToNullString()); //供货报价区间
                string txtCompanyName = CommHelper.GetStrDecode(dic["prdCompany"].ToNullString());//公司名称
                string txtIndustry = CommHelper.GetStrDecode(dic["prdCompanyIndus"].ToNullString());//公司行业
                string txtUrl = CommHelper.GetStrDecode(dic["prdCompanyWeb"].ToNullString());//公司网址   
                string prdSupplyWay = CommHelper.GetStrDecode(dic["prdSupplyWay"].ToNullString()); //供应方式
                string prdPic = CommHelper.GetStrDecode(dic["prdPic"].ToNullString()); //产品缩略图片 
                string supplyPrice = CommHelper.GetStrDecode(dic["supplyPrice"].ToNullString()).ToDecimal().ToString();//供货价格
                int prdMoq = CommHelper.GetStrDecode(dic["prdMoq"].ToNullString()).ToInt();//最小起订量
                int isSupplier = CommHelper.GetStrDecode(dic["isSupplier"].ToNullString()).ToInt();//is supplier or not
                string supplierName = CommHelper.GetStrDecode(dic["supplierName"].ToNullString()); 
                string supplierWebsite = CommHelper.GetStrDecode(dic["supplierWebsite"].ToNullString());
                string supplierPhone = CommHelper.GetStrDecode(dic["supplierPhone"].ToNullString());
                string supplierEmail = CommHelper.GetStrDecode(dic["supplierEmail"].ToNullString());
                string supplierAddress = CommHelper.GetStrDecode(dic["supplierAddress"].ToNullString()); 

                int isUseTemp = CommHelper.GetStrDecode(dic["isUseTemp"].ToNullString()).ToInt();

                mgr.AddPrd(prdState, name, estimateprice, videoUrl, txtCompanyName, txtIndustry, txtUrl, cateGuid, uGuid.Value, txtTag, txtjl, txtinfo, "", answer, prdPic, prdSupplyPrice, prdSupplyWay, prdMoq, out result, out  prdGuid, supplyPrice, isSupplier, supplierName, supplierWebsite, supplierPhone, supplierEmail, supplierAddress, isUseTemp);
                Response.Clear();
                if (result == "1" && prdGuid!=null && prdGuid.ToString()!="" )
                {
                    //string message = action == "save" ? "保存成功" : "保存失败";
                    bool bSaveCate = mgr.SaveCate(prdGuid.ToString(),  cate1GuidList,  cate2GuidList,  cate3GuidList);
                    //Send E-mail to service@
                    string strTitle = "User Suggested a Product";
                    string strMessage = "User Suggested a Product,Please review it";
                    Twee.Comm.Mailhelper.SendMail(strTitle, strMessage, "snow@leivaire.com");

                    Response.Write(prdGuid);
                }
                else
                {
                    //string message = action == "add" ? "添加成功" : "添加失败";
                    Response.Write("error");
                }               
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                Response.Write("error");
            } 
        }

        public void ChangeSKU(string prdGuid)
        {
            string sRulesID = dic["ruleid"].ToNullString();
            PrdMgr mgr = new PrdMgr();
            DataTable dt = mgr.GetProductTweebaaSKU(prdGuid, sRulesID);
            //get ship to 
            string TweebaaSKU = dt.Rows[0]["prosku"].ToString();
            Response.Clear();
            Response.Write(TweebaaSKU);

        }
        /// <summary>
        /// 提交产品
        /// </summary>
        /// <param name="prdState">产品状态</param>
        /// <param name="prdGuid">产品id</param>
        public void Submit(int prdState,Guid prdGuid)
        {
            PrdMgr mgr = new PrdMgr();
            Response.Clear();
            if ( mgr.UpdatePrdState(prdState, prdGuid))
            {

                Response.Write("success");
            }
            else
            {
                Response.Write("false");
            }
        }

        /// <summary>
        /// 更新修改产品
        /// </summary>
        /// <param name="id">产品id</param>
        public void Update(string id)
        {         
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Guid prdID = id.ToGuid().Value;
                    PrdMgr mgr = new PrdMgr();
                    Prd prd = new Prd();//产品基本信息 
                    Prdprice prdPrice = new Prdprice();//产品价格区间信息
                    File file = new File();//产品缩略图片信息
                    Supplyinfor supplyInfor = new Supplyinfor();//供应商信息                   
                    CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                    Guid? uGuid = CommUtil.IsLogion();
                    if (uGuid==null)
                    {
                        Response.Redirect("../User/login.aspx");
                    }
                    string result = "";
                    //Guid prdGuid = CommHelper.GetStrDecode(Request.QueryString["id"].ToNullString()).ToGuid().Value;
                    //string name = CommHelper.GetStrDecode(Request.Form["prdName"].ToNullString());//产品名称    
                    string name = CommHelper.GetStrDecode(dic["prdName"].ToNullString());//产品名称 
                    Guid cateGuid = CommHelper.GetStrDecode(dic["prdCate"].ToNullString()).ToGuid().Value;//产品类别
                    string cate1GuidList = CommHelper.GetStrDecode(dic["prdCate1List"].ToNullString());//all level 1 product categories 
                    string cate2GuidList = CommHelper.GetStrDecode(dic["prdCate2List"].ToNullString());//all level 2 product categories 
                    string cate3GuidList = CommHelper.GetStrDecode(dic["prdCate3List"].ToNullString());//all level 3 product categories 
                    string txtTag = CommHelper.GetStrDecode(dic["prdTag"].ToNullString());//tag        
                    string txtjl = CommHelper.GetStrDecode(dic["prdAdvantage"].ToNullString());//卖点特色        
                    string txtinfo = CommHelper.GetStrDecode(dic["prdContent"].ToNullString());//产品详情
                    string answer = CommHelper.GetStrDecode(dic["prdAnswer"].ToNullString());//产品解决的问题         
                    //string videoUrl = CommHelper.GetStrDecode(dic["prdVideo"].ToNullString());//产品视频
                    string videoUrl = dic["prdVideo"].ToNullString();//产品视频(不要解密)
                    decimal estimateprice = CommHelper.GetStrDecode(dic["prdPrice"].ToNullString()).ToDecimal();//产品建议零售价       
                    string prdSupplyPrice = CommHelper.GetStrDecode(dic["prdSupplyPrice"].ToNullString()); //供货报价区间
                    string txtCompanyName = CommHelper.GetStrDecode(dic["prdCompany"].ToNullString());//公司名称
                    string txtIndustry = CommHelper.GetStrDecode(dic["prdCompanyIndus"].ToNullString());//公司行业
                    string txtUrl = CommHelper.GetStrDecode(dic["prdCompanyWeb"].ToNullString());//公司网址   
                    string prdSupplyWay = CommHelper.GetStrDecode(dic["prdSupplyWay"].ToNullString()); //供应方式
                    string prdPic = CommHelper.GetStrDecode(dic["prdPic"].ToNullString()); //产品缩略图片
                    string supplyPrice = CommHelper.GetStrDecode(dic["supplyPrice"].ToNullString()).ToDecimal().ToString();//供货价格
                    int prdMoq = CommHelper.GetStrDecode(dic["prdMoq"].ToNullString()).ToInt();//最小起订量
                    int isSupplier = CommHelper.GetStrDecode(dic["isSupplier"].ToNullString()).ToInt();
                    string supplierName = CommHelper.GetStrDecode(dic["supplierName"].ToNullString());
                    string supplierWebsite = CommHelper.GetStrDecode(dic["supplierWebsite"].ToNullString());
                    string supplierPhone = CommHelper.GetStrDecode(dic["supplierPhone"].ToNullString());
                    string supplierEmail = CommHelper.GetStrDecode(dic["supplierEmail"].ToNullString());
                    string supplierAddress = CommHelper.GetStrDecode(dic["supplierAddress"].ToNullString());

                    mgr.UpdatePrd(name, estimateprice, videoUrl, txtCompanyName, txtIndustry, txtUrl, cateGuid, uGuid.Value, txtTag, txtjl, txtinfo, answer, "", prdPic, prdSupplyPrice, prdSupplyWay, supplyPrice, prdMoq,
                        isSupplier, supplierName, supplierWebsite, supplierPhone, supplierEmail, supplierAddress,
                        prdID, out result);
                    Response.Clear();

                    if (result == "1")
                    {
                        bool bSaveCate = mgr.SaveCate(prdID.ToString(), cate1GuidList, cate2GuidList, cate3GuidList);
                        Response.Write(prdID);
                    }
                    else
                    {
                        Response.Write("error");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                Response.Write("error");
            }
        }

        /// <summary>
        /// 查询某个产品
        /// </summary>
        /// <returns></returns>
        public void GetPrdModel(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {  
                Guid prdID = id.ToGuid().Value;

                #region 供应信息（去掉）
                //SupplyInforMgr supplyInforMgr=new SupplyInforMgr();
                //string txtCompanyName = "";
                //string txtUrl = "";
                //string txtIndustry = "";
                //string typelist = "";               
                //Supplyinfor supplyInfor = supplyInforMgr.GetPrdSupply(prdID);
                //if (supplyInfor!=null)
                //{
                //    txtCompanyName = supplyInfor.companyname;
                //    txtUrl = supplyInfor.companyurl;
                //    txtIndustry = supplyInfor.industry;
                //    typelist = supplyInfor.typelist;
                //}
                //string supply = "supplyInfor:[{'txtCompanyName':'" + txtCompanyName + "','txtUrl':'" + txtUrl + "','typelist':'" + txtIndustry + "','typelist':'" + typelist + "'}]";
                #endregion
                string pics="";
                FileMgr file=new FileMgr();
                List<File> listFile = file.GetModelList("prdguid='"+prdID+"'");
                foreach (var m in listFile)
	            {
		          pics+=m.fileurl+",";
	            }
                pics = pics.TrimEnd(',');               

                PrdMgr mgr = new PrdMgr();
                //string priceList="priceList:["; //发布页面的价格区间已经去掉不用
                //DataTable dtPrice= mgr.MgeGetPrdPrice(prdID.ToString());
                //for (int i = 0; i < dtPrice.Rows.Count; i++)
                //{
                //   // Math.Round(model.estimateprice.Value, 2);
                //    string pstr1 = dtPrice.Rows[i]["p1"].ToString();
                //    string pstr2 = dtPrice.Rows[i]["p2"].ToString();
                //    string p1 = pstr1.Substring(0, pstr1.IndexOf(".") + 2);
                //    string p2 = pstr2.Substring(0, pstr2.IndexOf(".") + 2);
                //    string price=dtPrice.Rows[i]["price"].ToString();
                //    price = Math.Round(price.ToDecimal(), 2).ToString();
                //    string item="{'p1':'"+p1+"','p2':'"+p2+"','price':'"+price+"'}";
                //    priceList+=item+",";
                //}
                //priceList=priceList.TrimEnd(',')+"]";    
               
                Prd model = mgr.GetModel(prdID);
                model.pics = pics;       
                string baseInfo = JsonConvert.SerializeObject(model);
                //string resu = "{baseInfo:" + baseInfo + "," + priceList + "}";
                string resu = "{baseInfo:" + baseInfo + "}";
                Response.Clear();
                Response.Write(resu);
            }
            else
            {
                Response.Clear();
                Response.Write("");
            }
        }

        /// <summary>
        /// 获取评审预览产品信息
        /// </summary>
        /// <returns></returns>
        public void GetReviewPrd(string id)
        {
            Response.Clear();
            if (!string.IsNullOrEmpty(id))
            {
                Guid prdID = id.ToGuid().Value;

                string pics = "";
                FileMgr file = new FileMgr();
                List<File> listFile = file.GetModelList("prdguid='" + prdID + "'");
                foreach (var m in listFile)
                {
                    pics += m.fileurl + ",";
                }
                pics = pics.TrimEnd(',');
                PrdMgr mgr = new PrdMgr();     
                Prd model = mgr.GetModel(prdID);

                if (model!=null)
                {
                    //Add by Long for display SKU/Ship To Country
                    DataTable dt = mgr.GetProductTweebaaRulesExtra(id, "");
                    //get ship to 
                    if (dt != null)
                    {
                        model.TweebaaSKU = string.Empty;
                        if (!DBNull.Value.Equals(dt.Rows[0]["prosku"]))
                        {
                            model.TweebaaSKU = dt.Rows[0]["prosku"].ToString();
                        }
                       
                       // Changed by Jack Cao 2015-12-21
                       // model.ShipToCountry = dt.Rows[0]["ShipFrom_ShipToCountries"].ToString();
                       // model.IsCustomerFreeShip = dt.Rows[0]["IsCustomerFreeShip"].ToString();
                        model.IsCustomerFreeShip = "0";  // this will not be used in the future ===> Jack Cao 2015/12/21
                    }

                    // add by jack to get ship to country information
                    string sShipToCountry = "<Table>";
                    DataTable dtShipToCountry = mgr.GetProductShipToCountryInfo(prdID.ToString());
                    if (dtShipToCountry != null) //Add by Long 2016/01/06 to check whether null
                    {
                        foreach (DataRow drShipToCountry in dtShipToCountry.Rows)
                        {
                            int iIsFreeShip = drShipToCountry["ProductShipToCountry_IsFree"].ToString().ToInt();
                            if (iIsFreeShip == 1)
                            {
                                sShipToCountry += "<tr><td>" + drShipToCountry["Country_Name"].ToString() + ":</td><td>This item qualifies for FREE SHIPPING.</td></tr>";
                            }
                            else
                            {
                                sShipToCountry += "<tr><td>" + drShipToCountry["Country_Name"].ToString() + ":</td><td> Standard shipping rate will apply.</td></tr>";
                            }
                        }
                        sShipToCountry += "<tr><td>" + "Other Countries:</td><td> We are delighted to serve international customers; Please request ship-rate at check-out.</td></tr>";
                    }
                    sShipToCountry += "</table>";
                    model.ShipToCountry = sShipToCountry;

                    UserMgr user = new UserMgr();
                    PrdCateMgr cate = new PrdCateMgr();
                    PrdCate cateMod = cate.GetModel(model.cateGuid);
                    if (cateMod!=null)
                    {
                        model.catename = cateMod.name;
                    }                  
                    model.userName = user.GetUserNameByID(model.userGuid.ToString());
                    model.pics = pics;
                    model.estimateprice = Math.Round(model.estimateprice.Value, 2);

                    // presaleendday has been retrieved form database and do not to calculate here
                    //if (model.presaleendtime!=null)
                    //{
                    //    TimeSpan ts = model.presaleendtime.Value - DateTime.Now;
                    //    model.presaleendday = ts.Days;       
                    //}
                              
                    string data = JsonConvert.SerializeObject(model);
                    Response.Write(data);
                    return;
                   
                    //string baseInfo = "baseInfo:[{";
                    //baseInfo += "'name':'" + model.name + "',"
                    //    + "'userName':'" + user.GetUserNameByID(model.userGuid.ToString())+ "',"
                    //    + "'userID':'" + model.userGuid + "',"
                    //    + "'cateGuid1':'" + model.cateGuid + "',"
                    //    + "'cateGuid2':'" + model.cateGuid + "',"
                    //    + "'cateGuid3':'" + model.cateGuid + "',"
                    //    + "'txtjl':'" + model.txtjj + "',"
                    //    + "'answer':'" + model.answer + "',"
                    //    + "'txtinfo':'" + CommHelper.GetStrEncode(model.txtinfo) + "',"
                    //    + "'videoUrl':'" + model.videoUrl + "',"
                    //    + "'estimateprice':'" + model.estimateprice + "',"
                    //    + "'addtime':'" + model.addtime + "',"
                    //    + "'pics':'" + pics + "'}]";
                    //string resu = "{" + baseInfo + "}";                   
                    //Response.Write(resu);
                    //return;
                }             
                Response.Write("");
            }
            else
            {
                Response.Clear();
                Response.Write("");
            }
        }

        /// <summary>
        /// 查询产品列表
        /// </summary>
        /// <returns></returns>
        public void GetPrd(string prdName, string state, string orderby, int startIndex, int endIndex)
        {
            PrdMgr mgr = new PrdMgr();
            //List<Prd> listPrd = mgr.DataTableToList(mgr.GetListByPage("", "", 1, 500).Tables[0]);
            //List<Prd> listPrd = mgr.DataTableToList(mgr.GetListByPage("", "", start, end).Tables[0]);
            //DataTable dt = mgr.GetPrdReview(prdName, state, orderby, startIndex, endIndex);
            //string data = DataTable2Json("pedReview", dt);
            //Response.Clear();
            //Response.Write(data); 
        }

        /// <summary>  
        /// dataTable转换成Json格式  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public void GetPrdCate(string prdGuid)
        {
            Response.Clear();
            PrdMgr mgr = new PrdMgr();
            if (string.IsNullOrEmpty(prdGuid))
            {
                Response.Write("");
                return;
            }
            DataTable dt = mgr.GetPrdCate(prdGuid);

            string sJson = JsonConvert.SerializeObject(dt);
            Response.Write(sJson);
        }

        #region dataTable转换成Json格式
        /// <summary>  
        /// dataTable转换成Json格式  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTable2Json(string jsonName,DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(jsonName);
            jsonBuilder.Append("\":[");
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        #endregion dataTable转换成Json格式


        /// <summary>
        /// Msdn
        /// </summary>
        /// <param name="jsonName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(string jsonName, DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }

        /// <summary>
        /// 该分享链接id
        /// </summary>
        /// <param name="shareUrlId"></param>
        private void ShareVisitAction(string shareUrlId)
        {
            ShareMgr share = new ShareMgr();
            Share shareModel = share.GetModel(shareUrlId.ToGuid().Value);
            if (shareModel != null)
            {
               
                Guid? shareUser = shareModel.userguid; //分享者id     
                CookiesHelper cookie = new CookiesHelper();
                //string cookieName = System.Configuration.ConfigurationManager.AppSettings["cookieshareUrl"].ToString();
                string cookieValue = cookie.getCookie(shareUrlId);//是以分享链接的数据库id作为cookie的key值的
                if (string.IsNullOrEmpty(cookieValue))
                {
                    //如果分享链接的cookie不存在，则修改链接的访问数加1
                    bool b1 = share.UpdateVisitCount(shareUrlId);
                    if (b1)
                    {
                        //修改访问数后，创建该链接的cookie,设置有效期1天。  1天后，cookie消失，再访问才计数
                        bool b2 = cookie.createCookie(shareUrlId, shareUrlId, 1);
                    }
                }

            }
        
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="prdID"></param>
        private void SavePic(string prdID)
        {
            string prdPic = CommHelper.GetStrDecode(dic["pics"].ToNullString()); //产品缩略图片 
            string video = dic["video"].ToNullString(); //产品视频
            List<string> listPics = prdPic.TrimStart(',').Split(',').ToList<string>();
            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            mgr.MgeUpdatePrdFile(prdID.ToGuid().Value, listPics,video);
        }


    }
}