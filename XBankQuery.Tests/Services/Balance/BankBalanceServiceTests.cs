using AutoMapper;
using Bogus;
using Bogus.Extensions.Brazil;
using Moq;
using System;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Interfaces.BalanceService;
using XbankQuery.Domain.Models.DTOs;
using XBankQuery.Application.Service;
using XBankQuery.Application.Service.Balance;
using XBankQuery.Tests.Core;
using Xunit;

namespace XBankQuery.Tests.Services.Balance
{
    public class BankBalanceServiceTests
    {
        private IBankBalanceService _bankBalanceService;
        private IMapper _mapper;
        private Faker faker;
        public BankBalanceServiceTests()
        {
            _bankBalanceService = new BankBalanceService(
                                    new Mock<IBankBalanceRepository>().Object, 
                                    new Mock<IBalanceService>().Object);

            this.faker = new Faker("pt_BR");
            _mapper = InstanceFactory.GetValidMapper();
        }

        [Fact]
        public async void Get_InvalidBalanceAccountByCpf()
        {
            string cpfNonExistent = "00000000000";
            await Assert.ThrowsAsync<Exception>(() => _bankBalanceService.GetBalanceAccountByCpf(cpfNonExistent));
        }
        [Fact]
        public async void Get_InvalidBalanceAccountById()
        {
            long accountId = 0;
            await Assert.ThrowsAsync<Exception>(() => _bankBalanceService.GetBalanceAccountById(accountId));
        }

        [Fact]
        public async void Get_Valid_BalanceAccountById()
        {
            string defaultCpf = faker.Person.Cpf();
            long defaultId = faker.Random.Long(1, 10);
            IBankBalanceRepository bankBalanceRepositoryMock = new BankBalanceRepositoryMock(
                                                                defaultCpf,
                                                                defaultId);

            IBankBalanceService bankBalanceService = new BankBalanceService(
                                                        bankBalanceRepositoryMock, 
                                                        new BalanceService(_mapper));

            AccountDTO accountDTO = await bankBalanceService.GetBalanceAccountById(defaultId);
            Assert.NotNull(accountDTO);
            Assert.NotNull(accountDTO.HolderCpf);
            Assert.True(accountDTO.HolderName.Length > 0);
        }
    }
}
