using Microsoft.EntityFrameworkCore;
using MyStore.Domain.IRepository.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrasctructure.DataAccess.Repositories.Product
{
    public class ProductRepository : IProductUpdateOnlyRepository, IProductWriteOnlyRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(Domain.Entities.Product entity)
        {
            await _context.Products.AddAsync(entity);
        }

        public async void Delete(long id)
        {
            var product = await _context.Products.FindAsync(id);

            _context.Products.Remove(product!);
        }

        public void Update(Domain.Entities.Product entity)
        {
            _context.Products.Update(entity);
        }

        public async Task<Domain.Entities.Product?> GetByIdAsync(long id)
        {
            return await _context.Products.Where(product => product.Active && product.Id == id).FirstOrDefaultAsync();
        }

    }
}
