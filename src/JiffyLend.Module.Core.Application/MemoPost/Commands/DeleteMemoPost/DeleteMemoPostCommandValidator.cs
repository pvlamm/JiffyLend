namespace JiffyLend.Module.Core.Application.MemoPost.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class DeleteMemoPostCommandValidator : AbstractValidator<DeleteMemoPostCommand>
{
    public static string ERROR_MEMOPOST_ID_NOT_FOUND = "MemoPost Not Found";
    public static string ERROR_MEMOPOST_CANNOT_DELETE = "MemoPost Cannot be Deleted";
    public DeleteMemoPostCommandValidator(IMemoPostService memoPostService)
    {
        RuleFor(x => x.Id)
            .Must(memoPostService.Exists)
            .WithMessage(ERROR_MEMOPOST_ID_NOT_FOUND)
            .Must(memoPostService.CanDelete)
            .WithMessage(ERROR_MEMOPOST_CANNOT_DELETE);
    }
}
