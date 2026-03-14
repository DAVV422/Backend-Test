using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bsol.Business.Template.Api.Endpoints.Transactions;

public class Create(IMediator _mediator)
: Endpoint<CreateTransactionRequest, Results<Ok<CreateTransactionResponse>, ProblemDetails>>
{
    public override void Configure()
    {
        Version(1);
        Post(CreateTransactionRequest.Route);
        AllowAnonymous();
    }

    public override async Task<Results<Ok<CreateTransactionResponse>, ProblemDetails>> ExecuteAsync(
        CreateTransactionRequest request,
        CancellationToken ct)
    {
        var command = new TransferCommand(
            request.SourceAccountNumber,
            request.DestinationAccountNumber,
            request.Amount
        );

        var result = await _mediator.Send(command, ct);

        if (!result.IsSuccess)
        {
            return new ProblemDetails
            {
                Detail = result.Errors.FirstOrDefault(),
                Status = StatusCodes.Status403Forbidden
            };
        }

        return TypedResults.Ok(
            new CreateTransactionResponse(
                result.Value.Id,
                result.Value.VoucherCode
            )
        );
    }
}
