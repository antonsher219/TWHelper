#pragma checksum "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e81d80e26b4e47d8ea729c1bba2525dcdd86926"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Home_Pages_Index), @"mvc.1.0.razor-page", @"/Areas/Home/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Home/Pages/Index.cshtml", typeof(AspNetCore.Areas_Home_Pages_Index), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e81d80e26b4e47d8ea729c1bba2525dcdd86926", @"/Areas/Home/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edbc150fb1bd4fac81dc98d762603619d51eae9c", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Home_Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Projects\проект по авпз\TWHelp\Areas\Home\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(95, 341, true);
            WriteLiteral(@"
<div style=""height:calc(100vh - 119px); background: #f2f2f2; z-index:-1;"" class=""mx-auto"">
    <div style=""text-align:center; margin-bottom: 0%; background: #f2f2f2;"">
        <h1 class=""display-4"">Welcome</h1>

        <p>Check your mental condition <a href=""https://docs.microsoft.com/aspnet/core"">here</a>.</p>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWHelp.Areas.Home.Pages.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Home.Pages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Home.Pages.IndexModel>)PageContext?.ViewData;
        public TWHelp.Areas.Home.Pages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591