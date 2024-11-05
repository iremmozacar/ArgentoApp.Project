using System;
using ArgentoApp.Backend.Business.Abstract;
using ArgentoApp.Backend.Data.Abstract;
using ArgentoApp.Backend.Entity.Concrete;
using ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ArgentoApp.Backend.Business.Concrete;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartItemService(ICartItemRepository cartItemRepository, ICartRepository cartRepository, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<NoContent>> ChangeQuantityAsync(CartItemUpdateDto cartItemUpdateDto)
    {
        var cartItem = await _cartItemRepository.GetAsync(x => x.Id == cartItemUpdateDto.CartItemId);
        if (cartItem == null)
        {
            return ResponseDto<NoContent>.Fail("Ürün bulunamadı", 404);
        }
        cartItem.Quentity = cartItemUpdateDto.Quantity;
        await _cartItemRepository.UpdateAsync(cartItem);
        return ResponseDto<NoContent>.Success(200);
    }

    public async Task<ResponseDto<NoContent>> ClearCartAsync(int cartId)
    {
        var cart = await _cartRepository.GetAsync(x => x.Id == cartId, source => source.Include(x => x.CartItems));
        if (cart == null)
        {
            return ResponseDto<NoContent>.Fail("İlgili sepet bulunamadı!", 404);
        }
        foreach (var cartItem in cart.CartItems.ToList())
        {
            await _cartItemRepository.DeleteAsync(cartItem);
        }
        return ResponseDto<NoContent>.Success(200);
    }

    public async Task<ResponseDto<int>> CountAsync(int CartId)
    {
        var count = await _cartItemRepository.GetCountAsync(x => x.CartId == CartId);
        if (count == 0)
        {
            return ResponseDto<int>.Fail("Sepet bulunamadı.", 404);
        }
        return ResponseDto<int>.Success(count, 200);
    }

    public async Task<ResponseDto<NoContent>> DeleteCartItemAsync(int cartItemId)
    {
        var cartItem = await _cartItemRepository.GetAsync(x => x.Id == cartItemId);
        if (cartItem == null)
        {
            return ResponseDto<NoContent>.Fail("İlgili ürün sepette bulunamadı!", 404);
        }
        await _cartItemRepository.DeleteAsync(cartItem);
        return ResponseDto<NoContent>.Success(200);
    }

    public async Task<ResponseDto<CartItemDto>> GetCartItemsAsync(int cartItemId)
    {
        var cartItem = await _cartItemRepository.GetAsync(x => x.Id == cartItemId, source => source.Include(x => x.Product));
        if (cartItem == null)
        {
            return ResponseDto<CartItemDto>.Fail("İlgili ürün sepette bulunamadı!", 404);
        }
        var cartItemDto = _mapper.Map<CartItemDto>(cartItem);
        return ResponseDto<CartItemDto>.Success(cartItemDto, 200);

    }
}
