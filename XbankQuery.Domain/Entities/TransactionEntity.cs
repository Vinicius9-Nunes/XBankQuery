using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Enums;

namespace XbankQuery.Domain.Entities
{
    public class TransactionEntity : BaseEntity
    {
        public string Description { get; private set; }
        public double Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public long AccountEntityId { get; private set; }
    }
}
