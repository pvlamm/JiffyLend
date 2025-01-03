namespace JiffyLend.Core.Infrastructure.Security.Behaviors;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
            {
                var code = 400;
                var message = "Validation error";
                var errors = failures.Select(err => err.ErrorMessage).ToArray();

                var genericType = typeof(Result<>);

                var resp = typeof(TResponse);
                var typeArguments = resp.GenericTypeArguments;
                var specificType = genericType.MakeGenericType(typeArguments);

                return (TResponse)Activator.CreateInstance(specificType, new object[] { errors });

                //var errorObj = new Result<TResponse>(["test", "test"]);

                //var respmore = Activator.CreateInstance(typeof(TResponse));

                //return (TResponse)Activator.CreateInstance(typeof(TResponse), errors);

                //Result<TResponse>.Failure(errors);
                //throw new ValidationException(failures);
            }
        }
        return await next();
    }
}