using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Persistense.Repository
{
    public class FakeCarRepository : IRepository<Car>
    {
        List<Car> _cars;
        public FakeCarRepository()
        {
            _cars = [
                new Car(1, "Peugeot", "France", "Automatic", 2008),
                new Car(2, "Ferrari", "Italy", "Automatic", 2019),
                new Car(3, "Audi", "Germany", "Automatic", 2020)
            ];
        }
        public Task AddAsync(Car entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Car entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Car> FirstOrDefaultAsync(Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Car, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Car>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _cars);
        }

        public async Task<IReadOnlyList<Car>> ListAsync(Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Car, object>>[]? includesProperties)
        {
            return await Task.Run(() => _cars.AsQueryable().Where(filter).ToList());
        }

        public Task UpdateAsync(Car entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
