using System.ComponentModel.DataAnnotations;

namespace WattPad.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [StringLength(150, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required.")]
      
        public int Role { get; set; }

    }
}
