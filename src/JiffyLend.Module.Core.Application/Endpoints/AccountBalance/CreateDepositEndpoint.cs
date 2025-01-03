namespace JiffyLend.Module.Core.Application.Endpoints.AccountBalance;

using System;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class CreateDepositEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("account-balance/{id:guid}/deposit", async (Guid id,
            CreateDeposit createDeposit,
            ISender sender,
            CancellationToken token) =>
        {
            //var createDepositCommand = createDeposit.ToCreateDepositCommand();
            //createDepositCommand.AccountId = id;
            //await sender.Send(createDepositCommand, token);
        }).WithTags("AccountBalance");
    }
}