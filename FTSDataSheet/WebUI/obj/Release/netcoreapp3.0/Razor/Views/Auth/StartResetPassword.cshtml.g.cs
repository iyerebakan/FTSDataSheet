#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\StartResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f6898f264c15f15928fcb06209824f9c224bc8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_StartResetPassword), @"mvc.1.0.view", @"/Views/Auth/StartResetPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f6898f264c15f15928fcb06209824f9c224bc8a", @"/Views/Auth/StartResetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_StartResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PasswordChangeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\StartResetPassword.cshtml"
  
    ViewData["Title"] = "StartResetPassword";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""content"">

    <!-- row -->
    <div class=""row"">

        <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">

            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""text-center error-box"">
                        <br>
                        <p class=""lead"">
                           Şifre değişikliği talebeniz için;
                        </p>
                        <p class=""font-md"">
                            <b>");
#nullable restore
#line 21 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\StartResetPassword.cshtml"
                          Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> adresine eposta gönderilmiştir.\r\n                        </p>\r\n                        <br>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <!-- end row -->\r\n\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PasswordChangeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
