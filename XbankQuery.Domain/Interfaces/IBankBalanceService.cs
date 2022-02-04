using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Models.DTOs;

namespace XbankQuery.Domain.Interfaces
{
    public interface IBankBalanceService
    {
        Task<AccountDTO> GetBalanceAccountById(long id);
        Task<AccountDTO> GetBalanceAccountByCpf(string cpf);
    }
}
