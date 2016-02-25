using System;
namespace Twee.Model
{
    /// <summary>
    /// knowTweeWay:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class knowTweeWay
    {
        public knowTweeWay()
        { }
        #region Model
        private int _id;
        private string _way;
        private DateTime? _createtime;
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
        public string way
        {
            set { _way = value; }
            get { return _way; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

