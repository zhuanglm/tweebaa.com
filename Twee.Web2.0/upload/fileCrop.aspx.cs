using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using TweebaaWebApp2.Method;

namespace TweebaaWebApp2.upload
{
    public partial class fileCrop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }
        /// <summary>
        /// 保存裁剪图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCutSave_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(hidTip.Value))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script type='text/javascript'>alert('Please upload picture at first .');</script>");
                return;
            }
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
            if (width <= 800 && height <= 800 && width >= 600 && height >= 600)
            {
                resuPic = CutPic(imgPath, pointX, pointY, width, height);
            }
            else
            {
                //resuPic = Server.MapPath("~" + "/" + imgPath);//原图路径
                //resuPic = imgPath;//原图路径
                Image1.ImageUrl = imgPath;
                string script = "<script type='text/javascript'>alert('Please cut a square picture 600*600-800*800')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
                System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~" + "/" + imgPath));
                styleCanvas = "width:" + img.Width + "px;height:" + img.Height + "px;";//将压缩后的图片尺寸赋值给画布

                _width = (600 / reduceRate).ToString();
                _height = (600 / reduceRate).ToString();

                _left = ((img.Width - 600 / reduceRate) / 2).ToString();
                _top = ((img.Height - 600 / reduceRate) / 2).ToString();


                styleBoxSize = "setTimeout('setBox()',1000)";


                img.Dispose();
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
                string imgNewSrc = resuPic.Replace("big", "small").Replace("~/", ""); //"UploadImg/small/" + folderName + "/" + newFileName;
                string script = "<script type='text/javascript'>setImg('" + imgNewSrc + "','" + imgid + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", script);
            }
            */
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
        /// 
        /*
        private string CutPic(string imgPath, int pointX, int pointY, int width, int height)
        {
           
            if (reduceRate != 1)
            {
                imgPath = imgPath.Replace("temp", "big");
            }
            width = Convert.ToInt32(width);
            height = Convert.ToInt32(height);
            pointX = Convert.ToInt32(pointX * reduceRate);
            pointY = Convert.ToInt32(pointY * reduceRate);//根据缩小比例恢复剪裁的实际大小
            string path = Server.MapPath("~" + "/" + imgPath);//原图路径            
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
            string newFileName = "/upload/UploadImg/big/" + folderName + "/" + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + ".jpg";
            string newPic = HttpContext.Current.Server.MapPath(newFileName);//新图片的完整路径
            //finalImg.Save(pp,System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Save(newPic, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
            originalImage.Dispose();
            gps.Dispose();
            //finalImg.Dispose();
            GC.Collect();
            PubClass.FileDel(path);
            Image1.ImageUrl = "~/" + newFileName;
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

        }*/
    }
}