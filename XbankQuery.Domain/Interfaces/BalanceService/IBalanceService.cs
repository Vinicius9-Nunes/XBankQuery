using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Models.DTOs;

namespace XbankQuery.Domain.Interfaces.BalanceService
{
    public interface IBalanceService
    {
        Task<AccountDTO> GetBalanceAccount(AccountEntity accountEntity);
    }
}
