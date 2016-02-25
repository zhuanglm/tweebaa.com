using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using Twee.Comm;
namespace TweebaaWebApp.Mgr.proManager
{
    public partial class proEdit : System.Web.UI.Page
    {
        //public string _proDes = string.Empty;
        public string _proId = string.Empty;

        public string _firstCateSelected = string.Empty;//该产品的一级类别，因为首次加载页面会把所有的一级类别加载出来，这个是一次类别首次加载时的选中项
        public string _secondCateSelected = string.Empty;
        public string _thirdCateSelected = string.Empty;

        Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proEdit));

            if (string.IsNullOrEmpty(Request["id"]))
                return;
            else
                _proId = Request["id"].Trim();

            if (!IsPostBack) {
                //hidddlThridCate.Value = string.Empty;
                BindBasicInfo();
            }
            
        }

        private void BindBasicInfo()
        {
            var proModel = new Twee.Mgr.PrdMgr().GetModel(Guid.Parse(_proId));
            if (null != proModel)
            {
                hidProId.Value = proModel.prdGuid.ToString();
                txtProName.Text = proModel.name;
                txtTags.Text = proModel.txtTag;
                txtSupplyPrice.Text = proModel.supplyPrice.ToString() == "0" ? "" : proModel.supplyPrice.ToString();
                txtSuggestPrice.Text = proModel.estimateprice.ToString();
                txtSalePrice.Text = proModel.saleprice.ToString();
                txtBenefits.Text = proModel.question.ToString();
                txtFeature.Text = proModel.txtjj;
                //_proDes = Microsoft.JScript.GlobalObject.unescape(proModel.txtinfo);
                procaizhicontent.InnerHtml = Microsoft.JScript.GlobalObject.unescape(proModel.txtinfo);

                ckbisFreeShipping.Checked = proModel.IsFreeShipping == true ? true : false;
                ckbisComingSoon.Checked = proModel.IsComingSoon == true ? true : false;
                ckbisLimitedTime.Checked = proModel.IsLimitedTime == true ? true : false;
                //BindProCate(proModel.cateGuid.ToString());
            }
            
        }

        ///// <summary>
        ///// 首次加载时带出当前产品的类别
        ///// </summary>
        ///// <param name="cateId"></param>
        //private void BindProCate(string cateId) 
        //{
        //    ddlFirstCate.Items.Clear();
        //    ddlSecondCate.Items.Clear();
        //    ddlThridCate.Items.Clear();

        //    // load first category
        //    var cateFirstModelList = cateMgr.GetModelList(" layer=0");
        //    ListItem firstItem = new ListItem() { Value = "-1", Text = "--please select--" };
        //    ddlFirstCate.Items.Add(firstItem);
        //    foreach (var item in cateFirstModelList)
        //    {
        //        ListItem _firstItem = new ListItem() { Value = item.guid.ToString(), Text = item.name };
        //        ddlFirstCate.Items.Add(_firstItem);
        //    }
        //    _firstCateSelected = "-1";//该产品的一级类别ID
            
        //    var thirdCate = cateMgr.GetModel(Guid.Parse(cateId.Trim()));

        //    if (thirdCate == null)
        //    {
        //        return;
        //    }

        //    var thirdGuid = cateId;
        //    var secondGuid = thirdCate.prtGuid;
        //    var secondCate = cateMgr.GetModel(secondGuid);
        //    var firstGuid = secondCate.prtGuid;

        //    // load second category
        //    var cateSecondModelList = cateMgr.GetModelList(" prtGuid='" + firstGuid + "'");
        //    ListItem secondItem = new ListItem() { Value = "-1", Text = "--please select--" };
        //    ddlSecondCate.Items.Add(secondItem);
        //    foreach (var item in cateSecondModelList)
        //    {
        //        ListItem _secondItem = new ListItem() { Value = item.guid.ToString(), Text = item.name };
        //        ddlSecondCate.Items.Add(_secondItem);
        //    }
        //    _secondCateSelected = secondGuid.ToString();//该产品二级类别ID
        //    ddlSecondCate.SelectedValue = secondGuid.ToString();
 
        //    // load third category
        //    var cateThirdModelList = cateMgr.GetModelList(" prtGuid='" + secondGuid + "'");
        //    ListItem thirdItem = new ListItem() { Value = "-1", Text = "--please select--" };
        //    ddlThridCate.Items.Add(thirdItem);
        //    foreach (var item in cateThirdModelList)
        //    {
        //        ListItem _thirdItem = new ListItem() { Value = item.guid.ToString(), Text = item.name };
        //        ddlThridCate.Items.Add(_thirdItem);
        //    }
        //    _thirdCateSelected = thirdGuid.ToString();//该产品三级类别ID
        //    ddlThridCate.SelectedValue = thirdGuid.ToString();
 
        //    //ListItem thirdItem = new ListItem() { Value=thirdCate.guid.ToString(),Text=thirdCate.name}; //三级类别
        //    //ddlThridCate.Items.Add(thirdItem);

        //    //ListItem secondItem = new ListItem() { Value = secondCate.guid.ToString(), Text = secondCate.name }; //二级类别
        //    //ddlSecondCate.Items.Add(secondItem);

        //    //var cateFirstModelList = cateMgr.GetModelList(" layer=0");
        //    //ListItem firstItem = new ListItem() { Value = "-1", Text = "--please select--" };
        //    //ddlFirstCate.Items.Add(firstItem);
        //    //foreach (var item in cateFirstModelList)
        //    //{
        //    //    ListItem _firstItem = new ListItem() { Value = item.guid.ToString(), Text = item.name };
        //    //    ddlFirstCate.Items.Add(_firstItem);
        //    //}
        //    _firstCateSelected = firstGuid.ToString();//该产品的一级类别ID
        //    //var firstCate = cateMgr.GetModel(firstGuid);
        //    //ListItem firstItem = new ListItem() { Value = firstCate.guid.ToString(), Text = firstCate.name }; //一级类别
            
        //}

        [AjaxPro.AjaxMethod]
        public string GetFirstCate()
        {
            var cateModelList = cateMgr.GetModelList(" layer=0");
            if (cateModelList == null || cateModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in cateModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "[{\"value\":\"--请选择--\",\"text\":\"--请选择--\"}" + json.ToString() + "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string GetNextCate(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return "fail";
            var sonModelList = cateMgr.GetModelList(" prtGuid='" + parentId + "'");
            if (sonModelList == null || sonModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in sonModelList)
            {
               // json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
                json.AppendFormat("<option value='{0}'>{1}</option>",item.guid.ToString(),item.name);
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "<option value='-1'>--please select--</option>" + json.ToString();
            else
                return "fail";
        }

        /// <summary>
        /// 保存编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string proId = hidProId.Value.Trim();
                string proName = txtProName.Text.Trim();
 //               string proCate = hidddlThridCate.Value; //ddlThridCate.SelectedItem.Value.Trim();
                string proCate = hdnPrdCate.Value;
                string prdCate1List = hdnPrdCate1List.Value;
                string prdCate2List = hdnPrdCate2List.Value;
                string prdCate3List = hdnPrdCate3List.Value;

                string feature = txtFeature.Text.Trim();
                string benefits = txtBenefits.Text.Trim();
                string suggestPrice = txtSuggestPrice.Text.Trim();
                string supplyPrice = txtSupplyPrice.Text.Trim();
                //string procaizhi = Microsoft.JScript.GlobalObject.escape(procaizhicontent.InnerHtml);
                string procaizhi = hidEditor.Value;//procaizhicontent.InnerHtml;

                Twee.Model.Prd prdModel = new Twee.Mgr.PrdMgr().GetModel(Guid.Parse(proId));
                prdModel.name = proName;
                prdModel.cateGuid = Guid.Parse(proCate);  
                prdModel.txtTag = txtTags.Text.Trim();
                prdModel.txtinfo = procaizhi;
                prdModel.txtjj = feature;       
        
                prdModel.question = benefits;
                prdModel.estimateprice = suggestPrice.ToDecimal();
                prdModel.saleprice = txtSalePrice.Text.Trim().ToDecimal();
                prdModel.supplyPrice = supplyPrice.ToDecimal();          

                prdModel.IsFreeShipping = ckbisFreeShipping.Checked ? true : false;
                prdModel.IsComingSoon = ckbisComingSoon.Checked ? true : false;
                prdModel.IsLimitedTime = ckbisLimitedTime.Checked ? true : false;

                Twee.Mgr.PrdMgr mgr=new Twee.Mgr.PrdMgr();
                mgr.Update(prdModel);
                mgr.SaveCate(proId, prdCate1List, prdCate2List, prdCate3List);
               // List<string> listPics=hidPics.Value.Split(',').ToList<string>();
                //mgr.MgeUpdatePrdFile(proId.ToGuid().Value, listPics);
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>SavePic();</script>");
                BindBasicInfo();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('edit product success');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
        }




    }
}