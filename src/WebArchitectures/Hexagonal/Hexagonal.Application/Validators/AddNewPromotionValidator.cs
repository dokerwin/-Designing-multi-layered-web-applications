using FluentValidation;
using Hexagonal.Domain.Services.Persistance.Interfaces;
using Hexagonal.Shared.Application.DTOs;

namespace Hexagonal.Aplications.Validators;

public class AddNewPromotionValidator : AbstractValidator<PromotionDto>
{
    public AddNewPromotionValidator(IUnitOfWork unitOfWork)
    {

        RuleFor(x => x.Name)
           .NotEmpty().MinimumLength(10).MaximumLength(100);

        RuleFor(x => x.StartTime)
           .NotEmpty().WithMessage("Start time is required")
           .LessThan(x => x.EndTime).WithMessage("Start time must be earlier than end time");

        RuleFor(x => x.Name).Custom(async (value, context) =>
        {
            var promotionNameInUse = await unitOfWork.Promotions.FindByName(value);
            if (promotionNameInUse != null && promotionNameInUse.Name != null)
            {
                context.AddFailure("Name", "Promotion name is taken");
            }
        });
        
    }
}

