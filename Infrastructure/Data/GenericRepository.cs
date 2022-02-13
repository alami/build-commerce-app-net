using Core.Interfaces;
using Core.Models.Billing;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public  class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BillingContext _context;

        public GenericRepository(BillingContext context)
        {
            this._context = context;
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>()
//                .Include(p => p.ProductType) 
//                .Include(p=>p.ProductBrand)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
//                .Include(p => p.ProductType)
//                .Include(p => p.ProductBrand)
                .FindAsync(id);//.FirstOrDefaultAsync(p=>p.Id==id); 
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
