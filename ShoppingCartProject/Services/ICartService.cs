using ShoppingCartProject.Models;
using ShoppingCartProject.ViewModels;

namespace ShoppingCartProject.Services
{
    public interface ICartService
    {

        /// <summary>
        /// get list of all Carts
        /// </summary>
        /// <returns></returns>
        List<Cart> GetCartList();

        /// <summary>
        /// get Cart details by User id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Cart> GetCartDetailsByUserId(int userId);

        /// <summary>
        /// get Cart details by Product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        List<Cart> GetCartDetailsByProductId(int productId);

        /// <summary>
        /// get Cart details by Product id and User Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Cart GetCartDetailsByProductAndUserID(int productId, int UserId);

        /// <summary>
        ///  add/edit Cart
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        ResponseModel SaveCart(CreateCart cartModel);

        /// <summary>
        /// delete CartItem
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        ResponseModel DeleteCartItem(CreateCart cartModel);
    }
}
