using Microsoft.EntityFrameworkCore;
using MyStore.Domain.IRepository.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.Repositories.Order
{
    public class OrderRepository : IOrderUpdateOnlyRepository, IOrderWriteRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Order entity)
        {
            await _context.Orders.AddAsync(entity);
        }

        public async Task Delete(long id)
        {
            var order = await _context.Orders.FindAsync(id);

            _context.Orders.Remove(order!);
        }

        public Task<Domain.Entities.Order> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Order entity)
        {
            _context.Orders.Update(entity);
        }
    }
}
