#pragma checksum "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d913653b7fefed3356aa35e4e1328016cdf0253f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles_Edit), @"mvc.1.0.view", @"/Views/Roles/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Roles/Edit.cshtml", typeof(AspNetCore.Views_Roles_Edit))]
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
#line 8 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d913653b7fefed3356aa35e4e1328016cdf0253f", @"/Views/Roles/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d11c48bc51a6fece1f8bcb66878277a8517078c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Roles_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TWHelp.Models.ChangeRoleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            BeginContext(42, 12, true);
            WriteLiteral("\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(134, 25, true);
            WriteLiteral("\r\n<h2>Changing roles for ");
            EndContext();
            BeginContext(160, 15, false);
#line 11 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
                  Write(Model.UserEmail);

#line default
#line hidden
            EndContext();
            BeginContext(175, 9, true);
            WriteLiteral("</h2>\r\n\r\n");
            EndContext();
            BeginContext(184, 483, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d913653b7fefed3356aa35e4e1328016cdf0253f4861", async() => {
                BeginContext(222, 40, true);
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"userId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 262, "\"", 283, 1);
#line 14 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
WriteAttributeValue("", 270, Model.UserId, 270, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(284, 35, true);
                WriteLiteral(" />\r\n    <div class=\"form-group\">\r\n");
                EndContext();
#line 16 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
         foreach (IdentityRole<long> role in Model.AllRoles)
        {

#line default
#line hidden
                BeginContext(392, 47, true);
                WriteLiteral("            <input type=\"checkbox\" name=\"roles\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 439, "\"", 457, 1);
#line 18 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
WriteAttributeValue("", 447, role.Name, 447, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(458, 21, true);
                WriteLiteral("\r\n                   ");
                EndContext();
                BeginContext(481, 64, false);
#line 19 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
               Write(Model.UserRoles.Contains(role.Name) ? "checked=\"checked\"" : "");

#line default
#line hidden
                EndContext();
                BeginContext(546, 3, true);
                WriteLiteral(" />");
                EndContext();
                BeginContext(550, 9, false);
#line 19 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
                                                                                    Write(role.Name);

#line default
#line hidden
                EndContext();
                BeginContext(559, 9, true);
                WriteLiteral(" <br />\r\n");
                EndContext();
#line 20 "D:\Projects\проект по авпз\TWHelp\Views\Roles\Edit.cshtml"
            }

#line default
#line hidden
                BeginContext(583, 77, true);
                WriteLiteral("    </div>\r\n    <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWHelp.Models.ChangeRoleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
