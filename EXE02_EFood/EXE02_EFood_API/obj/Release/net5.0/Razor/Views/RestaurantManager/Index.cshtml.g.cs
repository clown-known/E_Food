#pragma checksum "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e32047663e34772b1afe5fc793830cb734be33f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RestaurantManager_Index), @"mvc.1.0.view", @"/Views/RestaurantManager/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e32047663e34772b1afe5fc793830cb734be33f", @"/Views/RestaurantManager/Index.cshtml")]
    #nullable restore
    public class Views_RestaurantManager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EXE02_EFood_API.Models.Restaurant>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.District));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OpenTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.VoteRating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Lat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Log));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 55 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.District));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 73 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OpenTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 76 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.VoteRating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 79 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 82 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Lat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 85 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Log));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 88 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 91 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2741, "\"", 2767, 1);
#nullable restore
#line 94 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
WriteAttributeValue("", 2756, item.ResId, 2756, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2820, "\"", 2846, 1);
#nullable restore
#line 95 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
WriteAttributeValue("", 2835, item.ResId, 2835, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2901, "\"", 2927, 1);
#nullable restore
#line 96 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
WriteAttributeValue("", 2916, item.ResId, 2916, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 99 "D:\Semester 8\EXECoding\EXE02_EFood\EXE02_EFood_API\Views\RestaurantManager\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EXE02_EFood_API.Models.Restaurant>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
