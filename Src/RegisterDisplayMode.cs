using System.Web.WebPages;
using Sitecore.Pipelines;

namespace Sc.Mvc.DisplayModeView
{
    public class RegisterDisplayMode
    {
        public virtual void Process(PipelineArgs args)
        {
            DisplayModeProvider.Instance.Modes.Insert(0, new ContextSiteDisplayMode());
        }
    }
}
