using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XbankQuery.Domain.Entities;

namespace XbankQuery.Domain.Interfaces
{
    public interface IBankStatementRepository
    {
        Task<List<TransactionEntity>> GetStatement(long id, DateTime initialDate, DateTime finalDate);
    }
}
