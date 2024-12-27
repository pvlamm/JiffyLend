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
                await sender
                    .Send(new ClearMemoPostCommand { Id = id }, token);

                return Results.Accepted();

            }).WithTags("Memo-Post");
    }
}
