namespace JiffyLend.Core.Infrastructure.Security.Behaviors;

using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Interfaces;

using MediatR.Pipeline;

using Microsoft.Extensions.Logging;


public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly IUser _user;

    public LoggingBehavior(ILogger<TRequest> logger, IUser user)
    {
        _logger = logger;
        _user = user;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _user.Id;
        string? userName = _user.EmailAddress;

        _logger.LogInformation("JiffyLend Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
    }
}
