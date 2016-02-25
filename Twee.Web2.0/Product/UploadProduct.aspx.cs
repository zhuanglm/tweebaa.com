﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;


namespace TweebaaWebApp2.Product
{
    public partial class UploadProduct : System.Web.UI.Page
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

        protected void btnDelete_Click(object sender, EventArgs e)
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
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int iProductUploadBatchNo = -1;
            try
            {
                //if (ddlUser.SelectedIndex == 0)
                //{
                //    Response.Write("<script>alert('请选择导入人姓名'); </script>");
                //    return;
                //}

                // check password 
                if ( txtPwd.Text != "laocao") {
                    Response.Write("<script>alert('Please enter a valid password!'); </script>");
                    txtPwd.Focus();
                    return;
                }

                string fileName = FileUpload1.FileName;
                if (fileName == string.Empty)
                {
                    Response.Write("<script>alert('Please select the Excel File you want to upload!'); </script>");
                    return;
                }
                Twee.Mgr.UploadProduct mgrUpload = new Twee.Mgr.UploadProduct();
                string path = Server.MapPath("~" + "/UploadExcel/" + fileName);
                FileUpload1.SaveAs(path);

                string userID = "AA37747F-F2FB-4040-8C35-D231A0364C89";
                string userName = "YDF";

                string localhosturl = GetUrlForPage("");

                string error = mgrUpload.ImportPrdNew(userID, userName, path, localhosturl, out iProductUploadBatchNo);
                labError.InnerHtml = error + "  Batch #=" + iProductUploadBatchNo.ToString();
            }
            catch (Exception ex)
            {
                //throw ex;
                Response.Write("<script>alert(\"Batch #=" + iProductUploadBatchNo.ToString() + " Error: " + ex.Message + "\"); </script>");
                return;
            }
            Response.Write("<script>alert('Upload Completed: Batch #=" + iProductUploadBatchNo.ToString() + "'); </script>");

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