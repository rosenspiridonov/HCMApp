using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Web.Models.Users
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
