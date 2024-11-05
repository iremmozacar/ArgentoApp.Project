using System;
using ArgentoApp.Backend.Entity.Concrete;
using ArgentoApp.Backend.Shared.DTOs.CartDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ArgentoApp.Backend.Business.Abstract;

public interface ICartService
{
    Task<ResponseDto<NoContent>> InitilaizeCartAsync(string userId);
    Task<ResponseDto<CartDto>> GetCartByUserIdAsync(string userId);
    Task<ResponseDto<NoContent>> AddToCartAsync(string userId, int productId, int quantity);

}
