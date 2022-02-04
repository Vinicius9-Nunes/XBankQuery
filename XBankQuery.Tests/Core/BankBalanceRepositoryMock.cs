using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Enums;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Models.DTOs;

namespace XBankQuery.Tests.Core
{
    public class BankBalanceRepositoryMock : IBankBalanceRepository
    {
        private string defaultCpf;
        private long defaultId;
        private Faker faker;
        public BankBalanceRepositoryMock(string defaultCpf, long defaultId)
        {
            this.defaultCpf = defaultCpf;
            this.defaultId = defaultId;
            this.faker = new Faker("pt_BR");
        }

        public async Task<bool> ExistAsync(long id)
        {
            return await GetAsync(id) != null;
        }

        public async Task<AccountEntity> GetAsync(long id)
        {
            AccountEntity accountEntity = new AccountEntity(defaultId,
                            faker.Person.FullName,
                            defaultCpf,
                            faker.Random.Double(1, 100),
                            faker.Random.Int(1, 28),
                            AccountStatus.Active);
            return accountEntity.Id == defaultId ? accountEntity : null;
        }

        public async Task<AccountEntity> GetAsync(string cpf)
        {
            AccountEntity accountEntity = new AccountEntity(defaultId,
                                        faker.Person.FullName,
                                        defaultCpf,
                                        faker.Random.Double(1, 100),
                                        faker.Random.Int(1, 28),
                                        AccountStatus.Active);
            return accountEntity.HolderCpf.Equals(cpf) ? accountEntity : null;
        }
    }
}
