using System.ComponentModel.DataAnnotations;

namespace WebApi_app.Models
{
    public class Product
    {
      [Required]
      public int Id { get; set; }
      public string Title { get; set; }
      public decimal Price { get; set; }
      public string Stock { get; set; }
      public bool Status { get; set; }
      public int CategoryId { get; set ; }
      public Category Category { get; set; } = null!;
      public virtual ICollection<Cart> Carts { get; set; }
      public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
      public ICollection<OrderProduct> OrderProducts { get; set; }
      public virtual ICollection<Order> Orders { get; set; }


     
    }
}
