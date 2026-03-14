using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.TransactionAggregate;

public record TransferCommand(
    string SourceAccountNumber,
    string DestinationAccountNumber,
    decimal Amount
) : ICommand<Result<Transaction>>;
