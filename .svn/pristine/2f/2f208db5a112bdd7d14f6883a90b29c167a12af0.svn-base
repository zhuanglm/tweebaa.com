using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;


namespace TweebaaWebApp2.Manage.Servers
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ValidateCode : System.Web.Services.WebService
    {

        public ValidateCode()
        {

            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession = true)]
        public byte[] createValidateCode(int nLen, string strKey)
        {
            HttpContext.Current.Session["checkcode"] = strKey;
            int nBmpWidth = nLen * 13 + 20;
            int nBmpHeight = 25;
            Random rd = new Random((int)DateTime.Now.Ticks);
            int nRed; int nBlue; int nGreen;
            nRed = rd.Next(255) % 128 + 128;
            nBlue = rd.Next(255) % 128 + 128;
            nGreen = rd.Next(255) % 128 + 128;
            Bitmap bmp = new Bitmap(nBmpWidth, nBmpHeight);
            Graphics graph = Graphics.FromImage(bmp);
            // 创建背景
            graph.FillRectangle(new SolidBrush(Color.AliceBlue), 0, 0, nBmpWidth, nBmpHeight);
            //创建线条
            int lines = 3;
            for (int i = 0; i < lines; i++)
            {
                int x1 = rd.Next(nBmpWidth);
                int y1 = rd.Next(nBmpHeight);
                int x2 = rd.Next(nBmpWidth);
                int y2 = rd.Next(nBmpHeight);
                Pen penColor = new Pen(Color.FromArgb(nRed - 17, nGreen - 17, nBlue - 17));
                graph.DrawLine(penColor, x1, y1, x2, y2);
            }
            //创建躁点
            for (int i = 0; i < 100; i++)
            {
                int x1 = rd.Next(bmp.Width);
                int y1 = rd.Next(bmp.Height);
                bmp.SetPixel(x1, y1, Color.FromArgb(rd.Next()));

            }

            //创建字体
            Font fonts = new Font("微软 雅黑", 14 + rd.Next() % 4, FontStyle.Bold);
            System.Drawing.Drawing2D.LinearGradientBrush linearBrush = (new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, bmp.Width, bmp.Height), Color.Blue, Color.DarkRed, 1.2f, true));
            graph.DrawString(strKey, fonts, linearBrush, 2, 2);

            //输出字节流
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            graph.Dispose();
            bmp.Dispose();
            byte[] picbyte = stream.ToArray();
            stream.Dispose();

            return picbyte;
        }

    }
}
