#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\FTSAdminIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1c7723c5863063882efa2b18cae871eaa37bfd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FTSAdminIndex), @"mvc.1.0.view", @"/Views/Home/FTSAdminIndex.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1c7723c5863063882efa2b18cae871eaa37bfd7", @"/Views/Home/FTSAdminIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FTSAdminIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FTSAdminIndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Home\FTSAdminIndex.cshtml"
  
    ViewData["Title"] = "FTSAdminIndex";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"content\">\r\n    <section id=\"widget-grid\"");
            BeginWriteAttribute("class", " class=\"", 131, "\"", 139, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <div class=""row"">

            <article class=""col-xs-12 col-sm-6 col-lg-6 sortable-grid ui-sortable"">
                <div class=""jarviswidget"" id=""wid-id-7"" data-widget-colorbutton=""false"" data-widget-fullscreenbutton=""false""
                     data-widget-editbutton=""false"" data-widget-sortable=""false"" data-widget-deletebutton=""false"">
                    <header>
                        <h2>YILLIK - AYLIK DATA SHEET ADETLERİ </h2>
                    </header>
                    <div>
                        <div class=""jarviswidget-editbox"">
                            <input class=""form-control"" type=""text"">
                        </div>
                        <div class=""widget-body"">
                            <canvas id=""barChart"" height=""120""></canvas>
                        </div>
                    </div>
                </div>
            </article>

            <article class=""col-xs-12 col-sm-6 col-lg-6 sortable-grid ui-sortable"">
                <div clas");
            WriteLiteral(@"s=""jarviswidget"" id=""wid-id-17"" data-widget-colorbutton=""false"" data-widget-fullscreenbutton=""false""
                     data-widget-editbutton=""false"" data-widget-sortable=""false"" data-widget-deletebutton=""false"">
                    <header>
                        <h2>DATA SHEET TESLİM SÜRESİ </h2>
                    </header>
                    <div>
                        <div class=""jarviswidget-editbox"">
                            <input class=""form-control"" type=""text"">
                        </div>
                        <div class=""widget-body"">
                            <canvas id=""barChart2"" height=""120""></canvas>
                        </div>
                    </div>
                </div>
            </article>

            <article class=""col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable"">
                <div class=""jarviswidget"" id=""wid-id-6"" data-widget-colorbutton=""false"" data-widget-fullscreenbutton=""false""
                     data-widget-editbut");
            WriteLiteral(@"ton=""false"" data-widget-sortable=""false"" data-widget-deletebutton=""false"">
                    <header>
                        <h2>İLLERE GÖRE DATA SHEET ADETLERİ</h2>
                    </header>
                    <div>
                        <div class=""jarviswidget-editbox"">
                            <input class=""form-control"" type=""text"">
                        </div>
                        <div class=""widget-body"">
                            <canvas id=""pieChart"" height=""120""></canvas>
                        </div>
                    </div>
                </div>
            </article>

            <article class=""col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable"">
                <div class=""jarviswidget"" id=""wid-id-16"" data-widget-colorbutton=""false"" data-widget-fullscreenbutton=""false""
                     data-widget-editbutton=""false"" data-widget-sortable=""false"" data-widget-deletebutton=""false"">
                    <header>
                        <h2>TO");
            WriteLiteral(@"P 5 DATA SHEET MÜŞTERİSİ </h2>
                    </header>
                    <div>
                        <div class=""jarviswidget-editbox"">
                            <input class=""form-control"" type=""text"">
                        </div>
                        <div class=""widget-body"">
                            <canvas id=""pieChart2"" height=""120""></canvas>
                        </div>
                    </div>
                </div>
            </article>

            <article class=""col-sm-12 col-md-12 col-lg-12"">
                <div class=""jarviswidget"" id=""wid-id-4"">

                    <div>
                        <div class=""jarviswidget-editbox"">
                        </div>
                        <div class=""widget-body"">
                            <ul id=""myTab1"" class=""nav nav-tabs bordered"">
                                <li class=""active"">
                                    <a href=""#s1"" data-toggle=""tab""><i class=""fa fa-fw fa-lg fa-pencil""></i>Bekleyen");
            WriteLiteral(@" Kayıtlar</a>
                                </li>
                                <li>
                                    <a href=""#s2"" data-toggle=""tab""><i class=""fa fa-fw fa-lg fa-pencil""></i>Devam Eden Kayıtlar</a>
                                </li>
                                <li>
                                    <a href=""#s3"" data-toggle=""tab""><i class=""fa fa-fw fa-lg fa-file""></i>Tamamlanmış Kayıtlar</a>
                                </li>
                            </ul>

                            <div id=""myTabContent1"" class=""tab-content padding-10"">
                                <div class=""tab-pane fade in active"" id=""s1"">

                                    <div class=""row"">
                                        <article class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                                            <div class=""jarviswidget jarviswidget-color-blueDark"" id=""wid-id-1""
                                                 data-widget-editbutton=""false"" d");
            WriteLiteral(@"ata-widget-sortable=""false""
                                                 data-widget-deletebutton=""false"" data-widget-togglebutton=""false"">
                                                <header>
                                                    <span class=""widget-icon""> <i class=""fa fa-table""></i> </span>
                                                    <h2>Bekleyen Kayıtlar</h2>
                                                    <div class=""widget-toolbar"" role=""menu"">

                                                        <div class=""btn-group"">
                                                            <button class=""btn btn-xs btn-success""
                                                                    type=""button"" id=""btnExport"">
                                                                Excel'e Aktar <i class=""fa fa-file""></i>
                                                            </button>
                                                        </div>
       ");
            WriteLiteral(@"                                             </div>
                                                </header>

                                                <div>
                                                    <div class=""jarviswidget-editbox"">
                                                    </div>
                                                    <div class=""widget-body"">
                                                        <table id=""dtDataSheetList"" class=""table table-striped table-bordered"" width=""100%"">
                                                            <thead>
                                                                <tr>
                                                                    <th data-class=""expand""></th>
                                                                    <th data-class=""expand"">Müşteri Adı</th>
                                                                    <th data-class=""expand"">Datasheet No</th>
                           ");
            WriteLiteral(@"                                         <th data-class=""expand"">Kayıt Yapan</th>
                                                                    <th data-class=""expand"">Kayıt Tarihi</th>
                                                                    <th data-class=""expand"">Departman</th>
                                                                    <th data-class=""expand"">Ana Müşteri</th>
                                                                    <th data-class=""expand"">Model No</th>
                                                                    <th data-class=""expand"">Durum</th>
                                                                    <th data-class=""expand"">Test Sonucu</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody></tbody>
                                                        </table>
       ");
            WriteLiteral(@"                                             </div>
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
                                                 data-widget-editbutton=""false"" data-widget-sortable=""false""
                                                 data-widget-deletebutton=""false"" data-widget-togglebutton=""false"">
  ");
            WriteLiteral(@"                                              <header>
                                                    <span class=""widget-icon""> <i class=""fa fa-table""></i> </span>
                                                    <h2>Devam Eden Kayıtlar</h2>

                                                </header>

                                                <div>
                                                    <div class=""jarviswidget-editbox"">
                                                    </div>
                                                    <div class=""widget-body"">
                                                        <table id=""dtDataSheetList2"" class=""table table-striped table-bordered"" width=""100%"">
                                                            <thead>
                                                                <tr>
                                                                    <th data-class=""expand""></th>
                                            ");
            WriteLiteral(@"                        <th data-class=""expand"">FTSUser</th>
                                                                    <th data-class=""expand"">Müşteri Adı</th>
                                                                    <th data-class=""expand"">Datasheet No</th>
                                                                    <th data-class=""expand"">Kayıt Yapan</th>
                                                                    <th data-class=""expand"">Kayıt Tarihi</th>
                                                                    <th data-class=""expand"">Departman</th>
                                                                    <th data-class=""expand"">Ana Müşteri</th>
                                                                    <th data-class=""expand"">Model No</th>
                                                                    <th data-class=""expand"">Test Sonucu</th>
                                                                </tr>
              ");
            WriteLiteral(@"                                              </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!-- end widget content -->
                                                </div>

                                                <!-- end widget div -->
                                            </div>

                                        </article>
                                    </div>

                                </div>

                                <div class=""tab-pane fade"" id=""s3"">
                                    <div class=""row"">
                                        <article class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                                            <div class=""jarviswidget jarvi");
            WriteLiteral(@"swidget-color-blueDark"" id=""wid-id-3""
                                                 data-widget-editbutton=""false"" data-widget-deletebutton=""false""
                                                 data-widget-togglebutton=""false"" data-widget-sortable=""false"">
                                                <header>
                                                    <span class=""widget-icon""> <i class=""fa fa-table""></i> </span>
                                                    <h2>Tamamlanmış Kayıtlar</h2>

                                                </header>

                                                <div>
                                                    <div class=""jarviswidget-editbox"">
                                                    </div>
                                                    <div class=""widget-body"">
                                                        <table id=""dtDataSheetList3"" class=""table table-striped table-bordered"" width=""100%"">
             ");
            WriteLiteral(@"                                               <thead>
                                                                <tr>
                                                                    <th data-class=""expand""></th>
                                                                    <th data-class=""expand"">FTSUser</th>
                                                                    <th data-class=""expand"">Müşteri Adı</th>
                                                                    <th data-class=""expand"">Datasheet No</th>
                                                                    <th data-class=""expand"">Kayıt Yapan</th>
                                                                    <th data-class=""expand"">Kayıt Tarihi</th>
                                                                    <th data-class=""expand"">Departman</th>
                                                                    <th data-class=""expand"">Ana Müşteri</th>
                                 ");
            WriteLiteral(@"                                   <th data-class=""expand"">Model No</th>
                                                                    <th data-class=""expand"">Test Sonucu</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!-- end widget content -->
                                                </div>

                                                <!-- end widget div -->
                                            </div>

                                        </article>
                                    </div>

                                </div>
                            </");
            WriteLiteral(@"div>
                        </div>
                    </div>
                </div>
            </article>


        </div>
    </section>
</div>

<script type=""text/javascript"">

    var pieData = [];
    var pieData2 = [];
    var pieChart;
    var pieChart2;
    var pieOptions = {
        segmentShowStroke: false,
        segmentStrokeColor: ""#fff"",
        segmentStrokeWidth: 1,
        animateScale: false,
        responsive: true
    };

    var barData = [];
    var barChart;
    var barOptions = {
        scaleBeginAtZero: true,
        scaleShowGridLines: true,
        scaleGridLineColor: ""rgba(0,0,0,.05)"",
        scaleGridLineWidth: 1,
        barShowStroke: true,
        barStrokeWidth: 1,
        barValueSpacing: 5,
        barDatasetSpacing: 2,
        responsive: true
    };

    $(document).ready(function () {
        $.ajaxSetup({ ""async"": false });
        Projen.Client.UI.getDatatable(
            datatableId = ""dtDataSheetList"",
            tabl");
            WriteLiteral(@"et = 1024,
            phone = 480,
            searchButton = true,
            addnewrowButton = false,
            newrecurl = ""/datasheet/0"",
            showhideButton = """",
            serverside = true,
            ajax = ""/DataSheet/FTSDataSheetListDataTable"",
            columns = [
                {
                    ""name"": ""Id"",
                    'render': function (data) {
                        return '<a href=""' + UrlDuzelt(""/datasheet/"" + data) + '"" role=""button""><span class=""glyphicon glyphicon-pencil""></span></a>';
                    }
                },
                { ""name"": ""CustomerName"" },
                { ""name"": ""DataSheetNumber"" },
                { ""name"": ""CreateUserName"" },
                { ""name"": ""CreateDate"" },
                { ""name"": ""Department"" },
                { ""name"": ""MainCustomer"" },
                { ""name"": ""SampleNumber"" },
                { ""name"": ""Status"" },
                { ""name"": ""TestResult"" },
            ]
        );");
            WriteLiteral(@"

        Projen.Client.UI.getDatatable(
            datatableId = ""dtDataSheetList2"",
            tablet = 1024,
            phone = 480,
            searchButton = true,
            addnewrowButton = false,
            newrecurl = ""/datasheet/0"",
            showhideButton = """",
            serverside = true,
            ajax = ""/DataSheet/FTSAdminDataSheetListDataTable?status=1"",
            columns = [
                {
                    ""name"": ""Id"",
                    'render': function (data) {
                        return '<a href=""' + UrlDuzelt(""/datasheet/"" + data) + '""  role=""button""><span class=""glyphicon glyphicon-pencil""></span></a>';
                    }
                },
                { ""name"": ""FTSUser"" },
                { ""name"": ""CustomerName"" },
                { ""name"": ""DataSheetNumber"" },
                { ""name"": ""CreateUserName"" },
                { ""name"": ""CreateDate"" },
                { ""name"": ""Department"" },
                { ""name"": ""MainCustom");
            WriteLiteral(@"er"" },
                { ""name"": ""SampleNumber"" },
                { ""name"": ""TestResult"" },
            ]
        );

        Projen.Client.UI.getDatatable(
            datatableId = ""dtDataSheetList3"",
            tablet = 1024,
            phone = 480,
            searchButton = true,
            addnewrowButton = false,
            newrecurl = ""/datasheet/0"",
            showhideButton = """",
            serverside = true,
            ajax = ""/DataSheet/FTSAdminDataSheetListDataTable?status=2"",
            columns = [
                {
                    ""name"": ""Id"",
                    'render': function (data) {
                        return '<a href=""' + UrlDuzelt(""/datasheet/"" + data) + '"" role=""button""><span class=""glyphicon glyphicon-pencil""></span></a>';
                    }
                },
                { ""name"": ""FTSUser"" },
                { ""name"": ""CustomerName"" },
                { ""name"": ""DataSheetNumber"" },
                { ""name"": ""CreateUserName"" },
  ");
            WriteLiteral(@"              { ""name"": ""CreateDate"" },
                { ""name"": ""Department"" },
                { ""name"": ""MainCustomer"" },
                { ""name"": ""SampleNumber"" },
                { ""name"": ""TestResult"" },
            ]
        );

        Works.PieChart();
        Works.PieChart2();
        Works.BarChart();     
        Works.BarChart2();
        $.ajaxSetup({ ""async"": true });
    });

    var Works = function () {
        PieChart = function () {
            Projen.Server.PostAsync("""", ""/Home/PieChartIndex/"", function (data) {
                if (data.length > 0) {
                    data.forEach(function (e) {
                        pieData.push({
                            value: e.result,
                            color: e.color,
                            highlight: e.highlight,
                            label: e.label
                        });
                    });
                    var ctx = document.getElementById(""pieChart"").getContext(""2d"");
       ");
            WriteLiteral(@"             pieChart = new Chart(ctx).Pie(pieData, pieOptions);
                }
            });
        },
        PieChart2 = function () {
            Projen.Server.PostAsync("""", ""/Home/PieChartIndexTop5/"", function (data) {
                if (data.length > 0) {
                    data.forEach(function (e) {
                        pieData2.push({
                            value: e.result,
                            color: e.color,
                            highlight: e.highlight,
                            label: e.label
                        });
                    });
                    var ctx = document.getElementById(""pieChart2"").getContext(""2d"");
                    pieChart2 = new Chart(ctx).Pie(pieData2, pieOptions);
                }
            });
        },
        BarChart = function () {
            Projen.Server.PostAsync("""", ""/Home/BarChartIndex/"", function (response) {
                if (response.datas.length > 0) {
                    var labels = [];");
            WriteLiteral(@"
                    var datas = [];
                    response.datas.forEach(function (e) {
                        labels.push(e.name);
                        datas.push(e.data);
                    });

                    barData = {
                        labels: labels,
                        datasets: [
                            {
                                label: ""My First dataset"",
                                fillColor: response.fillColor,
                                strokeColor: response.strokeColor,
                                highlightFill: response.highlightFill,
                                highlightStroke: response.highlightStroke,
                                data: datas
                            }
                        ]
                    };

                    var ctx = document.getElementById(""barChart"").getContext(""2d"");
                    barChart = new Chart(ctx).Bar(barData, barOptions);
                }
            });
   ");
            WriteLiteral(@"     },
        BarChart2 = function () {
            Projen.Server.PostAsync("""", ""/Home/BarChartIndexYearly/"", function (response) {
                if (response.datas.length > 0) {
                    var labels = [];
                    var datas = [];
                    response.datas.forEach(function (e) {
                        labels.push(e.name);
                        datas.push(e.data);
                    });

                    barData = {
                        labels: labels,
                        datasets: [
                            {
                                label: ""My First dataset"",
                                fillColor: response.fillColor,
                                strokeColor: response.strokeColor,
                                highlightFill: response.highlightFill,
                                highlightStroke: response.highlightStroke,
                                data: datas
                            }
                        ]
");
            WriteLiteral(@"                    };

                    var ctx = document.getElementById(""barChart2"").getContext(""2d"");
                    barChart = new Chart(ctx).Bar(barData, barOptions);
                }
            });
        }
        return {
            PieChart: PieChart,
            PieChart2: PieChart2,
            BarChart: BarChart,
            BarChart2: BarChart2
        }
    }();

    $(""#btnExport"").click(function () {
        window.location.href = UrlDuzelt(""/DataSheet/ExportDataSheet?filter="" + $(""#dtDataSheetList_filter input"")[0].value);
    });
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FTSAdminIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
