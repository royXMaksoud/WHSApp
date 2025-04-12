namespace WHS.Application.DTO.Account.User
{
    public class UserDto
    {
        public Guid UserId { get; set; } // Primary Key
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }
        public bool IsActive { get; set; }
    }
}