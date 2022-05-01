using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace SoftBox.DataBase;

internal class DbContextFactory
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public DbContextFactory(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public SoftBoxDbContext Create(Type repositoryType)
    {
        var services = httpContextAccessor.HttpContext.RequestServices;

        var dbContexts = services.GetService<Dictionary<Type, SoftBoxDbContext>>();
        if (!dbContexts.ContainsKey(repositoryType))
            dbContexts[repositoryType] = services.GetService<SoftBoxDbContext>();

        return dbContexts[repositoryType];
    }
}
