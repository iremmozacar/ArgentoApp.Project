using ArgentoApp.Backend.Business.Abstract;
using ArgentoApp.Backend.Shared.ComplexTypes;
using ArgentoApp.Backend.Shared.DTOs.OrderDTOs;
using ArgentoApp.Backend.Shared.Helpers;
using Microsoft.AspNetCore.Http;


using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : CustomControllerBase

    {
        private readonly IOrderService _orderservice;

        public OrdersController(IOrderService orderservice)
        {
            _orderservice = orderservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderCreateDto orderCreateDto)
        {
            var response = await _orderservice.CreateAsync(orderCreateDto);
            return CreateActionResult(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _orderservice.GetOrderAsync(id);
            return CreateActionResult(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderservice.GetOrdersAsync();
            return CreateActionResult(response);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(string userId)
        {
            var response = await _orderservice.GetOrdersAsync(userId);
            return CreateActionResult(response);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetOrdersByProductId(int productId)
        {
            var response = await _orderservice.GetOrdersAsync(productId);
            return CreateActionResult(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var response = await _orderservice.CancelOrder(id);
            return CreateActionResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> ChangeStatus(int id, OrderState orderState)
        {
            var response = await _orderservice.ChangeOrderStatusAsync(id, orderState);
            return CreateActionResult(response);
        }

    }
}
