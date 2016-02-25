﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Twee.Model;
using Twee.Comm;
using System.Data.OleDb;
using log4net;
using System.Reflection;
using Maticsoft.Common;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace Twee.Mgr 
{
    public class UploadProduct
    {
        #region 以前的
        //导入的Excel的路径
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public string  ImportPrd(string userGuid,string userName,string excelPath)  
        {
            int flag = 0;

                DataTable dt = ExcelToDataTable(excelPath);
                PrdMgr prdMgr = new PrdMgr();
                FileMgr fileMgr = new FileMgr();
                PrdCate prdCate = new PrdCate();
                PrdCateMgr prdCateMgr = new Mgr.PrdCateMgr();
                Prdprice prdprice = new Prdprice();
                string error = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        flag = i;
                        Prd prd = new Prd();
                        prd.userGuid = userGuid.ToGuid().Value;//发布者id
                        prd.prdGuid = Guid.NewGuid();//产品id
                        prd.name = dt.Rows[i][0].ToString();//产品名称             
                        prd.txtjj = dt.Rows[i][2].ToString();//卖点特色
                        prd.question = dt.Rows[i][3].ToString();//解决的问题               
                        prd.estimateprice = dt.Rows[i][5].ToString().ToDecimal();//建议零售价                
                        List<PrdCate> listCate = prdCateMgr.GetModelList("name='" + dt.Rows[i][1].ToString() + "'");
                        if (listCate != null && listCate.Count > 0)
                        {
                            prdCate = listCate[0];
                        }
                        prd.cateGuid = prdCate.guid;//类别
                        string state = dt.Rows[i][8].ToString();//产品分区              
                        prd.wnstat = 1;//评审区
                        int count = prdMgr.Add(prd);
                        string[] fileImgs = dt.Rows[i][4].ToString().Split(',');
                        for (int j = 0; j < fileImgs.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(fileImgs[j]))
                            {
                                //UploadImg/big/20141211/20141211200125_1701.png
                                //UploadImg/20141130/51_eva.jpg
                                Twee.Model.File file = new Model.File();   
                                file.prdguid = prd.prdGuid;
                                file.prtguid = prd.prdGuid;
                                file.idx = j;
                                string urlStr = fileImgs[j].Trim();
                                string[] urlArr = urlStr.Split('/');
                                urlStr = "UploadImg/big/" + DateTime.Now.ToString("yyyyMMdd") + "/" + urlArr[2];
                                //urlStr = "UploadImg/big/" + "20141231" + "/" + urlArr[2];
                                file.fileurl = urlStr;//产品图片
                                file.addtime = DateTime.Now;
                                fileMgr.Add(file);
                            }
                        }
                        if (dt.Rows[i][7].ToString().Trim()!="")
                        {
                            string[] prices = dt.Rows[i][7].ToString().Split(';');
                            for (int f = 0; f < prices.Length; f++)
                            {
                                if (!string.IsNullOrEmpty(prices[f]))
                                {
                                    string p = prices[f];
                                    if (!string.IsNullOrEmpty(p))
                                    {
                                        bool b = prdMgr.MgeAddPrdPrice(prd.prdGuid, p.Split(',')[0].ToInt(), p.Split(',')[1].ToInt(), p.Split(',')[2].ToDecimal());
                                    }
                                }
                            }
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        log.Error("【"+userName+"】"+"导入错误:第【" + flag + 1 + " 】行：" + ex.Message);
                        error += "导入错误:第【" + flag + 1 + "】行：" + ex.Message + " <br />";
                    }
                }
                return error;
        }

        //for liwei
        public string ImportPrd2(string userGuid,string userName, string excelPath)
        {
            int flag = 0;

            DataTable dt = ExcelToDataTable(excelPath);
            PrdMgr prdMgr = new PrdMgr();
            FileMgr fileMgr = new FileMgr();
            PrdCate prdCate = new PrdCate();
            PrdCateMgr prdCateMgr = new Mgr.PrdCateMgr();
            Prdprice prdprice = new Prdprice();
            string error = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    flag = i;
                    Prd prd = new Prd();
                    prd.userGuid = userGuid.ToGuid().Value;//发布者id
                    prd.prdGuid = Guid.NewGuid();//产品id
                    prd.name = dt.Rows[i][0].ToString();//产品名称             
                    prd.txtjj = dt.Rows[i][2].ToString();//卖点特色
                    prd.question = dt.Rows[i][3].ToString();//解决的问题               
                    prd.estimateprice = dt.Rows[i][5].ToString().ToDecimal();//建议零售价                
                    List<PrdCate> listCate = prdCateMgr.GetModelList("name='" + dt.Rows[i][1].ToString() + "'");
                    if (listCate != null && listCate.Count > 0)
                    {
                        prdCate = listCate[0];
                    }
                    prd.cateGuid = prdCate.guid;//类别
                    string state = dt.Rows[i][8].ToString();//产品分区              
                    prd.wnstat = 1;//评审区
                    int count = prdMgr.Add(prd);
                    string[] fileImgs = dt.Rows[i][4].ToString().Split(',');
                    for (int j = 0; j < fileImgs.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(fileImgs[j]))
                        {
                            //UploadImg/big/20141211/20141211200125_1701.png
                            //UploadImg/20141130/51_eva.jpg
                            Twee.Model.File file = new Model.File();   
                            file.prdguid = prd.prdGuid;
                            file.prtguid = prd.prdGuid;
                            file.idx = j;
                            string urlStr = fileImgs[j].Trim();
                            string[] urlArr = urlStr.Split('/');
                            //urlStr = "UploadImg/big/" + DateTime.Now.ToString("yyyyMMdd") + "/" + urlArr[2];
                            urlStr = "UploadImg/big/" + urlArr[1] + "/" + urlArr[2];
                            file.fileurl = urlStr;//产品图片
                            file.addtime = DateTime.Now;
                            fileMgr.Add(file);
                        }
                    }
                    string[] prices = dt.Rows[i][7].ToString().Split(';');
                    for (int f = 0; f < prices.Length; f++)
                    {
                        if (!string.IsNullOrEmpty(prices[f]))
                        {
                            string p = prices[f];
                            if (!string.IsNullOrEmpty(p))
                            {
                                bool b = prdMgr.MgeAddPrdPrice(prd.prdGuid, p.Split(',')[0].ToInt(), p.Split(',')[1].ToInt(), p.Split(',')[2].ToDecimal());
                            }
                        }
                    }
                   
                }              
                catch (Exception ex)
                {                   
                    log.Error("【" + userName + "】" + "导入错误:第【" + flag + 1 + " 】行：" + ex.Message);
                    error += "导入错误:第【" + flag + 1 + "】行：" + ex.Message + " <br />";
                }
            }            
            return error;            
        }

        //把Excel里的数据转换为DataTable，并返回DataTable
        public DataTable ExcelToDataTable(string excelPath)  
        {
            try
            {
                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;IMEX=1'";
                System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strCon);
                string strCom = "SELECT * FROM [Sheet1$]";
                DataTable dt;
                try
                {
                    Conn.Open();
                    DataTable dtDATAExcel = new System.Data.DataTable();
                    DataTable dtDATA = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string name = dtDATA.Rows[0][2].ToString().Trim();
                    System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strCom, Conn);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "[Sheet1$]");
                    Conn.Close();
                    dt = ds.Tables[0];
                    return dt;
                }             
                catch (Exception err)
                {
                    return null;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }         
        #endregion

        #region 新的
        //导入的Excel的路径      
        public string ImportPrdNew(string userGuid, string userName, string excelPath, string localhosturl, out int iProductUploadBatchNo)
        {

            int flag = 0;
            bool bIsNewProduct = false;
            iProductUploadBatchNo = DbHelperSQL.GetSeq("ProductUploadBatchNo");
            string sErrMsg;

            //DataTable dt = ExcelToDataTableNew(excelPath);
            //DataTable dt = ReadExcelIntoDataTable(excelPath, "Supplier Upload form", out sErrMsg);
            DataTable dt = ExcelToDataTableOpenXML(excelPath, "Supplier Upload form", out sErrMsg );

            if (dt == null)
            {
                return sErrMsg;
            }

            PrdMgr prdMgr = new PrdMgr();
            FileMgr fileMgr = new FileMgr();
            PrdCate prdCate = new PrdCate();
            PrdCateMgr prdCateMgr = new Mgr.PrdCateMgr();
            Prdprice prdprice = new Prdprice();
            string error = "";
            string flagName = "";
            string flagSupperID = "";
            char cateSeparator = '|';
            bool bLoadTestSale = false;   // load buy-now or load test-sale products

            // -------------------------------------------------
            // check header ( check all headers in the future)
            // --------------------------------------------------
            if (!dt.Columns.Contains("Supplier ID (Product team reference only)")) {
                error = "header error: Supplier ID (Product team reference only)";
                return error;
            }
            if (!dt.Columns.Contains("Product Image (URL)")) {
                error = "header error: Product Image (URL)";
                return error;
            }
            if (!dt.Columns.Contains("Product Image (file)")) {
                error = "header error: Product Image (file)";
                return error;
            }
            if (!dt.Columns.Contains("WEBSITE LINK (to product)")) {
                error = "header error: WEBSITE LINK (to product)";
                return error;
            }
            if (!dt.Columns.Contains("Supply Shipping Cost (base on sku) If FREE shipping, input 0"))
            {
                error = "header error: Supply Shipping Cost (base on sku) If FREE shipping, input 0";
                return error;
            }
            if (!dt.Columns.Contains("Customer Free Shipping Yes or No"))
            {
                error = "header error: Customer Free Shipping Yes or No";
                return error;
            }


            // determine load test-sale or buy-now products
            if (dt.Columns.Contains("Test-Sale price (USD)")  &&
                dt.Columns.Contains("Test-Sale unit target (input as natrual number)") &&
                dt.Columns.Contains("Test-Sale ending date input as MM/DD/YYYY") )

            {
                bLoadTestSale = true;
            }


            // check category and Ship to Country
            for (int i = 1; i < dt.Rows.Count; i++)  // skip first row
            {

                string SupperID = dt.Rows[i]["Supplier ID (Product team reference only)"].ToString();
                if (SupperID.Trim() == "") break;

                // check category
                string cate1Name = dt.Rows[i][" Categories"].ToString();
                string cate2Name = dt.Rows[i]["Sub-Categories"].ToString();
                string cate3Name = dt.Rows[i]["Sub-Sub-Categories"].ToString();
                string[] cate1NameArr = cate1Name.Split(cateSeparator);
                string[] cate2NameArr = cate2Name.Split(cateSeparator);
                string[] cate3NameArr = cate3Name.Split(cateSeparator);
                if (cate1NameArr.Count() != cate2NameArr.Count() || cate2NameArr.Count() != cate3NameArr.Count())
                {
                    error = "Line: " + (i+1).ToString() +  " Category number does not match!";
                    return error;
                }

                // check product name
                string sPrdName = dt.Rows[i]["Product Name"].ToString().Trim();
                if (sPrdName == string.Empty)
                {
                    error = "Liddne: " + (i + 1).ToString() + " Product Name is not set!";
                    return error;
                }
 
                // check Tweebaa Sku #
                string sTweebaaSku = dt.Rows[i]["Tweebaa SKU Number"].ToString().Trim();
                if (sTweebaaSku == string.Empty)
                {
                    error = "Line: " + (i + 1).ToString() + " Tweebaa SKU is not set!";
                    return error;
                }


                // check ship to country
                string sShipToCountries = dt.Rows[i]["Ship to Countries"].ToString(); //shipping to countries
                string[] sShipToCountryArr = sShipToCountries.Split(',');
                CountryMgr mgrCountry = new CountryMgr(); 
                
                foreach (string sShipToCountry in sShipToCountryArr)
                {
                    string sCountryName = sShipToCountry.ToUpper();
                    int iCountryID = -1;
                    string sCountryCode = string.Empty;
                    sCountryName = sCountryName.Replace("FREE", "").Trim();

                    mgrCountry.GetCountryInfoByName(sCountryName, out iCountryID, out sCountryCode);

                    if (iCountryID == -1)
                    {
                        error = "Line: " + (i + 1).ToString() + " Ship to country:" + sShipToCountry + " does not exist!";
                        return error;
                    }
                }
            }

            //---------------------------------------------------------------------
            // main loop for loading product
            //---------------------------------------------------------------------
            for (int i =1; i < dt.Rows.Count; i++)  // skip first sample data
            {
                try
                {

                    flag = i + 1;
                    #region 供应商信息

                    string SupperID = dt.Rows[i]["Supplier ID (Product team reference only)"].ToString();
                    if (SupperID.Trim() == "") break;

                    if (SupperID != "")
                    {
                        flagSupperID = SupperID;
                    }
                    if (SupperID == "" && flagSupperID != "")
                    {
                        SupperID = flagSupperID;
                    }


                    //int ShipFrom_ID = DbHelperSQL.GetSeq("ShipFrom");
                    string ShipFrom_CompanyName = dt.Rows[i]["Supplier Name"].ToString();//供应商名称
                    string SupplierAddress = dt.Rows[i]["Supplier Address"].ToString();//供应商地址
                    string ShipFrom_ContactName = dt.Rows[i]["Supplier Contact person"].ToString();//供应商联系人
                    string ShipFrom_Phone = dt.Rows[i]["Supplier Contact Phone Number"].ToString();//供应商联系电话
                    string ShipFrom_Email = dt.Rows[i]["Supplier email"].ToString();//供应商电子邮件
                    string ShipForm_WebSite = dt.Rows[i]["Supplier website"].ToString();//供应商网站
                    string ShipFrom_Address1 = dt.Rows[i]["Inventory Location (Shipping from address)  "].ToString();//库存位置（装运地址）
                    string ShipFrom_City = dt.Rows[i]["City"].ToString();
                    string Country_ID = getCountryID(dt.Rows[i]["Country"].ToString());//国家
                    string Province_ID = getProvinceID(Country_ID.ToInt(), dt.Rows[0]["Province"].ToString());//省份
                    string ShipFrom_Zip = dt.Rows[i]["Zip/Postal Code"].ToString();//邮编
                    string ShiptoCountries = dt.Rows[i]["Ship to Countries"].ToString();//shipping to countries
                    int ShipPartner_ID = 3;

                    userGuid = CheckUser(ShipFrom_CompanyName, ShipFrom_Email, ShipFrom_Phone, Country_ID);

                    bool bIsNewShipFrom = true;
                    int ShipFrom_ID = AddShipInfo(ShipFrom_CompanyName, ShipFrom_Address1, ShipFrom_ContactName, ShipFrom_Phone, ShipFrom_Email, ShipForm_WebSite, ShipFrom_City, Province_ID, ShipFrom_Zip, Country_ID, SupplierAddress, userGuid.ToString(), SupperID, iProductUploadBatchNo, ShiptoCountries, out bIsNewShipFrom);
                    #endregion

                    #region shipping method

                    string sShipMethodName = dt.Rows[i]["Shipping Method"].ToString();
                    bool bOK = AddShipMethod(ShipFrom_ID, sShipMethodName, iProductUploadBatchNo, ShiptoCountries, out error);
                    if (!bOK)
                    {
                        error = "Line: " + (i + 1).ToString() + " " + error;
                        return error;
                    }
                    
                    #endregion


                    #region 产品信息

                   //Attipas Baby/Toddler shoes; Ballet, Red
                    bIsNewProduct  = false;
                    Prd prd = new Prd();
                    prd.name = dt.Rows[i]["Product Name"].ToString();//产品名称    
                    prd.supplyPrice = dt.Rows[i]["Wholesale price"].ToString().TrimStart('$').ToDecimal();//供应价格
                    if (prd.name != "" )
                    {
                        flagName = prd.name;
                    }
                    if (prd.name==""&&flagName!="")
                    {
                        prd.name = flagName;
                    }

                    // take product as a new product if it is not existed in current upload sheet
                    string ckbPrdID = checkPrd(prd.name, prd.supplyPrice.Value, iProductUploadBatchNo);
                    //if (ckbPrdID != "") bIsNewProduct = true;
                    
                    // new product
                    if (ckbPrdID == "")
                    {
                        prd.prdGuid = Guid.NewGuid();//产品id
                        prd.userGuid = userGuid.ToGuid().Value;//发布者id   
                        string brand = dt.Rows[i]["Brand"].ToString();//品牌                   
                        //prd.cateGuid = SubSubCategories.ToGuid().Value;
                        string Tags = dt.Rows[i]["Tags"].ToString();//标签
                        prd.txtTag = Tags.Trim();
                        prd.txtjj = dt.Rows[i]["Brief Description"].ToString();//卖点特色
                        prd.txtinfo = dt.Rows[i]["Detailed Description"].ToString();//描述
                        prd.question = dt.Rows[i]["Features and benefits"].ToString();//解决的问题     
                        prd.estimateprice = dt.Rows[i][" Suggested Retail Price (USD) "].ToString().TrimStart('$').ToDecimal();//建议零售价  
                        if (bLoadTestSale)
                        {
                            prd.saleprice = dt.Rows[i]["Test-Sale price (USD)"].ToString().TrimStart('$').ToDecimal();//销售价格
                        }
                        else
                        {
                            prd.saleprice = dt.Rows[i]["Tweebaa price"].ToString().TrimStart('$').ToDecimal();//销售价格
                        }
                        prd.Ranking = dt.Rows[i]["Ranking (1000-1   1000:best 1:worst)"].ToString().ToInt(); 
                        prd.MinAdvertisedPrice = dt.Rows[i]["MAP (Minimum Advertised Price) if none, leave blank"].ToString().TrimStart('$').ToDecimal();
                       
                        prd.moq = dt.Rows[i]["MOQ (units) - if Drop-Ship item, MOQ is 1"].ToString().ToInt();//最小起订
                        prd.videoUrl = dt.Rows[i]["VIDEO LINK"].ToString();//视频链接
                        if ( prd.videoUrl.IndexOf("iframe") != -1 && prd.videoUrl.IndexOf("youtube") != -1) {
                            prd.videoEmbed = prd.videoUrl;
                        }
                        string prdWebSite = dt.Rows[i]["WEBSITE LINK (to product)"].ToString();//产品对应的网站   "WEBSITE LINK (to product)"                


                        // presale target (presaleForward) and end date of test-sale
                        if (bLoadTestSale)
                        {
                            prd.presaleForward = dt.Rows[i]["Test-Sale unit target (input as natrual number)"].ToString().ToInt();

                            string sDate = dt.Rows[i]["Test-Sale ending date input as MM/DD/YYYY"].ToString();
                            if (sDate.All(Char.IsDigit))
                            {
                                double dDate = double.Parse(sDate);
                                prd.presaleendtime = DateTime.FromOADate(dDate);
                            }
                            else
                            {
                                prd.presaleendtime = sDate.ToDateTime();
                            }
                                //prd.presaleendtime = DateTime.Parse(dt.Rows[i]["Test-Sale ending date input as MM/DD/YYYY"].ToString());
                        }

                        // get multiple three category guid by name ( separated by cateSeparator)
                        string cate1NameList = dt.Rows[i][" Categories"].ToString();
                        string cate2NameList = dt.Rows[i]["Sub-Categories"].ToString();
                        string cate3NameList = dt.Rows[i]["Sub-Sub-Categories"].ToString();

                        string[] cate1NameArr = cate1NameList.Split(cateSeparator);
                        string[] cate2NameArr = cate2NameList.Split(cateSeparator);
                        string[] cate3NameArr = cate3NameList.Split(cateSeparator);

                        string cate1Name = string.Empty;
                        string cate2Name = string.Empty;
                        string cate3Name = string.Empty;
                        string cate1Guid = string.Empty;
                        string cate2Guid = string.Empty;
                        string cate3Guid = string.Empty;

                        string cate3GuidFirst = string.Empty;

                        for (int k = 0; k < cate1NameArr.Count(); k++)
                        {
                            cate1Name = cate1NameArr[k];
                            cate2Name = cate2NameArr[k];
                            cate3Name = cate3NameArr[k];
                            GetPrdCateGuid(cate1Name, cate2Name, cate3Name, out cate1Guid, out cate2Guid, out cate3Guid);

                            // add product category
                            bool b2 = AddPrdCate(prd.prdGuid.ToString(), cate1Guid, cate2Guid, cate3Guid, iProductUploadBatchNo);

                            if (k == 0) cate3GuidFirst = cate3Guid;
                        }
                        prd.cateGuid = (Guid)(cate3GuidFirst.ToGuid());  //类别                 

                        
                        // product status
                        if (bLoadTestSale)
                        {
                            prd.wnstat = (int)ConfigParamter.PrdSate.preSale;
                        }
                        else
                        {
                            prd.wnstat = (int)ConfigParamter.PrdSate.sale; //销售区
                        }

                        // batch #
                        prd.UpLoadBatchNo = iProductUploadBatchNo;

                        // add product
                        int count = prdMgr.Add(prd);
                        
                        bIsNewProduct = true;
                    }
                    else
                    {
                        prd.prdGuid = ckbPrdID.ToGuid().Value;//产品id
                        bIsNewProduct = false;
                    }
                    
                    #endregion

                    #region Product ship to countries
                    
                    // add product ship to country 
                    string[] sShipToCountryArr = ShiptoCountries.Split(',');
                    foreach (string sShipToCountry in sShipToCountryArr)
                    {
                        string sCountryName = sShipToCountry.ToUpper();
                        int  iCountryID = -1;
                        string sCountryCode = string.Empty;

                        bool bFreeShip = sCountryName.IndexOf("FREE") == -1 ? false : true;
                        sCountryName = sCountryName.Replace("FREE", "").Trim();

                        CountryMgr mgrCountry = new CountryMgr();

                        mgrCountry.GetCountryInfoByName(sCountryName, out iCountryID, out sCountryCode);

                        if ( iCountryID == -1)  { 
                            error = "Line: " + (i+1).ToString() +  " Ship to country:"  +  sShipToCountry + " does not exist!";
                            return error;
                        }

                        // insert product ship to country
                        AddProductShipToCountry(prd.prdGuid.ToString(), userGuid, iCountryID, sCountryCode, sCountryName, bFreeShip, iProductUploadBatchNo);
                    }


                    #endregion

                    #region 规格信息

                    string tweebaaSku = CommUtil.CreateTweebaaSKU(); //dt.Rows[i]["Tweebaa SKU Number"].ToString();
                    string supplierSku = dt.Rows[i]["Supplier SKU Number (Required)"].ToString();
                    string specsType = dt.Rows[i]["Specs Type"].ToString();
                    string specsName = dt.Rows[i]["Specs Name"].ToString();
                    string color = dt.Rows[i]["Color"].ToString();

                    //string proweight = dt.Rows[i]["Product Weight - lbs# (excluding pkg)"].ToString();
                    string proweight = dt.Rows[i]["Product Weight - lbs. (excluding pkg)"].ToString();
                    string prolength = dt.Rows[i]["Product Length - inches (excluding pkg)"].ToString();
                    string prowidth = dt.Rows[i]["Product Width - inches (excluding pkg)"].ToString();
                    string proheight = dt.Rows[i]["Product Height - inches (excluding pkg)"].ToString();

                    decimal ?proboxweight = dt.Rows[i]["Master Carton Weight - lbs"].ToString().ToDecimal();
                    string proboxlength = dt.Rows[i]["Master Carton Length- inches"].ToString();
                    string proboxwidth = dt.Rows[i]["Master Carton Width- inches"].ToString();
                    string proboxheight = dt.Rows[i]["Master Carton Height- inches"].ToString();

                    //string packageweight = dt.Rows[i]["Package Weight lbs#"].ToString();
                    string packageweight = dt.Rows[i]["Package Weight lbs."].ToString();
                    string packagelength = dt.Rows[i]["Package Length - inches"].ToString();
                    string packagewidth = dt.Rows[i]["Package Width - inches"].ToString();
                    string packageheight = dt.Rows[i]["Package Height - inches"].ToString();

                    string UPCCode = dt.Rows[i]["UPC code"].ToString();
                    string wholesaleprice = dt.Rows[i]["Wholesale price"].ToString();

                    string prostock = dt.Rows[i]["Available Inventory level"].ToString();//库存

                    decimal shippingCost = dt.Rows[i]["Supply Shipping Cost (base on sku) If FREE shipping, input 0"].ToString().ToDecimal();
                    int isFreeShip = dt.Rows[i]["Customer Free Shipping Yes or No"].ToString().ToUpper() == "YES" ? 1 : 0;                          

                    proRulesMgr ruleMgr = new proRulesMgr();
                    proRules rules = new proRules();
                    rules.ShipFrom_ID = ShipFrom_ID;
                    rules.prosku = tweebaaSku;   
                    rules.suppliersku = supplierSku;
                    rules.proid = prd.prdGuid.ToString();
                    rules.userid = userGuid;
                    rules.procolor = color;

                    rules.proweight = proweight;
                    rules.prolength = prolength;
                    rules.prowidth = prowidth;
                    rules.proheight = proheight;

                    rules.proboxweight = proboxweight;
                    rules.proboxlength = proboxlength;
                    rules.proboxwidth = proboxwidth;
                    rules.proboxheight = proboxheight;


                    rules.packageweight = packageweight;
                    rules.packagelength = packagelength;
                    rules.packagewidth = packagewidth;
                    rules.packageheight = packageheight;

                    
                    rules.prostock = prostock;
                    rules.ShipPartner_ID = ShipPartner_ID;
                    rules.proruletitle = getRulesID(specsType, iProductUploadBatchNo);//规格名称
                    rules.prorule = specsName;//规格属性值
                    rules.UpLoadBatchNo = iProductUploadBatchNo; // upload batch number
                    rules.isCustomerFreeShip = isFreeShip;
                    rules.SupplierShipFee = shippingCost;
                    rules.WholeSalePrice = wholesaleprice;
                    rules.barcode = UPCCode;

                    int iNewRuleId =ruleMgr.Add(rules);
                    #endregion 

                    #region 价格   

                    Prdprice priceModel = new Prdprice();
                    priceModel.edttime = DateTime.Now;
                    priceModel.p1 = 1;
                    priceModel.p2 = 10000;
                    priceModel.prdguid = prd.prdGuid;
                    if (bLoadTestSale)
                    {
                        priceModel.price = dt.Rows[i]["Test-Sale price (USD)"].ToString().TrimStart('$').ToDecimal();
                    }
                    else
                    {
                        priceModel.price = dt.Rows[i]["Tweebaa price"].ToString().TrimStart('$').ToDecimal();
                    }
                    priceModel.ruleid = iNewRuleId;
                    priceModel.UpLoadBatchNo = iProductUploadBatchNo;
                    PrdPriceMgr priceMgr = new PrdPriceMgr();
                    priceMgr.Add2(priceModel);
                    #endregion

                    #region 供货单基本信息
                    if (bIsNewProduct)
                    {
                        Twee.Model.proDetails model = new Twee.Model.proDetails();
                        model.proid = prd.prdGuid.ToString();
                        model.proright = 1;
                        model.proaddress = "1";
                        model.proexample = 1;
                        model.proexampleprice = null;
                        model.prosmallnum = "1";
                        model.promodelnum = " ";
                        model.prostock = 1;
                        model.stocknum = null;
                        model.state = 2;
                        model.userid = prd.userGuid.ToString();
                        model.UpLoadBatchNo = iProductUploadBatchNo;
                        proDetailsMgr proDetailsMgr = new Mgr.proDetailsMgr();
                        proDetailsMgr.Add2(model);
                    }
                    #endregion

                    #region 图片

                    if (bIsNewProduct)
                    {
                        WebClient web = new WebClient();

                        bool bIsImageURL = true;
                        string imagesURL = dt.Rows[i]["Product Image (URL)"].ToString().Trim();
                        string imagesFile = dt.Rows[i]["Product Image (file)"].ToString().Trim();

                        string images = imagesURL;
                        if (imagesFile != "")
                        {
                            images = imagesFile;
                            bIsImageURL = false;
                        }
                        

                        string[] fileImgs = images.Split(',');
                        for (int j = 0; j < fileImgs.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(fileImgs[j]))
                            {
                                string date = DateTime.Now.ToString("yyyyMMdd");
                                string app = fileImgs[j].Trim();
                                if (!bIsImageURL)
                                {
                                    app = localhosturl + "upload/LocalImage/" + app;
                                }
                                
                                string imgName = prd.prdGuid + "_" + j + ".jpg";

                                //string imgFolder = "E:\\TweeBaa_En\\upload\\downImg\\" + prd.prdGuid;
                                //string filename = "E:\\TweeBaa_En\\upload\\downImg\\" + prd.prdGuid + "\\" + imgName;

                                string imgFolder = "D:\\WorkSpace\\TweeBaaEn\\TweebaaWebApp\\upload\\downImg\\" + prd.prdGuid;
                                string filename = "D:\\WorkSpace\\TweeBaaEn\\TweebaaWebApp\\upload\\downImg\\" + prd.prdGuid + "\\" + imgName;

                                //string imgFolder = "D:\\WorkSpace\\TweeBaaEn\\TweebaaWebApp\\upload\\UploadImg\\big\\" + date;
                                //string filename = "D:\\WorkSpace\\TweeBaaEn\\TweebaaWebApp\\upload\\UploadImg\\big\\" + date + "\\" + imgName; 


                                if (!Directory.Exists(imgFolder))
                                {
                                    Directory.CreateDirectory(imgFolder);
                                }

                                //UploadImg/big/20141211/20141211200125_1701.png
                                //UploadImg/20141130/51_eva.jpg
                                Twee.Model.File file = new Model.File();
                                file.prdguid = prd.prdGuid;
                                file.prtguid = prd.prdGuid;
                                file.idx = j;
                                file.fileurl = "/upload/UploadImg/big/" + date + "/" + imgName; //产品图片
                                file.addtime = DateTime.Now;
                                file.UploadImageURL = app;
                                file.UpLoadBatchNo = iProductUploadBatchNo;
                                fileMgr.Add(file);
                                web.DownloadFile(app, filename);

                            }
                        }
                    }
                   
                    #endregion                 

                }
                catch (Exception ex)
                {
                    //throw ex;
                    log.Error("【" + userName + "】" + "导入错误:第【" + flag.ToString() + " 】行：" + ex.Message);
                    error += "导入错误:第【" + flag.ToString() + "】行：" + ex.Message + " <br />";
                }
            }
            return error;
        }


  

        //把Excel里的数据转换为DataTable，并返回DataTable
        public DataTable ExcelToDataTableNew(string excelPath)
        {
            try
            {
                //Microsoft.ACE.OLEDB.12.0，Extended Properties=Excel 12.0
                //string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件
                string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
                                
//此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串) //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。   "IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。 

                System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strCon);
                string strCom = "SELECT * FROM [Supplier Upload form$]";
                DataTable dt;
                try
                {
                    Conn.Open();
                    DataTable dtDATAExcel = new System.Data.DataTable();
                    DataTable dtDATA = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string name = dtDATA.Rows[0][2].ToString().Trim();
                    System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strCom, Conn);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "[Supplier Upload form$$]");
                    Conn.Close();
                    dt = ds.Tables[0];
                }
                catch (Exception err)
                {
                    return null;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ReadExcelIntoDataTable(string sFileName, string sSheetName, out string sErrMsg ) 
        {
            sErrMsg = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                string sConnString = "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + sFileName + ";";
                string sSql = "SELECT * FROM [" + sSheetName + "$]";
                System.Data.Odbc.OdbcDataAdapter y = new System.Data.Odbc.OdbcDataAdapter(sSql, sConnString);
                y.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                return null;
            }
        }
        
        
        // insert product ship to country
        private int  AddProductShipToCountry(string sPrdGuid, string sUserGuid, int iCountryID, string sCountryCode, string sCountryName, bool bFreeShip, int iProductUploadBatchNo)
        {
            int iAffectedRow = 0;
            
            // check if the recorded has alread existed
            string sSql = "select count(*) from wn_ProductShipToCountry where prdGuid='" + sPrdGuid +"' and userGuid ='" + sUserGuid + "' and Country_ID =" + iCountryID.ToString();
            int iCnt = DbHelperSQL.QueryCount(sSql);
            
            // insert a new one if not exist
            if (iCnt == 0)
            {
                sSql= "insert into wn_ProductShipToCountry(prdGuid, userGuid, Country_ID, Country_Code, Country_Name, ProductShipToCountry_IsFree, ProductShipToCountry_CreateDate, ProductUploadBatchNo) " +
                        " VALUES(" + 
                        "'" + sPrdGuid + "'," +
                        "'" + sUserGuid + "'," +
                        iCountryID.ToString() + "," +
                        "'" + sCountryCode + "'," +
                        "'" + sCountryName + "'," +
                        (bFreeShip?"1":"0") +  "," +
                        "getdate()," +
                        iProductUploadBatchNo.ToString() + ")";
                iAffectedRow = DbHelperSQL.ExecuteSql(sSql);
            }

            return iAffectedRow;
        }


        //添加供应信息
        private int AddShipInfo(string ShipFrom_CompanyName, string ShipFrom_Address1, string ShipFrom_ContactName, string ShipFrom_Phone, string ShipFrom_Email, string ShipForm_WebSite, string ShipFrom_City, string Province_ID, string ShipFrom_Zip, string Country_ID, string Supplier_Address, string userguid, string SupperID, int iProductUploadBatchNo, string ShiptoCountries, out bool bIsNewShipFrom)
        {

            string sqlCount = "select ShipFrom_ID,ShipFrom_CompanyName from wn_ShipFrom where ShipFrom_CompanyName=N'" + CommUtil.Quo(ShipFrom_CompanyName) + "' and  ShipFrom_Phone='" + ShipFrom_Phone + "'";
            DataSet dsCount = DbHelperSQL.Query(sqlCount);
            if (dsCount != null && dsCount.Tables.Count > 0 && dsCount.Tables[0].Rows.Count > 0)
            {
                int iOldShipFromID = dsCount.Tables[0].Rows[0]["ShipFrom_ID"].ToString().ToInt();
                bIsNewShipFrom = false;
                return iOldShipFromID;
            }

            int iNewShipFromID = DbHelperSQL.GetSeq("ShipFrom");
            string sql = "insert into dbo.wn_ShipFrom (ShipFrom_ID, ShipFrom_CompanyName,ShipFrom_Address1,ShipFrom_Address2,ShipFrom_ContactName,ShipFrom_Phone,ShipFrom_Email,ShipFrom_WebSite,ShipFrom_City,Province_ID,ShipFrom_Zip,Country_ID, ShipFrom_AddDate,ShipFrom_IsActive,userguid,Supplier_ID, ShipFrom_ShipToCountries, ProductUploadBatchNo) values (" + iNewShipFromID + ",N'" + CommUtil.Quo(ShipFrom_CompanyName) + "',N'" + CommUtil.Quo(ShipFrom_Address1) + "','',N'" + CommUtil.Quo(ShipFrom_ContactName) + "','" + ShipFrom_Phone + "','" + ShipFrom_Email + "','" + ShipForm_WebSite + "','" + ShipFrom_City + "','" + Province_ID + "','" + ShipFrom_Zip + "','" + Country_ID + "', GETDATE(),1,'" + userguid + "','" + SupperID + "','"  + ShiptoCountries +"',"  + iProductUploadBatchNo.ToString() + ");";
            int resu = DbHelperSQL.ExecuteSql(sql);
            bIsNewShipFrom = true;
            return iNewShipFromID;
        
        }



        //添加ShipMethod
        private bool AddShipMethod(int iShipFromID, string sShipFromName, int iProductUploadBatchNo, string sShipToCountries, out string sErrMsg)
        {
            int iShipMethodID = -1;
            sErrMsg = string.Empty;

            StringBuilder sSql = new StringBuilder();
            sSql.Append("select a.ShipMethod_ID from wn_ShipMethod a inner join wn_ShipFrom2ShipMethod b on a.ShipMethod_ID = b.ShipMethod_ID");
            sSql.Append(" where a.ShipMethod_Name =N'" + CommUtil.Quo(sShipFromName) + "'") ;
            sSql.Append("  and b.ShipFrom_ID=" + iShipFromID.ToString());

            DataSet dsCount = DbHelperSQL.Query(sSql.ToString());
            if (dsCount != null && dsCount.Tables.Count > 0 && dsCount.Tables[0].Rows.Count > 0)
            {
                iShipMethodID  = dsCount.Tables[0].Rows[0]["ShipMethod_ID"].ToString().ToInt();
                return true;
            }

            // Add new ship method for all countries
            string[] sShipToCountryArr = sShipToCountries.Split(',');
            CountryMgr mgrCountry = new CountryMgr();

            foreach (string sShipToCountry in sShipToCountryArr)
            {
                string sCountryName = sShipToCountry.ToUpper();
                int iCountryID = -1;
                string sCountryCode = string.Empty;

                bool bFreeShip = sCountryName.IndexOf("FREE") == -1 ? false : true;
                sCountryName = sCountryName.Replace("FREE", "").Trim();

                mgrCountry.GetCountryInfoByName(sCountryName, out iCountryID, out sCountryCode);

                if (iCountryID == -1)
                {
                    sErrMsg = " Ship to country:" + sCountryName + " does not exist!";
                    return false;
                }

                // ship method
                sSql.Clear();
                iShipMethodID = DbHelperSQL.GetSeq("ShipMethodID");
                sSql.Append(" INSERT INTO wn_ShipMethod (ShipMethod_ID, ShipPartner_ID, ShipCarrier_ID, ShipMethod_ServiceID, ShipMethod_Name, ShipMethod_ShipToCountryID, ShipMethod_IsFree, ShipMethod_IsActive, ProductUploadBatchNo)");
                sSql.Append(" VALUES( ");
                sSql.Append(iShipMethodID.ToString() +  "," +
                    ((int)ConfigParamter.ShipPartner.DropShipper).ToString() + "," +
                    "1,0,N'" + CommUtil.Quo(sShipFromName) + "'," + 
                    iCountryID.ToString() + "," +
                    (bFreeShip?"1,": "0,") + 
                    "1," + 
                    iProductUploadBatchNo.ToString() + ")");
                int resu = DbHelperSQL.ExecuteSql(sSql.ToString());

                // insert Shipfrom2ShipMethod
                sSql.Clear();
                sSql.Append("insert into wn_ShipFrom2ShipMethod(ShipFrom_ID, ShipMethod_ID, ProductUploadBatchNo) values(" + 
                    iShipFromID.ToString() + "," + 
                    iShipMethodID.ToString() + "," + 
                    iProductUploadBatchNo.ToString() + ")");
                resu = DbHelperSQL.ExecuteSql(sSql.ToString());
            }

            //int iShipMethodIDUS = -1;
            //int iShipMethodIDCA = -1;

            //if (iShipMethodID == -1)
            //{
            //    // USA
            //    sSql.Clear();
            //    iShipMethodIDUS = DbHelperSQL.GetSeq("ShipMethodID");
            //    sSql.Append(" INSERT INTO wn_ShipMethod (ShipMethod_ID, ShipPartner_ID, ShipCarrier_ID, ShipMethod_ServiceID, ShipMethod_Name, ShipMethod_ShipToCountryID, ShipMethod_IsFree, ShipMethod_IsActive, ProductUploadBatchNo)");
            //    sSql.Append(" VALUES( ") ;
            //    sSql.Append(iShipMethodIDUS.ToString() + ",3,1,0,'" + CommUtil.Quo(sShipFromName) + "', 1,0,1," + iProductUploadBatchNo.ToString() + ")");
            //    int resu = DbHelperSQL.ExecuteSql(sSql.ToString());

            //    // insert Shipfrom2ShipMethod USA
            //    sSql.Clear();
            //    sSql.Append("insert into wn_ShipFrom2ShipMethod(ShipFrom_ID, ShipMethod_ID, ProductUploadBatchNo) values(" + iShipFromID.ToString() + "," + iShipMethodIDUS.ToString() + "," + iProductUploadBatchNo.ToString() + ")");
            //    resu = DbHelperSQL.ExecuteSql(sSql.ToString());
                
            //    // Canada
            //    iShipMethodIDCA = DbHelperSQL.GetSeq("ShipMethodID");
            //    sSql.Clear();
            //    sSql.Append(" INSERT INTO wn_ShipMethod (ShipMethod_ID, ShipPartner_ID, ShipCarrier_ID, ShipMethod_ServiceID, ShipMethod_Name, ShipMethod_ShipToCountryID, ShipMethod_IsFree, ShipMethod_IsActive, ProductUploadBatchNo)");
            //    sSql.Append(" VALUES( ");
            //    sSql.Append(iShipMethodIDCA.ToString() + ",3,1,0,'" + CommUtil.Quo(sShipFromName) + "', 2,0,1," + iProductUploadBatchNo.ToString() + ")");
            //    resu = DbHelperSQL.ExecuteSql(sSql.ToString());

            //    // insert Shipfrom2ShipMethod Canada
            //    sSql.Clear();
            //    sSql.Append("insert into wn_ShipFrom2ShipMethod(ShipFrom_ID, ShipMethod_ID, ProductUploadBatchNo) values(" + iShipFromID.ToString() + "," + iShipMethodIDCA.ToString() + "," + iProductUploadBatchNo.ToString() + ")");
            //    resu = DbHelperSQL.ExecuteSql(sSql.ToString());

            //}
            return true;
        }

        
        //判断用户
        private string CheckUser(string companyNmae, string email,string phone, string Country_ID)
        {
            string strSql = "select * from wn_user where username =N'" + CommUtil.Quo(companyNmae) + "' or email='" + email + "'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0]["guid"].ToString();
            }

            else
            {
                // insert user
                Guid guid = Guid.NewGuid();
                string strSql2 = "insert into wn_user(guid,pwd,username,regtime,acttime,edttime,wnstat,email,phone,countryId,knowwayid) values('" + guid.ToString() + "','6E7FDC67A9EF4C9CF3F53A3DDD84E109',N'" + CommUtil.Quo(companyNmae) + "',GETDATE(),GETDATE(),GETDATE(),1,N'" + email + "','" + phone + "'," + Country_ID + ",1)";
                DbHelperSQL.ExecuteSql(strSql2);

                // insert user grade
                strSql2 = "insert into wn_usergrade(guid, userguid, publishgrade, reviewgrade, sharegrade, publishintegral,reviewintegral,shareintegral, " +
                    "publishcount,reviewhcount,sharecount,updatetime,tweebuck,shopingPoint,pending_tweebuck)" +
                    "VALUES (NEWID(), '" + guid.ToString() + "', 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,getdate(),0.0 ,0.0,0.0)";
                DbHelperSQL.ExecuteSql(strSql2);

                return guid.ToString();
            }
        }

        //添加产品类别
        private bool AddPrdCate(string prdGuid, string cateGuid1, string cateGuid2,string cateGuid3, int iProductUpLoadBatchNo)
        {
            string sql = "insert into wn_prd2cate values('" + prdGuid + "','" + cateGuid1 + "','" + cateGuid2 + "','" + cateGuid3 + "'," + iProductUpLoadBatchNo.ToString() + ")";
            int resu = DbHelperSQL.ExecuteSql(sql);
            return resu > 0 ? true : false;
        
        }

        //得到国家id
        private string getCountryID(string sCountry)
        {
            CountryMgr mgr = new CountryMgr();
            int iCountryID = 0;
            string sCountryCode = string.Empty;

            mgr.GetCountryInfoByName(sCountry, out iCountryID, out sCountryCode);
            return iCountryID.ToString();

        }

        //得到省份id
        // need to search by country id and short name 
        private string getProvinceID(int intCountryID, string province)
        {
            ProvinceMgr mgr = new ProvinceMgr();
            DataSet ds = mgr.GetList("CountryId="+ intCountryID.ToString() + " and (proName=N'"+province+"' or proShortName=N'" + province + "')");
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0]["ProID"].ToString();
            }
            return "";
        }

        ////得到类别id
        //private string getPrdCateID(string cateName,int layer)
        //{
        //    PrdCateMgr mgr = new PrdCateMgr();
        //    DataTable dt = mgr.MgeGetPrdCateList(" name='" + CommUtil.Quo(cateName.Trim()) + "' and layer=" + layer);
        //    if (dt!=null&&dt.Rows.Count>0)
        //    {
        //        return dt.Rows[0]["guid"].ToString();
        //    }
        //    return "00000000-0000-0000-0000-000000000000";
        
        //}


        private void GetPrdCateGuid(string cate1, string cate2, string cate3, out string cate1Guid, out string cate2Guid, out string cate3Guid)
        {
            // init
            cate1Guid = CommUtil.GetDummyGuid();
            cate2Guid = CommUtil.GetDummyGuid();
            cate3Guid = CommUtil.GetDummyGuid();

            // get first level category guid
            PrdCateMgr mgr = new PrdCateMgr();
            DataTable dt = mgr.MgeGetPrdCateList(" name=N'" + CommUtil.Quo(cate1.Trim()) + "' and layer=0");
            if (dt != null && dt.Rows.Count > 0)
            {
                cate1Guid = dt.Rows[0]["guid"].ToString();
            }

            // get second level category guid
            dt = mgr.MgeGetPrdCateList(" name=N'" + CommUtil.Quo(cate2.Trim()) + "' and layer=1 and prtguid='" + cate1Guid + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                cate2Guid = dt.Rows[0]["guid"].ToString();
            }

            // get third level category guid
            dt = mgr.MgeGetPrdCateList(" name=N'" + CommUtil.Quo(cate3.Trim()) + "' and layer=2 and prtguid='" + cate2Guid + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                cate3Guid = dt.Rows[0]["guid"].ToString();
            }
        }
   

        //得到规格id
        private int getRulesID(string name, int iProductUploadBatchNo)
        {

            if (name.Trim() == string.Empty) return 6; // blank specifications
            
            // check if the rule name has already existed
            string sql = "select id from wn_proDetailSupplyType where prodetailType=N'" + CommUtil.Quo(name) + "'";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0]["id"].ToString().ToInt();
            }

            // insert this name
            sql = "insert into wn_proDetailSupplyType (prodetailType, remark) values(" +
                   "N'" + CommUtil.Quo(name) + "'," +
                   "N'ProductUploadBatchNo:" + iProductUploadBatchNo.ToString() + "')";
            int iCnt = DbHelperSQL.ExecuteSql(sql);

            // retrieve the id
            sql = "select id from wn_proDetailSupplyType where prodetailType=N'" + CommUtil.Quo(name) + "'";
            ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["id"].ToString().ToInt();
            }

            return 6; // blank specifications
        }

        //判断产品是否已经存在
        // only check among current upload 
        private string checkPrd(string prdName,decimal supplyPrice, int iProductUploadBatchNo)
        {
            if (prdName=="")
            {
                return "";
            }
            PrdMgr mgr = new PrdMgr();
            //DataSet ds = mgr.GetList(" name='" + prdName + "' and supplyPrice=" + supplyPrice);
            DataSet ds = mgr.GetList(" name=N'" + CommUtil.Quo(prdName) + "' and ProductUploadBatchNo=" + iProductUploadBatchNo);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0]["prdGuid"].ToString();
            }
            return "";
        }


        // convert Excel file to DataTable by Open XML 2.0
        public DataTable ExcelToDataTableOpenXML(string sFileName, string sSheetName, out string sErrMsg)
        {
            sErrMsg = string.Empty;
            DataTable dt = new DataTable();

            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(sFileName, false))
            {

                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();

                // get sheet id by sheet name
                string relationshipId = sheets.First(s => sSheetName.Equals(s.Name)).Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
 
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                foreach (Cell cell in rows.ElementAt(0))
                {
                    dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                }

                foreach (Row row in rows) //this will also include your header row...
                {
                    DataRow drTemp = dt.NewRow();

                    for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    {
                        string sValue = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i)).Trim();
                        drTemp[i] = sValue;
                    }
                    dt.Rows.Add(drTemp);
                }

            }
            dt.Rows.RemoveAt(0); // remove the first header row.
            return dt;
        }


        public string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            
            if (cell.CellValue == null)
            {
                // return blank if the sell value is null
                return string.Empty;
            }
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        #endregion

    }



}
