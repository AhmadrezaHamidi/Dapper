#pragma checksum "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65061c9e0003be90bf530bad152576e9da019925"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\_ViewImports.cshtml"
using DapperSampleProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\_ViewImports.cshtml"
using DapperSampleProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\_ViewImports.cshtml"
using DapperSampleProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65061c9e0003be90bf530bad152576e9da019925", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bdedce74725b97031e798e28e590ed611f6bedd", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Order List";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""card"">
    <div class=""card-header"">Order List With Dapper.Contrib</div>
    <div class=""card-body"">
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th>Order Id</th>
                    <th>Customer Id</th>
                    <th>Employee Id</th>
                    <th>Order Date</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 19 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml"
                 foreach (var item in Model)
                {   

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 22 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml"
                       Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 23 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml"
                       Write(item.CustomerId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 24 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml"
                       Write(item.EmployeeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 25 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml"
                       Write(item.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td></td>\r\n                    </tr>\r\n");
#nullable restore
#line 28 "D:\DevTube\ASP.NET Core\Session08\Projects\DapperSampleProject\Views\Order\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
