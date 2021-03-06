﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    [Serializable]
    public partial class Coupons
    {
        public Coupons()
		{

        }

        #region Model
        private int _coupon_id;
        private char _coupon_type;
        private string _coupon_name;
        private string _coupon_code;
        private float _coupon_amount;
        private float _coupon_minimum_order;
        private DateTime _coupon_start_date;
        private DateTime _coupon_expire_date;
        private short _uses_per_coupon;
        private short _uses_per_user;
        private short _is_restrict_to_products;
        private string _restrict_to_products;
        private short _is_restrict_to_categories;
        private string _restrict_to_categories;
        private short _is_restrict_to_customers;
        private short _coupon_active;
        private DateTime _date_created;
        private DateTime _date_modified;

        public string restrict_to_products
        {
            set { _restrict_to_products = value; }
            get { return _restrict_to_products; }
        }
        public string restrict_to_categories
        {
            set { _restrict_to_categories = value; }
            get { return _restrict_to_categories; }
        }
        public int CouponID
        {
            set { _coupon_id = value; }
            get { return _coupon_id; }
        }
        public char CouponType
        {
            set { _coupon_type = value; }
            get { return _coupon_type; }
        }
        
        public string CouponName
        {
            set { _coupon_name = value; }
            get { return _coupon_name; }
        }
        public string CouponCode
        {
            set { _coupon_code = value; }
            get { return _coupon_code; }
        }
        public float CouponAmount
        {
            set { _coupon_amount = value; }
            get { return _coupon_amount; }
        }
        public float CouponMinimumOrder
        {
            set { _coupon_minimum_order = value; }
            get { return _coupon_minimum_order; }
        }
        public DateTime CouponStartDate
        {
            set { _coupon_start_date = value; }
            get { return _coupon_start_date; }
        }
        public DateTime CouponExpireDate
        {
            set { _coupon_expire_date = value; }
            get { return _coupon_expire_date; }
        }
        public short UsesPerCoupon
        {
            set { _uses_per_coupon = value; }
            get { return _uses_per_coupon; }
        }
        public short UsesPerUser
        {
            set { _uses_per_user = value; }
            get { return _uses_per_user; }
        }
        public short IsRestrictToProducts
        {
            set { _is_restrict_to_products = value; }
            get { return _is_restrict_to_products; }
        }
        public short IsRestrictToCategories
        {
            set { _is_restrict_to_categories = value; }
            get { return _is_restrict_to_categories; }
        }
        public short IsRestrictToCustomers
        {
            set { _is_restrict_to_customers = value; }
            get { return _is_restrict_to_customers; }
        }
        public short CouponActive
        {
            set { _coupon_active = value; }
            get { return _coupon_active; }
        }
        public DateTime DateCreated
        {
            set { _date_created = value; }
            get { return _date_created; }
        }
        public DateTime DateModified
        {
            set { _date_modified = value; }
            get { return _date_modified; }
        }

        #endregion Model
    }
}
