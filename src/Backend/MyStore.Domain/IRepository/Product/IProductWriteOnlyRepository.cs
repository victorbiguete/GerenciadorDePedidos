using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.Product
{
    public interface IProductWriteOnlyRepository
    {
        Task AddAsync(Entities.Product entity);
        void Delete(long id);
    }
}
