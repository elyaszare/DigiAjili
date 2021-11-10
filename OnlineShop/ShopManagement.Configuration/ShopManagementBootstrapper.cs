using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

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

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
