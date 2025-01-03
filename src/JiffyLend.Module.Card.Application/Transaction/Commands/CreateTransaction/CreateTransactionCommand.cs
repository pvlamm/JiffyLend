namespace JiffyLend.Module.Card.Application.Transaction.Commands.CreateTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

public class CreateTransactionCommand : IRequest<Result<Guid>>
{
}

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}