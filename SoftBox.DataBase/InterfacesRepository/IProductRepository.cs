using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.InterfacesRepository;

public interface IProductRepository : Base.IRepository<Product, Guid>
{
    public Task<IEnumerable<Product>> GetProductByOrganizationId(string organizationId);
    public Task<Product> AddProduct(Product product, CancellationToken cancel = default);
}
