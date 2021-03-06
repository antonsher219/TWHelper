#pragma checksum "D:\Projects\TWHelp\TWHelp\Areas\Analytics\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ada033bcfb36ea8bf38b3e564f07fb38ac71a6a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Analytics_Pages_Index), @"mvc.1.0.razor-page", @"/Areas/Analytics/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Analytics/Pages/Index.cshtml", typeof(AspNetCore.Areas_Analytics_Pages_Index), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ada033bcfb36ea8bf38b3e564f07fb38ac71a6a4", @"/Areas/Analytics/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a20b261fee6531cbb6326723e79904e255f25699", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Analytics_Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("createPredictionRequest(event);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(62, 379, true);
            WriteLiteral(@"

<div class=""container-fluid"">
    <div class=""row d-flex flex-column"">
        <div class=""col-12 mt-4 text-center"">
            <h3>Analytics</h3>
        </div>

        <div class=""col-12 col-sm-11 col-md-9 mx-auto"">
            <div class=""m-4 p-3"" style=""background-color: lightcyan; border-radius: 5px"">
                <h5>Twitter nick</h5>

                ");
            EndContext();
            BeginContext(441, 603, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ada033bcfb36ea8bf38b3e564f07fb38ac71a6a44217", async() => {
                BeginContext(490, 547, true);
                WriteLiteral(@"
                    <div class=""d-flex flex-row flex-wrap justify-content-between"">
                        <div class=""col-12 col-lg-9 p-0"">
                            <input type=""text"" class=""form-control mb-2"" id=""inlineFormInput"" placeholder=""Jane_Doe"">
                        </div>
                        <div class=""col-12 col-lg-2 p-0"">
                            <button type=""submit"" class=""btn btn-primary mb-2"" id=""submit-button"">Submit</button>
                        </div>
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1044, 2940, true);
            WriteLiteral(@"
                    
            </div>
        </div>

        <div class=""col-12 col-sm-11 col-md-9 mx-auto"">
            <div class=""mx-4 my-2 p-3"" style=""background-color: lightcyan; border-radius: 5px"">
                <h5>Result</h5>

                <p>Status: <span id=""analysis-status""></span></p>

                <div id=""analysis-area"">
                    <div class=""m-1 p-1"">
                        <h6 class=""m-0"">Twitter account analysis</h6>
                        <div>
                            <div>
                                <p>Top negative words:</p>
                                <div id=""analysis-negative-words"">

                                </div>
                            </div>
                            <div>
                                <p>Top positive words:</p>
                                <div id=""analysis-positive-words"">

                                </div>
                            </div>
                        </div>
   ");
            WriteLiteral(@"                 </div>
                    <div class=""m-1 p-2"">
                        <h6 class=""my-1"">Tweets analysis</h6>
                        <div id=""analysis-tweets"">
                            <div>
                                <p class=""font-weight-bold"">Best tweet: <span style=""font-weight: 400"" id=""analysis-best-tweet-text""></span></p>
                            </div>
                            <div class=""d-flex justify-content-between"">
                                <p class=""font-weight-bold"">Date: <span style=""font-weight: 400"" id=""analysis-best-tweet-date""></span></p>
                                <p class=""font-weight-bold"">Rating: <span style=""font-weight: 400"" id=""analysis-best-tweet-rating""></span></p>
                            </div>

                            <div>
                                <p class=""font-weight-bold"">Worst tweet: <span style=""font-weight: 400"" id=""analysis-worst-tweet-text""></span></p>
                            </div>
         ");
            WriteLiteral(@"                   <div class=""d-flex justify-content-between"">
                                <p class=""font-weight-bold"">Date: <span style=""font-weight: 400"" id=""analysis-worst-tweet-date""></span></p>
                                <p class=""font-weight-bold"">Rating: <span style=""font-weight: 400"" id=""analysis-worst-tweet-rating""></span></p>
                            </div>
                        </div>
                    </div>

                    <div class=""d-flex flex-column"" id=""analysis-images"">
                        <img src=""#"" id=""analysis-activity-img"" style=""display: none;"" />
                        <img src=""#"" id=""analysis-piechart-img"" style=""display: none;"" />
                    </div>

                    <div id=""analysis-date"">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            BeginContext(4006, 5558, true);
            WriteLiteral(@"<script>
    let socket = new WebSocket(""ws://localhost:5000"");
    let twitter_analytic_data = {

    }

    socket.onopen = function (e) {
        console.log(""opened"");
    };

    socket.onmessage = function (event) {
        _displaySocketData(event.data);
    };

    socket.onclose = function(event) {
       if (event.wasClean) {
           console.log(""closed"");
       } else {
           console.log(""error closed"");
       }
    };

    socket.onerror = function (error) {
        console.log(""error"");
    };

    async function createPredictionRequest() {
        event.preventDefault();

        let twitter_nick = document.getElementById('inlineFormInput').value;
        if (twitter_nick == null || twitter_nick == '') {
            return;
        }

        //check for already existed statistic
        let response = await fetch('http://localhost:44392/api/prediction/get/' + twitter_nick);

        if (response.ok) {
            let json = await response.json();");
            WriteLiteral(@"
            _displaySocketData(json)

            return;
        }
        else {
            console.log(""analytics not found"");
        }

        _clearData();

        let data = {
            twitter_nick: twitter_nick,
            count: 200
        }

        if (socket.readyState == socket.OPEN) {
            socket.send(JSON.stringify(data))
        }
        else {
            console.log(""socket already closed"");
        }
    }

    function _clearData() {
        document.getElementById('analysis-negative-words').innerHTML = '';
        document.getElementById('analysis-positive-words').innerHTML = '';

        document.getElementById('analysis-best-tweet-text').innerHTML = '';
        document.getElementById('analysis-best-tweet-date').innerHTML = '';
        document.getElementById('analysis-best-tweet-rating').innerHTML = '';
        document.getElementById('analysis-worst-tweet-text').innerHTML = '';
        document.getElementById('analysis-worst-tweet-date')");
            WriteLiteral(@".innerHTML = '';
        document.getElementById('analysis-worst-tweet-rating').innerHTML = '';

        document.getElementById('analysis-date').innerHTML = '';
        document.getElementById('analysis-status').innerHTML = '';
        document.getElementById('analysis-activity-img').style.display = 'none';
        document.getElementById('analysis-piechart-img').style.display = 'none';
    }

    function _displaySocketData(data) {
        //console.log(data);
        data = JSON.parse(data);

        if (data.type == ""status"") {
            document.getElementById('analysis-status').innerHTML = data.message;
            document.getElementById('analysis-status').style.color = ""green"";
            document.getElementById('analysis-status').style.fontWeight = ""bold"";

            if (data.data_type == ""done"") {
                document.getElementById('analysis-status').innerHTML = ""done"";
                document.getElementById('analysis-activity-img').style.display = 'block';
          ");
            WriteLiteral(@"      document.getElementById('analysis-activity-img').src = ""/output/activity_"" + data.message + "".png"";

                document.getElementById('analysis-piechart-img').style.display = 'block';
                document.getElementById('analysis-piechart-img').src = ""/output/piechart_"" + data.message + "".png"";
            }
        }
        else if (data.type == ""data"") {
            message = JSON.parse(data.message);

            if (data.data_type == ""top_negative_words"") {
                html = """"

                for (i = 0; i < message.length; i++) {
                     html += ""<div class='d-flex justify-content-around'><p>Term: "" + message[i].term + ""</p><p>Count: "" + message[i].count + ""</p><p>Rate: "" + message[i].rate + ""</p></div>"";
                }

                document.getElementById('analysis-negative-words').innerHTML = html
            }
            else if (data.data_type == ""top_positive_words"") {
                html = """"

                for (i = 0; i < messag");
            WriteLiteral(@"e.length; i++) {
                     html += ""<div class='d-flex justify-content-around'><p>Term: "" + message[i].term + ""</p><p>Count: "" + message[i].count + ""</p><p>Rate: "" + message[i].rate + ""</p></div>"";
                }

                document.getElementById('analysis-positive-words').innerHTML = html
            }
            else if (data.data_type == ""top_negative_tweet"") {
                document.getElementById('analysis-worst-tweet-text').innerHTML = message.text;
                document.getElementById('analysis-worst-tweet-date').innerHTML = message.date;
                document.getElementById('analysis-worst-tweet-rating').innerHTML = message.prediction;
            }
            else if (data.data_type == ""top_positive_tweet"") {
                document.getElementById('analysis-best-tweet-text').innerHTML = message.text;
                document.getElementById('analysis-best-tweet-date').innerHTML = message.date;
                document.getElementById('analysis-best-tweet-ra");
            WriteLiteral(@"ting').innerHTML = message.prediction;
            }
        }
        else if (data.type == ""error"") {
            document.getElementById('analysis-status').innerHTML = ""we are deeply sorry for that, but something went wrong. try again"";
            document.getElementById('analysis-status').style.color = ""red"";
            document.getElementById('analysis-status').style.fontWeight = ""normal"";
        }
    }
</script>

");
            EndContext();
            BeginContext(9584, 1448, true);
            WriteLiteral(@"<script>
    async function _createPredictionRequest() {
        event.preventDefault();

        let twitter_nick = document.getElementById('inlineFormInput').value;

        if (twitter_nick == null || twitter_nick == '') {
            return;
        }

        //block form to enter new data
        document.getElementById('inlineFormInput').disabled = true;
        document.getElementById('submit-button').disabled = true;

        await fetch('http://localhost:44392/api/prediction/create/' + twitter_nick + '/200')
            .then(response => response.json())
            .then(data => _displayData(data))
            .catch(error => console.error('Unable to get items.', error));

        document.getElementById('inlineFormInput').disabled = false;
        document.getElementById('submit-button').disabled = false;
    }

    function _displayData(data) {
        console.log(data);

        document.getElementById('analysis-activity-img').src = data.activityChartPath;
        docu");
            WriteLiteral(@"ment.getElementById('analysis-piechart-img').src = data.pieChartPath;

        document.getElementById('analysis-statistic').innerHTML =
            '<div><p>Good emotional rate: ' + data.goodEmotionRate + '</p></div>'
            + '<div><p>Bad emotional rate: ' + data.badEmotionRate + '</p></div>'

        document.getElementById('analysis-date').innerHTML = '<p>' + data.lastModified + '</p>';
    }
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWHelp.Areas.Analytics.Pages.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Analytics.Pages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TWHelp.Areas.Analytics.Pages.IndexModel>)PageContext?.ViewData;
        public TWHelp.Areas.Analytics.Pages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
