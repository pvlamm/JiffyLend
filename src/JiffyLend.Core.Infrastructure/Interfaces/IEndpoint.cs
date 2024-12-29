namespace JiffyLend.Core.Interfaces;

using Microsoft.AspNetCore.Routing;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}