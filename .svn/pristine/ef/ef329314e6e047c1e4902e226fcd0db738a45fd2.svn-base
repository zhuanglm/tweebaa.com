using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    /// <summary>
    /// MyReview:扩展类，包含会员中心【我的评审】信息
    /// </summary>
    [Serializable]
    public partial class MyReview
    {
        public MyReview()
        { }
        #region Model    
        private Guid? _prtguid;
        private Guid? _userGuid;//扩展字段（产品发布者id）
        private string _username;//扩展字段（产品发布者）
        private int? _reviewCount;//扩展字段（评审总数）
        private string _name;//扩展字段（产品名称）
        private decimal? _estimateprice;//扩展字段（产品价格）
        private string _prdstat;//扩展字段（产品状态）
        private DateTime? _reviewendtime;//扩展字段（评审结束时间）
        private DateTime? _presaleendtime;//扩展字段（预售结束时间）
        private DateTime? _edttime;//我的评审时间
        private string _fileurl;//扩展字段（图片）


        /// <summary>
        /// 产品id
        /// </summary>
        public Guid? prtguid
        {
            set { _prtguid = value; }
            get { return _prtguid; }
        }
        /// <summary>
        /// 产品发布者id
        /// </summary>
        public Guid? userGuid
        {
            set { _userGuid = value; }
            get { return _userGuid; }
        }

        /// <summary>
        /// 产品发布者
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 评审总数
        /// </summary>
        public int? reviewCount
        {
            set { _reviewCount = value; }
            get { return _reviewCount; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal? estimateprice
        {
            set { _estimateprice = value; }
            get { return _estimateprice; }
        }

          /// <summary>
        /// 产品状态
        /// </summary>
        public string prdstat
        {
            set { _prdstat = value; }
            get { return _prdstat; }
        }
      /// <summary>
        /// 评审结束时间
      /// </summary>
        public DateTime? reviewendtime
        {
            set { _reviewendtime = value; }
            get { return _reviewendtime; }
        }
        /// <summary>
        /// 预售结束时间
        /// </summary>
        public DateTime? presaleendtime
        {
            set { _presaleendtime = value; }
            get { return _presaleendtime; }
        }
        /// <summary>
        /// 我的评审时间
        /// </summary>
        public DateTime? edttime
        {
            set { _edttime = value; }
            get { return _edttime; }
        }

         /// <summary>
        /// 产品图片
        /// </summary>
        public string fileurl
        {
            set { _fileurl = value; }
            get { return _fileurl; }
        }      
       

        #endregion Model

    }
}
