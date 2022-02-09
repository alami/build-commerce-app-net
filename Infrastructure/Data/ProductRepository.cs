using Core.Interfaces;
using Core.Models.Billing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public  class ProductRepository : IProductRepository
    {
        private readonly BillingContext _context;

        public ProductRepository(BillingContext context)
        {
            this._context = context;
        }
        public async Task<IReadOnlyList<Product>> GetProducstAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id); 
        }
    }
}
