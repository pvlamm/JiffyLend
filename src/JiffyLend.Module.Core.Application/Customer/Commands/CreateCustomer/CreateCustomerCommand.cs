namespace JiffyLend.Module.Core.Application.Customer.Commands;
using System;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class CreateCustomerCommand : IRequest<Guid>
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string EmailAddress { get; set; }
    public virtual DateTime DateOfBirth { get; set; }
}

public class CreateCustomerCommandHanlder : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerService _customerService;
    public CreateCustomerCommandHanlder(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerService.Create(request.ToCustomer(), cancellationToken);
    }
}