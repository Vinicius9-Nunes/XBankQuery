using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Interfaces.StatementService;
using XBankQuery.Application.Service;
using Xunit;

namespace XBankQuery.Tests.Services.Statement
{
    public class BankStatementServiceTests
    {
        private IBankStatementService _bankStatementService;
        public BankStatementServiceTests()
        {
            _bankStatementService = new BankStatementService(
                                        new Mock<IBankStatementRepository>().Object,
                                        new Mock<IStatementService>().Object);
        }

        [Fact]
        public async void Get_InvalidStatement()
        {
            long accountId = 12;
            DateTime date = DateTime.Now;
            DateTime initialDate = date.AddDays(-30);
            DateTime finalDate = date;
            await Assert.ThrowsAsync<Exception>(() => _bankStatementService.GetStatement(accountId, initialDate, finalDate));
        }
        [Fact]
        public async void Get_Statement_With_InvalidDate()
        {
            const string ERROR_MESSAGE = "Favor informar datas validas";
            long accountId = 12;
            DateTime date = DateTime.MinValue;
            DateTime initialDate = date;
            DateTime finalDate = date;
            Exception exception = await Assert.ThrowsAsync<Exception>(() => _bankStatementService.GetStatement(accountId, initialDate, finalDate));
            Assert.Contains(ERROR_MESSAGE, exception.Message);
        }
        [Fact]
        public async void Get_Statement_With_InvalidDateRange()
        {
            const string ERROR_MESSAGE = "Periodo maximo de uma fatura é de 30 dias";
            long accountId = 12;
            DateTime date = DateTime.Now;
            DateTime initialDate = date.AddDays(-35);
            DateTime finalDate = date;
            Exception exception = await Assert.ThrowsAsync<Exception>(() => _bankStatementService.GetStatement(accountId, initialDate, finalDate));
            Assert.Contains(ERROR_MESSAGE, exception.Message);
        }
    }
}
