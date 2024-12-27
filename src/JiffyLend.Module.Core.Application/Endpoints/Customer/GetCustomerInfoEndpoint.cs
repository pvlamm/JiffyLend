namespace JiffyLend.Module.Core.Application.Endpoints.Customer;
using System;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.Customer.Queries;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class GetCustomerInfoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("customer/{id:guid}", async (Guid id, ISender sender, CancellationToken token) => {

            var customerInfo = await sender
                .Send(new GetCustomerInfoByIdQuery { Id = id }, token);

            return customerInfo;
        }).WithTags("Customer");
    }
}
