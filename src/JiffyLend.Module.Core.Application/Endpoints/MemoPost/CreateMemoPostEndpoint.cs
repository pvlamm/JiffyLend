namespace JiffyLend.Module.Core.Application.Endpoints.MemoPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Core.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

public class CreateMemoPostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("memo-post", async ()
    }
}
