using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using log4net;
using System.Reflection;
using TweebaaWebApp2.Method;

namespace TweebaaWebApp2.Product
{
    public partial class UploadProductExcelPic : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string error = "";
        /*
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (ddlUser.SelectedIndex == 0)
            {
                Response.Write("<script>alert('请选择导入人姓名'); </script>");
                return;
            }
            btnUpload.Enabled = false;
            DirectoryInfo dir = new DirectoryInfo(@"D:\ProductImages\" + ddlUser.SelectedValue);
            if (!dir.Exists) return;
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                PicAction(file);
            }
            labErroe.InnerHtml = error;
            Response.Write("<script>alert('导入完成！'); </script>");
            return;
        }
        */

        //图片处理
        private void PicAction(FileInfo imgFile)
        {
            if (string.IsNullOrEmpty(imgFile.Name))
            {
                //showError(-1, "请选择文件", context, "", "");
                return;
            }
            String fileName = imgFile.Name;//源文件名
            String fileExt = Path.GetExtension(fileName).ToLower(); //文件扩展名
            if (System.Configuration.ConfigurationManager.AppSettings["UploadExtension"].ToString().IndexOf(fileExt) == -1)
            {
                //showError(-2, "不许可的文件类型", context, "", "");
                //return;
            }
            if (imgFile.Length > int.Parse(System.Configuration.ConfigurationManager.AppSettings["UploadSizeB"].ToString()))
            {
                //showError(-3, "不许可的文件大小", context, "", "");
                //return;
            }

            String savePath = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
            //建立日期文件夹          
            string date = DateTime.Now.ToString("yyyyMMdd");
            String dirPath = Server.MapPath("~" + "/" + savePath);
            string dirPath1 = Server.MapPath("~" + "/" + savePath + "big/" + date + "/");
            string dirPath2 = Server.MapPath("~" + "/" + savePath + "small/" + date + "/");
            string dirPath3 = Server.MapPath("~" + "/" + savePath + "mid/" + date + "/");
            string dirPath4 = Server.MapPath("~" + "/" + savePath + "mid2/" + date + "/");

            if (!Directory.Exists(dirPath1))
                Directory.CreateDirectory(dirPath1);
            if (!Directory.Exists(dirPath2))
                Directory.CreateDirectory(dirPath2);
            if (!Directory.Exists(dirPath3))
                Directory.CreateDirectory(dirPath3);
            if (!Directory.Exists(dirPath4))
                Directory.CreateDirectory(dirPath4);
            //新文件名
            //String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String newFileName = imgFile.Name;
            String filePath = dirPath1 + newFileName;
            string newFileName2 = "";//用于及时显示的ico
            try
            {
                if (System.IO.File.Exists(Path.GetFullPath(filePath)))
                {
                    File.Delete(Path.GetFullPath(filePath));
                }
                imgFile.CopyTo(filePath, true);
                if (true)
                {
                    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(filePath);
                    if (originalImage.Width < 590 || originalImage.Height < 590 || originalImage.Width > 810 || originalImage.Height > 810)
                    {
                        // showError(-4, "请选择600*600-800*800的正方形图片", context, "", "");
                        //return;
                        log.Error("图片不合格，宽高不在要求范围内:【" + imgFile.Name + " 】");
                        error += "图片不合格，宽高不在要求范围内:【" + imgFile.Name + " 】" + " <br />";
                    }
                    if ((originalImage.Width - originalImage.Height) > 10 || (originalImage.Height - originalImage.Width) > 10)
                    {
                        /// showError(-4, "请选择600*600-800*800的正方形图片", context, "", "");
                        //return;
                        log.Error("图片不合格，宽高相差像素大于10:【" + imgFile.Name + " 】");
                        error += "图片不合格，宽高相差像素大于10:【" + imgFile.Name + " 】" + " <br />";
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
                    if (i == 0)
                    {
                        filePathMack = dirPath2 + newFileName;
                    }
                    else if (i == 1)
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
                        newFileName2 = newFileName;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            btnUpload.Enabled = false;
            //DirectoryInfo dir = new DirectoryInfo("E:\\TweeBaa_En\\upload\\downImg\\");
            DirectoryInfo dir = new DirectoryInfo("D:\\WorkSpace\\TweeBaaEn\\TweebaaWebApp\\upload\\downImg\\");
            if (!dir.Exists) return;
            DirectoryInfo[] dirs = dir.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                FileInfo[] files = dirs[i].GetFiles();
                foreach (FileInfo file in files)
                {
                    PicActionNew(file);
                }
            }
            labErroe.InnerHtml = error;
            Response.Write("<script>alert('导入完成！'); </script>");
            return;
        }


        //图片处理
        private void PicActionNew(FileInfo imgFile)
        {
            if (string.IsNullOrEmpty(imgFile.Name))
            {
                //showError(-1, "请选择文件", context, "", "");
                return;
            }
            String fileName = imgFile.Name;//源文件名
            String fileExt = Path.GetExtension(fileName).ToLower(); //文件扩展名
            if (System.Configuration.ConfigurationManager.AppSettings["UploadExtension"].ToString().IndexOf(fileExt) == -1)
            {
                //showError(-2, "不许可的文件类型", context, "", "");
                //return;
            }
            if (imgFile.Length > int.Parse(System.Configuration.ConfigurationManager.AppSettings["UploadSizeB"].ToString()))
            {
                //showError(-3, "不许可的文件大小", context, "", "");
                //return;
            }

            String savePath = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
            //建立日期文件夹          
            string date = DateTime.Now.ToString("yyyyMMdd");
            String dirPath = Server.MapPath("~" + "/" + savePath);
            string dirPath1 = Server.MapPath("~" + "/" + savePath + "big/" + date + "/");
            string dirPath2 = Server.MapPath("~" + "/" + savePath + "small/" + date + "/");
            string dirPath3 = Server.MapPath("~" + "/" + savePath + "mid/" + date + "/");
            string dirPath4 = Server.MapPath("~" + "/" + savePath + "mid2/" + date + "/");

            if (!Directory.Exists(dirPath1))
                Directory.CreateDirectory(dirPath1);
            if (!Directory.Exists(dirPath2))
                Directory.CreateDirectory(dirPath2);
            if (!Directory.Exists(dirPath3))
                Directory.CreateDirectory(dirPath3);
            if (!Directory.Exists(dirPath4))
                Directory.CreateDirectory(dirPath4);
            //新文件名
            //String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String newFileName = imgFile.Name;
            String filePath = dirPath1 + newFileName;
            string newFileName2 = "";//用于及时显示的ico
            try
            {
                if (System.IO.File.Exists(Path.GetFullPath(filePath)))
                {
                    File.Delete(Path.GetFullPath(filePath));
                }
                imgFile.CopyTo(filePath, true);
                /*
                if (true)
                {
                    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(filePath);
                    if (originalImage.Width < 590 || originalImage.Height < 590 || originalImage.Width > 810 || originalImage.Height > 810)
                    {
                        // showError(-4, "请选择600*600-800*800的正方形图片", context, "", "");
                        //return;
                        log.Error("图片不合格，宽高不在要求范围内:【" + imgFile.Name + " 】");
                        error += "图片不合格，宽高不在要求范围内:【" + imgFile.Name + " 】" + " <br />";
                    }
                    if ((originalImage.Width - originalImage.Height) > 10 || (originalImage.Height - originalImage.Width) > 10)
                    {
                        /// showError(-4, "请选择600*600-800*800的正方形图片", context, "", "");
                        //return;
                        log.Error("图片不合格，宽高相差像素大于10:【" + imgFile.Name + " 】");
                        error += "图片不合格，宽高相差像素大于10:【" + imgFile.Name + " 】" + " <br />";
                    }
                }
                 * */

                //开始压缩
                string[] whs = System.Configuration.ConfigurationManager.AppSettings["UploadWH"].ToString().Split(',');

                for (int i = 0; i < whs.Length; i++)
                {
                    int w = int.Parse(whs[i].Split('_')[0]);
                    int h = int.Parse(whs[i].Split('_')[1]);
                    //string filePathMack = dirPath + wh + newFileName;
                    string filePathMack = "";
                    if (i == 0)
                    {
                        filePathMack = dirPath2 + newFileName;
                    }
                    else if (i == 1)
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
                        newFileName2 = newFileName;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

}