public class GetAccountRequest
{
    public const string Route = "/accounts/{accountId}";

    public string AccountId { get; set; }
}
