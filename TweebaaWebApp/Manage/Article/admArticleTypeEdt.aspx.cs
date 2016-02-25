using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Manage.Article
{
    public partial class adminArticleTypeEdt : System.Web.UI.Page
    {
        Twee.Mgr.ArticleTypeMgr mgr = new Twee.Mgr.ArticleTypeMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["op"]) && string.IsNullOrEmpty(Request.QueryString["id"]))
                    return;

                if (Request.QueryString["op"].Trim() == "edit")
                {
                    edit();
                }
                if (Request.QueryString["op"].Trim() == "add")
                {
                    add();
                }

            }
        }

        private void edit()
        {
            btnAdd.Visible = false;
            int id = Convert.ToInt32(Request.QueryString["id"].Trim());
            Twee.Model.ArticleType model = mgr.GetModel(id);
            if (null == model)
                return;
            txtTypeName.Text = model.typename;
            ddlState.SelectedValue = model.state.ToString();
            labId.Text = id.ToString();
        }

        private void add()
        {
            btnSave.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Twee.Model.ArticleType model = new Twee.Model.ArticleType();
            model.id = Convert.ToInt32(Request.QueryString["id"].Trim());
            model.typename = txtTypeName.Text.Trim();
            model.state = Convert.ToInt32(ddlState.SelectedItem.Value);
            model.creator = new Guid(); //这里要问一下东飞
            model.createtime = DateTime.Now;
            if (mgr.Update(model))
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>parent.search();</script>");
            else
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>alert('修改失败');</script>");

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Twee.Model.ArticleType model = new Twee.Model.ArticleType();
            model.typename = txtTypeName.Text.Trim();
            model.state = Convert.ToInt32(ddlState.SelectedItem.Value);
            model.creator = new Guid(); //这里要问一下东飞
            model.createtime = DateTime.Now;
            if (mgr.Add(model) > 0)
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>parent.search();</script>");
            else
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type='text/javascript'>alert('添加失败');</script>");
        }
    }
}