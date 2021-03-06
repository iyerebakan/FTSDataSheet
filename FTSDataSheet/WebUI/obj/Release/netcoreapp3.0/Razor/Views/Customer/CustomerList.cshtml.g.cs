#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Customer\CustomerList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "993c240239b9433833fde507ef971b7fc4656eab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerList), @"mvc.1.0.view", @"/Views/Customer/CustomerList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"993c240239b9433833fde507ef971b7fc4656eab", @"/Views/Customer/CustomerList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Customer\CustomerList.cshtml"
  
    ViewData["Title"] = "CustomerList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div id=\"content\">\r\n    <section id=\"widget-grid\"");
            BeginWriteAttribute("class", " class=\"", 103, "\"", 111, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <!-- row -->
        <div class=""row"">
            <!-- NEW WIDGET START -->
            <article class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                <div class=""jarviswidget jarviswidget-color-blueDark"" id=""wid-id-1"" data-widget-editbutton=""false"" data-widget-deletebutton=""false"">
                    <header>
                        <span class=""widget-icon""> <i class=""fa fa-table""></i> </span>
                        <h2>Müşteriler </h2>

                    </header>

                    <!-- widget div-->
                    <div>
                        <!-- widget edit box -->
                        <div class=""jarviswidget-editbox"">
                            <!-- This area used as dropdown edit box -->
                        </div>
                        <!-- end widget edit box -->
                        <!-- widget content -->
                        <div class=""widget-body no-padding"">
                            <table id=""dtCustomer"" class=""table t");
            WriteLiteral(@"able-striped table-bordered"" width=""100%"">
                                <thead>
                                    <tr>
                                        <th style=""width:2%""></th>
                                        <th class=""hasinput"" style=""width:7%"">
                                            <input type=""number"" class=""form-control"" placeholder=""ID"" />
                                        </th>
                                        <th class=""hasinput"" style=""width:15%"">
                                            <input type=""text"" class=""form-control"" placeholder=""Firma Adı"" />
                                        </th>
                                        <th class=""hasinput"" style=""width:20%"">
                                            <input class=""form-control"" placeholder=""Ticari Ünvan"" type=""text"">
                                        </th>
                                        <th class=""hasinput"" style=""width:10%"">
                                 ");
            WriteLiteral(@"           <input class=""form-control"" placeholder=""Telefon"" type=""text"">
                                        </th>
                                        <th class=""hasinput"" style=""width:15%"">
                                            <input class=""form-control"" placeholder=""Eposta"" type=""text"">
                                        </th>
                                        <th class=""hasinput"" style=""width:15%"">
                                            <input class=""form-control"" placeholder=""Web"" type=""text"">
                                        </th>
                                    </tr>
                                    <tr>
                                        <th data-class=""expand""></th>
                                        <th data-class=""expand"">Id</th>
                                        <th data-class=""expand"">Firma Adı</th>
                                        <th data-class=""expand"">Ticari Ünvan</th>
                                        <th");
            WriteLiteral(@" data-class=""expand"">Telefon</th>
                                        <th data-class=""expand"">Eposta</th>
                                        <th data-class=""expand"">Web</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                        <!-- end widget content -->
                    </div>

                    <!-- end widget div -->
                </div>

            </article>
            <!-- WIDGET END -->
        </div>
        <!-- end row -->
        <!-- end row -->
    </section>
</div>

<script type=""text/javascript"">
    $(document).ready(function () {
        Projen.Client.UI.getDatatable(
            datatableId = ""dtCustomer"",
            tablet = 1024,
            phone = 480,
            searchButton = true,
            addnewrowButton = true,
            newrecurl = ""/musteri/0"",
            sh");
            WriteLiteral(@"owhideButton = """",
            serverside = true,
            ajax = ""/Customer/CustomerListDataTable"",
            columns = [
                {
                    ""name"": ""Id"",
                    'render': function (data) {
                        return '<a href=""' + UrlDuzelt(""/musteri/"" + data) + '""  role=""button""><span class=""glyphicon glyphicon-pencil""></span></a>';
                    }
                },
                { ""name"": ""Id"" },
                { ""name"": ""DisplayName"" },
                { ""name"": ""CommercialTitle"" },
                { ""name"": ""TelephoneNumber"" },
                { ""name"": ""EmailAddress"" },
                { ""name"": ""WebAddress"" },
            ]
        );
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
