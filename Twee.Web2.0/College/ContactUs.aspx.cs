using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp2.College
{
    public partial class ContactUs : System.Web.UI.Page
    {
        public String IsSubmit = "";
        public string VerifyCodeError = "";
        public string sPageName = "ContactUs";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                //get action 

                String sGet = Request.QueryString["action"];
                if (sGet!=null && sGet.Equals("send"))
                {
                    string sSubject = selSubject.Value.ToString();
                    string sName = txtName.Value.ToString();
                    string sCompany = txtCompany.Value.ToString();
                    string sTelephone = txtTelphone.Value.ToString();
                    string sEmail = txtEmail.Value.ToString().Trim();
                    string sMessage = txtMessage.Value.ToString();
                    string sVerify = txtVerify.Value.ToString();

                    if (sName == string.Empty)
                    {
                        VerifyCodeError = "Please enter the your name!";
                        txtName.Focus();
                        return;
                    }

                    if (sEmail == string.Empty)
                    {
                        VerifyCodeError = "Please enter the email address!";
                        txtEmail.Focus();
                        return;
                    }

                    if (!CommUtil.isValidEmail(sEmail) ) {
                        VerifyCodeError = "Please enter a valid email address!";
                        txtEmail.Focus();
                        return;
                    }
                    if (sMessage == string.Empty)
                    {
                        VerifyCodeError = "Please enter the your message!";
                        txtMessage.Focus();
                        return;
                    }
                    if (sVerify.ToUpper() != Request.Cookies["WaterMark" + sPageName]["Text"])
                    {
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "VerifyCode", "<script type='text/javascript'>alert('Please enter the correct verify code!');</script>");
                        VerifyCodeError = "Please enter the correct verify code!";
                        txtVerify.Value = string.Empty;
                        txtVerify.Focus();
                        return;
                    }

                    String mailbody = "Subject:" + sSubject + System.Environment.NewLine + "<br />Name:" + sName + "<br />" + System.Environment.NewLine
                        + "Company:" + sCompany + System.Environment.NewLine
                        + "<br />Telephone: " + sTelephone + System.Environment.NewLine
                        + "<br />E-mail:" + sEmail + "<br />" + System.Environment.NewLine + "Message:" + sMessage + "<br />";
                    Twee.Comm.Mailhelper.SendMail("Inquiry from customer", mailbody,"service@tweebaa.com");
                    IsSubmit = "submited";
                    Response.Write("<script>alert('Message has been sent successfully!');</script>");

                    // clean
                    txtName.Value = string.Empty;
                    txtCompany.Value = string.Empty;
                    txtTelphone.Value = string.Empty;
                    txtEmail.Value = string.Empty;
                    txtMessage.Value = string.Empty;
                    txtVerify.Value = string.Empty;
                }
            }
        }
    }
}