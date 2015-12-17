using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Sitecore.Mvc.Presentation;

namespace Sc.Mvc.DisplayModeView
{
    public class GetDisplayModeViewRenderer : GetViewRenderer
    {
        public override void Process(GetRendererArgs args)
        {
            base.Process(args);
            
            var viewRendering = args.Result as ViewRenderer;
            if (viewRendering != null)
            {
                args.Result = new DisplayModeViewRenderer
                {
                    ViewPath = viewRendering.ViewPath,
                    Rendering = viewRendering.Rendering
                };
            }
        }
    }
}
