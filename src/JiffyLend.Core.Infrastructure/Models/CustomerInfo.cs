namespace JiffyLend.Core.Infrastructure.Models;

using System;

public class CustomerInfo
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime Created { get; set; }
}