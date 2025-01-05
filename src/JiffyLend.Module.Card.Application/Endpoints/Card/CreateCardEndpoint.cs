namespace JiffyLend.Module.Card.Application.Endpoints.Card;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Card.Application.Common.Models;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class CreateCardEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("card", async (CreateCard card, ISender sender, CancellationToken token) => { 
        
        }).WithTags("Card");
    }
}
