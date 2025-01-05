namespace JiffyLend.Module.Core.Application.Common.Interfaces;

using System;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;

public interface ICustomerService
{
    bool EmailExists(string email);

    bool Exists(Guid id);

    Task<Customer> GetCustomerById(Guid id, CancellationToken token = default);

    Task<Customer> GetCustomerByEmailAddress(string emailAddress, CancellationToken token = default);

    Task<Guid> Create(Customer customer, CancellationToken token = default);

    Task Update(Customer customer, CancellationToken token = default);

    Task Delete(Guid id, CancellationToken token = default);
}