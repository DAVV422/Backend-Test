using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Bsol.Business.Template.Core.AccountAggregate.Specifications;
public class TransactionsByAccountSpec : Specification<TransactionAggregate.Transaction>
{
    public TransactionsByAccountSpec(Guid accountId)
    {
        Query.Where(t =>
            t.SourceAccountId == accountId ||
            t.DestinationAccountId == accountId
        );
    }
}
