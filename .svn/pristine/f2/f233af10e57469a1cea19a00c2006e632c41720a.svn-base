using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using TweebaaWebApp2.Method;
using System;

namespace TweebaaWebApp2.Events.Tweebot
{
	public class FileTransferHandler : IHttpHandler {
		private readonly JavaScriptSerializer js = new JavaScriptSerializer();

        string[] strArrFfmpeg = new string[] { "wmv", "mov", "asf", "avi", "mpg", "3gp", "rm", "rmvb" };
        string[] strArrMencoder = new string[] { "rm", "rmvb" };

        /*
		public string StorageRoot {
            get { return Server.MapPath("~" + "/upload/UploadVideo/"); }
		}*/
		public bool IsReusable { get { return false; } }

		public void ProcessRequest (HttpContext context) {
			context.Response.AddHeader("Pragma", "no-cache");
			context.Response.AddHeader("Cache-Control", "private, no-cache");

			HandleMethod(context);
		}

		// Handle request based on method
		private void HandleMethod (HttpContext context) {
			switch (context.Request.HttpMethod) {
				case "HEAD":
				case "GET":
					if (GivenFilename(context)) DeliverFile(context);
					else ListCurrentFiles(context);
					break;

				case "POST":
				case "PUT":
					UploadFile(context);
					break;

				case "DELETE":
					DeleteFile(context);
					break;

				case "OPTIONS":
					ReturnOptions(context);
					break;

				default:
					context.Response.ClearHeaders();
					context.Response.StatusCode = 405;
					break;
			}
		}

		private static void ReturnOptions(HttpContext context) {
			context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
			context.Response.StatusCode = 200;
		}

		// Delete file from the server
		private void DeleteFile (HttpContext context) {
            var filePath = context.Server.MapPath("~" + "/upload/UploadVideo/") + context.Request["f"];
			if (File.Exists(filePath)) {
				File.Delete(filePath);
			}
		}

		// Upload file to the server
		private void UploadFile (HttpContext context) {
			var statuses = new List<FilesStatus>();
			var headers = context.Request.Headers;

			if (string.IsNullOrEmpty(headers["X-File-Name"])) {
				UploadWholeFile(context, statuses);
			} else {
				UploadPartialFile(headers["X-File-Name"], context, statuses);
			}

			WriteJsonIframeSafe(context, statuses);
		}

		// Upload partial file
		private void UploadPartialFile (string fileName, HttpContext context, List<FilesStatus> statuses) {
			if (context.Request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
			var inputStream = context.Request.Files[0].InputStream;
            var fullName = context.Server.MapPath("~" + "/upload/UploadVideo/") + Path.GetFileName(fileName);

			using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write)) {
				var buffer = new byte[1024];

				var l = inputStream.Read(buffer, 0, 1024);
				while (l > 0) {
					fs.Write(buffer, 0, l);
					l = inputStream.Read(buffer, 0, 1024);
				}
				fs.Flush();
				fs.Close();
			}
			statuses.Add(new FilesStatus(new FileInfo(fullName)));
		}

