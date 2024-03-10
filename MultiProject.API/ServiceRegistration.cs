﻿

using System.Reflection;
using Application.CoinsDetail.Common.Interface;
using Application.Common.Interface;
using Infrastructure.Repositories;
using MediatR;

namespace MultiProject.API
{
    public static class ServiceRegistration
    {
        public static void AddServiceDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IAccountRepository,AccountRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<ICoinRepository, CoinRepository>();
            services.AddTransient<IDropDownRepository, DropDownRepository>();
            services.AddTransient<ILoginSignupRepository, LoginSignupRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<ISiteDetailRepository, SiteDetailRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
