using MongoDB.Driver;
using MyStore.Domain.IRepository.Order;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.Order
{
    public class OrderReadRepository : IOrderReadRepository
    {
        private readonly IMongoCollection<OrderReadModel> _collection;

        public OrderReadRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<OrderReadModel>("orders");
        }

        public async Task AddAsync(OrderReadModel entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(long id)
        {
            await _collection.DeleteOneAsync(order => order.Id == id);
        }

        public async Task<IEnumerable<OrderReadModel?>> GetAllAsync()
        {
            return await _collection.Find(order => order.Active).ToListAsync();
        }

        public async Task<OrderReadModel?> GetByIdAsync(long id)
        {
            return await _collection.Find(order => order.Active && order.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderReadModel?>> GetOrdersByCustomerIdAsync(long customerId)
        {
            return await _collection.Find(order => order.Active && order.CustomerId == customerId).ToListAsync();
        }

        public async Task Update(OrderReadModel entity)
        {
            await _collection.ReplaceOneAsync(order => order.Id == entity.Id, entity);
        }
    }
}
