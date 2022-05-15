using SoftBox.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBox.DataBase.InterfacesRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetProductsByCategoryId(int id);
        Product GetById(Guid id);
        void NewProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Guid id);
    }
}
