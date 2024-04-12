using System.ComponentModel.DataAnnotations;

namespace Silicon.Models;

public class SignInViewModel
{
    [Display(Name = "Email address", Prompt = " Enter your email address")]
    [Required(ErrorMessage = "A valid email is requierd")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = " Enter your password")]
    [Required(ErrorMessage = "A valid password is requierd")]
    [MinLength(8, ErrorMessage = "A valid password is requierd")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}
