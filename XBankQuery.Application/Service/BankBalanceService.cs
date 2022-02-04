using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Interfaces.BalanceService;
using XbankQuery.Domain.Models.DTOs;

namespace XBankQuery.Application.Service
{
    public class BankBalanceService : IBankBalanceService
    {
        private readonly IBankBalanceRepository _bankBalanceRepository;
        private readonly IBalanceService _balanceService;

        public BankBalanceService(IBankBalanceRepository bankBalanceRepository, IBalanceService balanceService)
        {
            _bankBalanceRepository = bankBalanceRepository;
            _balanceService = balanceService;
        }

        public async Task<AccountDTO> GetBalanceAccountByCpf(string cpf)
        {
            AccountEntity accountEntity = await _bankBalanceRepository.GetAsync(cpf);
            if (accountEntity == null || accountEntity?.Id < 1)
                throw new Exception("Não foi localizado conta pelo cpf informado.");

            AccountDTO accountDTO = await _balanceService.GetBalanceAccount(accountEntity);
            return accountDTO;
        }

        public async Task<AccountDTO> GetBalanceAccountById(long id)
        {
            if (!await _bankBalanceRepository.ExistAsync(id))
                throw new Exception("Não foi localizado uma conta pelo Id informado.");

                AccountEntity accountEntity = await _bankBalanceRepository.GetAsync(id);
            if (accountEntity == null || accountEntity?.Id < 1)
                throw new Exception("Não foi localizado conta pelo id informado.");

            AccountDTO accountDTO = await _balanceService.GetBalanceAccount(accountEntity);
            return accountDTO;
        }
    }
}
