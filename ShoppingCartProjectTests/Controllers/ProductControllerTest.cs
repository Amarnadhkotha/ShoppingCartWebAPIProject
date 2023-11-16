using Microsoft.AspNetCore.Mvc;
using ShoppingCartProject.Controllers;
using ShoppingCartProject.Models;
using ShoppingCartProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCartProjectTests.Controllers
{
    public class ProductControllerTest
    {
        private readonly ProductController _productController;
        private readonly IProductService _productService;
        public ProductControllerTest()
        {
            _productService = new ProductServiceFake();
            _productController = new ProductController(_productService);
        }

        [Fact]
        public void ProductList_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _productController.ProductList();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void ProductList_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _productController.ProductList() as OkObjectResult;
            // Assert
            Assert.IsType<List<User>>(okResult.Value);


            var items = Assert.IsType<List<User>>(okResult.Value);

            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void GetProductById_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _productController.GetProductById(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetProductById_WhenCalled_ReturnsNotOkResult()
        {
            // Act
            var okResult = _productController.GetProductById(0);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        


        [Fact]
        public void SaveProduct_WhenCalled_ReturnsOkResult()
        {
            Product product = new Product() { ProductId = 6, ProductName = "Charger", Price = 70, InStock = true };

            // Act
            var okResult = _productController.SaveUser(product);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void SaveUser_WhenCalled_ReturnsNotOkResult()
        {
            Product product = null;

            // Act
            var okResult = _productController.SaveUser(product);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
