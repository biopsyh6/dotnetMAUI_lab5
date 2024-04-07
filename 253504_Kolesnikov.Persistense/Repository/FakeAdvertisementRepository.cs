using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _253504_Kolesnikov.Domain.Abstractions;
using _253504_Kolesnikov.Domain.Entities;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _253504_Kolesnikov.Persistense.Repository
{
    public class FakeAdvertisementRepository : IRepository<Advertisement>
    {
        List<Advertisement> _advertisements;
        public FakeAdvertisementRepository()
        {
            _advertisements =
                [
                    new Advertisement(1, "Sell", DateTime.Now, "Sell the auto", "", 1, 5000),
                    new Advertisement(2, "Sell 2", DateTime.Now, "Sell the auto 2", "", 2, 10000),
                    new Advertisement(3, "Sell 3", new DateTime(2015, 7, 20), "Sell the auto 3", "", 3, 15000),
                    new Advertisement(4, "Sell 4", new DateTime(2014, 6, 23), "Sell the auto 4", "", 1, 17000),
                    new Advertisement(5, "Sell 5", new DateTime(2019, 10, 15), "Sell the auto 5", "", 1, 18000)
                ];
        }
        public Task AddAsync(Advertisement entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Advertisement entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> FirstOrDefaultAsync(Expression<Func<Advertisement, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Advertisement, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Advertisement>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _advertisements);
        }

        public Task<IReadOnlyList<Advertisement>> ListAsync(Expression<Func<Advertisement, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Advertisement, object>>[]? includesProperties)
        {
            var data = _advertisements.AsQueryable();
            var filteredData = data.Where(filter).ToList();
            IReadOnlyList<Advertisement> result = filteredData;
            return Task.FromResult(result);
        }

        public Task UpdateAsync(Advertisement entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
