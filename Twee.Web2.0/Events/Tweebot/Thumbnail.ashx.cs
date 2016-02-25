using System.Web;

namespace TweebaaWebApp2.Events.Tweebot
{
	public class Thumbnail : IHttpHandler {

		public void ProcessRequest (HttpContext context) {
			context.Response.ContentType = "image/jpg";
			context.Response.WriteFile(context.Server.MapPath("/images/default_thumb.jpg"));
		}

		public bool IsReusable { get { return false; } }
	}
}
