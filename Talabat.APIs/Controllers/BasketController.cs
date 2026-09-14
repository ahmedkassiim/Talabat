using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.Applcation.Dtos.Basket;
using Talabat.Domain.Entities.Basket;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository,
            IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            return Ok(basket is null ? new CustomerBasket(basketId) : basket);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var createdOrUpdatedBasket = await _basketRepository.CreateOrUpdatedBasketAsync(customerBasket);
            if (createdOrUpdatedBasket is null) return BadRequest();
            return Ok(createdOrUpdatedBasket);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string basketId)
        {
            return Ok(await _basketRepository.DeleteBasketAsync(basketId));
        }
    }
}
