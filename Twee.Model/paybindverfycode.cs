using System;
namespace Twee.Model
{
    /// <summary>
    /// paybindverfycode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class paybindverfycode
    {
        public paybindverfycode()
        { }
        #region Model
        private int _id;
        private string _phone;
        private string _verfycode;
        private DateTime? _createtime;
        private Guid _userid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string verfycode
        {
            set { _verfycode = value; }
            get { return _verfycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        #endregion Model

    }
}

