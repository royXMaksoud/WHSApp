

using FluentValidation;
using WHS.Application.DTO.Warehouse;

namespace WHS.Application.Validators.Warehouse;

public class CreateWarehouseDtoValidtor : AbstractValidator<CreateWarehouseDto>
{
    private readonly List<string> validCategories = ["STI", "Non STI"];
    public CreateWarehouseDtoValidtor()
    {
        RuleFor(x => x.WarehouseName).Length(3, 100);
        RuleFor(dto => dto.WarehouseName).NotEmpty().WithMessage("Name is required");
        RuleFor(dto => dto.BranchName).Must(validCategories.Contains).WithMessage("Branch Name should have a valid value");
    }

}
