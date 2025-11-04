using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.ICustomer
{
    public interface ICustomerUpdateOnlyRepository
    {
        Task<Customer?> GetByIdAsync(long id);
        void Update(Customer entity);
    }
}
