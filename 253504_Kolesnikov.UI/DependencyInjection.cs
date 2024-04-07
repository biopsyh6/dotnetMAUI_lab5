using _253504_Kolesnikov.UI.Pages;
using _253504_Kolesnikov.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddTransient<CarsList>()
                .AddTransient<AdvertisementDetails>()
                .AddTransient<AddCar>()
                .AddTransient<AddAdvertisement>()
                .AddTransient<EditAdvertisement>();


            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddTransient<CarsListViewModel>()
                .AddTransient<AdvertisementDetailsViewModel>()
                .AddTransient<AddCarViewModel>()
                .AddTransient<AddAdvertisementViewModel>()
                .AddTransient<EditAdvertisementViewModel>();
            return services;
        }
    }
}
