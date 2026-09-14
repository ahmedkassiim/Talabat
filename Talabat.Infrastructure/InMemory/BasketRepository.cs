using StackExchange.Redis;
using System.Text.Json;
using Talabat.Domain.Entities.Basket;
using Talabat.Domain.Interfaces;

namespace Talabat.Infrastructure.InMemory
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redisConnection)
        {
            _database = redisConnection.GetDatabase();

        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {

            var basket = await _database.StringGetAsync(basketId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket.ToString());

        }
        public async Task<CustomerBasket?> CreateOrUpdatedBasketAsync(CustomerBasket basket)
        {

            var createdOrUpdatedBasket = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (!createdOrUpdatedBasket) return null;
            return await GetBasketAsync(basket.Id);

        }

        public async Task<bool> DeleteBasketAsync(string baskekId)
        {
            return await _database.KeyDeleteAsync(baskekId);
        }
    }

}