namespace JiffyLend.Module.Core.Application.Customer.Commands;
using System;

using JiffyLend.Module.Core.Application.Common.Interfaces;

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

    public Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}