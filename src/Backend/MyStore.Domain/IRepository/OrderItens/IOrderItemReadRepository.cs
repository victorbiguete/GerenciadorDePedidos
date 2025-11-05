using MyStore.Domain.Entities;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.OrderItens
{
    public interface IOrderItemReadRepository
    {
        Task<OrderItemReadModel?> GetByIdAsync(long id);
        Task<IEnumerable<OrderItemReadModel>> GetByOrderIdAsync(long orderId);
        Task<IEnumerable<OrderItemReadModel>> GetAllAsync();
        Task AddAsync(IList<OrderItemReadModel> entity);
        Task Delete(long id);
        Task Update(OrderItemReadModel entity);
    }
}
