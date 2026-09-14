using Talabat.Domain.Entities.Basket;

namespace Talabat.Domain.Interfaces
{
    public interface IBasketRepository
    {

        Task<CustomerBasket?> GetBasketAsync(string basketId);

        Task<CustomerBasket?> CreateOrUpdatedBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string baskekId);


    }
}
