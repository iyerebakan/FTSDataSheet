#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5297bf3c4d5ce0b03d81e32e893583d6414e318"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_ChangePassword), @"mvc.1.0.view", @"/Views/Auth/ChangePassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5297bf3c4d5ce0b03d81e32e893583d6414e318", @"/Views/Auth/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserForChangePassword>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("smart-form client-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("login-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
  
    ViewBag.PageId = "extr-page";
    ViewBag.PageClass = "animated fadeInDown";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div id=\"content\" class=\"container\">\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-xs-12 col-sm-12 col-md-6 col-lg-6 col-lg-offset-3\">\r\n            <div class=\"well no-padding\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5297bf3c4d5ce0b03d81e32e893583d6414e3185241", async() => {
                WriteLiteral("\r\n                    <header>\r\n                        Şifre Değiştirme\r\n                    </header>\r\n                    ");
#nullable restore
#line 18 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                <fieldset>
                    <section>
                        <label class=""label"">E-posta adresi</label>
                        <label class=""input"">
                            <i class=""icon-append fa fa-user""></i>
                            ");
#nullable restore
#line 24 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
                       Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control", disabled = "true" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            <b class=\"tooltip tooltip-top-right\"><i class=\"fa fa-user txt-color-teal\"></i> Lütfen email adresinizi giriniz.</b>\r\n                            ");
#nullable restore
#line 26 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
                       Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </label>
                    </section>
                    <section>
                        <label class=""label"">Şifre</label>
                        <label class=""input"">
                            <i class=""icon-append fa fa-lock""></i>
                            ");
#nullable restore
#line 33 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
                       Write(Html.PasswordFor(m => m.NewPassword, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            <b class=""tooltip tooltip-top-right""><i class=""fa fa-lock txt-color-teal""></i> Şifrenizi Giriniz.</b>
                        </label>
                        <div class=""note"">
                            <label class=""label"">");
#nullable restore
#line 37 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
                                            Write(TempData["LoginErrors"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                        </div>
                    </section>
                    <section>
                        <label class=""label"">Şifre Tekrar</label>
                        <label class=""input"">
                            <i class=""icon-append fa fa-lock""></i>
                            ");
#nullable restore
#line 44 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
                       Write(Html.PasswordFor(m => m.NewPasswordAgain, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            <b class=""tooltip tooltip-top-right""><i class=""fa fa-lock txt-color-teal""></i> Şifrenizi Giriniz.</b>
                        </label>
                        <div class=""note"">
                            <label class=""label"">");
#nullable restore
#line 48 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
                                            Write(TempData["LoginErrors"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                        </div>
                    </section>
                </fieldset>
                    <footer>
                        <button type=""submit"" class=""btn btn-primary"">
                            Şifremi Değiştir
                        </button>
                    </footer>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 59 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\Auth\ChangePassword.cshtml"
               Html.RenderPartial("_SocialMedia.cshtml"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserForChangePassword> Html { get; private set; }
    }
}
#pragma warning restore 1591