using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.Product
{
    public interface IProductUpdateOnlyRepository
    {
        Task<Entities.Product?> GetByIdAsync(long id);
        void Update(Entities.Product entity);
    }
}
