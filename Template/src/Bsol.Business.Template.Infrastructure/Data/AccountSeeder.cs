using Bsol.Business.Template.Core.AccountAggregate;
using Microsoft.EntityFrameworkCore;

namespace Bsol.Business.Template.Infrastructure.Data;

public static class AccountSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Accounts.AnyAsync())
            return;

        var accounts = new List<Account>
        {
            new Account("10001", 5000m),
            new Account("10002", 2500m),
            new Account("10003", 100m),
            new Account("10004", 0m),
            new Account("10005", 100000m)
        };

        context.Accounts.AddRange(accounts);
        await context.SaveChangesAsync();
    }
}
