namespace JiffyLend.Module.Core.Application.MemoPost.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

public class DeleteMemoPostCommandValidator : AbstractValidator<DeleteMemoPostCommand>
{
    public DeleteMemoPostCommandValidator()
    {
    }
}
