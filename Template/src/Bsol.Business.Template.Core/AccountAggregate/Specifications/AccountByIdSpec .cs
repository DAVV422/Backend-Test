using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Bsol.Business.Template.Core.AccountAggregate.Specifications;
public class AccountByIdSpec : Specification<Account>, ISingleResultSpecification<Account>
{
    public AccountByIdSpec(Guid id)
    {
        Query.Where(a => a.Id == id);
    }
}
