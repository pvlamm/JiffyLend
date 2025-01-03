namespace JiffyLend.Module.Card.Application.Card.Commands;

using FluentValidation;

using JiffyLend.Core.Infrastructure.Interfaces;
using JiffyLend.Module.Card.Application.Common.Interfaces;

public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
{
    public CreateCardCommandValidator(ICardService cardService, ICoreHttpClient coreHttpClient)
    {
        RuleFor(x => x.AccountId)
            .NotEmpty()
            .NotNull()
            .WithMessage("AccountId is required")
            .Must(x => {

                var accountInfo = coreHttpClient.GetAccountInfo(x, default).Result;

                if(accountInfo == null)
                {
                    return false;
                }
                return true;
            });

        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull()
            .WithMessage("CustomerId is required")
            .Must(x => {

                var customerInfo = coreHttpClient.GetCustomerInfo(x, default).Result;

                if (customerInfo == null)
                {
                    return false;
                }
                return true;
            });
    }
}
