using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, Task<T>> GetById =
            EF.CompileAsyncQuery((CompanyDbContext cotext, string id) => cotext.Set<T>().FirstOrDefault(p => p.Id == id));


        private CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }
        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }

        public async Task RemoveByIdAsync(string id)
        {
            T entity = await GetById(_context, id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            Entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }
    }
}
