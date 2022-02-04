using Bogus;
using Moq;
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
using XBankQuery.Application.Service.Statement;
using Xunit;

namespace XBankQuery.Tests.Services.Statement
{
    public class StatementServiceTests
    {
        private IStatementService _statementService;
        private Faker faker;
        public StatementServiceTests()
        {
            _statementService = new StatementService(new Mock<IBankBalanceRepository>().Object);
            this.faker = new Faker("pt_BR");
        }

        [Fact]
        public async void Build_Statement_From_Invalid_Entity()
        {
            AccountEntity accountEntity = Utilities.BuildAccountEntity();
            await Assert.ThrowsAsync<Exception>(() => _statementService.BuildStatement(accountEntity));
        }

        [Fact]
        public async void Build_Statement_From_Valid_Entity()
        {
            AccountEntity accountEntity = Utilities.BuildAccountEntity(true);
            StatementDTO statementDTO = await _statementService.BuildStatement(accountEntity);
            Assert.NotNull(statementDTO);
        }
    }
}
