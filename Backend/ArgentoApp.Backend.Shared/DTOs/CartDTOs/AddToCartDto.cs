using System;

namespace ArgentoApp.Backend.Shared.DTOs.CartDTOs;
public class AddToCartDto
{
    public int ProductId { get; set; }

    public int Quantity { get; set; } = 1;
    public string UserId { get; set; }
}
