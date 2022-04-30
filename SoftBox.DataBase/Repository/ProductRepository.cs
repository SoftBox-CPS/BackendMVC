using SoftBox.DataBase.Entities;
using SoftBox.DataBase.IntarfaceRepository;

namespace SoftBox.DataBase.Repository
{
    public class ProductRepository : IProductRepository 
    {
        private readonly List<Product> _product;
        public ProductRepository()
        {
            this._product = new List<Product>();
        }

        public void DeleteProduct(Guid id)
        {
            var product = GetById(id);
            if(product == null)
            {
                throw new ArgumentException();
            }
            _product.Remove(product);
            //_product.SaveChanges();
        }

        //TODO: не понятно что с этим делать 
        public void EditProduct(Product product)
        {
            var model = _product.First(p => p.Id == product.Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _product.ToList();
        }

        public Product GetById(Guid id) => GetAll().FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            return GetAll().Where(p => p.CategoryId == id);
        }

        public void NewProduct(Product product)
        {
            _product.Add(product);
        }
    }
}
