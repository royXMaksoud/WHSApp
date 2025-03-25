namespace WHS.Application.DTO.User
{
    public class UserDto
    {
        public Guid UserId { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}