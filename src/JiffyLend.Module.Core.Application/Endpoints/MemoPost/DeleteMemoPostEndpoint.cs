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

            var result = await sender
                .Send(new DeleteMemoPostCommand { Id = id }, token);

                return result.IsSuccess switch
                {
                    true => Results.Ok(),
                    _ => Results.BadRequest(result.Errors)
                };
            })
            .Produces(StatusCodes.Status200OK)
            .Produces<string[]>(StatusCodes.Status400BadRequest)
            .WithTags("Memo-Post");
    }
}
