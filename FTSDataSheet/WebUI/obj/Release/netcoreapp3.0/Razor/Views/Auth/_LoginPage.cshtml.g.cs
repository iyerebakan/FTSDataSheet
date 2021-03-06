#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\_LoginPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8dcac144728fcc1113d91e0c2a04111712db8dbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth__LoginPage), @"mvc.1.0.view", @"/Views/Auth/_LoginPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dcac144728fcc1113d91e0c2a04111712db8dbc", @"/Views/Auth/_LoginPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth__LoginPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserForLoginDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<fieldset>\r\n    <section>\r\n        <label class=\"label\">E-posta adresi</label>\r\n        <label class=\"input\">\r\n            <i class=\"icon-append fa fa-user\"></i>\r\n            ");
#nullable restore
#line 8 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\_LoginPage.cshtml"
       Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <b class=""tooltip tooltip-top-right""><i class=""fa fa-user txt-color-teal""></i> Lütfen email adresinizi giriniz.</b>
        </label>
    </section>
    <section>
        <label class=""label"">Şifre</label>
        <label class=""input"">
            <i class=""icon-append fa fa-lock""></i>
            ");
#nullable restore
#line 16 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\_LoginPage.cshtml"
       Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <b class=\"tooltip tooltip-top-right\"><i class=\"fa fa-lock txt-color-teal\"></i> Şifrenizi Giriniz.</b>\r\n        </label>\r\n        <div class=\"note\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 827, "\"", 870, 1);
#nullable restore
#line 20 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\_LoginPage.cshtml"
WriteAttributeValue("", 834, Url.Action("resetpassword", "auth"), 834, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-frown-o\"></i> Şifremi Unuttum</a>\r\n            <label class=\"label\">");
#nullable restore
#line 21 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\_LoginPage.cshtml"
                            Write(TempData["LoginErrors"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </section>\r\n    <section>\r\n        <label class=\"checkbox\">\r\n            ");
#nullable restore
#line 26 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\_LoginPage.cshtml"
       Write(Html.CheckBox("Rememberme", true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <i></i>Beni Hatırla\r\n        </label>\r\n    </section>\r\n</fieldset>\r\n<footer>\r\n    <button type=\"submit\" class=\"btn btn-primary\">\r\n        Oturum Aç\r\n    </button>\r\n</footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserForLoginDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
