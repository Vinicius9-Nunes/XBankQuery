using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XbankQuery.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; protected set; }
    }
}
