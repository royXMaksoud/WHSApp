using FluentValidation;
using WHS.Application.CQRS.InventoryItemCQRS.Commands;

namespace WHS.Application.CQRS.InventoryItemCQRS.Validtor
{
    public class CreateInventoryItemCommandValidtor : AbstractValidator<CreateInventoryItemCommand>
    {
        public CreateInventoryItemCommandValidtor()
        {
            RuleFor(d => d.UnitPrice)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Price must be a non negative number");

            RuleFor(d => d.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Quantity must be a non-negative number");
        }
    }
}