using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;
using XbankQuery.Domain.Interfaces;
using Dapper;

namespace XBankQuery.Repository.Repository
{
    public class BankBalanceRepository : IBankBalanceRepository
    {
        private readonly IConfiguration _configuration;

        public BankBalanceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ExistAsync(long id)
        {
            AccountEntity transactionEntity = await GetAsync(id);
            return transactionEntity?.Id > 0;
        }

        public async Task<AccountEntity> GetAsync(long id)
        {
            string connectionString = _configuration.GetConnectionString("Default");
            using SqlConnection connection = new SqlConnection(connectionString);
            string query = $"SELECT * FROM XBank.Accounts" +
                            $" WHERE Id = {id}";
            AccountEntity accountEntity = await connection.QueryFirstOrDefaultAsync<AccountEntity>(query);
            return accountEntity;
        }

        public async Task<AccountEntity> GetAsync(string cpf)
        {
            string connectionString = _configuration.GetConnectionString("Default");
            using SqlConnection connection = new SqlConnection(connectionString);
            AccountEntity accountEntity = await connection.QueryFirstOrDefaultAsync<AccountEntity>(
                    $"SELECT * FROM XBank.Accounts " +
                    $"WHERE HolderCpf = '{cpf}'"
                );
            return accountEntity;
        }
    }
}
