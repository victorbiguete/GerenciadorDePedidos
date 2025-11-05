using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.Order
{
    public interface IOrderWriteRepository
    {
        Task AddAsync(Entities.Order entity);
        Task Delete(long id);
    }
}
