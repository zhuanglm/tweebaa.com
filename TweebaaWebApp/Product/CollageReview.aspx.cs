﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Model;
using Twee.Mgr;
using System.Text;

namespace TweebaaWebApp.Product
{
    public partial class CollageReview : TweebaaWebApp.MasterPages.BasePage
    {
        public string templateHTML;
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例
        public bool isLogion;
        public string design_id;
        public string IsValidID="";
        public string shareID = "";
        public string sTitle = "";
        public string sInspiration = "";

       
        protected void Page_Load(object sender, EventArgs e)
        {
            isLogion = CheckLogion(out userGuid);



            if (null != userGuid)
            {
                _userid = userGuid.ToString();
                //_userid = userGuid.ToString();
                var persent = new Twee.Mgr.UserGradeCalMgr().GetUserGrade(userGuid).Rows[0]["sratio"];
                if (null != persent && !Convert.IsDBNull(persent))
                    _persent = (((int)persent) / 1000).ToString();
            }
            else
            {
                _userid = "";
                _persent = "";
            }
            HttpCookie myDesignID = new HttpCookie("DesignID");
            myDesignID = Request.Cookies["DesignID"];

            try
            {
                // Read the cookie information and display it.
                
                if (myDesignID != null && int.Parse(myDesignID.Value.ToString()) > 0)
                {
                    design_id = myDesignID.Value.ToString();
                }
                else
                {
                    //get html from template
                    design_id = Request.QueryString["design_id"];
                    
                    if (design_id.IndexOf("_") > 0)
                    {
                        design_id = Twee.Comm.CommUtil.GetUrlPrdId(design_id, out shareID);
                        //shareID = "_" + shareID;
                    }
                }
                if (design_id != null)
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    Twee.Model.CollageDesign design = mgr.GetDesignByID(design_id);
                    templateHTML = design.innerHTML;

                    //check this product is valid or not
                    Twee.Mgr.CollageDesignProductMgr pMgr = new CollageDesignProductMgr();
                    int iValid = pMgr.CheckCollageDesignValid(design_id);

                    if (iValid == 0)
                    {
                        string sNotify = mgr.GetDesignEMailNotify(design_id);
                        if (sNotify.Length > 2)
                        {
                            string s1 = sNotify.Substring(0, 1);
                            string eMail = sNotify.Substring(1, sNotify.Length - 1);
                            if (int.Parse(s1) == 0)
                            {
                                SendNotifyEMail(design, eMail);
                                mgr.SetDesignEMailNotify(design_id);
                            }
                        }

                    }
                    IsValidID = iValid.ToString();

                    sTitle = design.CollageDesing_Title;
                    sInspiration = design.Inspiration;
                }
            }
            catch (Exception e1)
            {

            }
            //templateID = template.id;
        }

        private void SendNotifyEMail(Twee.Model.CollageDesign design, string eMail)
        {
            

            StringBuilder emailBody = new StringBuilder();
            emailBody.Append("<p>Dear "+design.User_name+"</p>");
            emailBody.Append("");
            emailBody.Append("<p>Your Tweebaa collage titled “" + design.CollageDesing_Title + "” has been deactivated because item(s) listed in the collage are no longer available for purchase at Tweebaa.com.</p>");
            emailBody.Append("");
            emailBody.Append("<p>Don’t worry ~ it’s easy to update your collage design!  Please login to your Tweebaa account and select “My Collage Designs”, then open the collage referenced above.</p>");
            emailBody.Append("");
            emailBody.Append("<p>Once you update the collage, you can reactivate it so you can earn when other Tweebaa members share!</p>");
            emailBody.Append("");
            emailBody.Append("<p>Thank you,</p>");
            emailBody.Append("<p>The Tweebaa Team</p>");

            bool bSend = Twee.Comm.Mailhelper.SendMail("Please update your Tweebaa collage", emailBody.ToString(), eMail);
        }
    }
}