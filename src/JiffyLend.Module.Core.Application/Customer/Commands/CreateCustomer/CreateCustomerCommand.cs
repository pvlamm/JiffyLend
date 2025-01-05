namespace JiffyLend.Module.Core.Application.Customer.Commands;

using System;

using JiffyLend.Core.Common.Interfaces;
using JiffyLend.Core.Extensions;
using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Core.Infrastructure.Models;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MassTransit;

using MediatR;

public class CreateCustomerCommand : IRequest<Result<CustomerInfo>>
{
    public Guid AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class CreateCustomerCommandHanlder : IRequestHandler<CreateCustomerCommand, Result<CustomerInfo>>
{
    private readonly ICustomerService _customerService;
    private readonly IDateTime _dateTime;
    private readonly IPublishEndpoint _publish;
    public CreateCustomerCommandHanlder(ICustomerService customerService, IDateTime dateTime, IPublishEndpoint publish)
    {
        _customerService = customerService;
        _dateTime = dateTime;
        _publish = publish;
    }

    public async Task<Result<CustomerInfo>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();

        customer.Id = JiffyGuid.NewId();
        customer.CreateDate = _dateTime.Now;
        customer.UpdateDate = customer.CreateDate;

        await _customerService.Create(customer, cancellationToken);

        await _publish.Publish<ICreatedACustomer>(new
        {
            customer.Id,
            DisplayName = $"{customer.FirstName} {customer.LastName}",
            ChangeDate = customer.CreateDate
        }, cancellationToken);

        return customer.ToCustomerInfo();
    }
}
