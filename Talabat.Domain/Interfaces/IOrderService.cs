using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string basketId, Address shippingAddress, int? deliveryMethodId, string buyerEmail);

        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyeremail);

        Task<Order> GetOrderByIdForUserAsync(string buyerEmail, int orderId);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();



    }
}
