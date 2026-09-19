using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Domain.Interfaces
{
    public interface IOrderService<TEntity>
    {
        Task<Order> CreateOrderAsync(string basketId, Address shippingAddress, int deliveryMethodId, string buyerEmail);

        Task<IReadOnlyList<TEntity>> GetOrdersForUserAsync(string buyeremail);

        Task<TEntity> GetOrderByIdForUserAsync(string buyerEmail, int orderId);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();



    }
}
