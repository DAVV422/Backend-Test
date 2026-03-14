using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

public class GetTransactions(IMediator _mediator)
: EndpointWithoutRequest<Results<Ok<List<TransactionResponse>>, ProblemDetails>>
{
    public override void Configure()
    {
        Version(1);
        Get("/transactions");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<List<TransactionResponse>>, ProblemDetails>> ExecuteAsync(CancellationToken ct)
    {
        var result = await _mediator.Send(new GetTransactionsQuery(), ct);

        if (!result.IsSuccess)
        {
            return new ProblemDetails
            {
                Detail = result.Errors.FirstOrDefault(),
                Status = StatusCodes.Status403Forbidden
            };
        }

        var response = result.Value.Select(t => new TransactionResponse(
            t.Id,
            t.TransactionType,
            t.SourceAccountId,
            t.DestinationAccountId,
            t.Amount,
            t.Timestamp,
            t.VoucherCode
        )).ToList();

        return TypedResults.Ok(response);
    }
}
