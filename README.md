# Sc.Commons.PageEditor
Easily add PageEditor specific views for Sitecore MVC

With this solution the implementation is rather simple. If there is a PageEditor view available and we are in the Page Editor (or Experience Editor if you will), then that view is preferred. If it’s not available then the application reverts to the default.

To create a PageEditor specific view you copy the current and add ".PageEditor" to the name.
- SomeRendering.cshtml (default)
- SomeRendering.PageEditor.cshtml (used only in PageEditor mode)

This solution works for ControllerRenderings and ViewRenderings.
