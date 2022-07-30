using _0_Framework.Infrastructure;
using DiscountManagement.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Configuration.Permissions;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            service.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            service.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            service.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            service.AddTransient<IPermissionExposer, DiscountPermissionExposer>();
            service.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
