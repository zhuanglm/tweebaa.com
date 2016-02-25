using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Reflection;
using Twee.Comm;
using log4net;
using TweebaaWebApp.MasterPages;
using Twee.Model;
using Twee.Mgr;
using Newtonsoft.Json;
using System.Data;

namespace TweebaaWebApp.AjaxPages
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
            //}
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
                model.email = dic["email"].ToString();
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
                    ProvinceMgr provinceMgr = new ProvinceMgr();
                    List<Province> listProvince = provinceMgr.GetModelList(" CountryId=" + CountryId);
                    string data = JsonConvert.SerializeObject(listProvince);
                    Response.Write(data);
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