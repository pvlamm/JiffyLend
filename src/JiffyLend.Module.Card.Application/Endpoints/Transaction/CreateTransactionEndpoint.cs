namespace JiffyLend.Module.Card.Application.Endpoints.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Card.Application.Common.Models;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class CreateTransactionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/transaction", async (CreateTransaction transaction, ISender sender, CancellationToken token) =>
        {
            // await sender.Send(transaction.ToCreateTransactionCommand, token);
            return true;
        }).WithTags("Transaction");
    }
}
