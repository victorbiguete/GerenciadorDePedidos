using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.Product
{
    public interface IProductReadRepository
    {
        Task<ProductReadModel> GetByIdAsync(long id);
        Task<IEnumerable<ProductReadModel>> GetAllAsync();
        Task AddAsync(ProductReadModel entity);
        void Delete(long id);
        void Update(ProductReadModel entity);
    }
}
