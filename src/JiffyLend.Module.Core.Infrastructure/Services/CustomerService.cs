namespace JiffyLend.Module.Core.Infrastructure.Services;

using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public class CustomerService : ICustomerService
{
    private readonly ICoreDbContext _context;

    public CustomerService(ICoreDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Customer customer, CancellationToken token = default)
    {
        await _context.AccountCustomers.AddAsync(customer, token);
        await _context.SaveChangesAsync(token);

        return customer.Id;
    }

    public Task Delete(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public bool EmailExists(string email)
    {
        return _context.AccountCustomers.Any(x => x.EmailAddress == email);
    }

    public bool Exists(Guid id)
    {
        return _context.AccountCustomers.Any(x => x.Id == id);
    }

    public async Task<Customer> GetCustomerByEmailAddress(string emailAddress, CancellationToken token = default)
    {
        return await _context.AccountCustomers
            .SingleAsync(x => x.EmailAddress == emailAddress, token);
    }

    public async Task<Customer> GetCustomerById(Guid id, CancellationToken token = default)
    {
        return await _context.AccountCustomers
            .SingleAsync(x => x.Id == id, token);
    }

    public async Task Update(Customer customer, CancellationToken token = default)
    {
        _context.AccountCustomers.Attach(customer);
        await _context.SaveChangesAsync(token);
    }
}