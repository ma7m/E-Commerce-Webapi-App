using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApi_app.Interfaces;

namespace WebApi_app.Models
{
    public class AppDbContext : DbContext , IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Carts)
                .WithMany(e => e.Products)
                .UsingEntity<CartProduct>();

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithMany(e => e.Products)
                .UsingEntity<OrderProduct>();

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
        }

    }


}
