using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Manage.Article
{
    public partial class admArticleEdt : System.Web.UI.Page
    {
        Twee.Mgr.ArticleMgr mgr = new Twee.Mgr.ArticleMgr();
        Twee.Mgr.ArticleTypeMgr typeMgr = new Twee.Mgr.ArticleTypeMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["op"]) && string.IsNullOrEmpty(Request.QueryString["id"]))
                    return;

                typeBind();

                if (Request.QueryString["op"].Trim() == "edit")
                {
                    edit();
                }
                if (Request.QueryString["op"].Trim() == "add")
                {
                    add();
                }
                if (Request.QueryString["op"].Trim() == "view")
                {
                    view();
                }

            }
        }

        private void view() {
            int id = Convert.ToInt32(Request.QueryString["id"].Trim());
            var model = mgr.GetModel(id);
            ddlType.SelectedValue = model.typeid.ToString();
            ddlState.SelectedValue = model.state.ToString();
            txtTitle.Text = model.title;
            txtReadCount.Text = model.readcount.ToString();
            txtcontent.Value = model.content;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            ddlType.Enabled = false;
            ddlState.Enabled = false;
            txtTitle.Enabled = false;
            txtReadCount.Enabled = false;
            txtcontent.Disabled = true;
            
        }

        private void edit()
        {
            btnAdd.Visible = false;
            labTitle.Text = "内容修改";
            int id = Convert.ToInt32(Request.QueryString["id"].Trim());
            Twee.Model.Article model = mgr.GetModel(id);
            if (null == model)
                return;
            ddlType.SelectedValue = model.typeid.ToString();
            ddlState.SelectedValue = model.state.ToString();
            txtcontent.Value = model.content;
            txtTitle.Text = model.title;
            txtReadCount.Text = model.readcount.ToString();
            labid.Text = id.ToString();
        }

        private void typeBind() {
            var table=typeMgr.GetList("state=1").Tables[0];
            ddlType.DataValueField = "id";
            ddlType.DataTextField = "typename";
            ddlType.DataSource = table;
            ddlType.DataBind();
            
        }

        private void add()
        {
            btnEdit.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Twee.Model.Article model = new Twee.Model.Article();
            model.typeid =Convert.ToInt32( ddlType.SelectedItem.Value);
            model.state = Convert.ToInt32(ddlState.SelectedItem.Value);
            model.title = txtTitle.Text.Trim();
            model.readcount =Convert.ToInt32( txtReadCount.Text.Trim());
            model.content = txtcontent.Value;
            model.creator = new Guid(); //这里要问一下东飞
            model.createtime = DateTime.Now;
            if (mgr.Add(model) > 0)
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>alert('添加成功');</script>");
            else
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>alert('添加失败');</script>");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Twee.Model.Article model = new Twee.Model.Article();
            model.id = Convert.ToInt32(Request.QueryString["id"].Trim());
            model.typeid =Convert.ToInt32(ddlType.SelectedItem.Value);
            model.state = Convert.ToInt32(ddlState.SelectedItem.Value);
            model.readcount = Convert.ToInt32(txtReadCount.Text.Trim());
            model.content = txtcontent.Value;
            model.title = txtTitle.Text;
            model.creator = new Guid(); //这里要问一下东飞
            model.createtime = DateTime.Now;
            if (mgr.Update(model))
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>alert('修改成功');</script>");
            else
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>alert('修改失败');</script>");

        }



    }
}