using MongoDB.Driver;
using MyStore.Domain.IRepository.OrderItens;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.OrderItem
{
    public class OrderItemReadRepository : IOrderItemReadRepository
    {
        private readonly IMongoCollection<OrderItemReadModel> _collection;

        public OrderItemReadRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<OrderItemReadModel>("OrderItens");
        }

        public async Task AddAsync(IList<OrderItemReadModel> entity)
        {
            await _collection.InsertManyAsync(entity);
        }

        public async Task Delete(long id)
        {
            await _collection.DeleteOneAsync(orderItem=> orderItem.Id == id);
        }

        public async Task<IEnumerable<OrderItemReadModel>> GetAllAsync()
        {
            return await _collection.Find(orderItens => orderItens.Active).ToListAsync();
        }

        public async Task<OrderItemReadModel?> GetByIdAsync(long id)
        {
            return await _collection.Find(orderItem => orderItem.Active && orderItem.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderItemReadModel>> GetByOrderIdAsync(long orderId)
        {
            return await _collection.Find(orderItem => orderItem.Active && orderItem.OrderId == orderId).ToListAsync();
        }

        public async Task Update(OrderItemReadModel entity)
        {
            await _collection.ReplaceOneAsync(orderItem => orderItem.Id == entity.Id, entity);
        }
    }
}
