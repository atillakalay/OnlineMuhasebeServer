using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebeServer.Domain
{
    public interface IContextService
    {
        DbContext createDbContextInstance(string companyId);
    }
}
