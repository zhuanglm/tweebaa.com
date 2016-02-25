using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweebaaWebFile.Method;

namespace TweebaaWebFile.Server
{
    /// <summary>
    /// uploadVideo 的摘要说明
    /// </summary>
    public class uploadVideoEn : IHttpHandler
    {


        // 扩展名定义
        string[] strArrFfmpeg = new string[] { "wmv", "mov", "asf", "avi", "mpg", "3gp", "rm", "rmvb" };
        string[] strArrMencoder = new string[] { "rm", "rmvb" };
        //string[] strArrFfmpeg = new string[] { "wmv", "mov", "mp4", "flv" };//通过

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile videoFile = context.Request.Files["video"];

            string upFileName = "";
            if (!string.IsNullOrEmpty(videoFile.FileName))
            {
                string fileName = PublicMethod.GetFileName(videoFile.FileName);// GetFileName();
                //if ((string)Session["file"] == fileName)
                //{
                //    return;
                //}
             
                String savePath = System.Configuration.ConfigurationManager.AppSettings["upfile"].ToString();
                String dirPath = context.Server.MapPath("~" + "/" + savePath);
                //upFileName = context.Server.MapPath(PublicMethod.upFile + fileName);
                upFileName = dirPath + "/" + fileName;
                videoFile.SaveAs(dirPath+"/"+fileName);
                string saveName = DateTime.Now.ToString("yyyyMMddHHmmssffff");             
                string playFile = context.Server.MapPath("~" + "/" + PublicMethod.playFile + saveName);
                string imgFile = context.Server.MapPath("~" + "/" + PublicMethod.imgFile + saveName);

                int fileSize = videoFile.ContentLength;
                if (fileSize>1024*1024*5)
                {
                    showError(-4, playFile, context, imgFile,"Video size can not exceed 5M");
                    return;
                    
                }
                //System.IO.File.Copy(Server.MapPath(PublicMethod.playFile + "00000002.jpg"), Server.MapPath(PublicMethod.imgFile+"aa.jpg"));
                PublicMethod pm = new PublicMethod();
                string m_strExtension = PublicMethod.GetExtension(videoFile.FileName).ToLower();
                string saveType = "flv";
                if (m_strExtension == "flv")
                {//直接拷贝到播放文件夹下
                    //System.IO.File.Copy(upFileName, playFile + ".flv");//正式的
                    System.IO.File.Copy(upFileName, context.Server.MapPath("~" + "/" + PublicMethod.playFile + fileName),true);//临时
                    pm.CatchImg(upFileName, imgFile);
                    // this.FileUpload1.SaveAs(imgFile + ".jpg");
                }
                else if (m_strExtension == "mp4")
                {
                    //System.IO.File.Copy(upFileName, playFile + ".mp4");//正式的
                    System.IO.File.Copy(upFileName, context.Server.MapPath("~" + "/" + PublicMethod.playFile + fileName),true);//临时
                    pm.CatchImg(upFileName, imgFile);
                    // this.FileUpload1.SaveAs(imgFile + ".jpg");
                    saveType = "mp4";
                }
                else
                {
                    string Extension = CheckExtension(m_strExtension);
                    if (Extension == "ffmpeg")
                    {
                        pm.ChangeFilePhy(upFileName, playFile, imgFile);                       

                    }
                    else if (Extension == "mencoder")
                    {
                        pm.MChangeFilePhy(upFileName, playFile, imgFile);                                           
                    }
                }
                //InsertData(this.txtTitle.Text, fileName, saveName, saveType);
                //context.Session["file"] = fileName;
                fileName = fileName.Substring(0, fileName.IndexOf("."));
                //showError(1, PublicMethod.playFile + "/" + saveName + "." + saveType, context, PublicMethod.imgFile + "/" + imgFile + ".jpg");正式的
                //临时
                string strpath = PublicMethod.playFile  + fileName + "." + saveType;
                //strpath = strpath.Replace(@"//",@"/");
                showError(1, strpath, context, PublicMethod.imgFile + "/" + imgFile + ".jpg","");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
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

      

        #region 运行tool的视频解码

        /// <summary>
        /// @从视频文件截图,生成在视频文件所在文件夹,在Web.Config   中需要两个前置配置项: 1.ffmpeg.exe文件的路径   2.截图的尺寸大小3.视频处理程序ffmpeg.exe 
        /// </summary>
        /// <param name="vFileName">视频文件地址</param>
        /// <param name="playFile"></param>
        /// <param name="imgFile"></param>
        /// <returns>成功:返回图片虚拟地址;   失败:返回空字符串</returns>
        public string CatchImg(string vFileName, string playFile, string imgFile, HttpContext context)
        {
            //取得ffmpeg.exe的路径,路径配置在Web.Config中,如:<add   key="ffmpeg"   value="E:\51aspx\ffmpeg.exe"   />   

            // string tool = PublicMethod.ffmpegtool;
            string tool = PublicMethod.mencodertool;
            tool = context.Server.MapPath(tool);
            if ((!System.IO.File.Exists(tool)) || (!System.IO.File.Exists(vFileName)))
            {
                return "";
            }

            //获得图片和(.flv)文件相对路径/最后存储到数据库的路径,如:/Web/User1/00001.jpg   
            string flv_img = System.IO.Path.ChangeExtension(imgFile, ".jpg");
            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");


            //截图的尺寸大小,配置在Web.Config中,如:<add   key="CatchFlvImgSize"   value="240x180"   />   
            string FlvImgSize = PublicMethod.sizeOfImg;

            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(tool);
            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(tool);

            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //此处组合成tool.exe文件需要的参数即可,此处命令在tool   0.4.9调试通过 
            //tool -i F:\01.wmv -ab 56 -ar 22050 -b 500 -r 15 -s 320x240 f:\test.flv
            // FilestartInfo.Arguments = " -i " + vFileName + " -ab 56 -ar 22050 -b 500 -r 15 -s 320x240 " + flv_file;
            // ImgstartInfo.Arguments = "   -i   " + vFileName + "   -y   -f   image2   -t   0.001   -s   " + FlvImgSize + "   " + flv_img;
            FilestartInfo.Arguments = " " + vFileName + " -o " + flv_file + " -of lavf -lavfopts i_certify_that_my_video_stream_does_not_use_b_frames -oac mp3lame -lameopts abr:br=56 -ovc lavc -lavcopts vcodec=flv:vbitrate=200:mbd=2:mv0:trell:v4mv:cbp:last_pred=1:dia=-1:cmp=0:vb_strategy=1 -vf scale=512:-3 -ofps 12 -srate 22050";
            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }

            ///注意:图片截取成功后,数据由内存缓存写到磁盘需要时间较长,大概在3,4秒甚至更长;   
            ///这儿需要延时后再检测,我服务器延时8秒,即如果超过8秒图片仍不存在,认为截图失败;   
            ///此处略去延时代码.如有那位知道如何捕捉tool.exe截图失败消息,请告知,先谢过!
            if (System.IO.File.Exists(flv_img))
            {
                return flv_img;
            }

            return "";
        }

        #endregion

        private void showError(int resInt, string playFile, HttpContext context, string imgFile,string errMess)
        {
            // context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Clear();
            //context.Response.Write(resInt.ToString() + ":" + message);
            context.Response.Write("{resInt:'" + resInt.ToString() + "',playFile:'" + playFile + "',imgFile:'" + imgFile + "',message:'" + errMess + "'}"); 

            context.Response.End();
        }
    }
}