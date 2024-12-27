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

public class UpdateCustomerEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("customer/{id:guid}",
            async (Guid id, 
            UpdateCustomer command,
            ISender sender,
            CancellationToken token) =>
            {
                if (command == null) return Results.NoContent();

                var updateCustomerCommand = command.ToUpdateCustomerCommand();
                updateCustomerCommand.Id = id;

                await sender
                    .Send(updateCustomerCommand, token);

                return Results.Accepted();

            }).WithTags("Customer");
    }
}
