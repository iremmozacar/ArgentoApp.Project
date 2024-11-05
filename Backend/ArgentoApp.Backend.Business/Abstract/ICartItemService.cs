using System;
using ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ArgentoApp.Backend.Business.Abstract;

public interface ICartItemService
{
    Task<ResponseDto<NoContent>> ChangeQuantityAsync(CartItemUpdateDto cartItemUpdateDto);
    Task<ResponseDto<int>> CountAsync(int cartId);
    Task<ResponseDto<NoContent>> DeleteCartItemAsync(int cartItemId);
    Task<ResponseDto<NoContent>> ClearCartAsync(int cartId);
    Task<ResponseDto<CartItemDto>> GetCartItemsAsync(int cartItemId);
}
