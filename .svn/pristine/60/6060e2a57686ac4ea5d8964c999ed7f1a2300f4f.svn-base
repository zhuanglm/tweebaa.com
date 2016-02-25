using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class admPatent : System.Web.UI.Page
    {
        const int pageSize = 10;//页大小
        int pagesCount, recordsCount;//总页数、总条数
        int currentPage, pages, jumpPage;//当前页、信息总页数、跳转页码
        const string COUNT_SQL = "select count(*)  from p_user";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAll();
                // recordsCount = 70;/默认信息总数

                pagesCount = recordsCount / pageSize + OverPage();//默认的页总数
                ViewState["pagesCount"] = recordsCount / pageSize - ModPage();//保存末页索引，比页总数小1
                ViewState["PageIndex"] = 0;//保存页面初始索引从0开始
                ViewState["JumpPages"] = pagesCount;
                //保存页总数，跳页时判断用户输入数是否超出页码范围
                //显示lbPageCount、lbRecordCount的状态
                lbPageCount.Text = pagesCount.ToString();
                lbRecordCount.Text = recordsCount.ToString();
                //判断跳页文本框失效
                if (recordsCount <= 10)
                {
                    GotoPage.Enabled = false;
                }
                GridViewDataBind("default");//调用数据绑定函数TDataBind()进行数据绑定运算

            }
        }

        private void GetAll()
        {
            PatentMgr patent = new PatentMgr();
            DataTable dt = patent.MgeGetList();
            recordsCount = dt.Rows.Count;
        }

        private void GetSerch()
        {
            GridViewDataBind("");

        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetSerch();
        }

        protected void gridData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridData.EditIndex = e.NewEditIndex;
            GridViewDataBind("");
        }

        protected void gridData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridData.EditIndex = -1;
            GridViewDataBind("");
        }

        //删除
        protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PatentMgr patent = new PatentMgr();
            bool resu = patent.MgeDelete(gridData.DataKeys[e.RowIndex].Value.ToString());
            if (resu)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert0", "alert('删除成功')", true);

            }
            GridViewDataBind("");
        }

        //更新
        protected void gridData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PatentMgr patent = new PatentMgr();
            string guid = gridData.DataKeys[e.RowIndex].Value.ToString();
            string panName = ((TextBox)(gridData.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
            string panCode = ((TextBox)(gridData.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
            bool resu = patent.MgeUpdate(guid, panName, panCode);
            if (resu)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('修改成功')", true);
            }
            gridData.EditIndex = -1;
            GridViewDataBind("");
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    //((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "javascript:return(confirm('确认删除该条记录吗？'))");

                    // ScriptManager.RegisterStartupScript(lkb, GetType(), "alertScript", "javascript:if(confirm('确认删除该条记录吗？'))==true{document.forms(0)." + lkb + ".click();}", true);

                    LinkButton lkb = (LinkButton)e.Row.Cells[9].Controls[0];
                    ScriptManager.RegisterStartupScript(lkb, this.GetType(), "alertScript", "javascript:return(confirm('确认删除该条记录吗？'))", true);


                }
            }
        }


        #region 分页

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="sqlSearch"></param>
        private void GridViewDataBind(string sqlSearch)
        {
            currentPage = (int)ViewState["PageIndex"];
            //从ViewState中读取页码值保存到currentPage变量中进行按钮失效运算
            pages = (int)ViewState["pagesCount"];
            //从ViewState中读取总页参数进行按钮失效运算
            //判断四个按钮（首页、上一页、下一页、尾页）状态
            if (currentPage + 1 > 1)//当前页是否为首页
            {
                Fistpage.Enabled = true;
                Prevpage.Enabled = true;
            }
            else
            {
                Fistpage.Enabled = false;
                Prevpage.Enabled = false;
            }
            if (currentPage == pages)//当前页是否为尾页
            {
                Nextpage.Enabled = false;
                Lastpage.Enabled = false;
            }
            else
            {
                Nextpage.Enabled = true;
                Lastpage.Enabled = true;
            }
            DataSet ds = new DataSet();
            string sqlResult;
            //根据传入参数sqlSearch进行判断，如果为default则为默认的分页查询，否则为添加了过滤条件的分页查询
            if (sqlSearch == "default")
            {

            }
            else
            {

            }

            PatentMgr patent = new PatentMgr();
            gridData.DataSource = patent.MgeGetListByPage(txtname.Value.Trim(), true, pageSize, currentPage);
            gridData.DataBind();

            //显示Label控件lbCurrentPaget和文本框控件GotoPage状态
            lbCurrentPage.Text = (currentPage + 1).ToString();
            GotoPage.Text = (currentPage + 1).ToString();


        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PagerBtnCommand_OnClick(object sender, EventArgs e)
        {
            PatentMgr patent = new PatentMgr();

            currentPage = (int)ViewState["PageIndex"];
            pages = (int)ViewState["pagesCount"];
            Button btn = sender as Button;
            string sqlResult = "default";
            if (btn != null)
            {
                string cmd = btn.CommandName;
                switch (cmd)
                {
                    case "next":
                        currentPage++;
                        break;
                    case "prev":
                        currentPage--;
                        break;
                    case "last":
                        currentPage = pages;
                        break;
                    case "search":
                        if (!string.IsNullOrEmpty(txtname.Value))
                        {
                            patent.MgeGetList(txtname.Value, true, out recordsCount);


                            pagesCount = recordsCount / pageSize + OverPage();
                            ViewState["pagesCount"] = recordsCount / pageSize - ModPage();
                            ViewState["PageIndex"] = 0;
                            ViewState["JumpPages"] = pagesCount;
                            lbPageCount.Text = pagesCount.ToString();
                            lbRecordCount.Text = recordsCount.ToString();
                            if (recordsCount <= 10)
                                GotoPage.Enabled = false;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert3", "alert('请输入专利拥有者用户名')", true);
                        }
                        break;
                    case "jump":
                        jumpPage = (int)ViewState["JumpPages"];
                        if (Int32.Parse(GotoPage.Text) > jumpPage || Int32.Parse(GotoPage.Text) <= 0)
                            Response.Write("<script>alert('页码超出范围！')</script>");
                        else
                        {
                            int InputPage = Int32.Parse(GotoPage.Text.ToString()) - 1;
                            ViewState["PageIndex"] = InputPage;
                            currentPage = InputPage;
                        }
                        break;
                    default:
                        currentPage = 0;
                        break;
                }
                ViewState["PageIndex"] = currentPage;
                GridViewDataBind(sqlResult);
            }
        }



        /// <summary>
        /// 计算余页
        /// </summary>
        /// <returns></returns>
        public int OverPage()
        {
            int pages = 0;
            if (recordsCount % pageSize != 0)
                pages = 1;
            else
                pages = 0;
            return pages;
        }


        /// <summary>
        /// 计算余页，防止SQL语句执行时溢出查询范围
        /// </summary>
        /// <returns></returns>
        public int ModPage()
        {
            int pages = 0;
            if (recordsCount % pageSize == 0 && recordsCount != 0)
                pages = 1;
            else
                pages = 0;
            return pages;
        }

        private int GetRecordsCount()
        {
            return 0;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtname.Value = "";
        }

        #endregion
    }
}