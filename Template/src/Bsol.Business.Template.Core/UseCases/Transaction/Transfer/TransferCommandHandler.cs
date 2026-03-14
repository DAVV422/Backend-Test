using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.AccountAggregate.Specifications;
using Bsol.Business.Template.Core.AccountAggregate;

namespace Bsol.Business.Template.Core.UseCases.Transaction.GetTransactions;

public class TransferCommandHandler(SharedKernel.Interfaces.IRepository<TransactionAggregate.Transaction> _repository,
    SharedKernel.Interfaces.IRepository<AccountAggregate.Account> _accountRepository)
    : ICommandHandler<TransferCommand, Result<TransactionAggregate.Transaction>>
{

    public async Task<Result<TransactionAggregate.Transaction>> Handle(TransferCommand request, CancellationToken ct)
    {
        var source = await _accountRepository.FirstOrDefaultAsync(
            new AccountByNumberSpec(request.SourceAccountNumber), ct);

        var destination = await _accountRepository.FirstOrDefaultAsync(
            new AccountByNumberSpec(request.DestinationAccountNumber), ct);

        if (source == null || destination == null)
            return Result.NotFound("Cuenta no encontrada");

        source.Debit(request.Amount);
        destination.Credit(request.Amount);

        var voucher = $"TRX-{Guid.NewGuid().ToString()[..8]}";

        var transaction = new TransactionAggregate.Transaction(
            "Transfer",
            source.Id,
            destination.Id,
            request.Amount,
            voucher
        );

        await _repository.AddAsync(transaction, ct);

        return transaction;
    }
}
