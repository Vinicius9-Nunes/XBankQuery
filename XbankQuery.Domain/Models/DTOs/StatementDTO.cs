using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;

namespace XbankQuery.Domain.Models.DTOs
{
    public class StatementDTO
    {
        public StatementDTO(string holderName, int dueDate, string accountStatus, double invoiceTotal)
        {
            HolderName = holderName;
            DueDate = dueDate;
            AccountStatus = accountStatus;
            InvoiceTotal = invoiceTotal;
        }

        public string HolderName { get; set; }
        public int DueDate { get; set; }
        public string AccountStatus { get; set; }
        public double InvoiceTotal { get; set; }
        public List<DetailsTransactionDTO> DetailsTransactionDTOs { get; set; }

        public void AddDetailsTransaction(IEnumerable<TransactionEntity> transactions)
        {
            DetailsTransactionDTOs = transactions.Select(trans => new DetailsTransactionDTO(
                    trans.Description,
                    trans.Amount,
                    trans.TransactionDate
                )).ToList();
        }
    }
}
