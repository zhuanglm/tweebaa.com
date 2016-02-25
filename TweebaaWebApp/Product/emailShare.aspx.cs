using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using Twee.Comm;

namespace TweebaaWebApp.Product
{
    public partial class emailShare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //产品id
            //产品名称
            //图片全路径

            string prdid = Request["prdid"];
            string link = Request["link"];
            string prdname = Request["name"];
            string prdDesc = Microsoft.JScript.GlobalObject.unescape(Request["desc"]);
            string prdimg =Microsoft.JScript.GlobalObject.unescape(Request["img"]);

            if (string.IsNullOrEmpty(prdid) || string.IsNullOrEmpty(prdname))
                Response.Clear();

            labPrdID.Text = prdid;
            labPrdName.Text = prdname;
            labShareLink.Text = link;
            Image1.ImageUrl = prdimg;
            labPrdDesc.Text = prdDesc;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sPrdId = labPrdID.Text;
            StringBuilder sEmailBody = new StringBuilder();

            string sPrdDesc = labPrdDesc.Text;
            string sShareLink = labShareLink.Text;

            if (sShareLink.IndexOf("localhost") == -1)
            {
                int iIdx = sShareLink.IndexOf("/Product");
                if (iIdx != -1) sShareLink = "https://www.tweebaa.com" + sShareLink.Substring(iIdx);
            }

            string sUserMsg = txtMessage.InnerText.Replace("\n", "<br />");
            string sPrdName = labPrdName.Text;

            // get the login user's email address if it is login
            // take as the reference email of registration
            Guid? userGuid = CommUtil.IsLogion();
            string sRefEmail = string.Empty;
            if (userGuid != null)
            {
                Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
                Twee.Model.User model = mgr.GetModel((Guid)userGuid);
                if (!string.IsNullOrEmpty(model.email))
                {
                    sRefEmail = "?ref=" + model.email;
                }
            }

            //string sImageUrl = Image1.ImageUrl.Replace("/mid2/", "/amall/");   // use small image of the product
            string sImageUrl = Image1.ImageUrl.Replace("/big/", "/mid2/");   // use small image of the product

            string sEmailTemplate = string.Empty;

            int iPrdStatus = 0;
            if (sPrdId.Length >= 16)
            {

                Guid prdGuid = new Guid(sPrdId);

                Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
                DataTable dt = mgr.GetPrdBaseInfo(prdGuid);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                DataRow dr = dt.Rows[0];

                iPrdStatus = Int32.Parse(dt.Rows[0]["wnstat"].ToString());

                // product description
                // filter the descriptions of FREE SHIPPING in the product descriptions
                int iPosFreeShipping = sPrdDesc.IndexOf("FREE SHIPPING");
                if (iPosFreeShipping != -1)
                {
                    // find the end of the previous sentence of the "FREE SHIPPING" 
                    while (iPosFreeShipping > 0)
                    {
                        if (sPrdDesc.Substring(iPosFreeShipping, 1) == ".") break;
                        iPosFreeShipping--;
                    }
                    sPrdDesc = sPrdDesc.Substring(0, iPosFreeShipping + 1);
                }

                string sEmailTemplateFileName = string.Empty;
                
                switch (iPrdStatus)
                {
                    case (int)Twee.Comm.ConfigParamter.PrdSate.review:   // evaluate
                        sEmailTemplateFileName = "EmailShareTemplateEvaluate.html";
                        break;
                    case (int)Twee.Comm.ConfigParamter.PrdSate.preSale:
                        sEmailTemplateFileName = "EmailShareTemplateTestSale.html";
                        break;
                    case (int)Twee.Comm.ConfigParamter.PrdSate.sale:
                        sEmailTemplateFileName = "EmailShareTemplateBuyNow.html";
                        break;
                    default:
                        break;
                }
                if (sEmailTemplateFileName != string.Empty)
                {
                    sEmailTemplate = ReadEmailTemplate(sEmailTemplateFileName);
                    sEmailTemplate = sEmailTemplate.Replace("#SendFrom#", txtSender.Value);
                    sEmailTemplate = sEmailTemplate.Replace("#ShareUrl#", sShareLink);
                    sEmailTemplate = sEmailTemplate.Replace("#ProductImgUrl#", sImageUrl);
                    sEmailTemplate = sEmailTemplate.Replace("#ProductName#", sPrdName);
                    sEmailTemplate = sEmailTemplate.Replace("#PersonalMessage#", sUserMsg);
                    sEmailTemplate = sEmailTemplate.Replace("#ProductDesc#", sPrdDesc);
                    sEmailTemplate = sEmailTemplate.Replace("#RefEmail#", sRefEmail);
                }
            }
            else
            {
                //This maybe Collage Share
                // should implemented here in the future
                iPrdStatus = -1;
            }

            // do not send if no email template
            if (sEmailTemplate == string.Empty) return;


            // send email to individual email address
            string[] sEmailArray = hidEmail.Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            bool bSendAll = true;
            foreach (string sMailTo in sEmailArray)
            {
                // get customer name from email address
                int iPos = sMailTo.IndexOf('@');
                string sRecipientName = sMailTo;
                if (iPos != -1) sRecipientName = sRecipientName.Substring(0, iPos);
                
                // set first letter to upper case
                sRecipientName = char.ToUpper(sRecipientName[0]) + sRecipientName.Substring(1);

                string htmlBody = sEmailTemplate.Replace("#SendTo#", sRecipientName);

                //strTitle
                string sTitle = txtSender.Value + " has shared a Tweebaa product with you";
                bool bSend = Twee.Comm.Mailhelper.SendMail(sTitle, htmlBody, sMailTo);
                //bool bSend = Twee.Comm.Mailhelper.SendMail(labPrdName.Text, htmlBody, str);
                if (!bSend) bSendAll = false;
            }

            string sMsg = "Share email has been sent successfully!";
            if (!bSendAll) sMsg = "Failed to send the share email, please try again later";
            // when success need to close the window
            string sScript = "alert('" + sMsg + "'); ";
            if (bSendAll) sScript = sScript + " window.close(); ";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", sScript, true);
            
        }

        private void MyAlert(string sMsg)
        {
            string sAlert = "alert('" + sMsg + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", sAlert, true);
        }


        private string ReadEmailTemplate(string sFileName)
        {
            string sFullFileName = System.Web.HttpContext.Current.Server.MapPath("~") + @"\Product\" + sFileName;
            StreamReader sr = null;
            string sEmailTemplate = string.Empty;
            try
            {
                sr = new StreamReader(sFullFileName, Encoding.GetEncoding("UTF-8"));
                sEmailTemplate = sr.ReadToEnd(); // read the file 
            }
            catch (Exception exp)
            {
                CommHelper.WrtLog(exp.Message);
            }
            finally
            {
                sr.Dispose();
                sr.Close();
            }

            return sEmailTemplate;
        }

    }
}