namespace JiffyLend.Core.Infrastructure.Messages;

using System;

public interface IUpdatedAnAccount
{
    Guid Id { get; }
    string Title { get; }
    bool IsActive { get; }
    DateTime ChangeDate { get; }
}