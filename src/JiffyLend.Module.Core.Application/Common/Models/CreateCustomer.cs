namespace JiffyLend.Module.Core.Application.Common.Models;

using System;

public class CreateCustomer
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string EmailAddress { get; set; }
    public virtual DateTime DateOfBirth { get; set; }
}