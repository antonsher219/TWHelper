#pragma checksum "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Psychologists\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a724f1aa4b3e32b77792fca58a84ae6188ac593"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Profiles_Pages_Psychologists_Index), @"mvc.1.0.razor-page", @"/Areas/Profiles/Pages/Psychologists/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Profiles/Pages/Psychologists/Index.cshtml", typeof(AspNetCore.Areas_Profiles_Pages_Psychologists_Index), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a724f1aa4b3e32b77792fca58a84ae6188ac593", @"/Areas/Profiles/Pages/Psychologists/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a20b261fee6531cbb6326723e79904e255f25699", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Profiles_Pages_Psychologists_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex justify-content-between"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("searchForPsycoProfiles(event)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(68, 387, true);
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row d-flex flex-column"">
        <div class=""mx-auto"">
            <h2 class=""text-center"">Psychologists page</h2>
        </div>

        <div class=""col-12 col-sm-11 col-md-10 mx-auto my-3"">
            <div class=""mx-3"">
                <label for=""search"">Psychologist name and surname</label>
            </div>
            ");
            EndContext();
            BeginContext(455, 637, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a724f1aa4b3e32b77792fca58a84ae6188ac5935034", async() => {
                BeginContext(558, 208, true);
                WriteLiteral("\r\n                <div class=\"col-9\">\r\n                    <input type=\"text\" class=\"form-control\" id=\"search-text\" placeholder=\"John Johnson\" list=\"psychoResults\" oninput=\"autocompleteForPsychoProfiles()\">\r\n");
                EndContext();
                BeginContext(816, 269, true);
                WriteLiteral(@"                    <datalist id=""psychoResults"">
                    </datalist>
                </div>
                <div class=""col-3"">
                    <button type=""submit"" class=""btn btn-primary mb-2"">Search</button>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1092, 225, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-12 col-sm-11 col-md-10 mx-auto\">\r\n            <p class=\"font-weight-bold text-center\">List of psychologists</p>\r\n            <div class=\"d-flex flex-column\" id=\"psycho-container\">\r\n");
            EndContext();
            BeginContext(1365, 2938, true);
            WriteLiteral(@"            </div>

            <div>
                <nav aria-label=""Page navigation example"">
                    <ul class=""pagination"">
                        <li class=""page-item""><a class=""page-link"" href=""#"" onclick=""changeCurrentPsychoPage('previous')"">Previous</a></li>
                        <li class=""page-item""><a class=""page-link"" href=""#"" onclick=""changeCurrentPsychoPage('1')"">1</a></li>
                        <li class=""page-item""><a class=""page-link"" href=""#"" onclick=""changeCurrentPsychoPage('2')"">2</a></li>
                        <li class=""page-item""><a class=""page-link"" href=""#"" onclick=""changeCurrentPsychoPage('3')"">3</a></li>
                        <li class=""page-item""><a class=""page-link"" href=""#"" onclick=""changeCurrentPsychoPage('next')"">Next</a></li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>
</div>

<template id=""template"">
    <div id=""psycho-div"" class=""m-2 p-2"" style=""background-color: #fafafa"">
        <di");
            WriteLiteral(@"v class=""d-flex flex-column flex-md-row "">
            <div>
                <div>
                    <img id=""psycho-image"" src="""" alt=""profile-image"" class=""m-3 rounded-circle"" style=""border: 1px solid black;"" width=""200"" height=""200"">
                </div>
            </div>
            <div class=""d-flex flex-column flex-md-row flex-md-wrap flex-lg-nowrap"">
                <div class=""m-3"">
                    <p>Name: <span id=""psycho-name""></span></p>
                    <p>Age: <span id=""psycho-age""></span></p>
                    <p>Is psycho confirm his degree: <span id=""psycho-confirm""></span></p>
                </div>
                <div class=""m-3"">
                    <div class=""d-flex"">
                        <p class=""m-1"">Psycho degree:</p>
                        <p class=""m-1"" id=""psycho-degree""></p>
                    </div>
                    <div class=""d-flex"">
                        <p class=""m-1"">Area of experetise:</p>
                        <p class=""m-1""");
            WriteLiteral(@" id=""psycho-expertise-area""></p>
                    </div>
                    <div class=""d-flex"">
                        <p class=""m-1"">Psycho work experience:</p>
                        <p class=""m-1"" id=""psycho-experience""></p>
                    </div>
                </div>
            </div>
        </div>

        <div>
            <div>
                <p>Number of likes: <span id=""psycho-likes""></span></p>
            </div>
            <div id=""psycho-like"">
                <i id=""psycho-like-like"" class=""far fa-heart"" style=""color: red; font-size: 20px;""></i>
            </div>
        </div>
    </div>
</template>

<style>
    #psycho-like-like {
        transition: all 0.2s ease-in-out; 
    }

    #psycho-like-like:hover {
        transform: scale(1.5, 1.5);
        color: orange;
    }
</style>

<script>
    const webRoot = '");
            EndContext();
            BeginContext(4304, 13, false);
#line 102 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Psychologists\Index.cshtml"
                Write(Model.WebRoot);

#line default
#line hidden
            EndContext();
            BeginContext(4317, 26, true);
            WriteLiteral("\';\r\n    const isPsycho = \'");
            EndContext();
            BeginContext(4344, 18, false);
#line 103 "D:\Projects\TWHelp\TWHelp\Areas\Profiles\Pages\Psychologists\Index.cshtml"
                 Write(Model.IsUserPsycho);

#line default
#line hidden
            EndContext();
            BeginContext(4362, 7207, true);
            WriteLiteral(@"';

    window.onload = function () {
        getPsychosProfiles();
    }

    //send to elastic search
    async function searchForPsycoProfiles(event) {
        event.preventDefault();

        let text = document.getElementById('search-text').value;

        if (text == '' || text == null || text == undefined) {
            document.getElementById('search-text').placeholder = 'field is empty';

            document.getElementById('search-text').classList.remove('gray-placeholder');
            document.getElementById('search-text').classList.add('red-placeholder');

            getPsychosProfiles();

            return;
        }

        document.getElementById('search-text').classList.remove('red-placeholder');
        document.getElementById('search-text').classList.add('gray-placeholder');

        await fetch(webRoot + '/api/search/full/psychologist/' + text, {
                method: 'GET'
            })
            .then(response => response.json())
            .then(da");
            WriteLiteral(@"ta => _displayElasticItems(data))
            .catch(error => console.error('Unable to get items.', error));
    }

    async function autocompleteForPsychoProfiles() {
        let text = document.getElementById('search-text').value;

        if (text == '' || text == null || text == undefined) {
            return;
        }

        await fetch(webRoot + '/api/search/autocomplete/psychologist/' + text, {
                method: 'GET'
            })
            .then(response => response.json())
            .then(data => _displayAutocomplete(data))
            .catch(error => console.error('Unable to get items.', error));
    }

    function changeCurrentPsychoPage(button) {
        if (button == 'previous') {
            currentPsychoPage -= 10;

            if (currentPsychoPage < 0) {
                currentPsychoPage = 0;
            }
        }
        else if (button == '1') {
            currentPsychoPage = 0;
        }
        else if (button == '2') {
            curre");
            WriteLiteral(@"ntPsychoPage = 11;
        }
        else if (button == '3') {
            currentPsychoPage = 21;
        }
        else if (button == 'next') {
            currentPsychoPage += 10;
        }

        getPsychosProfiles();
    }

    let currentPsychoPage = 0;
    async function getPsychosProfiles() {

        await fetch(webRoot + '/api/psychologists/part/' + currentPsychoPage + '/' + (currentPsychoPage + 10))
            .then(response => response.json())
            .then(data => _displayItems(data))
            .catch(error => console.error('Unable to get items.', error));
    }

    function addLikeToProfile(psychoId) {
        if (!isPsycho) {
            return;
        }

        fetch(webRoot + '/api/likes/add/' + psychoId, {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            }
        })
        .catch(error => console.error('Unable to add like.', error));
    }");
            WriteLiteral(@"

    function removeLikeFromProfile(psychoId) {
        if (!isPsycho) {
            return;
        }

        fetch(webRoot + '/api/likes/remove/' + psychoId, {
            method: 'DELETE',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            }
        })
        .catch(error => console.error('Unable to add like.', error));
    }

    function _displayElasticItems(data) {
        let items = [];
        data.hits.hits.forEach(item => {
            items.push({
                id: item._source.id,
                nickName: item._source.nickName,
                education: item._source.education,
                areaOfExpertise: item._source.areaOfExpertise,
                isAccountActivated: item._source.isAccountActivated,
                avatarImage: null,
            })
        })

        _displayItems(items);
    }

    function _displayAutocomplete(data) {
        let input = document.getElem");
            WriteLiteral(@"entById('psychoResults');
        input.innerHTML = """";

        data.hits.hits.forEach(item => {
            let option = document.createElement('option');
            option.value = item._source.nickName;
            input.append(option);
        })
    }

    function _displayItems(data) {
        const container = document.getElementById('psycho-container');
        container.innerHTML = '';

        data.forEach(item => {
            let newDiv = document.importNode(template.content, true);

            newDiv.getElementById('psycho-name').textContent = item.nickName;
            newDiv.getElementById('psycho-image').src = item.avatarImage == null ? ""/images/user-profile.png"" : ""data:image/png;base64,"" + item.avatarImage;
            newDiv.getElementById('psycho-age').textContent = item.age;
            newDiv.getElementById('psycho-degree').textContent = item.education;
            newDiv.getElementById('psycho-expertise-area').textContent = item.areaOfExpertise;
            newDi");
            WriteLiteral(@"v.getElementById('psycho-experience').textContent = item.workExperience;
            newDiv.getElementById('psycho-likes').textContent = item.likes;

            if (item.isAccountActivated == 'true') {
                newDiv.getElementById('psycho-confirm').textContent = 'yes';
            }
            else {
                newDiv.getElementById('psycho-confirm').textContent = 'no';
            }

            if (item.isCurrentUserSetLike) {
                newDiv.getElementById('psycho-like').innerHTML = '<i id=""psycho-like-like"" class=""fas fa-heart"" style=""color: red; font-size: 20px;""></i>';
            }

            //add event listener for click on like
            newDiv.getElementById('psycho-like-like').addEventListener('click', function (element) {
                let container = document.getElementById('psycho-' + item.id);

                //there is already like
                if (element.target.classList.contains('fas')) {
                    removeLikeFromProfile(item.id");
            WriteLiteral(@");

                    container.querySelector('#psycho-like-like').classList.add('far');
                    container.querySelector('#psycho-like-like').classList.remove('fas');

                    let likes = parseInt(container.querySelector('#psycho-likes').innerHTML);
                    container.querySelector('#psycho-likes').innerHTML = likes - 1;
                }
                else {
                    addLikeToProfile(item.id);

                    container.querySelector('#psycho-like-like').classList.add('fas');
                    container.querySelector('#psycho-like-like').classList.remove('far');

                    let likes = parseInt(container.querySelector('#psycho-likes').innerHTML);
                    container.querySelector('#psycho-likes').innerHTML = likes + 1;
                }
            });

            //to get access to element
            newDiv.getElementById('psycho-div').setAttribute('id', 'psycho-' + item.id);

            container.append(newD");
            WriteLiteral("iv);\r\n        });\r\n    }\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWHelp.Areas.Profiles.Pages.Psychologists.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Profiles.Pages.Psychologists.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Profiles.Pages.Psychologists.IndexModel>)PageContext?.ViewData;
        public TWHelp.Areas.Profiles.Pages.Psychologists.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
