using ShoppingCartProject.Models;
using ShoppingCartProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCartProject.ViewModels;

namespace ShoppingCartProject.Services
{
    public class UserService : IUserService
    {
        private ShoppingCartContext _context;
        public UserService(ShoppingCartContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get list of all Users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsersList()
        {
            List<User> userList;
            try
            {
                userList = _context.Set<User>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }


        /// <summary>
        /// get User details by User id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserDetailsById(int userId)
        {
            User user;
            try
            {
                user = _context.Find<User>(userId);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        /// <summary>
        /// get User details by User Name
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public User GetUserDetailsByName(string UserName)
        {
            User user;
            try
            {
                user = GetUsersList().Find(x => x.Name == UserName);


            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }


        /// <summary>
        ///  add/edit User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public ResponseModel SaveUser(User userModel)
        {

            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUserDetailsById(userModel.UserId);
                if (_temp == null)
                {
                    User user = GetUserDetailsByName(userModel.Name);
                    if (user == null)
                    {
                        _context.Users.Add(userModel);
                        model.Messsage = "User Inserted Successfully";
                    }
                    else
                    {
                        user.Name = userModel.Name;
                        user.PhoneNumber = userModel.PhoneNumber;
                        _context.Update<User>(user);
                        model.Messsage = "User Update Successfully";
                    }
                }
                else
                {
                    _temp.Name = userModel.Name;
                    _temp.PhoneNumber = userModel.PhoneNumber;

                    _context.Users.Update(_temp);
                    model.Messsage = "User Update Successfully";
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        
    }
}
