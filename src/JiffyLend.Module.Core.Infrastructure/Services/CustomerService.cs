namespace JiffyLend.Module.Core.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Domain.Entities;

public class CustomerService : ICustomerService
{
    public Task<Guid> Create(Customer customer, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public bool EmailExists(string email)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Guid id)
    {
        return false;
    }

    public Task<Customer> GetCustomerByEmailAddress(string emailAddress, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetCustomerById(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Customer customer, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
