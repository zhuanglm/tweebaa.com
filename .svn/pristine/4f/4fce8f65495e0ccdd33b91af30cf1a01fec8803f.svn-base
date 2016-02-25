using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using TweebaaWebApp2.Method;

namespace TweebaaWebApp2.upload
{
    /// <summary>
    /// Summary description for fileSave
    /// </summary>
    public class fileSave : IHttpHandler
    {
        public static double reduceRate = 1;//等比缩小比例        
        private string path2 = "";
        private string path3 = "";
        private string path4 = "";


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
         //   context.Response.Write("Hello World");
            /*
            $data = $_POST['imgData'];
$file = "/path/to/file.png";
$uri =  substr($data,strpos($data,",")+1);
file_put_contents($file, base64_decode($uri));
echo $file;*/

            //file path
            try
            {
               // Twee.Comm.CommHelper.WrtLog("11111111111");
                string savePath = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
                string folderName = System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "");
                string path = context.Server.MapPath("~" + "/" + savePath + "big/" + folderName + "/");
                path2 = context.Server.MapPath("~" + "/" + savePath + "small/" + folderName + "/");
                path3 = context.Server.MapPath("~" + "/" + savePath + "mid/" + folderName + "/");
                path4 = context.Server.MapPath("~" + "/" + savePath + "mid2/" + folderName + "/");

               // Twee.Comm.CommHelper.WrtLog("22=" + "/" + savePath + "temp/" + folderName + "/");
                string pathTemp = context.Server.MapPath("~" + "/" + savePath + "temp/" + folderName + "/");
                if (!Directory.Exists(pathTemp))
                    Directory.CreateDirectory(pathTemp);


                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!Directory.Exists(path2))
                    Directory.CreateDirectory(path2);
                if (!Directory.Exists(path3))
                    Directory.CreateDirectory(path3);
                if (!Directory.Exists(path4))
                    Directory.CreateDirectory(path4);
                //新文件名
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + ".png";
                string fileSavePath = path + newFileName;

               // Twee.Comm.CommHelper.WrtLog("22222222222");
                String s_data = context.Request.Form["imgData"];
                //remove data:image/png;base64, 22
                s_data = s_data.Substring(22, s_data.Length - 22);

                byte[] bt = Convert.FromBase64String(s_data);
                FileStream fs;
                fs = new FileStream(fileSavePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bt);
                fs.Close();
                bw.Close();

                //reduce it to others size
                //Twee.Comm.CommHelper.WrtLog("33333");
                bool b = CreateSmallPic(fileSavePath);
                if (b == false)
                {
                    context.Response.Write("-1");
                    return;
                }
                //Twee.Comm.CommHelper.WrtLog("444444444444");
                context.Response.Write("/" + savePath + "small/" + folderName + "/" + newFileName);
            }
            catch (Exception ee)
            {
                context.Response.Write(ee.StackTrace);

            }
        }
        private bool CreateSmallPic(string imgFullPath)
        {
            try
            {
                System.Drawing.Image newImage = System.Drawing.Image.FromFile(imgFullPath);//剪切后的图片
                //string error = CheckSize(newImage);
                //if (error != "")
                //{
                //    Response.Write("<script>alert('" + error + "')</script>");
                //    return false;
                //}
                //开始压缩
                string[] whs = System.Configuration.ConfigurationManager.AppSettings["UploadWH"].ToString().Split(',');
                for (int i = 0; i < whs.Length; i++)
                {
                    int wNew = int.Parse(whs[i].Split('_')[0]);
                    int hNew = int.Parse(whs[i].Split('_')[1]);
                    string filePathMack = "";
                    if (i == 0)
                    {
                        filePathMack = imgFullPath.Replace("big", "small");
                    }
                    else if (i == 1)
                    {
                        //224_224_W mid2
                        filePathMack = imgFullPath.Replace("big", "mid2");
                    }
                    else if (i == 2)
                    {
                        //400_400_M mid
                        filePathMack = imgFullPath.Replace("big", "mid");
                    }
                    //imgFile.SaveAs(filePathMack);
                    ImgThumbnail iz = new ImgThumbnail();
                    iz.Thumbnail(imgFullPath, filePathMack, wNew, hNew, whs[i].Split('_')[2]);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}