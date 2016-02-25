using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
using Twee.Model;

namespace TweebaaWebApp2.Product
{
    public partial class ShareProduct : System.Web.UI.Page
    {
        public string strProductName="";
        public string strImgSrc = "";
        public string strPrdDesc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(Request["id"])) {
                Response.Redirect("../index.aspx");
                Response.End();
            }

            string strReferer = Request.Headers["Referer"];

            Twee.Comm.CommHelper.WrtLog("href=" + strReferer);

            string sId = Request["id"].Trim();

            string sShareId = string.Empty;
            string sPrdId = Twee.Comm.CommUtil.GetUrlPrdId(sId, out sShareId);

            Guid sPrdGuid = (Guid)CommUtil.ToGuid(sPrdId);
            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();

            FileMgr fileMgr = new FileMgr();
            List<Twee.Model.File> listFile = fileMgr.GetModelList("prdguid='" + sPrdGuid + "'");

            Prd prdModel = mgr.GetModel(sPrdGuid);
            strProductName = prdModel.name;
            if (listFile[0].fileurl.Length > 0 && listFile[0].fileurl.Substring(0, 1) == "/")
            {
                strImgSrc = "https://tweebaa.com" + listFile[0].fileurl;
            }
            else
            {
                strImgSrc = "https://tweebaa.com/" + listFile[0].fileurl;
            }
            //strImgSrc = "https://tweebaa.com" + listFile[0].fileurl; 
            strPrdDesc = prdModel.txtjj;
            
            string sUrl = "../index.aspx";
            if (prdModel.wnstat == (int)(ConfigParamter.PrdSate.review))
            {
                sUrl = "submitReview.aspx?id=" + sId;
            }
            else if (prdModel.wnstat == (int)(ConfigParamter.PrdSate.preSale))
            {
                sUrl = "presaleBuy.aspx?id=" + sId;
            }
            else if (prdModel.wnstat == (int)(ConfigParamter.PrdSate.sale))
            {
                sUrl = "saleBuy.aspx?id=" + sId;
            }
            //Add by Long 2016/01/11 如果当前不是从别的网站链接过来的，则不用跳转
            //To Fix google plus share bug
            if (string.IsNullOrEmpty(strReferer) || strReferer.Length < 10)
            {

            }
            else
            {
                Response.Redirect(sUrl);
            }
        }
    }
}
    //*
 //    * 
 //    * select a.name, b.userguid, b.prdguid, b.sharetype, d.ShareGuid, b.VisitCountSum, isnull(c.SoldQuantitySum, 0) as SoldQuantitySum
//from wn_prd a 
//inner join vw_ProductShareVisitCountSum b on a.prdguid = b.prdGuid
//left join vw_ProductShareSoldQuantitySum c on c.userguid = b.userGuid and c.prdguid=b.prdguid and c.sharetype=b.sharetype
//left join vw_ProductShareLastShareGuid d on d.userguid = b.userGuid and d.prdguid=b.prdguid and d.sharetype=b.sharetype
//     * /
