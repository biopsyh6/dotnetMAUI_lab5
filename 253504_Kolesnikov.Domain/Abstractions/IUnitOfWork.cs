using _253504_Kolesnikov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Car> CarRepository { get; } 
        IRepository<Advertisement> AdvertisementRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
