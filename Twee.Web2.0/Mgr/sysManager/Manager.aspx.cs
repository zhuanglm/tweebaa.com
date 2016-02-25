﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Data;
using Newtonsoft.Json;

namespace TweebaaWebApp2.Mgr.sysManager
{
    public partial class Manager : System.Web.UI.Page
    {
        
        public string _unselected = string.Empty;
        public string _selected = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<GroupOption> unselected_grouplist = new List<GroupOption>();
            List<GroupOption> selected_grouplist = new List<GroupOption>();
                        
            Utility.RegisterTypeForAjax(typeof(Manager));
            hidID.Value = string.Empty;

            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
            /*Twee.Model.MgrUser adm = (Twee.Model.MgrUser)Session["CURRENT_USER"];
            if (!mgr.IsFuncAllowed(adm.iID, 610))
            {
                Response.Write("<script>alert('This function was NOT allowed!');window.navigate('../index.aspx');</script>");
                //Response.Write("<Script Language=JavaScript>...alert('This function was NOT allowed！');window.navigate('main.aspx');</Script>");
                return;
            }*/
            DataTable dt = mgr.GetGroupList();
            if (dt == null)
                return;

            foreach (DataRow dr in dt.Rows)
            {
                GroupOption group = new GroupOption();
                group.value = int.Parse(dr["MgrUserGroupType_ID"].ToString());
                group.text = dr["MgrUserGroupType_Name"].ToString();
                //group.sDescription = dr["MgrUserGroupType_Description"].ToString();
                unselected_grouplist.Add(group);
                //System.Diagnostics.Debug.Write(dr["MgrFunction_ID"].ToString());
            }

            if (string.IsNullOrEmpty(Request["id"]))
            {
                linkBtnSave.Style.Add("display", "none");

            }
            else
            {
                linkBtnRegister.Style.Add("display", "none");
                string sMgrUserID = Request["id"].Trim();
                hidID.Value = sMgrUserID;
                var model = new Twee.Mgr.AdminstratorMgr().GetModel(int.Parse(sMgrUserID));
                txtName.Value = model.sName;
                
                //selRole.SelectedValue = model.role.ToString().Trim();
                selState.SelectedValue = model.iActive.ToString().Trim();

                dt = mgr.GetUserGroupList(int.Parse(sMgrUserID));
                if (dt == null)
                return;

                foreach (DataRow dr in dt.Rows)
                {
                    int nAuthorized = int.Parse(dr["MgrUserGroupType_ID"].ToString());
                    for (int i = 0; i < unselected_grouplist.Count(); i++ )
                    {
                        if (nAuthorized == unselected_grouplist[i].value)
                        {
                            selected_grouplist.Add(unselected_grouplist[i]);
                            unselected_grouplist.Remove(unselected_grouplist[i]);
                            break;
                        }
                    }

                }
            }

            _unselected = JsonConvert.SerializeObject(unselected_grouplist);
            _selected = JsonConvert.SerializeObject(selected_grouplist);
        }

        protected void linkBtnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtName.Value;
            string userPwd = txtPwd1.Value;
            string groups = hidSelect.Value;
            string state = selState.SelectedValue;

            if (string.IsNullOrEmpty(userName))
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('please input user name')"); return;
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('please input password')"); return;
            }
            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
            Twee.Model.MgrUser model = new Twee.Model.MgrUser();
            model.sName = userName;
            model.sPassword = HD.Common.MD5Encrypt.GetStrMD5(userPwd);
            model.iActive = int.Parse(state);
            //model.role = int.Parse(role);
            int iNewID = mgr.Add(model);
            if (iNewID > 0)
            {
                groups = groups.Substring(0, groups.LastIndexOf(","));
                int[] arrInt = Array.ConvertAll<string, int>(groups.Split(','), s => int.Parse(s));
                List<int> grouplist = new List<int>(arrInt);
                if (mgr.SetUserGroupList(iNewID, grouplist) > 0)
                    HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('new administrator was added')");
            }
            else
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('registeration failed')");
            }
        }

        [AjaxPro.AjaxMethod]
        public string Save(string id, string userName, string pwd, /*string role,*/ string state, string groups)
        {
            Twee.Model.MgrUser adm = new Twee.Model.MgrUser();
            adm.iID = int.Parse(id);
            adm.sName = userName;
            adm.iActive  = int.Parse(state);
            //adm.role = int.Parse(role);
            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
            var bRe = true;
            if (pwd == string.Empty)
            {
                bRe = mgr.Update(adm,false);
            }
            else
            {
                adm.sPassword = HD.Common.MD5Encrypt.GetStrMD5(pwd);
                bRe = mgr.Update(adm,true);
            }
            if (bRe)
            {
                groups = groups.Substring(0, groups.LastIndexOf(","));
                int[] arrInt = Array.ConvertAll<string, int>(groups.Split(','), s => int.Parse(s));
                List<int> grouplist = new List<int>(arrInt);
                if (mgr.SetUserGroupList(adm.iID, grouplist) > 0)
                    return "success";
                else
                    return "set group fail";
            }
            else
            {
                return "fail";
            }
            

        }
    }

    public class GroupOption
    {
        public int value;
        public string text;
    }
}