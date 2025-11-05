using MyStore.Domain.Entities;
using MyStore.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.ICustomer
{
    public interface ICustomerReadRepository
    {
        Task<CustomerReadModel?> GetByIdAsync(long id);
        Task<IEnumerable<CustomerReadModel?>> GetAllAsync();
        
    }
}
