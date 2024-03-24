using _253504_Kolesnikov.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Persistense.Repository
{
    internal class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;
        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if(includesProperties.Any() && includesProperties != null)
            {
                foreach(Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }
            return await query.FirstOrDefaultAsync(el => el.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any() && includesProperties != null)
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return Task.CompletedTask;
        }
    }
}
