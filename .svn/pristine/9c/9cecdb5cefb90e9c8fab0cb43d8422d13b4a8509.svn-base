using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TweebaaWebApp.Product
{
    /// <summary>
    /// Summary description for CollageSaveFile
    /// </summary>
    public class CollageSaveFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
           // context.Response.Write("Hello World");
            try
            {


                String s=context.Request["imgBase64"];
                //context.Response.Write(s);
                s = s.Replace("data:image/png;base64,", "");
                //remove data:image/png;base64,
                byte[] imageBytes = System.Convert.FromBase64String(s);

                string savepath = "";
                string tempPath = "";
                tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
                savepath = context.Server.MapPath(tempPath);
                string filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")+".png";
                if (!Directory.Exists(savepath))
                    Directory.CreateDirectory(savepath);

                //postedFile.SaveAs(savepath + @"\" + filename);
                //folder path is 
                savepath = @"C:\\TweebaaWebEn\\TweebaaPic\\UploadImg";
                FileStream fs = new FileStream(savepath + @"\CollageImg\" + filename, FileMode.Create);
                // Create the writer for data.
                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(imageBytes);
                
                fs.Close();
                bw.Close();

                context.Response.Write("/CollageImg/" + filename);
                context.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
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