namespace JiffyLend.Module.Core.Application.Endpoints.Customer;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class CreateCustomerEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("customer", async (CreateCustomer command, ISender sender, CancellationToken token) =>
        {
            var result = await sender
                .Send(command.ToCreateCustomerCommand(), token);

            return result.IsSuccess switch
            {
                true => Results.Created($"customer/{result.Data}", result.Data),
                _ => Results.BadRequest(result.Errors)
            };
        })
        .Produces<Guid>(StatusCodes.Status201Created)
        .Produces<string[]>(StatusCodes.Status400BadRequest)
        .WithTags("Customer");
    }
}