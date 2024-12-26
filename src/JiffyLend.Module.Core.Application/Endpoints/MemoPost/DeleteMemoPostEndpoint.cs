namespace JiffyLend.Module.Core.Application.Endpoints.MemoPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Core.Interfaces;
using JiffyLend.Module.Core.Application.MemoPost.Commands;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

public class DeleteMemoPostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("memo-post/{id:guid}", async (Guid id, ISender sender, CancellationToken token) => {

            var result = await sender
                .Send(new DeleteMemoPostCommand { Id = id }, token);

            if (result)
                return OkResult;

            else
                return NotFoundResult;

        }).WithTags("Memo-Post");
    }
}
