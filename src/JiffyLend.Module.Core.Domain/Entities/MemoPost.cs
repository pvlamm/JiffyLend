namespace JiffyLend.Module.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record MemoPost
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? CompleteDate { get; set; }
    public DateTime? CancelDate { get; set; }
    public string Description { get; set; }
    public long Amount { get; set; }
}
