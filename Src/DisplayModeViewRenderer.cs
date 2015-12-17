using System.IO;
using System.Web.Hosting;
using Sitecore;
using Sitecore.Mvc.Presentation;
using Sitecore.Sites;

namespace Sc.Mvc.DisplayModeView
{
    public class DisplayModeViewRenderer : ViewRenderer
    {
        public override void Render(TextWriter writer)
        {
            if (Context.Site != null && Context.Site.DisplayMode != DisplayMode.Normal)
            {
                var extension = Path.GetExtension(ViewPath);
                var filePath = Path.ChangeExtension(ViewPath, Context.Site.DisplayMode + extension);

                if (HostingEnvironment.VirtualPathProvider.FileExists(filePath))
                    ViewPath = filePath;
            }

            base.Render(writer);
        }
    }
}
