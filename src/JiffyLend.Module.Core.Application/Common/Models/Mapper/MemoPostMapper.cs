namespace JiffyLend.Module.Core.Application.Common.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.MemoPost.Commands.CreateMemoPost;

using Riok.Mapperly.Abstractions;

[Mapper]
public partial class MemoPostMapper
{
    public partial CreateMemoPostCommand ToCreateMemoPostCommand(CreateMemoPost createMemoPost);
    
}
