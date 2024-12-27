namespace JiffyLend.Module.Core.Application.Endpoints.Account;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class CreateAccountEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("account", async (CreateAccount account, ISender sender, CancellationToken token) =>
        {
            var id = await sender
                .Send(account.ToCreateAccountCommand(), token);

            return Results.Created($"account/{id}", id);

        }).WithTags("Account");
    }
}
