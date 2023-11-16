using Microsoft.AspNetCore.Components.Forms;
using ShoppingCartProject.Models;
using ShoppingCartProject.ViewModels;
using System.IO;
using System.Linq;
namespace ShoppingCartProject.Services
{
    public class ProductService : IProductService
    {
        private ShoppingCartContext _context;
        public ProductService(ShoppingCartContext context)
        {
            _context = context;
        }
        /// <summary>
        /// get list of all Products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductsList()
        {
            List<Product> productList;
            try
            {
                productList = _context.Set<Product>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return productList;

        }

        /// <summary>
        /// get Product details by Product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductDetailsById(int productId)
        {
            Product product;
            try
            {
                product = _context.Find<Product>(productId);
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /// <summary>
        /// get Product details by Product Name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public Product GetProductDetailsByName(string productName)
        {
            Product product;
            try
            {
                product = GetProductsList().Find(x => x.ProductName == productName);
                

            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

      
        /// <summary>
        ///  add/edit Product
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public ResponseModel SaveProduct(Product productModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Product _temp = GetProductDetailsById(productModel.ProductId);
                if (_temp == null)
                {
                    Product Prod = GetProductDetailsByName(productModel.ProductName);
                    if (Prod == null)
                    {
                        _context.Add<Product>(productModel);
                        model.Messsage = "Product Inserted Successfully";
                    }
                    else
                    {
                        Prod.ProductName = productModel.ProductName;
                        Prod.Price = productModel.Price;
                        Prod.InStock = productModel.InStock;

                        _context.Products.Update(Prod);
                        model.Messsage = "Product Update Successfully";
                    }
                }
                else
                {
                    _temp.ProductName = productModel.ProductName;
                    _temp.Price = productModel.Price;
                    _temp.InStock = productModel.InStock;

                    _context.Products.Add(_temp);
                    model.Messsage = "Product Update Successfully";
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
