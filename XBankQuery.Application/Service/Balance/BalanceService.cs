using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Enums;
using XbankQuery.Domain.Interfaces.BalanceService;
using XbankQuery.Domain.Models.DTOs;

namespace XBankQuery.Application.Service.Balance
{
    public class BalanceService : IBalanceService
    {
        private readonly IMapper _mapper;

        public BalanceService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<AccountDTO> GetBalanceAccount(AccountEntity accountEntity)
        {
            if (accountEntity.AccountStatus != AccountStatus.Active)
                throw new Exception($"Essa conta encontra-se {accountEntity.AccountStatus.ToString()} por favor entre em contato com o banco para validar o ocorrido.");

            return _mapper.Map<AccountDTO>(accountEntity);
        }
    }
}
