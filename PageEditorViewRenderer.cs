using System.IO;
using System.Web.Hosting;
using Sitecore;
using Sitecore.Mvc.Presentation;

namespace Sc.Commons.PageEditorView
{
    public class PageEditorViewRenderer : ViewRenderer
    {
        public override void Render(TextWriter writer)
        {
            if (Context.PageMode.IsPageEditor)
            {
                var extension = Path.GetExtension(ViewPath);
                var filePath = Path.ChangeExtension(ViewPath, "PageEditor" + extension);

                if (HostingEnvironment.VirtualPathProvider.FileExists(filePath))
                    ViewPath = filePath;
            }

            base.Render(writer);
        }
    }
}
