using Bsol.Business.Template.SharedKernel.Audit;
using Bsol.Business.Template.SharedKernel.Interfaces;

namespace Bsol.Business.Template.Core.AccountAggregate;

public class Account : AuditableEntity, IAggregateRoot
{
    public string AccountNumber { get; private set; } = null!;
    public decimal Balance { get; private set; }

    public string Status { get; private set; } = "active";
    public bool IsDeleted { get; private set; }

    private Account() { } // requerido por EF

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public void Credit(decimal amount)
    {
        Balance += amount;
    }

    public void Debit(decimal amount)
    {
        if (Balance < amount)
            throw new InvalidOperationException("Saldo insuficiente");

        Balance -= amount;
    }
}
