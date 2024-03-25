using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application.AdvertisementUseCases.Queries
{
    public record AddAdvertisementQuery : IRequest<int>
    {
        public AddAdvertisementQuery(string name, DateTime createdAt, string description, decimal cost,
            string imagePath, int carId)
        {
            Name = name;
            CreatedAt = createdAt;
            Description = description;
            Cost = cost;
            ImagePath = imagePath;
            CarId = carId;
        }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
    }
}
