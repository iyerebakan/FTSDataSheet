#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Shared\_Ribbon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebb29755d24b1827b7c91e535347b35f5dc57dfc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Ribbon), @"mvc.1.0.view", @"/Views/Shared/_Ribbon.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebb29755d24b1827b7c91e535347b35f5dc57dfc", @"/Views/Shared/_Ribbon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Ribbon : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""ribbon"">

    <span class=""ribbon-button-alignment"">
        <span id=""refresh"" class=""btn btn-ribbon"" data-action=""resetWidgets"" data-title=""refresh"" rel=""tooltip"" data-placement=""bottom"" data-original-title=""<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings."" data-html=""true"">
						<i class=""fa fa-refresh""></i>
					</span>
    </span>

    <!-- breadcrumb -->
    <ol class=""breadcrumb"">
        <li>");
#nullable restore
#line 11 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Shared\_Ribbon.cshtml"
       Write(Html.Raw(ViewData["newurl"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n        <li>");
#nullable restore
#line 12 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Shared\_Ribbon.cshtml"
       Write(Html.Raw(ViewData["listurl"]));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- You can also add more buttons to the
    ribbon for further usability

    Example below:

    <span class=""ribbon-button-alignment pull-right"">
    <span id=""search"" class=""btn btn-ribbon hidden-xs"" data-title=""search""><i class=""fa-grid""></i> Change Grid</span>
    <span id=""add"" class=""btn btn-ribbon hidden-xs"" data-title=""add""><i class=""fa-plus""></i> Add</span>
    <span id=""search"" class=""btn btn-ribbon"" data-title=""search""><i class=""fa-search""></i> <span class=""hidden-mobile"">Search</span></span>
    </span> -->

</div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591