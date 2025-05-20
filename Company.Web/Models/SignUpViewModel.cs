using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = " Invalid Format For Email")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=(.*[a-z]){1,})(?=(.*[A-Z]){1,})(?=(.*\d){1,})(?=(.*\W){1,})(?!.*(.)\1{2,}).{6,}$", ErrorMessage = "Password must be at least 6 characters long, with at least one lowercase letter, one uppercase letter, one digit, one special character, and at least 2 unique characters.")]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not match password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Required To Agree")]
        public bool IsAgree { get; set; }

    }
}
