using Microsoft.Identity.Client;
using ShoppingCartProject.Models;
using ShoppingCartProject.Services;
using ShoppingCartProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProjectTests
{
    public  class ProductServiceFake :IProductService
    {
        private readonly List<Product> _Product;
        public ProductServiceFake()
        {
            _Product = new List<Product>()
            {
                new Product() {ProductId=1, ProductName = "KeyBoard", Price=100, InStock=true },
                new Product() {ProductId=2, ProductName = "Mouse", Price=50, InStock=true },
                new Product() {ProductId=3, ProductName = "Laptop", Price=1000, InStock=true },
                new Product() {ProductId=4, ProductName = "Speaker", Price=50, InStock=true },
            };

        }
        public List<Product> GetProductsList()
        {
            return _Product.ToList();
        }

        public Product GetProductDetailsById(int productId)
        {
            return _Product.Where(a => a.ProductId == productId).FirstOrDefault();
        }

        public Product GetProductDetailsByName(string productName)
        {
            return _Product.Where(a => a.ProductName == productName).FirstOrDefault();
        }

        

        public ResponseModel SaveProduct(Product productModel)
        {
            ResponseModel model = new ResponseModel();

            _Product.Add(productModel);

            model.IsSuccess = true;
            model.Messsage = "Product Inserted Successfully";

            return model;
        }

    }
}
