#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65c3e1655089e067319012bf29e4c3284832941c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CustomerIndex), @"mvc.1.0.view", @"/Views/Home/CustomerIndex.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\_ViewImports.cshtml"
using WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\_ViewImports.cshtml"
using Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\_ViewImports.cshtml"
using Entities.Dto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65c3e1655089e067319012bf29e4c3284832941c", @"/Views/Home/CustomerIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CustomerIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CustomerIndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
  
    ViewData["Title"] = "CustomerIndex";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div id=\"content\">\r\n    <section id=\"widget-grid\"");
            BeginWriteAttribute("class", " class=\"", 135, "\"", 143, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <!-- row -->
        <div class=""row"">
            <!-- NEW WIDGET START -->

            <article class=""col-sm-12 col-md-12 col-lg-12"">
                <div class=""jarviswidget"" id=""wid-id-4"">

                    <div>
                        <div class=""jarviswidget-editbox"">
                        </div>
                        <div class=""widget-body"">
                            <ul id=""myTab1"" class=""nav nav-tabs bordered"">
                                <li class=""active"">
                                    <a href=""#s1"" data-toggle=""tab""><i class=""fa fa-fw fa-lg fa-pencil""></i>Yeni Açılan Kayıtlarım</a>
                                </li>
                                <li>
                                    <a href=""#s2"" data-toggle=""tab""><i class=""fa fa-fw fa-lg fa-pencil""></i>Cevap Bekleyen Kayıtlar</a>
                                </li>
                            </ul>

                            <div id=""myTabContent1"" class=""tab-content padding-10"">
");
            WriteLiteral(@"                                <div class=""tab-pane fade in active"" id=""s1"">

                                    <div class=""row"">
                                        <article class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                                            <div class=""jarviswidget jarviswidget-color-blueDark"" id=""wid-id-1"" 
                                                 data-widget-editbutton=""false"" data-widget-deletebutton=""false"" 
                                                 data-widget-togglebutton=""false"" data-widget-sortable=""false"">
                                                <header>
                                                    <span class=""widget-icon""> <i class=""fa fa-table""></i> </span>
                                                    <h2>Yeni Açılan Kayıtlarım</h2>

                                                </header>

                                                <div>
                                                    <div class=""jarvis");
            WriteLiteral(@"widget-editbox"">
                                                    </div>
                                                    <div class=""widget-body no-padding"">
                                                        <table id=""dtDataSheetList"" class=""table table-striped table-bordered"" width=""100%"">
                                                            <thead>
                                                                <tr>
                                                                    <th data-class=""expand""></th>
                                                                    <th data-class=""expand"">Datasheet No</th>
                                                                    <th data-class=""expand"">Kayıt Yapan</th>
                                                                    <th data-class=""expand"">Kayıt Tarihi</th>
                                                                    <th data-class=""expand"">Departman</th>
                                    ");
            WriteLiteral(@"                                <th data-class=""expand"">Ana Müşteri</th>
                                                                    <th data-class=""expand"">Model No</th>
                                                                    <th data-class=""expand"">Durum</th>
                                                                    <th data-class=""expand"">Test Sonucu</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
");
#nullable restore
#line 63 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                 foreach (var item in Model.DataSheetDtos.Where(k => k.StatusId == 0))
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <tr>\r\n                                                                        <td class=\"sorting_1\"><a");
            BeginWriteAttribute("href", " href=\"", 4194, "\"", 4253, 1);
#nullable restore
#line 66 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
WriteAttributeValue("", 4201, Url.Action("DataSheet","DataSheet",new { item.Id }), 4201, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\"><span class=\"glyphicon glyphicon-pencil\"></span></a></td>\r\n                                                                        <td>");
#nullable restore
#line 67 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.DataSheetNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 68 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.CreateUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 69 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 70 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 71 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.MainCustomer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 72 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.SampleNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 73 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 74 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.TestResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    </tr>\r\n");
#nullable restore
#line 76 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!-- end widget content -->
                                                </div>

                                                <!-- end widget div -->
                                            </div>

                                        </article>
                                    </div>

                                </div>

                                <div class=""tab-pane fade"" id=""s2"">
                                    <div class=""row"">
                                        <article class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                                            <div class=""jarviswidget jarviswidget-color-blueDark"" id=""wid-id-2"" 
                                                 data-widget-editbutton=""false"" data-");
            WriteLiteral(@"widget-deletebutton=""false""
                                                 data-widget-togglebutton=""false"" data-widget-sortable=""false"">
                                                <header>
                                                    <span class=""widget-icon""> <i class=""fa fa-table""></i> </span>
                                                    <h2>Yeni Açılan Kayıtlar</h2>

                                                </header>

                                                <div>
                                                    <div class=""jarviswidget-editbox"">
                                                    </div>
                                                    <div class=""widget-body no-padding"">
                                                        <table id=""dtDataSheetList2"" class=""table table-striped table-bordered"" width=""100%"">
                                                            <thead>
                                                         ");
            WriteLiteral(@"       <tr>
                                                                    <th data-class=""expand""></th>
                                                                    <th data-class=""expand"">Datasheet No</th>
                                                                    <th data-class=""expand"">Kayıt Yapan</th>
                                                                    <th data-class=""expand"">Kayıt Tarihi</th>
                                                                    <th data-class=""expand"">Departman</th>
                                                                    <th data-class=""expand"">Ana Müşteri</th>
                                                                    <th data-class=""expand"">Model No</th>
                                                                    <th data-class=""expand"">Durum</th>
                                                                    <th data-class=""expand"">Test Sonucu</th>
                                         ");
            WriteLiteral("                       </tr>\r\n                                                            </thead>\r\n                                                            <tbody>\r\n");
#nullable restore
#line 122 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                 foreach (var item in Model.DataSheetDtos.Where(k => k.StatusId == 1))
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <tr>\r\n                                                                        <td class=\"sorting_1\"><a");
            BeginWriteAttribute("href", " href=\"", 8885, "\"", 8944, 1);
#nullable restore
#line 125 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
WriteAttributeValue("", 8892, Url.Action("DataSheet","DataSheet",new { item.Id }), 8892, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\"><span class=\"glyphicon glyphicon-pencil\"></span></a></td>\r\n                                                                        <td>");
#nullable restore
#line 126 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.DataSheetNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 127 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.CreateUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 128 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 129 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 130 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.MainCustomer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 131 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.SampleNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 132 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                        <td>");
#nullable restore
#line 133 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                       Write(item.TestResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    </tr>\r\n");
#nullable restore
#line 135 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\CustomerIndex.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!-- end widget content -->
                                                </div>

                                                <!-- end widget div -->
                                            </div>

                                        </article>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </article>

            <!-- WIDGET END -->
        </div>
        <!-- end row -->
        <!-- end row -->
    </section>
</div>

<script type=""text/javascript"">
    $(""#dtDataSheetList2"").dataTable();
    $(""#dtDataSheetList"").dataTable();
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CustomerIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
