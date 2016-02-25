using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// prdprice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Prdprice
	{
        public Prdprice()
		{}
        #region Model
        private Guid _guid;
        private Guid _prdguid;
        private DateTime? _edttime = DateTime.Now;
        private decimal? _p1;
        private decimal? _p2;
        private decimal? _price;
        private int? _ruleid;
        private int _uploadBatchNo;

        public int UpLoadBatchNo
        {
            get { return _uploadBatchNo; }
            set { _uploadBatchNo = value; }
        }

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
        public decimal? p1
        {
            set { _p1 = value; }
            get { return _p1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? p2
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
        /// <summary>
        /// 
        /// </summary>
        public int? ruleid
        {
            set { _ruleid = value; }
            get { return _ruleid; }
        }
        #endregion Model

	}
}

