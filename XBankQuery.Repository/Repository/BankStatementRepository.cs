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
using XbankQuery.Domain.Enums;

namespace XBankQuery.Repository.Repository
{
    public class BankStatementRepository : IBankStatementRepository
    {
        private readonly IConfiguration _configuration;

        public BankStatementRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<TransactionEntity>> GetStatement(long accountId, DateTime initialDate, DateTime finalDate)
        {
            string connectionString = _configuration.GetConnectionString("Default");
            using SqlConnection connection = new SqlConnection(connectionString);
            string query = $"SELECT * FROM XBank.Transactions " +
                            $"WHERE AccountEntityId = {accountId} " +
                            $"AND TransactionDate >= '{initialDate.ToString("yyyy/MM/dd HH:mm:ss").Replace('/', '-')}' " +
                            $"AND TransactionDate <= '{finalDate.ToString("yyyy/MM/dd HH:mm:ss").Replace('/', '-')}' " +
                            $"AND TransactionType = {(int)TransactionType.Credit}";
            IEnumerable<TransactionEntity> transactions = await connection.QueryAsync<TransactionEntity>(query);
            return transactions.ToList();
        }
    }
}
