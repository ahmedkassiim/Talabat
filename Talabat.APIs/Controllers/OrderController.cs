using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.Applcation.Dtos.Order;
using Talabat.Domain.Entities.Order_Aggregate;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{
    [Authorize]
    public class OrderController : BaseApiController
    {
        private readonly IOrderService<ResepnseOrderDto> _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService<ResepnseOrderDto> orderService,
            IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpPost]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResepnseOrderDto>> CreateOrder(CreateOrderDto orderDto)
        {

            var address = _mapper.Map<AddressDto, Address>(orderDto.ShippingAddress);
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            var order = await _orderService.CreateOrderAsync(orderDto.BasketId, address, orderDto.DeliveryMethodId, buyerEmail);
            if (order is null) return BadRequest();
            return Ok(order);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResepnseOrderDto>> GetOrderById(int id)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            if (buyerEmail is null) return BadRequest();
            var order = await _orderService.GetOrderByIdForUserAsync(buyerEmail, id);
            if (order is null) return NotFound();
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ResepnseOrderDto>>> GetAllOrderForUser()
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            if (buyerEmail is null) return Unauthorized();
            var orders = await _orderService.GetOrdersForUserAsync(buyerEmail);
            if (orders is null) return NotFound();
            return Ok(orders);
        }
    }
}

