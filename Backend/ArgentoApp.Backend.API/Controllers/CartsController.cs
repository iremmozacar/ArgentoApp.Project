using System.Diagnostics.Contracts;
using ArgentoApp.Backend.Business.Abstract;
using ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;
using ArgentoApp.Backend.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : CustomControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public CartsController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(string userId)
        {
            var response = await _cartService.InitilaizeCartAsync(userId);
            return CreateActionResult(response);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var response = await _cartService.GetCartByUserIdAsync(userId);
            return CreateActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string userId, int productId, int quantity)
        {
            var response = await _cartService.AddToCartAsync(userId, productId, quantity);
            return CreateActionResult(response);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(CartItemUpdateDto cartItemUpdateDto)
        {
            var response = await _cartItemService.ChangeQuantityAsync(cartItemUpdateDto);
            return CreateActionResult(response);
        }
        [HttpGet("{cartId}")]
        public async Task<IActionResult> Count(int cartId)
        {
            var response = await _cartItemService.CountAsync(cartId);
            return CreateActionResult(response);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteItem(int cartItemId)
        {
            var response = await _cartItemService.DeleteCartItemAsync(cartItemId);
            return CreateActionResult(response);
        }
        [HttpDelete("{cartId}")]
        public async Task<IActionResult> ClearCart(int cartId)
        {
            var response = await _cartItemService.ClearCartAsync(cartId);
            return CreateActionResult(response);
        }
        [HttpGet("{cartItemId}")]
        public async Task<IActionResult> GetCartItem(int cartItemId)
        {
            var response = await _cartItemService.GetCartItemsAsync(cartItemId);
            return CreateActionResult(response);
        }
    }
}