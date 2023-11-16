using ShoppingCartProject.Models;
using ShoppingCartProject.Services;
using ShoppingCartProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ShoppingCartProjectTests.Services
{
    public class CartServiceFake : ICartService
    {
        private readonly List<Cart> _cart;
        public CartServiceFake()
        {
            _cart = new List<Cart>()
            {
                new Cart() {CartId=1, ProductId = 1, UserId=1, Quantity=10 },
                new Cart() {CartId=2, ProductId = 2, UserId=1, Quantity=5 },
                new Cart() {CartId=3, ProductId = 1, UserId=2, Quantity=20 },
                new Cart() {CartId=4, ProductId = 2, UserId=2, Quantity=10 },
            };
            
        }

        public List<Cart> GetCartList()
        {
            return _cart.ToList();
        }

        public List<Cart> GetCartDetailsByProductId(int productId)
        {
            return _cart.Where(a => a.ProductId == productId).ToList();
        }
        public List<Cart> GetCartDetailsByUserId(int UserId)
        {
            return _cart.Where(a => a.UserId == UserId).ToList();
        }

        public Cart GetCartDetailsByProductAndUserID(int productId, int UserId)
        {
            return _cart.Where(a => (a.ProductId == productId) && (a.UserId == UserId)).FirstOrDefault();
        }
      
        public ResponseModel SaveCart(CreateCart cartModel)
        {
            ResponseModel model = new ResponseModel();

            int Maxid = (from i in _cart
                            let maxId = _cart.Max(m => m.CartId)
                            where i.CartId == maxId
                            select i).FirstOrDefault().CartId + 1;

            Cart Cart = new Cart() { CartId = Maxid, ProductId = cartModel.ProductId, UserId = cartModel.UserId, Quantity = cartModel.Quantity };

            _cart.Add(Cart);

            return model;
        }

        public ResponseModel DeleteCartItem(CreateCart cartModel)
        {
            ResponseModel model = new ResponseModel();

            int Maxid = (from i in _cart
                         where (i.ProductId == cartModel.ProductId) && (i.UserId == cartModel.UserId)
                         select i).FirstOrDefault().CartId;

            Cart Cart = new Cart() { CartId = Maxid, ProductId = cartModel.ProductId, UserId = cartModel.UserId, Quantity = cartModel.Quantity };

            _cart.Add(Cart);

            return model;
        }

    }
}
