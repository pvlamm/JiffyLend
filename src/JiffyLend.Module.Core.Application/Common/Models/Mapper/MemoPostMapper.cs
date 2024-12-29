namespace JiffyLend.Module.Core.Application.Common.Models.Mapper;

using JiffyLend.Module.Core.Application.MemoPost.Commands.CreateMemoPost;
using JiffyLend.Module.Core.Domain.Entities;

using Riok.Mapperly.Abstractions;

[Mapper]
public partial class MemoPostMapper
{
    public partial CreateMemoPostCommand ToCreateMemoPostCommand(CreateMemoPost createMemoPost);

    public partial MemoPost ToMemoPost(CreateMemoPostCommand createMemoPostCommand);
}