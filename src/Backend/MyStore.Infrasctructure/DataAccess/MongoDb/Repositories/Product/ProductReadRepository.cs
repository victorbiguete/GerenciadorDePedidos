using MongoDB.Driver;
using MyStore.Domain.IRepository.Product;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.Product
{
    public class ProductReadRepository : IProductReadRepository
    {
        private readonly IMongoCollection<ProductReadModel> _collection;

        public ProductReadRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<ProductReadModel>("Products");
        }

        public async Task<IEnumerable<ProductReadModel>> GetAllAsync()
        {
            return await _collection.Find(product => product.Active).ToListAsync();
        }

        public async Task<ProductReadModel> GetByIdAsync(long id)
        {
            return await _collection.Find(product => product.Active && product.Id == id).FirstOrDefaultAsync();
        }
    }
}
