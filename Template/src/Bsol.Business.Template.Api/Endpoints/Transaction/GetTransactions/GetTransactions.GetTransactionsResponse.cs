public record TransactionResponse(
    Guid Id,
    string TransactionType,
    Guid SourceAccountId,
    Guid DestinationAccountId,
    decimal Amount,
    DateTime Timestamp,
    string VoucherCode
);
