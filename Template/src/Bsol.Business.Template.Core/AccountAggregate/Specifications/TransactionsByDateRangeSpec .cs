using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Bsol.Business.Template.Core.AccountAggregate.Specifications;
public class TransactionsByDateRangeSpec : Specification<TransactionAggregate.Transaction>
{
    public TransactionsByDateRangeSpec(DateTime from, DateTime to)
    {
        Query.Where(t => t.Timestamp >= from && t.Timestamp <= to);
    }
}
