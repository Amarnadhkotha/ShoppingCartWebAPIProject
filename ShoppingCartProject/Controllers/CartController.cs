using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartProject.Models;
using ShoppingCartProject.Services;
using ShoppingCartProject.ViewModels;

namespace ShoppingCartProject.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : Controller
    {
        ICartService _cartService;
        public CartController(ICartService service)
        {
            _cartService = service;
        }

        /// <summary>
        /// get list of all Carts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCartList()
        {
            try
            {
                var cart = _cartService.GetCartList();
                if (cart == null)
                    return NotFound();
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// get Cart details by User id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCartDetailsByUserId(int userId)
        {
            try
            {
                var cart = _cartService.GetCartDetailsByUserId(userId);
                if (cart == null)
                    return NotFound();
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get Cart details by Product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCartDetailsByProductId(int productId)
        {
            try
            {
                var cart = _cartService.GetCartDetailsByProductId(productId);
                if (cart == null)
                    return NotFound();
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get Cart details by Product id and User Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCartDetailsByProductAndUserID(int productId, int UserId)
        {
            try
            {
                var cart = _cartService.GetCartDetailsByProductAndUserID(productId, UserId);
                if (cart == null)
                    return NotFound();
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        /// <summary>
        ///  add/edit Cart
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateCartItems")]
        public IActionResult SaveCart(CreateCart cartModel)
        {
            try
            {
                var cart = _cartService.SaveCart(cartModel);
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///  Delete Cart Item
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("DeleteCartItems")]
        public IActionResult DeleteCartItem(CreateCart cartModel)
        {
            try
            {
                var cart = _cartService.DeleteCartItem(cartModel);
                if (cart == null)
                    return NotFound();
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
