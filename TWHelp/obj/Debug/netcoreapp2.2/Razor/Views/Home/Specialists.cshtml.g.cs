#pragma checksum "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e3a1370f6d4e87658ebf5eb605713ea54d22b91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Specialists), @"mvc.1.0.view", @"/Views/Home/Specialists.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Specialists.cshtml", typeof(AspNetCore.Views_Home_Specialists))]
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
#line 1 "D:\Projects\проект по авпз\TWHelp\Views\_ViewImports.cshtml"
using Domain.Models.Identity;

#line default
#line hidden
#line 2 "D:\Projects\проект по авпз\TWHelp\Views\_ViewImports.cshtml"
using Domain.Models.Domain;

#line default
#line hidden
#line 3 "D:\Projects\проект по авпз\TWHelp\Views\_ViewImports.cshtml"
using TWHelp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e3a1370f6d4e87658ebf5eb605713ea54d22b91", @"/Views/Home/Specialists.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d11c48bc51a6fece1f8bcb66878277a8517078c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Specialists : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
  
    ViewData["Title"] = "Specialists";

#line default
#line hidden
            BeginContext(49, 182, true);
            WriteLiteral("\r\n<h1>Specialists</h1>\r\n\r\n<div style=\"width:100%; height:100%; background: #f2f2f2; z-index:-1;\" class=\"mx-auto\">\r\n\r\n    <div style=\"width:90%; padding-top:10px ;\" class=\"mx-auto\">\r\n");
            EndContext();
#line 11 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
         foreach (var x in ViewBag.Spec)
        {

#line default
#line hidden
            BeginContext(284, 216, true);
            WriteLiteral("            <div style=\" width: 100%; \" class=\"row text-left border border-dark mb-4 mr-n4\">\r\n                <div class=\"col-2\" style=\"padding-top: 1%; padding-bottom: 1%;padding-left:1%;\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\'", 500, "\'", 564, 2);
#line 15 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
WriteAttributeValue("", 506, Url.Action("getImgByIdAsync", "Home", new { id = x.Id }), 506, 57, false);

#line default
#line hidden
            WriteAttributeValue(" ", 563, "", 564, 1, true);
            EndWriteAttribute();
            BeginContext(565, 277, true);
            WriteLiteral(@" alt="""" style=""border:1px solid black; width:100px; height:100px"">
                    
                </div>

                <div class=""col-10 ml-n5"">
                    
                        <p>
                            <h3>
                                ");
            EndContext();
            BeginContext(843, 10, false);
#line 23 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
                           Write(x.Nickname);

#line default
#line hidden
            EndContext();
            BeginContext(853, 133, true);
            WriteLiteral("\r\n                            </h3>\r\n                    </p>\r\n                    <hr style=\"margin-top: -2%;margin-bottom: 0%\" />\r\n");
            EndContext();
#line 27 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
                     if (x.About == null)
                    {

#line default
#line hidden
            BeginContext(1052, 152, true);
            WriteLiteral("                        <p> Hi, I am a professional psychologist and I will be happy to help you solve all your life problems. You can call the number: ");
            EndContext();
            BeginContext(1205, 13, false);
#line 29 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
                                                                                                                                                   Write(x.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1218, 14, true);
            WriteLiteral(" or email me: ");
            EndContext();
            BeginContext(1233, 7, false);
#line 29 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
                                                                                                                                                                               Write(x.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1240, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 30 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1318, 27, true);
            WriteLiteral("                        <p>");
            EndContext();
            BeginContext(1346, 7, false);
#line 33 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
                      Write(x.About);

#line default
#line hidden
            EndContext();
            BeginContext(1353, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 34 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
                    }

#line default
#line hidden
            BeginContext(1382, 42, true);
            WriteLiteral("                </div>\r\n          </div>\r\n");
            EndContext();
#line 37 "D:\Projects\проект по авпз\TWHelp\Views\Home\Specialists.cshtml"
        }

#line default
#line hidden
            BeginContext(1435, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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