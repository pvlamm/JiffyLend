namespace JiffyLend.Module.Core.Application.Common.Models;

using System;

public class CreateAccount
{
    public string Title { get; set; }
    public Guid CustomerId { get; set; }
}