namespace JiffyLend.Core.Infrastructure.Messages;

using System;

public interface ICreatedACustomer
{
    Guid Id { get; }
    string DisplayName { get; }
    DateTime ChangeDate { get; }
}