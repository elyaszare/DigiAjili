#pragma checksum "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cd17246ef7fccbf430e945d9f603eaf669ee889"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.Slide.Pages_Shared_Components_Slide_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/Slide/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.Slide
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd17246ef7fccbf430e945d9f603eaf669ee889", @"/Pages/Shared/Components/Slide/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1d277691ff97276995da980fa12d1415fd1863d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_Slide_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_Query.Contracts.Slides.SlideQueryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<section class=\"header-content\">\r\n\r\n    <h2 class=\"d-none\">عنصر کشویی</h2>\r\n\r\n    <div class=\"container-fluid\">\r\n\r\n        <div class=\"owl-slider owl-carousel owl-theme\" data-autoplay=\"true\">\r\n            <!--Slide item-->\r\n");
#nullable restore
#line 12 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"item d-flex align-items-center\"");
            BeginWriteAttribute("onclick", "onclick=\"", 405, "\"", 441, 3);
            WriteAttributeValue("", 414, "location.href=\'", 414, 15, true);
#nullable restore
#line 14 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
WriteAttributeValue("", 429, item.Link, 429, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 439, "\';", 439, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("style", " style=\"", 442, "\"", 502, 4);
            WriteAttributeValue("", 450, "background-image:", 450, 17, true);
            WriteAttributeValue(" ", 467, "url(ProductPictures/", 468, 21, true);
#nullable restore
#line 14 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
WriteAttributeValue("", 488, item.Picture, 488, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 501, ")", 501, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                        <div class=""container"">
                            <div class=""caption"">
                                <div class=""animated"" data-start=""fadeInUp"">
                                    <div class=""promo pt-3"">
                                        <div class=""title title-sm p-0"" style=""font-size: 45px"">");
#nullable restore
#line 19 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                                                                                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"animated\" data-start=\"fadeInUp\" style=\"font-size: 25px\">\r\n                                    ");
#nullable restore
#line 23 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                               Write(item.Heading);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"animated\" data-start=\"fadeInUp\" style=\"font-size: 20px\">\r\n                                    ");
#nullable restore
#line 26 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                               Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"animated\" data-start=\"fadeInUp\">\r\n                                    <div class=\"pt-3\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 1504, "\"", 1521, 1);
#nullable restore
#line 30 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
WriteAttributeValue("", 1511, item.Link, 1511, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" class=\"btn btn-outline-light\">");
#nullable restore
#line 30 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                                                                                                      Write(item.BtnText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </div>\r\n                                </div>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 37 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div> <!--/owl-slider-->\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_Query.Contracts.Slides.SlideQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
