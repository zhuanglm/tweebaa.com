using System;
namespace Twee.Model
{
    /// <summary>
    /// PrdPrice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PrdPrices
    {
        public PrdPrices()
        { }
        #region Model
        private Guid _guid;
        private Guid _prdguid;
        private DateTime? _edttime = DateTime.Now;
        private int? _p1;
        private int? _p2;
        private decimal? _price;
        /// <summary>
        /// 
        /// </summary>
        public Guid guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid prdguid
        {
            set { _prdguid = value; }
            get { return _prdguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? edttime
        {
            set { _edttime = value; }
            get { return _edttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? p1
        {
            set { _p1 = value; }
            get { return _p1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? p2
        {
            set { _p2 = value; }
            get { return _p2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}

