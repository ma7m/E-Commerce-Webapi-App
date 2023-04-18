namespace WebApi_app.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
