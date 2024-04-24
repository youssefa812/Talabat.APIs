﻿using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System.Text.Json;
using Talabat.Core.Entites;
using Talabat.Core.Repositories.Contract;

namespace Talabat.Repository
{
	public class BasketRepository : IBasketRepository
	{
		private readonly StackExchange.Redis.IDatabase _database;

		public BasketRepository(IConnectionMultiplexer redis)
		{
			_database = redis.GetDatabase();
		}
		public async Task<bool> DeleteBasketAsync(string basketId)
		{
			return await _database.KeyDeleteAsync(basketId);
		}

		public async Task<CustomerBasket?> GetBasketAsync(string basketId)
		{
			var basket = await _database.StringGetAsync(basketId);

			return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
		}

		public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
		{
			var createdOrUpdated = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

			if (!createdOrUpdated) return null;
			return await GetBasketAsync(basket.Id);
		}
	}
}