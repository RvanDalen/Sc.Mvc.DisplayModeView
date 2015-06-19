using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Sitecore.Mvc.Presentation;

namespace Sc.Commons.PageEditorView
{
    public class GetPageEditorViewRenderer : GetViewRenderer
    {
        public override void Process(GetRendererArgs args)
        {
            base.Process(args);
            
            var viewRendering = args.Result as ViewRenderer;
            if (viewRendering != null)
            {
                args.Result = new PageEditorViewRenderer
                {
                    ViewPath = viewRendering.ViewPath,
                    Rendering = viewRendering.Rendering
                };
            }
        }
    }
}
