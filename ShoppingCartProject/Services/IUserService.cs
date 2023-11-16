using ShoppingCartProject.Models;
using ShoppingCartProject.ViewModels;
using System.Collections.Generic;

namespace ShoppingCartProject.Services
{
    public interface IUserService
    {
        /// <summary>
        /// get list of all Users
        /// </summary>
        /// <returns></returns>
        List<User> GetUsersList();

        /// <summary>
        /// get Users details by User id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserDetailsById(int userId);

        /// <summary>
        /// get User details by User Name
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        User GetUserDetailsByName(string UserName);

        /// <summary>
        ///  add/edit User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        ResponseModel SaveUser(User userModel);

    }
}
