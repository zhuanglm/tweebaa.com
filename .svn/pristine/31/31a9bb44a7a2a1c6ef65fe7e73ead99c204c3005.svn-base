using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Mgr
{

    public partial class CouponMgr
    {
        private readonly Twee.DataMgr.CouponDataMgr dal = new Twee.DataMgr.CouponDataMgr();
        public CouponMgr()
        { }
        public float CheckCoupon(string strCouponCode, string strOrderTotal, string strUserGuid)
        {
            return dal.CheckCoupon(strCouponCode, strOrderTotal, strUserGuid);
        }
        public int CouponAdd(Twee.Model.Coupons coupon)
        {
            return dal.CouponAdd(coupon);
        }
        public bool Update(Twee.Model.Coupons coupon)
        {
            return dal.Update(coupon);
        }
        public bool Delete(int id){
            return dal.Delete(id);
        }
        public DataTable MgeGetPageCoupons(bool bActiveOnly, int iStartRow, int iEndRow, out int iTotalCount, string strWhere)
        {
            return dal.MgeGetPageCoupons(bActiveOnly, iStartRow, iEndRow, out iTotalCount, strWhere);
        }
        public DataTable LoadSingleCoupon(string sCouponID){
            return dal.LoadSingleCoupon(sCouponID);
        }
        public void ChangeCouponStatus(bool bIsActive, string sCouponID)
        {
            dal.ChangeCouponStatus(bIsActive, sCouponID);
        }
    }
}
