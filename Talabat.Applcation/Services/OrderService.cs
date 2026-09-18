using Talabat.Applcation.Specification.Order;
using Talabat.Domain.Entities.Order_Aggregate;
using Talabat.Domain.Entities.Products;
using Talabat.Domain.Interfaces;

namespace Talabat.Applcation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IGenericRepository<Product, ProductOrdredItem> _productRepo;
        private readonly IGenericRepository<DeliveryMethod, DeliveryMethod> _deliveryRepo;
        private readonly IGenericRepository<Order, Order> _orderRepo;

        public OrderService(IBasketRepository basketRepo,
            IGenericRepository<Product, ProductOrdredItem> productRepo,
            IGenericRepository<DeliveryMethod, DeliveryMethod> deliveryRepo,
            IGenericRepository<Order, Order> orderRepo
            )
        {
            _basketRepository = basketRepo;
            _productRepo = productRepo;
            _deliveryRepo = deliveryRepo;
            _orderRepo = orderRepo;
        }
        public async Task<Order> CreateOrderAsync(string basketId, Address shippingAddress, int? deliveryMethodId, string buyerEmail)
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
            var products = await _productRepo.GetAllWithSpec(new GetSelectedItemOnBasketSpecification(produtsId ?? new List<int>()));
            var deliverMehtod = await _deliveryRepo.GetWithSpec(new GetDelivetyMethodByIdSpecification(deliveryMethodId));
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
            var order = new Order(buyerEmail, address, deliverMehtod.Id, orderItems, subtotal);
            await _orderRepo.AddAsync(order);
            return order;
        }



        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdForUserAsync(string buyerEmail, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyeremail)
        {
            throw new NotImplementedException();
        }
    }
}
