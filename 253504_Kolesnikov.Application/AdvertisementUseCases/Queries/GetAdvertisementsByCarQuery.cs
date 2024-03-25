using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application.AdvertisementUseCases.Queries
{
    public record GetAdvertisementsByCarQuery : IRequest<List<Advertisement>>
    {
        public GetAdvertisementsByCarQuery(int carId) 
        {
            CarId = carId;
        }
        public int CarId { get; set; }
    }
}
