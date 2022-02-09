using Core.Models.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByIdAsync(string id);
        Task<IReadOnlyList<Account>> GetAccountAsync();
    }
}
