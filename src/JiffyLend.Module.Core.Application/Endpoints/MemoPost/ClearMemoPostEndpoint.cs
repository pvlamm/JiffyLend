namespace JiffyLend.Module.Core.Application.Endpoints.MemoPost;
using System;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.MemoPost.Commands;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class ClearMemoPostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("memo-post/{id:guid}/clear",
            async (Guid id,
            ISender sender,
            CancellationToken token) =>
            {
                var result = await sender
                    .Send(new ClearMemoPostCommand { Id = id }, token);


                return result.IsSuccess switch
                {
                    true => Results.Accepted(),
                    _ => Results.BadRequest(result.Errors)
                };

            })
            .Produces(StatusCodes.Status202Accepted)
            .Produces<string[]>(StatusCodes.Status400BadRequest)
            .WithTags("Memo-Post");
    }
}
