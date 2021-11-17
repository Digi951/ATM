namespace API.DTOs
{
    public class UserDto
    {    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string Token { get; set; }
    }
}