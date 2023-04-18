using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using WebApi_app.Models;
namespace WebApi_app.Interfaces

{
    public interface IProductRepository
    {
        List<Product> GetProducts(NameValueCollection queryParameters);
        Product GetProductById(int id);
        List<Product> GetProductsv2(bool status, decimal price);
        List<Product> GetProductsByCategoryId(int categoryId);
    }
}
