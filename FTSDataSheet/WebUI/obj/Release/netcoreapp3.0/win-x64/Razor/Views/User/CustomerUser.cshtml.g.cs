#pragma checksum "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "957bf0095c23c69bf64f391e444c904b0d6dd6d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_CustomerUser), @"mvc.1.0.view", @"/Views/User/CustomerUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"957bf0095c23c69bf64f391e444c904b0d6dd6d4", @"/Views/User/CustomerUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bb3556bda1a9eccdfa670ff29ff3e8a8b74c085", @"/Views/_ViewImports.cshtml")]
    public class Views_User_CustomerUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddOrUpdateUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("mainform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("smart-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
  
    ViewData["Title"] = "User";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
Write(Html.Partial("~/Views/Shared/_Ribbon.cshtml"
    , new ViewDataDictionary(ViewData) {
        { "newurl" , string.Format("<a href={0}> Yeni Kayıt </a>","/ftsdatasheet/kullanici/0") },
        { "listurl" , string.Format("<a href={0} class='stretched-link'> Kayıt Listesine Git </a>","/ftsdatasheet/kullanicilar") }
    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div id=\"content\">\r\n    <section id=\"widget-grid\"");
            BeginWriteAttribute("class", " class=\"", 443, "\"", 451, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <!-- row -->\r\n        <div class=\"row\">\r\n\r\n            ");
#nullable restore
#line 17 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
       Write(Html.Partial("~/Views/Shared/_Master.cshtml",
               new ViewDataDictionary(ViewData) {
                   { "Id", Model.User.Id},
                   { "url", "/User/DeleteUser"},
                   { "returnurl", "/kullanicilar" },
               }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            <!-- NEW WIDGET START -->
            <article class=""col-sm-12 col-md-12 col-lg-12"">
                <!-- Widget ID (each widget will need unique ID)-->
                <div class=""jarviswidget"" id=""wid-id-8"" data-widget-editbutton=""false"" data-widget-custombutton=""false"">
                    <header>
                        <span class=""widget-icon""> <i class=""fa fa-edit""></i> </span>
                        <h2>Kullanıcı Tanımlama</h2>
                    </header>
                    <!-- widget div-->
                    <div>
                        <!-- widget edit box -->
                        <div class=""jarviswidget-editbox"">
                            <!-- This area used as dropdown edit box -->
                            <p class=""lead"">");
#nullable restore
#line 37 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                       Write(Html.ValidationMessage("ValidationException"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <!-- end widget edit box -->\r\n                        <!-- widget content -->\r\n                        <div class=\"widget-body no-padding\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "957bf0095c23c69bf64f391e444c904b0d6dd6d47800", async() => {
                WriteLiteral(@"

                                <fieldset>
                                    <div class=""row"">
                                        <label class=""label col col-2"">Email</label>
                                        <section class=""col col-4"">
                                            <label class=""input"">
                                                ");
#nullable restore
#line 49 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.TextBoxFor(m => m.User.Email, new { type = "email", placeholder = "example@mail.com" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 50 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.User.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </label>
                                        </section>

                                        <label class=""label col col-2"">Şifre</label>
                                        <section class=""col col-4"">
                                            <label class=""input"">
                                                ");
#nullable restore
#line 57 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.TextBoxFor(m => m.User.Password, new { type = "text", required = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            </label>\r\n                                        </section>\r\n\r\n                                        ");
#nullable restore
#line 61 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                   Write(Html.HiddenFor(m => m.User.Id, new { id = "txtUserId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        <input type=""hidden"" value=""1"" name=""User.RoleId"" />
                                        
                                    </div>

                                    <div class=""row"">
                                        <label class=""label col col-2"">Kullanıcı Adı</label>
                                        <section class=""col col-4"">
                                            <label class=""input"">
                                                ");
#nullable restore
#line 70 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.TextBoxFor(m => m.User.FirstName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 71 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.User.FirstName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </label>
                                        </section>

                                        <label class=""label col col-2"">Kullanıcı Soyadı</label>
                                        <section class=""col col-4"">
                                            <label class=""input"">
                                                ");
#nullable restore
#line 78 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.TextBoxFor(m => m.User.LastName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 79 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.User.LastName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </label>
                                        </section>
                                    </div>

                                    <div class=""row"">
                                        <label class=""label col col-2""></label>
                                        <section class=""col col-4"">
                                            <label class=""checkbox"">
                                                ");
#nullable restore
#line 88 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.CheckBoxFor(m => m.User.Status, new { type = "checkbox" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                <i></i>Aktif
                                            </label>
                                        </section>

                                        <label class=""label col col-2"">Müşteri</label>
                                        <section class=""col col-4"">
                                            <label class=""input"">
                                                ");
#nullable restore
#line 96 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.DropDownListFor(m => m.User.CustomerId, new SelectList(Model.Customers, "Id", "DisplayName"), new { @class = "form-control", style = "width:100%", id = "txtCustomerId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 97 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.User.CustomerId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            </label>\r\n                                        </section>\r\n\r\n                                    </div>\r\n\r\n");
#nullable restore
#line 103 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                     if (Model.User.Id > 0)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        <div class=""row"">
                                            <section class=""col col-12 pull-right"">
                                                <button class=""btn btn-sm btn-success"" type=""button"" onclick=""Works.SendEmail()"">E-posta Gönder</button>
                                            </section>
                                        </div>
");
#nullable restore
#line 110 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </fieldset>\r\n\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                        </div>
                        <!-- end widget content -->
                    </div>
                    <!-- end widget div -->
                </div>
                <!-- end widget -->
            </article>



        </div>
        <!-- end row -->
    </section>
</div>

<script type=""text/javascript"">
    $(document).ready(function () {
        Projen.Client.UI.getSelect2Combobox(""txtCustomerId"", ""/Customer/GetCustomers"");
    });

    var Works = function () {
        SendEmail = function () {
            return Projen.Server.PostAsync("""", ""/User/SendUserMail?Id=");
#nullable restore
#line 137 "C:\Users\ibrahimy\Desktop\FTSDataSheet\WebUI\Views\User\CustomerUser.cshtml"
                                                                 Write(Model.User.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", function (data) {\r\n                alert(data);\r\n                window.location.reload();\r\n            });\r\n        }\r\n\r\n        return {\r\n            SendEmail: SendEmail\r\n        }\r\n    }();\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
