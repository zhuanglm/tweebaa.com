using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp.UploadFile;

namespace TweebaaWebApp
{
    public partial class fileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UploadPicServiceClient ser = new UploadPicServiceClient();

            FileUploadMessage request = new FileUploadMessage();
            request.FileName = FileUpload1.FileName;
            request.FileData = FileUpload1.FileContent;

            IUploadPicService channel = ser.ChannelFactory.CreateChannel();
            channel.UploadFile(request);

        }
    }
}