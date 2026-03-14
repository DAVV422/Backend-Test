using System.ComponentModel.DataAnnotations;

namespace Bsol.Business.Template.Api.Endpoints.Transactions;

public class CreateTransactionRequest
{
    public const string Route = "/transactions";

    [Required]
    public required string SourceAccountNumber { get; set; }

    [Required]
    public required string DestinationAccountNumber { get; set; }

    [Required]
    public decimal Amount { get; set; }
}
