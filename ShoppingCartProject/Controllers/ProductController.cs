using Microsoft.AspNetCore.Mvc;
using ShoppingCartProject.Services;
using ShoppingCartProject.Models;


namespace ShoppingCartProject.Controllers
{
    [Route("api/Product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService service)
        {
            _productService = service;
        }

        /// <summary>
        /// get all Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult ProductList()
        {
            try
            {
                var products = _productService.GetProductsList();
                if (products == null)
                    return NotFound();
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// get Product details by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                var product = _productService.GetProductDetailsById(productId);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save Product
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateProduct")]
        public IActionResult SaveUser(Product productModel)
        {
            try
            {
                var model = _productService.SaveProduct(productModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



    }
}
