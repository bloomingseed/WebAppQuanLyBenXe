#pragma checksum "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66dc0c51559f80fd073d5ed6aaa49a08a3dc0a3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QTV1_LsVaoRa), @"mvc.1.0.view", @"/Views/QTV1/LsVaoRa.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/QTV1/LsVaoRa.cshtml", typeof(AspNetCore.Views_QTV1_LsVaoRa))]
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
#line 1 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\_ViewImports.cshtml"
using QuanLyBenXeWebApp;

#line default
#line hidden
#line 2 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\_ViewImports.cshtml"
using QuanLyBenXeWebApp.Models;

#line default
#line hidden
#line 3 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66dc0c51559f80fd073d5ed6aaa49a08a3dc0a3a", @"/Views/QTV1/LsVaoRa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a743be3cae5d0a00d61f43ba3e212f472d72e39", @"/Views/_ViewImports.cshtml")]
    public class Views_QTV1_LsVaoRa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LichSuVaoRa[]>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
  
    Layout = "~/Views/Qtv1/_Qtv1Layout.cshtml";
    ViewData["Title"] = "LSVaoRa";

#line default
#line hidden
            BeginContext(114, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(121, 17, false);
#line 7 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(138, 27, true);
            WriteLiteral("</h1>\r\n<div class=\"\">\r\n    ");
            EndContext();
            BeginContext(165, 2084, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66dc0c51559f80fd073d5ed6aaa49a08a3dc0a3a4316", async() => {
                BeginContext(185, 565, true);
                WriteLiteral(@"
        <div class=""text-danger validation-summary""></div>
        <div class=""input-group"">
            <table id=""data-grid"" class=""table-bordered"">
                <thead>
                    <tr>
                        <th scope=""col"">Số thứ tự</th>
                        <th scope=""col"">Mã xe khách</th>
                        <th scope=""col"">Mã vị trí</th>
                        <th scope=""col"">Vào bến</th>
                        <th scope=""col"">Thời điểm</th>
                    </tr>
                </thead>
                <tbody>
");
                EndContext();
#line 23 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
                     foreach (LichSuVaoRa lichSuVaoRa in Model)
                    {

#line default
#line hidden
                BeginContext(838, 122, true);
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                <input readonly typ=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 960, "\"", 985, 2);
#line 27 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 968, lichSuVaoRa.Stt, 968, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 984, ",", 984, 1, true);
                EndWriteAttribute();
                BeginContext(986, 63, true);
                WriteLiteral(" />\r\n                                <input readonly typ=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1049, "\"", 1080, 2);
#line 28 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 1057, lichSuVaoRa.MaXeKhach, 1057, 22, false);

#line default
#line hidden
                WriteAttributeValue("", 1079, ",", 1079, 1, true);
                EndWriteAttribute();
                BeginContext(1081, 63, true);
                WriteLiteral(" />\r\n                                <input readonly typ=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1144, "\"", 1173, 2);
#line 29 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 1152, lichSuVaoRa.MaViTri, 1152, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1172, ",", 1172, 1, true);
                EndWriteAttribute();
                BeginContext(1174, 63, true);
                WriteLiteral(" />\r\n                                <input readonly typ=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1237, "\"", 1265, 2);
#line 30 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 1245, lichSuVaoRa.VaoBen, 1245, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1264, ",", 1264, 1, true);
                EndWriteAttribute();
                BeginContext(1266, 63, true);
                WriteLiteral(" />\r\n                                <input readonly typ=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1329, "\"", 1359, 2);
#line 31 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 1337, lichSuVaoRa.ThoiDiem, 1337, 21, false);

#line default
#line hidden
                WriteAttributeValue("", 1358, ",", 1358, 1, true);
                EndWriteAttribute();
                BeginContext(1360, 100, true);
                WriteLiteral(" />\r\n                            </td>\r\n                            <td><input type=\"datetime-local\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1460, "\"", 1510, 1);
#line 33 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 1468, DateTime.Now.ToString("yyyy-MM-ddThh:mm"), 1468, 42, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1511, 41, true);
                WriteLiteral(" /></td>\r\n                        </tr>\r\n");
                EndContext();
#line 35 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
                    }

#line default
#line hidden
                BeginContext(1575, 73, true);
                WriteLiteral("                <tr>\r\n                    <td><input readonly type=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1648, "\"", 1672, 1);
#line 37 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 1656, ViewBag.NextStt, 1656, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1673, 293, true);
                WriteLiteral(@" /></td>
                    <td><input readonly type=""text"" value="""" /></td>
                    <td><input readonly type=""text"" value="""" /></td>
                    <td><input readonly type=""checkbox"" checked /></td>
                    <td><input readonly disabled type=""datetime-local""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1966, "\"", 2016, 1);
#line 41 "D:\code\WebAppQuanLyBenXe\QuanLyBenXeWebApp\Views\QTV1\LsVaoRa.cshtml"
WriteAttributeValue("", 1974, DateTime.Now.ToString("yyyy-MM-ddThh:mm"), 1974, 42, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2017, 225, true);
                WriteLiteral(" /></td>\r\n                </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"input-group\">\r\n            <button type=\"button\" id=\"create-lsvr\">Tạo mới</button>\r\n        </div>\r\n      \r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2249, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LichSuVaoRa[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
