using System;
using ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;

namespace ArgentoApp.Backend.Shared.DTOs.CartDTOs;

public class CartCreateDto
{
    public string UserId { get; set; }
    public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();

}
