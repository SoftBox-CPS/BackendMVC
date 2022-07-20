using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;

namespace SoftBox.DataBase.Repository;

public class ProductRepository : Base.DbNamedRepository<Product, Guid>, IProductRepository
{
    public ProductRepository(SoftBoxDbContext db) : base(db)
    { }

    public async Task<IEnumerable<Product>> GetProductByOrganizationName(string organizationName)
    {
        return await db.Set<Product>()
            .Include(x => x.Organization)
            .Where(x => x.Organization.Name == organizationName)
            .ToArrayAsync();
    }
}
