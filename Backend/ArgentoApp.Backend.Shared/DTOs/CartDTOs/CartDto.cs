using System;
using ArgentoApp.Backend.Shared.DTOs.CartItemDTOs;

namespace ArgentoApp.Backend.Shared.DTOs.CartDTOs;

public class CartDto
{
    public int CartId { get; set; }
    public string UserId { get; set; }
    public List<CartItemDto> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
}
