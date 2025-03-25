using Microsoft.AspNetCore.Identity;
using WHS.Domain.Entities.Code;

namespace WHS.Domain.Entities.Account
{
    public class User : IdentityUser
    {
        public string? Nationality { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public List<Warehouse> OwnedWarehouses { get; set; } = [];
    }
}