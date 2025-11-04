using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.OrderItens
{
    public interface IOrderItemUpdateOnlyRepository
    {
        Task<OrderItem?> GetByIdAsync(long id);
        void Update(OrderItem item);
    }
}
