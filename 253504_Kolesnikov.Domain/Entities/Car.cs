using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Domain.Entities
{
    public class Car : Entity
    {
        public string ?Name { get; set; }
        public string ?Country { get; set; }
        public string ?Description { get; set; }
        public int ?Year { get; set; }

        //private List<Advertisement> _advertisements = new();
        //public IReadOnlyList<Advertisement> Advertisements { get => _advertisements.AsReadOnly(); }
        public List<Advertisement> Advertisements { get; private set; } = [];
        public Car() { }
        public Car(int id, string name, string country, string description, int year) 
        {
            Id = id;
            Name = name;
            Country = country;
            Description = description;
            Year = year;
        }
        public void AddAdvertisement(Advertisement advertisement)
        {
            Advertisements.Add(advertisement);
        }
        public string GetCountryYear()
        {
            return $"{Country}, {Year}";
        }
        public string GetDescription()
        {
            return $"{Description}";
        }
    }
}
