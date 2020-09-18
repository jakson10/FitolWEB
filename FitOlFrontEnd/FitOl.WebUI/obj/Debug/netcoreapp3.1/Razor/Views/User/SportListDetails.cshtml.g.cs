#pragma checksum "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3b9a87f7405177e7dc168fee6dc76bcefa6f12a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_SportListDetails), @"mvc.1.0.view", @"/Views/User/SportListDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3b9a87f7405177e7dc168fee6dc76bcefa6f12a", @"/Views/User/SportListDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68be884424b98f6e618642ec01de67e13e8a8c75", @"/Views/_ViewImports.cshtml")]
    public class Views_User_SportListDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AreaMovementsDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card shadow mb-4\">\r\n    <div class=\"card-header py-3\" style=\"background-color:darkgrey\">\r\n        <h6 class=\"m-0 font-weight-bold text-primary\" style=\"color:coral\">");
#nullable restore
#line 9 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
                                                                     Write(User.Identity.Name.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Spor Listesi</h6>
    </div>
    <div class=""card-body"" style=""background-color:white"">
        <div class=""table-responsive"">
            <table class=""table table-bordered"" id=""besinListeTablosu"" width=""100%"" cellspacing=""0"">
                <thead>
                    <tr>
                        <th>
                            <label>Hangi Gün</label>
                        </th>
                        <th>
                            <label>Etki Ettiği Bölge </label>
                        </th>
                        <th>
                            <label>Hareket İsmi</label>
                        </th>
                        <th>
                            <label>Hangi Açıklaması</label>
                        </th>
");
            WriteLiteral("                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 44 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th>\r\n                                ");
#nullable restore
#line 48 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Area.SportDay.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <td>\r\n                                ");
#nullable restore
#line 51 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Area.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 54 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Movement.MovementName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 57 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Movement.MovementDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 60 "C:\Users\FatihSOZUER\source\repos\FitOlFrontEnd\FitOl.WebUI\Views\User\SportListDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AreaMovementsDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
