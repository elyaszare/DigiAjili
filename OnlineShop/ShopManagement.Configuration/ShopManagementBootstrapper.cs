using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
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
            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
