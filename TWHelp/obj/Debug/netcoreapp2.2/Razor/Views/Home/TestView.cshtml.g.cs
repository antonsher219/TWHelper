#pragma checksum "D:\Projects\проект по авпз\TWHelp\Views\Home\TestView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fe45b5ce76d3405929b043f7e33d02867c9c693"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TestView), @"mvc.1.0.view", @"/Views/Home/TestView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TestView.cshtml", typeof(AspNetCore.Views_Home_TestView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fe45b5ce76d3405929b043f7e33d02867c9c693", @"/Views/Home/TestView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d11c48bc51a6fece1f8bcb66878277a8517078c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TestView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\проект по авпз\TWHelp\Views\Home\TestView.cshtml"
  
    ViewData["Title"] = "TestView";

#line default
#line hidden
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "D:\Projects\проект по авпз\TWHelp\Views\Home\TestView.cshtml"
 if (ViewBag.Test != null)
{
    

#line default
#line hidden
            BeginContext(84, 22, false);
#line 8 "D:\Projects\проект по авпз\TWHelp\Views\Home\TestView.cshtml"
Write(Html.Raw(ViewBag.Test));

#line default
#line hidden
            EndContext();
#line 8 "D:\Projects\проект по авпз\TWHelp\Views\Home\TestView.cshtml"
                           
}
else
{

#line default
#line hidden
            BeginContext(120, 412, true);
            WriteLiteral(@"    <script>(function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = 'https://embed.playbuzz.com/sdk.js'; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'playbuzz-sdk'));</script>
    <div class=""playbuzz"" data-id=""a77056b2-3712-4a09-8b56-59523262c8d8"" data-show-share=""false"" data-show-info=""false""></div>
");
            EndContext();
#line 14 "D:\Projects\проект по авпз\TWHelp\Views\Home\TestView.cshtml"
}

#line default
#line hidden
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
