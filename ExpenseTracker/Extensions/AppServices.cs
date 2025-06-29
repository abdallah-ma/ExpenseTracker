using ExpenseTracker.BLL;
using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.BLL.Repositories;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.PL.Helpers;

namespace ExpenseTracker.PL.Extensions
{
    public static class AppServices
    {

        public static void AddServices(this IServiceCollection Services)
        {

            Services.AddControllersWithViews();
            

            Services.AddScoped<IUnitOfWork, UnitOfWork>();
                


            Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
        }

    }
}
