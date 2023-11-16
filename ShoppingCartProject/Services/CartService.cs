using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ShoppingCartProject.Models;
using ShoppingCartProject.ViewModels;
using System.Collections.Generic;

namespace ShoppingCartProject.Services
{
    public class CartService : ICartService
    {
        private ShoppingCartContext _context;
        public CartService(ShoppingCartContext context)
        {
            _context = context;
            
        }

        /// <summary>
        /// get list of all Carts
        /// </summary>
        /// <returns></returns>
        public List<Cart> GetCartList()
        {
            List<Cart> cartList;
            try
            {
                cartList = _context.Cart.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return cartList;

        }

        /// <summary>
        /// get Cart details by User id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Cart> GetCartDetailsByUserId(int userId)
        {
            List<Cart> cartList;
            try
            {

                cartList = _context.Cart.ToList().FindAll(x => x.UserId == userId);
            }
            catch (Exception)
            {
                throw;
            }
            return cartList;
        }

        /// <summary>
        /// get Cart details by Product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<Cart> GetCartDetailsByProductId(int productId)
        {
            List<Cart> cartList;
            try
            {
                cartList = _context.Cart.ToList().FindAll(x => x.ProductId == productId);
            }
            catch (Exception)
            {
                throw;
            }
            return cartList;
        }

        /// <summary>
        /// get Cart details by Product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Cart GetCartDetailsByProductAndUserID(int productId, int UserId)
        {
            Cart cart;
            try
            {
                cart = (Cart)_context.Cart.ToList().Find(x => (x.ProductId == productId) && (x.UserId == UserId));
            }
            catch (Exception)
            {
                throw;
            }
            return cart;
        }

        /// <summary>
        ///  add/edit Cart
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        public ResponseModel SaveCart(CreateCart cartModel)
        {
            ResponseModel model = new ResponseModel();
            Boolean Flag = true;
            try
            {

                var product = _context.Products.Find(cartModel.ProductId);
                if(product==null)
                {
                    model.IsSuccess = false;
                    model.Messsage = string.Format("Product with ID {0} Not found",cartModel.ProductId);
                    return model;
                }

                var user = _context.Users.Find(cartModel.UserId);
                if (user == null)
                {
                    model.IsSuccess = false;
                    model.Messsage = string.Format("User with ID {0} Not found", cartModel.UserId);
                    return model;
                }


                Cart _temp = GetCartDetailsByProductAndUserID(product.ProductId, user.UserId);

                List<Cart> CartProduct = GetCartDetailsByProductId(product.ProductId);

                Boolean productInStock = false;
                if (CartProduct.Count > 0)
                    productInStock = CartProduct[0].Products.InStock;
                else
                    productInStock = true;

                if (cartModel.Quantity <= 0)
                    cartModel.Quantity = 1;

                int ProductTotalQuantityUsed = 0;
                if (_temp != null)
                {
                    foreach (Cart cart in CartProduct)
                    {
                        ProductTotalQuantityUsed = ProductTotalQuantityUsed + cart.Quantity;
                    }
                    ProductTotalQuantityUsed = ProductTotalQuantityUsed + cartModel.Quantity;
                }
                else
                    ProductTotalQuantityUsed = ProductTotalQuantityUsed + cartModel.Quantity;

                if (productInStock == false)
                {
                    model.IsSuccess = false;
                    model.Messsage = "Cound not Insert into the Cart Item as Stock on the product is not available.";
                    Flag = false;
                }

                if (Flag == true)
                {
                    if (_temp != null)
                    {
                        _temp.ProductId = cartModel.ProductId;
                        _temp.UserId = cartModel.UserId;
                        _temp.Quantity = ProductTotalQuantityUsed;

                        _context.ChangeTracker.Clear();
                        _context.Update<Cart>(_temp);
                        model.Messsage = "Cart Update Successfully";
                    }
                    else
                    {
                        Cart InsertCart = new Cart();
                        

                        InsertCart.ProductId = product.ProductId;
                        InsertCart.UserId = user.UserId;
                        InsertCart.Quantity = cartModel.Quantity;

                        _context.ChangeTracker.Clear();
                        _context.Add<Cart>(InsertCart);
                        model.Messsage = "Cart Inserted Successfully";
                    
                    }
                     _context.SaveChanges();
                    model.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        /// <summary>
        /// delete CartItem
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        public ResponseModel DeleteCartItem(CreateCart cartModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                
                var product = _context.Products.Find(cartModel.ProductId);
                if (product == null)
                {
                    model.IsSuccess = false;
                    model.Messsage = string.Format("Product with ID {0} Not found", cartModel.ProductId);
                    return model;
                }

                var user = _context.Users.Find(cartModel.UserId);
                if (user == null)
                {
                    model.IsSuccess = false;
                    model.Messsage = string.Format("User with ID {0} Not found", cartModel.UserId);
                    return model;
                }

                Cart _temp = GetCartDetailsByProductAndUserID(product.ProductId, user.UserId);
                if (_temp != null)
                {
                    List<Cart> CartProduct = GetCartDetailsByProductId(product.ProductId);
                    Boolean productInStock = false;
                    if (CartProduct.Count > 0)
                        productInStock = CartProduct[0].Products.InStock;
                    else
                        productInStock = true;

                    if (cartModel.Quantity <= 0)
                        cartModel.Quantity = -1;
                    else
                        cartModel.Quantity = -(cartModel.Quantity);

                    int ProductTotalQuantityUsed = 0;
                    foreach (Cart cart in CartProduct)
                    {
                        ProductTotalQuantityUsed = ProductTotalQuantityUsed + cart.Quantity;
                    }
                    ProductTotalQuantityUsed = ProductTotalQuantityUsed + cartModel.Quantity;

                    if (ProductTotalQuantityUsed <= 0)
                    {
                        _context.Cart.Remove(_temp);
                        _context.SaveChanges();
                        model.IsSuccess = true;
                        model.Messsage = "Cart item Deleted Successfully";
                    }
                    else
                    {
                        _temp.ProductId = cartModel.ProductId;
                        _temp.UserId = cartModel.UserId;
                        _temp.Quantity = ProductTotalQuantityUsed;

                        _context.ChangeTracker.Clear();
                        _context.Cart.Update(_temp);
                        _context.SaveChanges();
                        model.IsSuccess = true;
                        model.Messsage = "Cart Update Successfully";
                    }

                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Product Not Found";
                }

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
