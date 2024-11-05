using System;

namespace ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;

public class CartItemCreateDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}


