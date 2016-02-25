using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TweebaaWebApp.Method
{
    public class PublicMethod : System.Web.UI.Page
    {
        public PublicMethod()
        {

        }
        //文件路径
        public static string ffmpegtool = ConfigurationManager.AppSettings["ffmpeg"];
        public static string mencodertool = ConfigurationManager.AppSettings["mencoder"];
        public static string mplayertool = ConfigurationManager.AppSettings["mplayer"];
        public static string upFile = ConfigurationManager.AppSettings["upfile"] + "/";
        public static string imgFile = ConfigurationManager.AppSettings["imgfile"] + "/";
        public static string playFile = ConfigurationManager.AppSettings["playfile"] + "/";
        //文件图片大小
        public static string sizeOfImg = ConfigurationManager.AppSettings["CatchFlvImgSize"];
        //文件大小
        public static string widthOfFile = ConfigurationManager.AppSettings["widthSize"];
        public static string heightOfFile = ConfigurationManager.AppSettings["heightSize"];
        //获取文件的名字
        public static string GetFileName(string fileName)
        {
            int i = fileName.LastIndexOf("\\") + 1;
            string Name = fileName.Substring(i);
            return Name;
        }
        //获取文件扩展名
        public static string GetExtension(string fileName)
        {
            int i = fileName.LastIndexOf(".") + 1;
            string Name = fileName.Substring(i);
            return Name;
        }
        //
        #region //运行FFMpeg的视频解码，(这里是绝对路径)
        /// <summary>
        /// 转换文件并保存在指定文件夹下面(这里是绝对路径)
        /// </summary>
        /// <param name="fileName">上传视频文件的路径（原文件）</param>
        /// <param name="playFile">转换后的文件的路径（网络播放文件）</param>
        /// <param name="imgFile">从视频文件中抓取的图片路径</param>
        /// <returns>成功:返回图片虚拟地址;   失败:返回空字符串</returns>
        public string ChangeFilePhy(string fileName, string playFile, string imgFile)
        {
            //取得ffmpeg.exe的路径,路径配置在Web.Config中,如:<add   key="ffmpeg"   value="E:\51aspx\ffmpeg.exe"   />   
            string ffmpeg = Server.MapPath(PublicMethod.ffmpegtool);
            if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(fileName)))
            {
                return "";
            }

            //获得图片和(.flv)文件相对路径/最后存储到数据库的路径,如:/Web/User1/00001.jpg   

            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");


            //截图的尺寸大小,配置在Web.Config中,如:<add   key="CatchFlvImgSize"   value="240x180"   />   
            string FlvImgSize = PublicMethod.sizeOfImg;

            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);

            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            FilestartInfo.Arguments = " -i " + fileName + " -y -ab 56 -ar 22050 -b 500 -r 15 -s " + widthOfFile + "x" + heightOfFile + " " + flv_file;

         
            //ImgstartInfo.Arguments = "   -i   " + fileName + "   -y   -f   image2   -t   0.05   -s   " + FlvImgSize + "   " + flv_img;

            //D:\ffmpeg\bin>ffmpeg.exe -i C:\Users\pc\Desktop\sp.mp4 -vf scale=500:-1 -t 100 ss.flv

            //参数
            //string Command = " -i " + uploadfileName + " -y -ab 56 -ar 22050 -b 500 -r 15 -s " + WidthAndHeight + " " + playfilename; //Flv格式

            try
            {

                //转换
                System.Diagnostics.Process.Start(FilestartInfo);
             
                //截图
                CatchImg(fileName, imgFile);
                //System.Diagnostics.Process.Start(ImgstartInfo);


            }
            catch
            {
                return "";
            }
            //
            return "";
        }
        //
        public string CatchImg(string fileName, string imgFile)
        {
            //
            string ffmpeg = Server.MapPath("~" + "/" + PublicMethod.ffmpegtool);
            //
            string flv_img = imgFile + ".jpg";
            //
            string FlvImgSize = PublicMethod.sizeOfImg;
            //
            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //
            ImgstartInfo.Arguments = "   -i   " + fileName + "  -y  -f  image2   -ss 2 -vframes 1  -s   " + FlvImgSize + "   " + flv_img;
            //Twee.Comm.CommHelper.WrtLog("ffmpeg -i   " + fileName + "  -y  -f  image2   -ss 2 -vframes 1  -s   " + FlvImgSize + "   " + flv_img);
            try
            {
                //System.Diagnostics.Process p = new System.Diagnostics.Process();
                //p.StartInfo.FileName = ffmpeg;
                //p.StartInfo.Arguments = Command;
                ////p.StartInfo.WorkingDirectory = workdirectory;
                //p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardInput = true;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.CreateNoWindow = false;

                
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch(Exception e)
            {
                Twee.Comm.CommHelper.WrtLog("error=" + e.Message);
                return "";
            }
            //
            if (System.IO.File.Exists(flv_img))
            {
                //Twee.Comm.CommHelper.WrtLog("flv img=" + flv_img);
                return flv_img;
            }
            //Twee.Comm.CommHelper.WrtLog("return null?");
            return "";
        }
        #endregion
        //
        #region //运行FFMpeg的视频解码，(这里是(虚拟)相对路径)
        /// <summary>
        /// 转换文件并保存在指定文件夹下面(这里是相对路径)
        /// </summary>
        /// <param name="fileName">上传视频文件的路径（原文件）</param>
        /// <param name="playFile">转换后的文件的路径（网络播放文件）</param>
        /// <param name="imgFile">从视频文件中抓取的图片路径</param>
        /// <returns>成功:返回图片虚拟地址;   失败:返回空字符串</returns>
        public string ChangeFileVir(string fileName, string playFile, string imgFile)
        {
            //取得ffmpeg.exe的路径,路径配置在Web.Config中,如:<add   key="ffmpeg"   value="E:\51aspx\ffmpeg.exe"   />   
            string ffmpeg = Server.MapPath(PublicMethod.ffmpegtool);
            if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(fileName)))
            {
                return "";
            }

            //获得图片和(.flv)文件相对路径/最后存储到数据库的路径,如:/Web/User1/00001.jpg   
            string flv_img = System.IO.Path.ChangeExtension(Server.MapPath(imgFile), ".jpg");
            string flv_file = System.IO.Path.ChangeExtension(Server.MapPath(playFile), ".flv");


            //截图的尺寸大小,配置在Web.Config中,如:<add   key="CatchFlvImgSize"   value="240x180"   />   
            string FlvImgSize = PublicMethod.sizeOfImg;

            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);

            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //此处组合成ffmpeg.exe文件需要的参数即可,此处命令在ffmpeg   0.4.9调试通过 
            //ffmpeg -i F:\01.wmv -ab 56 -ar 22050 -b 500 -r 15 -s 320x240 f:\test.flv
            FilestartInfo.Arguments = " -i " + fileName + " -ab 56 -ar 22050 -b 500 -r 15 -s " + widthOfFile + "x" + heightOfFile + " " + flv_file;
            ImgstartInfo.Arguments = "   -i   " + fileName + "   -y   -f   image2   -t   0.001   -s   " + FlvImgSize + "   " + flv_img;

            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }

            /**/
            ///注意:图片截取成功后,数据由内存缓存写到磁盘需要时间较长,大概在3,4秒甚至更长;   
            ///这儿需要延时后再检测,我服务器延时8秒,即如果超过8秒图片仍不存在,认为截图失败;   
            ///此处略去延时代码.如有那位知道如何捕捉ffmpeg.exe截图失败消息,请告知,先谢过!   
            if (System.IO.File.Exists(flv_img))
            {
                return flv_img;
            }

            return "";
        }
        #endregion

        #region //运行mencoder的视频解码器转换(这里是(绝对路径))
        public string MChangeFilePhy(string vFileName, string playFile, string imgFile)
        {
            string tool = Server.MapPath(PublicMethod.mencodertool);
            //string mplaytool = Server.MapPath(PublicMethod.ffmpegtool);

            if ((!System.IO.File.Exists(tool)) || (!System.IO.File.Exists(vFileName)))
            {
                return "";
            }

            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");


            //截图的尺寸大小,配置在Web.Config中,如:<add   key="CatchFlvImgSize"   value="240x180"   />   
            string FlvImgSize = PublicMethod.sizeOfImg;

            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(tool);

            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            FilestartInfo.Arguments = " mencoder '" + vFileName + "' -o '" + flv_file + "' -of lavf -lavfopts i_certify_that_my_video_stream_does_not_use_b_frames -oac mp3lame -lameopts abr:br=56 -ovc lavc -lavcopts vcodec=flv:vbitrate=200:mbd=2:mv0:trell:v4mv:cbp:last_pred=1:dia=-1:cmp=0:vb_strategy=1 -vf scale=" + widthOfFile + ":" + heightOfFile + " -ofps 12 -srate 22050"; 

           //FilestartInfo.Arguments = " mencoder infile.* -o outfile.flv -of lavf -oac mp3lame -lameopts abr:br=56 -ovc lavc -lavcopts vcodec=flv:vbitrate=150:mbd=2:mv0:trell:v4mv:cbp:last_pred=3 -srate 22050 mencoder infile.rmvb -o outfile.flv -vf scale=-3:150 -ofps 12 -oac mp3lame -ovc xvid -xvidencopts bitrate=112"

            //argu = @"-ffourcc FLV1 -lavfopts i_certify_that_my_video_stream_does_not_use_b_frames -of lavf -oac mp3lame -lameopts aq=9:cbr:br=64:vol=2 -ovc lavc -lavcopts vcodec=flv:vbitrate=300:acodec=mp3:abitrate=56 -vf scale=320:290,expand=320:290:::1,crop=320:290:0:0 -ofps 18 -srate 22050 " + orginalFile + " -o " + targetFile;

            //FilestartInfo.Arguments = "mencoder -ffourcc FLV1 -lavfopts i_certify_that_my_video_stream_does_not_use_b_frames -of lavf -oac mp3lame -lameopts aq=9:cbr:br=64:vol=2 -ovc lavc -lavcopts vcodec=flv:vbitrate=200:acodec=mp3:abitrate=56 -vf scale=320:270,expand=320:270:::1,crop=320:270:0:0 -ofps 18 -srate 22050 " + vFileName + " -o " + flv_file;

            //mencoder -ffourcc FLV1 -lavfopts i_certify_that_my_video_stream_does_not_use_b_frames -of lavf -oac mp3lame -lameopts aq=9:cbr:br=64:vol=2 -ovc lavc -lavcopts vcodec=flv:vbitrate=200:acodec=mp3:abitrate=56 -vf scale=320:270,expand=320:270:::1,crop=320:270:0:0 -ofps 18 -srate 22050 E:\重新架构框架\TweebaaWebFile\TweebaaWebFile\UploadVideo\IPX Marketing Dishwasher by Vortex (Low).wmv -o E:\重新架构框架\TweebaaWebFile\TweebaaWebFile\PlayVideo\201411121441559697.flv
         

        //mencoder 'E:/test.m2p' -o 'E:/output.flv' -of lavf  -lavfopts i_certify_that_my_video_stream_does_not_use_b_frames -oac mp3lame -lameopts abr:br=56 -ovc lavc -lavcopts vcodec=flv:vbitrate=500:mbd=2:mv0:trell:v4mv:cbp:last_pred=3:dia=4:cmp=6:vb_strategy=1 -vf scale=512:-3 -ofps 12 -srate 22050
          

            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
                CatchImg(flv_file, imgFile);
            }
            catch
            {
                return "";
            }
            //
            return "";
        }
        #endregion






        #region ydf

        #region  使用ffmpeg解码器转换视频格式

        /// <summary>
        /// 使用ffmpeg解码器转换视频格式 
        /// </summary>
        /// <param name="FromName">转换的视频文件名称,即上传后保存的文件名称</param>
        /// <returns></returns>
        public static string VideoConvertFlvFFMPEG(string FromName)
        {
            //获取web.config中的配置信息
            //解码器文件存放的绝对路径
            string ffmpeg = ConfigurationManager.AppSettings["ffmpeg"];
            ffmpeg = HttpContext.Current.Server.MapPath(ffmpeg);
            //转化后的flv文件的尺寸大小
            string widthOfFile = ConfigurationManager.AppSettings["Width"];
            string heightOfFile = ConfigurationManager.AppSettings["Height"];
            string WidthAndHeight = widthOfFile + "*" + heightOfFile;
            //上传文件虚拟地址
            string uploadfileadd = ConfigurationManager.AppSettings["uploadfileadd"];
            //转化后flv文件存放的虚拟地址
            string playfileadd = ConfigurationManager.AppSettings["playfileadd"];
            //截图文件存放的虚拟地址
            string imagefileadd = ConfigurationManager.AppSettings["imagefileadd"];

            //视频文件的绝对地址
            string uploadfileName = HttpContext.Current.Server.MapPath(uploadfileadd) + FromName;
            //转化后的flv文件绝对地址
            string playfilename = System.IO.Path.ChangeExtension(HttpContext.Current.Server.MapPath(playfileadd) + FromName, ".flv");

            //参数
            string Command = " -i " + uploadfileName + " -y -ab 56 -ar 22050 -b 500 -r 15 -s " + WidthAndHeight + " " + playfilename; //Flv格式

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = ffmpeg;
            p.StartInfo.Arguments = Command;
            //p.StartInfo.WorkingDirectory = workdirectory;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;

            string s = "";
            try
            {
                //开始执行
                p.Start();
                p.BeginErrorReadLine();
                p.WaitForExit();
                //if (CatchImg(playfileadd, imagefileadd, GetFileName(playfilename)) == "")
                //    s = "截图失败！";

            }
            catch
            { s = "视频转换出错啦！"; }
            finally
            {
                p.Close();
                p.Dispose();

            }
            //p.StandardInput.WriteLine(Command);
            //p.StandardInput.WriteLine("Exit ");
            return s;

        }

        #endregion

        #endregion
    }
}