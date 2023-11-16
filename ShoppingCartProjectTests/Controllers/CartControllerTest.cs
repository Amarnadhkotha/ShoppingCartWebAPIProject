using Microsoft.AspNetCore.Mvc;
using ShoppingCartProject.Controllers;
using ShoppingCartProject.Models;
using ShoppingCartProject.Services;
using ShoppingCartProjectTests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCartProjectTests.Controllers
{
    public class CartControllerTest 
    {
        private readonly CartController _cartController;
        private readonly ICartService _cartService;
        public CartControllerTest()
        {
            _cartService = new CartServiceFake();
            _cartController = new CartController(_cartService);
        }

        [Fact]
        public void CartList_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _cartController.GetCartList();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void CartList_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _cartController.GetCartList() as OkObjectResult;
            // Assert
            Assert.IsType<List<User>>(okResult.Value);


            var items = Assert.IsType<List<User>>(okResult.Value);

            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void GetCartDetailsByUserId_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _cartController.GetCartDetailsByUserId(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetCartDetailsByUserId_WhenCalled_ReturnsNotOkResult()
        {
            // Act
            var okResult = _cartController.GetCartDetailsByUserId(0);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetCartDetailsByProductId_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _cartController.GetCartDetailsByProductId(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetCartDetailsByProductId_WhenCalled_ReturnsNotOkResult()
        {
            // Act
            var okResult = _cartController.GetCartDetailsByProductId(0);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetCartDetailsByProductAndUserID_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _cartController.GetCartDetailsByProductAndUserID(1,1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetCartDetailsByProductAndUserID_WhenCalled_ReturnsNotOkResult()
        {
            // Act
            var okResult = _cartController.GetCartDetailsByProductAndUserID(0,0);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void SaveCart_WhenCalled_ReturnsOkResult()
        {
            CreateCart cart = new CreateCart() { ProductId = 1, UserId = 1, Quantity = 10 };

            // Act
            var okResult = _cartController.SaveCart(cart);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void SaveCart_WhenCalled_ReturnsNotOkResult()
        {
            CreateCart cart = null;

            // Act
            var okResult = _cartController.SaveCart(cart);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }


        [Fact]
        public void DeleteCartItem_WhenCalled_ReturnsOkResult()
        {
            CreateCart cart = new CreateCart() { ProductId = 1, UserId = 1, Quantity = 10 };

            // Act
            var okResult = _cartController.DeleteCartItem(cart);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void DeleteCartItem_WhenCalled_ReturnsNotOkResult()
        {
            CreateCart cart = null;

            // Act
            var okResult = _cartController.DeleteCartItem(cart);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

    }
}
