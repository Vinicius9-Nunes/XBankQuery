using AutoMapper;
using Bogus;
using Bogus.Extensions.Brazil;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Enums;
using XbankQuery.Domain.Interfaces.BalanceService;
using XbankQuery.Domain.Models.DTOs;
using XBankQuery.Application.Service.Balance;
using Xunit;

namespace XBankQuery.Tests.Services.Balance
{
    public class BalanceServiceTests
    {
        private IBalanceService _balanceService;
        private Faker faker;
        public BalanceServiceTests()
        {
            _balanceService = new BalanceService(new Mock<IMapper>().Object);
            this.faker = new Faker("pt_BR");
        }

        [Fact]
        public async void Get_Disabled_Account()
        {
            AccountEntity accountEntity = new AccountEntity(1, 
                                                faker.Person.FullName, 
                                                faker.Person.Cpf(), 
                                                0, 
                                                15, 
                                                AccountStatus.Disabled);
            await Assert.ThrowsAsync<Exception>(() => _balanceService.GetBalanceAccount(accountEntity));
        }

        [Fact]
        public async void Get_Suspended_Account()
        {
            AccountEntity accountEntity = new AccountEntity(2,
                                                faker.Person.FullName,
                                                faker.Person.Cpf(),
                                                0,
                                                15,
                                                AccountStatus.Suspended);
            await Assert.ThrowsAsync<Exception>(() => _balanceService.GetBalanceAccount(accountEntity));
        }
    }
}
