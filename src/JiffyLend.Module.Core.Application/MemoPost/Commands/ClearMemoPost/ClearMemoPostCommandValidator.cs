namespace JiffyLend.Module.Core.Application.MemoPost.Commands;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class ClearMemoPostCommandValidator : AbstractValidator<ClearMemoPostCommand>
{
    public static string ERROR_MEMO_POST_CANNOT_CLEAR = "MemoPost Cannot be Cleared";

    public ClearMemoPostCommandValidator(IMemoPostService memoPostService)
    {
        RuleFor(x => x.Id)
            .Must(memoPostService.CanClear)
            .WithMessage(ERROR_MEMO_POST_CANNOT_CLEAR);
    }
}