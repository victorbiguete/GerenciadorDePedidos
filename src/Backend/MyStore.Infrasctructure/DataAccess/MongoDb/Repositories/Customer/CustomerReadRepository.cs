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
            _collection = context.GetCollection<CustomerReadModel>("Customers");
        }
        public async Task<IEnumerable<CustomerReadModel?>> GetAllAsync()
        {
            return await _collection.Find(customer => customer.Active).ToListAsync();
        }

        public async Task<CustomerReadModel?> GetByIdAsync(long id)
        {
            return await _collection.Find(customer => customer.Active &&  customer.Id == id).FirstOrDefaultAsync();
        }
    }
}
