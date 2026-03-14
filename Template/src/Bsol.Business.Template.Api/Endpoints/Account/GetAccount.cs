using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

public class GetAccount(IMediator _mediator)
: Endpoint<GetAccountRequest, Results<Ok<GetAccountResponse>, NotFound, ProblemDetails>>
{
    public override void Configure()
    {
        Version(1);
        Get(GetAccountRequest.Route);
        AllowAnonymous();
    }

    public override async Task<Results<Ok<GetAccountResponse>, NotFound, ProblemDetails>> ExecuteAsync(
        GetAccountRequest request,
        CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAccountQuery(request.AccountId), ct);

        if (!result.IsSuccess)
        {
            return new ProblemDetails{
                Detail = result.Errors.FirstOrDefault(),
                Status = StatusCodes.Status403Forbidden
             };
        }

        var account = result.Value;

        return TypedResults.Ok(
            new GetAccountResponse(
                account.Id,
                account.AccountNumber,
                account.Balance
            )
        );
    }
}
