using WHS.Application.DTO.DutyStation;

public class WarehouseDto
{
    public Guid WarehouseId { get; set; } // Primary Key
    public string WarehouseName { get; set; }
    public Guid DutyStationId { get; set; } // Foreign Key to Duty Station
    public Guid BranchId { get; set; } // Foreign Key to Duty BRANCH
    public string BranchName { get; set; } = default!;
    public string DutyStationName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public DateTime? CreateDate { get; set; }
    public List<WarehosueUserDto> WarehosueUsers { get; set; } = [];

    public DutyStationDto DutyStation { get; set; } = default!;

    //public static WarehouseDto FromEntity(Warehouse? x)
    //{
    //    if (x == null) return null;
    //    return new WarehouseDto()
    //    {
    //        WarehouseId = x.WarehouseId,
    //        WarehouseName = x.WarehouseName,
    //        warehouseFocalPoints= x.WarehouseFocalPoints?.Select(WarehouseFocalPointDto.FromEntity).ToList() ?? new List<WarehouseFocalPointDto>()
    //    };
    //}
}