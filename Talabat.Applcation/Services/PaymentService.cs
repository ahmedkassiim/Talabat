using Microsoft.Extensions.Configuration;
using Stripe;
using Talabat.Applcation.Specification.Order;
using Talabat.Applcation.Specification.Product;
using Talabat.Domain.Entities.Basket;
using Talabat.Domain.Entities.Order_Aggregate;
using Talabat.Domain.Interfaces;
using Product = Talabat.Domain.Entities.Products.Product;

namespace Talabat.Applcation.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IConfiguration configuration
            , IBasketRepository basketRepository,
            IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerBasket?> CreateOrUpdatePaymentIntentAsync(string basketId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSetting:Secretkey"];
            var basket = await _basketRepository.GetBasketAsync(basketId);
            if (basket is null) return null;
            if (basket.Items.Count > 0)
            {

                var shippingPrice = 0m;

                var productRepo = _unitOfWork.Repository<Product>();
                foreach (var item in basket.Items)
                {
                    var product = await productRepo.GetWithSpec(new GetProductByIdSpecification(item.Id, _configuration));
                    if (product is null) continue;
                    if (item.Price != product.Price)
                        item.Price = product.Price;
                }
                if (basket.DeliveryMethodId.HasValue)
                {
                    var deliveyMethod = await _unitOfWork.Repository<DeliveryMethod>().GetWithSpec(new GetDelivetyMethodByIdSpecification(basket.DeliveryMethodId.Value));
                    shippingPrice = deliveyMethod.Cost;
                    basket.ShippingPrice = shippingPrice;
                }
                PaymentIntent paymentIntent;
                PaymentIntentService paymentIntentService = new PaymentIntentService();
                if (string.IsNullOrEmpty(basket.PaymentIntentId))
                {
                    var opation = new PaymentIntentCreateOptions()
                    {

                        Amount = (long)basket.Items.Sum(item => item.Price * 100 * item.Quantity) + (long)shippingPrice * 100,
                        Currency = "usd",
                        PaymentMethodTypes = new List<string>() { "card" }
                    };
                    paymentIntent = await paymentIntentService.CreateAsync(opation);
                    basket.PaymentIntentId = paymentIntent.Id;
                    basket.ClientSecret = paymentIntent.ClientSecret;

                }
                else
                {
                    var opation = new PaymentIntentUpdateOptions()
                    {
                        Amount = (long)basket.Items.Sum(item => item.Price * 100 * item.Quantity) + (long)shippingPrice * 100,

                    };
                    paymentIntent = await paymentIntentService.UpdateAsync(basket.PaymentIntentId, opation);
                }

            }
            await _basketRepository.CreateOrUpdatedBasketAsync(basket);
            return basket;
        }

        public async Task<Order?> UpdateOrderStatus(string paymentIntentId, bool isPaid)
        {
            var orderRepo = _unitOfWork.Repository<Order>();
            var order = await orderRepo.GetWithSpec(new GetOrderByPaymentIntentSpecification(paymentIntentId));
            if (order is null) return null;
            if (isPaid == true)
                order.Status = OrderStatus.PaymentReceived;
            else
                order.Status = OrderStatus.PaymentFailed;
            orderRepo.Update(order);
            await _unitOfWork.ComplateAsync();
            return order;

        }
    }
}
