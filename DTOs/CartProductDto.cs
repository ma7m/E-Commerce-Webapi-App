namespace WebApi_app.DTOs
{
    public record CartProductDto
    (
         int userId,
         int productId,
         int quantity
    );
}
