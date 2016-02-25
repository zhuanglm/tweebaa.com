using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using AjaxPro;
using Twee.Comm;
using TweebaaWebApp2.Method;

namespace TweebaaWebApp2.Mgr.proManager
{
    public partial class proAssignSkuImage : System.Web.UI.Page
    {
        string _sPrdGuid = string.Empty;
        DataTable _dtSKUList;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proAssignSkuImage));

            if (string.IsNullOrEmpty(Request["id"]))
                return;
            else
                _sPrdGuid = Request["id"].Trim();

            if (!IsPostBack)
            {
                _dtSKUList = GetProductSKUList();
                ShowImageList();
            }
        }

        private DataTable GetProductSKUList()
        {
            Twee.Mgr.PrdMgr prdMgr = new Twee.Mgr.PrdMgr();
            DataTable dt = prdMgr.MgeGetProductSKUList(_sPrdGuid);
            return dt;
        }

        private bool ShowImageList()
        {
            Twee.Mgr.PrdMgr prdMgr = new Twee.Mgr.PrdMgr();
            DataTable dt = prdMgr.MgeGetProductImageList(_sPrdGuid);
            if (dt == null) return false;
            if (dt.Rows.Count == 0) return false;
            DataRow dr = dt.Rows[0];

            lblProductGuid.Text = _sPrdGuid;

            Twee.Model.Prd prdModel = prdMgr.GetModel((Guid)_sPrdGuid.ToGuid());
            lblProductName.Text = prdModel.name;

            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add(new DataColumn("FileGuid", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ProductImage", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ImageURL", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ImageIdx", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ImageRuleID", typeof(string)));
            foreach (DataRow drItem in dt.Rows)
            {
                DataRow drGrid = dtGrid.NewRow();
                drGrid["ProductImage"] = ResolveUrl("http://tweebaa.com/" + drItem["ImageURL"]._ObjToString().Replace("/big/", "/small/"));
                drGrid["FileGuid"] = drItem["fileguid"]._ObjToString();
                drGrid["ImageURL"] = drItem["ImageURL"]._ObjToString();
                drGrid["ImageIdx"] = drItem["ImageIdx"]._ObjToString();
                if (drItem["ruleid"] == DBNull.Value)
                {
                    drGrid["ImageRuleID"] = "-1";
                }
                else
                {
                    drGrid["ImageRuleID"] = drItem["ruleid"]._ObjToString();
                }
                    //drGrid["TrackingNo"] = "<a target=\"_blank\" href=\"" + CommUtil.GetTrackingLink(sCarrierName, sTrackingNo) + "\">" + sTrackingNo + "</a>";

                dtGrid.Rows.Add(drGrid);
                //dtGrid.Rows.Add("aaa", "bbb");
            }

            gdvImage.Visible = true;
            gdvImage.AutoGenerateColumns = false;
            gdvImage.DataSource = dtGrid;
            gdvImage.DataBind();

            return true;
        }

        protected void gdvImage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sItemName = string.Empty;
            string sRuleID = string.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlSKU = (e.Row.FindControl("ddlSKU") as DropDownList);
                if (_dtSKUList != null)
                {
                    foreach (DataRow dr in _dtSKUList.Rows)
                    {
                        sItemName = dr["prosku"].ToNullString() + " " + dr["SpecType"].ToNullString() + " " + dr["SpecName"].ToNullString() + " " + dr["color"].ToNullString();
                        sRuleID = dr["id"].ToNullString();
                        ddlSKU.Items.Add(new ListItem(sItemName, sRuleID));
                    }
                }
                ddlSKU.Items.Insert(0, new ListItem("Please select", "-1"));

                //Select the Country of Customer in DropDownList
                string sImageRuleID = "-1";
                int iColIdxImageRuleID = GetColumnIndexByName(gdvImage, "ImageRuleID"); ;
                if (iColIdxImageRuleID != -1) sImageRuleID = e.Row.Cells[iColIdxImageRuleID].Text.Trim();
                if (sImageRuleID == string.Empty) sImageRuleID = "-1";
                ddlSKU.Items.FindByValue(sImageRuleID).Selected = true;
            }
            e.Row.Cells[3].Visible = false;  // file guid column
            e.Row.Cells[4].Visible = false;  // image rule id column
        }

        private int GetColumnIndexByName(GridView grid, string name)
        {
            foreach (DataControlField col in grid.Columns)
            {
                if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
                {
                    return grid.Columns.IndexOf(col);
                }
            }

            return -1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.DBConnectBeginTrans();
            foreach (GridViewRow gr in gdvImage.Rows)
            {
                /* 
                <asp:ImageField DataImageUrlField="ProductImage"></asp:ImageField>
                <asp:BoundField DataField="ImageURL" HeaderText="Image URL" ItemStyle-Width="150" />
                <asp:BoundField DataField="ImageIdx" HeaderText="Image Index" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FileGuid" HeaderText="FileGuid" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center" Visible="true" />
                <asp:BoundField DataField="ImageRuleID" HeaderText="ImageRuleID" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center" Visible="true" />
                <asp:TemplateField HeaderText="Please Select SKU" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlSKU" runat="server" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                */

                string sFileGuid = gdvImage.Rows[gr.RowIndex].Cells[3].Text;   // file guid column
                string sOldRuleID = gdvImage.Rows[gr.RowIndex].Cells[4].Text;  // image rule id column
                DropDownList ddlSKU = gr.FindControl("ddlSKU") as DropDownList;
                string sNewRuleID = ddlSKU.SelectedValue.Trim();
                if (sNewRuleID == "-1" || sNewRuleID == string.Empty) sNewRuleID = "null";
                
                string sSql = "update wn_file set ruleid = " + sNewRuleID + " where fileguid='" + sFileGuid + "'";
                int iCnt = db.DBExecute(sSql);
            }
            db.DBDisconnectCommitTrans();
            Response.Write("<script>alert('Images have been assigned successfully!');</script>");
            Response.Flush();
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            string sImageFileName = fupUploadImage.FileName;
            if (sImageFileName == string.Empty)
            {
                Response.Write("<script>alert('Please select the image file you want to upload!'); </script>");
                return;
            }

            // check file type
            String sImageFileExt = Path.GetExtension(sImageFileName).ToLower();
            if (System.Configuration.ConfigurationManager.AppSettings["UploadExtension"].ToString().IndexOf(sImageFileExt) == -1)
            {
                Response.Write("<script>alert('This type of image is not supported!');</script>");
                return;
            }

            // get imag upload root path
            String sImageUploadRoot = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
            
       
            // set upload image folder of big/small/mid/mid2
            string sDate = DateTime.Now.ToString("yyyyMMdd");
            String sPathRoot  = Server.MapPath("~" + "/" + sImageUploadRoot);
            string sPathBig = Server.MapPath("~" + "/" + sImageUploadRoot + "big/" + sDate + "/");
            string sPathSmall = Server.MapPath("~" + "/" + sImageUploadRoot + "small/" + sDate + "/");
            string sPathMid = Server.MapPath("~" + "/" + sImageUploadRoot + "mid/" + sDate + "/");
            string sPathMid2 = Server.MapPath("~" + "/" + sImageUploadRoot + "mid2/" + sDate + "/");

            // create image folder if it does not exist
            if (!Directory.Exists(sPathBig))
                Directory.CreateDirectory(sPathBig);
            if (!Directory.Exists(sPathSmall))
                Directory.CreateDirectory(sPathSmall);
            if (!Directory.Exists(sPathMid))
                Directory.CreateDirectory(sPathMid);
            if (!Directory.Exists(sPathMid2))
                Directory.CreateDirectory(sPathMid2);

            // create a new Guid for the file name
            Guid guidImageFile = Guid.NewGuid();
            string sNewFileName = guidImageFile.ToString() + sImageFileExt;

            // set image file names
            string sFileNamePathBig   = sPathBig   + sNewFileName;
            string sFileNamePathSmall = sPathSmall + sNewFileName;
            string sFileNamePathMid   = sPathMid   + sNewFileName;
            string sFileNamePathMid2  = sPathMid2  + sNewFileName;
            
            // upload the image to the big image folder
            string sUploadImageFile = Server.MapPath("~" + "/" + sImageUploadRoot + "big/" + sDate + "/" + sNewFileName);
            fupUploadImage.SaveAs(sUploadImageFile);
            
            FileInfo fiUploadImage = new FileInfo(sUploadImageFile);

            // create small/mid/mid2 images
            string[] whs = System.Configuration.ConfigurationManager.AppSettings["UploadWH"].ToString().Split(',');

            for (int i = 0; i < whs.Length; i++)
            {
                int w = int.Parse(whs[i].Split('_')[0]);
                int h = int.Parse(whs[i].Split('_')[1]);
                //string filePathMack = dirPath + wh + newFileName;
                string sCreatFilePath = "";
                if (i == 0)
                {
                    // small
                    sCreatFilePath =  sFileNamePathSmall;
                }
                else if (i == 1)
                {
                    //224_224_W mid2
                    sCreatFilePath = sFileNamePathMid2;
                }
                else if (i == 2)
                {
                    //400_400_M mid
                    sCreatFilePath = sFileNamePathMid;
                }

                ImgThumbnail iz = new ImgThumbnail();
                iz.Thumbnail(sUploadImageFile, sCreatFilePath, w, h, whs[i].Split('_')[2]);
            }

            Twee.Model.File model = new Twee.Model.File();
            model.fileguid = guidImageFile;
            model.prdguid = (Guid)_sPrdGuid.ToGuid();
            model.prtguid = (Guid)_sPrdGuid.ToGuid();
            model.idx = txtImageIdx.Text.ToInt();
            model.fileurl = "/" + sImageUploadRoot + "big/" + sDate + "/" + sNewFileName;

            Twee.Mgr.FileMgr fileMgr = new Twee.Mgr.FileMgr();
            string sErrMsg = string.Empty;
            bool bOK = fileMgr.MgeAdd(model, out sErrMsg);
            if (bOK)
            {
                Response.Write("<script>alert('Image has been uploaded successfully!');</script>");
                _dtSKUList = GetProductSKUList();
                ShowImageList();
            }
            else
            {
                Response.Write("<script>alert('Failed to upload the image!" +  sErrMsg + "');</script>");
            }
            Response.Flush();

        }

        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            Button btnDelete = sender as Button;
            int rowIndex = Convert.ToInt32(btnDelete.Attributes["RowIndex"]);
            GridViewRow row = gdvImage.Rows[rowIndex];

            string sFileGuid = row.Cells[3].Text;
            int iImageIdx = int.Parse(row.Cells[2].Text);
            if (iImageIdx == 0)
            {
                Response.Write("<script>alert('You cannot delete the primary image!');</script>");
                return;
            }
            Twee.Mgr.FileMgr fileMgr = new Twee.Mgr.FileMgr();
            bool bOK = fileMgr.DeleteByFileGuid((Guid)sFileGuid.ToGuid());
            if (bOK)
            {
                _dtSKUList = GetProductSKUList();
                ShowImageList();
                Response.Write("<script>alert('Image has been deleted successfully!');</script>");
                return;
            }
            else
            {
                Response.Write("<script>alert('Failed to delete the image!');</script>");
                return;
            }


        }
        protected void gdvImage_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
     }
}