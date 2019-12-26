#pragma checksum "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb62a49603a82e06d9afa2700b7e477528cb1909"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Profiles_Pages_Users_Index), @"mvc.1.0.razor-page", @"/Areas/Profiles/Pages/Users/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Profiles/Pages/Users/Index.cshtml", typeof(AspNetCore.Areas_Profiles_Pages_Users_Index), null)]
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
#line 1 "D:\Projects\TWHelp\TWHelp\Areas\_ViewImports.cshtml"
using Domain.Models.Identity;

#line default
#line hidden
#line 2 "D:\Projects\TWHelp\TWHelp\Areas\_ViewImports.cshtml"
using Domain.Models.Domain;

#line default
#line hidden
#line 3 "D:\Projects\TWHelp\TWHelp\Areas\_ViewImports.cshtml"
using TWHelp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb62a49603a82e06d9afa2700b7e477528cb1909", @"/Areas/Profiles/Pages/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a20b261fee6531cbb6326723e79904e255f25699", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Profiles_Pages_Users_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(67, 658, true);
            WriteLiteral(@"
<style>
    .page-background-image {
        background-image: url('../images/users-background.svg');
        background-repeat: no-repeat;
        background-size: 50% 100%;
        background-position: right;
        background-attachment: fixed;
    }
</style>

<div class=""container-fluid"">
    <div class=""row page-background-image"">
        <div class=""col-12 col-sm-11 col-md-10 col-lg-9 mx-auto"">
            <div class=""my-5 py-5"">
                <div class=""text-center"">
                    <h4>All TWHelp users</h4>
                </div>
                <div class=""p-2"" style=""background-color: rgba(242, 242, 242, 0.6);"">
");
            EndContext();
#line 24 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml"
                     foreach (var user in Model.Users)
                    {
                        var base64 = Convert.ToBase64String(user.AvatarImage);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);

#line default
#line hidden
            BeginContext(974, 336, true);
            WriteLiteral(@"                        <div id=""psycho-div"" class=""m-2 p-2"" style=""background-color: rgba(255, 255, 255, 0.6);"">
                            <div class=""d-flex flex-column flex-md-row "">
                                <div>
                                    <div>

                                        <img id=""psycho-image""");
            EndContext();
            BeginWriteAttribute("src", " src=\'", 1310, "\'", 1324, 2);
#line 33 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml"
WriteAttributeValue("", 1316, imgSrc, 1316, 7, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1323, "", 1324, 1, true);
            EndWriteAttribute();
            BeginContext(1325, 402, true);
            WriteLiteral(@" alt=""profile-image"" class=""m-3 rounded-circle"" style=""border: 1px solid black;"" width=""200"" height=""200"">
                                    </div>
                                </div>
                                <div class=""d-flex flex-column flex-md-row flex-md-wrap flex-lg-nowrap"">
                                    <div class=""m-3"">
                                        <p>Name: ");
            EndContext();
            BeginContext(1728, 13, false);
#line 38 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml"
                                            Write(user.Nickname);

#line default
#line hidden
            EndContext();
            BeginContext(1741, 56, true);
            WriteLiteral("</p>\r\n                                        <p>Email: ");
            EndContext();
            BeginContext(1798, 10, false);
#line 39 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml"
                                             Write(user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1808, 54, true);
            WriteLiteral("</p>\r\n                                        <p>Age: ");
            EndContext();
            BeginContext(1863, 8, false);
#line 40 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml"
                                           Write(user.Age);

#line default
#line hidden
            EndContext();
            BeginContext(1871, 56, true);
            WriteLiteral("</p>\r\n                                        <p>About: ");
            EndContext();
            BeginContext(1928, 10, false);
#line 41 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml"
                                             Write(user.About);

#line default
#line hidden
            EndContext();
            BeginContext(1938, 257, true);
            WriteLiteral(@"</p>
                                    </div>
                                    <div class=""m-3"">
                                    </div>
                                </div>
                            </div>
                        </div>
");
            EndContext();
#line 48 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Users\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(2218, 82, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWHelp.Areas.Profiles.Pages.Users.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Profiles.Pages.Users.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Profiles.Pages.Users.IndexModel>)PageContext?.ViewData;
        public TWHelp.Areas.Profiles.Pages.Users.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
