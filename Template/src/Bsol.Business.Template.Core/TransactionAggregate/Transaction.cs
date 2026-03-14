using Ardalis.GuardClauses;
using Bsol.Business.Template.SharedKernel.Audit;
using Bsol.Business.Template.SharedKernel.Interfaces;

namespace Bsol.Business.Template.Core.TransactionAggregate;
public class Transaction : AuditableEntity, IAggregateRoot
{
    public string TransactionType { get; private set; } = null!;
    public Guid SourceAccountId { get; private set; }
    public Guid DestinationAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string VoucherCode { get; private set; } = null!;

    private Transaction() { }

    public Transaction(
        string transactionType,
        Guid sourceAccountId,
        Guid destinationAccountId,
        decimal amount,
        string voucherCode)
    {
        TransactionType = Guard.Against.NullOrEmpty(transactionType);
        SourceAccountId = sourceAccountId;
        DestinationAccountId = destinationAccountId;
        Amount = Guard.Against.NegativeOrZero(amount);
        VoucherCode = Guard.Against.NullOrEmpty(voucherCode);

        Timestamp = DateTime.UtcNow;
    }
}
