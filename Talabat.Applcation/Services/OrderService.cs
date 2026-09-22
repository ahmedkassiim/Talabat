using Talabat.Applcation.Dtos.Order;
using Talabat.Applcation.Specification.Order;
using Talabat.Domain.Entities.Order_Aggregate;
using Talabat.Domain.Entities.Products;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.Services
{
    public class OrderService<TEntity> : IOrderService<ResepnseOrderDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        public OrderService(IBasketRepository basketRepo,
                        IUnitOfWork unitOfWork,
                        IPaymentService paymentService)
        {
            _basketRepository = basketRepo;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }
        public async Task<Order> CreateOrderAsync(string basketId, Address shippingAddress, int deliveryMethodId, string buyerEmail)
        {

            var address = new Address
            {
                FirstName = shippingAddress.FirstName,
                LastName = shippingAddress.LastName,
                Street = shippingAddress.Street,
                City = shippingAddress.City,
                Country = shippingAddress.Country,
            };


            var basket = await _basketRepository.GetBasketAsync(basketId);
            var produtsId = basket?.Items.Select(b => b.Id);
            var products = await _unitOfWork.Repository<Product>().GetAllWithSpec(new GetSelectedItemOnBasketSpecification(produtsId ?? new List<int>()));
            var deliverMehtod = await _unitOfWork.Repository<DeliveryMethod>().GetWithSpec(new GetDelivetyMethodByIdSpecification(deliveryMethodId));
            var orderItems = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var product = products.FirstOrDefault(P => P.ProductId == item.Id);
                var orderItem = new OrderItem
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Product = product
                };
                orderItems.Add(orderItem);
            }

            var subtotal = orderItems.Sum(p => p.Price * p.Quantity);

            var productRepo = _unitOfWork.Repository<Order>();
            var exsistOrder = await productRepo.GetWithSpec(new GetOrderByPaymentIntentSpecification(basket.PaymentIntentId));
            if (exsistOrder is not null)
            {
                productRepo.Delete(exsistOrder);
                await _paymentService.CreateOrUpdatePaymentIntentAsync(basketId);
            }

            var order = new Order(buyerEmail, address, deliveryMethodId, orderItems, subtotal, basket.PaymentIntentId);
            await productRepo.AddAsync(order);
            var result = await _unitOfWork.ComplateAsync();
            if (result <= 0) return null!;
            return order;
        }



        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            var result = await _unitOfWork.Repository<DeliveryMethod>().GetAllWithSpec(new GetAllDeliveryMethodSpecification());
            return result;
        }

        public async Task<ResepnseOrderDto> GetOrderByIdForUserAsync(string buyerEmail, int orderId)
        {
            var order = await _unitOfWork.Repository<Order>()
                .GetWithSpec(new GetOrderForSpecificUserSpecification(orderId, buyerEmail));
            return order;
        }

        public async Task<IReadOnlyList<ResepnseOrderDto>> GetOrdersForUserAsync(string buyeremail)
        {
            var orders = await _unitOfWork.Repository<Order>()
                 .GetAllWithSpec(new GetAllOrdersForSpecificUserSpecification(buyeremail));
            return orders;
        }
    }
}
