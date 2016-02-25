using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    	[Serializable]
	public partial class CollageDesign
    {
        public CollageDesign()
		{

        }
		#region Model
		private int _id;  //CollageDesign_ID	int	
        private int _template_id; //CollageTemp_ID	int	
        private short _status;//CollageDesign_Status	tinyint	
        private int _cateID; //CollageCate_ID	int
        private string _Title;
        private string _tags; //CollageDesign_Tag	nvarchar(300)
        private string _Inspiration;// CollageDesign_Inspiration	nvarchar(500)
        private Guid _guid; //CollageDesign_CreateUserGuid	uniqueidentifier
        private string _CreateTime;//CollageDesign_CreateTime	datetime
        private string _UpdateTime;//CollageDesign_UpdateTime	datetime
        private string _PublishTime;//CollageDesign_PublishTime	datetime
        private string _innerHTML;//CollageDesign_HTML	nvarchar(300)
        private string _thumbnail; //CollageDesign_ThumbnailFileName	nvarchar(300)
        private string _templateHTML;//
        private string _product_id1; 
            
        private string _product_id2;
        private string _product_id3;
        private string _product_id4;

        private string _product_id5;
        private string _product_id6;
        private string _product_id7;
        private string _product_id8;

        private string _product_ids;

        private string _user_name;

        private string _city;
        private string _country;
        private int _iShareTotalCount;
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
        public int template_id
        {
            set { _template_id = value; }
            get { return _template_id; }
        }
        /// <summary>
        public short status_id
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>        

        /// <summary>
        public int cate_id
        {
            set { _cateID = value; }
            get { return _cateID; }
        }
        /// <summary>         
            /// 
        public string CollageDesing_Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
		/// </summary>
		public string tags
		{
            set { _tags = value; }
            get { return _tags; }
		}
        public string Inspiration
        {
            set { _Inspiration = value; }
            get { return _Inspiration; }
        }


        public Guid guid
        {
            set { _guid = value; }
            get { return _guid; }
        }

        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
        public string PublishTime
        {
            set { _PublishTime = value; }
            get { return _PublishTime; }
        }
        public string innerHTML
        {
            set { _innerHTML = value; }
            get { return _innerHTML; }
        }
        public string thumbnail
        {
            set { _thumbnail = value; }
            get { return _thumbnail; }
        }           
        public string TemplateHTML
        {
            set { _templateHTML = value; }
            get { return _templateHTML; }
        }

        public string Product_ids
        {
            set { _product_ids = value; }
            get { return _product_ids; }
        }
        public string Product_ID1
        {
            set { _product_id1 = value; }
            get { return _product_id1; }
        }

        public string Product_ID2
        {
            set { _product_id2 = value; }
            get { return _product_id2; }
        }
        public string Product_ID3
        {
            set { _product_id3 = value; }
            get { return _product_id3; }
        }
        public string Product_ID4
        {
            set { _product_id4 = value; }
            get { return _product_id4; }
        }

        public string Product_ID5
        {
            set { _product_id5 = value; }
            get { return _product_id5; }
        }

        public string Product_ID6
        {
            set { _product_id6 = value; }
            get { return _product_id6; }
        }
        public string Product_ID7
        {
            set { _product_id7 = value; }
            get { return _product_id7; }
        }
        public string Product_ID8
        {
            set { _product_id8 = value; }
            get { return _product_id8; }
        }
        public string User_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }
            public int ShareTotalCount
        {
            set { _iShareTotalCount = value; }
            get { return _iShareTotalCount; }
        }
            #endregion Model
    }


}
