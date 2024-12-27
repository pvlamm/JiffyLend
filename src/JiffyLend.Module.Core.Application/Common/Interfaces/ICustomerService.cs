namespace JiffyLend.Module.Core.Application.Common.Interfaces;
using System;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;

public interface ICustomerService
{
    Task<bool> EmailExists(string email);
    Task<Guid> Create(Customer customer);
    Task<bool> Update(Customer customer);
    Task<bool> Delete(Guid id);

}
