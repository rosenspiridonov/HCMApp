using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Api.Models.Users
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
