namespace JiffyLend.Core.Infrastructure.Messages;

using System;

public interface ICreatedAnAccount
{
    Guid Id { get; }
    string Title { get; }
    bool IsActive { get; }
    DateTime ChangeDate { get; }
}