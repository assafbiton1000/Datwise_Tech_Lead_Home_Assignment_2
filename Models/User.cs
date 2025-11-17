using System.ComponentModel.DataAnnotations;

namespace Datwise_Tech_Lead_Home_Assignment.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }


        public string Role { get; set; }

        public bool IsActive { get; set; }
    }
}