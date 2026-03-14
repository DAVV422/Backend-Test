using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.AccountAggregate;

public record GetAccountQuery(string AccountId)
    : IQuery<Result<Account>>;
