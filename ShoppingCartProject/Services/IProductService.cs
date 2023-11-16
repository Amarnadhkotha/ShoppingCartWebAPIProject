using ShoppingCartProject.Models;
using ShoppingCartProject.ViewModels;

namespace ShoppingCartProject.Services
{
    public interface IProductService
    {
        /// <summary>
        /// get list of all Products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProductsList();

        /// <summary>
        /// get Product details by Product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetProductDetailsById(int productId);

        /// <summary>
        /// get Product details by Product Name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        Product GetProductDetailsByName(string productName);

        /// <summary>
        ///  add/edit Product
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        ResponseModel SaveProduct(Product productModel);

       
    }
}
