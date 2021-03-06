﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.IO;

namespace TweebaaWebApp.Product
{
    public partial class uoloadProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //导入产品Excel信息
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUser.SelectedIndex==0)
                {
                    Response.Write("<script>alert('请选择导入人姓名'); </script>");
                    return;
                }
                string fileName = FileUpload1.FileName;
                UploadProduct upload = new UploadProduct();
                string path = Server.MapPath("~" + "/UploadExcel/" + fileName);
                FileUpload1.SaveAs(path);
                string error = upload.ImportPrd(ddlUser.SelectedValue, ddlUser.SelectedItem.Text, path);
                labErroe.InnerHtml = error;
            }
            catch (Exception)
            {
                Response.Write("<script>alert('请检查Excel格式是否正确'); </script>");
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