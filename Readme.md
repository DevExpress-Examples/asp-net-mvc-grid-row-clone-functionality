<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550388/12.2.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4643)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Sample/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Sample/Controllers/HomeController.vb))
* [Person.cs](./CS/Sample/Models/Person.cs) (VB: [Person.vb](./VB/Sample/Models/Person.vb))
* [PersonsList.cs](./CS/Sample/Models/PersonsList.cs) (VB: [PersonsList.vb](./VB/Sample/Models/PersonsList.vb))
* **[GridViewEditingPartial.cshtml](./CS/Sample/Views/Home/GridViewEditingPartial.cshtml)**
* [Index.cshtml](./CS/Sample/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to implement row copy / clone functionality
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4643)**
<!-- run online end -->


<p>This example is based on the <a href="https://www.devexpress.com/Support/Center/p/E3983">E3983: GridView - How to edit in memory data source</a> example.<br />
It illustrates how to implement row copy / clone functionality similar to the ASP.NET WebForms solution illustrated in the online <a href="http://demos.devexpress.com/ASPxGridViewDemos/Columns/CommandColumnCustomButtons.aspx"><u>Grid Columns - Custom Buttons</u></a> demo.</p><p>Here are the main implementation details:<br />
- Specify the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_CustomActionRouteValuestopic"><u>GridViewSettings.CustomActionRouteValues.Action</u></a> property - a method for custom callbacks routine;<br />
- Add a new Custom Button;<br />
- Handle the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_CustomButtonClicktopic"><u>ASPxClientGridView.CustomButtonClick</u></a> event;<br />
- Get the clicked row's keyValue via the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_GetRowKeytopic"><u>ASPxClientGridView.GetRowKey</u></a> method. Pass the <strong>e.visibleIndex</strong> property as a parameter;<br />
- Store the retrieved row's keyValue;<br />
- Perform a custom grid callback via the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_PerformCallbacktopic"><u>ASPxClientGridView.PerformCallback</u></a> method;<br />
- Handle the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_BeginCallbacktopic"><u>ASPxClientGridView.BeginCallback</u></a> event. If the custom callback is currently processing (<strong>e.command</strong> equals  "CUSTOMCALLBACK"), populate the e.customArgs item with the stored keyValue. See the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument9941"><u>Passing Values to Controller Action Through Callbacks</u></a> help article to learn more on how to deal with this option;<br />
- Handle <strong>GridViewSettings.CustomActionRouteValues.Action</strong>. Pass the stored keyValue to the PartialView via the ViewData;</p><p>In the PartialView:<br />
- Handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_BeforeGetCallbackResulttopic"><u>GridViewSettings.BeforeGetCallbackResult</u></a> event. If there is an item in the ViewData, start editing a new row via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_AddNewRowtopic"><u>MVCxGridView.AddNewRow</u></a> method;<br />
- Handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_InitNewRowtopic"><u>GridViewSettings.InitNewRow</u></a> event. If there is an item in the ViewData, copy row values from the original row to the new one.</p>

<br/>


