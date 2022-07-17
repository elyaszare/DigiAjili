using _0_Framework.Infrastructure;
using _01_Query.Contracts;
using _01_Query.Contracts.Product;
using _01_Query.Contracts.ProductCategory;
using _01_Query.Contracts.Slides;
using _01_Query.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Services;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using ShopManagement.Infrastructure.InventoryAcl;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();


            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();


            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();


            service.AddTransient<ISlideRepository, SlideRepository>();
            service.AddTransient<ISlideApplication, SlideApplication>();

            service.AddTransient<IOrderApplication, OrderApplication>();
            service.AddTransient<IOrderRepository, OrderRepository>();


            service.AddSingleton<ICartService, CartService>();

            service.AddTransient<ISlideQuery, SlideQuery>();


            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();

            service.AddTransient<IProductQuery, ProductQuery>();

            service.AddTransient<IPermissionExposer, ShopPermissionExposer>();

            service.AddTransient<ICartCalculateService, CartCalculateService>();

            service.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
