namespace JiffyLend.Module.Core.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Domain.Entities;

public class MemoPostService : IMemoPostService
{
    public bool CanClear(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool CanDelete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Clear(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(MemoPost memoPost, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Guid id)
    {
        throw new NotImplementedException();
    }
}
