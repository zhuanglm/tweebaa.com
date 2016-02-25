using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace TweebaaWebFile.Method
{
    public class FFMpeg
    {
        #region 定义变量

        // 存信變量
        private Hashtable _variables = new Hashtable();

        #endregion

        #region 定义属性

        /// <summary>
        /// ffmpeg.exe文件所在路徑
        /// </summary>
        public string Path
        {
            get { return (string)_variables["Path"]; }
            set { _variables.Add("Path", value); }
        }
        /// <summary>
        /// 要转换成FLV的宽度（默认400）
        /// </summary>
        public int FlvWidth
        {
            get
            {
                if (_variables.ContainsKey("FlvWidth")) return (int)_variables["FlvWidth"];
                else return 160;
            }
            set { _variables.Add("FlvWidth", value); }
        }
        /// <summary>
        /// 要转换成FLV的高度(默认350)
        /// </summary>
        public int FlvHeight
        {
            get
            {
                if (_variables.ContainsKey("FlvHeight")) return (int)_variables["FlvHeight"];
                else return 128;
            }
            set { _variables.Add("FlvHeight", value); }
        }
        /// <summary>
        /// 臷圖寬(默認240)
        /// </summary>
        public int ImageWidth
        {
            get
            {
                if (_variables.ContainsKey("ImageWidth")) return (int)_variables["ImageWidth"];
                else return 160;
            }
            set { _variables.Add("ImageWidth", value); }
        }
        /// <summary>
        /// 臷圖高(默認180)
        /// </summary>
        public int ImageHeight
        {
            get
            {
                if (_variables.ContainsKey("ImageHeight")) return (int)_variables["ImageHeight"];
                else return 128;
            }
            set { _variables.Add("ImageHeight", value); }
        }

        #endregion

        #region 构造函数

        public FFMpeg(string path)
        {
            Path = path;
        }

        #endregion

        #region 內部方法

        /// <summary>
        /// 转换为Flv文件
        /// </summary>
        private void RunFlv(string fullName, string path)
        {   //ffmpeg -i F:\01.wmv -ab 56 -ar 22050 -b 500 -r 15 -s 寬x高 f:\test.flv
            if (System.IO.File.Exists(fullName))
            {
                string flvName = System.IO.Path.ChangeExtension(fullName, ".flv");
                if (!String.IsNullOrEmpty(path))
                {
                    string lastChar = path.Substring(path.Length - 1);
                    if (lastChar == @"\" || lastChar == @"/") path = path.Substring(0, path.Length - 1);
                    //flvName = path + @"\" + GetFileName(flvName);
                    flvName = path + GetFileName(flvName);
                }
                string args = String.Format("-i {0} -ab 56 -ar 22050 -b 500 -r 15 -s {1}x{2} {3}", fullName, this.FlvWidth, this.FlvHeight, flvName);
                RunCmd(args);
            }
        }
        /// <summary>
        /// 转换为Jpg文件
        /// </summary>
        private void RunJpg(string fullName, string path)
        {   //ffmpeg -i F:\01.wmv -y -f image2 -t 0.001 -s  寬x高 f:\test.jpg;
            if (System.IO.File.Exists(fullName))
            {
                string jpgName = System.IO.Path.ChangeExtension(fullName, ".jpg");
                if (!String.IsNullOrEmpty(path))
                {
                    string lastChar = path.Substring(path.Length - 1);
                    if (lastChar == @"\" || lastChar == @"/") path = path.Substring(0, path.Length - 1);
                    jpgName = path + @"\" + GetFileName(jpgName);
                }
                string args = String.Format("-i {0} -y -f image2 -t 0.001 -s {1}x{2} {3}", fullName, this.ImageWidth, this.ImageHeight, jpgName);
                RunCmd(args);
            }
        }
        /// <summary>
        /// 從文件路徑中取得文件名
        /// </summary>
        private string GetFileName(string fullName)
        {
            fullName = fullName.Replace(@"/", @"\");
            return fullName.Substring(fullName.LastIndexOf(@"\"));
        }
        /// <summary>
        /// 运行Dos命令
        /// </summary>
        private void RunCmd(string args)
        {
            string cmdFile = this.Path + @"\ffmpeg.exe";
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo(cmdFile);
            processInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            processInfo.Arguments = args;
            processInfo.UseShellExecute = false;
            System.Diagnostics.Process.Start(processInfo);
        }

        #endregion

        #region 對外方法

        /// <summary>
        /// 转换为Flv文件
        /// </summary>
        public void ToFlv(string fullName)
        {
            RunFlv(fullName, String.Empty);
        }
        /// <summary>
        /// 转换为Flv文件到指定的目录
        /// </summary>
        public void ToFlv(string fullName, string path)
        {
            RunFlv(fullName, path);
        }
        /// <summary>
        /// 转换为Jpg文件
        /// </summary>
        public void ToJpg(string fullName)
        {
            RunJpg(fullName, String.Empty);
        }
        /// <summary>
        /// 转换为Jpg文件到指定的目录
        /// </summary>
        public void ToJpg(string fullName, string path)
        {
            RunJpg(fullName, path);
        }

        #endregion
    }
}


