using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Web.Models.Users
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
