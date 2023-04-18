using Microsoft.AspNetCore.Mvc;
using WebApi_app.Interfaces;
using WebApi_app.Models;
using WebApi_app.Repositories;

namespace WebApi_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public  ActionResult<List<Category>> GetCategories()
        {
            var categories =  categoryRepository.GetCategories();
            return Ok(categories);
        }
    }
}
