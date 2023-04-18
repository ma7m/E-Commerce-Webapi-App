using Microsoft.EntityFrameworkCore;
using WebApi_app.Interfaces;
using WebApi_app.Models;

namespace WebApi_app.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public List<Category> GetCategories()
        {
            return appDbContext.Category.ToList();
        }
    }
}
