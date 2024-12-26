namespace JiffyLend.Module.Core.Application.Common.Interfaces;
using System;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;
public interface IMemoPostService
{
    bool Exists(Guid id);
    bool CanClear(Guid id);
    bool CanDelete(Guid id);

    Task<Guid> Create(MemoPost memoPost);
    Task<bool> Delete(Guid id);
    Task<bool> Clear(Guid id);
}
