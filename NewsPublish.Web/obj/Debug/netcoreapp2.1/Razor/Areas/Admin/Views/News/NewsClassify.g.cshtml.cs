#pragma checksum "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "438fcd5f8c74bc749f4d921ab1ff6f2c3e717a99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_News_NewsClassify), @"mvc.1.0.view", @"/Areas/Admin/Views/News/NewsClassify.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/News/NewsClassify.cshtml", typeof(AspNetCore.Areas_Admin_Views_News_NewsClassify))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438fcd5f8c74bc749f4d921ab1ff6f2c3e717a99", @"/Areas/Admin/Views/News/NewsClassify.cshtml")]
    public class Areas_Admin_Views_News_NewsClassify : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewsPublish.Model.Response.ResponseModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
  
    ViewData["Title"] = "NewsClassify";

#line default
#line hidden
            BeginContext(99, 25, true);
            WriteLiteral("<!DOCTYPE HTML>\r\n<html>\r\n");
            EndContext();
            BeginContext(124, 1013, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0686d6cd729d4fffa48763d2686cdbd0", async() => {
                BeginContext(130, 1000, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""renderer"" content=""webkit|ie-comp|ie-stand"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width,initial-scale=1,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no"" />
    <meta http-equiv=""Cache-Control"" content=""no-siteapp"" />
    <!--[if lt IE 9]>
    <script type=""text/javascript"" src=""/admin/js/html5.js""></script>
    <script type=""text/javascript"" src=""/admin/js/respond.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/PIE_IE678.js""></script>
    <![endif]-->
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/css/H-ui.css"" />
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/css/H-ui.admin.css"" />
    <link type=""text/css"" rel=""stylesheet"" href=""/admin/font/font-awesome.min.css"" />
    <!--[if IE 7]>
    <link href=""/admin/font/font-awesome-ie7.min.css"" rel=""stylesheet"" type=""text/css"" />
    <![endif]-->
    <title>新闻类别</title>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1137, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1139, 2644, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93868dd1330d475685973a0e1cb34d80", async() => {
                BeginContext(1145, 1133, true);
                WriteLiteral(@"
    <nav class=""Hui-breadcrumb""><i class=""icon-home""></i> 首页 <span class=""c-gray en"">&gt;</span> 新闻中心 <span class=""c-gray en"">&gt;</span> 新闻类别 <a class=""btn btn-success radius r mr-20"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""icon-refresh""></i></a></nav>
    <div class=""pd-20"">
        <div class=""cl pd-5 bg-1 bk-gray mt-20"">
            <span class=""l""><a href=""javascript:;"" onClick=""user_add('550','300','添加新闻类别','/Admin/News/NewsClassifyAdd')"" class=""btn btn-primary radius""><i class=""icon-plus""></i> 添加新闻类别</a></span>

        </div>

        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""80"">ID</th>
                    <th width=""200"">类别名称</th>
                    <th width=""90"">排序</th>
                    <th>备注</th>
  ");
                WriteLiteral("                  <th width=\"100\">操作</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
                EndContext();
#line 47 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
                 if (Model.code == 200)
                {
                    foreach (var m in Model.data)
                    {

#line default
#line hidden
                BeginContext(2412, 99, true);
                WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td><input type=\"checkbox\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2511, "\"", 2524, 1);
#line 52 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
WriteAttributeValue("", 2519, m.Id, 2519, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2525, 48, true);
                WriteLiteral(" name=\"\"></td>\r\n                            <td>");
                EndContext();
                BeginContext(2574, 4, false);
#line 53 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
                           Write(m.Id);

#line default
#line hidden
                EndContext();
                BeginContext(2578, 39, true);
                WriteLiteral("</td>\r\n                            <td>");
                EndContext();
                BeginContext(2618, 6, false);
#line 54 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
                           Write(m.Name);

#line default
#line hidden
                EndContext();
                BeginContext(2624, 39, true);
                WriteLiteral("</td>\r\n                            <td>");
                EndContext();
                BeginContext(2664, 6, false);
#line 55 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
                           Write(m.Sort);

#line default
#line hidden
                EndContext();
                BeginContext(2670, 39, true);
                WriteLiteral("</td>\r\n                            <td>");
                EndContext();
                BeginContext(2710, 8, false);
#line 56 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
                           Write(m.Remark);

#line default
#line hidden
                EndContext();
                BeginContext(2718, 72, true);
                WriteLiteral("</td>\r\n                            <td><a title=\"编辑\" href=\"javascript:;\"");
                EndContext();
                BeginWriteAttribute("onClick", " onClick=\"", 2790, "\"", 2872, 3);
                WriteAttributeValue("", 2800, "user_edit(\'4\',\'550\',\'300\',\'编辑\',\'/Admin/News/NewsClassifyEdit?ID=\'+", 2800, 66, true);
#line 57 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
WriteAttributeValue("", 2866, m.Id, 2866, 5, false);

#line default
#line hidden
                WriteAttributeValue("", 2871, ")", 2871, 1, true);
                EndWriteAttribute();
                BeginContext(2873, 110, true);
                WriteLiteral(" class=\"ml-5\" style=\"text-decoration:none\"><i class=\"icon-edit\"></i></a></td>\r\n                        </tr>\r\n");
                EndContext();
#line 59 "D:\project\2019\网易云课堂\NewsPublish\NewsPublish.Web\Areas\Admin\Views\News\NewsClassify.cshtml"
                    }
                }

#line default
#line hidden
                BeginContext(3025, 751, true);
                WriteLiteral(@"
            </tbody>
        </table>
    </div>
    <script type=""text/javascript"" src=""/admin/js/jquery.min.js""></script>
    <script type=""text/javascript"" src=""/admin/layer/layer.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/pagenav.cn.js""></script>
    <script type=""text/javascript"" src=""/admin/js/H-ui.js""></script>
    <script type=""text/javascript"" src=""/admin/plugin/My97DatePicker/WdatePicker.js""></script>
    <script type=""text/javascript"" src=""/admin/js/jquery.dataTables.min.js""></script>
    <script type=""text/javascript"" src=""/admin/js/H-ui.admin.js""></script>
    <script type=""text/javascript"">
        function reload() {
            location.replace(location.href);
        }
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3783, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewsPublish.Model.Response.ResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591