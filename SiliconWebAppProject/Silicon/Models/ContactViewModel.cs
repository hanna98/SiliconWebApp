using System.ComponentModel.DataAnnotations;

namespace Silicon.Models;

public class ContactViewModel
{
    [Display(Name = "FullName", Prompt = "Enter your full name")]
    [Required(ErrorMessage = "You must enter a full name")]
    [MinLength(2, ErrorMessage = "A valid full name is required")]
    [DataType(DataType.Text)]
    public string FullName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?).[a-zA-Z]{2,}$", ErrorMessage = "An valid email address is required")]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "A valid email is requierd")]
    public string Email { get; set; } = null!;

    [Display(Name = "Service (Optional)", Prompt = "Choose the service you are interested in")]
    public string? Service { get; set; }

    [Display(Name = "Message", Prompt = "Enter your message here...")]
    [Required(ErrorMessage = "You must enter a message")]
    public string Message { get; set; } = null!;
}
