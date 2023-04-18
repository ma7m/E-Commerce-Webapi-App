namespace WebApi_app.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    }
}
