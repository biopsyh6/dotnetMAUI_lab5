using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            await unitOfWork.CarRepository.AddAsync(new Car(1, "Peugeot 5008", "France", "Automatic", 2022));
            await unitOfWork.CarRepository.AddAsync(new Car(2, "Audi A5", "Germany", "Automatic", 2019));
            await unitOfWork.CarRepository.AddAsync(new Car(3, "Renault Captur", "France", "Manual Transmission", 2017));

            await unitOfWork.SaveAllAsync();

            await unitOfWork.AdvertisementRepository.AddAsync(new Advertisement(1, "Sale Peugeot", new DateTime(2024, 6, 14), "SUV 5 doors, front wheel drive, blue, deregistered",
                "Resources/Images/peugeot.jpg", 1, 20000));
            await unitOfWork.AdvertisementRepository.AddAsync(new Advertisement(2, "Peugeot Minsk", new DateTime(2024, 7, 20), "SUV 5 doors, front-wheel drive, gray, deregistered",
                "Resources/Images/peugeot1.jpg", 1, 20000));
            await unitOfWork.AdvertisementRepository.AddAsync(new Advertisement(3, "5008 Sale", new DateTime(2024, 6, 24), "SUV 7 doors, front-wheel drive, yellow, deregistered",
                "Resources/Images/peugeot2.jpg", 1, 24000));

            await unitOfWork.AdvertisementRepository.AddAsync(new Advertisement(4, "Sale auto Audi", new DateTime(2023, 5, 12), "liftback, permanent all-wheel drive, red",
                "Resources/Images/audi.jpg", 2, 17000));
            await unitOfWork.AdvertisementRepository.AddAsync(new Advertisement(5, "Audi Minsk", new DateTime(2022, 4, 15), "liftback, front-wheel drive, silver",
                "Resources/Images/audi2.jpg", 2, 31000));

            await unitOfWork.AdvertisementRepository.AddAsync(new Advertisement(6, "Renault Sale", new DateTime(2019, 7, 25), "SUV 5 doors, front wheel drive, blue",
                "Resources/Images/renault.jpg", 3, 14000));
            await unitOfWork.AdvertisementRepository.AddAsync(new Advertisement(7, "Renault Brest", new DateTime(2020, 4, 17), "SUV 5 doors, front wheel drive, gray",
                "Resources/Images/renault2.jpg", 3, 13500));

            await unitOfWork.SaveAllAsync();
        }
    }
}
