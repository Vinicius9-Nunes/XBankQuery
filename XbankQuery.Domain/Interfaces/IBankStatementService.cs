using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XbankQuery.Domain.Interfaces
{
    public interface IBankStatementService
    {
        Task<object> GetStatement(long accountId, DateTime initialDate, DateTime finalDate);
    }
}
