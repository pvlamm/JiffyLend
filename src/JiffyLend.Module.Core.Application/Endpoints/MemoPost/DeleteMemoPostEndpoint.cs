namespace JiffyLend.Module.Core.Application.Endpoints.MemoPost;
using System;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.MemoPost.Commands;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class DeleteMemoPostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("memo-post/{id:guid}", 
            async (Guid id, 
            ISender sender, 
            CancellationToken token) => {

            await sender
                .Send(new DeleteMemoPostCommand { Id = id }, token);

            return Results.Accepted();

        }).WithTags("Memo-Post");
    }
}
