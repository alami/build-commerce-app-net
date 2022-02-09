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
    public class AccountRepository : IAccountRepository
    {
        private readonly BillingContext _context;

        public AccountRepository(BillingContext context)
        {
            this._context = context;
        }
        public async Task<IReadOnlyList<Account>> GetAccountAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(string id)
        {
            return await _context.Accounts.FindAsync(id);
        }
    }
}
