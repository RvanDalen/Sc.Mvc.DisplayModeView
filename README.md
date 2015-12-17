# Sc.Mvc.DisplayModeView
Easily add DisplayMOde specific views for Sitecore MVC

With this solution the implementation is rather simple. If there is a specific DisplayMode view available and we are in Edit or Preview mode, then that view is preferred. If it’s not available then the application reverts to the default.

To create an Edit specific view you copy the current and add ".Edit" to the name.
- SomeRendering.cshtml (default)
- SomeRendering.Edit.cshtml (used only in Edit mode)
- SomeRendering.Preview.cshtml (used only in Preview mode)

This solution works for ControllerRenderings and ViewRenderings.