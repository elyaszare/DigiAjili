#pragma checksum "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Newsletter\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6fb89073a318a821ad9fd2e612321f726c5a8d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.Newsletter.Pages_Shared_Components_Newsletter_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/Newsletter/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.Newsletter
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
#line 1 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6fb89073a318a821ad9fd2e612321f726c5a8d4", @"/Pages/Shared/Components/Newsletter/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1d277691ff97276995da980fa12d1415fd1863d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_Newsletter_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""banner"">

    <div class=""container-fluid"">

        <div class=""banner-image"" style=""background-image: url(/Theme/assets/images/Banner2.jpg)"">
            <!--Header-->

            <header>
                <div class=""container"">

                    <h2 class=""h2 title"">در تماس باش!</h2>
                    <div class=""text"">
                        <p>اولین کسی باشید که در مورد تمام ویژگی های داخلی جدید مطلع شوید</p>
                    </div>

                </div>
            </header>

            <!--Content-->

            <div class=""container"">
                <div class=""row align-items-center"">
                    <div class=""col-md-4"">
                        <input type=""email"" class=""form-control"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 781, "\"", 789, 0);
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""ایمیل خود را وارد کنید"">
                    </div>
                    <div class=""col-md-4"">
                        <a href=""#"" class=""btn btn-clean"">اکنون مشترک شوید</a>
                    </div>
                </div>
            </div>
        </div>

    </div> <!--/container-fluid-->

</section>");
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
