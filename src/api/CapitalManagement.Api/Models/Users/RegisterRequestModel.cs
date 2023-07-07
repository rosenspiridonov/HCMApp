using System.ComponentModel.DataAnnotations;

namespace CapitalManagement.Api.Models.Users
{
    public class RegisterRequestModel : LoginRequestModel
    {
        [Required]
        public string Email { get; set; }
    }
}
