using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.IRepository.ICustomer
{
    public interface ICustomerWriteOnlyRepository
    {
        Task AddAsync(Customer entity);
        void Delete(long id);
    }
}
