using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MVCDataAccessLayer;
using MVCPresentationLayer.Models;
using ProductInfo = MVCPresentationLayer.Models.ProductInfo;

namespace MVCPresentationLayer.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly IProductDataService _Service;
        public List<Product> dalProducts { get; set; }

        public List<ProductInfo> mvcProducts { get; set; }

        public ProductController1(IProductDataService service)
        {
            _Service = service;
        }
        public IActionResult Display()
        {

            List<ProductInfo> mvcProducts = new List<ProductInfo>();

            dalProducts = _Service.GetAllProducts();
            foreach (var product in dalProducts)
            {
                ProductInfo product1 = new ProductInfo();
                product1.Id = product.Id;
                product1.Name = product.Name;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.Category = product.Category;
                mvcProducts.Add(product1);

            }
            return View(mvcProducts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductInfo productInfo)
        {
            Product p = new Product();
            p.Id = productInfo.Id;
            p.Name = productInfo.Name;
            p.Description = productInfo.Description;
            p.Price = productInfo.Price;
            p.Category = productInfo.Category;
            _Service.InsertProduct(p);
            return RedirectToAction("Display");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = _Service.GetProductById(id);
            if (product != null)
            {
                ProductInfo info = new ProductInfo();
                info.Id = product.Id;
                info.Name = product.Name;
                info.Description = product.Description;
                info.Price = product.Price;
                info.Category = product.Category;
                return View(info);
            }
            return RedirectToAction("Create");
        }
        [HttpPost]
        public IActionResult Delete(ProductInfo productInfo)
        {
            Product p = new Product();
            p.Id = productInfo.Id;
            p.Name = productInfo.Name;
            p.Description = productInfo.Description;
            p.Price = productInfo.Price;
            p.Category = productInfo.Category;
            _Service.DeleteProduct(p);
            return RedirectToAction("Display");
        }

        public IActionResult Edit(int id) 
        {
            var p = _Service.GetProductById(id);
            ProductInfo info = new ProductInfo();
            info.Id= p.Id;
            info.Name = p.Name;
            info.Description = p.Description;
            info.Price = p.Price;
            info.Category = p.Category;
            return View(info);

        }
        [HttpPost]
        public IActionResult Edit(ProductInfo productInfo) 
        { 
            Product p = new Product();
            p.Id = productInfo.Id;
            p.Name = productInfo.Name;
            p.Description = productInfo.Description;
            p.Price = productInfo.Price;
            p.Category = productInfo.Category;
            _Service.UpdateProduct(p);
            return RedirectToAction("Display");
        }

        public IActionResult Details(int id) 
        { 
            var x = _Service.GetProductById(id);
            ProductInfo info = new ProductInfo();
            info.Id = x.Id;
            info.Name = x.Name;
            info.Description = x.Description;
            info.Price = x.Price;
            info.Category = x.Category;
            return View(info);
        }
    }
}
