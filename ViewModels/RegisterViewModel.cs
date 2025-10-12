using System.ComponentModel.DataAnnotations;

namespace FightClub.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
