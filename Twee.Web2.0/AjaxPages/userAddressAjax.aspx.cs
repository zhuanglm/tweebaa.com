﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Reflection;
using Twee.Comm;
using log4net;
using TweebaaWebApp2.MasterPages;
using Twee.Model;
using Twee.Mgr;
using Newtonsoft.Json;
using System.Data;
using System.Net;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class userAddressAjax : BasePage
    {
        private Guid? userGuid;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            //if (isLogion == false)
            //{
            //    Response.Write("-1");
            //    return;
            //}
            //else
            //{
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string cartInfo = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
                action = dic["action"].ToString();
                if (action == "query")
                {
                    GetMyAddress();
                }
                if (action == "add")
                {
                    AddMyAddress();
                }
                else if (action == "delet")
                {
                    DeletMyAddress();
                }
                else if (action == "edit")
                {
                    EditMyAddress();
                }
                else if (action == "QueryAddressInfo")
                {
                    GetAddressInfo();
                }
                else if (action == "update")
                {
                    UpdateMyAddress();
                }
                else if (action == "area")
                {
                    GetArae();//获取地区
                }
                else if (action=="setdefault")
                {
                    SetDefault();//设置默认地址
                }
                else if (action == "QueryCityByZip")
                {
                    string zip = dic["zip"].ToString();
                    GetStateCityByZip(zip);
                }
            //}
        }
        //HttpUtility.UrlPathEncode
        private void GetStateCityByZip(string strZip)
        {
            //get it from database first
            UserAddressMgr mgr = new UserAddressMgr();
            DataSet ds = mgr.GetCityByZipcode(strZip);
            if(ds==null || ds.Tables[0].Rows.Count==0){
                //not found,then using google map API
                string sURL = "http://maps.googleapis.com/maps/api/geocode/json?address=" + HttpUtility.UrlPathEncode(strZip) + "&sensor=true";
                using (WebClient client = new WebClient())
                {
                    string s = client.DownloadString(sURL);
                    if (s.Length > 0)
                    {
                        dynamic result = JsonConvert.DeserializeObject(s);
                        if (result.status == "OK")
                        {
                            dynamic addr = result.results[0].address_components;
                            string locality = "";
                            string administrative_area_level_1 = "";
                            string country = "";
                            for (int i = 0; i < addr.Count; i++)
                            {
                                if (addr[i].types[0] == "sublocality_level_1") locality = addr[i].long_name;
                                if (locality.Length < 1 && addr[i].types[0] == "locality") locality = addr[i].long_name;
                                if (addr[i].types[0] == "administrative_area_level_1") administrative_area_level_1 = addr[i].long_name;
                                if (addr[i].types[0] == "country"){
                                    country = addr[i].short_name;
                                    if(country=="US") country="USA";
                                    if (country == "CA") country = "Canada";
                                }
                            }
                            mgr.AddZip2City( strZip, locality, administrative_area_level_1, country);

                            //Add this record to database

                            /*
                            string postal_code = addr[0].short_name;
                            string neighborhood = addr[1].short_name;*/
                            /*
                            string locality = addr[2].short_name;
                           // string administrative_area_level_2 = addr[3].short_name;
                            string administrative_area_level_1 = addr[4].short_name;
                            string country = addr[5].short_name;
                        
                             */
                            string data = locality + ":" + administrative_area_level_1 + ":" + country;
                            Response.Write(data);
                        }
                    }
                }
            }else{
                //show it from database
                 string data = ds.Tables[0].Rows[0]["CityName"] + ":" + ds.Tables[0].Rows[0]["State"] + ":" + ds.Tables[0].Rows[0]["Country"];
                 Response.Write(data);
            }
                /* 
{
   "results" : [
      {
         "address_components" : [
            {
               "long_name" : "L6C 0B8",
               "short_name" : "L6C 0B8",
               "types" : [ "postal_code" ]
            },
            {
               "long_name" : "Berczy Village",
               "short_name" : "Berczy Village",
               "types" : [ "neighborhood", "political" ]
            },
            {
               "long_name" : "Markham",
               "short_name" : "Markham",
               "types" : [ "locality", "political" ]
            },
            {
               "long_name" : "York Regional Municipality",
               "short_name" : "York Regional Municipality",
               "types" : [ "administrative_area_level_2", "political" ]
            },
            {
               "long_name" : "Ontario",
               "short_name" : "ON",
               "types" : [ "administrative_area_level_1", "political" ]
            },
            {
               "long_name" : "加拿大",
               "short_name" : "CA",
               "types" : [ "country", "political" ]
            }
         ],
         "formatted_address" : "加拿大安大略省万锦邮政编码: L6C 0B8",
         "geometry" : {
            "bounds" : {
               "northeast" : {
                  "lat" : 43.89702,
                  "lng" : -79.29141360000001
               },
               "southwest" : {
                  "lat" : 43.8951549,
                  "lng" : -79.29393
               }
            },
            "location" : {
               "lat" : 43.8959458,
               "lng" : -79.2932074
            },
            "location_type" : "APPROXIMATE",
            "viewport" : {
               "northeast" : {
                  "lat" : 43.8974364302915,
                  "lng" : -79.29132281970851
               },
               "southwest" : {
                  "lat" : 43.8947384697085,
                  "lng" : -79.29402078029152
               }
            }
         },
         "place_id" : "ChIJ4f09qgAq1YkRB_wxawVzvuc",
         "types" : [ "postal_code" ]
      }
   ],
   "status" : "OK"
}
   ;*/

            
        }
        /// <summary>
        /// 我的所有地址
        /// </summary>
        private void GetMyAddress()
        {
            UserAddressMgr mgr = new UserAddressMgr();
            DataTable dt = null;
            if (userGuid!=null)
            {               
                //List<Useraddress> listData = mgr.GetModelList(" userguid='"+userGuid+"'");
                //DataTable dt = mgr.GetList(" userguid='" + userGuid + "'").Tables[0];       
                dt = mgr.GetMyAddress(userGuid.Value);
                     
            }
            else
            {
                CookiesHelper cookie = new CookiesHelper();
                string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                string addressCartGudid = cookie.getCookie(keyAddress);
                if (!string.IsNullOrEmpty(addressCartGudid))
                {
                    dt = mgr.GetAddressByGuid(addressCartGudid);
                }               
            }
            string data = JsonConvert.SerializeObject(dt);
            Response.Clear();
            Response.Write(data);   
            
        
        }
 
        /// <summary>
        /// 编辑我的地址
        /// </summary>
        private void EditMyAddress()
        {
            UserAddressMgr mgr = new UserAddressMgr();
            if (dic["guid"].ToString()!=""&&dic["guid"].ToString()!="undefined")
            {
                string guid = dic["guid"].ToString();
                //List<Useraddress> listData = mgr.GetModelList(" guid='" + guid + "'");
                DataTable dt = mgr.GetList(" userguid='" + userGuid + "'").Tables[0];
                string data = JsonConvert.SerializeObject(dt);                
                Response.Clear();
                Response.Write(data);
            }
            else
            {
                Response.Write("");
            }
           

        }

        /// <summary>
        /// Get Address Info
        /// </summary>
        private void GetAddressInfo()
        {
            UserAddressMgr mgr = new UserAddressMgr();
            if (dic["guid"].ToString() != "" && dic["guid"].ToString() != "undefined")
            {
                string guid = dic["guid"].ToString();
                DataTable dt = mgr.GetList(" guid='" + guid + "'").Tables[0];
                string data = JsonConvert.SerializeObject(dt);
                Response.Clear();
                Response.Write(data);
            }
            else
            {
                Response.Write("");
            }
        }

        
        /// <summary>
        /// 添加我的地址
        /// </summary>
        private void AddMyAddress()
        {
            try
            {
                UserAddressMgr mgr = new UserAddressMgr();
                Useraddress model = new Useraddress();
                model.userguid = userGuid == null ? Guid.Empty : userGuid.Value;
                model.countyid = dic["countyid"].ToString().ToInt();
                model.provinceid = dic["provinceid"].ToString().ToInt();
                if (model.provinceid < 0)
                {
                    Response.Write("-1");//失败
                    return;
                }
                model.cityid = null;// dic["cityid"].ToString().ToInt();
                model.zip = dic["zip"].ToString();               
                model.address = dic["address"].ToString();
                model.username = dic["username"].ToString();
                model.phone = dic["phone"].ToString();
                model.tel = dic["tel"].ToString();
                model.isfirst = dic["isfirst"].ToString().ToInt();
                model.addtime = DateTime.Now;
                model.city = dic["city"].ToString();
                if (dic.ContainsKey("address2")) model.address2 = dic["address2"].ToString();
                else model.address2 = null;

                if (dic.ContainsKey("lastName")) model.lastName = dic["lastName"].ToString();
                else model.lastName = null;

                string addressGuid = string.Empty;
                if (dic.ContainsKey("email"))
                {
                    model.email = dic["email"].ToString();
                }
                else
                {
                    model.email = "";
                }
                bool b = mgr.Add(model, out addressGuid);
                if (b)
                {
                    if (!string.IsNullOrEmpty(addressGuid))
                    {
                        CookiesHelper cookie = new CookiesHelper();
                        string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                        string addressCartCookie = cookie.getCookie(keyAddress);  
                        if (cookie.createCookie(keyAddress, addressGuid, 30))
                        {
                            //Session["userAddress"] = addressGuid;
                            Response.Write("1");//成功
                            return;
                        }
                    }
                    Response.Write("1");//成功
                    return;
                }
                Response.Write("0");//失败
            }
            catch (Exception)
            {               
                Response.Write("0");
            }           
        
        }
        /// <summary>
        /// 删除我的地址
        /// </summary>
        private void DeletMyAddress()
        {
            UserAddressMgr mgr = new UserAddressMgr();
            Guid guid = dic["guid"].ToString().ToGuid().Value;

            Useraddress model = mgr.GetModel(guid);

            if (model.isfirst == 1)
            {
                // cannot delete default address
                Response.Write("-2");
                return;
            }

            bool b = mgr.Delete(guid);
            if (b)
            {
                Response.Write("1");
                return;
            }
            Response.Write("0");

        }
        /// <summary>
        /// 修改我的地址
        /// </summary>
        private void UpdateMyAddress()
        {
            UserAddressMgr mgr = new UserAddressMgr();          
            Useraddress model = new Useraddress();
            Guid guid = dic["guid"].ToString().ToGuid().Value;
            model.guid = guid;
            model.userguid = userGuid == null ? Guid.Empty : userGuid.Value;
            model.countyid = dic["countyid"].ToString().ToInt();           
            model.provinceid = dic["provinceid"].ToString().ToInt();
            if (model.provinceid < 0)
            {
                Response.Write("-1");//失败
                return;
            }
            model.cityid = null;// dic["cityid"].ToString().ToInt();
            model.zip = dic["zip"].ToString();
            model.address = dic["address"].ToString();
            model.username = dic["username"].ToString();
            model.phone = dic["phone"].ToString();
            model.tel = dic["tel"].ToString();
            model.isfirst = dic["isfirst"].ToString().ToInt();
            model.addtime = DateTime.Now;
            model.city = dic["city"].ToString();
            
            if (dic.ContainsKey("address2")) model.address2 = dic["address2"].ToString();
            else model.address2 = null;

            if (dic.ContainsKey("lastName")) model.lastName = dic["lastName"].ToString();
            else model.lastName = null;
            if (dic.ContainsKey("email"))
            {
                model.email = dic["email"].ToString();
            }
            else
            {
                model.email = "";
            }
            bool b = mgr.Update(model);
            if (b)
            {
                Response.Write("1");
                return;
            }
            Response.Write("0");

        }

        /// <summary>
        /// 设置为默认地址
        /// </summary>
        private void SetDefault()
        {
            UserAddressMgr mgr = new UserAddressMgr();
            Guid guid = dic["guid"].ToString().ToGuid().Value;
            bool b = mgr.SetDefault(guid,userGuid.Value);
            if (b)
            {
                Response.Write("1");
                return;
            }
            Response.Write("0");

        }

        /// <summary>
        /// 获得地区列表
        /// </summary>
        private void GetArae()
        {          
            string layer = dic["layer"].ToString();
            Response.Clear();
            if (layer == "0")
            {
                CountryMgr country = new CountryMgr();
                List<Country> listCountry = country.GetModelList("");
                string data = JsonConvert.SerializeObject(listCountry);
                Response.Write(data);
                return;
            }
            if (layer=="1")
            {
                if (dic.ContainsKey("countryId"))
                {
                    string CountryId = dic["countryId"].ToString();
                    if (CountryId == "undefined")
                    {
                        Response.Write("");
                    }
                    else
                    {
                        ProvinceMgr provinceMgr = new ProvinceMgr();
                        List<Province> listProvince = provinceMgr.GetModelList(" CountryId=" + CountryId);
                        string data = JsonConvert.SerializeObject(listProvince);
                        Response.Write(data);
                    }
                }
                else
                {
                    Response.Write("");
                }
               return;
            }
            else if (layer=="2")
            {
                string proId = dic["proid"].ToString();
                CityMgr cityMgr = new CityMgr();
                List<City> listCity = cityMgr.GetModelList(" ProID=" + proId );
                string data = JsonConvert.SerializeObject(listCity);
                Response.Write(data);
                return;
            }           
        
        }

      
    }
}