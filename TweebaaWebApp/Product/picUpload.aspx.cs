using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using TweebaaWebApp.Method;
using System.IO;
using TweebaaWebApp.UploadFile;

namespace TweebaaWebApp.Product
{
    public partial class picUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string path2 = "";
        private string path3 = "";
        private string path4 = "";
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileUploadPic.HasFile)
                {
                    string fileExrensio = System.IO.Path.GetExtension(fileUploadPic.FileName).ToLower();
                    List<string> exNameList = new List<string>() { ".jpg", ".jpeg", ".png", ".gif" };
                    if (!exNameList.Contains(fileExrensio))
                    {
                        string scriptString = "<script>alert('Please select a image,the width and height of the image should be between 600 and 800 pixels')</script>";
                        Image1.ImageUrl = "~/Images/picture.jpg";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", scriptString);
                        return;
                    }

                    if (fileUploadPic.FileContent.Length > int.Parse(System.Configuration.ConfigurationManager.AppSettings["UploadSizeB"].ToString()))
                    {
                        Response.Write("Image size can not exceed 2M");
                        return;
                    }
                    string savePath = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
                    string folderName = System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "");
                    string path = Server.MapPath("~" + "/" + savePath + "big/" + folderName + "/");
                    path2 = Server.MapPath("~" + "/" + savePath + "small/" + folderName + "/");
                    path3 = Server.MapPath("~" + "/" + savePath + "mid/" + folderName + "/");
                    path4 = Server.MapPath("~" + "/" + savePath + "mid2/" + folderName + "/");

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    if (!Directory.Exists(path2))
                        Directory.CreateDirectory(path2);
                    if (!Directory.Exists(path3))
                        Directory.CreateDirectory(path3);
                    if (!Directory.Exists(path4))
                        Directory.CreateDirectory(path4);
                    //新文件名
                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExrensio;
                    string fileSavePath = path + newFileName;
                    fileUploadPic.PostedFile.SaveAs(fileSavePath);
                    System.Drawing.Image img = System.Drawing.Image.FromFile(fileSavePath);
                    if (img.Width < 600 || img.Height < 600)
                    {
                        string scriptString = "<script>alert('The picture width and length cannot be less than 600 px')</script>";
                        Image1.ImageUrl = "~/Images/picture.jpg";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", scriptString);
                        return;
                    }
                    if (img.Width > 800 || img.Height > 800)
                    {
                        string scriptString = "<script>alert('The picture width and length cannot be bigger than 800 px')</script>";
                        Image1.ImageUrl = "~/Images/picture.jpg";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", scriptString);
                        return;
                    }

                    string str = "<script>document.getElementById(\"imgDiv\").style.width = \"" + img.Width + "\";document.getElementById(\"imgDiv\").style.height = \"" + img.Height + "\";</script>";
                    Response.Write(str);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", str);

                    img.Dispose();
                    hidBigFilePath.Value = newFileName;//给前台写入文件新名称
                    //UploadImg/big/20150307/20150307175353_4997.jpg
                    Image1.ImageUrl = "~/UploadImg/big/" + folderName + "/" + newFileName;
                    hidTip.Value = "~/UploadImg/big/" + folderName + "/" + newFileName;

                    dataX.Value = "0";
                    dataY.Value = "0";
                    dataWidth.Value = "600";
                    dataHeight.Value = "600";
                    //string script = "<script type='text/javascript'>$(function(){   jcrop_api.setSelect([0, 0, 600, 600]); })</script>";
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存裁剪图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCutSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hidTip.Value))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script type='text/javascript'>alert('Please upload picture at first .');</script>");
                return;
            }

            //这里是取页面上图片的信息JSON
            //{"naturalWidth":578,"naturalHeight":325,"aspectRatio":1.7784615384615385,"rotate":0,"width":848,"height":476.8166089965398,"left":0,"top":0}
            //  string imgJsonData = putData.Value;


            int pointX = 0;
            int pointY = 0;
            int width = 0;
            int height = 0;
            int.TryParse(dataX.Value.Trim(), out pointX);
            int.TryParse(dataY.Value.Trim(), out pointY);
            int.TryParse(dataWidth.Value.Trim(), out width);
            int.TryParse(dataHeight.Value.Trim(), out height);
            string imgPath = Image1.ImageUrl;//UploadImg/big/20150307/20150307225105_7156.jpg
            string resuPic = "";
            if (width >= 566 && height >= 566)
            {
                resuPic = CutPic(imgPath, pointX, pointY, width, height);
            }
            else
            {
                //resuPic = Server.MapPath("~" + "/" + imgPath);//原图路径
                resuPic = imgPath;//原图路径
                string script = "<script type='text/javascript'>alert('Please cut a square picture 600*600-800*800')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
                return;
            }
            if (resuPic != "")
            {
                string _resuPic = Server.MapPath(resuPic);//原图路径
                bool b = CreateSmallPic(_resuPic);
                if (b == false)
                {
                    return;
                }
                string imgid = Request["imgid"];
                string imgNewSrc = resuPic.Replace("big", "small").Replace("~/", "../"); //"UploadImg/small/" + folderName + "/" + newFileName;
                string script = "<script type='text/javascript'>setImg('" + imgNewSrc + "','" + imgid + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);

                //调用服务上传图片
               //string fileName = AppDomain.CurrentDomain.BaseDirectory + "Images/1-0.jpg";            
                SendFileStream(_resuPic);
                SendFileStream(_resuPic.Replace("big", "mid"));
                SendFileStream(_resuPic.Replace("big", "mid2"));
                SendFileStream(_resuPic.Replace("big", "small"));
            }
        }
        /// <summary>
        /// 剪切图片
        /// </summary>
        /// <param name="imgPath"></param>
        /// <param name="pointX"></param>
        /// <param name="pointY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>返回新图片相对路径，如：~/UploadImg/big/picName"</returns>
        private string CutPic(string imgPath, int pointX, int pointY, int width, int height)
        {
            string path = Server.MapPath(imgPath);//原图路径
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(path);//原图片
            //System.Drawing.Rectangle rl = new System.Drawing.Rectangle(pointX, pointY, width, height);   //得到截图矩形   
            System.Drawing.Image finalImg = null;  //最终图片             
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, height); //按截图区域生成Bitmap        
            System.Drawing.Rectangle rl = new System.Drawing.Rectangle(pointX, pointY, width, height);   //得到截图矩形
            System.Drawing.Graphics gps = System.Drawing.Graphics.FromImage(bitmap);      //读到绘图对象            
            gps.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            gps.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gps.Clear(System.Drawing.Color.Transparent);
            gps.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, width, height), new System.Drawing.Rectangle(pointX, pointY, width, height), System.Drawing.GraphicsUnit.Pixel);
            //finalImg = PubClass.GetThumbNailImage(bitmap, width, height); 
            string folderName = System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "");
            string newFileName = "~/UploadImg/big/" + folderName + "/" + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + ".jpg";
            string newPic = HttpContext.Current.Server.MapPath(newFileName);//新图片的完整路径
            //finalImg.Save(pp,System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Save(newPic, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
            originalImage.Dispose();
            gps.Dispose();
            //finalImg.Dispose();
            GC.Collect();
            PubClass.FileDel(path);
            Image1.ImageUrl =  newFileName;
            return Image1.ImageUrl;
            //return newPic;
        }

        /// <summary>
        /// 检验图片的尺寸，如符合规定，则返回空
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private string CheckSize(System.Drawing.Image img)
        {
            if (img.Width < 600 || img.Height < 600 || img.Width > 800 || img.Height > 800)
            {
                return "Please select a square picture 600*600-800*800";
            }
            else if ((img.Width - img.Height) > 10 || (img.Height - img.Width) > 10)
            {
                return "Please select a square picture 600*600-800*800";
            }
            return "";
        }

        /// <summary>
        /// 生成小图
        /// </summary>
        /// <param name="imgFullPath"></param>
        /// <returns></returns>
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

        protected void fileUploadPic_Load(object sender, EventArgs e)
        {
            if (fileUploadPic.HasFile)
            {

            }

        }


        private void SendFileStream(string imgPath)
        {

            FileStream fileStream = new FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.Read);          
            //UploadImg/big/20150307/20150307225105_7156.jpg
            string fileName = imgPath.Substring(imgPath.LastIndexOf(@"\") + 1);
            string filePath = imgPath.Substring(0, imgPath.LastIndexOf(@"\"));

            byte[] bytes = new byte[fileStream.Length];// 读取文件的 byte[]
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();         
            Stream stream = new MemoryStream(bytes);   // 把 byte[] 转换成 Stream
            UploadPicServiceClient ser = new UploadPicServiceClient();
            FileUploadMessage request = new FileUploadMessage();
            request.SavePath = filePath;
            request.FileName = fileName;
            request.FileData = fileStream;
            IUploadPicService channel = ser.ChannelFactory.CreateChannel();
            channel.UploadFile(request);   
        
        }
    }
}