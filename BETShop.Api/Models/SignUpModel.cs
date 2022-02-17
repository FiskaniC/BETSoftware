using System.ComponentModel.DataAnnotations;

namespace BETShop.Api.Models
{
    public class SignUpModel : SignInModel
    {
        [Required(ErrorMessage = "Password is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
