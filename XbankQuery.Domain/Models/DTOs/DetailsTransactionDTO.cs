using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XbankQuery.Domain.Models.DTOs
{
    public class DetailsTransactionDTO
    {
        public DetailsTransactionDTO(string description, double amount, DateTime transactionDate)
        {
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public override string ToString()
        {
            return $"Descrição da Compra: {Description}." +
                $"{Environment.NewLine}" +
                $"Valor da Compra: {Amount.ToString("N2")}" +
                $"{Environment.NewLine}" +
                $"Data da Compra: {TransactionDate.ToString("dddd, dd MMMM yyyy")}" +
                $"{Environment.NewLine}";
        }
    }
}
