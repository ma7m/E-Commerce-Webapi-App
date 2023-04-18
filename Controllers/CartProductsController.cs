using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using System;
using WebApi_app.Interfaces;
using WebApi_app.Models;
using WebApi_app.DTOs;

namespace WebApi_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartProductsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartProductsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("add-to-product")]
        public ActionResult AddProductToCart([FromBody] CartProductDto cartProductDto)
        {
            bool result = _cartRepository.AddProductToCart(cartProductDto);

            return Ok(result);
        }

        [HttpDelete("DeleteProductFromCart")]
        public ActionResult RemoveProductFromCart(CartProductDto cartProductDto)
        {
            var result = _cartRepository.RemoveProductFromCart(cartProductDto);
            if(result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Cannot find user_id / product_id");
            }

        }
    }

}
