using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.AccountAggregate;
using Bsol.Business.Template.Core.AccountAggregate.Specifications;

namespace Bsol.Business.Template.Core.UseCases.Account;

public class GetAccountQueryHandler(SharedKernel.Interfaces.IRepository<AccountAggregate.Account> _repository)
    : IQueryHandler<GetAccountQuery, Result<AccountAggregate.Account>>
{

    public async Task<Result<AccountAggregate.Account>> Handle(GetAccountQuery request, CancellationToken ct)
    {
        AccountAggregate.Account? account;

        if (Guid.TryParse(request.AccountId, out var accountId))
        {
            account = await _repository.FirstOrDefaultAsync(
                new AccountByIdSpec(accountId), ct);
        }
        else
        {
            account = await _repository.FirstOrDefaultAsync(
                new AccountByNumberSpec(request.AccountId), ct);
        }

        if (account is null)
            return Result.NotFound("Cuenta no encontrada");

        return account;
    }
}
