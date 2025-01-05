namespace JiffyLend.Module.Card.Application.Transaction.Commands.ClearTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

public class ClearTransactionCommand : IRequest
{
}

public class ClearTransactionCommandHandler : IRequestHandler<ClearTransactionCommand>
{
    public async Task Handle(ClearTransactionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}