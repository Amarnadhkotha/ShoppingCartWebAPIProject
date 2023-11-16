using Microsoft.AspNetCore.Mvc;
using ShoppingCartProject.Services;
using ShoppingCartProject.Models;

namespace ShoppingCartProject.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        /// <summary>
        /// get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult UsersList()
        {
            try
            {
                var users = _userService.GetUsersList();
                if (users == null)
                    return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// get employee details by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _userService.GetUserDetailsById(userId);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// save employee
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateUser")]
        public IActionResult SaveUser(User userModel)
        {
            try
            {
                var model = _userService.SaveUser(userModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
