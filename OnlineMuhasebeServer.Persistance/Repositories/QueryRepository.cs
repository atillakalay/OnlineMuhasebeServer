using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Context;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Persistance.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : Entity
    {
        private CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }

        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((CompanyDbContext cotext, string id) => cotext.Set<T>().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext, Task<T>> GetFirstCompiled =
            EF.CompileAsyncQuery((CompanyDbContext cotext) => cotext.Set<T>().FirstOrDefault());

        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, Task<T>> GetFirstByExpressionCompiled =
            EF.CompileAsyncQuery((CompanyDbContext cotext, Expression<Func<T, bool>> expression) => cotext.Set<T>().FirstOrDefault(expression));
        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return Entity.Where(expression);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await GetByIdCompiled(_context, id);
        }

        public async Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await GetFirstByExpressionCompiled(_context, expression);
        }

        public async Task<T> GetFirstAsync()
        {
            return await GetFirstCompiled(_context);
        }
    }
}
