using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Interfaces.StatementService;
using XbankQuery.Domain.Models.DTOs;

namespace XBankQuery.Application.Service
{
    public class BankStatementService : IBankStatementService
    {
        private readonly IBankStatementRepository _bankStatementRepository;
        private readonly IStatementService _statementService;
        public BankStatementService(IBankStatementRepository bankStatementRepository, IStatementService statementService)
        {
            _bankStatementRepository = bankStatementRepository;
            _statementService = statementService;
        }

        public async Task<object> GetStatement(long accountId, DateTime initialDate, DateTime finalDate)
        {
            if (initialDate == DateTime.MinValue || finalDate == DateTime.MinValue)
                throw new Exception("Favor informar datas validas.");
            if (finalDate >= initialDate.AddDays(30))
                throw new Exception("Periodo maximo de uma fatura é de 30 dias.");

            initialDate = new DateTime(initialDate.Year, initialDate.Month, initialDate.Day, 0, 0, 0);
            finalDate = new DateTime(finalDate.Year, finalDate.Month, finalDate.Day, 23, 59, 59);

            AccountEntity accountEntity = await _statementService.GetAccount(accountId);
            if (accountEntity == null)
                throw new Exception("Não foi possivel recuperar a conta.");

            List<TransactionEntity> transactions = await _bankStatementRepository.GetStatement(accountId, initialDate, finalDate);

            if(transactions?.Count > 0)
            {
                accountEntity.AddTransactions(transactions);
                StatementDTO statementDTO = await _statementService.BuildStatement(accountEntity);
                return statementDTO;
            }
            else
            {
                return new
                {
                    HolderName = accountEntity.HolderName,
                    DueDate = accountEntity.DueDate,
                    AccountStatus = accountEntity.AccountStatus.ToString(),
                    InvoiceTotal = "Não há valores em abertos para essa fatura"
                };
            }
        }
    }
}
