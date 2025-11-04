using Microsoft.EntityFrameworkCore;
using MyStore.Domain.IRepository.OrderItens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.Repositories.OrderItem
{
    public class OrderItemRepository :
        IOrderItemUpdateOnlyRepository, IOrderItemWriteOnlyRepository
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

         public async Task<Domain.Entities.OrderItem?> GetByIdAsync(long id)
        {
            return await _context.OrderItems.Where(orderItem => orderItem.Active && orderItem.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Domain.Entities.OrderItem item)
        {
             _context.OrderItems.Update(item);
        }

        public async Task AddAsync(Domain.Entities.OrderItem item) => await _context.OrderItems.AddAsync(item);

        public async Task DeleteAsync(long id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            _context.OrderItems.Remove(orderItem!);
        }
    }
}
