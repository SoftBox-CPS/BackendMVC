using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.InterfacesRepository;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    IEnumerable<Product> GetProductsByCategoryId(int id);
    Product GetById(Guid id);
    void NewProduct(Product product);
    void EditProduct(Product product);
    void DeleteProduct(Guid id);
}
