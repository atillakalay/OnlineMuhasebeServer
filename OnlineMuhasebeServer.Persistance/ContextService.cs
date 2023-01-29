using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appDbContext;

        public ContextService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DbContext createDbContextInstance(string companyId)
        {
            Company company = _appDbContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}
