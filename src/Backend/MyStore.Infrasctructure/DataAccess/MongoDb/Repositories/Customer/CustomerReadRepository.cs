using MongoDB.Driver;
using MyStore.Domain.IRepository.ICustomer;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.Customer
{
    public class CustomerReadRepository : ICustomerReadRepository
    {
        private readonly IMongoCollection<CustomerReadModel> _collection;

        public CustomerReadRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<CustomerReadModel>("customers");
        }

        public async Task AddAsync(CustomerReadModel entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(long id)
        {
            await _collection.DeleteOneAsync(customer => customer.Id == id);
        }

        public async Task<IEnumerable<CustomerReadModel>> GetAllAsync()
        {
            return await _collection.Find(customer => customer.Active).ToListAsync();
        }

        public async Task<CustomerReadModel> GetByIdAsync(long id)
        {
            return await _collection.Find(customer => customer.Active &&  customer.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(CustomerReadModel entity)
        {
            await _collection.ReplaceOneAsync(customer => customer.Id == entity.Id, entity);
        }
    }
}
