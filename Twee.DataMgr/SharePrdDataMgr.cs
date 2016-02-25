using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Comm;
using System.Data.SqlClient;
using System.Data;

namespace Twee.DataMgr
{
    public class SharePrdDataMgr
    {
        public SharePrdDataMgr()
		{}
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.SharePrd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_shareprd(");
            strSql.Append("thing_id,imgurl,img_mask,img_opaque,url,object_class,ow,w,h,oh,displayurl,seo_title,display_price,masking_policy,edtTime,addtime)");
            strSql.Append(" values (");
            strSql.Append("@thing_id,@imgurl,@img_mask,@img_opaque,@url,@object_class,@ow,@w,@h,@oh,@displayurl,@seo_title,@display_price,@masking_policy,@edtTime,@addtime)");
            SqlParameter[] parameters = {
					new SqlParameter("@thing_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,50),
					new SqlParameter("@img_mask", SqlDbType.NVarChar,50),
					new SqlParameter("@img_opaque", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,50),
					new SqlParameter("@object_class", SqlDbType.NVarChar,50),
					new SqlParameter("@ow", SqlDbType.NVarChar,50),
					new SqlParameter("@w", SqlDbType.NVarChar,50),
					new SqlParameter("@h", SqlDbType.NVarChar,50),
					new SqlParameter("@oh", SqlDbType.NVarChar,50),
					new SqlParameter("@displayurl", SqlDbType.NVarChar,50),
					new SqlParameter("@seo_title", SqlDbType.NVarChar,50),
					new SqlParameter("@display_price", SqlDbType.Decimal,5),
					new SqlParameter("@masking_policy", SqlDbType.NVarChar,50),
					new SqlParameter("@edtTime", SqlDbType.DateTime),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.imgurl;
            parameters[2].Value = model.img_mask;
            parameters[3].Value = model.img_opaque;
            parameters[4].Value = model.url;
            parameters[5].Value = model.object_class;
            parameters[6].Value = model.ow;
            parameters[7].Value = model.w;
            parameters[8].Value = model.h;
            parameters[9].Value = model.oh;
            parameters[10].Value = model.displayurl;
            parameters[11].Value = model.seo_title;
            parameters[12].Value = model.display_price;
            parameters[13].Value = model.masking_policy;
            parameters[14].Value = model.edtTime;
            parameters[15].Value = model.addtime;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.SharePrd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_shareprd set ");
            strSql.Append("thing_id=@thing_id,");
            strSql.Append("imgurl=@imgurl,");
            strSql.Append("img_mask=@img_mask,");
            strSql.Append("img_opaque=@img_opaque,");
            strSql.Append("url=@url,");
            strSql.Append("object_class=@object_class,");
            strSql.Append("ow=@ow,");
            strSql.Append("w=@w,");
            strSql.Append("h=@h,");
            strSql.Append("oh=@oh,");
            strSql.Append("displayurl=@displayurl,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("display_price=@display_price,");
            strSql.Append("masking_policy=@masking_policy,");
            strSql.Append("edtTime=@edtTime,");
            strSql.Append("addtime=@addtime");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@thing_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@imgurl", SqlDbType.NVarChar,50),
					new SqlParameter("@img_mask", SqlDbType.NVarChar,50),
					new SqlParameter("@img_opaque", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,50),
					new SqlParameter("@object_class", SqlDbType.NVarChar,50),
					new SqlParameter("@ow", SqlDbType.NVarChar,50),
					new SqlParameter("@w", SqlDbType.NVarChar,50),
					new SqlParameter("@h", SqlDbType.NVarChar,50),
					new SqlParameter("@oh", SqlDbType.NVarChar,50),
					new SqlParameter("@displayurl", SqlDbType.NVarChar,50),
					new SqlParameter("@seo_title", SqlDbType.NVarChar,50),
					new SqlParameter("@display_price", SqlDbType.Decimal,5),
					new SqlParameter("@masking_policy", SqlDbType.NVarChar,50),
					new SqlParameter("@edtTime", SqlDbType.DateTime),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
            parameters[0].Value = model.thing_id;
            parameters[1].Value = model.imgurl;
            parameters[2].Value = model.img_mask;
            parameters[3].Value = model.img_opaque;
            parameters[4].Value = model.url;
            parameters[5].Value = model.object_class;
            parameters[6].Value = model.ow;
            parameters[7].Value = model.w;
            parameters[8].Value = model.h;
            parameters[9].Value = model.oh;
            parameters[10].Value = model.displayurl;
            parameters[11].Value = model.seo_title;
            parameters[12].Value = model.display_price;
            parameters[13].Value = model.masking_policy;
            parameters[14].Value = model.edtTime;
            parameters[15].Value = model.addtime;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_shareprd ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.SharePrd GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 thing_id,imgurl,img_mask,img_opaque,url,object_class,ow,w,h,oh,displayurl,seo_title,display_price,masking_policy,edtTime,addtime from wn_shareprd ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            Twee.Model.SharePrd model = new Twee.Model.SharePrd();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.SharePrd DataRowToModel(DataRow row)
        {
            Twee.Model.SharePrd model = new Twee.Model.SharePrd();
            if (row != null)
            {
                if (row["thing_id"] != null && row["thing_id"].ToString() != "")
                {
                    model.thing_id = new Guid(row["thing_id"].ToString());
                }
                if (row["imgurl"] != null)
                {
                    model.imgurl = row["imgurl"].ToString();
                }
                if (row["img_mask"] != null)
                {
                    model.img_mask = row["img_mask"].ToString();
                }
                if (row["img_opaque"] != null)
                {
                    model.img_opaque = row["img_opaque"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["object_class"] != null)
                {
                    model.object_class = row["object_class"].ToString();
                }
                if (row["ow"] != null)
                {
                    model.ow = row["ow"].ToString();
                }
                if (row["w"] != null)
                {
                    model.w = row["w"].ToString();
                }
                if (row["h"] != null)
                {
                    model.h = row["h"].ToString();
                }
                if (row["oh"] != null)
                {
                    model.oh = row["oh"].ToString();
                }
                if (row["displayurl"] != null)
                {
                    model.displayurl = row["displayurl"].ToString();
                }
                if (row["seo_title"] != null)
                {
                    model.seo_title = row["seo_title"].ToString();
                }
                if (row["display_price"] != null && row["display_price"].ToString() != "")
                {
                    model.display_price = decimal.Parse(row["display_price"].ToString());
                }
                if (row["masking_policy"] != null)
                {
                    model.masking_policy = row["masking_policy"].ToString();
                }
                if (row["edtTime"] != null && row["edtTime"].ToString() != "")
                {
                    model.edtTime = DateTime.Parse(row["edtTime"].ToString());
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select thing_id,imgurl,img_mask,img_opaque,url,object_class,ow,w,h,oh,displayurl,seo_title,display_price,masking_policy,edtTime,addtime ");
            strSql.Append(" FROM wn_shareprd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" thing_id,imgurl,img_mask,img_opaque,url,object_class,ow,w,h,oh,displayurl,seo_title,display_price,masking_policy,edtTime,addtime ");
            strSql.Append(" FROM wn_shareprd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wn_shareprd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT thing_id,imgurl,img_mask,img_opaque,url,object_class,ow,w,h,oh,brand_id,displayurl,seo_title,display_price=saleprice,masking_policy,edtTime,addtime,saleprice price,name title FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.* ,p.saleprice,p.name from wn_shareprd T ");
            strSql.Append("left join wn_prd p on T.thing_id=p.prdGuid ");   
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
           
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SharePrd";
            parameters[1].Value = "prdGuid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

		#region  ExtensionMethod  叠图分享


        /// <summary>
        /// 分页获取叠图产品区数据列表
        /// </summary>
        public DataSet GetSharePrdByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.prdGuid thing_id,T.smallImg imgurl,T.maskImg img_mask,T.opaqueImg img_opaque,T.edtTime,T.addtime,p.name title,p.saleprice price,p.cateGuid FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_shareprd T ");
            strSql.Append("left join wn_prd p on T.prdGuid=p.prdGuid ");   
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        //public Twee.Model.SharePrd DataRowToModel2(DataRow row)
        //{
        //    Twee.Model.SharePrd model = new Twee.Model.SharePrd();
        //    if (row != null)
        //    {
        //        if (row["prdGuid"] != null && row["prdGuid"].ToString() != "")
        //        {
        //            model.prdGuid = new Guid(row["prdGuid"].ToString());
        //        }
        //        if (row["smallImg"] != null)
        //        {
        //            model.smallImg = row["smallImg"].ToString();
        //        }
        //        if (row["maskImg"] != null)
        //        {
        //            model.maskImg = row["maskImg"].ToString();
        //        }
        //        if (row["opaqueImg"] != null)
        //        {
        //            model.opaqueImg = row["opaqueImg"].ToString();
        //        }
        //        if (row["edtTime"] != null && row["edtTime"].ToString() != "")
        //        {
        //            model.edtTime = DateTime.Parse(row["edtTime"].ToString());
        //        }
        //        if (row["addtime"] != null && row["addtime"].ToString() != "")
        //        {
        //            model.addtime = DateTime.Parse(row["addtime"].ToString());
        //        }

        //        //#region 扩展字段
        //        //private string prdUrl;//产品url地址
        //        //private string object_class;
        //        //private string title;//标题
        //        //private string ow;//原始图片宽高
        //        //private string w;//缩略图宽高
        //        //private string brand_id;//品牌ID
        //        //private string h;//缩略图宽高
        //        //private string oh;//原始图片宽高
        //        //private string displayurl;
        //        //private string seotitle;//SEO标题用于TITLE等
        //        //private string display_price;//显示价格
        //        //private string maskingpolicy;//"default_yes"
        //        //#endregion 

        //        if (row["prdUrl"] != null && row["prdUrl"].ToString() != "")
        //        {
        //            model.prdUrl = row["prdUrl"].ToString();
        //        }
        //        if (row["object_class"] != null && row["object_class"].ToString() != "")
        //        {
        //            model.object_class = row["object_class"].ToString();
        //        }
        //        if (row["title"] != null && row["title"].ToString() != "")
        //        {
        //            model.title = row["title"].ToString();
        //        }
        //        if (row["ow"] != null && row["ow"].ToString() != "")
        //        {
        //            model.ow = row["ow"].ToString();
        //        }
        //        if (row["w"] != null && row["w"].ToString() != "")
        //        {
        //            model.w = row["w"].ToString();
        //        }
        //        if (row["brand_id"] != null && row["brand_id"].ToString() != "")
        //        {
        //            model.ow = row["ow"].ToString();
        //        }
        //        if (row["h"] != null && row["h"].ToString() != "")
        //        {
        //            model.h = row["h"].ToString();
        //        }
        //        if (row["oh"] != null && row["oh"].ToString() != "")
        //        {
        //            model.oh = row["oh"].ToString();
        //        }
        //        if (row["displayurl"] != null && row["displayurl"].ToString() != "")
        //        {
        //            model.displayurl = row["displayurl"].ToString();
        //        }
        //        if (row["seotitle"] != null && row["seotitle"].ToString() != "")
        //        {
        //            model.seotitle = row["seotitle"].ToString();
        //        }
        //        if (row["display_price"] != null && row["display_price"].ToString() != "")
        //        {
        //            model.seotitle = row["seotitle"].ToString();
        //        }
        //        if (row["maskingpolicy"] != null && row["maskingpolicy"].ToString() != "")
        //        {
        //            model.seotitle = row["maskingpolicy"].ToString();
        //        }
        //    }
        //    return model;
        //}

		#endregion  ExtensionMethod
    }
}

