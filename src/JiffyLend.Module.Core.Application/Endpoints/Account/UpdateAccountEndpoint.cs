namespace JiffyLend.Module.Core.Application.Endpoints.Account;
using System;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class UpdateAccountEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("account/{id:guid}", async (Guid id, 
            UpdateAccount updateAccount, 
            ISender sender, 
            CancellationToken token) => {

                var updateAccountCommand = updateAccount.ToUpdateAccountCommand();
                updateAccountCommand.Id = id;

                await sender.Send(updateAccountCommand, token);

            }).WithTags("Account");
    }
}
