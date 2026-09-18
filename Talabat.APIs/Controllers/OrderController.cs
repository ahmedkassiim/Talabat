using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.Domain.Entities.Order_Aggregate;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{

    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Order>> CreateOrder(Order order, string basketId)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);

            var userOrder = await _orderService.CreateOrderAsync(basketId, order.ShippingAddress, order.DeliveryMethodId, buyerEmail);
            return Ok(userOrder);

        }
    }

}

