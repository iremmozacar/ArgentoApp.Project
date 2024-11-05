using System;
using ArgentoApp.Backend.Shared.ComplexTypes;
using ArgentoApp.Backend.Shared.DTOs.OrderDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ArgentoApp.Backend.Business.Abstract;

public interface IOrderService
{
    Task<ResponseDto<NoContent>> CreateAsync(OrderCreateDto orderCreateDto);
    Task<ResponseDto<List<OrderDto>>> GetOrdersAsync();
    Task<ResponseDto<List<OrderDto>>> GetOrdersAsync(int productId);
    Task<ResponseDto<List<OrderDto>>> GetOrdersAsync(string userId);
    Task<ResponseDto<OrderDto>> GetOrderAsync(int Id);
    Task<ResponseDto<NoContent>> ChangeOrderStatusAsync(int id, OrderState orderState);
    Task<ResponseDto<NoContent>> CancelOrder(int id);


}
