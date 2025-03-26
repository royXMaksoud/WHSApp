using FluentValidation;
using WHS.Application.CQRS.WarehouseCQRS.Queries;

namespace WHS.Application.CQRS.WarehouseCQRS.Validtor
{
    public class GetAllwarehouseQueryValidator : AbstractValidator<GetAllWarehousesQuery>
    {
        private int[] allowPageSize = [5, 10, 15, 30];
        private string[] allowedSortByColumnNames = [nameof(WarehouseDto.WarehouseName), nameof(WarehouseDto.DutyStationName)];

        public GetAllwarehouseQueryValidator()
        {
            RuleFor(f => f.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Must(value => allowPageSize.Contains(value)).WithMessage($"Page size must be in [{string.Join(", ", allowPageSize)}].");
            RuleFor(r => r.SortBy).
                Must(value => allowedSortByColumnNames.Contains(value))
                .When(x => x.SortBy != null)
                .WithMessage($"Sort by is optional,or must be in[{string.Join(",", allowedSortByColumnNames)}");
        }
    }
}