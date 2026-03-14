using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Bsol.Business.Template.Core.AccountAggregate.Specifications;
public class ActiveAccountsSpec : Specification<Account>
{
    public ActiveAccountsSpec()
    {
        Query.Where(a => a.Status == "Active" && !a.IsDeleted);
    }
}
