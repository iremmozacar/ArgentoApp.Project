using System;
using ArgentoApp.Backend.Shared.ComplexTypes;
using ArgentoApp.Backend.Shared.DTOs.OrderDTOs;

namespace ArgentoApp.Backend.Shared.DTOs.OrderDTOs;

public class OrderDto
{
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public PaymentType PaymentType { get; set; }
    public OrderState OrderState { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();


}

