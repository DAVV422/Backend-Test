using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Bsol.Business.Template.Core.AccountAggregate.Specifications;
public class AccountByNumberSpec : Specification<Account>, ISingleResultSpecification<Account>
{
    public AccountByNumberSpec(string accountNumber)
    {
        Query.Where(a => a.AccountNumber == accountNumber);
    }
}
