
using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.TransactionAggregate;

public record GetTransactionsQuery()
    : IQuery<Result<List<Transaction>>>;
