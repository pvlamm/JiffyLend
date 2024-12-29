namespace JiffyLend.Module.Core.Application.Endpoints.MemoPost;
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

public class CreateMemoPostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("memo-post",
            async (CreateMemoPost command,
            ISender sender,
            CancellationToken token) =>
            {
                MemoPostMapper mapper = new MemoPostMapper();
                var createMemoPostCommand = 
                    mapper.ToCreateMemoPostCommand(command);

                var result = await sender
                    .Send(createMemoPostCommand, token);

                return result.IsSuccess switch
                {
                    true => Results.Created($"memo-post/{result.Data}", result.Data),
                    _ => Results.BadRequest(result.Errors)
                };

            })
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces<string[]>(StatusCodes.Status400BadRequest)
            .WithTags("Memo-Post");
    }
}
