namespace JiffyLend.Module.Card.Application.Endpoints.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Core.Interfaces;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class ClearTransactionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/transaction/{id:guid}/clear", async (Guid id, ISender sender, CancellationToken token) =>
        {

        }).WithTags("Transaction");
    }
}
