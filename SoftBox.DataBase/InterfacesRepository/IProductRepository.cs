using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.InterfacesRepository;

public interface IProductRepository : Base.INamedRepository<Product, Guid>
{
    public Task<IEnumerable<Product>> GetProductByOrganizationName(string organizationName);
}
