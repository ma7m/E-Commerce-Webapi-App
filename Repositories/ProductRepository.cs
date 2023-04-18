using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Web;
using WebApi_app.Interfaces;
using WebApi_app.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApi_app.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Product GetProductById(int id)
        {
            return appDbContext.Products.SingleOrDefault(p => p.Id == id);
        }
        public List<Product> GetProductsv2(bool status, decimal price)
        {
            //var query = appDbContext.Products.AsQueryable();

            //if (!string.IsNullOrEmpty(stock))   
            //{
            //    query = query.Where(p => p.Stock == stock);
            //}

            //if (price >= 1000)
            //{
            //    query = query.Where(p => p.Price >= price);
            //}h
            //return appDbContext.Products.ToList();
            return this.GetProductv3(status, price);
        }
        public List<Product> GetProducts(NameValueCollection queryParameters)
        {

            decimal? price = queryParameters["price"] != null ? decimal.Parse(queryParameters["price"]) : null;
          //  string title = queryParameters["title"];
            bool? status = queryParameters["status"] != null ? bool.Parse(queryParameters["status"]) : null;

            //return appDbContext.Products.Where(p => p.Price > price)
            //    .Where(p => p.Title == title)
            //    .Where(p => p.Status == true)
            //    .OrderBy(p => p.Title)
            //    .ToList();

            return this.GetProductv3(status, price);
        }

        private List<Product> GetProductv3(bool? status = null, decimal? price = null)
        {
            var query = appDbContext.Products.AsQueryable();

            if (status != null) 
            {
                query = query.Where(p => p.Status == status);
            }
            if (price != null)
            { 
                query = query.Where(p=> p.Price <= price);
            }

            return query.ToList();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return appDbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }
    }
}
