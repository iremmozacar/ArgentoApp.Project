using System;
using ArgentoApp.Backend.Shared.ComplexTypes;

namespace ArgentoApp.Backend.Shared.DTOs.OrderDTOs;

public class ChangeStatusDto
{
    public int Id { get; set; }
    public OrderState OrderState { get; set; }
}
