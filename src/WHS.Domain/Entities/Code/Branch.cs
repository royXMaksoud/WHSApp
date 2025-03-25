namespace WHS.Domain.Entities.Code
{
    public class Branch
    {
        public Guid BranchId { get; set; } // Primary Key
        public string BranchName { get; set; }
        public Guid OrganizationId { get; set; }  // Foreign Key to Organization
        public Organization Organization { get; set; }  // Navigation Property

        // Navigation Properties
        public ICollection<Warehouse> Warehouses { get; set; }  // Related Warehouses
    }
}