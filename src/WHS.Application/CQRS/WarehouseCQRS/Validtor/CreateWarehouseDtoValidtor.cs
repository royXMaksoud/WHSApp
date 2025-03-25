using FluentValidation;
using System.ComponentModel;
using WHS.Application.CQRS.WarehouseCQRS.Commands;

namespace WHS.Application.CQRS.WarehouseCQRS.Validtor;

public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
{
    private readonly List<Guid> notvalidBranches = [Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f56")];

    public CreateWarehouseCommandValidator()
    {
        RuleFor(x => x.WarehouseName).Length(3, 100);
        RuleFor(dto => dto.WarehouseName).NotEmpty().WithMessage("Name is required");
        RuleFor(dto => dto.DutyStationId).NotEmpty().WithMessage("Duty Station is required");
        RuleFor(dto => dto.BranchId).NotEmpty().WithMessage("Branch is required").Must(branchId => !notvalidBranches.Contains(branchId)).WithMessage("Branch Name should not have BRS value");
    }
}