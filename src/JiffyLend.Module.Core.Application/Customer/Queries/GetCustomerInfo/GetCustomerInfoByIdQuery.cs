namespace JiffyLend.Module.Core.Application.Customer.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class GetCustomerInfoByIdQuery : IRequest<Result<CustomerInfo>>
{
    public Guid Id { get; set; }
}

public class GetCustomerInfoByIdQueryHandler : IRequestHandler<GetCustomerInfoByIdQuery, Result<CustomerInfo>>
{
    private readonly ICustomerService _customerService;
    public GetCustomerInfoByIdQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public async Task<Result<CustomerInfo>> Handle(GetCustomerInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerService
            .GetCustomerById(request.Id, cancellationToken);

        return customer.ToCustomerInfo();
    }
}
