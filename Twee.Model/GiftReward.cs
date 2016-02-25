using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    /// <summary>
    /// user Gift reward
    /// </summary>
    [Serializable]
    public class GiftReward
    {
        public GiftReward()
        { }
        #region Model
        private int _id;
        private Guid _userGuid;
        private Guid? _prdGuid;
        private int _giftID;
        private int _giftQuantity;
        private Guid _grantUserGuid;
        private DateTime _grantDate;
        private int _giftSourceID;
        private int _shipStatusID;
        //private int? _shipPartnerID;
        //private int? _shipCarrierID;
        //private int? _shipServiceID;
        //private string _shipNum;
        //private DateTime? _shipDate;


        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserGuid
        {
            set { _userGuid = value; }
            get { return _userGuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid? ProductGuid
        {
            set { _prdGuid = value; }
            get { return _prdGuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GiftID
        {
            set { _giftID = value; }
            get { return _giftID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GiftQuantity
        {
            set { _giftQuantity = value; }
            get { return _giftQuantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime GrantDate
        {
            set { _grantDate = value; }
            get { return _grantDate; }
        }
        public int GiftSourceID
        {
            set { _giftSourceID = value; }
            get { return _giftSourceID; }
        }

        #endregion Model
    }
}
