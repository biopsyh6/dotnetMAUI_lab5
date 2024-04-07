using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Domain.Entities
{
    public class Advertisement : Entity
    {
        private Advertisement() { }
        public Advertisement(int id, string name, DateTime createAt, string description, string imagePath, int carId, decimal cost)
        {
            Id = id;
            Name = name;
            CreatedAt = createAt;
            Description = description;
            Cost = cost;
            ImagePath = imagePath;
            CarId = carId;
        }
        public string ?Name { get; set; }
        public decimal Cost { get; /*private*/ set; }
        public string ?Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CarId { get; /*private*/ set; }
        public Car Car { get; set; }
        public string ?ImagePath { get; set; }
        public void addToCar(int carId)
        {
            if (carId <= 0) return;
            CarId = carId;
        }
        public void removeFromCar() { CarId = 0; }
        public void changeCost(decimal cost)
        {
            if(cost < 0) return;
            Cost = cost;
        }
    }
}
