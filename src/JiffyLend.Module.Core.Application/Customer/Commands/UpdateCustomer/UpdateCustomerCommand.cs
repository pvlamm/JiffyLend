namespace JiffyLend.Module.Core.Application.Customer.Commands;

using System;
using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MassTransit;

using MediatR;

public class UpdateCustomerCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<bool>>
{
    private readonly ICustomerService _customerService;
    private readonly IPublishEndpoint _publish;
    public UpdateCustomerCommandHandler(ICustomerService customerService, IPublishEndpoint publish)
    {
        _customerService = customerService;
        _publish = publish;
    }

    public async Task<Result<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();
        await _customerService.Update(customer, cancellationToken);
        await _publish.Publish<IUpdatedACustomer>(new
        {
            request.Id,
            DisplayName = $"{request.FirstName} {request.LastName}",
            ChangeDate = customer.UpdateDate
        }, cancellationToken);

        return true;
    }
}