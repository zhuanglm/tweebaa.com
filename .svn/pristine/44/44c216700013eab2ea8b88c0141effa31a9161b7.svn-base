using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Mgr
{
     public partial class CheckoutTmpMgr
    {
         private readonly Twee.DataMgr.CheckoutTmpDataMgr mgr = new DataMgr.CheckoutTmpDataMgr();

         public int Add(Twee.Model.CheckoutTmp model)
         {
             return mgr.Add(model);
         }

         public Twee.Model.CheckoutTmp GetCheckoutTmp(string OrderNo)
         {
             return mgr.GetCheckoutTmp(OrderNo);
         }
    }
}
