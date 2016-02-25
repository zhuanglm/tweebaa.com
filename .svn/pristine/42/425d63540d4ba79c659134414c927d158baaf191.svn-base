using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace TweebaaWebApp.Product
{
    public partial class uploadProduct3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string GetUrlForPage(string page)
        {
            return string.Format(
               "{0}://{1}{2}/{3}",
                Request.Url.Scheme,
                Request.Url.Host,
                Request.Url.IsDefaultPort ? string.Empty : ":" + Request.Url.Port,
                page);
        }

        protected void btnDelete_Click(object sender,EventArgs e)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo("D:\\WorkSpace\\TweeBaaEn\\TweebaaWebApp\\upload\\downImg\\");
                if (dir.Exists)
                {
                    dir.Delete(true);
                }
                dir.Create();
                Response.Write("<script>alert('完成'); </script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('失败'); </script>");
                throw;
            }
         
        }
        //导入产品Excel信息
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ddlUser.SelectedIndex == 0)
                //{
                //    Response.Write("<script>alert('请选择导入人姓名'); </script>");
                //    return;
                //}
                string fileName = FileUpload1.FileName;
                UploadProduct upload = new UploadProduct();
                string path = Server.MapPath("~" + "/UploadExcel/" + fileName);
                FileUpload1.SaveAs(path);

                string userID = "AA37747F-F2FB-4040-8C35-D231A0364C89";
                string userName = "YDF";

                string localhosturl = GetUrlForPage("");

                string error = upload.ImportPrdNew(userID, userName, path, localhosturl);
                labError.InnerHtml = error;
            }
            catch (Exception ex)
            {
                //throw ex;
                Response.Write("<script>alert('请检查Excel格式是否正确:" + ex.Message + "'); </script>");
                return;
            }
            Response.Write("<script>alert('导入完成'); </script>");

        }
        //图片导入处理
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        private void CopyImg(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists) return;
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string fileName = file.Name;
                string desPath = "E:\\imgCopy\\" + fileName;
                file.CopyTo(desPath);
            }
            foreach (DirectoryInfo d in dirs)
            {
                string p = d.FullName;
                CopyImg(p);
            }
        }
    }
}