#pragma checksum "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5d2c995543c147d8f607cf92d8739f3ef76cc31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorCollege.Pages.Students.Pages_Students_Details), @"mvc.1.0.razor-page", @"/Pages/Students/Details.cshtml")]
namespace RazorCollege.Pages.Students
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
#line 1 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\_ViewImports.cshtml"
using RazorCollege;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id:int?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5d2c995543c147d8f607cf92d8739f3ef76cc31", @"/Pages/Students/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4360e7301fb390d46a2736032da1849b9258121c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Students_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
  
    ViewData["Title"] = "Details";
    string sortP =  String.IsNullOrEmpty(Model.SortParam) ? "?sortOrder=LastName" : "?sortOrder=" + Model.SortParam;
    sortP = sortP + "&pageIndex=" + Model.DisplayedPageNo;
    sortP = String.IsNullOrEmpty(Model.CurrentFilter) ? sortP : sortP + "&currentFilter=" + Model.CurrentFilter;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n<h5>URL = ");
#nullable restore
#line 12 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
     Write(Request.Path);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                  Write(sortP);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>currentFilter = ");
#nullable restore
#line 13 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
               Write(Model.CurrentFilter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h5>sortP = ");
#nullable restore
#line 14 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(sortP);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n<div>\r\n    <h4>Student with ID = ");
#nullable restore
#line 17 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                     Write(Model.Student.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.FirstMidName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.FirstMidName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.EnrollmentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.EnrollmentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <!-- added to display enrollment model\'s course and grade properties-->\r\n    <dt class=\"col-sm-2\">\r\n            Class ");
#nullable restore
#line 47 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
             Write(Html.DisplayNameFor(model => model.Student.Enrollments));

#line default
#line hidden
#nullable disable
            WriteLiteral(": Count = ");
#nullable restore
#line 47 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                                                                               Write(Model.Student.Enrollments.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        <table class=\"table\">\r\n            <tr>\r\n                <th>Course Title</th>\r\n                <th>Grade</th>\r\n            </tr>\r\n");
#nullable restore
#line 55 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
             foreach (var item in Model.Student.Enrollments.OrderBy(i => i.Course.CourseYear).ThenBy(j => j.Course.CourseSemester))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Course.CourseYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Course.CourseSemester));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Course.CourseNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Course.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Grade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 74 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </dd>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5d2c995543c147d8f607cf92d8739f3ef76cc3111989", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
                           WriteLiteral(Model.Student.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n");
#nullable restore
#line 80 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
      string addressE = "/Students/Edit/" + Model.Student.ID; 
    addressE = addressE + sortP;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a");
            BeginWriteAttribute("href", " href=", 3015, "", 3030, 1);
#nullable restore
#line 83 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
WriteAttributeValue("", 3021, addressE, 3021, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <input type=\"button\" value=\"EditSort\">\r\n    </a>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5d2c995543c147d8f607cf92d8739f3ef76cc3114932", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <!-- TO GET A model field RECOGNIZED, MUST ADD IT TO THE HREF ADDRESS-->\r\n");
#nullable restore
#line 88 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
      
    string addressER = "/Students" + sortP;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a");
            BeginWriteAttribute("href", " href=", 3279, "", 3295, 1);
#nullable restore
#line 91 "I:\Visual Studio Code\ASPNETCore\Chapter04\RazorEFCCollege\RazorCollege\Pages\Students\Details.cshtml"
WriteAttributeValue("", 3285, addressER, 3285, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <input type=\"button\" value=\"Back with Sort\">\r\n    </a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorCollege.Pages.Students.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorCollege.Pages.Students.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorCollege.Pages.Students.DetailsModel>)PageContext?.ViewData;
        public RazorCollege.Pages.Students.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
