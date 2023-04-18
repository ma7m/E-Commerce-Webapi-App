
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;
using WebApi_app.Interfaces;
using WebApi_app.Models;
using WebApi_app.Repositories;

namespace WebApi_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet("/api/v2")]
        public ActionResult<Product> GetProducts(bool status, decimal price) {

            var products = productRepository.GetProductsv2(status,price);
            return Ok(products);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                string queryString = Request.QueryString.ToString();


                NameValueCollection queryParameters = HttpUtility.ParseQueryString(queryString);
                var mah = queryParameters;
                return Ok(productRepository.GetProducts(queryParameters));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            try
            {
                Product result = productRepository.GetProductById(id);
                if(result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("byCategory/{categoryId}")]
        public ActionResult<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            var products = productRepository.GetProductsByCategoryId(categoryId);
            return Ok(products);
        }
    }
}
