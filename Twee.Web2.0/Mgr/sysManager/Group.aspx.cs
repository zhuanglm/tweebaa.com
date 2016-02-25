﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using AjaxPro;
using System.Data;

namespace TweebaaWebApp2.Mgr.sysManager
{
    public partial class Group : System.Web.UI.Page
    {
        public string _treeJson = string.Empty;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //List<int> funclist = new List<int> { 110,1101,1102,111,121,1232,1233};
            List<int> funclist = new List<int>();
            
            Utility.RegisterTypeForAjax(typeof(Group));
            hidID.Value = string.Empty;
            if (string.IsNullOrEmpty(Request["id"]))
            {
                linkBtnSave.Style.Add("display", "none");
            }
            else
            {
                linkBtnRegister.Style.Add("display", "none");
                string sMgrGroupID = Request["id"].Trim();
                hidID.Value = sMgrGroupID;
                int nGrpID = int.Parse(sMgrGroupID);

                Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
                var model = mgr.GetGrpModel(nGrpID);
                txtName.Value = model.sName;
                txtDes.Value = model.sDescription;
                //selRole.SelectedValue = model.role.ToString().Trim();
                selState.SelectedValue = model.iActive.ToString().Trim();

                DataTable dt = mgr.GetGroupFunctionList(nGrpID);
                if (dt == null)
                    return;

                foreach (DataRow dr in dt.Rows)
                {
                    funclist.Add(int.Parse(dr["MgrFunction_ID"].ToString()));
                    //System.Diagnostics.Debug.Write(dr["MgrFunction_ID"].ToString());
                }
            }
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\Mgr\\mgrConfig\\MgrTreeConfig.txt";
            _treeJson = mgrcomm.mgrHelper._MgrReadConfig(configPath);

            List<SysAdmMenu> menulist = JsonConvert.DeserializeObject<List<SysAdmMenu>>(_treeJson);
            for (int i = 0; i < menulist.Count; i++)
            {
                if (funclist.Contains(menulist[i].id))
                {
                    menulist[i].@checked = true;
                }

                for (int j = 0; j < menulist[i].children.Count; j++)
                {
                    if (funclist.Contains(menulist[i].children[j].id))
                    {
                        menulist[i].children[j].@checked = true;
                    }
                }
            }
            _treeJson = JsonConvert.SerializeObject(menulist);
        }

        protected void linkBtnRegister_Click(object sender, EventArgs e)
        {
            string groupName = txtName.Value;
            string groupDes = txtDes.Value;
            string groupPower = hidSelect.Value;
            string errMsg;
            int     nGrpID;
            
            //string role = selRole.SelectedValue;
            string state = selState.SelectedValue;
            if (string.IsNullOrEmpty(groupName))
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('please input group name')"); return;
            }
            if (string.IsNullOrEmpty(groupPower))
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('please assign authorization to group')"); return;
            }
            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();

            nGrpID = mgr.AddGroup(groupName,groupDes,int.Parse(state)>0,out errMsg);
            if (nGrpID > 0)
            {
                int[] arrInt = Array.ConvertAll<string, int>(groupPower.Split(','), s => int.Parse(s));
                List<int> funclist = new List<int>(arrInt);
                if(mgr.SetGroupFunctionList(nGrpID, funclist)>0)
                    HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('new group was added')");
            }
            else
            {
                HD.Common.JavaScriptHelper.RegisterScriptBlock(this.Page, "alert('registion fail:'+errMsg)");
            }
        }

        [AjaxPro.AjaxMethod]
        public string Save(string id, string GrpName, string Des, /*string role,*/ string state, string groupPower)
        {
            Twee.Model.MgrGroup adm = new Twee.Model.MgrGroup();
            adm.iID = int.Parse(id);
            adm.sName = GrpName;
            adm.sDescription = Des;
            adm.iActive  = int.Parse(state);
            Twee.Mgr.AdminstratorMgr mgr = new Twee.Mgr.AdminstratorMgr();
            //adm.role = int.Parse(role);
            if (mgr.UpdateGroup(adm))
            {
                int[] arrInt = Array.ConvertAll<string, int>(groupPower.Split(','), s => int.Parse(s));
                List<int> funclist = new List<int>(arrInt);
                if (mgr.SetGroupFunctionList(adm.iID, funclist) > 0)
                    return "success";
            }
            else
            {
                return "fail";
            }

            return "fail";
        }
    }

    public class SysAdmMenu
    {
        public int id;
        public string text;
        public string state;
        public bool @checked;
        public List<SysAdmMenu_Child> children;
    }

    public class SysAdmMenu_Child
    {
        public int id;
        public string text;
        public bool @checked;
        public MenuAttribute attributes;
    }

    public struct MenuAttribute
    {
        public string url;
    }
}