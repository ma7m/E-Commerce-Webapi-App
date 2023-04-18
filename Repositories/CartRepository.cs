using Microsoft.EntityFrameworkCore;
using WebApi_app.DTOs;
using WebApi_app.Interfaces;
using WebApi_app.Models;

namespace WebApi_app.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext appDbContext;
        public CartRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool AddProductToCart(CartProductDto cartProductDto)
        {
            Product? product = appDbContext.Products.FirstOrDefault(p => p.Id == cartProductDto.productId);
            if (product == null)
            {
                return false;
            }

            Cart cart = appDbContext.Carts.FirstOrDefault(c => c.UserId == cartProductDto.userId)
              ?? appDbContext.Carts.Add(new Cart { UserId = cartProductDto.userId }).Entity;

            CartProduct? cartProduct = appDbContext.CartProduct
                .FirstOrDefault(cp => cp.ProductId == cartProductDto.productId && cp.CartId == cart.Id);
  
            if(cartProduct != null)
            {
                cartProduct.Quantity += cartProductDto.quantity;
                appDbContext.CartProduct.Update(cartProduct);
            }
            else
            {
                cartProduct = new CartProduct
                {
                    Product = product,
                    Cart = cart,
                    Quantity = cartProductDto.quantity
                };
                appDbContext.CartProduct.Add(cartProduct);
            }
            appDbContext.SaveChanges();
            return true;     
            }

        public bool RemoveProductFromCart(CartProductDto cartProductDto)
        {
            var cart = appDbContext.Carts.FirstOrDefault(c => c.UserId == cartProductDto.userId);
            if (cart == null) 
            {
                return false;
            }
            var cartproduct = appDbContext.CartProduct.FirstOrDefault(cp => cp.ProductId == cartProductDto.productId && cp.Quantity >= cartProductDto.quantity);
            if (cartproduct == null) 
            {
                return false;

            }
            cartproduct.Quantity -= cartProductDto.quantity;
            if (cartproduct.Quantity == 0) 
            {
                appDbContext.Remove(cartproduct);

            }
            appDbContext.SaveChanges();
            return true;
        }
    }
}
