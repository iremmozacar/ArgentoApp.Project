using System;

namespace ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;

public class CartItemDto
{


    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
