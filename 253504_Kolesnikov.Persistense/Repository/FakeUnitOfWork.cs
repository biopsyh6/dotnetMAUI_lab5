using _253504_Kolesnikov.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Car>> _carRepository;
        private readonly Lazy<IRepository<Advertisement>> _advertisementRepository;
        public FakeUnitOfWork(/*AppDbContext context*/)
        {
            //_context = context;
            _carRepository = new Lazy<IRepository<Car>>(() => new FakeCarRepository());
            _advertisementRepository = new Lazy<IRepository<Advertisement>>(() => new FakeAdvertisementRepository());
        }
        public IRepository<Car> CarRepository => _carRepository.Value;

        public IRepository<Advertisement> AdvertisementRepository => _advertisementRepository.Value;

        public async Task CreateDataBaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task DeleteDataBaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
