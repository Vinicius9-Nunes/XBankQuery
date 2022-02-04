using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Enums;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Interfaces.StatementService;
using XbankQuery.Domain.Models.DTOs;

namespace XBankQuery.Application.Service.Statement
{
    public class StatementService : IStatementService
    {
        private readonly IBankBalanceRepository _bankBalanceRepository;

        public StatementService(IBankBalanceRepository bankBalanceRepository)
        {
            _bankBalanceRepository = bankBalanceRepository;
        }

        public async Task<StatementDTO> BuildStatement(AccountEntity accountEntity)
        {
            if (accountEntity.Id < 1 || accountEntity.Transactions == null ||accountEntity.Transactions.ToList().Count < 1)
                throw new Exception("Objeto invalido para construção do extrato.");

            double fullValue = GetFullValue(accountEntity.Transactions);

            StatementDTO statementDTO = new StatementDTO(
                    accountEntity.HolderName,
                    accountEntity.DueDate,
                    accountEntity.AccountStatus.ToString(),
                    fullValue
                );
            statementDTO.AddDetailsTransaction(accountEntity.Transactions);
            return statementDTO;
        }

        public async Task<AccountEntity> GetAccount(long accountId)
        {
            if (!await _bankBalanceRepository.ExistAsync(accountId))
                throw new Exception("Não foi localizado uma conta com o Id informado.");

            AccountEntity accountEntity = await _bankBalanceRepository.GetAsync(accountId);
            if (accountEntity.AccountStatus != AccountStatus.Active)
                throw new Exception($"Não é possivel atualizar a conta pois a mesma esta com status de {accountEntity.AccountStatus.ToString()}.");

            return accountEntity;
        }

        private double GetFullValue(IEnumerable<TransactionEntity> transactions)
        {
            double fullValue = 0;
            foreach (TransactionEntity transaction in transactions)
            {
                fullValue += transaction.Amount;
            }
            return fullValue;
        }
    }
}
