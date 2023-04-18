using WebApi_app.Models;

namespace WebApi_app.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}

//Update 1 added successfully