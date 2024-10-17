using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDataAccessLayer
{
    public class ProductDataService : IProductDataService
    {
        private ProductContext _context;
        public ProductDataService() 
        {
            _context = new ProductContext();
        }

        public void DeleteProduct(Product product)
        {
            Product p = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            Product product = _context.Products.FirstOrDefault();
            return product;
        }

        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var p = _context.Products.Find(product.Id);
            p.Id= product.Id; 
            p.Name= product.Name;   
            p.Description= product.Description;
            p.Price= product.Price;
            p.Category = product.Category;
            _context.SaveChanges();
        }
    }
}
