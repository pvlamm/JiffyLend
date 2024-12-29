namespace JiffyLend.Module.Core.Application.Customer.Commands;

using System;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

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

    public CreateCustomerCommandHanlder(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerService.Create(request.ToCustomer(), cancellationToken);
    }
}