using System;
using ArgentoApp.Backend.Shared.DTOs.OrderDTOs;

namespace ArgentoApp.Backend.Shared.DTOs.OrderDTOs;

public class OrderCreateDto
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int PaymentType { get; set; }
    public List<OrderItemCreateDto> OrderItems { get; set; }

}
