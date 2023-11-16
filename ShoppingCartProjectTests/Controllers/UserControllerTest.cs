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
    public class UserControllerTest
    {
        private readonly UserController _userController;
        private readonly IUserService _userService;
        public UserControllerTest()
        {
            _userService = new UserServiceFake();
            _userController = new UserController(_userService);
        }

        [Fact]
        public void UsersList_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _userController.UsersList();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void UsersList_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _userController.UsersList() as OkObjectResult;
            // Assert
            Assert.IsType<List<User>>(okResult.Value);


            var items = Assert.IsType<List<User>>(okResult.Value);

            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void GetUserById_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _userController.GetUserById(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetUserById_WhenCalled_ReturnsNotOkResult()
        {
            // Act
            var okResult = _userController.GetUserById(0);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void SaveUser_WhenCalled_ReturnsOkResult()
        {
            User user = new User() { UserId = 5, Name = "test1", PhoneNumber = "123456" };

            // Act
            var okResult = _userController.SaveUser(user);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void SaveUser_WhenCalled_ReturnsNotOkResult()
        {
            User user = null;

            // Act
            var okResult = _userController.SaveUser(user);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

    }
}

