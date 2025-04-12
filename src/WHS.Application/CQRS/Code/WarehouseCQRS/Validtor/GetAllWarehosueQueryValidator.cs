using FluentValidation;
using WHS.Application.CQRS.Code.WarehouseCQRS.Queries;
using WHS.Application.GenericValidtor;

namespace WHS.Application.CQRS.Code.WarehouseCQRS.Validtor
{
    public class GetAllWarehousesQueryValidator : BaseQueryValidator<GetAllWarehousesQuery>
    {
        public GetAllWarehousesQueryValidator()
            : base(new[] { 5, 10, 15, 30 },
                   new[] { nameof(WarehouseDto.WarehouseName), nameof(WarehouseDto.DutyStationName) })
        {
        }
    }

    //public class GetAllWarehosueQueryValidator : AbstractValidator<GetAllWarehousesQuery>
    //{
    //    private int[] allowPageSize = [5, 10, 15, 30];
    //    private string[] allowedSortByColumnNames = [nameof(WarehouseDto.WarehouseName), nameof(WarehouseDto.DutyStationName)];

    //    public GetAllWarehosueQueryValidator()
    //    {
    //        RuleFor(f => f.PageNumber).GreaterThanOrEqualTo(1);
    //        RuleFor(r => r.PageSize).Must(value => allowPageSize.Contains(value)).WithMessage($"Page size must be in [{string.Join(", ", allowPageSize)}].");
    //        RuleFor(r => r.SortBy).
    //            Must(value => allowedSortByColumnNames.Contains(value))
    //            .When(x => x.SortBy != null)
    //            .WithMessage($"Sort by is optional,or must be in[{string.Join(",", allowedSortByColumnNames)}");
    //    }
    //}
}