using WebApi_app.DTOs;

namespace WebApi_app.Interfaces
{
    public interface ICartRepository
    {
        bool AddProductToCart (CartProductDto cartProductDto);
        bool RemoveProductFromCart(CartProductDto cartProductDto);
    }
}
