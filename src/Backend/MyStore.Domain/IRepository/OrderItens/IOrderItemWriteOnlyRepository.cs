using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.OrderItens
{
    public interface IOrderItemWriteOnlyRepository
    {
        Task AddAsync(OrderItem item);
        //Task AddRangeAsync(IEnumerable<OrderItem> items);
        Task DeleteAsync(long id);
    }
}
