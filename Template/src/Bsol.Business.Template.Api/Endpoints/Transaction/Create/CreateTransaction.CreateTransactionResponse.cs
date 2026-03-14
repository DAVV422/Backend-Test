namespace Bsol.Business.Template.Api.Endpoints.Transactions;

public record CreateTransactionResponse(
    Guid TransactionId,
    string VoucherCode
);
