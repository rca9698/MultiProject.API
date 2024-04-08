

using System.Reflection;
using Application.CoinsDetail.Common.Interface;
using Application.Common.Interface;
using Infrastructure.Repositories;
using MediatR;
using MultiProject.API.ServiceFilter;

namespace MultiProject.API
{
    public static class ServiceRegistration
    {
        public static void AddServiceDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ValidateSessionFilter>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAccountRepository,AccountRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<ICoinRepository, CoinRepository>();
            services.AddTransient<IDropDownRepository, DropDownRepository>();
            services.AddTransient<ILoginSignupRepository, LoginSignupRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<ISiteDetailRepository, SiteDetailRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPassbookHistoryRepository, PassbookHistoryRepository>();
        }
    }
}
