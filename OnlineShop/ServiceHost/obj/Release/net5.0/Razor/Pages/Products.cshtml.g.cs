#pragma checksum "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdbcd6e4f52e637461a9c7ea50ed72f5f76eb6d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Products), @"mvc.1.0.razor-page", @"/Pages/Products.cshtml")]
namespace ServiceHost.Pages
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdbcd6e4f52e637461a9c7ea50ed72f5f76eb6d8", @"/Pages/Products.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1d277691ff97276995da980fa12d1415fd1863d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Products : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
  
    ViewData["Title"] = "محصولات";
    ViewData["keywords"] = "خرید پسته, پسته,درخت پسته,پسته مه ولات,پسته اکبری,پسته تازه,خرید آنلاین پسته,خرید آجیل,آنواع آجیل";
    ViewData["metaDescription"] = "خرید آنلاین پسته و انواع آجیل";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"products pt-0\">\r\n    <!--Header-->\r\n\r\n    <header>\r\n        <div class=\"container\">\r\n            <ol class=\"breadcrumb\">\r\n                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cdbcd6e4f52e637461a9c7ea50ed72f5f76eb6d84221", async() => {
                WriteLiteral("خانه");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                <li class=""breadcrumb-item active"" aria-current=""page"">محصولات ما</li>
            </ol>
            <h1 class=""title"">محصولات ما</h1>
            <div class=""text"">
                <p>بهترین و با کیفیت ترین پسته شرق کشور در اختیار شماست!</p>
            </div>
        </div>
    </header>

    <!-- ======================== Icons ======================== -->
    <!--Content-->

    <div class=""container"">
        <div class=""row"">

            <!--Right content-->

            <div class=""col-12"">

                <!--Sort bar-->


                <!--Products collection-->

                <div class=""row"">

                    <!--Product item-->

");
#nullable restore
#line 44 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                     foreach (var product in Model.Products)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-6 col-lg-4"">
                            <article>
                                <div class=""info"">
                                    <span class=""add-favorite"">
                                        <a href=""javascript:void(0);"" data-title=""افزودن به علاقه مندی ها"" data-title-added=""افزودن به  لیست علاقه مندی "">
                                            <i class=""icon icon-heart""></i>
                                        </a>
                                    </span>
                                </div>
                                <div class=""btn btn-add"">
                                    <i class=""icon icon-cart""></i>
                                </div>
                                <div class=""figure-grid"">
");
#nullable restore
#line 59 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                     if (product.HasDiscount)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"badge badge-warning\" style=\"font-size: 110%\">");
#nullable restore
#line 61 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                                                                             Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%-</span>\r\n");
#nullable restore
#line 62 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"image\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cdbcd6e4f52e637461a9c7ea50ed72f5f76eb6d88220", async() => {
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cdbcd6e4f52e637461a9c7ea50ed72f5f76eb6d88519", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2570, "~/ProductPictures/", 2570, 18, true);
#nullable restore
#line 65 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
AddHtmlAttributeValue("", 2588, product.Picture, 2588, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 65 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
AddHtmlAttributeValue("", 2611, product.PictureAlt, 2611, 19, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 65 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
AddHtmlAttributeValue("", 2639, product.PictureTitle, 2639, 21, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                                                 WriteLiteral(product.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"text\">\r\n                                        <h2 class=\"title h4\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cdbcd6e4f52e637461a9c7ea50ed72f5f76eb6d813179", async() => {
#nullable restore
#line 70 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                                                                           Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                                                     WriteLiteral(product.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </h2>\r\n                                        <sub>");
#nullable restore
#line 72 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                        Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</sub>\r\n");
#nullable restore
#line 73 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                         if (product.HasDiscount)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <sup>");
#nullable restore
#line 75 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                            Write(product.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</sup>\r\n");
#nullable restore
#line 76 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"description clearfix\">\r\n                                            <h3>\r\n                                                ");
#nullable restore
#line 79 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                                           Write(product.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </h3>
                                        </span>
                                    </div>
                                </div>
                            </article>
                        </div>
");
#nullable restore
#line 86 "D:\PistachioShop\OnlineShop\OnlineShop\ServiceHost\Pages\Products.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>

                <!--Pagination-->

                <div class=""pagination-wrapper"">
                    <ul class=""pagination justify-content-center"">
                        <li class=""page-item""><a class=""page-link"" href=""#"">&laquo;</a></li>
                        <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
                        <li class=""page-item""><a class=""page-link active"" href=""#"">2</a></li>
                        <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                        <li class=""page-item""><a class=""page-link"" href=""#"">&raquo;</a></li>
                    </ul>
                </div>

            </div> <!--/product items-->

        </div><!--/row-->

    </div>

</section>



<!-- ========================  Newsletter ======================== -->

<section class=""banner"">

    <div class=""container-fluid"">

        <div class=""banner-image"" style=""background-image:url(/Theme/assets/images/ga");
            WriteLiteral(@"llery-1.jpg)"">
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
            BeginWriteAttribute("value", " value=\"", 5481, "\"", 5489, 0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.ProductsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.ProductsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.ProductsModel>)PageContext?.ViewData;
        public ServiceHost.Pages.ProductsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
