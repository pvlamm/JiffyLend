namespace JiffyLend.Module.Core.Application.Common.Interfaces;

using System;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;

public interface IMemoPostService
{
    bool Exists(Guid id);

    bool CanClear(Guid id);

    bool CanDelete(Guid id);

    Task<Guid> Create(MemoPost memoPost, CancellationToken token = default);

    Task<bool> Delete(Guid id, CancellationToken token = default);

    Task<bool> Clear(Guid id, CancellationToken token = default);
}