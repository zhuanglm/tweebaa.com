using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;
using System.Reflection;
using Twee.Model;
using System.Collections;
namespace Twee.DataMgr
{
    public class OrderDataMgr
    {      

        #region 后台方法

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <returns></returns>     
        public bool Add()
        {
            return true;
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>     
        public DataTable MgeGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.guid,a.guidno,a.address1,a.reciveName,a.recivePhone, a.addtime,a.wnstat,a.logisticscost,d.name,b.sumProMoney,e.idx from dbo.wn_orderhead a inner join dbo.wn_orderBody e on  a.guid=e.headGuid inner join(select headGuid, SUM(buydanJia * quantity) as sumProMoney from dbo.wn_orderBody  group by headGuid) b on a.guid=b.headGuid  inner join dbo.wn_user c on a.userguid=c.guid inner join dbo.wn_prd d on e.prdGuid=d.prdGuid  ");
            //strSql.Append("select a.guid,a.guidno,a.address1,a.addtime,a.wnstat,b.buydanJia,b.quantity,b.idx,b.buydanJia*b.quantity as sumProMoney, a.logisticscost ,c.username,c.phone,c.email,d.name from  dbo.wn_orderhead a inner join  dbo.wn_orderBody b on a.guid=b.headGuid inner join dbo.wn_user c on a.userguid=c.guid inner join dbo.wn_prd d on b.prdGuid=d.prdGuid ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="txtData1"></param>
        /// <param name="txtData2"></param>
        /// <param name="orderCode"></param>
        /// <param name="txtUser"></param>
        /// <param name="txtRecive"></param>
        /// <param name="orderby"></param>
        /// <param name="state"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable MgeGetListAll(string prdName,string txtData1, string txtData2, string orderCode, string txtUser, string txtRecive, string orderby, string state, int startIndex, int endIndex)
        {
            //select prtguid,u.username, cmdtype,cmdtxt,r.wnstat,r.edttime
            //    from dbo.wn_review r left join dbo.wn_user  u on r.userguid=u.guid

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.guid,TT.guidno,TT.addtime,TT.wnstat,TT.logisticscost, b.sumProMoney,e.idx,f.address address1,c.username  reciveName,c.phone recivePhone,zip,c.email, f.username as ShipToUserFirstName, f.lastname as ShipToUserLastName  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by a." + orderby); 
            }
            else
            {
                strSql.Append("order by a.addtime desc");
            }
            strSql.Append(")AS Row, a.*  from dbo.wn_orderhead a where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and a.wnstat=" + state);
            }
            if (!string.IsNullOrEmpty(txtData1.Trim()))
            {
                strSql.Append(" and a.addtime>='" + txtData1 + "'");
            }
            if (!string.IsNullOrEmpty(txtData2.Trim()))
            {
                strSql.Append(" and a.addtime<='" + txtData2 + "'");
            }
            if (!string.IsNullOrEmpty(orderCode.Trim()))
            {
                strSql.Append(" and a.guidno='" + orderCode + "'");
            }
            if (!string.IsNullOrEmpty(txtRecive.Trim()))
            {
                strSql.Append(" and a.reciveName='" + txtRecive + "'");
            }
            strSql.Append(" ) TT ");
            strSql.Append(" left join (select * from dbo.wn_orderBody where idx=1) e on  TT.guid=e.headGuid ");
            strSql.Append(" left join(select headGuid, SUM(buydanJia * quantity) as sumProMoney from dbo.wn_orderBody  group by headGuid) b on TT.guid=b.headGuid   ");
            strSql.Append(" left join dbo.wn_user c on TT.userguid=c.guid ");
            strSql.Append("left join (select u.address+' '+ v.ProName+' '+c.country address,guid,u.zip, u.username, u.lastname  from wn_useraddress u left join wn_Province v   on  u.provinceid=v.ProID left join wn_country c on u.countyid=c.id) f on TT.addressguid=f.guid");
            strSql.Append(" where  1=1 ");
            if (!string.IsNullOrEmpty(txtUser.Trim()))
            {
                strSql.Append(" and c.username='" + txtUser + "'");
            }
            if (!string.IsNullOrEmpty(prdName))
            {
                strSql.Append(" and d.name='" + prdName + "'");
            }
            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;


        }
        /// <summary>
        /// 获取订单记录总数
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="txtData1"></param>
        /// <param name="txtData2"></param>
        /// <param name="orderCode"></param>
        /// <param name="txtUser"></param>
        /// <param name="txtRecive"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int MgeGetRecordCount(string prdName, string txtData1, string txtData2, string orderCode, string txtUser, string txtRecive, string state)
        {
            //select prtguid,u.username, cmdtype,cmdtxt,r.wnstat,r.edttime
            //    from dbo.wn_review r left join dbo.wn_user  u on r.userguid=u.guid

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1)  from  dbo.wn_orderhead TT ");

