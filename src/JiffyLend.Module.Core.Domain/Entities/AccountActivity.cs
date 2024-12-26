﻿namespace JiffyLend.Module.Core.Domain.Entities;
using System;

public record AccountActivity
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public Guid? MemoPostId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string ReferenceNumber { get; set; }
    public long Amount { get; set; } = 0;
    
}
