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
    public class UserServiceFake : IUserService
    {
        private readonly List<User> _User;
        public UserServiceFake()
        {
            _User = new List<User>()
            {
                new User() {UserId=1, Name = "Amarnadh", PhoneNumber="123456"},
                new User() {UserId=2, Name = "Hareesh", PhoneNumber="232456"},
                new User() {UserId=3, Name = "Sravan", PhoneNumber="123543"},
                new User() {UserId=4, Name = "Ravikumar", PhoneNumber="213445"},
            };
        }

        public User GetUserDetailsById(int userId)
        {
              return _User.Where(a => a.UserId == userId).FirstOrDefault();
        }

        public User GetUserDetailsByName(string UserName)
        {
            return _User.Where(a => a.Name == UserName).FirstOrDefault();
        }

        public List<User> GetUsersList()
        {
            return _User.ToList();
        }

        public ResponseModel SaveUser(User userModel)
        {
            ResponseModel model = new ResponseModel();

            _User.Add(userModel);

            model.IsSuccess = true;
            model.Messsage = "User Inserted Successfully";

            return model;
        }
    }
   
}
