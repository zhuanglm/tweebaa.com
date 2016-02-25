using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using TweebaaWebApp2.Method;

namespace TweebaaWebApp2.Server
{
    /// <summary>
    /// upload_json 的摘要说明
    /// </summary>
    public class upload_jsonEn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            

            //HttpPostedFile imgFile = context.Request.Files["document"];//这里是获取上传的文件流，也可以用索引值来表示如果是多个文件的话
            HttpPostedFile imgFile = context.Request.Files["fuck"];           

            if (string.IsNullOrEmpty(imgFile.FileName))
            {
                showError(-1, "Please select a picture", context, "", "");
                return;
            }

            //源文件名
            String fileName = imgFile.FileName;
            //文件扩展名
            String fileExt = Path.GetExtension(fileName).ToLower();
            if (System.Configuration.ConfigurationManager.AppSettings["UploadExtension"].ToString().IndexOf(fileExt) == -1)
            {
                showError(-2, "Not supported image types", context, "", "");
                return;
            }
            if (imgFile.ContentLength > int.Parse(System.Configuration.ConfigurationManager.AppSettings["UploadSizeB"].ToString()))
            {
                showError(-3, "Image size can not exceed 2M", context, "", "");
                return;
            }

            String savePath = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
            //建立日期文件夹
            //savePath += DateTime.Now.ToString("yyyyMMdd") + "/";
            //savePath = savePath + "small/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            string date = DateTime.Now.ToString("yyyyMMdd");
            String dirPath = context.Server.MapPath("~" + "/" + savePath);
            string dirPath1 = context.Server.MapPath("~" + "/" + savePath + "big/" + date + "/");
            string dirPath2 = context.Server.MapPath("~" + "/" + savePath + "small/" + date + "/");
            string dirPath3 = context.Server.MapPath("~" + "/" + savePath + "mid/" + date + "/");
            string dirPath4 = context.Server.MapPath("~" + "/" + savePath + "mid2/" + date + "/");

            if (!Directory.Exists(dirPath1))
                Directory.CreateDirectory(dirPath1);
            if (!Directory.Exists(dirPath2))
                Directory.CreateDirectory(dirPath2);
            if (!Directory.Exists(dirPath3))
                Directory.CreateDirectory(dirPath3);
            if (!Directory.Exists(dirPath4))
                Directory.CreateDirectory(dirPath4);
            //新文件名
            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = dirPath1 + newFileName;
            string newFileName2 = "";//用于及时显示的ico
            try
            {
                imgFile.SaveAs(filePath);
                if (true)
                {
                    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(filePath);
                    if (originalImage.Width < 600 || originalImage.Height < 600 || originalImage.Width>800|| originalImage.Height>800)
                    {
                        showError(-4, "Please select a square picture 600*600-800*800", context, "", "");
                        return;
                    }
                    else if ((originalImage.Width - originalImage.Height) > 10 || (originalImage.Height - originalImage.Width)>10)
                    {
                        showError(-4, "Please select a square picture 600*600-800*800", context, "", "");
                        return;
                    }
                }

                //开始压缩
                string[] whs = System.Configuration.ConfigurationManager.AppSettings["UploadWH"].ToString().Split(',');               
                for (int i = 0; i < whs.Length; i++)
                {
                    int w = int.Parse(whs[i].Split('_')[0]);
                    int h = int.Parse(whs[i].Split('_')[1]);
                    //string filePathMack = dirPath + wh + newFileName;
                    string filePathMack = "";
                    if (i==0)
                    {
                        filePathMack = dirPath2 + newFileName;
                    }
                    else if (i==1)
                    {
                        //224_224_W mid2
                        filePathMack = dirPath4 + newFileName;
                    }
                    else if (i == 2)
                    {
                        //400_400_M mid
                        filePathMack = dirPath3 + newFileName;
                    }
                    //imgFile.SaveAs(filePathMack);
                    ImgThumbnail iz = new ImgThumbnail();
                    iz.Thumbnail(filePath, filePathMack, w, h, whs[i].Split('_')[2]);
                    if (newFileName2.Length == 0)
                        //newFileName2 = wh + newFileName;
                        newFileName2 =  newFileName;
                }


                //
            }
            catch (Exception ex)
            {
               // CommHelper.WrtLog("上传时：upload_json.ashx中：" + ex.Message.ToString());
            }
            string dateFileName = date +"/"+ newFileName;
            showError(1, savePath + "big/" + dateFileName, context, savePath + "mid/" + dateFileName, savePath + "small/" + dateFileName);
       
        }
        private void showError(int resInt, string message, HttpContext context, string message2, string message3)
        {
            // context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Clear();
            //context.Response.Write(resInt.ToString() + ":" + message);
            context.Response.Write("{resInt:'" + resInt.ToString() + "',message:'" + message + "',message2:'" + message2 +"',message3:'" + message3 + "'}");
           
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}