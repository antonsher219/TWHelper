#pragma checksum "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1672c37eb60d6c40cd1d3f897d7d4fab4f04a4e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Home_Pages_Temp_Tests), @"mvc.1.0.view", @"/Areas/Home/Pages/Temp/Tests.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Home/Pages/Temp/Tests.cshtml", typeof(AspNetCore.Areas_Home_Pages_Temp_Tests))]
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
#line 1 "D:\Projects\проект по авпз\TWHelp\Areas\_ViewImports.cshtml"
using Domain.Models.Identity;

#line default
#line hidden
#line 2 "D:\Projects\проект по авпз\TWHelp\Areas\_ViewImports.cshtml"
using Domain.Models.Domain;

#line default
#line hidden
#line 3 "D:\Projects\проект по авпз\TWHelp\Areas\_ViewImports.cshtml"
using TWHelp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1672c37eb60d6c40cd1d3f897d7d4fab4f04a4e6", @"/Areas/Home/Pages/Temp/Tests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edbc150fb1bd4fac81dc98d762603619d51eae9c", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Home_Pages_Temp_Tests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
  
    ViewData["Title"] = "Tests";

#line default
#line hidden
            BeginContext(43, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 7 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
 if (User.Identity.IsAuthenticated && (User.IsInRole("admin") || User.IsInRole("specialist")))
{

#line default
#line hidden
            BeginContext(146, 259, true);
            WriteLiteral(@"    <form method=""get"" action=""CreateTest"">

        <button type=""submit"" style=""margin-left:75%; top:82px; width:120px;
         z-index:1;"" class=""position-absolute btn btn-primary text-center"">
            Create test
        </button>
    </form>
");
            EndContext();
#line 16 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
}

#line default
#line hidden
            BeginContext(408, 72, true);
            WriteLiteral("\r\n    <div style=\"background: #f2f2f2; z-index:-1;\" class=\"mx-auto\">\r\n\r\n");
            EndContext();
#line 20 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
         foreach (var test in ViewBag.Tests)
        {


#line default
#line hidden
            BeginContext(539, 281, true);
            WriteLiteral(@"            <div style=""width:90%; padding:2% ;"" class=""mx-auto"">


                <div style="" width: 100%; "" class=""row text-left border border-dark mb-1 bg-white"">

                    <div class=""col-10 text-justify mt-1"">

                        <h3 id="""" onclick="""">");
            EndContext();
            BeginContext(821, 10, false);
#line 30 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
                                        Write(test.Theme);

#line default
#line hidden
            EndContext();
            BeginContext(831, 76, true);
            WriteLiteral("</h3>\r\n\r\n\r\n                        <p class=\"\" style=\"white-space: normal;\">");
            EndContext();
            BeginContext(908, 16, false);
#line 33 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
                                                            Write(test.Description);

#line default
#line hidden
            EndContext();
            BeginContext(924, 235, true);
            WriteLiteral("</p>\r\n\r\n\r\n                    </div>\r\n                    <div class=\"col-2 text-center my-auto\" style=\"\">\r\n                        <form>\r\n\r\n                            <button type=\"submit\" asp-action=\"TestView\" asp-controller=\"Home\"");
            EndContext();
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1159, "\"", 1182, 1);
#line 40 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
WriteAttributeValue("", 1174, test.Id, 1174, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1183, 215, true);
            WriteLiteral(" class=\"btn btn-dark rounded-circle my-2\" style=\"width:130px; height:130px\"><h3><i>Start</i></h3></button>\r\n\r\n                        </form>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 46 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Temp\Tests.cshtml"
        }

#line default
#line hidden
            BeginContext(1409, 10, true);
            WriteLiteral("    </div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591