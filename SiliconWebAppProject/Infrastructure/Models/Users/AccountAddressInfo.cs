using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Users;

public class AccountAddressInfo
{
    [Required(ErrorMessage = "You must enter a address line")]
    [Display(Name = "Addressline 1", Prompt = "Enter your addressline")]
    public string AddressLine_1 { get; set; } = null!;

    [Display(Name = "Addressline 2 (Optional)", Prompt = "Enter your second addressline")]
    public string? AddressLine_2 { get; set; }

    [Required(ErrorMessage = "You must enter a postal code")]
    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a city")]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;
}
