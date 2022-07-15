using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;

namespace SoftBox.DataBase.Repository;

public class ProductRepository : Base.DbRepository<Product, Guid>, IProductRepository
{
    public ProductRepository(SoftBoxDbContext db) : base(db)
    { }

    public async Task<Product> AddProduct(Product product, CancellationToken cancel = default)
    {
        if (product is null) throw new ArgumentNullException(nameof(product));

        await db.AddAsync(product, cancel).ConfigureAwait(false);
        await db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return product;
    }


    public async Task<IEnumerable<Product>> GetProductByOrganizationId(string organizationId)
    {
        return await db.Set<Product>()
            .Include(x => x.OrganizationId.ToString() == organizationId)
            .Select(x => new Product())
            .ToArrayAsync();
    }
}
