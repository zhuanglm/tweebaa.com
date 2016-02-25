using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    /// <summary>
    /// 叠图去产品图片
    /// </summary>
    [Serializable]
    public class SharePrd
    {
        public SharePrd()
        { }
        #region Model
        private Guid _thing_id;
        private string _imgurl;
        private string _img_mask;
        private string _img_opaque;
        private string _url;
        private string _object_class;
        private string _ow;
        private string _w;
        private string _h;
        private string _oh;
        private string _brand_id;
        private string _displayurl;
        private string _seo_title;
        private decimal? _display_price;
        private string _masking_policy;
        private DateTime? _edttime;
        private DateTime? _addtime;
        /// <summary>
        /// 
        /// </summary>
        public Guid thing_id
        {
            set { _thing_id = value; }
            get { return _thing_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgurl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string img_mask
        {
            set { _img_mask = value; }
            get { return _img_mask; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string img_opaque
        {
            set { _img_opaque = value; }
            get { return _img_opaque; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string object_class
        {
            set { _object_class = value; }
            get { return _object_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ow
        {
            set { _ow = value; }
            get { return _ow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string w
        {
            set { _w = value; }
            get { return _w; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string h
        {
            set { _h = value; }
            get { return _h; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oh
        {
            set { _oh = value; }
            get { return _oh; }
        }
         /// <summary>
        /// 
        /// </summary>
        public string brand_id
        {
            set { _brand_id = value; }
            get { return _brand_id; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string displayurl
        {
            set { _displayurl = value; }
            get { return _displayurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string seo_title
        {
            set { _seo_title = value; }
            get { return _seo_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? display_price
        {
            set { _display_price = value; }
            get { return _display_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string masking_policy
        {
            set { _masking_policy = value; }
            get { return _masking_policy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? edtTime
        {
            set { _edttime = value; }
            get { return _edttime; }
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
