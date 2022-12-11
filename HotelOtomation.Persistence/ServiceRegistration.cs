using HotelOtomation.Application.Repositories;
using HotelOtomation.Domain.Entities;
using HotelOtomation.Persistence.Context;
using HotelOtomation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HotelOtomationDbContext>();
            services.AddScoped<IHotelReadRepository, HotelReadrepository>();
            services.AddScoped<IHotelWriteRepository, HotelWriteRepository>();
            services.AddScoped<ICityWriteRepository, CityWriteRepository>();
            services.AddScoped<ICityReadRepository, CityReadRepository>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HotelOtomationDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Home/Index";
                options.SlidingExpiration = true;
            });
        }
    }
}
