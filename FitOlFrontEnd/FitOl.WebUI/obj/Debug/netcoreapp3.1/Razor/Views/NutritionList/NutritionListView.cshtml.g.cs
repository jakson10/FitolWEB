#pragma checksum "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\NutritionList\NutritionListView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bbde502ccb4e7d9b9a09562f7c833442fdd93d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NutritionList_NutritionListView), @"mvc.1.0.view", @"/Views/NutritionList/NutritionListView.cshtml")]
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
#line 1 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\_ViewImports.cshtml"
using FitOl.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\_ViewImports.cshtml"
using FitOl.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\_ViewImports.cshtml"
using FitOl.WebUI.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\_ViewImports.cshtml"
using FitOl.WebUI.Models.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\_ViewImports.cshtml"
using FitOl.WebUI.Models.Calculator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bbde502ccb4e7d9b9a09562f7c833442fdd93d5", @"/Views/NutritionList/NutritionListView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68be884424b98f6e618642ec01de67e13e8a8c75", @"/Views/_ViewImports.cshtml")]
    public class Views_NutritionList_NutritionListView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MealFoodsDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\NutritionList\NutritionListView.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card shadow mb-4"">
    <div class=""card-header py-3"" style=""background-color:darkgrey"">
        <h6 class=""m-0 font-weight-bold text-primary"" style=""color:coral"">Beslenme Listesi</h6>
    </div>
    <div class=""card-body"" style=""background-color:white"">
        <div class=""table-responsive"">
            <table class=""table table-bordered"" id=""besinListeTablosu"" width=""100%"" cellspacing=""0"">
                <thead>
                    <tr>
                        <th>
                            <label>Besin İsmi</label>
                        </th>
                        <th>
                            <label>Hangi Öğün </label>
                        </th>
                        <th>
                            <label>Hangi Gün</label>
                        </th>
");
            WriteLiteral("                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\NutritionList\NutritionListView.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 42 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\NutritionList\NutritionListView.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Food.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 45 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\NutritionList\NutritionListView.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ThatDay.EnumMealType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 48 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\NutritionList\NutritionListView.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ThatDay.NutritionDays.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 52 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\NutritionList\NutritionListView.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MealFoodsDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
