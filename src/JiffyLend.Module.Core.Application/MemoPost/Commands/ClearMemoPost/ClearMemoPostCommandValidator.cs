namespace JiffyLend.Module.Core.Application.MemoPost.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class ClearMemoPostCommandValidator : AbstractValidator<ClearMemoPostCommand>
{
    public ClearMemoPostCommandValidator(IMemoPostService memoPostService)
    {
    }
}
