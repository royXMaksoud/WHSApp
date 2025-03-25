using FluentValidation;
using WHS.Application.CQRS.WarehouseCQRS.Commands;

namespace WHS.Application.CQRS.WarehouseCQRS.Validtor;

public class UpdateWarehouseValidtor : AbstractValidator<UpdateWarehouseCommand>
{
    public UpdateWarehouseValidtor()
    {
        RuleFor(c => c.WarehouseName).
            Length(3, 100);
    }
}