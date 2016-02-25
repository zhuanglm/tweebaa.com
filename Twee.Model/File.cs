using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// file:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class File
	{
        public File()
		{}
		#region Model
		private Guid _fileguid;
		private Guid _prtguid;
		private string _filename;
		private string _fileurl;
        private string _fileurl2;
        private string _fileurl3;
		private int? _wntype;
		private int _idx;
		private Guid _prdguid;
        private DateTime? _addtime;
        private string _uploadImageURL;
        private int? _ruleid;             // the ruleid which the image belongs to  Added by Jack Cao 2016-01-14
        private int _uploadBatchNo;


        public int? ruleid
        {
            set { _ruleid = value; }
            get { return _ruleid; }
        }

        public string UploadImageURL
        {
            get { return _uploadImageURL; }
            set { _uploadImageURL = value; }
        }

        public int UpLoadBatchNo
        {
            get { return _uploadBatchNo; }
            set { _uploadBatchNo = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		public Guid fileguid
		{
			set{ _fileguid=value;}
			get{return _fileguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prtguid
		{
			set{ _prtguid=value;}
			get{return _prtguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filename
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 产品主缩略图
		/// </summary>
		public string fileurl
		{
			set{ _fileurl=value;}
			get{return _fileurl;}
		}
        /// <summary>
        /// 产品小缩略图
        /// </summary>
        public string fileurl2
        {
            set { _fileurl2 = value; }
            get { return _fileurl2; }
        }
        /// <summary>
        /// 产品放大镜图片
        /// </summary>
        public string fileurl3
        {
            set { _fileurl3 = value; }
            get { return _fileurl3; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? wntype
		{
			set{ _wntype=value;}
			get{return _wntype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int idx
		{
			set{ _idx=value;}
			get{return _idx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prdguid
		{
			set{ _prdguid=value;}
			get{return _prdguid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public DateTime? addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
		#endregion Model

	}
}