		// Upload entire file
		private void UploadWholeFile (HttpContext context, List<FilesStatus> statuses) {
			for (int i = 0; i < context.Request.Files.Count; i++) {
				var file = context.Request.Files[i];
                string m_strExtension = PublicMethod.GetExtension(file.FileName).ToLower();
                string saveName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string playFile = context.Server.MapPath("~" + "/" + PublicMethod.playFile + saveName + "." + m_strExtension);
                string imgFile = context.Server.MapPath("~" + "/" + PublicMethod.imgFile + saveName);

               // file.SaveAs(context.Server.MapPath("~" + "/upload/UploadVideo/") + Path.GetFileName(file.FileName));
                file.SaveAs(playFile);

                string fullName = Path.GetFileName(playFile);//file.FileName);

                //Do video screenshot
                MakeJpgFile(fullName, playFile, imgFile);
				statuses.Add(new FilesStatus(fullName, file.ContentLength));
			}
		}
        private void MakeJpgFile(string upFileName,string videoFileName, string imgFile)
        {
            PublicMethod pm = new PublicMethod();
            string m_strExtension = PublicMethod.GetExtension(videoFileName).ToLower();
            string saveType = "flv";
            //Twee.Comm.CommHelper.WrtLog("ext=" + m_strExtension);
            if (m_strExtension == "flv")
            {//直接拷贝到播放文件夹下
                //System.IO.File.Copy(upFileName, playFile + ".flv");//正式的
                //System.IO.File.Copy(upFileName, context.Server.MapPath("~" + "/" + PublicMethod.playFile + fileName), true);//临时
                pm.CatchImg(videoFileName, imgFile);
                // this.FileUpload1.SaveAs(imgFile + ".jpg");
            }
            else if (m_strExtension == "mp4")
            {
                //System.IO.File.Copy(upFileName, playFile + ".mp4");//正式的
                // Twee.Comm.CommHelper.WrtLog("try to copy" + upFileName + " to " + context.Server.MapPath("~" + "/" + PublicMethod.playFile + fileName));
                //System.IO.File.Copy(upFileName, context.Server.MapPath("~" + "/" + PublicMethod.playFile + fileName), true);//临时
                //Twee.Comm.CommHelper.WrtLog("try to catch");
                pm.CatchImg(videoFileName, imgFile);
                // this.FileUpload1.SaveAs(imgFile + ".jpg");
                saveType = "mp4";
            }
            else
            {
                string Extension = CheckExtension(m_strExtension);
                if (Extension == "ffmpeg")
                {
                    pm.ChangeFilePhy(upFileName, videoFileName, imgFile);

                }
                else if (Extension == "mencoder")
                {
                    pm.MChangeFilePhy(upFileName, videoFileName, imgFile);
                }
            }
            //InsertData(this.txtTitle.Text, fileName, saveName, saveType);
            //context.Session["file"] = fileName;
           // fileName = fileName.Substring(0, fileName.IndexOf("."));
            //showError(1, PublicMethod.playFile + "/" + saveName + "." + saveType, context, PublicMethod.imgFile + "/" + imgFile + ".jpg");正式的
            //临时
            //string strpath = PublicMethod.playFile + fileName + "." + saveType;
            // Twee.Comm.CommHelper.WrtLog("showerror=" + strpath);
            //strpath = strpath.Replace(@"//",@"/");
            //showError(1, strpath, context, PublicMethod.imgFile + "/" + imgFile + ".jpg", "");
            //showError(1, strpath, context, PublicMethod.imgFile + "/" + saveName + ".jpg", "");
        }

        private string CheckExtension(string extension)
        {
            string m_strReturn = "";
            foreach (string var in this.strArrFfmpeg)
            {
                if (var == extension)
                {
                    m_strReturn = "ffmpeg"; break;
                }
            }
            if (m_strReturn == "")
            {
                foreach (string var in strArrMencoder)
                {
                    if (var == extension)
                    {
                        m_strReturn = "mencoder"; break;
                    }
                }
            }
            return m_strReturn;
        }
		private void WriteJsonIframeSafe (HttpContext context, List<FilesStatus> statuses) {
			context.Response.AddHeader("Vary", "Accept");
			try {
				if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
					context.Response.ContentType = "application/json";
				else
					context.Response.ContentType = "text/plain";
			} catch {
				context.Response.ContentType = "text/plain";
			}

			var jsonObj = js.Serialize(statuses.ToArray());
			context.Response.Write(jsonObj);
		}

		private static bool GivenFilename (HttpContext context) {
			return !string.IsNullOrEmpty(context.Request["f"]);
		}

		private void DeliverFile (HttpContext context) {
			var filename = context.Request["f"];
            var filePath = context.Server.MapPath("~" + "/upload/UploadVideo/") + filename;

			if (File.Exists(filePath)) {
				context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
				context.Response.ContentType = "application/octet-stream";
				context.Response.ClearContent();
				context.Response.WriteFile(filePath);
			} else
				context.Response.StatusCode = 404;
		}

		private void ListCurrentFiles (HttpContext context) {
			var files =
                new DirectoryInfo(context.Server.MapPath("~" + "/upload/UploadVideo/"))
					.GetFiles("*", SearchOption.TopDirectoryOnly)
					.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
					.Select(f => new FilesStatus(f))
					.ToArray();

			string jsonObj = js.Serialize(files);
			context.Response.AddHeader("Content-Disposition", "inline; filename=\"files.json\"");
			context.Response.Write(jsonObj);
			context.Response.ContentType = "application/json";
		}
	}
}