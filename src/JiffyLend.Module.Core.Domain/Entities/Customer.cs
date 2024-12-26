namespace JiffyLend.Module.Core.Domain.Entities;
using System;
using System.Collections.Generic;

public record Customer
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string EmailAddress { get; set; }
    public virtual DateTime DateOfBirth { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public IEnumerable<Account> Accounts { get; set; }
}
