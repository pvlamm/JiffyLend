namespace JiffyLend.Module.Core.Application.Common.Models;
using System;

public class CustomerInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime Created { get; set; }
}
