using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;

namespace XbankQuery.Domain.Interfaces
{
    public interface IBankBalanceRepository
    {
        Task<AccountEntity> GetAsync(long id);
        Task<AccountEntity> GetAsync(string cpf);
        Task<bool> ExistAsync(long id);
    }
}
