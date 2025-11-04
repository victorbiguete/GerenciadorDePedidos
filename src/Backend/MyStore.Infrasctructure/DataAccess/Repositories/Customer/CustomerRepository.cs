using Microsoft.EntityFrameworkCore;
using MyStore.Domain.IRepository.ICustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.Repositories.Customer
{
    public class CustomerRepository : ICustomerUpdateOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Customer entity) => await _context.Customers.AddAsync(entity);
        
        public async void Delete(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(customer);
        }

        public async Task<Domain.Entities.Customer?>GetByIdAsync(long id)
        {
           return await _context.Customers.Where(customer => customer.Active && customer.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Domain.Entities.Customer entity)
        {
            _context.Customers.Update(entity);
        }
    }
}
