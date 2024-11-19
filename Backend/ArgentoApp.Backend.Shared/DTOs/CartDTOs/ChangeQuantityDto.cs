using System;

namespace ArgentoApp.Backend.Shared.DTOs.CartDTOs;

public class ChangeQuantityDto
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }
}
