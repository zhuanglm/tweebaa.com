using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using log4net;
using System.Web.Script.Serialization;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using TweebaaWebApp2.MasterPages;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class FavoriteAjax : BasePage
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string info = sr.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(info);
            if (dic["action"]!=null)
            {
                action = dic["action"].ToString();
                if (action == "add")
                {
                    AddFavoirte();
                }
                if (action == "add_collage_favorite")
                {
                    AddCollageFavoirte();
                }
                else if (action == "query")
                {
                    HomeFavoirte();
                }
                else if (action == "query_collage")
                {
                    HomeCollageFavoirte();
                }
                else if (action == "querysale")
                {
                    HomeCollectionForSale();
                }
                else if (action == "queryhomecount")
                {
                    HomeFavoirteCount();
                }
                else if (action == "queryhomecount_collage")
                {
                    HomeCollageFavoirteCount();
                }
                else if (action == "delete")
                {
                    DeleteFavoirte();
                }
                else if (action == "deleteByUserPrd")
                {
                    DeleteFavoirteByUserPrd();
                }
            }
           
        }

        private void AddCollageFavoirte()
        {
            try
            {
                Response.Clear();
                if (dic["id"] != null && !string.IsNullOrEmpty(dic["id"].ToString()))
                {
                    Guid? userGuid = CommUtil.IsLogion();
                    if (userGuid != null)
                    {
                        bool addResu = true;
                        FavoriteMgr mgr = new FavoriteMgr();
                        string id = dic["id"].ToString();
                        var ids = id.Split(',');
                        for (int i = 0; i < ids.Length; i++)
                        {
                            Favorite favorite = new Favorite();
                            favorite.CollageDesign_ID = int.Parse(dic["id"].ToString());
                            favorite.Sourcetype = 2;

                            bool isExit = mgr.CollageFavoriteExists(favorite.CollageDesign_ID, userGuid.Value);
                            if (isExit == false)
                            {
                                favorite.edttime = DateTime.Now;
                                favorite.userguid = userGuid.Value;
                                addResu = mgr.Add_CollageDesign_Favorite(favorite);
                            }
                        }
                        if (addResu == true)
                        {
                            Response.Write("success");
                            return;
                        }
                        else
                        {
                            Response.Write("false");
                            return;
                        }

                    }
                    else
                    {
                        Response.Write("-1");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("false");
            }

        }
        /// <summary>
        /// 添加收藏
        /// </summary>
        private void AddFavoirte()
        {
            try
            {
                Response.Clear();
                if (dic["id"] != null && !string.IsNullOrEmpty(dic["id"].ToString()))
                {
                    Guid? userGuid = CommUtil.IsLogion();
                    if (userGuid != null)
                    {
                        bool addResu = true;
                        FavoriteMgr mgr = new FavoriteMgr();                       
                        string id = dic["id"].ToString();
                        var ids = id.Split(',');
                        for (int i = 0; i < ids.Length; i++)
                        {                           
                            Favorite favorite = new Favorite();
                            favorite.prtguid = ids[i].ToString().ToGuid().Value;
                            bool isExit = mgr.Exists(favorite.prtguid, userGuid.Value);
                            if (isExit==false)
                            {
                                favorite.edttime = DateTime.Now;
                                favorite.userguid = userGuid.Value;
                                addResu = mgr.Add(favorite);     
                            }                                                   
                        }
                        if (addResu == true)
                        {
                            Response.Write("success");
                            return;
                        }
                        else
                        {
                            Response.Write("false");
                            return;
                        }                       
                      
                    }
                    else
                    {
                        Response.Write("-1");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("false");
            }
          
        
        }

        /// <summary>
        ///查询会员中心我的收藏列表
        /// </summary>
        private void HomeCollageFavoirte()
        {
            try
            {
                Guid? userGuid = CommUtil.IsLogion();
                if (userGuid != null)
                {
                    string state = dic["state"].ToNullString();
                    string beginTime = dic["begTime"].ToNullString();
                    string endTime = dic["endTime"].ToNullString();
                    int page = dic["page"].ToNullString().ToInt();
                    int startIndex = ConfigParamter.pageSize * (page - 1) + 1;
                    int endIndex = ConfigParamter.pageSize * page;
                    string orderby = "edttime desc";
                    FavoriteMgr mgr = new FavoriteMgr();
                    DataTable dt = mgr.GetMyCollageCollection2(userGuid.Value.ToString(), "", orderby, beginTime, endTime, startIndex, endIndex);
                    string data = JsonConvert.SerializeObject(dt);
                    Response.Clear();
                    Response.Write(data);
                }

            }
            catch (Exception)
            {
                Response.Write("false");
            }


        }

        /// <summary>
        ///查询会员中心我的收藏列表
        /// </summary>
        private void HomeFavoirte()
        {
            try
            {
                 Guid? userGuid = CommUtil.IsLogion();
                 if (userGuid != null)
                 {
                     string state = dic["state"].ToNullString();
                     string beginTime = dic["begTime"].ToNullString();
                     string endTime = dic["endTime"].ToNullString();
                     int page = dic["page"].ToNullString().ToInt();
                     int startIndex = ConfigParamter.pageSize * (page - 1) + 1;
                     int endIndex = ConfigParamter.pageSize * page;
                     string orderby = "edttime desc";
                     FavoriteMgr mgr = new FavoriteMgr();
                     DataTable dt = mgr.GetMyCollection2(userGuid.Value.ToString(), state, orderby, beginTime, endTime, startIndex, endIndex);  
                     string data = JsonConvert.SerializeObject(dt);
                     Response.Clear();
                     Response.Write(data);                   
                 }               
               
            }
            catch (Exception)
            {
                Response.Write("false");
            }


        }

        /// <summary>
        ///查询会员中心我的收藏总数
        /// </summary>
        private void HomeCollageFavoirteCount()
        {
            try
            {
                Guid? userGuid = CommUtil.IsLogion();
                if (userGuid != null)
                {
                    string state = dic["state"].ToNullString();
                    string beginTime = dic["begTime"].ToNullString();
                    string endTime = dic["endTime"].ToNullString();
                    FavoriteMgr mgr = new FavoriteMgr();
                    int recordCount = mgr.GetMyCollageCollectionCount(userGuid.Value.ToString(), state, beginTime, endTime);
                    int pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;
                    Response.Clear();
                    Response.Write(recordCount + "," + pageCount);
                }

            }
            catch (Exception)
            {
                Response.Write("0");
            }
        }

        /// <summary>
        ///查询会员中心我的收藏总数
        /// </summary>
        private void HomeFavoirteCount()
        {
            try
            {
                Guid? userGuid = CommUtil.IsLogion();
                if (userGuid != null)
                {
                    string state = dic["state"].ToNullString();
                    string beginTime = dic["begTime"].ToNullString();
                    string endTime = dic["endTime"].ToNullString();                     
                    FavoriteMgr mgr = new FavoriteMgr();
                    int recordCount = mgr.GetMyCollectionCount(userGuid.Value.ToString(), state, beginTime, endTime);                   
                    int pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;
                    Response.Clear();
                    Response.Write(recordCount + "," + pageCount);                    
                }

            }
            catch (Exception)
            {
                Response.Write("0");
            }
        }

        //删除我的收藏
        private void DeleteFavoirteByUserPrd()
        {
            try
            {
                Guid? userGuid = CommUtil.IsLogion();
                if (userGuid != null)
                {
                    string prdGuid = dic["id"].ToNullString();
                    FavoriteMgr mgr = new FavoriteMgr();
                    bool b = mgr.DeleteByUserPrd( (Guid)userGuid, prdGuid.ToGuid().Value);
                    Response.Clear();
                    if (b)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                       Response.Write("false");
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("false");
            }
        }



        //删除我的收藏
        private void DeleteFavoirte()
        {
            try
            {
                Guid? userGuid = CommUtil.IsLogion();
                if (userGuid != null)
                {
                    string prdGuid = dic["id"].ToNullString();                   
                    FavoriteMgr mgr = new FavoriteMgr();
                    bool b =  mgr.Delete(prdGuid.ToGuid().Value);
                    Response.Clear();
                    if (b)
                    {
                        Response.Write("1");
                    }
                    else
                    {
                        Response.Write("0");
                    } 
                }
            }
            catch (Exception)
            {
                Response.Write("false");
            }        
        }
        /// <summary>
        ///查询收藏（预售产品的信息：已预售金额、数量、预售结束时间）
        /// </summary>
        private void HomeCollectionForSale()
        {
            try
            {                
                string prdGuid = dic["id"].ToNullString();
                PrdMgr mgr = new PrdMgr();
                DataTable dt = mgr.GetHomeCollectionForSale(prdGuid);
                StringBuilder strResu = new StringBuilder();
              
                if (dt!=null&&dt.Rows.Count>0)
                {
                    DataRow dr = dt.Rows[0];
                    string prdguid = dr["prdguid"].ToString();
                    string count = dr["count"].ToString();
                    string summoney = dr["summoney"].ToString();
                    string reviewendtime = dr["reviewendtime"].ToString();
                    strResu.Append("[{");
                    strResu.Append("'summoney':'" + summoney + "',");
                    strResu.Append("'reviewendtime':'" + reviewendtime + "'");
                    strResu.Append("}]");
                }
                Response.Clear();
                Response.Write(strResu.ToString());                
            }
            catch (Exception)
            {
                Response.Write("false");
            }


        }
    }
}