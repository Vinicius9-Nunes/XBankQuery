using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Enums;

namespace XbankQuery.Domain.Entities
{
    public class AccountEntity : BaseEntity
    {
        public string HolderName { get; private set; }
        public string HolderCpf { get; private set;}
        public double Balance { get; private set;}
        public int DueDate { get; private set;}
        public AccountStatus AccountStatus { get; private set;}
        public IEnumerable<TransactionEntity> Transactions { get; private set; }

        public AccountEntity(long id,string holderName, string holderCpf, double balance, int dueDate, AccountStatus accountStatus)
        {
            Id = id;
            HolderName = holderName;
            HolderCpf = holderCpf;
            Balance = balance;
            DueDate = dueDate;
            AccountStatus = accountStatus;
        }
        public AccountEntity(){}

        public void AddTransactions(List<TransactionEntity> transactions)
        {
            if(transactions.Count > 0)
            {
                Transactions = transactions;
            }
        }
    }
}
