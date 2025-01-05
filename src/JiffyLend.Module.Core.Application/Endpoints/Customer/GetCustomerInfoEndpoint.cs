namespace JiffyLend.Module.Core.Application.Endpoints.Customer;

using System;

using JiffyLend.Core.Infrastructure.Models;
using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Customer.Queries;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class GetCustomerInfoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("customer/{id:guid}", async (Guid id, ISender sender, CancellationToken token) =>
        {
            var result = await sender
                .Send(new GetCustomerInfoByIdQuery { Id = id }, token);

            return result.IsSuccess switch
            {
                true => Results.Ok(result.Data),
                _ => Results.BadRequest(result.Errors)
            };
        })
        .Produces<CustomerInfo>(StatusCodes.Status200OK)
        .Produces<string[]>(StatusCodes.Status400BadRequest)
        .WithTags("Customer");
    }
}