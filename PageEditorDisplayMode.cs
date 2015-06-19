using System;
using System.IO;
using System.Web;
using System.Web.WebPages;
using Sitecore;
using Sitecore.Mvc.Extensions;

namespace Sc.Commons.PageEditorView
{
    public class PageEditorDisplayMode : IDisplayMode
    {
        public bool CanHandleContext(HttpContextBase httpContext)
        {
            //Is it an Sitecore MVC route?
            var isContentUrl = httpContext.Items["sc::IsContentUrl"] as string;
            if (string.IsNullOrEmpty(isContentUrl) || !isContentUrl.ToBool()) return false;

            //Are we in PageEditor mode?
            return Context.PageMode.IsPageEditor;
        }

        public DisplayInfo GetDisplayInfo(HttpContextBase httpContext, string virtualPath, Func<string, bool> virtualPathExists)
        {
            var extension = Path.GetExtension(virtualPath);
            var filePath = Path.ChangeExtension(virtualPath, "PageEditor" + extension);

            //Return new DisplayInfo if we were able to find a *.PageEditor view
            if (filePath != null && virtualPathExists(filePath)) return new DisplayInfo(filePath, this);

            return null;
        }

        public string DisplayModeId
        {
            get
            {
                //Return a key to ensure the view is correctly cached in the ViewEngine
                return "PageEditor";
            }
        }
    }
}