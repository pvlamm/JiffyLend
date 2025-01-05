namespace JiffyLend.Module.Core.Application.Endpoints.Account;

using JiffyLend.Core.Infrastructure.Models;
using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.Account.Queries;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class GetAccountEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("account/{id:guid}", async (Guid id, ISender sender, CancellationToken token) =>
        {
            var result = await sender
                .Send(new GetAccountInfoByIdQuery { Id = id }, token);

            return result.IsSuccess switch
            {
                true => Results.Ok(result.Data),
                _ => Results.BadRequest(result.Errors)
            };
        }).Produces<AccountInfo>(StatusCodes.Status200OK)
            .Produces<string[]>(StatusCodes.Status400BadRequest)
            .WithTags("Account");
    }
}