            strSql.Append(" left join (select * from dbo.wn_orderBody where idx=1) e on  TT.guid=e.headGuid ");
            strSql.Append(" left join(select headGuid, SUM(buydanJia * quantity) as sumProMoney from dbo.wn_orderBody  group by headGuid) b on TT.guid=b.headGuid   ");
            strSql.Append(" left join dbo.wn_user c on TT.userguid=c.guid left join dbo.wn_prd d on e.prdGuid=d.prdGuid   ");
            strSql.Append(" where  1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and TT.wnstat=" + state);
            }
            if (!string.IsNullOrEmpty(txtData1.Trim()))
            {
                strSql.Append(" and TT.addtime>='" + txtData1 + "'");
            }
            if (!string.IsNullOrEmpty(txtData2.Trim()))
            {
                strSql.Append(" and TT.addtime<='" + txtData2 + "'");
            }
            if (!string.IsNullOrEmpty(orderCode.Trim()))
            {
                strSql.Append(" and TT.guidno>='" + orderCode + "'");
            }
            if (!string.IsNullOrEmpty(txtRecive.Trim()))
            {
                strSql.Append(" and TT.reciveName='" + txtRecive + "'");
            }
            if (!string.IsNullOrEmpty(txtUser.Trim()))
            {
                strSql.Append(" and c.username='" + txtUser + "'");
            }
            if (!string.IsNullOrEmpty(prdName))
            {
                strSql.Append(" and d.name='" + prdName + "'");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>       
        private DataTable MgeGetOrderInfo(Guid orderGuid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select [guid],[userguid] ,[edttime],[wnstat],[address1],[guidno],[addtime] ,[logisticscost],[messageWord],[upPriceTime],[upPriceMeassage],[expressNo],[payTime]  from [dbo].[wn_orderhead] where guid=@guid");
                SqlParameter[] paras = new SqlParameter[] { 
          new SqlParameter("@guid",SqlDbType.UniqueIdentifier)
        };
                paras[0].Value = orderGuid;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), paras);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
               
            }
            return null;

        }


        /// <summary>
        /// 获取订单产品详情列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>       
        public DataTable MgeGetOrderProInfo(Guid orderGuid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select b.idx, b.buydanJia,b.quantity,d.name,(case  when (b.buydanJia * b.quantity) is NULL then  0 else b.buydanJia * b.quantity   end ) proMoney from  dbo.wn_orderBody b inner join   dbo.wn_prd d on b.prdGuid=d.prdGuid where headGuid=@headGuid");
                SqlParameter[] paras = new SqlParameter[] { 
          new SqlParameter("@headGuid",SqlDbType.UniqueIdentifier)
        };
                paras[0].Value = orderGuid;

                DataSet ds = DbHelperSQL.Query(strSql.ToString(), paras);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
              
            }
            return null;

        }

        /// <summary>
        /// 获取收货人详细信息
        /// </summary>
        /// <param name="orderGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetOrderPeopleInfo(Guid orderGuid)
        {
            try
            {
                //string strSql = " select a.guid,a.guidno,a.address1,a.messageWord,c.username reciveName,c.phone recivePhone ,c.email from  dbo.wn_orderhead a inner join dbo.wn_user c on a.userguid=c.guid where a.guid=@guid";
                
                StringBuilder strSql=new StringBuilder();
                strSql.Append(" select f.* from dbo.wn_orderhead h");
                strSql.Append("  left join (select u.address+' '+ v.ProName+' '+c.country address1,guid,username,phone,tel,zip,email,u.userguid as AddrUserGuid from wn_useraddress u left join wn_Province v  on  u.provinceid=v.ProID      left join wn_country c on u.countyid=c.id) f on h.addressguid=f.guid ");
                strSql.Append(" where h.guid=@guid");

                SqlParameter[] paras = new SqlParameter[] { 
                  new SqlParameter("@guid",SqlDbType.UniqueIdentifier)
                };
                paras[0].Value = orderGuid;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), paras);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
               
            }
            return null;

        }

        /// <summary>
        /// 订单综合信息
        /// </summary>
        /// <param name="orderGuid"></param>
        /// <returns></returns>
        public Dictionary<string, string> MgeGetAllInfo(Guid orderGuid)
        {
            Dictionary<string, string> OrderInfoDic = new Dictionary<string, string>();
            try
            {
                DataTable dt1 = MgeGetOrderInfo(orderGuid);//订单信息
                DataTable dt2 = MgeGetOrderProInfo(orderGuid);//订单产品信息
                DataTable dt3 = MgeGetOrderPeopleInfo(orderGuid);//收货人信息
                if (dt1 != null && dt1.Rows.Count == 0)
                {
                    DataRow dr1 = dt1.NewRow();
                    dt1.Rows.Add(dr1);
                }
                if (dt2 != null && dt2.Rows.Count == 0)
                {
                    DataRow dr2 = dt2.NewRow();
                    dt2.Rows.Add(dr2);
                    dt2.Rows[0]["proMoney"] = "0";
                }
                if (dt3 != null && dt3.Rows.Count == 0)
                {
                    DataRow dr3 = dt3.NewRow();
                    dt3.Rows.Add(dr3);
                }

                OrderInfoDic["wnstat"] = dt1.Rows[0]["wnstat"].ToString();
                OrderInfoDic["guidno"] = dt1.Rows[0]["guidno"].ToString();
                OrderInfoDic["addtime"] = dt1.Rows[0]["addtime"].ToString();
                OrderInfoDic["messageWord"] = dt1.Rows[0]["messageWord"].ToString();
                OrderInfoDic["logisticscost"] = dt1.Rows[0]["logisticscost"].ToString();//物流费用
                OrderInfoDic["expressNo"] = dt1.Rows[0]["expressNo"].ToString();
                OrderInfoDic["edttime"] = dt1.Rows[0]["edttime"].ToString();
                OrderInfoDic["payTime"] = dt1.Rows[0]["payTime"].ToString();
                OrderInfoDic["upPriceMeassage"] = dt1.Rows[0]["upPriceMeassage"].ToString();
                var list = dt2.AsEnumerable().Select(t => t.Field<Decimal>("proMoney")).ToList();
                var sumProMoney = list.Select(a => a).Sum();
                OrderInfoDic["sumProMoney"] = sumProMoney.ToString();//商品总价
                OrderInfoDic["amountMoney"] = (OrderInfoDic["logisticscost"].ToDecimal() + OrderInfoDic["sumProMoney"].ToDecimal()).ToString();//最终结算

                OrderInfoDic["upPriceTime"] = dt1.Rows[0]["upPriceTime"].ToString();
                OrderInfoDic["upPriceMeassage"] = dt1.Rows[0]["upPriceMeassage"].ToString();             

                OrderInfoDic["address1"] = dt3.Rows[0]["address1"].ToString();
                OrderInfoDic["userName"] = dt3.Rows[0]["username"].ToString();
                OrderInfoDic["userPhone"] = dt3.Rows[0]["phone"].ToString();
                OrderInfoDic["zip"] = dt3.Rows[0]["zip"].ToString();
                OrderInfoDic["email"] = dt3.Rows[0]["email"].ToString();
                //如果email 为空，则从user table 里取
                string AddrUserGuid = dt3.Rows[0]["AddrUserGuid"].ToString();
                if (!String.IsNullOrEmpty(AddrUserGuid))
                {
                    string sSQL = "SELECT  email FROM   wn_user WHERE   (guid = '" + AddrUserGuid + "')";
                    object obj = DbHelperSQL.GetSingle(sSQL);
                    if(obj==null){

                    }else{
                        OrderInfoDic["email"]=obj.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
              
            }
            return OrderInfoDic;

        }
        /// <summary>
        /// 1改价/2支付/3发货/4完成/5作废
        /// </summary>
        /// <param name="dicUpdate">所有操作的参数集合</param>
        /// <param name="upAction">行为</param>
        /// <param name="orderGuid">订单ID</param>
        /// <returns></returns>
        public bool MgeUpDateInfo(Dictionary<string, string> dicUpdate, int upAction, Guid orderGuid)
        {
            try
            {
                string upDateSql = "";
                SqlParameter[] paras = null;
                //改价
                if (upAction == 1)
                {
                    string amountMoney = dicUpdate["amountMoney"];
                    string upPriceMeassage = dicUpdate["upPriceMeassage"];
                    string upPriceTime = DateTime.Now.ToString();
                    upDateSql = "update dbo.wn_orderhead set amountMoney=@amountMoney,upPriceMeassage=@upPriceMeassage,upPriceTime=@upPriceTime where guid=@guid";
                    paras = new SqlParameter[] { 
              new SqlParameter("@guid",SqlDbType.UniqueIdentifier),
              new SqlParameter("@amountMoney",SqlDbType.Decimal), 
              new SqlParameter("@upPriceMeassage",SqlDbType.NVarChar,50),     
              new SqlParameter("@upPriceTime",SqlDbType.DateTime)             
            };
                    paras[0].Value = orderGuid;
                    paras[1].Value = amountMoney;
                    paras[2].Value = upPriceMeassage;
                    paras[3].Value = upPriceTime;
                };

                //支付
                if (upAction == 2)
                {
                    upDateSql = "update dbo.wn_orderhead set wnstat=1,edttime=GETDATE() where guid=@guid";
                    paras = new SqlParameter[] { 
              new SqlParameter("@guid",SqlDbType.UniqueIdentifier)};
                    paras[0].Value = orderGuid;
                }
                //发货
                if (upAction == 3)
                {
                    paras = new SqlParameter[] { 
                  new SqlParameter("@guid",SqlDbType.UniqueIdentifier),
                  new SqlParameter("@expressCompanyGuid",SqlDbType.UniqueIdentifier), 
                  new SqlParameter("@expressNo",SqlDbType.NVarChar,20)
                 };
                    Guid expressCompanyGuid = new Guid(dicUpdate["expressCompanyGuid"]);
                    string expressNo = dicUpdate["expressNo"];
                    paras[0].Value = orderGuid;
                    paras[1].Value = expressCompanyGuid;
                    paras[2].Value = expressNo;
                    upDateSql = "update dbo.wn_orderhead set wnstat=2,expressCompanyGuid=@expressCompanyGuid,expressNo=@expressNo,edttime=GETDATE() where guid=@guid";
                }
                //完成
                if (upAction == 4)
                {
                    paras = new SqlParameter[] { 
                  new SqlParameter("@guid",SqlDbType.UniqueIdentifier)     
                 };
                    paras[0].Value = orderGuid;
                    upDateSql = "update dbo.wn_orderhead set wnstat=3,edttime=GETDATE() where guid=@guid";
                }
                //作废
                if (upAction == 5)
                {
                    paras = new SqlParameter[] { 
                  new SqlParameter("@guid",SqlDbType.UniqueIdentifier)     
                 };
                    paras[0].Value = orderGuid;
                    upDateSql = "update dbo.wn_orderhead set wnstat=-1,edttime=GETDATE() where guid=@guid";
                }
                int count = DbHelperSQL.ExecuteSql(upDateSql, paras);
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
               
            }
            return false;

        }


        /// <summary>
        /// 获取销售记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="state">2：预售区；3：销售区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <returns></returns>
        public DataTable MgeGetAllSale(string strWhere1, string strWhere2, string orderby, string state, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT quantity,buydanJia,quantity*buydanJia sunmAmount,h.guidno,h.edttime, p.name,u.username  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.guid desc");
            }
            strSql.Append(")AS Row, T.*  from dbo.wn_orderBody T ");
            if (!string.IsNullOrEmpty(strWhere1.Trim()))
            {
                strSql.Append(" WHERE " + strWhere1);
            }
            strSql.Append(" ) TT  left join wn_orderhead h on TT.headGuid=h.guid  left join  [dbo].[wn_prd] p on TT.prdGuid=p.prdGuid left join dbo.wn_user u on h.userguid=u.guid");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.AppendFormat(" and p.wnstat={0}", state);
            if (!string.IsNullOrEmpty(strWhere2.Trim()))
            {
                strSql.AppendFormat(" and " + strWhere2);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;


            //select b.quantity,b.buydanJia,b.quantity * b.buydanJia sunmAmount,h.guidno,h.edttime, p.name,u.username from wn_orderBody b left join wn_orderhead h on b.headGuid=h.guid 
            //left join  [dbo].[wn_prd] p on b.prdGuid=p.prdGuid left join dbo.wn_user u on h.userguid=u.guid
            //where p.wnstat=2


        }
        /// <summary>
        /// 获取订单所有产品图片
        /// </summary>
        /// <param name="headGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetOrderImg(string headGuid)
        {
            string StrSql = string.Format(" select h.guid, guidno,b.idx, b.prdGuid,f.fileurl  from    dbo.wn_orderhead  h  left join (select idx, headGuid,prdguid from  dbo.wn_orderBody where idx=1)  b on h.guid=b.headGuid left join   dbo.wn_file f on b.prdGuid=f.prdguid  where h.guid='{0}'", headGuid);
            DataSet ds = DbHelperSQL.Query(StrSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        /// <summary>
        /// Check if a customer order has been successfully shipped to fosdick not not
        /// </summary>
        /// <param name="guidno"></param>
        /// <returns></returns>
        public int MgeGetWarehouseShipOrderID(string sGuidNo)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select distinct a.ShipOrder_ID");
            sSql.Append(" from wn_OrderBody  a");
            sSql.Append(" inner join wn_ShipOrder b on b.ShipOrder_ID = a.ShipOrder_ID");
            sSql.Append(" where b.ShipPartner_ID = " +  ((int)ConfigParamter.ShipPartner.Fosdick).ToString());
            sSql.Append("  and b.OrderHead_GuidNo ='" + sGuidNo + "'");
            sSql.Append("  and b.ShipOrder_IsSuccess = 1");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ShipOrder_ID"].ToString().ToInt();
                }
            }
            return -1;
        }



        #endregion 

        #region  前台方法
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderHead"></param>
        /// <param name="listBody"></param>
        /// <returns></returns>
        public bool AddOrder(Orderhead orderHead,List<OrderBody> listBody)
        {
            try
            {
                string strsql = "insert into dbo.wn_orderhead (guid,userguid,guidno,wnstat,logisticscost,taxSum, taxGST,taxHST,taxQST, expressNo,expressCompanyGuid,addressguid,addtime,payTime,messageWord,userShopingAmount,useTweebuckAmount,useSharePointAmount) values (@guid,@userguid,@guidno,@wnstat,@logisticscost, @taxSum, @taxGST, @taxHST, @taxQST, @expressNo,@expressCompanyGuid,@addressguid,@addtime,@payTime,@messageWord,@userShopingAmount,@useTweebuckAmount,@useSharePointAmount)";

                DB db = new DB();
                bool bOK = db.DBConnectBeginTrans();

                SqlParameter[] paras = new SqlParameter[] { 
                  new SqlParameter("@userguid",SqlDbType.UniqueIdentifier),
                  new SqlParameter("@guidno",SqlDbType.NVarChar), 
                  new SqlParameter("@wnstat",SqlDbType.Int),     
                  new SqlParameter("@logisticscost",SqlDbType.Decimal),
                  new SqlParameter("@taxSum",SqlDbType.Decimal),
                  new SqlParameter("@taxGST",SqlDbType.Decimal),
                  new SqlParameter("@taxHST",SqlDbType.Decimal),
                  new SqlParameter("@taxQST",SqlDbType.Decimal),
                  new SqlParameter("@expressNo",SqlDbType.NVarChar),
                  new SqlParameter("@expressCompanyGuid",SqlDbType.UniqueIdentifier), 
                  new SqlParameter("@addressguid",SqlDbType.UniqueIdentifier),     
                  new SqlParameter("@addtime",SqlDbType.DateTime), 
                  new SqlParameter("@payTime",SqlDbType.DateTime), 
                  new SqlParameter("@messageWord",SqlDbType.NVarChar,50), 
                  new SqlParameter("@guid",SqlDbType.UniqueIdentifier),
                  new SqlParameter("@userShopingAmount",SqlDbType.Decimal),
                  new SqlParameter("@useTweebuckAmount",SqlDbType.Decimal),
                  new SqlParameter("@useSharePointAmount",SqlDbType.Decimal)
                };
                paras[0].Value = orderHead.userguid;
                paras[1].Value = orderHead.guidno;
                paras[2].Value = orderHead.wnstat;
                paras[3].Value = orderHead.logisticscost;
                paras[4].Value = orderHead.taxSum;
                paras[5].Value = orderHead.taxGST;
                paras[6].Value = orderHead.taxHST;
                paras[7].Value = orderHead.taxQST;
                paras[8].Value = orderHead.expressNo;
                paras[9].Value = orderHead.expressCompanyGuid;
                paras[10].Value = orderHead.addressguid;
                paras[11].Value = DateTime.Now;
                paras[12].Value = DateTime.Now;
                paras[13].Value = orderHead.messageWord;
                paras[14].Value = orderHead.guid;
                paras[15].Value = orderHead.userShopingAmount;
                paras[16].Value = orderHead.useTweebuckAmount;
                paras[17].Value = orderHead.useSharePointAmount;


                Hashtable hashSql = new Hashtable();
                hashSql.Add(strsql, paras);
                string temp = "";
                //int resuHead = DbHelperSQL.ExecuteSql(strsql, paras);
                int resuHead = db.DBExecute(strsql, paras);
                if (resuHead > 0)
                {
                    foreach (OrderBody item in listBody)
                    {
                        temp += ";";
                        string itemSql = "insert into  dbo.wn_orderBody  (guid,headGuid,prdGuid,quantity,buydanJia,edtTime,logisticscost, ShipMethod_ID, shareId,ruleid) values(@guid,@headGuid,@prdGuid,@quantity,@buydanJia,@edtTime,@logisticscost, @shipmethodid, @shareId,@ruleid)" + temp;
                        SqlParameter[] itemParas = new SqlParameter[] { 
                      new SqlParameter("@guid",SqlDbType.UniqueIdentifier),
                      new SqlParameter("@headGuid",SqlDbType.UniqueIdentifier),
                      new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier), 
                      new SqlParameter("@quantity",SqlDbType.Decimal), 
                      new SqlParameter("@buydanJia",SqlDbType.Decimal),     
                      //new SqlParameter("@idx",SqlDbType.Int),
                      new SqlParameter("@edtTime",SqlDbType.DateTime),
                      new SqlParameter("@logisticscost",SqlDbType.Decimal),
                      new SqlParameter("@shipmethodid",SqlDbType.Int),
                      new SqlParameter("@shareId",SqlDbType.UniqueIdentifier),
                      new SqlParameter("@ruleid",SqlDbType.Int) 
                    };
                        itemParas[0].Value = item.guid;
                        itemParas[1].Value = orderHead.guid;
                        itemParas[2].Value = item.prdGuid;
                        itemParas[3].Value = item.quantity;
                        itemParas[4].Value = item.buydanJia;
                        ///itemParas[5].Value = item.idx;
                        itemParas[5].Value = DateTime.Now;
                        itemParas[6].Value = item.logisticscost;
                        itemParas[7].Value = item.shipmethodid;
                        itemParas[8].Value = item.shareId;
                        itemParas[9].Value = item.ruleid;
                        //int resu = DbHelperSQL.ExecuteSql(itemSql, itemParas);
                        int resu = db.DBExecute(itemSql, itemParas);
                        //hashSql.Add(itemSql, itemParas);
                    }
                }
                //DbHelperSQL.ExecuteSqlTran(hashSql);

                db.DBDisconnectCommitTrans();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }           

        }
        //Add by Long 2016/01/20 for Events claim free products
        public void UpdateFreeProductClaimOrderNo(string strID,string strOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_FreeProductClaim set OrderGuidNo='" + strOrderNo + "' where FreeProductID=" + strID );
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void UpdateFreeProductIsClaim(string strOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_FreeProductClaim set IsClaim=1 where OrderGuidNo='" + strOrderNo + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public DataTable GetFreeProductInfoBySerialNo(string strSerialNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FreeProductID,OrderGuidNo,IsClaim FROM wn_FreeProductClaim where serial_code='" + strSerialNo + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;  
        }
        public DataTable GetFreeProductGuidForEvents(string strUserGuid)
        {

            StringBuilder strSql=new StringBuilder();
            strSql.Append("select FreeProductID,ProductGuid,serial_code FROM wn_FreeProductClaim where UserGuid='" + strUserGuid + "' and IsClaim=0");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >0)
            {
                return ds.Tables[0];
            }
            return null;  
        }
        /*
         * 为了兼容老版本
         */
        public bool AddOrder2(Orderhead orderHead, List<OrderBody> listBody)
        {
           
            try
            {
                string strsql = "insert into dbo.wn_orderhead (guid,userguid,guidno,wnstat,logisticscost,taxSum, taxGST,taxHST,taxQST, expressNo,expressCompanyGuid,addressguid,addtime,payTime,messageWord,userShopingAmount,useTweebuckAmount,useSharePointAmount,ShippingFirstname,ShippingLastname,ShippingAddress1,ShippingAddress2,ShippingCity,ShippingProvince,ShippingCountry,ShippingEmail,ShippingPhone,BillingFirstname,BillingLastname,BillingAddress1,BillingAddress2,BillingCity,BillingProvince,BillingCountry,BillingEmail,BillingPhone,ShippingZip,BillingZip,useCouponAmount,CouponCode) values (@guid,@userguid,@guidno,@wnstat,@logisticscost, @taxSum, @taxGST, @taxHST, @taxQST, @expressNo,@expressCompanyGuid,@addressguid,@addtime,@payTime,@messageWord,@userShopingAmount,@useTweebuckAmount,@useSharePointAmount,@ShippingFirstname,@ShippingLastname,@ShippingAddress1,@ShippingAddress2,@ShippingCity,@ShippingProvince,@ShippingCountry,@ShippingEmail,@ShippingPhone,@BillingFirstname,@BillingLastname,@BillingAddress1,@BillingAddress2,@BillingCity,@BillingProvince,@BillingCountry,@BillingEmail,@BillingPhone,@ShippingZip,@BillingZip,@useCouponAmount,@CouponCode)";

                DB db = new DB();
                bool bOK = db.DBConnectBeginTrans();
 
                SqlParameter[] paras = new SqlParameter[] { 
                  new SqlParameter("@userguid",SqlDbType.UniqueIdentifier),
                  new SqlParameter("@guidno",SqlDbType.NVarChar), 
                  new SqlParameter("@wnstat",SqlDbType.Int),     
                  new SqlParameter("@logisticscost",SqlDbType.Decimal),
                  new SqlParameter("@taxSum",SqlDbType.Decimal),
                  new SqlParameter("@taxGST",SqlDbType.Decimal),
                  new SqlParameter("@taxHST",SqlDbType.Decimal),
                  new SqlParameter("@taxQST",SqlDbType.Decimal),
                  new SqlParameter("@expressNo",SqlDbType.NVarChar),
                  new SqlParameter("@expressCompanyGuid",SqlDbType.UniqueIdentifier), 
                  new SqlParameter("@addressguid",SqlDbType.UniqueIdentifier),     
                  new SqlParameter("@addtime",SqlDbType.DateTime), 
                  new SqlParameter("@payTime",SqlDbType.DateTime), 
                  new SqlParameter("@messageWord",SqlDbType.NVarChar,100), 
                  new SqlParameter("@guid",SqlDbType.UniqueIdentifier),
                  new SqlParameter("@userShopingAmount",SqlDbType.Decimal),
                  new SqlParameter("@useTweebuckAmount",SqlDbType.Decimal),
                  new SqlParameter("@useSharePointAmount",SqlDbType.Decimal),
                  new SqlParameter("@ShippingFirstname",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingLastname",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingAddress1",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingAddress2",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingCity",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingProvince",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingCountry",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingEmail",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingPhone",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingFirstname",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingLastname",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingAddress1",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingAddress2",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingCity",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingProvince",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingCountry",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingEmail",SqlDbType.NVarChar,100),
                  new SqlParameter("@BillingPhone",SqlDbType.NVarChar,100),
                  new SqlParameter("@ShippingZip",SqlDbType.NVarChar,50),
                  new SqlParameter("@BillingZip",SqlDbType.NVarChar,50),
                  new SqlParameter("@useCouponAmount",SqlDbType.Decimal,50),
                  new SqlParameter("@CouponCode",SqlDbType.NVarChar,50)
                };
                paras[0].Value = orderHead.userguid;
                paras[1].Value = orderHead.guidno;
                paras[2].Value = orderHead.wnstat;
                paras[3].Value = orderHead.logisticscost;
                paras[4].Value = orderHead.taxSum;
                paras[5].Value = orderHead.taxGST;
                paras[6].Value = orderHead.taxHST;
                paras[7].Value = orderHead.taxQST;
                paras[8].Value = orderHead.expressNo;
                paras[9].Value = orderHead.expressCompanyGuid;
                paras[10].Value = orderHead.addressguid;
                paras[11].Value = DateTime.Now;
                paras[12].Value = DateTime.Now;
                paras[13].Value = orderHead.messageWord;
                paras[14].Value = orderHead.guid;
                paras[15].Value = orderHead.userShopingAmount;
                paras[16].Value = orderHead.useTweebuckAmount;
                paras[17].Value = orderHead.useSharePointAmount;

                paras[18].Value = orderHead.ShippingFirstname;
                paras[19].Value = orderHead.ShippingLastname;
                paras[20].Value = orderHead.ShippingAddress1;
                paras[21].Value = orderHead.ShippingAddress2;
                paras[22].Value = orderHead.ShippingCity;
                paras[23].Value = orderHead.ShippingProvince;
                paras[24].Value = orderHead.ShippingCountry;
                paras[25].Value = orderHead.ShippingEmail;
                paras[26].Value = orderHead.ShippingPhone;

                paras[27].Value = orderHead.BillingFirstname;
                paras[28].Value = orderHead.BillingLastname;
                paras[29].Value = orderHead.BillingAddress1;
                paras[30].Value = orderHead.BillingAddress2;
                paras[31].Value = orderHead.BillingCity;
                paras[32].Value = orderHead.BillingProvince;
                paras[33].Value = orderHead.BillingCountry;
                paras[34].Value = orderHead.BillingEmail;
                paras[35].Value = orderHead.BillingPhone;

                paras[36].Value = orderHead.ShippingZip;
                paras[37].Value = orderHead.BillingZip;

                paras[38].Value = orderHead.CouponAmount;
                paras[39].Value = orderHead.CouponCode;

                Hashtable hashSql = new Hashtable();
                hashSql.Add(strsql, paras);
                string temp = "";
                //int resuHead = DbHelperSQL.ExecuteSql(strsql, paras);
                int resuHead = db.DBExecute(strsql, paras);
                if (resuHead > 0)
                {
                    foreach (OrderBody item in listBody)
                    {
                        temp += ";";
                        string itemSql = "insert into  dbo.wn_orderBody  (guid,headGuid,prdGuid,quantity,buydanJia,edtTime,logisticscost, ShipMethod_ID, shareId,ruleid) values(@guid,@headGuid,@prdGuid,@quantity,@buydanJia,@edtTime,@logisticscost, @shipmethodid, @shareId,@ruleid)" + temp;
                        SqlParameter[] itemParas = new SqlParameter[] { 
                      new SqlParameter("@guid",SqlDbType.UniqueIdentifier),
                      new SqlParameter("@headGuid",SqlDbType.UniqueIdentifier),
                      new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier), 
                      new SqlParameter("@quantity",SqlDbType.Decimal), 
                      new SqlParameter("@buydanJia",SqlDbType.Decimal),     
                      //new SqlParameter("@idx",SqlDbType.Int),
                      new SqlParameter("@edtTime",SqlDbType.DateTime),
                      new SqlParameter("@logisticscost",SqlDbType.Decimal),
                      new SqlParameter("@shipmethodid",SqlDbType.Int),
                      new SqlParameter("@shareId",SqlDbType.UniqueIdentifier),
                      new SqlParameter("@ruleid",SqlDbType.Int) 
                    };
                        itemParas[0].Value = item.guid;
                        itemParas[1].Value = orderHead.guid;
                        itemParas[2].Value = item.prdGuid;
                        itemParas[3].Value = item.quantity;
                       
                        itemParas[4].Value = item.buydanJia;
                        //Twee.Comm.CommUtil.SendDebugString(" 1=" + itemParas[4].Value + " 2=" + item.buydanJia);
                        ///itemParas[5].Value = item.idx;
                        itemParas[5].Value = DateTime.Now;
                        itemParas[6].Value = item.logisticscost;
                        itemParas[7].Value = item.shipmethodid;
                        itemParas[8].Value = item.shareId;
                        itemParas[9].Value = item.ruleid;
                        //int resu = DbHelperSQL.ExecuteSql(itemSql, itemParas);
                        int resu = db.DBExecute(itemSql, itemParas);
                        //hashSql.Add(itemSql, itemParas);
                    }
                }
                //DbHelperSQL.ExecuteSqlTran(hashSql);

                bOK = db.DBDisconnectCommitTrans();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="userGuid">用户id</param>
        /// <returns></returns>
        public DataTable GetOrder(Guid userGuid)
        {
            StringBuilder strSql=new StringBuilder();          
            strSql.Append("select b.guid, headGuid,h.wnstat orderStat,h.guidno,b.prdGuid,quantity,p.name,p.estimateprice,p.saleprice,p.wnstat prdStat,f.fileurl,quantity*p.saleprice money from dbo.wn_orderBody b ");
            strSql.Append(" left join dbo.wn_orderhead h on b.headGuid=h.guid");
            strSql.Append(" left join dbo.wn_prd p on b.prdGuid=p.prdGuid ");
            strSql.Append(" left join dbo.wn_file f on f.prdguid=p.prdGuid ");
            strSql.Append(string.Format(" where h.userguid='{0}' and f.idx=0", userGuid));
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds!=null&&ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            return null;  
        }
       /// <summary>
       /// 根据订单号查询订单信息
       /// </summary>
       /// <param name="orderNo">订单号</param>
       /// <returns></returns>
        public DataTable GetOrderByOrserNo(string orderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.guid, headGuid,h.wnstat orderStat,h.guidno,b.prdGuid,quantity,p.name,p.estimateprice,p.saleprice,p.wnstat prdStat,f.fileurl,quantity*p.saleprice money,pr.color,pr.prorule from dbo.wn_orderBody b ");
            strSql.Append(" left join dbo.wn_orderhead h on b.headGuid=h.guid");
            strSql.Append(" left join dbo.wn_prd p on b.prdGuid=p.prdGuid ");
            strSql.Append(" left join dbo.wn_file f on f.prdguid=p.prdGuid ");
            strSql.Append(" left join wn_proRules pr on b.ruleid=pr.id");    
            strSql.Append(string.Format(" where h.guidno='{0}' and f.idx=0", orderNo));
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Order DataRowToModel(DataRow row)
        {
            Twee.Model.Order model = new Twee.Model.Order();
            if (row != null)
            {
                // b.guid, headGuid,b.prdGuid,quantity,p.name,p.saleprice,f.fileurl
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.orderBodyGuid = new Guid(row["guid"].ToString());
                }
                if (row["headGuid"] != null && row["headGuid"].ToString() != "")
                {
                    model.orderHeadGuid = new Guid(row["headGuid"].ToString());
                }
                if (row["guidno"] != null && row["guidno"].ToString() != "")
                {
                    model.guidno = row["guidno"].ToString();
                }
                if (row["prdGuid"] != null && row["prdGuid"].ToString() != "")
                {
                    model.prdGuid = new Guid(row["prdGuid"].ToString());
                }

                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = row["quantity"].ToString().ToDecimal();
                }
                if (row["name"] != null && row["name"].ToString() != "")
                {
                    model.name = row["name"].ToString();
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = row["estimateprice"].ToString().ToDecimal();
                }
                if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                {
                    model.salePrice =  row["saleprice"].ToString().ToDecimal();
                }
                if (row["fileurl"] != null && row["fileurl"].ToString() != "")
                {
                    model.fileurl = row["fileurl"].ToString();
                }
                if (row["money"] != null && row["money"].ToString() != "")
                {
                    model.money = row["money"].ToString().ToDecimal();
                }
                if (row["prdStat"] != null && row["prdStat"].ToString() != "")
                {
                    model.prdStat = int.Parse(row["prdStat"].ToString());
                }
                if (row["orderStat"] != null && row["orderStat"].ToString() != "")
                {
                    model.orderStat = int.Parse(row["orderStat"].ToString());
                }
            }
            return model;
        }

        //取订单状态
        //Add by Long for 
        public int GetOrderState(string guidno)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select wnstat from wn_orderhead where guidno='" + guidno+"'");
            object objResult = DbHelperSQL.GetSingle(strSql.ToString());
            if (objResult != null)
            {
                return objResult.ToString().ToInt();
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="guidno">订单号</param>
        /// <param name="state">订单状态</param>
        /// <returns></returns>
        public bool UpdateOrderState(string guidno,int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_orderhead set wnstat=@wnstat where guidno=@guidno");
            SqlParameter[] paras = new SqlParameter[]{
             new SqlParameter("@wnstat",SqlDbType.Int),
             new SqlParameter("@guidno",SqlDbType.NVarChar,50)
            };
            paras[0].Value = state;
            paras[1].Value = guidno;           
            CommHelper.WrtLog("order data mgr sql=" + strSql + " guidno=" + guidno + " stat=" + state.ToString());
            int resu = DbHelperSQL.ExecuteSql(strSql.ToString(), paras);
            if (resu>0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// update logicticcost of order header
        /// </summary>
        /// <param name="guidno">订单号</param>
        /// <param name="dLogisticsCost">shipping fee</param>
        /// <returns></returns>
        public bool UpdateOrderLogisticsCost(string guidno, decimal dLogisticsCost)
        {
            string strSql = "update wn_orderhead set logisticscost=@logisticscost where guidno=@guidno";
            SqlParameter[] paras = new SqlParameter[]{
             new SqlParameter("@logisticscost",SqlDbType.Decimal),
             new SqlParameter("@guidno",SqlDbType.NVarChar,50)
            };
            paras[0].Value = dLogisticsCost;
            paras[1].Value = guidno;

            int resu = DbHelperSQL.ExecuteSql(strSql, paras);
            if (resu > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 得到订单的收件人邮箱
        /// </summary>
        /// <param name="guidno"></param>
        /// <returns></returns>
        public string GetOrderEmail(string guidno)
        {
            string strSql = "select email from wn_useraddress where guid=(select addressguid from wn_orderhead where guidno='"+guidno+"')";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["email"].ToString();
            }
            return "";
        
        }


        ///// <summary>
        ///// 添加订单
        ///// </summary>
        ///// <param name="orderHead"></param>
        ///// <param name="listBody"></param>
        ///// <returns></returns>
        //public bool AddOrder(Orderhead orderHead, List<OrderBody> listBody)
        //{
        //    try
        //    {
        //        string strsql = "insert into dbo.wn_orderhead (userguid,guidno,wnstat,logisticscost,expressNo,expressCompanyGuid,addressguid,addtime,payTime,messageWord) values (@userguid,@guidno,@wnstat,@logisticscost,@expressNo,@expressCompanyGuid,@addressguid,@addtime,@payTime,@messageWord)";

        //        SqlParameter[] paras = new SqlParameter[] { 
        //          new SqlParameter("@userguid",SqlDbType.UniqueIdentifier),
        //          new SqlParameter("@guidno",SqlDbType.NVarChar), 
        //          new SqlParameter("@wnstat",SqlDbType.Int),     
        //          new SqlParameter("@logisticscost",SqlDbType.Decimal),
        //          new SqlParameter("@expressNo",SqlDbType.NVarChar),
        //          new SqlParameter("@expressCompanyGuid",SqlDbType.UniqueIdentifier), 
        //          new SqlParameter("@addressguid",SqlDbType.UniqueIdentifier),     
        //          new SqlParameter("@addtime",SqlDbType.DateTime), 
        //          new SqlParameter("@payTime",SqlDbType.DateTime), 
        //          new SqlParameter("@messageWord",SqlDbType.NVarChar,50), 
        //          new SqlParameter("@guid",SqlDbType.UniqueIdentifier)
        //        };
        //        paras[0].Value = orderHead.userguid;
        //        paras[1].Value = orderHead.guidno;
        //        paras[2].Value = orderHead.wnstat;
        //        paras[3].Value = orderHead.logisticscost;
        //        paras[4].Value = orderHead.expressNo;
        //        paras[5].Value = orderHead.expressCompanyGuid;
        //        paras[6].Value = orderHead.addressguid;
        //        paras[7].Value = DateTime.Now;
        //        paras[8].Value = DateTime.Now;
        //        paras[9].Value = orderHead.messageWord;
        //        paras[10].Value = orderHead.guid;
        //        Hashtable hashSql = new Hashtable();
        //        hashSql.Add(strsql, paras);
        //        foreach (OrderBody item in listBody)
        //        {

        //            string itemSql = "insert into  dbo.wn_orderBody  (guid,headGuid,prdGuid,quantity,buydanJia,idx,edtTime,logisticscost) values(@guid,@headGuid,@prdGuid,@quantity,@buydanJia,@idx,@edtTime,@logisticscost)";
        //            SqlParameter[] itemParas = new SqlParameter[] { 
        //          new SqlParameter("@guid",SqlDbType.UniqueIdentifier),
        //          new SqlParameter("@headGuid",SqlDbType.UniqueIdentifier),
        //          new SqlParameter("@prdGuid",SqlDbType.UniqueIdentifier), 
        //          new SqlParameter("@quantity",SqlDbType.Int), 
        //          new SqlParameter("@buydanJia",SqlDbType.Decimal),     
        //          new SqlParameter("@idx",SqlDbType.Int),
        //          new SqlParameter("@edtTime",SqlDbType.DateTime),
        //          new SqlParameter("@logisticscost",SqlDbType.Decimal)             
                  
        //          };
        //            paras[0].Value = item.guid;
        //            paras[1].Value = orderHead.guid;
        //            paras[2].Value = item.prdGuid;
        //            paras[3].Value = item.quantity;
        //            paras[4].Value = null;
        //            paras[5].Value = item.idx;
        //            paras[6].Value = DateTime.Now;
        //            paras[7].Value = null;

        //            hashSql.Add(itemSql, paras);
        //        }
        //        DbHelperSQL.ExecuteSqlTran(hashSql);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return false;

        //}
        #endregion

        #region 会员中心方法
        /// <summary>
        /// 查询待发货，已发货，已完成的个数，根据userid
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="ordertype">状态编号</param>
        /// <returns></returns>
        public string GetInfo(string userid, string ordertype) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(1) from wn_orderhead ");
            strSql.Append(" where userguid=@userguid and wnstat in ( ");
            strSql.Append(ordertype);
            strSql.Append(" )");
            SqlParameter[] parameters = {
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier)             };
            parameters[0].Value = Guid.Parse(userid);
            var res = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (null == res)
                return string.Empty;
            else
                return res.ToString();
        }

        /// <summary>
        /// 会员中心查询订单(根据会员id,查询所属订单号)
        /// </summary>
        /// <param name="userGuid">用户id</param>
        /// <param name="wnstat">订单状态</param>
        /// <returns></returns>
        public DataTable GetHomeOrder(Guid userGuid, string wnstat, string orderby, string strWhere, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();
            //strSql.Append(string.Format("select guid,guidno,addtime from  dbo.wn_orderhead  where userguid='{0}'", userGuid.ToString().ToUpper()));


            strSql.Append("SELECT TT.guid,TT.guidno,DATEDIFF(day,TT.addtime,getdate()) as DiffDate,TT.addtime,TT.wnstat,TT.logisticscost,e.expressprice FROM ( ");
           // strSql.Append("SELECT TT.guid,TT.guidno,DATEDIFF(day,TT.addtime,getdate()) as DiffDate,TT.addtime,TT.wnstat,TT.logisticscost,body.buydanJia as expressprice FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.addtime desc");
            }
            strSql.Append(")AS Row, T.*  from dbo.wn_orderhead  T  where 1=1");   
            
            // do not include unpaid orders
            strSql.Append(" and wnstat <> 0");
             
            if (!string.IsNullOrEmpty(wnstat))
            {
                //strSql.Append(" and wnstat=" + wnstat);
                strSql.Append(" and wnstat in(" + wnstat + ")");
            }
            if (!string.IsNullOrEmpty(userGuid.ToString()))
            {
                strSql.Append(" and userguid='" + userGuid .ToString()+ "'");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  dbo.wn_expresscompany e on TT.expressCompanyGuid=e.guid");    
            //strSql.Append(" left join wn_orderBody body on TT.guid=body.headGuid");
            strSql.AppendFormat("  WHERE TT.Row between {0} and {1};", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
              
                return ds.Tables[0];
            }         
            return null;            
           
        }
        /// <summary>
        /// 会员中心查询订单,记录数(根据会员id,查询所属订单号)
        /// </summary>
        /// <param name="userGuid">用户id</param>
        /// <param name="wnstat">订单状态</param>
        /// <returns></returns>
        public int GetHomeOrderRecordCount(Guid userGuid, string wnstat, string orderby, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();    
            strSql.Append("SELECT guid,guidno,addtime FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.addtime desc");
            }
            strSql.Append(")AS Row, T.*  from dbo.wn_orderhead  T where 1=1");

            // do not incude unpaid order
            strSql.Append(" and wnstat <> 0");

            if (!string.IsNullOrEmpty(wnstat))
            {
                //strSql.Append(" and wnstat=" + wnstat);
                strSql.Append(" and wnstat in(" + wnstat + ")");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.userguid='{0}'", userGuid.ToString().ToUpper());
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count;
            }
            return 0;

        }

        /// <summary>
        /// 会员中心查询订单(根据订单主表headguid，查询订单明细)
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public DataTable GetHomeOrderDetial(Guid headGuid)
        {
            StringBuilder strSql = new StringBuilder();
            //Modify by Long 2015/11/30 应该从orderbody里取价格，而不是从产品表里取，因为价格会随时变动的
            //Modify by Jack Cao 2015/12/02 add shipment detail ID and return info ID
            //strSql.Append("select b.guid, headGuid,h.wnstat orderStat,h.guidno,h.logisticscost,b.prdGuid,quantity,p.name,p.estimateprice,p.saleprice,p.wnstat prdStat,f.fileurl,quantity*p.saleprice money,quantity*p.estimateprice money2,r.color,r.probulk prosize, s.prodetailtype as spectype, r.prorule as specname  from dbo.wn_orderBody b ");
            strSql.Append("select b.guid, headGuid,h.wnstat orderStat,h.guidno,h.logisticscost,quantity*b.buydanJia as bodymoney,b.prdGuid,quantity,p.name,p.estimateprice,p.saleprice,p.wnstat prdStat,f.fileurl,quantity*p.saleprice money,quantity*p.estimateprice money2,r.color,r.probulk prosize, s.prodetailtype as spectype, r.prorule as specname ");
            strSql.Append(" ,b.ShipmentDetail_ID, b.ReturnInfo_ID ");
            strSql.Append(" from dbo.wn_orderBody b ");
            strSql.Append(" left join dbo.wn_orderhead h on b.headGuid=h.guid");
            strSql.Append(" left join dbo.wn_prd p on b.prdGuid=p.prdGuid ");
            strSql.Append(" left join dbo.wn_file f on f.prdguid=p.prdGuid ");
            strSql.Append(" left join dbo.wn_proRules r on b.ruleid=r.id");
            strSql.Append(" left join dbo.wn_proDetailSupplyType s on s.id= r.proruletitle");
            strSql.Append(string.Format(" where b.headGuid='{0}' and f.idx=0", headGuid));
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// member center query order sipment details
        /// </summary>
        /// <param name="order no"></param>
        /// <returns></returns>
        public DataTable GetHomeOrderShipmentDetail(string sOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ShipOrder_ID as ShipOrderID, ProductName, buydanjia as UnitPrice, Shipmentdetail_ShippedDate as ShippedDate, ShipmentDetail_Quantity as ShippedQuantity, ShipmentDetailTracking_No as TrackingNo, ShipmentDetailTracking_CarrierName as CarrierName");
            strSql.Append(" from dbo.vw_OrderShipmentDetail ");
            strSql.Append(" where guidno='" +  sOrderNo + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        /// <summary>
        /// member center query order return details
        /// </summary>
        /// <param name="order no"></param>
        /// <returns></returns>
        public DataTable GetHomeOrderReturnDetail(string sOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ShipOrder_ID as ShipOrderID, ProductName, buydanjia as UnitPrice, ReturnInfo_ReturnDate as ReturnDate, ReturnInfo_ReturnQuantity as ReturnQuantity, ReturnInfo_Quality as ReturnQuality, ReturnInfo_ReasonCode as ReturnReasonCode, ReturnInfo_ReasonDesc as ReturnReasonDesc, ReturnInfo_ActionRequested as ReturnAction");
            strSql.Append(" from dbo.vw_OrderReturnDetail ");
            strSql.Append(" where guidno='" + sOrderNo + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }



        /// <summary>
        /// 查询订单信息（包括:订单时间、订单号、收货人电话、收货人姓名、物流公司、物流费；订单id和订单号输入其中一个即可）
        /// </summary>
        /// <param name="headGuid"></param>
        /// <returns></returns>
        public DataTable GetOrderHead(Guid headGuid,string orderNum)
        { 
            StringBuilder sbSql=new StringBuilder();
            sbSql.Append("select h.*,a.phone,a.tel,a.username ,e.companyname,e.expressprice from  dbo.wn_orderhead h ");
            sbSql.Append(" left join  dbo.wn_useraddress a on h.addressguid=a.guid");
            sbSql.Append(" left join  dbo.wn_user u on a.userguid=u.guid");
            sbSql.Append(" left join  dbo.wn_expresscompany e on h.expressCompanyGuid=e.guid");
            if (headGuid != null && headGuid.ToString() != "" && headGuid != Guid.Empty)
            {
                sbSql.Append(" where h.guid='" + headGuid.ToString().ToUpper() + "'");
            }
            else if (!string.IsNullOrEmpty(orderNum))
            {
                 sbSql.Append(" where h.guidno='" + orderNum + "'");
            }
            DataSet ds = DbHelperSQL.Query(sbSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        
        }


        /// <summary>
        /// 查询订单明细(用于收益计算：根据订单号OrderNo，查询订单明细)
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public DataTable GetOrderDetial(string orderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.guid,b.prdGuid, h.guid,h.wnstat orderStat,h.guidno,quantity,p.name,p.saleprice,p.wnstat prdStat,quantity*p.saleprice money,p.userGuid from  dbo.wn_orderhead h");
            strSql.Append(" left join dbo.wn_orderBody b on b.headGuid=h.guid");
            strSql.Append(" left join dbo.wn_prd p on b.prdGuid=p.prdGuid ");
            strSql.Append(string.Format(" where h.guidno='{0}'", orderNo));
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 查询会员所有消费总额
        /// </summary>
        /// <param name="userGuid">会员id</param>
        /// <param name="orderState">订单状态</param>
        /// <returns></returns>
        public decimal GetSumShopMoney(string userGuid, Twee.Comm.ConfigParamter.OrderStatus orderState)
        {
            string strSql = "select SUM(b.buydanJia*b.quantity) from wn_orderhead h left join wn_orderBody b on h.guid=b.headGuid where  h.userguid=@userguid and h.wnstat=@orderState";
            SqlParameter[] parameters = {
					new SqlParameter("@userguid", userGuid),
                    new SqlParameter("@orderState", orderState)
             };
           DataSet ds = DbHelperSQL.Query(strSql,parameters);
           if (ds!=null && ds.Tables.Count>0)
           {
               return ds.Tables[0].Rows[0][0].ToString().ToDecimal();
           }
           return 0;
        
        }
        public decimal GetBonusShoppingPoint(string userGuid, Twee.Comm.ConfigParamter.OrderStatus orderState)
        {

            string strSql = "select SUM(point) as BonusPoints from wn_orderhead h left join wn_point b on h.guidno=b.orderNo where  h.userguid=@userguid and h.wnstat=@orderState and remark='Bonus Shopping Reward Points'";
            SqlParameter[] parameters = {
					new SqlParameter("@userguid", userGuid),
                    new SqlParameter("@orderState", orderState)
             };
            DataSet ds = DbHelperSQL.Query(strSql, parameters);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().ToDecimal();
            }
            return 0;
        }
        /// <summary>
        /// 查询用户用掉的消费积分
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>

        public decimal GetSumUsedShoppingPointsMoney(string userGuid)
        {
            string strSql = "select SUM(userShopingAmount) from wn_orderhead  where  userguid=@userguid";// and h.wnstat=@orderState";
            SqlParameter[] parameters = {
					new SqlParameter("@userguid", userGuid)
             };
            DataSet ds = DbHelperSQL.Query(strSql, parameters);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().ToDecimal();
            }
            return 0;

        }
        /// <summary>
        /// 查询插入购物积分所需的字段信息
        /// </summary>
        /// <param name="headGuid"></param>
        /// <returns></returns>
        public DataTable GetPointInfoByHeadGuid(string headGuid)
        {
            string strSql = " select h.guidno,h.userguid, b.buydanJia*b.quantity money,h.addtime from wn_orderhead h left join wn_orderBody b on h.guid=b.headGuid  where  h.guid='"+headGuid+"'";
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;        
        }

        public string GetGuestCheckoutUsernameByOrderno(string strOrderno)
        {
            string strSql = "select ua.username+' '+ ua.lastName as Username from wn_useraddress ua left join wn_orderhead h on h.addressguid=ua.guid where h.guidno='"+strOrderno+"'";
            Object obj = DbHelperSQL.GetSingle(strSql);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }

        }
        #endregion
    }
}
