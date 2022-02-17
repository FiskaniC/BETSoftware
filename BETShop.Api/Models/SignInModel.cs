using System.ComponentModel.DataAnnotations;

namespace BETShop.Api.Models
{
    public class SignInModel
    {
        [EmailAddress(ErrorMessage = "Email is invalid")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
