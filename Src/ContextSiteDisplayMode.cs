using System;
using System.IO;
using System.Web;
using System.Web.WebPages;
using Sitecore;
using Sitecore.Mvc.Extensions;
using Sitecore.Sites;

namespace Sc.Mvc.DisplayModeView
{
    public class ContextSiteDisplayMode : IDisplayMode
    {
        public bool CanHandleContext(HttpContextBase httpContext)
        {
            //Is it an Sitecore MVC route?
            var isContentUrl = httpContext.Items["sc::IsContentUrl"] as string;
            if (string.IsNullOrEmpty(isContentUrl) || !isContentUrl.ToBool()) return false;

            //Are we in a special mode?
            return Context.Site != null && Context.Site.DisplayMode != DisplayMode.Normal;
        }

        public DisplayInfo GetDisplayInfo(HttpContextBase httpContext, string virtualPath, Func<string, bool> virtualPathExists)
        {
            var extension = Path.GetExtension(virtualPath);
            var filePath = Path.ChangeExtension(virtualPath, Context.Site.DisplayMode + extension);

            //Return new DisplayInfo if we were able to find a *.PageEditor view
            if (filePath != null && virtualPathExists(filePath)) return new DisplayInfo(filePath, this);

            return null;
        }

        public string DisplayModeId
        {
            get
            {
                //Return a key to ensure the view is correctly cached in the ViewEngine
                return Context.Site.DisplayMode.ToString();
            }
        }
    }
}