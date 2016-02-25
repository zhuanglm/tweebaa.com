using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;
using log4net;
using System.Reflection;

namespace TweebaaWebApp.Product
{
    public partial class issue2 : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        Guid? uGuid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                uGuid = CommUtil.IsLogion();
                if (uGuid == null)
                {
                    Response.Write("<script>alert('Logged in to release products！')<script>");//未登录
                    return;
                }
            }          
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                PrdMgr mgr = new PrdMgr();
                Prd prd = new Prd();
                Guid prdGuid = new Guid();              

                string result = "1";
                string name = proName.Value.Trim();//产品名称 
                string cateGuid = "00000000-0000-0000-0000-000000000000";//产品类别
                string txtjl = tese.Value.Trim();//卖点特色        
                string txtinfo = CommHelper.GetStrDecode(txtDec.ToString());//产品详情
                string answer = proDes.ToString();//产品解决的问题   
                decimal estimateprice = txtPrice.Value.Trim().ToDecimal();//产品建议零售价                    
                string supplyPrice = txtSupplyPrice.Value.Trim().ToDecimal().ToString();//供货价格
                string prdSupplyPrice = ""; //供货报价区间 
                int isSupplier = 0;//是否供应商
                if (rdSupplierYes.Checked)
                {
                    isSupplier = 1;
                }
                int prdMoq = txtMoq.Value.Trim().ToInt();//最小起订量
                string supplierName = txtSupplierName.Value.Trim();//供应商名称
                string supplierWebsite = txtSupplierWebsite.Value.Trim();//供应商网址
                string supplierPhone = txtSupplierPhone.Value.Trim();//供应商电话
                string supplierEmail = txtSupplierEmail.Value.Trim();//供应商邮箱
                string supplierAddress = txtSupplierAddress.Value.Trim();//供应商地址

                string prdPic = img1.Src; //产品缩略图片 
                //string videoUrl = CommHelper.GetStrDecode(dic["prdVideo"].ToNullString());//产品视频
                string videoUrl = proWeb.Value.Trim();//产品视频(不要解密)

                mgr.AddPrd(0, name, estimateprice, videoUrl, "", "", "", cateGuid, uGuid.Value, "", txtjl, txtinfo, "", answer, prdPic, prdSupplyPrice, "", prdMoq, out result, out  prdGuid, supplyPrice, isSupplier, supplierName, supplierWebsite, supplierPhone, supplierEmail, supplierAddress,0);
                Response.Clear();
                if (result == "1" && prdGuid != null && prdGuid.ToString() != "")
                {                  
                    Response.Redirect("prdReview.aspx?id=" + result);
                }
                else
                {                    
                    Response.Write("<script>alert('Failed to publish！')<script>");
                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                Response.Write("error");
            } 
        }

        

    }
}