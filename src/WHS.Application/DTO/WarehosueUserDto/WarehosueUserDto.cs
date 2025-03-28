public class warehouseUserDto
{
    public Guid warehouseUserId { get; set; } // Primary Key
    public string UserName { get; set; } = default!;

    public DateTime? CreateDate { get; set; }
   
    //public static WarehouseFocalPointDto FromEntity(WarehouseFocalPoint focalpoint)
    //{
    //    return new WarehouseFocalPointDto()
    //    {
    //        WarehouseFocalId = focalpoint.WarehouseFocalId,
    //        CreateDate = focalpoint.CreateDate
    //    };
    //}
}