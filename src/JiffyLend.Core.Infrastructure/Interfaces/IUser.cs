namespace JiffyLend.Core.Infrastructure.Interfaces;

using System;

public interface IUser
{
    Guid Id { get; }
    string DisplayName { get; }
    string EmailAddress { get; }
}