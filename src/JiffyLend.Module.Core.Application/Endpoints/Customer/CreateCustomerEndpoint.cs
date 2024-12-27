namespace JiffyLend.Module.Core.Application.Endpoints.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var mapper = new CustomerMapper();
            var createCustomerCommand = mapper
                .ToCreateCustomerCommand(command);

            var result = await sender
                .Send(createCustomerCommand, token);

            return Results.Created($"customer/{result}", result);

        }).WithTags("Customer");
    }
}
