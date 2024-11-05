using System;

namespace ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;

public class CartItemUpdateDto
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }
}
