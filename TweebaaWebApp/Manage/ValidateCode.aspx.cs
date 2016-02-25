using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Manage
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Servers.ValidateCode  webImg = new  Servers.ValidateCode();
            //实例化类
            int nlen = 4;
            string str = "0123456789ABCDEFGHIGKLMNOPQRSTUVWXYZ";
            string strkey = traStr(nlen, str);
            byte[] img = webImg.createValidateCode(nlen, strkey);
            Response.OutputStream.Write(img, 0, img.Length); //输出图像
        }

        //生成验证码的字符
        private string traStr(int nlength, string str)
        {
            string ValidateCode = "";
            Random rd = new Random();
            for (int i = 0; i < nlength; i++)
            {
                char c = str[rd.Next(str.Length)];
                ValidateCode += c;
            }
            HttpContext.Current.Session["checkcode"] = ValidateCode;
            return ValidateCode;
        }
    }
}