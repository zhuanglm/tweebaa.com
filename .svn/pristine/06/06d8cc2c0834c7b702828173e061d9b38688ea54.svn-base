using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace TweebaaWebApp.mobileApp
{
    /// <summary>
    /// Summary description for CollageFileAPI
    /// </summary>
    public class CollageFileAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {


                HttpPostedFile file = context.Request.Files[0];
                string filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".png";
                if (file.ContentLength > 0)
                {
                    //do something
                    //save file
                        string savepath = "";
                    string tempPath = "";
                    tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
                    savepath = context.Server.MapPath(tempPath);
                
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);

                    //postedFile.SaveAs(savepath + @"\" + filename);
                    //folder path is 
                    savepath = @"C:\\TweebaaWebEn\\TweebaaWebEn\\UploadImg";
                    file.SaveAs(savepath + @"\CollageImg\" + filename);
                }
                /*
                String str = context.Request["imgData"];
                //context.Response.Write(s);
                //s = s.Replace(" ", "");
                //remove data:image/png;base64,
                //byte[] imageBytes = System.Convert.FromBase64String(s);
                byte[] bytes = new byte[str.Length * sizeof(char)];
                System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);


                
                FileStream fs = new FileStream(savepath + @"\CollageImg\" + filename, FileMode.Create);
                // Create the writer for data.
                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(bytes);

                fs.Close();
                bw.Close();
                 * */

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