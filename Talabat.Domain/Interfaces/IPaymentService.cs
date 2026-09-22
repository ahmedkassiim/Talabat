using Talabat.Domain.Entities.Basket;
using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket?> CreateOrUpdatePaymentIntentAsync(string basketId);

        Task<Order?> UpdateOrderStatus(string paymentIntentId, bool isPaid);
    }
}
