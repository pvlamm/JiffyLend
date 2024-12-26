namespace JiffyLend.Core.Infrastructure.Messages;
using System;

public interface IUpdatedACustomer
{
    Guid Id { get; }
    string DisplayName { get; }
    DateTime ChangeDate { get; }
}
