namespace JiffyLend.Module.Core.Application.Customer.Commands;

using System;

using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MassTransit;

using MediatR;

public class CreateCustomerCommand : IRequest<Result<Guid>>
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string EmailAddress { get; set; }
    public virtual DateTime DateOfBirth { get; set; }
}

public class CreateCustomerCommandHanlder : IRequestHandler<CreateCustomerCommand, Result<Guid>>
{
    private readonly ICustomerService _customerService;
    private readonly IPublishEndpoint _publish;
    public CreateCustomerCommandHanlder(ICustomerService customerService, IPublishEndpoint publish)
    {
        _customerService = customerService;
        _publish = publish;
    }

    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();
        await _customerService.Create(customer, cancellationToken);
        await _publish.Publish<ICreatedACustomer>(new
        {
            customer.Id,
            DisplayName = $"{customer.FirstName} {customer.LastName}",
            ChangeDate = customer.CreateDate
        }, cancellationToken);

        return customer.Id;
    }
}
