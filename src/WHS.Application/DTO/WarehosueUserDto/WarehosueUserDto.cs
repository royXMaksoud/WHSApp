public class WarehosueUserDto
{
    public Guid WarehosueUserId { get; set; } // Primary Key
    public string UserName { get; set; }

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