using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.TransactionAggregate;

namespace Bsol.Business.Template.Core.UseCases.Transaction.GetTransactions;

public class GetTransactionsQueryHandler(SharedKernel.Interfaces.IRepository<TransactionAggregate.Transaction> _repository)
    : IQueryHandler<GetTransactionsQuery, Result<List<TransactionAggregate.Transaction>>>
{
    public async Task<Result<List<TransactionAggregate.Transaction>>> Handle(GetTransactionsQuery request, CancellationToken ct)
    {
        var transactions = await _repository.ListAsync(ct);

        return transactions;
    }
}
