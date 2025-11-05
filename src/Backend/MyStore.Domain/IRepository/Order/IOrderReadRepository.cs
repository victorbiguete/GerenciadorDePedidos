using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.Order
{
    public interface IOrderReadRepository
    {
        Task<OrderReadModel?> GetByIdAsync(long id);
        Task<IEnumerable<OrderReadModel?>> GetAllAsync();
        Task<IEnumerable<OrderReadModel?>> GetAllOrderStatus(int status);
        Task<IEnumerable<OrderReadModel?>> GetOrdersByCustomerIdAsync(long customerId);
        Task AddAsync(OrderReadModel entity);
        Task Delete(long id);
        Task Update(OrderReadModel entity);
    }
}
