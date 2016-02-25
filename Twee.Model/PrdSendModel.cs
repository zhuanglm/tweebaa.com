using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Twee.Model
{
    public class PrdSendModel
    {
            //dicProducts.Add("owner_id", OwnerId);//Y货主ID
            //dicProducts.Add("product_id", "prd001");//Y商品编号
            //dicProducts.Add("product_name", "产品1");//Y商品简称
            //dicProducts.Add("product_title", "产品1");// Y商品标题
            //dicProducts.Add("category", "");// 商品类目(调类目接口获取)
            //dicProducts.Add("remark", "");// 备注

            public string owner_id { get; set; }       
            public string product_id { get; set; }
            public string product_name { get; set; }
            public string product_title { get; set; }
            public string category { get; set; }
            public string remark { get; set; }

            public DataTable sku { get; set; }
        
         
    }
    public class products
    {
        public List<PrdSendModel> models { get; set; }
    }
}
