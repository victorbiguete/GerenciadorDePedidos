using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.Order
{
    public interface IOrderUpdateOnlyRepository
    {
        Task<Entities.Order> GetByIdAsync(long id);
        void Update(Entities.Order entity);
    }
}
