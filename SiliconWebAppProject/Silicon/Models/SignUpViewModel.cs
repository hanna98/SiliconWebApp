using Silicon.Filters;
using System.ComponentModel.DataAnnotations;

namespace Silicon.Models;

public class SignUpViewModel
{
    [Display(Name = "FirstName", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "You must enter a first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "You must enter a last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?).[a-zA-Z]{2,}$", ErrorMessage = "An valid email address is required")]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "A valid email is requierd")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "You must enter a password")]
    [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,})", ErrorMessage = "A valid password is required")]
    [MinLength(8, ErrorMessage = "A length more than 8 characters is requierd")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password", Prompt = " Confirm your password")]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Password don't match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Terms & Conditions", Prompt = "I agree to the Terms & Conditions.")]
    [Required(ErrorMessage = "You must accept the Terms & Conditions")]
    [CheckBoxRequired]
    public bool TermsAndConditions { get; set;}
}